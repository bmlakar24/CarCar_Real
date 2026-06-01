using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCar.Models
{
    public class Vozilo
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Registracija { get; set; }

        public decimal CijenaDan { get; set; }

        public decimal CijenaSat { get; set; }

        public decimal TrošakServisa { get; set; }

        public int BrojNajmova { get; set; }

        public List<Termin> Termini { get; set; } = new List<Termin>();
        public override string ToString()
        {
            return Registracija;
        }
    }
}
