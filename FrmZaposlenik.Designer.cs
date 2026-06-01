namespace CarCar
{
    partial class FrmZaposlenik
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
            this.lblServisi = new System.Windows.Forms.Label();
            this.lblRezervacije = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKorisnikZap = new System.Windows.Forms.Label();
            this.lblImeSustava = new System.Windows.Forms.Label();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.dgvRezervacijeZap = new System.Windows.Forms.DataGridView();
            this.btnDodajZap = new System.Windows.Forms.Button();
            this.btnObrisiZap = new System.Windows.Forms.Button();
            this.btnUrediZap = new System.Windows.Forms.Button();
            this.lblPretragaZap = new System.Windows.Forms.Label();
            this.txtPretragaZap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacijeZap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServisi
            // 
            this.lblServisi.AutoSize = true;
            this.lblServisi.Location = new System.Drawing.Point(378, 32);
            this.lblServisi.Name = "lblServisi";
            this.lblServisi.Size = new System.Drawing.Size(48, 16);
            this.lblServisi.TabIndex = 13;
            this.lblServisi.Text = "Servisi";
            this.lblServisi.Click += new System.EventHandler(this.lblServisi_Click);
            // 
            // lblRezervacije
            // 
            this.lblRezervacije.AutoSize = true;
            this.lblRezervacije.Location = new System.Drawing.Point(233, 32);
            this.lblRezervacije.Name = "lblRezervacije";
            this.lblRezervacije.Size = new System.Drawing.Size(79, 16);
            this.lblRezervacije.TabIndex = 12;
            this.lblRezervacije.Text = "Rezervacije";
            this.lblRezervacije.Click += new System.EventHandler(this.lblRezervacije_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vozila";
            // 
            // lblKorisnikZap
            // 
            this.lblKorisnikZap.AutoSize = true;
            this.lblKorisnikZap.Location = new System.Drawing.Point(794, 13);
            this.lblKorisnikZap.Name = "lblKorisnikZap";
            this.lblKorisnikZap.Size = new System.Drawing.Size(74, 16);
            this.lblKorisnikZap.TabIndex = 10;
            this.lblKorisnikZap.Text = "Zaposlenik";
            // 
            // lblImeSustava
            // 
            this.lblImeSustava.AutoSize = true;
            this.lblImeSustava.Location = new System.Drawing.Point(5, 13);
            this.lblImeSustava.Name = "lblImeSustava";
            this.lblImeSustava.Size = new System.Drawing.Size(49, 16);
            this.lblImeSustava.TabIndex = 9;
            this.lblImeSustava.Text = "CarCar";
            // 
            // btnOdjava
            // 
            this.btnOdjava.Location = new System.Drawing.Point(874, 8);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(89, 26);
            this.btnOdjava.TabIndex = 8;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // dgvRezervacijeZap
            // 
            this.dgvRezervacijeZap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRezervacijeZap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacijeZap.Location = new System.Drawing.Point(13, 100);
            this.dgvRezervacijeZap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRezervacijeZap.Name = "dgvRezervacijeZap";
            this.dgvRezervacijeZap.RowHeadersWidth = 51;
            this.dgvRezervacijeZap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacijeZap.Size = new System.Drawing.Size(953, 291);
            this.dgvRezervacijeZap.TabIndex = 15;
            // 
            // btnDodajZap
            // 
            this.btnDodajZap.Location = new System.Drawing.Point(27, 398);
            this.btnDodajZap.Name = "btnDodajZap";
            this.btnDodajZap.Size = new System.Drawing.Size(75, 23);
            this.btnDodajZap.TabIndex = 16;
            this.btnDodajZap.Text = "Dodaj termin";
            this.btnDodajZap.UseVisualStyleBackColor = true;
            this.btnDodajZap.Click += new System.EventHandler(this.btnDodajZap_Click);
            // 
            // btnObrisiZap
            // 
            this.btnObrisiZap.Location = new System.Drawing.Point(118, 398);
            this.btnObrisiZap.Name = "btnObrisiZap";
            this.btnObrisiZap.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiZap.TabIndex = 17;
            this.btnObrisiZap.Text = "Obriši";
            this.btnObrisiZap.UseVisualStyleBackColor = true;
            this.btnObrisiZap.Click += new System.EventHandler(this.btnObrisiZap_Click);
            // 
            // btnUrediZap
            // 
            this.btnUrediZap.Location = new System.Drawing.Point(221, 397);
            this.btnUrediZap.Name = "btnUrediZap";
            this.btnUrediZap.Size = new System.Drawing.Size(75, 23);
            this.btnUrediZap.TabIndex = 18;
            this.btnUrediZap.Text = "Uredi";
            this.btnUrediZap.UseVisualStyleBackColor = true;
            this.btnUrediZap.Click += new System.EventHandler(this.btnUrediZap_Click);
            // 
            // lblPretragaZap
            // 
            this.lblPretragaZap.AutoSize = true;
            this.lblPretragaZap.Location = new System.Drawing.Point(43, 70);
            this.lblPretragaZap.Name = "lblPretragaZap";
            this.lblPretragaZap.Size = new System.Drawing.Size(59, 16);
            this.lblPretragaZap.TabIndex = 20;
            this.lblPretragaZap.Text = "Pretraga";
            // 
            // txtPretragaZap
            // 
            this.txtPretragaZap.Location = new System.Drawing.Point(113, 70);
            this.txtPretragaZap.Name = "txtPretragaZap";
            this.txtPretragaZap.Size = new System.Drawing.Size(147, 22);
            this.txtPretragaZap.TabIndex = 19;
            this.txtPretragaZap.TextChanged += new System.EventHandler(this.txtPretragaZap_TextChanged);
            // 
            // FrmZaposlenik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.lblPretragaZap);
            this.Controls.Add(this.txtPretragaZap);
            this.Controls.Add(this.btnUrediZap);
            this.Controls.Add(this.btnObrisiZap);
            this.Controls.Add(this.btnDodajZap);
            this.Controls.Add(this.dgvRezervacijeZap);
            this.Controls.Add(this.lblServisi);
            this.Controls.Add(this.lblRezervacije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKorisnikZap);
            this.Controls.Add(this.lblImeSustava);
            this.Controls.Add(this.btnOdjava);
            this.Name = "FrmZaposlenik";
            this.Text = "FrmZaposlenik";
            this.Load += new System.EventHandler(this.FrmZaposlenik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacijeZap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblServisi;
        private System.Windows.Forms.Label lblRezervacije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKorisnikZap;
        private System.Windows.Forms.Label lblImeSustava;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.DataGridView dgvRezervacijeZap;
        private System.Windows.Forms.Button btnDodajZap;
        private System.Windows.Forms.Button btnObrisiZap;
        private System.Windows.Forms.Button btnUrediZap;
        private System.Windows.Forms.Label lblPretragaZap;
        private System.Windows.Forms.TextBox txtPretragaZap;
    }
}