using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar.Models;
using DBLayer;

namespace CarCar.Repositories
{
    public class ZaposlenikRepository
    {
        public static List<Zaposlenik> GetZaposlenici()
        {
            var lista = new List<Zaposlenik>();
            string sql = "SELECT * FROM Zaposlenik";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                lista.Add(new Zaposlenik
                {
                    Id = int.Parse(reader["IdZaposlenik"].ToString()),
                    Ime = reader["Ime"].ToString(),
                    Prezime = reader["Prezime"].ToString()
                });
            }
            reader.Close();
            DB.CloseConnection();
            return lista;
        }
    }
}
