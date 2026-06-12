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
    public partial class FrmAdmin : Form
    {
        private string trenutniPrikaz = "Rezervacije";

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
            PrikaziRezervacije(RezervacijaRepository.GetRezervacije());
        }

        private void PrikaziRezervacije(List<Termin> rezervacije)
        {
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

        private void lblServisi_Click(object sender, EventArgs e)
        {
            trenutniPrikaz = "Servisi";
            UcitajServise();
        }

        private void UcitajServise()
        {
            PrikaziServise(ServisiRepository.GetServisi());
        }

        private void PrikaziServise(List<Termin> servisi)
        {
            var zaPrikaz = servisi.Select(r => new
            {
                Id = r.Id,
                VrijemeOd = r.VrijemeOd,
                VrijemeDo = r.VrijemeDo,
                Status = r.Status,
                Vozilo = r.Vozilo != null ? r.Vozilo.Registracija : "-",
                Zaposlenik = r.Zaposlenik != null ? r.Zaposlenik.Ime + " " + r.Zaposlenik.Prezime : "-",
                OIBKlijenta = r.OIBKlijenta,
                TrosakServisa = r.Vozilo != null ? r.Vozilo.TrošakServisa : 0
            }).ToList();

            dgvRezervacije.DataSource = zaPrikaz;

            if (dgvRezervacije.Columns.Count > 0)
            {
                dgvRezervacije.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacije.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacije.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacije.Columns["TrosakServisa"].HeaderText = "Trošak Servisa";
                dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void lblRezervacije_Click(object sender, EventArgs e)
        {
            trenutniPrikaz = "Rezervacije";
            UcitajRezervacije();
        }

        private void OsvjeziPrikaz()
        {
            if (trenutniPrikaz == "Servisi")
            {
                UcitajServise();
            }
            else
            {
                UcitajRezervacije();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmUnosTermina forma = new FrmUnosTermina();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Termin uspješno spremljen!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OsvjeziPrikaz();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvRezervacije.SelectedRows.Count > 0)
            {
                int idZaBrisanje = Convert.ToInt32(dgvRezervacije.SelectedRows[0].Cells["Id"].Value);
                var rezultat = MessageBox.Show($"Jeste li sigurni da želite obrisati stavku ID: {idZaBrisanje}?",
                                               "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rezultat == DialogResult.Yes)
                {
                    TerminRepository.ObrisiTermin(idZaBrisanje);
                    OsvjeziPrikaz();
                    MessageBox.Show("Uspješno obrisano!");
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite cijeli redak za brisanje.");
            }
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvRezervacije.SelectedRows.Count > 0)
            {
                int idZaUredivanje = Convert.ToInt32(dgvRezervacije.SelectedRows[0].Cells["Id"].Value);
                Termin odabrani = RezervacijaRepository.GetTermin(idZaUredivanje);
                if (odabrani != null)
                {
                    FrmUnosTermina forma = new FrmUnosTermina(odabrani);
                    if (forma.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Termin uspješno spremljen!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OsvjeziPrikaz();
                    }
                }
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            string tekst = txtPretraga.Text;
            if (string.IsNullOrWhiteSpace(tekst))
            {
                OsvjeziPrikaz();
                return;
            }

            if (trenutniPrikaz == "Servisi")
            {
                List<Termin> filtrirano = ServisiRepository.GetServisi().Where(r => Odgovara(r, tekst)).ToList();
                PrikaziServise(filtrirano);
            }
            else
            {
                List<Termin> filtrirano = RezervacijaRepository.GetRezervacije().Where(r => Odgovara(r, tekst)).ToList();
                PrikaziRezervacije(filtrirano);
            }
        }

        private bool Odgovara(Termin r, string tekst)
        {
            tekst = tekst.ToLower();
            string vozilo = r.Vozilo != null ? r.Vozilo.Registracija : "";
            string zaposlenik = r.Zaposlenik != null ? r.Zaposlenik.Ime + " " + r.Zaposlenik.Prezime : "";
            string oib = r.OIBKlijenta != null ? r.OIBKlijenta : "";
            string status = r.Status != null ? r.Status : "";
            return vozilo.ToLower().Contains(tekst)
                || zaposlenik.ToLower().Contains(tekst)
                || oib.ToLower().Contains(tekst)
                || status.ToLower().Contains(tekst);
        }

        private void lblIzvještaj_Click(object sender, EventArgs e)
        {
            FrmIzvještaj frmIzvjestaj = new FrmIzvještaj();
            frmIzvjestaj.ShowDialog();
            trenutniPrikaz = "Rezervacije";
            UcitajRezervacije();
        }
    }
}