using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCar.Models
{
    public class IzvjestajVozila
    {
        public string Registracija { get; set; }
        public decimal UkupnaZarada { get; set; }
        public decimal UkupniTrosak { get; set; }
        public decimal NetoDobit => UkupnaZarada - UkupniTrosak;
    }
}
