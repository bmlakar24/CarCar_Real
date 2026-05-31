using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;

namespace CarCar.Repositories
{
    public class TerminRepository
    {
        public static void DeleteTermin(int id)
        {
            string sql = $"DELETE FROM Rezervacija WHERE IdRez = {id}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
