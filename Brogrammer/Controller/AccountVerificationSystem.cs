using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using Brogrammer.Entity;

namespace Brogrammer.Controller
{
    public class AccountVerificationSystem
    {
        public static account LoginAccount(string id, string password)
        {
            account a = new account();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM account where id = @id And password = @password";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@password", password);
            //cmd.Parameters.AddWithValue("@idTest", 1);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                a.id = reader["id"].ToString();
                a.name = reader["name"].ToString();
                a.password = reader["password"].ToString();
                a.role = reader["role"].ToString();
            }
            conn.Close();


            return a;
        }
    }

}