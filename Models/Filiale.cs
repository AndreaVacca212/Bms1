using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class Filiale : Entity
    {
        public Filiale() { }

        public Filiale(int id, string nome, string citta, string indirizzo, Banca idBanca): base(id)
        {
            Nome = nome;
            Citta = citta;
            Indirizzo = indirizzo;
            IdBanca = idBanca;
        }

        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public Banca IdBanca { get; set; }
    }
}

