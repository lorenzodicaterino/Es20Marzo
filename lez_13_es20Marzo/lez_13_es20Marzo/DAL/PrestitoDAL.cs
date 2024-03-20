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

        public bool Delete(int id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM prestito WHERE prestitoID = @id";
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
        }

        public List<Prestito> GetAll()
        {
            List<Prestito> elenco = new List<Prestito>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_restituzione, libroRIF, utenteRIF FROM prestito";
                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        Prestito prestito = new Prestito(Convert.ToInt32(r[0]), Convert.ToDateTime(r[1]), Convert.ToDateTime(r[2]), Convert.ToInt32(r[3]), Convert.ToInt32(r[4]));
                        elenco.Add(prestito);
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
        }

        public Prestito GetById(int id)
        {
            Prestito prestito = new Prestito();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_restituzione, libroRIF, utenteRIF FROM prestito WHERE prestitoID = @id";
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        prestito.Id = Convert.ToInt32(r[0]);
                        prestito.DataPrestito = Convert.ToDateTime(r[1]);
                        prestito.DataRestituzione = Convert.ToDateTime(r[2]);
                        prestito.LibroRIF = Convert.ToInt32(r[3]);
                        prestito.UtenteRIF = Convert.ToInt32(r[4]);
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

            return prestito;
        }

        public bool Insert(Prestito t)
        {
            bool res = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO prestito (data_prestito, data_restituzione, libroRIF,utenteRIF) VALUES (@datap, @datar, @libro, @utente)";
                cmd.Parameters.AddWithValue("datap", t.DataPrestito);
                cmd.Parameters.AddWithValue("datar", t.DataRestituzione);
                cmd.Parameters.AddWithValue("libro", t.LibroRIF);
                cmd.Parameters.AddWithValue("utente", t.UtenteRIF);


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
        }

        public bool Update(Prestito t, int id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE prestito SET data_prestito=@datap, data_restituzione=@datar, libroRIF = @libroRIF, utenteRIF=@utenteRIF  WHERE prestitoID=@id";
                cmd.Parameters.AddWithValue("datap", t.DataPrestito);
                cmd.Parameters.AddWithValue("datar", t.DataRestituzione);
                cmd.Parameters.AddWithValue("libroRIF", t.LibroRIF);
                cmd.Parameters.AddWithValue("utenteRIF", t.UtenteRIF);
                cmd.Parameters.AddWithValue("id", id);

                //try
                //{
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        res = true;
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                    con.Close();
                //}
            };
            return res;
        }

        public List<Prestito> GetByUtente(int utenteRIF)
        {
            List<Prestito> elenco = new List<Prestito>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_restituzione, libroRIF, utenteRIF FROM prestito WHERE utenteRIF = @utenteRIF";
                cmd.Parameters.AddWithValue("utenteRIF", utenteRIF);

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        Prestito prestito = new Prestito(Convert.ToInt32(r[0]), Convert.ToDateTime(r[1]), Convert.ToDateTime(r[2]), Convert.ToInt32(r[3]), Convert.ToInt32(r[4]));
                        elenco.Add(prestito);
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
        }

        public List<Prestito> GetByLibro(int libroRIF)
        {
            List<Prestito> elenco = new List<Prestito>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_restituzione, libroRIF, utenteRIF FROM prestito WHERE libroRIF = @libroRIF";
                cmd.Parameters.AddWithValue("libroRIF", libroRIF);

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        Prestito prestito = new Prestito(Convert.ToInt32(r[0]), Convert.ToDateTime(r[1]), Convert.ToDateTime(r[2]), Convert.ToInt32(r[3]), Convert.ToInt32(r[4]));
                        elenco.Add(prestito);
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
        }

        public List<Prestito> GetByLibroUtente(int libroRIF, int utenteRIF)
        {
            List<Prestito> elenco = new List<Prestito>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_restituzione, libroRIF, utenteRIF FROM prestito WHERE libroRIF = @libroRIF AND utenteRIF = @utenteRIF";
                cmd.Parameters.AddWithValue("libroRIF", libroRIF);
                cmd.Parameters.AddWithValue("utenteRIF", utenteRIF);


                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        Prestito prestito = new Prestito(Convert.ToInt32(r[0]), Convert.ToDateTime(r[1]), Convert.ToDateTime(r[2]), Convert.ToInt32(r[3]), Convert.ToInt32(r[4]));
                        elenco.Add(prestito);
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

        }
    }
}
