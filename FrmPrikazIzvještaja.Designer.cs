namespace CarCar
{
    partial class FrmPrikazIzvještaja
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
            this.lblVozilo = new System.Windows.Forms.Label();
            this.lblZarada = new System.Windows.Forms.Label();
            this.lblTrosak = new System.Windows.Forms.Label();
            this.lblDobit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVozilo
            // 
            this.lblVozilo.AutoSize = true;
            this.lblVozilo.Location = new System.Drawing.Point(35, 24);
            this.lblVozilo.Name = "lblVozilo";
            this.lblVozilo.Size = new System.Drawing.Size(44, 16);
            this.lblVozilo.TabIndex = 0;
            this.lblVozilo.Text = "label1";
            // 
            // lblZarada
            // 
            this.lblZarada.AutoSize = true;
            this.lblZarada.Location = new System.Drawing.Point(35, 59);
            this.lblZarada.Name = "lblZarada";
            this.lblZarada.Size = new System.Drawing.Size(44, 16);
            this.lblZarada.TabIndex = 1;
            this.lblZarada.Text = "label2";
            // 
            // lblTrosak
            // 
            this.lblTrosak.AutoSize = true;
            this.lblTrosak.Location = new System.Drawing.Point(35, 89);
            this.lblTrosak.Name = "lblTrosak";
            this.lblTrosak.Size = new System.Drawing.Size(44, 16);
            this.lblTrosak.TabIndex = 2;
            this.lblTrosak.Text = "label3";
            // 
            // lblDobit
            // 
            this.lblDobit.AutoSize = true;
            this.lblDobit.Location = new System.Drawing.Point(38, 123);
            this.lblDobit.Name = "lblDobit";
            this.lblDobit.Size = new System.Drawing.Size(44, 16);
            this.lblDobit.TabIndex = 3;
            this.lblDobit.Text = "label4";
            // 
            // FrmPrikazIzvještaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 246);
            this.Controls.Add(this.lblDobit);
            this.Controls.Add(this.lblTrosak);
            this.Controls.Add(this.lblZarada);
            this.Controls.Add(this.lblVozilo);
            this.Name = "FrmPrikazIzvještaja";
            this.Text = "PrikazIzvještaja";
            this.Load += new System.EventHandler(this.FrmPrikazIzvještaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVozilo;
        private System.Windows.Forms.Label lblZarada;
        private System.Windows.Forms.Label lblTrosak;
        private System.Windows.Forms.Label lblDobit;
    }
}