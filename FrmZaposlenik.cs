using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarCar.Repositories;

namespace CarCar
{
    public partial class FrmZaposlenik : Form
    {
        public FrmZaposlenik()
        {
            InitializeComponent();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            Hide();
            frmLogin.ShowDialog();
            Close();
        }

        private void FrmZaposlenik_Load(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }
        private void UcitajRezervacije()
        {
            var rezervacije = RezervacijaRepository.GetRezervacije();

            var zaPrikaz = rezervacije.Select(r => new
            {
                Id = r.Id,
                VrijemeOd = r.VrijemeOd,
                VrijemeDo = r.VrijemeDo,
                Status = r.Status,

                Vozilo = r.Vozilo != null ? r.Vozilo.Registracija : "-",
                Zaposlenik = r.Zaposlenik != null ? r.Zaposlenik.Ime + " " + r.Zaposlenik.Prezime : "-",
                OIBKlijenta = r.OIBKlijenta,
                CijenaNajma = r.CijenaNajma
            }).ToList();

            dgvRezervacijeZap.DataSource = zaPrikaz;

            if (dgvRezervacijeZap.Columns.Count > 0)
            {
                dgvRezervacijeZap.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacijeZap.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacijeZap.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacijeZap.Columns["CijenaNajma"].HeaderText = "Cijena Najma";

                dgvRezervacijeZap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void lblServisi_Click(object sender, EventArgs e)
        {
            UcitajServise();
        }
        private void UcitajServise()
        {
            var servisi = ServisiRepository.GetServisi();
            var zaPrikaz = servisi.Select(r => new
            {
                Id = r.Id,
                VrijemeOd = r.VrijemeOd,
                VrijemeDo = r.VrijemeDo,
                Status = r.Status,
                Vozilo = r.Vozilo != null ? r.Vozilo.Registracija : "-",
                Zaposlenik = r.Zaposlenik != null ? r.Zaposlenik.Ime + " " + r.Zaposlenik.Prezime : "-",
                OIBKlijenta = r.OIBKlijenta,
                TrošakServisa = r.Vozilo.TrošakServisa,
            }).ToList();
            dgvRezervacijeZap.DataSource = zaPrikaz;
            if (dgvRezervacijeZap.Columns.Count > 0)
            {
                dgvRezervacijeZap.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacijeZap.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacijeZap.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacijeZap.Columns["TrošakServisa"].HeaderText = "Trošak Servisa";
                dgvRezervacijeZap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
