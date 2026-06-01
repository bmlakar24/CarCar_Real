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
    public partial class FrmPrikazIzvještaja : Form
    {
        private string Registracija;
        private DateTime VrijemeOd;
        private DateTime VrijemeDo;
        public FrmPrikazIzvještaja(string Reg, DateTime vrijemeOd, DateTime vrijemeDo)
        {
            InitializeComponent();
            Registracija = Reg;
            VrijemeOd = vrijemeOd;
            VrijemeDo = vrijemeDo;
        }

        private void FrmPrikazIzvještaja_Load(object sender, EventArgs e)
        {
            var podaci = RezervacijaRepository.GetFinancijskiIzvjestaj(Registracija);


        
            lblVozilo.Text = "Izvještaj za vozilo: " + podaci.Registracija;
            lblZarada.Text = "Ukupna Zarada: " + podaci.UkupnaZarada.ToString("C2");
            lblTrosak.Text = "Trošak: " + podaci.UkupniTrosak.ToString("C2");
            lblDobit.Text = "Dobit: " + podaci.NetoDobit.ToString("C2");
        }

        
    }
}
