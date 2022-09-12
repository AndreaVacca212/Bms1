using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class DAOBanca : IDAO
    {
        private Database db;

        private static DAOBanca instance = null;


        private DAOBanca()
        {
            db = new Database("Bms");
        }

        public static DAOBanca GetInstance()
        {
            return instance == null ? new DAOBanca() : instance;
        }

        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Banche");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Banca b = new Banca();
                b.FromDictionary(riga);

                ris.Add(b);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Banche WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Banca b = (Banca)e;

            string query = $"UPDATE Banche SET " +
                           $"nome = '{b.Nome}'," +
                           $"nazione = '{b.Nazione}' " +
                           $"WHERE id = {b.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Banca b = (Banca)e;

            string query = $"INSERT INTO Banche " +
                           $"(nome, nazione) " +
                           $"VALUES " +
                           $"('{b.Nome}','{b.Nazione}')";

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

