namespace skoda.staz
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form


        private void InitializeComponent()
        {
            this.btnPlan = new System.Windows.Forms.Button();
            this.btnSklad = new System.Windows.Forms.Button();
            this.btnDodavatel = new System.Windows.Forms.Button();
            this.btnGenerovat = new System.Windows.Forms.Button();
            this.dgvVysledky = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVysledky)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlan
            // 
            this.btnPlan.BackColor = System.Drawing.Color.Ivory;
            this.btnPlan.Location = new System.Drawing.Point(129, 62);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(138, 37);
            this.btnPlan.TabIndex = 0;
            this.btnPlan.Text = "Načíst plán";
            this.btnPlan.UseVisualStyleBackColor = false;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // btnSklad
            // 
            this.btnSklad.BackColor = System.Drawing.Color.Ivory;
            this.btnSklad.Location = new System.Drawing.Point(129, 127);
            this.btnSklad.Name = "btnSklad";
            this.btnSklad.Size = new System.Drawing.Size(138, 37);
            this.btnSklad.TabIndex = 1;
            this.btnSklad.Text = "Načíst sklad";
            this.btnSklad.UseVisualStyleBackColor = false;
            this.btnSklad.Click += new System.EventHandler(this.btnSklad_Click);
            // 
            // btnDodavatel
            // 
            this.btnDodavatel.BackColor = System.Drawing.Color.Ivory;
            this.btnDodavatel.Location = new System.Drawing.Point(129, 194);
            this.btnDodavatel.Name = "btnDodavatel";
            this.btnDodavatel.Size = new System.Drawing.Size(138, 37);
            this.btnDodavatel.TabIndex = 2;
            this.btnDodavatel.Text = "Načíst dodavatele";
            this.btnDodavatel.UseVisualStyleBackColor = false;
            this.btnDodavatel.Click += new System.EventHandler(this.btnDodavatel_Click);
            // 
            // btnGenerovat
            // 
            this.btnGenerovat.BackColor = System.Drawing.Color.Ivory;
            this.btnGenerovat.Location = new System.Drawing.Point(129, 251);
            this.btnGenerovat.Name = "btnGenerovat";
            this.btnGenerovat.Size = new System.Drawing.Size(138, 37);
            this.btnGenerovat.TabIndex = 3;
            this.btnGenerovat.Text = "Generovat";
            this.btnGenerovat.UseVisualStyleBackColor = false;
            this.btnGenerovat.Click += new System.EventHandler(this.btnGenerovat_Click);
            // 
            // dgvVysledky
            // 
            this.dgvVysledky.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVysledky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVysledky.GridColor = System.Drawing.Color.LightGreen;
            this.dgvVysledky.Location = new System.Drawing.Point(352, 62);
            this.dgvVysledky.Name = "dgvVysledky";
            this.dgvVysledky.ReadOnly = true;
            this.dgvVysledky.RowHeadersWidth = 51;
            this.dgvVysledky.RowTemplate.Height = 24;
            this.dgvVysledky.Size = new System.Drawing.Size(1119, 504);
            this.dgvVysledky.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(124, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Načti soubory";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(347, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Výsledný report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1475, 568);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvVysledky);
            this.Controls.Add(this.btnGenerovat);
            this.Controls.Add(this.btnDodavatel);
            this.Controls.Add(this.btnSklad);
            this.Controls.Add(this.btnPlan);
            this.Name = "Form1";
            this.Text = "Správa údržby letadel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVysledky)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlan;
        private System.Windows.Forms.Button btnSklad;
        private System.Windows.Forms.Button btnDodavatel;
        private System.Windows.Forms.Button btnGenerovat;
        private System.Windows.Forms.DataGridView dgvVysledky;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}