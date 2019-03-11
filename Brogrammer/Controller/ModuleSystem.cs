using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using Brogrammer.Entity;
using System.Data;

namespace Brogrammer.Controller
{
    public class ModuleSystem
    {
        public static DataTable getAllModule()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM modules";


            var cmd = new MySqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("mid");
            dt.Columns.Add("modcode");
            dt.Columns.Add("modname");


            int i = 0;


            while (reader.Read())
            {

                dt.Rows.Add();
                dt.Rows[i]["mid"] = reader["id"].ToString();
                dt.Rows[i]["modcode"] = reader["mod_code"].ToString();
                dt.Rows[i]["modname"] = reader["mod_name"].ToString();
                i++;

            }
            return dt;
        }
    }
}