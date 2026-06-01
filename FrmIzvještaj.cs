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
    public partial class FrmIzvještaj : Form
    {

        public FrmIzvještaj()
        {
            InitializeComponent();
            
        }
        public void FrmIzvještaj_Load(object sender, EventArgs e)
        {
            cmbReg.Items.Add("ZG-12345-AA");
            cmbReg.Items.Add("ZG-54321-BB");

            DateTime VrijemeOd = dtpVrijemeOd.Value;
            DateTime VrijemeDo = dtpVrijemeDo.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbReg.Text))
            {
                MessageBox.Show("Molim odaberi vozilo!");
                return;
            }
                string Reg = cmbReg.Text;

                DateTime VrijemeOd = dtpVrijemeOd.Value;
                DateTime VrijemeDo  = dtpVrijemeDo.Value;

                FrmPrikazIzvještaja forma = new FrmPrikazIzvještaja(Reg, VrijemeOd, VrijemeDo);
                Hide();
                forma.ShowDialog();
                Close();
        }
    }
}
