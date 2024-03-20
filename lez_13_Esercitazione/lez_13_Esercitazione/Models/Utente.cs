using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_Esercitazione.Models
{
    internal class Utente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }

        public Utente(string? nome, string? cognome, string? email)
        {
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }

        public Utente(int id, string? nome, string? cognome, string? email)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id} {Nome} {Cognome} {Email}";
        }
    }
}
