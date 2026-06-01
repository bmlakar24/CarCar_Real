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
        public static List<Termin> PretraziTermine(string tekst)
        {
            List<Termin> lista = new List<Termin>();
            string sql = $@"SELECT
                           r.IdRez,
                           r.VrijemeOd,
                           r.VrijemeDO,
                           r.Status,
                           r.TipNajma,
                           v.Registracija,
                           z.Ime AS ImeZaposlenika, 
                           z.Prezime AS PrezimeZaposlenika 
                    FROM Rezervacija r
                    LEFT JOIN Vozilo v ON r.Vozilo = v.IdVozila
                    LEFT JOIN Zaposlenik z ON r.Zaposlenik = z.IdZaposlenik
                    WHERE r.TipNajma = 'Najam' 
                    AND (r.Status LIKE '%{tekst}%' 
                         OR v.Registracija LIKE '%{tekst}%' 
                         OR z.Ime LIKE '%{tekst}%' 
                         OR z.Prezime LIKE '%{tekst}%' 
                         OR r.OIB_Klijenta LIKE '%{tekst}%')";


            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Termin t = RezervacijaRepository.CreateObject(reader);
                if (reader["Registracija"] != DBNull.Value)
                {
                    t.Vozilo = new Vozilo();
                    t.Vozilo.Registracija = reader["Registracija"].ToString();
                }
                if (reader["ImeZaposlenika"] != DBNull.Value && reader["PrezimeZaposlenika"] != DBNull.Value)
                {
                    t.Zaposlenik = new Zaposlenik();
                    t.Zaposlenik.Ime = reader["ImeZaposlenika"].ToString();
                    t.Zaposlenik.Prezime = reader["PrezimeZaposlenika"].ToString();
                }
                    lista.Add(t);
            }
            reader.Close();
            DB.CloseConnection();
            return lista;
        }
        public static List<Termin> PretraziServise(string tekst)
        {
            List<Termin> lista = new List<Termin>();
            string sql = $@"SELECT * from Rezervacija Where TipNajma='Servis' AND (Status LIKE '%{tekst}%'
            OR Vozilo LIKE '%{tekst}%' OR Zaposlenik LIKE '%{tekst}%' OR OIB_Klijenta LIKE '%{tekst}%')";


            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Termin t = RezervacijaRepository.CreateObject(reader);
                lista.Add(t);
            }
            reader.Close();
            DB.CloseConnection();
            return lista;
        }


        }
}
