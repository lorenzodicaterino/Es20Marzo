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
    internal class PrestitoDAL : IDal<Prestito>
    {
        private static PrestitoDAL istanza;
        public static PrestitoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new PrestitoDAL();

            return istanza;
        }

        public bool Delete(Prestito t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public List<Prestito> GetAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public Prestito GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Insert(Prestito t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Update(Prestito t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }
    }
}
