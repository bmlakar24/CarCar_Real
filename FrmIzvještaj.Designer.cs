namespace CarCar
{
    partial class FrmIzvještaj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRegIzvještaj = new System.Windows.Forms.Label();
            this.lblOdIzvještaj = new System.Windows.Forms.Label();
            this.lblDoIzvještaj = new System.Windows.Forms.Label();
            this.dtpVrijemeOd = new System.Windows.Forms.DateTimePicker();
            this.dtpVrijemeDo = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbReg = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblRegIzvještaj
            // 
            this.lblRegIzvještaj.AutoSize = true;
            this.lblRegIzvještaj.Location = new System.Drawing.Point(107, 38);
            this.lblRegIzvještaj.Name = "lblRegIzvještaj";
            this.lblRegIzvještaj.Size = new System.Drawing.Size(79, 16);
            this.lblRegIzvještaj.TabIndex = 1;
            this.lblRegIzvještaj.Text = "Registracija";
            // 
            // lblOdIzvještaj
            // 
            this.lblOdIzvještaj.AutoSize = true;
            this.lblOdIzvještaj.Location = new System.Drawing.Point(112, 81);
            this.lblOdIzvještaj.Name = "lblOdIzvještaj";
            this.lblOdIzvještaj.Size = new System.Drawing.Size(74, 16);
            this.lblOdIzvještaj.TabIndex = 2;
            this.lblOdIzvještaj.Text = "Vrijeme Od";
            // 
            // lblDoIzvještaj
            // 
            this.lblDoIzvještaj.AutoSize = true;
            this.lblDoIzvještaj.Location = new System.Drawing.Point(112, 114);
            this.lblDoIzvještaj.Name = "lblDoIzvještaj";
            this.lblDoIzvještaj.Size = new System.Drawing.Size(74, 16);
            this.lblDoIzvještaj.TabIndex = 3;
            this.lblDoIzvještaj.Text = "Vrijeme Do";
            // 
            // dtpVrijemeOd
            // 
            this.dtpVrijemeOd.Location = new System.Drawing.Point(233, 75);
            this.dtpVrijemeOd.Name = "dtpVrijemeOd";
            this.dtpVrijemeOd.Size = new System.Drawing.Size(257, 22);
            this.dtpVrijemeOd.TabIndex = 5;
            // 
            // dtpVrijemeDo
            // 
            this.dtpVrijemeDo.Location = new System.Drawing.Point(241, 114);
            this.dtpVrijemeDo.Name = "dtpVrijemeDo";
            this.dtpVrijemeDo.Size = new System.Drawing.Size(249, 22);
            this.dtpVrijemeDo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbReg
            // 
            this.cmbReg.FormattingEnabled = true;
            this.cmbReg.Location = new System.Drawing.Point(233, 38);
            this.cmbReg.Name = "cmbReg";
            this.cmbReg.Size = new System.Drawing.Size(208, 24);
            this.cmbReg.TabIndex = 8;
            // 
            // FrmIzvještaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 203);
            this.Controls.Add(this.cmbReg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpVrijemeDo);
            this.Controls.Add(this.dtpVrijemeOd);
            this.Controls.Add(this.lblDoIzvještaj);
            this.Controls.Add(this.lblOdIzvještaj);
            this.Controls.Add(this.lblRegIzvještaj);
            this.Name = "FrmIzvještaj";
            this.Text = "FrmIzvještaj";
            this.Load += new System.EventHandler(this.FrmIzvještaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRegIzvještaj;
        private System.Windows.Forms.Label lblOdIzvještaj;
        private System.Windows.Forms.Label lblDoIzvještaj;
        private System.Windows.Forms.DateTimePicker dtpVrijemeOd;
        private System.Windows.Forms.DateTimePicker dtpVrijemeDo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbReg;
    }
}