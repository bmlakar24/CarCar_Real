using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar.Models;
using DBLayer;

namespace CarCar.Repositories
{
    public class VoziloRepository
    {
        public static List<Vozilo> GetVozila()
        {
            var lista = new List<Vozilo>();
            string sql = "SELECT * FROM Vozilo";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                lista.Add(new Vozilo
                {
                    Id = int.Parse(reader["IdVozila"].ToString()),
                    Model = reader["Model"].ToString(),
                    Registracija = reader["Registracija"].ToString(),
                    CijenaDan = Convert.ToDecimal(reader["CijenaDan"]),
                    CijenaSat = Convert.ToDecimal(reader["CijenaSat"]),
                    TrošakServisa = Convert.ToDecimal(reader["TrošakServisa"])
                });
            }
            reader.Close();
            DB.CloseConnection();
            return lista;
        }
    }
}
