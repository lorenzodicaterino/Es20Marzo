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
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL istanza;

        public static LibroDAL getIstanza()
        {
            if(istanza == null)
                istanza= new LibroDAL();

            return istanza;
        }
        
        public bool Delete(Libro t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM libro WHERE @Id";
                cmd.Parameters.AddWithValue("@Id",t.Id);

                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        Console.WriteLine("Record eliminato");
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };

            return false;
        }

        public List<Libro> GetAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };

            throw new NotImplementedException();
        }

        public Libro GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Insert(Libro t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }

        public bool Update(Libro t)
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

            };
            throw new NotImplementedException();
        }
    }
}
