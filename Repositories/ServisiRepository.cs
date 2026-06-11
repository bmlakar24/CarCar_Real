using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar.Models;
using DBLayer;

namespace CarCar.Repositories
{
    internal class ServisiRepository
    {
        public static List<Termin> GetServisi()
        {
            var servisi = new List<Termin>();

            string sql = @"
        SELECT r.*, v.*, 
               k.Ime AS ImeKlijenta, k.Prezime AS PrezimeKlijenta, 
               z.Ime AS ImeZaposlenika, z.Prezime AS PrezimeZaposlenika 
        FROM Rezervacija r 
        JOIN Vozilo v ON r.Vozilo = v.IdVozila 
        JOIN Klijent k ON k.OIB = r.OIB_Klijenta 
        JOIN Zaposlenik z ON r.Zaposlenik = z.IdZaposlenik 
        WHERE r.TipNajma = 'Servis'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Termin termin = CreateObjectSaDetaljima(reader);
                    servisi.Add(termin);
                }
                reader.Close();
            }
            DB.CloseConnection();
            return servisi;
        }

        private static Termin CreateObject(SqlDataReader reader)
        {
            var termin = new Termin
            {

                Id = int.Parse(reader["IdRez"].ToString()),
                Tip = reader["TipNajma"].ToString(),
                Status = reader["Status"].ToString(),
                VrijemeOd = Convert.ToDateTime(reader["VrijemeOd"]),
                VrijemeDo = Convert.ToDateTime(reader["VrijemeDO"])
            };
           
            return termin;
        }

        private static Termin CreateObjectSaDetaljima(SqlDataReader reader)
        {
            var termin = CreateObject(reader);

            termin.Vozilo = new Vozilo
            {
                Id = int.Parse(reader["Vozilo"].ToString()),
                Model = reader["Model"].ToString(),
                Registracija = reader["Registracija"].ToString(),
                CijenaDan = Convert.ToDecimal(reader["CijenaDan"]),
                CijenaSat = Convert.ToDecimal(reader["CijenaSat"]),
                TrošakServisa = Convert.ToDecimal(reader["TrošakServisa"])
            };

            if (reader["OIB_Klijenta"] != DBNull.Value)
            {
                termin.Klijent = new Klijent
                {
                    OIB = reader["OIB_Klijenta"].ToString(),
                    Ime = reader["ImeKlijenta"].ToString(),
                    Prezime = reader["PrezimeKlijenta"].ToString()
                };
            }

            termin.Zaposlenik = new Zaposlenik
            {
                Id = int.Parse(reader["Zaposlenik"].ToString()),
                Ime = reader["ImeZaposlenika"].ToString(),
                Prezime = reader["PrezimeZaposlenika"].ToString()
            };

            return termin;
        }
    }
}
