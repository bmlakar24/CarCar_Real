namespace CarCar
{
    partial class FrmPrikazIzvještaja
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
            this.lblCarCar = new System.Windows.Forms.Label();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.dgvIzvjestaj = new System.Windows.Forms.DataGridView();
            this.btnZatvori = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvjestaj)).BeginInit();
            this.SuspendLayout();
            //
            // lblCarCar
            //
            this.lblCarCar.AutoSize = true;
            this.lblCarCar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCarCar.Location = new System.Drawing.Point(12, 12);
            this.lblCarCar.Name = "lblCarCar";
            this.lblCarCar.Size = new System.Drawing.Size(60, 20);
            this.lblCarCar.TabIndex = 0;
            this.lblCarCar.Text = "CarCar";
            //
            // lblNaslov
            //
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.Location = new System.Drawing.Point(12, 50);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(220, 25);
            this.lblNaslov.TabIndex = 1;
            this.lblNaslov.Text = "Financijski izvještaj";
            //
            // dgvIzvjestaj
            //
            this.dgvIzvjestaj.AllowUserToAddRows = false;
            this.dgvIzvjestaj.AllowUserToDeleteRows = false;
            this.dgvIzvjestaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvjestaj.Location = new System.Drawing.Point(12, 95);
            this.dgvIzvjestaj.Name = "dgvIzvjestaj";
            this.dgvIzvjestaj.ReadOnly = true;
            this.dgvIzvjestaj.RowHeadersVisible = false;
            this.dgvIzvjestaj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIzvjestaj.Size = new System.Drawing.Size(560, 300);
            this.dgvIzvjestaj.TabIndex = 2;
            //
            // btnZatvori
            //
            this.btnZatvori.Location = new System.Drawing.Point(472, 410);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(100, 32);
            this.btnZatvori.TabIndex = 3;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            //
            // FrmPrikazIzvještaja
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.dgvIzvjestaj);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.lblCarCar);
            this.Name = "FrmPrikazIzvještaja";
            this.Text = "CarCar - Financijski izvještaj";
            this.Load += new System.EventHandler(this.FrmPrikazIzvjestaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvjestaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCarCar;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.DataGridView dgvIzvjestaj;
        private System.Windows.Forms.Button btnZatvori;
    }
}