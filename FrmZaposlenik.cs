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
    public partial class FrmZaposlenik : Form
    {
        private string trenutniPrikaz = "Rezervacije";

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
            trenutniPrikaz = "Rezervacije";
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

            dgvRezervacijeZap.DataSource = zaPrikaz;

            if (dgvRezervacijeZap.Columns.Count > 0)
            {
                dgvRezervacijeZap.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacijeZap.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacijeZap.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacijeZap.Columns["TrosakServisa"].HeaderText = "Trošak Servisa";
                dgvRezervacijeZap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnObrisiZap_Click(object sender, EventArgs e)
        {
            if (dgvRezervacijeZap.SelectedRows.Count > 0)
            {
                int idZaBrisanje = Convert.ToInt32(dgvRezervacijeZap.SelectedRows[0].Cells["Id"].Value);
                var rezultat = MessageBox.Show($"Jeste li sigurni da želite obrisati stavku ID: {idZaBrisanje}?",
                                               "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rezultat == DialogResult.Yes)
                {
                    TerminRepository.DeleteTermin(idZaBrisanje);
                    OsvjeziPrikaz();
                    MessageBox.Show("Uspješno obrisano!");
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite cijeli redak za brisanje.");
            }
        }

        private void btnDodajZap_Click(object sender, EventArgs e)
        {
            FrmUnosTermina forma = new FrmUnosTermina();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Termin uspješno spremljen!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OsvjeziPrikaz();
            }
        }

        private void btnUrediZap_Click(object sender, EventArgs e)
        {
            if (dgvRezervacijeZap.SelectedRows.Count > 0)
            {
                int idZaUredivanje = Convert.ToInt32(dgvRezervacijeZap.SelectedRows[0].Cells["Id"].Value);
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

        private void txtPretragaZap_TextChanged(object sender, EventArgs e)
        {
            string tekst = txtPretragaZap.Text;
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
    }
}