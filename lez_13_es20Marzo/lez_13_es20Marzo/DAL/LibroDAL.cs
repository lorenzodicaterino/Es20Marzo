using lez_13_DB_01_DAL.Utilities;
using lez_13_Esercitazione.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_Esercitazione.DAL
{
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL? istanza;

        public static LibroDAL getIstanza()
        {
            if (istanza == null)
                istanza = new LibroDAL();

            return istanza;
        }

        public bool Delete(int id)
        {
            #region delete
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM libro WHERE libroID = @Id ";
                cmd.Parameters.AddWithValue("Id", id);

                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };

            return risultato;
            #endregion
        }

        public List<Libro> GetAll()
        {
            #region getAll
            List<Libro> elenco = new List<Libro>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo, anno_di_pubblicazione, disponibile FROM libro";

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        Libro libro = new Libro(Convert.ToInt32(r[0]),r[1].ToString(), Convert.ToDateTime(r[2]), Convert.ToBoolean(r[3]));
                        elenco.Add(libro);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };

            return elenco;
            #endregion
        }

        public Libro GetById(int id)
        {
            #region GetByID
            Libro res = new Libro();
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo, anno_di_pubblicazione, disponibile FROM libro WHERE libroID=@id";
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    con.Open();
                    SqlDataReader? r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        res.Id = Convert.ToInt32(r[0]);
                        res.Titolo = r[1].ToString();
                        res.AnnoDiPubblicazione = Convert.ToDateTime(r[2]);
                        res.IsDisponibile = Convert.ToBoolean(r[3]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };

            return res;
            #endregion

        }

        public bool Insert(Libro t)
        {
            #region insert
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO libro (titolo, anno_di_pubblicazione, disponibile) VALUES (@titolo, @annoPub, @dispon)";
                cmd.Parameters.AddWithValue("@titolo", t.Titolo);
                cmd.Parameters.AddWithValue("@annoPub", t.AnnoDiPubblicazione);
                cmd.Parameters.AddWithValue("@dispon", t.IsDisponibile);

                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };

            return risultato;

            #endregion
        }

        public bool Update(Libro t, int id)
        {
            #region update
            bool res = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE libro SET titolo=@titolo, anno_di_pubblicazione = @anno, disponibile=@dispo WHERE libroID=@id";
                cmd.Parameters.AddWithValue("titolo", t.Titolo);
                cmd.Parameters.AddWithValue("anno", t.AnnoDiPubblicazione);
                cmd.Parameters.AddWithValue("dispo", t.IsDisponibile);
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            };
            return res;
            #endregion
        }
    }
}
