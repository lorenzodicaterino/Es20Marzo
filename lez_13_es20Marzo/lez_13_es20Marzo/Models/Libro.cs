using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_Esercitazione.Models
{
    internal class Libro
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public DateTime AnnoDiPubblicazione { get; set; }
        public bool IsDisponibile { get; set; }

        public Libro(string? titolo, DateTime annoDiPubblicazione, bool isDIsponibile)
        {
            Titolo = titolo;
            AnnoDiPubblicazione= annoDiPubblicazione;
            IsDisponibile= isDIsponibile;
        }

        public Libro(int id, string? titolo, DateTime annoDiPubblicazione, bool isDIsponibile)
        {
            Id = id;
            Titolo = titolo;
            AnnoDiPubblicazione = annoDiPubblicazione;
            IsDisponibile = isDIsponibile;
        }

        public Libro()
        {

        }

        public override string ToString()
        {
            return $"{Id} {Titolo} {AnnoDiPubblicazione.ToString("dd/MM/yyyy")} {IsDisponibile}";
        }
    }
}
