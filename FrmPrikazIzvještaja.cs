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
using System.Linq;

namespace CarCar
{
    public partial class FrmPrikazIzvještaja : Form
    {
        private string Regi;
        private DateTime Od;
        private DateTime Do;
        public FrmPrikazIzvještaja(string Reg, DateTime vrijemeOd, DateTime vrijemeDo)
        {
            InitializeComponent();
            Regi = Reg;
            Od = vrijemeOd;
            Do = vrijemeDo;
        }

        private void FrmPrikazIzvještaja_Load(object sender, EventArgs e)
        {
            var ter = RezervacijaRepository.GetRezervacije(); 
            var ser = ServisiRepository.GetServisi();

            decimal ukupnaZarada = ter
          .Where(t => t.Registracija == Regi && t.VrijemeOd >= Od && t.VrijemeDo <= Do)
         .Where(t => t.CijenaNajma.HasValue) 
            .Sum(t => t.CijenaNajma.Value);

            decimal ukupniTrosak = ter
        .Where(t=> t.Registracija == Regi && t.VrijemeOd >= Od && t.VrijemeDo <= Do)
        .Sum(t => t.Vozilo.TrošakServisa);
            decimal netoDobit = ukupnaZarada - ukupniTrosak;


            lblZarada.Text = "Ukupna Zarada: " + ukupnaZarada.ToString("C2");
            lblTrosak.Text = "Trošak: " + ukupniTrosak.ToString("C2");
            lblDobit.Text = "Dobit: " + netoDobit.ToString("C2");
        }

        
    }
}
