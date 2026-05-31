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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            Hide();
            frmLogin.ShowDialog();
            Close();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
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

            dgvRezervacije.DataSource = zaPrikaz;

            if (dgvRezervacije.Columns.Count > 0)
            {
                dgvRezervacije.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacije.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacije.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacije.Columns["CijenaNajma"].HeaderText = "Cijena Najma";

                dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
