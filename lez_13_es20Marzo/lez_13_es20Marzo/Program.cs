using lez_13_Esercitazione.DAL;
using lez_13_Esercitazione.Models;

namespace lez_13_es20Marzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro("Moby Sos", Convert.ToDateTime("12/12/2025"), false);
            


            //LibroDAL.getIstanza().Insert(libro);
            //Console.WriteLine(LibroDAL.getIstanza().GetById(1).ToString());
            //LibroDAL.getIstanza().Update(libro, 3);
            //Console.WriteLine(LibroDAL.getIstanza().GetById(1).ToString());

            //List<Libro> elenco = LibroDAL.getIstanza().GetAll();

            //foreach(Libro l in elenco)
            //    Console.WriteLine(l.ToString());

            //Utente utente = new Utente("Mario", "Di Caterino", "lorewjfns@gmail.com");

            //List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

            //foreach(Utente u in elenco)
            //    Console.WriteLine(u.ToString());

            Prestito prestito = new Prestito(Convert.ToDateTime("12/12/2025"), 1,1); //INSERT NON FUNZIONA SENZA DATA DI RESTITUZIONE

            PrestitoDAL.getIstanza().Insert(prestito);
            
            
            
        
        }
    }
}
