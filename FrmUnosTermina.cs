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
        private Termin odabraniTermin;
        public FrmUnosTermina()
        {
            InitializeComponent();
        }
        public FrmUnosTermina(Termin terminZaUredivanje)
        {
            InitializeComponent();
            odabraniTermin = terminZaUredivanje;
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

            if (odabraniTermin != null)
            {
                dtpOd.Value = odabraniTermin.VrijemeOd;
                dtpDo.Value = odabraniTermin.VrijemeDo;
                cmbTip.SelectedItem = odabraniTermin.Tip;
                cmbStatus.SelectedItem = odabraniTermin.Status;
                cmbVozilo.SelectedItem = odabraniTermin.Vozilo;
                cmbKlijent.SelectedItem = odabraniTermin.Klijent;
                cmbZaposlenik.SelectedItem = odabraniTermin.Zaposlenik;
            }
            else
            {
                cmbTip.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            Termin t = odabraniTermin ?? new Termin();
            t.VrijemeOd = dtpOd.Value;
            t.VrijemeDo = dtpDo.Value;
            t.Status = cmbStatus.SelectedItem.ToString();
            t.Tip = cmbTip.SelectedItem.ToString();
            t.Vozilo = (Vozilo)cmbVozilo.SelectedItem;
            t.Klijent = (Klijent)cmbKlijent.SelectedItem;
            t.Zaposlenik = (Zaposlenik)cmbZaposlenik.SelectedItem;
            if (odabraniTermin != null)
            {
                TerminRepository.Update(t);
            }
            else
            {
                TerminRepository.AddTermin(t);

            }

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
