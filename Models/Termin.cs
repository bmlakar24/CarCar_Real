using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCar.Models
{
    public class Termin
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public string Tip { get; set; }

        public DateTime VrijemeOd { get; set; }

        public DateTime VrijemeDo { get; set; }

        public int IdVozila { get; set; }

        public Vozilo Vozilo { get; set; }

        public string OIBKlijenta => Klijent?.OIB;

        public Klijent Klijent { get; set; }

        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        public decimal? CijenaNajma
        {
            get
            {
                if (Tip != "Najam" || Vozilo == null)
                {
                    return null;
                }
                if (VrijemeOd >= VrijemeDo)
                {
                    return null;

                }
                TimeSpan trajanje = VrijemeDo - VrijemeOd;
                int dani = trajanje.Days;
                int sati = trajanje.Hours;
                int minute = trajanje.Minutes;
                if (minute > 0)
                {
                    sati++;
                }

                if (sati >= 24)
                {
                    dani++;
                    sati = 0;
                }
                return (dani * Vozilo.CijenaDan) + (sati * Vozilo.CijenaSat);
            }
        }
    }
}
