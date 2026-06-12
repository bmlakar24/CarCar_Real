using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarCar.Models;
using CarCar.Repositories;

namespace CarCar
{
    public partial class FrmPrikazIzvještaja : Form
    {
        private int godina;
        private string registracija;

        public FrmPrikazIzvještaja()
        {
            InitializeComponent();
        }

        public FrmPrikazIzvještaja(int godina, string registracija)
        {
            InitializeComponent();
            this.godina = godina;
            this.registracija = registracija;
        }

        private void FrmPrikazIzvjestaja_Load(object sender, EventArgs e)
        {
            lblNaslov.Text = "Financijski izvještaj za " + godina;
            if (!string.IsNullOrEmpty(registracija))
            {
                lblNaslov.Text = lblNaslov.Text + " - " + registracija;
            }

            List<IzvjestajVozila> podaci = RezervacijaRepository.GetGodisnjiIzvjestaj(godina, registracija);

            var zaPrikaz = podaci.Select(p => new
            {
                Vozilo = p.Registracija,
                UkupanNajam = p.UkupnaZarada,
                UkupniTroskovi = p.UkupniTrosak,
                Dobit = p.NetoDobit
            }).ToList();

            dgvIzvjestaj.DataSource = zaPrikaz;

            if (dgvIzvjestaj.Columns.Count > 0)
            {
                dgvIzvjestaj.Columns["Vozilo"].HeaderText = "Vozilo (reg)";
                dgvIzvjestaj.Columns["UkupanNajam"].HeaderText = "Ukupan najam";
                dgvIzvjestaj.Columns["UkupniTroskovi"].HeaderText = "Ukupni troškovi";
                dgvIzvjestaj.Columns["Dobit"].HeaderText = "Dobit";

                dgvIzvjestaj.Columns["UkupanNajam"].DefaultCellStyle.Format = "C2";
                dgvIzvjestaj.Columns["UkupniTroskovi"].DefaultCellStyle.Format = "C2";
                dgvIzvjestaj.Columns["Dobit"].DefaultCellStyle.Format = "";

                dgvIzvjestaj.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}