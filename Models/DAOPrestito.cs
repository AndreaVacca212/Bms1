using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class DAOPrestito : IDAO
    {
        private Database db;

        private static DAOPrestito instance = null;

        private DAOPrestito()
        {
            db = new Database("Bms");
        }

        public static DAOPrestito GetInstance()
        {
            return instance == null ? new DAOPrestito() : instance;
        }

        public List<Entity> Read()
        {
            List<Entity> ris = new List<Entity>();
            List<Dictionary<string, string>> tabella = db.Read("SELECT * FROM Prestiti");

            foreach (Dictionary<string, string> riga in tabella)
            {
                Prestito p = new Prestito();
                p.FromDictionary(riga);

                ris.Add(p);
            }

            return ris;
        }

        public bool Delete(int id)
        {
            return db.Send($"DELETE FROM Prestiti WHERE id = {id}");
        }

        public bool Update(Entity e)
        {
            Prestito p = (Prestito)e;

            string query = $"UPDATE Prestiti SET " +
                           $"tipoPrestito = '{p.TipoPrestito}' " +
                           $"WHERE id = {p.Id}";

            return db.Send(query);
        }

        public bool Insert(Entity e)
        {
            Prestito p = (Prestito)e;

            string query = $"INSERT INTO Prestiti " +
                           $"(tipoPrestito) " +
                           $"VALUES " +
                           $"('{p.TipoPrestito}')";

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

