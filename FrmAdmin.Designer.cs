namespace CarCar
{
    partial class FrmAdmin
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
            this.btnOdjava = new System.Windows.Forms.Button();
            this.lblImeSustava = new System.Windows.Forms.Label();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRezervacije = new System.Windows.Forms.Label();
            this.lblServisi = new System.Windows.Forms.Label();
            this.lblIzvještaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOdjava
            // 
            this.btnOdjava.Location = new System.Drawing.Point(496, 2);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(89, 26);
            this.btnOdjava.TabIndex = 0;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblImeSustava
            // 
            this.lblImeSustava.AutoSize = true;
            this.lblImeSustava.Location = new System.Drawing.Point(12, 12);
            this.lblImeSustava.Name = "lblImeSustava";
            this.lblImeSustava.Size = new System.Drawing.Size(49, 16);
            this.lblImeSustava.TabIndex = 1;
            this.lblImeSustava.Text = "CarCar";
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Location = new System.Drawing.Point(415, 7);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(45, 16);
            this.lblKorisnik.TabIndex = 2;
            this.lblKorisnik.Text = "Admin\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vozila";
            // 
            // lblRezervacije
            // 
            this.lblRezervacije.AutoSize = true;
            this.lblRezervacije.Location = new System.Drawing.Point(154, 58);
            this.lblRezervacije.Name = "lblRezervacije";
            this.lblRezervacije.Size = new System.Drawing.Size(79, 16);
            this.lblRezervacije.TabIndex = 5;
            this.lblRezervacije.Text = "Rezervacije";
            // 
            // lblServisi
            // 
            this.lblServisi.AutoSize = true;
            this.lblServisi.Location = new System.Drawing.Point(249, 58);
            this.lblServisi.Name = "lblServisi";
            this.lblServisi.Size = new System.Drawing.Size(48, 16);
            this.lblServisi.TabIndex = 6;
            this.lblServisi.Text = "Servisi";
            // 
            // lblIzvještaj
            // 
            this.lblIzvještaj.AutoSize = true;
            this.lblIzvještaj.Location = new System.Drawing.Point(315, 58);
            this.lblIzvještaj.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblIzvještaj.Name = "lblIzvještaj";
            this.lblIzvještaj.Size = new System.Drawing.Size(55, 16);
            this.lblIzvještaj.TabIndex = 7;
            this.lblIzvještaj.Text = "Izvještaj";
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 436);
            this.Controls.Add(this.lblIzvještaj);
            this.Controls.Add(this.lblServisi);
            this.Controls.Add(this.lblRezervacije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.lblImeSustava);
            this.Controls.Add(this.btnOdjava);
            this.MaximumSize = new System.Drawing.Size(819, 492);
            this.Name = "FrmAdmin";
            this.Text = "FrmAdmin";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Label lblImeSustava;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRezervacije;
        private System.Windows.Forms.Label lblServisi;
        private System.Windows.Forms.Label lblIzvještaj;
    }
}