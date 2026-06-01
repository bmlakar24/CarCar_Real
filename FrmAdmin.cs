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
        private List<Termin> SviTermini = new List<Termin>();
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

        private void lblServisi_Click(object sender, EventArgs e)
        {
            trenutniPrikaz = "Servisi";
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
            dgvRezervacije.DataSource = zaPrikaz;
            if (dgvRezervacije.Columns.Count > 0)
            {
                dgvRezervacije.Columns["VrijemeOd"].HeaderText = "Od";
                dgvRezervacije.Columns["VrijemeDo"].HeaderText = "Do";
                dgvRezervacije.Columns["OIBKlijenta"].HeaderText = "OIB Klijenta";
                dgvRezervacije.Columns["TrošakServisa"].HeaderText = "Trošak Servisa";
                dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void lblRezervacije_Click(object sender, EventArgs e)
        {
            trenutniPrikaz = "Rezervacije";
            UcitajRezervacije();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmUnosTermina forma = new FrmUnosTermina();

            if (forma.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Termin uspješno spremljen!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacije.DataSource = ServisiRepository.GetServisi();
                }
                else
                {
                    dgvRezervacije.DataSource = RezervacijaRepository.GetRezervacije();
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvRezervacije.SelectedRows.Count > 0)
            {

                int idZaBrisanje = Convert.ToInt32(dgvRezervacije.SelectedRows[0].Cells["Id"].Value);
                int idVozila = Convert.ToInt32(dgvRezervacije.SelectedRows[0].Cells["IdVozila"].Value);
                var rezultat = MessageBox.Show($"Jeste li sigurni da želite obrisati stavku ID: {idZaBrisanje}?",
                                               "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {

                    TerminRepository.DeleteTermin(idZaBrisanje);

                    if (trenutniPrikaz == "Servisi")
                    {
                        dgvRezervacije.DataSource = ServisiRepository.GetServisi();
                    }
                    else
                    {
                        dgvRezervacije.DataSource = RezervacijaRepository.GetRezervacije();
                    }

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

                        if (trenutniPrikaz == "Servisi")
                        {
                            dgvRezervacije.DataSource = ServisiRepository.GetServisi();
                        }
                        else
                        {
                            dgvRezervacije.DataSource = RezervacijaRepository.GetRezervacije();
                        }
                    }
                }
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            string tekst = txtPretraga.Text;
            if (string.IsNullOrWhiteSpace(tekst))
            {
                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacije.DataSource = ServisiRepository.GetServisi();
                }
                else
                {
                    dgvRezervacije.DataSource = RezervacijaRepository.GetRezervacije();
                }
            }
            else
            {
                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacije.DataSource = TerminRepository.PretraziServise(tekst);
                }
                else
                { 
                    dgvRezervacije.DataSource = TerminRepository.PretraziTermine(tekst);
                }
                FormatirajTablicu();
            }
        }
        private void FormatirajTablicu()
        {


            if (dgvRezervacije.DataSource == null) return;


            if (dgvRezervacije.Columns.Contains("Id")) dgvRezervacije.Columns["Id"].HeaderText = "Id";

            if (dgvRezervacije.Columns.Contains("VrijemeOd")) dgvRezervacije.Columns["VrijemeOd"].HeaderText = "Od";
            if (dgvRezervacije.Columns.Contains("VrijemeDo")) dgvRezervacije.Columns["VrijemeDo"].HeaderText = "Do";
            if (dgvRezervacije.Columns.Contains("Od")) dgvRezervacije.Columns["Od"].HeaderText = "Od";
            if (dgvRezervacije.Columns.Contains("Do")) dgvRezervacije.Columns["Do"].HeaderText = "Do";

            if (dgvRezervacije.Columns.Contains("Status")) dgvRezervacije.Columns["Status"].HeaderText = "Status";
            if (dgvRezervacije.Columns.Contains("Vozilo")) dgvRezervacije.Columns["Vozilo"].HeaderText = "Vozilo";
            if (dgvRezervacije.Columns.Contains("Zaposlenik")) dgvRezervacije.Columns["Zaposlenik"].HeaderText = "Zaposlenik";

            if (dgvRezervacije.Columns.Contains("OIB_Klijenta")) dgvRezervacije.Columns["OIB_Klijenta"].HeaderText = "OIB Klijenta";
            if (dgvRezervacije.Columns.Contains("OIB_Klijenta")) dgvRezervacije.Columns["OIB_Klijenta"].HeaderText = "OIB Klijenta";

            string[] stupciZaSkrivanje = { "ZaposlenikID", "IdZaposlenika", "VoziloId", "IdVozila", "Klijent", "Tip" };
            foreach (string stupac in stupciZaSkrivanje)
            {
                if (dgvRezervacije.Columns.Contains(stupac))
                {
                    dgvRezervacije.Columns[stupac].Visible = false;
                }
            }

            if (trenutniPrikaz == "Servisi")
            {
                if (dgvRezervacije.Columns.Contains("CijenaNajma")) dgvRezervacije.Columns["CijenaNajma"].Visible = false;

                if (dgvRezervacije.Columns.Contains("TrošakServisa"))
                {
                    dgvRezervacije.Columns["TrošakServisa"].Visible = true;
                    dgvRezervacije.Columns["TrošakServisa"].HeaderText = "Trošak Servisa";
                }

            }
            else if(trenutniPrikaz=="Rezervacije")
            {
                if (dgvRezervacije.Columns.Contains("TrošakServisa")) dgvRezervacije.Columns["TrošakServisa"].Visible = false;

                if (dgvRezervacije.Columns.Contains("CijenaNajma"))
                {
                    dgvRezervacije.Columns["CijenaNajma"].Visible = true;
                    dgvRezervacije.Columns["CijenaNajma"].HeaderText = "Cijena Najma";
                }
            }

            dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void lblIzvještaj_Click(object sender, EventArgs e)
        {
            FrmIzvještaj frmIzvještaj = new FrmIzvještaj();
            Hide();
            frmIzvještaj.ShowDialog();
            Close();
        }
    }
}
