using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class Banca : Entity
    {
        public Banca() { }

        public Banca(int id, string nome, string nazione) : base(id)
        {
            Nome = nome;
            Nazione = nazione;
        }

        public string Nome { get; set; }
        public string Nazione { get; set; }
    }
}

