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

        public bool Delete(int id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM utente WHERE utenteID = @id";
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

        public List<Utente> GetAll()
        {
            List<Utente> elenco = new List<Utente>();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM utente";

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        Utente utente = new Utente(Convert.ToInt32(r[0]), r[1].ToString(), r[2].ToString(), r[3].ToString());
                        elenco.Add(utente);
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

        public Utente GetById(int id)
        {
            Utente utente = new Utente();

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM utente WHERE utenteID=@id";
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    
                    while(r.Read()){
                        utente.Id = id;
                    utente.Nome = r[1].ToString();
                    utente.Cognome = r[2].ToString();
                        utente.Email = r[3].ToString();
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

            return utente;
        }

        public bool Insert(Utente t)
        {
            bool res = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO utente (nome, cognome, email) VALUES (@nome, @cognome, @email)";
                cmd.Parameters.AddWithValue("nome", t.Nome);
                cmd.Parameters.AddWithValue("cognome", t.Cognome);
                cmd.Parameters.AddWithValue("email", t.Email);

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

        public bool Update(Utente t, int id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE utente SET nome=@nome, cognome=@cognome, email=@email WHERE utenteID=@id";
                cmd.Parameters.AddWithValue("nome", t.Nome);
                cmd.Parameters.AddWithValue("cognome", t.Cognome);
                cmd.Parameters.AddWithValue("email", t.Email);
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
    }
}
