using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace WcfRESTGroupesService
{
    public class GroupesDataProvider
    {
        // inscription
        public static int AddPersonne(Personne personne)
        {
            int check = checkUser(personne);
            if (check != 1) return check;
            int value = 0;
            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into personne values (@id,@courriel, @passWord,@userName) ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("courriel", personne.courriel);
                cmd.Parameters.AddWithValue("passWord", personne.passWord);
                cmd.Parameters.AddWithValue("userName", personne.userName); 
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                value = 1;
                cnx.Close();
            }
            catch (Exception ex)
            {
                value = -1;
            }
            return value;
        }

        // ajouter un groupe
        internal static int AddGroupe(Groupe groupe, string courriel, string passWord)
        {
            if (!checkPassWord(courriel, passWord)) return -2;
            if (checkGroupe(groupe.nomGroupe)) return -3;
            int value = 0;
            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into groupe values (@nomGroupe,@admin) ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("nomGroupe", groupe.nomGroupe);
                cmd.Parameters.AddWithValue("admin",getAdmin(courriel, passWord));
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                value = 1;
                cnx.Close();
            }
            catch (Exception ex)
            {
                value = -1;
            }
            return value;
        }

        //liste des groupes
        internal static List<Groupe> GetGroupes(string courriel, string passWord)
        {
            List<Groupe> liste = new List<Groupe>();
            if (!checkPassWord(courriel, passWord)) return liste;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM groupe ";
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                liste.Add(new Groupe(dr["nomGroupe"].ToString(), dr["admin"].ToString()));
            }
            cnx.Close();
            return liste;
        }

        //connection
        internal static bool checkPassWord(string courriel, string passWord)
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM personne WHERE COURRIEL = @courriel AND PASSWORD = @passWord";
            cmd.Parameters.AddWithValue("courriel", courriel);
            cmd.Parameters.AddWithValue("passWord", passWord);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows ) return true;
            cnx.Close();
            return false;
        }

        // verifier si le groupe existe deja
        internal static bool checkGroupe(string nomGroupe)
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM groupe WHERE NOMGROUPE = @nomGroupe";
            cmd.Parameters.AddWithValue("nomGroupe", nomGroupe);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) return true;
            cnx.Close();
            return false;
        }

        // verifier si courriel ou userName existe deja avant inscription
        internal static int checkUser(Personne personne)
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            // check userName
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM personne WHERE USERNAME = @userName";
            cmd.Parameters.AddWithValue("userName", personne.userName);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) return -2;
            dr.Close();
            //  check courriel
            cmd.CommandText = "SELECT * FROM personne WHERE COURRIEL = @courriel";
            cmd.Parameters.AddWithValue("courriel", personne.courriel);
            cmd.Connection = cnx;
            dr = cmd.ExecuteReader();
            if (dr.HasRows) return -3;
            cnx.Close();
            return 1;
        }

        // get Admin from personne
        internal static string getAdmin(string courriel, string passWord)
        {
            string ID = null;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM personne WHERE COURRIEL = @courriel AND PASSWORD = @passWord";
            cmd.Parameters.AddWithValue("courriel", courriel);
            cmd.Parameters.AddWithValue("passWord", passWord);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               ID = dr.GetString("ID");
            }
            cnx.Close();
            return ID;
        }

        // envoyer une invitation ou demande adhesion
        public static int AddAdhesion(Adhesion adhesion, string courriel, string passWord)
        {
            if (!checkPassWord(courriel, passWord)) return -5;
            String ID = null;
            ID = getID(adhesion.userName);
            if (ID==null) return -2;
            if (!checkGroupe(adhesion.nomGroupe)) return -3;
            // verification non exestance
            int dbStatus = checkAdhesion(ID, adhesion.nomGroupe);
            if (dbStatus != 0) return -4;
            if (adhesion.status != 1 && adhesion.status != 4) return -6;
          //  if (adhesion.status == 4) ID = getAdmin(courriel, passWord);  //added
            /*
            desc.Champ Status
            1 : Inviter
            4 : Demander
            */

                // seul un admin peut envoyer une invitation


                //  if ((adhesion.status == 1) && (getAdmin(courriel, passWord) == getAdmin(adhesion.nomGroupe))) return -7;
            try
            {
                MySqlConnection cnx = new MySqlConnection();
                cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
                cnx.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into adhesion values (@id,@nomGroupe, @status) ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("id", ID);
                cmd.Parameters.AddWithValue("nomGroupe", adhesion.nomGroupe);
                cmd.Parameters.AddWithValue("status", adhesion.status);
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception ex)
            {
                dbStatus = -1;
            }
            return dbStatus;
        }

        // accepter ou refuser une demande d'adhesion, et se desabonner d'un groupe
        internal static int UpdateAdhesion(Adhesion adhesion, string courriel, string passWord)
        {              
            if (!checkPassWord(courriel, passWord)) return -5;
            String ID = null;
            ID = getID(adhesion.userName);
            if (ID == null) return -2;
            if (!checkGroupe(adhesion.nomGroupe)) return -3;
            // verification exestance
            int dbStatus = checkAdhesion(ID, adhesion.nomGroupe);
            if (dbStatus == 0) return -4;
            if (
                !(
                   (adhesion.status == 2 && dbStatus == 4) // accepter une demande
                || (adhesion.status == 3 && dbStatus == 4) // refuser une demande
                || (adhesion.status == 5 && dbStatus == 2) // se desabonner d'un groupe
                )
                ) return -6;
            /*
            desc.Champ Status
            2 : Accepter
            3 : Refuser
            5 : se désabonner
            */
            // seul un admin peut accepter ou refuser une adhesion
            if (!((adhesion.status == 2 || adhesion.status == 3) && (getAdmin(courriel, passWord) == getAdmin(adhesion.nomGroupe)))) return -7;


            try
            { 
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE adhesion set status=@status  WHERE ID=@id AND nomGroupe= @nomGroupe";
            cmd.Parameters.AddWithValue("id", ID);
            cmd.Parameters.AddWithValue("nomGroupe", adhesion.nomGroupe);
            cmd.Parameters.AddWithValue("status", adhesion.status);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();  
            cnx.Close();
             return 1;
            }
            catch (Exception ex)
            {
                return  -1;
            }
        }

        // recuperer le ID a partir du userName
        internal static string getID(string userName)
        {
            string ID = null;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM personne WHERE USERNAME = @userName";
            cmd.Parameters.AddWithValue("userName", userName);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ID = dr.GetString("ID");
            }
            cnx.Close();
            return ID;
        }

        // recuperer le Admin d'un groupe
        internal static string getAdmin(string nomGroupe)
        {
            string admin = null;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM groupe WHERE NOMGROUPE = @nomGroupe";
            cmd.Parameters.AddWithValue("nomGroupe", nomGroupe);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                admin = dr.GetString("ADMIN");
            }
            cnx.Close();
            return admin;
        }

        // recuperer l'etat d'une adhesion
        internal static int checkAdhesion(String ID,string nomGroupe)
        {
            int status = 0;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM adhesion WHERE ID = @id AND NOMGROUPE = @nomGroupe";
            cmd.Parameters.AddWithValue("id", ID);
            cmd.Parameters.AddWithValue("nomGroupe", nomGroupe);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows) return 0;

            while (dr.Read())
            {
                status = dr.GetInt16("STATUS");
            }

            cnx.Close();
            return status;
        }

       
        
        // get userName from personne
        internal static string getUserName(string courriel, string passWord)
        {
            string userName = null;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=root;Database=groupesbd;";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM personne WHERE COURRIEL = @courriel AND PASSWORD = @passWord";
            cmd.Parameters.AddWithValue("courriel", courriel);
            cmd.Parameters.AddWithValue("passWord", passWord);
            cmd.Connection = cnx;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                userName = dr.GetString("userName");
            }
            cnx.Close();
            return userName;
        }
    
    }
}