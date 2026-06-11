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
    public class RezervacijaRepository
    {
        public static Termin GetTermin(int id)
        {
            Termin termin = null;
            string sql = $@"
        SELECT r.*, v.*,
               k.Ime AS ImeKlijenta, k.Prezime AS PrezimeKlijenta,
               z.Ime AS ImeZaposlenika, z.Prezime AS PrezimeZaposlenika
        FROM Rezervacija r
        JOIN Vozilo v ON r.Vozilo = v.IdVozila
        JOIN Klijent k ON k.OIB = r.OIB_Klijenta
        JOIN Zaposlenik z ON r.Zaposlenik = z.IdZaposlenik
        WHERE r.IdRez = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            if (reader.HasRows)
            {
                reader.Read();
                termin = CreateObjectSaDetaljima(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return termin;
        }

        public static List<Termin> GetRezervacije()
        {
            var rezervacije = new List<Termin>();

            string sql = @"
                SELECT r.*, v.*, 
                       k.Ime AS ImeKlijenta, k.Prezime AS PrezimeKlijenta, 
                       z.Ime AS ImeZaposlenika, z.Prezime AS PrezimeZaposlenika 
                FROM Rezervacija r 
                JOIN Vozilo v ON r.Vozilo = v.IdVozila 
                JOIN Klijent k ON k.OIB = r.OIB_Klijenta 
                JOIN Zaposlenik z ON r.Zaposlenik = z.IdZaposlenik 
                WHERE r.TipNajma = 'Najam'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Termin termin = CreateObjectSaDetaljima(reader);
                    rezervacije.Add(termin);
                }
                reader.Close();
            }
            DB.CloseConnection();
            return rezervacije;
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
                CijenaSat = Convert.ToDecimal(reader["CijenaSat"])
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

        public static List<IzvjestajVozila> GetGodisnjiIzvjestaj(int godina, string registracija = null)
        {
            string filterVozila = string.IsNullOrEmpty(registracija)
                ? ""
                : $" AND v.Registracija = '{registracija}'";

            string sql = $@"
        SELECT v.Registracija, v.CijenaDan, v.CijenaSat, v.TrošakServisa,
               r.TipNajma, r.VrijemeOd, r.VrijemeDO
        FROM Vozilo v
        LEFT JOIN Rezervacija r
            ON r.Vozilo = v.IdVozila AND YEAR(r.VrijemeOd) = {godina}
        WHERE 1 = 1{filterVozila}
        ORDER BY v.Registracija";

            var mapa = new Dictionary<string, IzvjestajVozila>();

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                string reg = reader["Registracija"].ToString();
                if (!mapa.TryGetValue(reg, out IzvjestajVozila iz))
                {
                    iz = new IzvjestajVozila { Registracija = reg };
                    mapa[reg] = iz;
                }

                if (reader["TipNajma"] == DBNull.Value)
                {
                    continue;
                }

                string tip = reader["TipNajma"].ToString();
                if (tip == "Servis")
                {
                    iz.UkupniTrosak += Convert.ToDecimal(reader["TrošakServisa"]);
                }
                else
                {
                    Termin stavka = new Termin
                    {
                        Tip = "Najam",
                        VrijemeOd = Convert.ToDateTime(reader["VrijemeOd"]),
                        VrijemeDo = Convert.ToDateTime(reader["VrijemeDO"]),
                        Vozilo = new Vozilo
                        {
                            CijenaDan = Convert.ToDecimal(reader["CijenaDan"]),
                            CijenaSat = Convert.ToDecimal(reader["CijenaSat"])
                        }
                    };
                    iz.UkupnaZarada += stavka.CijenaNajma ?? 0;
                }
            }

            reader.Close();
            DB.CloseConnection();

            return mapa.Values.ToList();
        }
    }
}