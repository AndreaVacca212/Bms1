using System;
using Utility;

namespace BankManagementSystem.Models
{
    public class Prestito : Entity
    {
        public Prestito() { }

        public Prestito(int id, string tipoPrestito) : base (id)
        {
            TipoPrestito = tipoPrestito;
        }

        public string TipoPrestito { get; set; }
    }
}

