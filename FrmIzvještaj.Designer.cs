namespace CarCar
{
    partial class FrmIzvještaj
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNaslov = new System.Windows.Forms.Label();
            this.lblVozilo = new System.Windows.Forms.Label();
            this.cmbVozilo = new System.Windows.Forms.ComboBox();
            this.lblGodina = new System.Windows.Forms.Label();
            this.nudGodina = new System.Windows.Forms.NumericUpDown();
            this.btnGeneriraj = new System.Windows.Forms.Button();
            this.btnOdbaci = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGodina)).BeginInit();
            this.SuspendLayout();
            //
            // lblNaslov
            //
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.Location = new System.Drawing.Point(60, 20);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(247, 21);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "Unos podataka za izvještaj";
            //
            // lblVozilo
            //
            this.lblVozilo.AutoSize = true;
            this.lblVozilo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVozilo.Location = new System.Drawing.Point(64, 75);
            this.lblVozilo.Name = "lblVozilo";
            this.lblVozilo.Size = new System.Drawing.Size(52, 20);
            this.lblVozilo.TabIndex = 1;
            this.lblVozilo.Text = "Vozilo";
            //
            // cmbVozilo
            //
            this.cmbVozilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVozilo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbVozilo.Location = new System.Drawing.Point(170, 72);
            this.cmbVozilo.Name = "cmbVozilo";
            this.cmbVozilo.Size = new System.Drawing.Size(160, 28);
            this.cmbVozilo.TabIndex = 2;
            //
            // lblGodina
            //
            this.lblGodina.AutoSize = true;
            this.lblGodina.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGodina.Location = new System.Drawing.Point(64, 120);
            this.lblGodina.Name = "lblGodina";
            this.lblGodina.Size = new System.Drawing.Size(57, 20);
            this.lblGodina.TabIndex = 3;
            this.lblGodina.Text = "Godina";
            //
            // nudGodina
            //
            this.nudGodina.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudGodina.Location = new System.Drawing.Point(170, 118);
            this.nudGodina.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.nudGodina.Minimum = new decimal(new int[] { 1990, 0, 0, 0 });
            this.nudGodina.Name = "nudGodina";
            this.nudGodina.Size = new System.Drawing.Size(120, 27);
            this.nudGodina.TabIndex = 4;
            this.nudGodina.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            //
            // btnGeneriraj
            //
            this.btnGeneriraj.Location = new System.Drawing.Point(64, 175);
            this.btnGeneriraj.Name = "btnGeneriraj";
            this.btnGeneriraj.Size = new System.Drawing.Size(100, 35);
            this.btnGeneriraj.TabIndex = 5;
            this.btnGeneriraj.Text = "Generiraj";
            this.btnGeneriraj.UseVisualStyleBackColor = true;
            this.btnGeneriraj.Click += new System.EventHandler(this.btnGeneriraj_Click);
            //
            // btnOdbaci
            //
            this.btnOdbaci.Location = new System.Drawing.Point(190, 175);
            this.btnOdbaci.Name = "btnOdbaci";
            this.btnOdbaci.Size = new System.Drawing.Size(100, 35);
            this.btnOdbaci.TabIndex = 6;
            this.btnOdbaci.Text = "Odbaci";
            this.btnOdbaci.UseVisualStyleBackColor = true;
            this.btnOdbaci.Click += new System.EventHandler(this.btnOdbaci_Click);
            //
            // FrmIzvještaj
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.btnOdbaci);
            this.Controls.Add(this.btnGeneriraj);
            this.Controls.Add(this.nudGodina);
            this.Controls.Add(this.lblGodina);
            this.Controls.Add(this.cmbVozilo);
            this.Controls.Add(this.lblVozilo);
            this.Controls.Add(this.lblNaslov);
            this.Name = "FrmIzvještaj";
            this.Text = "CarCar - Unos podataka za izvještaj";
            this.Load += new System.EventHandler(this.FrmIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGodina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Label lblVozilo;
        private System.Windows.Forms.ComboBox cmbVozilo;
        private System.Windows.Forms.Label lblGodina;
        private System.Windows.Forms.NumericUpDown nudGodina;
        private System.Windows.Forms.Button btnGeneriraj;
        private System.Windows.Forms.Button btnOdbaci;
    }
}