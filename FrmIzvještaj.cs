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
    public partial class FrmIzvještaj : Form
    {
        public FrmIzvještaj()
        {
            InitializeComponent();
        }

        private void FrmIzvjestaj_Load(object sender, EventArgs e)
        {
            nudGodina.Value = DateTime.Now.Year;

            cmbVozilo.Items.Add("Sva vozila");
            foreach (Vozilo v in VoziloRepository.GetVozila())
            {
                cmbVozilo.Items.Add(v.Registracija);
            }
            cmbVozilo.SelectedIndex = 0;
        }

        private void btnGeneriraj_Click(object sender, EventArgs e)
        {
            int godina = (int)nudGodina.Value;

            string registracija = null;
            if (cmbVozilo.SelectedIndex > 0)
            {
                registracija = cmbVozilo.SelectedItem.ToString();
            }

            FrmPrikazIzvještaja forma = new FrmPrikazIzvještaja(godina, registracija);
            forma.ShowDialog();
            Close();
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}