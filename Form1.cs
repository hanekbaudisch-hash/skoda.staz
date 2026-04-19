using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace skoda.staz
{
    public partial class Form1 : Form
    {
        string cestaPlan = "";
        string cestaSklad = "";
        string cestaDodavatele = ""; 

        public Form1()
        {
            InitializeComponent(); 
        }

        private string VyberSoubor() //vybira pouze excel soubory
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel (*.xlsx)|*.xlsx";
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : "";
            }
        } 

        private DataTable NactiExcel(string cesta)
        {
            var dt = new DataTable();

            using (var wb = new XLWorkbook(cesta))
            {
                var ws = wb.Worksheet(1);
                bool firstRow = true;

                foreach (var row in ws.RowsUsed())
                {
                    if (firstRow)
                    {
                        foreach (var cell in row.Cells())
                            dt.Columns.Add(cell.Value.ToString().Trim());
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add(row.Cells().Select(c => c.Value.ToString().Trim()).ToArray());
                    }
                }
            }
            return dt;
        }

        private bool ZkontrolujSloupce(DataTable dt, params string[] sloupce) //kontroluje zda dany exccel obsahuje potrebne sloupce
        {
            foreach (var s in sloupce)
            {
                if (!dt.Columns.Contains(s))
                    return false;
            }
            return true;
        }

        private List<VystupniRadek> AnalyzujData(DataTable dtPlan, DataTable dtSklad, DataTable dtDodavatele) //vysledna tabulka a sloupce
        {
            var report = new List<VystupniRadek>();

            foreach (DataRow r in dtPlan.Rows)
            {
                string kod = r["Kod_Soucastky"].ToString();

                var radek = new VystupniRadek
                {
                    ID_Letadla = r["ID_Letadla"].ToString(),
                    Kod_Soucastky = kod
                };

                var sklad = dtSklad.AsEnumerable()
                    .FirstOrDefault(s =>
                        s["Kod_Soucastky"].ToString() == kod &&
                        int.TryParse(s["Skladem_ks"].ToString(), out int ks) && ks > 0);

                if (sklad != null)
                {
                    radek.Stav = "Skladem";
                    radek.DodavatelUmisteni = sklad["Umisteni"].ToString();
                    radek.Cena = "0 CZK";
                    radek.Termin_Dodani = "Ihned";
                }
                else
                {
                    var dod = dtDodavatele.AsEnumerable()
                        .Where(d => d["Kod_Soucastky"].ToString() == kod)
                        .OrderBy(d =>
                        {
                            double.TryParse(d["Cena_CZK"].ToString(), out double cena);
                            return cena;
                        })
                        .FirstOrDefault();

                    if (dod != null)
                    {
                        radek.Stav = "Objednat";
                        radek.DodavatelUmisteni = dod["Dodavatel"].ToString();
                        radek.Cena = dod["Cena_CZK"] + " CZK";
                        radek.Termin_Dodani = dod["Dodani_Dny"] + " dní";
                    }
                    else
                    {
                        radek.Stav = "Nenalezeno";
                        radek.DodavatelUmisteni = "Chybí data";
                        radek.Cena = "-";
                        radek.Termin_Dodani = "-";
                    }
                }

                report.Add(radek);
            }

            return report;
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            cestaPlan = VyberSoubor();
        }

        private void btnSklad_Click(object sender, EventArgs e)
        {
            cestaSklad = VyberSoubor();
        }

        private void btnDodavatel_Click(object sender, EventArgs e)
        {
            cestaDodavatele = VyberSoubor();
        }

        private void btnGenerovat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cestaPlan) ||
                    string.IsNullOrEmpty(cestaSklad) ||
                    string.IsNullOrEmpty(cestaDodavatele))
                {
                    MessageBox.Show("Vyber všechny soubory!");
                    return;
                }

                var dtPlan = NactiExcel(cestaPlan);
                var dtSklad = NactiExcel(cestaSklad);
                var dtDod = NactiExcel(cestaDodavatele);

                if (!ZkontrolujSloupce(dtPlan, "Kod_Soucastky", "ID_Letadla") ||
                    !ZkontrolujSloupce(dtSklad, "Kod_Soucastky", "Skladem_ks", "Umisteni") ||
                    !ZkontrolujSloupce(dtDod, "Kod_Soucastky", "Cena_CZK", "Dodavatel", "Dodani_Dny"))
                {
                    MessageBox.Show("Některý soubor nemá správné sloupce!");
                    return;
                }

                var vysledky = AnalyzujData(dtPlan, dtSklad, dtDod);

                dgvVysledky.DataSource = vysledky;

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                    sfd.FileName = "finalni_report.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        UlozDoExcelu(vysledky, sfd.FileName);
                        MessageBox.Show("Report uložen!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void UlozDoExcelu(List<VystupniRadek> data, string cesta)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Report");

                ws.Cell(1, 1).Value = "ID_Letadla";
                ws.Cell(1, 2).Value = "Kod_Soucastky";
                ws.Cell(1, 3).Value = "Stav";
                ws.Cell(1, 4).Value = "Dodavatel/Umisteni";
                ws.Cell(1, 5).Value = "Cena";
                ws.Cell(1, 6).Value = "Termin_Dodani";

                for (int i = 0; i < data.Count; i++)
                {
                    ws.Cell(i + 2, 1).Value = data[i].ID_Letadla;
                    ws.Cell(i + 2, 2).Value = data[i].Kod_Soucastky;
                    ws.Cell(i + 2, 3).Value = data[i].Stav;
                    ws.Cell(i + 2, 4).Value = data[i].DodavatelUmisteni;
                    ws.Cell(i + 2, 5).Value = data[i].Cena;
                    ws.Cell(i + 2, 6).Value = data[i].Termin_Dodani;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(cesta);
            }
        }

    }

    public class VystupniRadek
    {
        public string ID_Letadla { get; set; }
        public string Kod_Soucastky { get; set; }
        public string Stav { get; set; }
        public string DodavatelUmisteni { get; set; }
        public string Cena { get; set; }
        public string Termin_Dodani { get; set; }
    }
}