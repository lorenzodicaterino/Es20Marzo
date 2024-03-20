using lez_13_DB_01_DAL.Utilities;
using lez_13_Esercitazione.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_Esercitazione.DAL
{
    internal class UtenteDAL : IDal<Utente>
    {
        private static UtenteDAL istanza;
        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();

            return istanza;
        }

        public bool Delete(Utente t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public Utente GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Update(Utente t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }
    }
}
