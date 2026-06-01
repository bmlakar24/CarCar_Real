using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar.Models;
using DBLayer;

namespace CarCar.Repositories
{
    public class TerminRepository
    {
        public static void AddTermin(Termin t)
        {
            string sql = $@"INSERT INTO Rezervacija (VrijemeOd, VrijemeDO, Status, OIB_Klijenta, Zaposlenik, Vozilo, TipNajma) 
                            VALUES ('{t.VrijemeOd:yyyy-MM-dd HH:mm:ss}', 
                                    '{t.VrijemeDo:yyyy-MM-dd HH:mm:ss}', 
                                    '{t.Status}', 
                                    '{t.Klijent.OIB}', 
                                    {t.Zaposlenik.Id}, 
                                    {t.Vozilo.Id}, 
                                    '{t.Tip}')";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        public static void DeleteTermin(int id)
        {
            string sql = $"DELETE FROM Rezervacija WHERE IdRez = {id}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        public static void Update(Termin t)
        {
            string sql = $@"UPDATE Rezervacija 
                    SET VrijemeOd = '{t.VrijemeOd:yyyy-MM-dd HH:mm:ss}', 
                        VrijemeDO = '{t.VrijemeDo:yyyy-MM-dd HH:mm:ss}', 
                        Status = '{t.Status}', 
                        OIB_Klijenta = '{t.Klijent.OIB}', 
                        Zaposlenik = {t.Zaposlenik.Id}, 
                        Vozilo = {t.Vozilo.Id}, 
                        TipNajma = '{t.Tip}' 
                    WHERE IdRez = {t.Id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
