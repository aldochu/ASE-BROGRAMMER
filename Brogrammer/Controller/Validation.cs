using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using Brogrammer.Entity;
using System.IO;

namespace Brogrammer.Controller
{
    public class Validation
    {
        public static bool ComparePassword(string a, string b)
        {
            if (a == b)
                return true;
            else
                return false;
        }

        public static bool isEmpty(String s)
        {
            if (s == null || s == String.Empty)
                return true;
            else
                return false;

        }

        public static bool MoreThanChar(String s, int num)
        {
            if (s.Length < num)
                return true;
            else
                return false;

        }

        public static bool LessThanChar(String s, int num)
        {
            if (s.Length > num)
                return true;
            else
                return false;

        }

        public static bool CheckEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            { return false; }
            try
            {
                Regex _regex = new Regex("^((([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])" +
                        "+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+)*)|((\\x22)" +
                        "((((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(([\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x7f]|\\x21|[\\x23-\\x5b]|[\\x5d-\\x7e]|" +
                        "[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(\\\\([\\x01-\\x09\\x0b\\x0c\\x0d-\\x7f]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\u" +
                        "FDF0-\\uFFEF]))))*(((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(\\x22)))@((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|" +
                        "(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|" +
                        "[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900" +
                        "-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFF" +
                        "EF])))\\.?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
                return _regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool ValidNumber(string a)
        {
            int test;
            return int.TryParse(a, out test);
        }

        public static bool checkIDExist(string id)
        {
            account a = new account();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM account where id = @id";

            var cmd = new MySqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@idTest", 1);

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                a.id = reader["id"].ToString();
                a.name = reader["name"].ToString();
                a.password = reader["password"].ToString();
                a.role = reader["password"].ToString();
            }
            conn.Close();

            if (a.id != null)
                return true;
            else
                return false;
        }


        public static bool ImageCheck(String files)

        {

            string[] validFileTypes = { "gif", "png", "jpg", "jpeg", "pdf" };

            bool isValidFile = false;

            for (int i = 0; i < validFileTypes.Length; i++)

            {

                if (files.ToLower() == "." + validFileTypes[i])

                {

                    isValidFile = true;
                    break;


                }

            }

            if (!isValidFile)

            {

                return false;
            }
            else
                return true;

        }

    }
}