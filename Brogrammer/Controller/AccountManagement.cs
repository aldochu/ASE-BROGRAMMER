using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brogrammer.Entity;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Brogrammer.Controller
{
    public class AccountManagement
    {
        public static account GetAccount(string id)
        {
            account a = new account();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM account WHERE id=@id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                a.id = reader["id"].ToString();
                a.name = reader["name"].ToString();
                a.password = reader["password"].ToString();
                a.role = reader["role"].ToString();
                a.warning = Convert.ToInt32(reader["warning"]);
            }
            conn.Close();
            return a;
        }

        public static int createAccount()
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "INSERT into account (id,name,password,role,warning) VALUES (@id,@name,@pw,@role,@warning)";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", 2);
            cmd.Parameters.AddWithValue("@name", 2);
            cmd.Parameters.AddWithValue("@pw", 2);
            cmd.Parameters.AddWithValue("@role", 2);
            cmd.Parameters.AddWithValue("@warning", 2);

            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Close();
            return result;
        }

        public static void DeleteAccount(string id)
        {

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "DELETE FROM account WHERE id=@id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static DataTable getAllAcc()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM account";


            var cmd = new MySqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("password");
            dt.Columns.Add("role");
            dt.Columns.Add("warning");

            int i = 0;


            while (reader.Read())
            {

                dt.Rows.Add();
                dt.Rows[i]["id"] = reader["id"].ToString();
                dt.Rows[i]["name"] = reader["name"].ToString();
                dt.Rows[i]["password"] = reader["password"].ToString();
                dt.Rows[i]["role"] = reader["role"].ToString();
                dt.Rows[i]["warning"] = reader["warning"].ToString();

                i++;

            }
            return dt;
        }
    }
}