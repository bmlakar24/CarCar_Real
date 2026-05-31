using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar.Models;
using DBLayer;

namespace CarCar.Repositories
{
    public class KlijentRepository
        {
            public static List<Klijent> GetKlijenti()
            {
                var lista = new List<Klijent>();
                string sql = "SELECT * FROM Klijent";

                DB.OpenConnection();
                var reader = DB.GetDataReader(sql);
                while (reader.Read())
                {
                    lista.Add(new Klijent
                    {
                        OIB = reader["OIB"].ToString(),
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
