using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCar.Models
{
    public class Klijent
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string OIB { get; set; }

        public List<Termin> Rezervacije { get; set; } = new List<Termin>();
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
