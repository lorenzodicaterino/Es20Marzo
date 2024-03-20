using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_Esercitazione.Models
{
    internal class Prestito
    {
        public int Id { get; set; }
        public DateTime DataPrestito { get; set; }
        public DateTime DataRestituzione { get; set; }
        public int LibroRIF { get; set; }
        public int UtenteRIF { get; set; }

        public Prestito(DateTime dataP, DateTime dataR, int libroRIF, int utenteRIF)
        {
            DataPrestito = dataP;
            DataRestituzione = dataR;
            LibroRIF = libroRIF;
            UtenteRIF = utenteRIF;
        }

        public Prestito(int id,DateTime dataP, DateTime dataR, int libroRIF, int utenteRIF)
        {
            Id = id;
            DataPrestito = dataP;
            DataRestituzione = dataR;
            LibroRIF = libroRIF;
            UtenteRIF = utenteRIF;
        }

        public Prestito(DateTime dataP, int libroRIF, int utenteRIF)
        {
            DataPrestito = dataP;
            LibroRIF = libroRIF;
            UtenteRIF = utenteRIF;
        }

        public Prestito(int id, DateTime dataP, int libroRIF, int utenteRIF)
        {
            Id = id;
            DataPrestito = dataP;
            LibroRIF = libroRIF;
            UtenteRIF = utenteRIF;
        }

        public Prestito() { }

        public override string ToString()
        {
            return $"{Id} {DataPrestito.ToString("dd/MM/yyyy")} {DataRestituzione.ToString("dd/MM/yyyy")} {LibroRIF} {UtenteRIF}";
        }
    }
}
