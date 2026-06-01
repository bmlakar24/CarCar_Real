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
    public partial class FrmUnosTermina : Form
    {
        public FrmUnosTermina()
        {
            InitializeComponent();
        }


        private void FrmUnosTermina_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Add("Najam");
            cmbTip.Items.Add("Servis");
            cmbTip.SelectedIndex = 0;

            cmbStatus.Items.Add("Završen");
            cmbStatus.Items.Add("U tijeku");
            cmbStatus.SelectedIndex = 0;
            cmbVozilo.DataSource = VoziloRepository.GetVozila();
            cmbVozilo.DisplayMember = "Registracija";

            cmbKlijent.DataSource = KlijentRepository.GetKlijenti();
            cmbKlijent.DisplayMember = "Ime";

            cmbZaposlenik.DataSource = ZaposlenikRepository.GetZaposlenici();
            cmbZaposlenik.DisplayMember = "Ime";
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (cmbVozilo.SelectedItem == null || cmbKlijent.SelectedItem == null ||
                cmbZaposlenik.SelectedItem == null || cmbTip.SelectedItem == null)
            {
                MessageBox.Show("Sva polja moraju biti odabrana!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Termin noviTermin = new Termin
            {
                VrijemeOd = dtpOd.Value,
                VrijemeDo = dtpDo.Value,

               
                Tip = cmbTip.SelectedItem.ToString(),
                Status = cmbStatus.SelectedItem.ToString(),

                Vozilo = (Vozilo)cmbVozilo.SelectedItem,
                Klijent = (Klijent)cmbKlijent.SelectedItem,
                Zaposlenik = (Zaposlenik)cmbZaposlenik.SelectedItem
            };

            
            TerminRepository.AddTermin(noviTermin);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
