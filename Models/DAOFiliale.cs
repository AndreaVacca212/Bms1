using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class DAOFiliale : IDAO
    {
        private Database db;

        private static DAOFiliale instance = null;

        private DAOFiliale()
        {
            db = new Database("Fumetteria");
        }

        public static DAOFiliale GetInstance()
        {
            return instance == null ? new DAOFiliale() : instance;
        }

        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Filiali");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Filiale f = new Filiale();
                f.FromDictionary(riga);

                ris.Add(f);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Filiali WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Filiale f = (Filiale)e;

            string query = $"UPDATE Filiali SET " +
                           $"nome = '{f.Nome}'," +
                           $"citta = '{f.Citta}'," +
                           $"indirizzo = '{f.Indirizzo}'," +
                           $"idBanca = {f.IdBanca.Id} " +
                           $"WHERE id = {f.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Filiale f = (Filiale)e;

            string query = $"INSERT INTO fumetti " +
                           $"(nome, citta,indirizzo, idBanca) " +
                           $"VALUES " +
                           $"('{f.Nome}','{f.Citta}','{f.Indirizzo}',{f.IdBanca.Id})";


            return db.Send(query);
        }

        public Entity Find(int id)
        {
            foreach (Entity e in Read())
                if (e.Id == id)
                    return e;

            return null;

        }
    }
}