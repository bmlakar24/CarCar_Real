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
            trenutniPrikaz= "Servisi";
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

        private void lblRezervacije_Click(object sender, EventArgs e)
        {
            trenutniPrikaz = "Rezervacije";
            UcitajRezervacije();
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


                    if (trenutniPrikaz == "Servisi")
                    {
                        dgvRezervacijeZap.DataSource = ServisiRepository.GetServisi();
                    }
                    else if(trenutniPrikaz == "Rezervacije")
                    {
                        dgvRezervacijeZap.DataSource = RezervacijaRepository.GetRezervacije();
                    }

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

                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacijeZap.DataSource = ServisiRepository.GetServisi();
                }
                else
                {
                    dgvRezervacijeZap.DataSource = RezervacijaRepository.GetRezervacije();
                }
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

                        if (trenutniPrikaz == "Servisi")
                        {
                            dgvRezervacijeZap.DataSource = ServisiRepository.GetServisi();
                        }
                        else
                        {
                            dgvRezervacijeZap.DataSource = RezervacijaRepository.GetRezervacije();
                        }
                    }
                }
            }
        }

        private void txtPretragaZap_TextChanged(object sender, EventArgs e)
        {
            string tekst = txtPretragaZap.Text;
            if (string.IsNullOrWhiteSpace(tekst))
            {
                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacijeZap.DataSource = ServisiRepository.GetServisi();
                }
                else
                {
                    dgvRezervacijeZap.DataSource = RezervacijaRepository.GetRezervacije();
                }
            }
            else
            {
                if (trenutniPrikaz == "Servisi")
                {
                    dgvRezervacijeZap.DataSource = TerminRepository.PretraziServise(tekst);
                }
                else
                {
                    dgvRezervacijeZap.DataSource = TerminRepository.PretraziTermine(tekst);
                }
                FormatirajTablicu();
            }
        }
        private void FormatirajTablicu()
        {


            if (dgvRezervacijeZap.DataSource == null) return;


            if (dgvRezervacijeZap.Columns.Contains("Id")) dgvRezervacijeZap.Columns["Id"].HeaderText = "Id";

            if (dgvRezervacijeZap.Columns.Contains("VrijemeOd")) dgvRezervacijeZap.Columns["VrijemeOd"].HeaderText = "Od";
            if (dgvRezervacijeZap.Columns.Contains("VrijemeDo")) dgvRezervacijeZap.Columns["VrijemeDo"].HeaderText = "Do";
            if (dgvRezervacijeZap.Columns.Contains("Od")) dgvRezervacijeZap.Columns["Od"].HeaderText = "Od";
            if (dgvRezervacijeZap.Columns.Contains("Do")) dgvRezervacijeZap.Columns["Do"].HeaderText = "Do";

            if (dgvRezervacijeZap.Columns.Contains("Status")) dgvRezervacijeZap.Columns["Status"].HeaderText = "Status";
            if (dgvRezervacijeZap.Columns.Contains("Vozilo")) dgvRezervacijeZap.Columns["Vozilo"].HeaderText = "Vozilo";
            if (dgvRezervacijeZap.Columns.Contains("Zaposlenik")) dgvRezervacijeZap.Columns["Zaposlenik"].HeaderText = "Zaposlenik";

            if (dgvRezervacijeZap.Columns.Contains("OIB_Klijenta")) dgvRezervacijeZap.Columns["OIB_Klijenta"].HeaderText = "OIB Klijenta";
            if (dgvRezervacijeZap.Columns.Contains("OIB_Klijenta")) dgvRezervacijeZap.Columns["OIB_Klijenta"].HeaderText = "OIB Klijenta";

            string[] stupciZaSkrivanje = { "ZaposlenikID", "IdZaposlenika", "VoziloId", "IdVozila", "Klijent", "Tip", "OpisKvara" };
            foreach (string stupac in stupciZaSkrivanje)
            {
                if (dgvRezervacijeZap.Columns.Contains(stupac))
                {
                    dgvRezervacijeZap.Columns[stupac].Visible = false;
                }
            }

            if (trenutniPrikaz == "Servisi")
            {
                if (dgvRezervacijeZap.Columns.Contains("CijenaNajma")) dgvRezervacijeZap.Columns["CijenaNajma"].Visible = false;

                if (dgvRezervacijeZap.Columns.Contains("TrosakServisa"))
                {
                    dgvRezervacijeZap.Columns["TrosakServisa"].Visible = true;
                    dgvRezervacijeZap.Columns["TrosakServisa"].HeaderText = "Trošak Servisa";
                }
            }
            else
            {
                if (dgvRezervacijeZap.Columns.Contains("TrosakServisa")) dgvRezervacijeZap.Columns["TrosakServisa"].Visible = false;

                if (dgvRezervacijeZap.Columns.Contains("CijenaNajma"))
                {
                    dgvRezervacijeZap.Columns["CijenaNajma"].Visible = true;
                    dgvRezervacijeZap.Columns["CijenaNajma"].HeaderText = "Cijena Najma";
                }
            }

            dgvRezervacijeZap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
    

