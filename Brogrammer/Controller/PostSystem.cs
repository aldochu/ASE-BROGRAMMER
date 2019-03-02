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
    public class PostSystem
    {
        public static int createPost(post p)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "INSERT into post (id,uid,title,content,file,date) VALUES (@id,@uid,@title,@content,@file,@date)";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", p.id);
            cmd.Parameters.AddWithValue("@uid", p.uid);
            cmd.Parameters.AddWithValue("@title", p.title);
            cmd.Parameters.AddWithValue("@content", p.content);
            cmd.Parameters.AddWithValue("@file", p.file);
            cmd.Parameters.AddWithValue("@date", p.date);

            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Close();
            return result;
        }

        public static post GetPost(string id)
        {
            post p = new post();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM post WHERE id=@id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                p.id = reader["id"].ToString();
                p.uid = reader["uid"].ToString();
                p.title = reader["title"].ToString();
                p.content = reader["content"].ToString();
                p.date = Convert.ToDateTime(reader["date"]);
                p.file = reader["file"].ToString();
            }
            conn.Close();
            return p;
        }

        public static List<post> GetPostTest(string uid)
        {

            List<post> list = new List<post>();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM post WHERE uid=@uid";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", uid);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                post p = new post();

                p.id = reader["id"].ToString();
                p.uid = reader["uid"].ToString();
                p.title = reader["title"].ToString();
                p.content = reader["content"].ToString();
                p.date = Convert.ToDateTime(reader["date"]);
                p.file = reader["file"].ToString();

                list.Add(p);

            }
            conn.Close();

            return list;
        }

        public static DataTable getAllCom()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM post";


            var cmd = new MySqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("uid");
            dt.Columns.Add("content");


            int i = 0;


            while (reader.Read())
            {

                dt.Rows.Add();
                dt.Rows[i]["id"] = reader["id"].ToString();
                dt.Rows[i]["uid"] = reader["uid"].ToString();
                dt.Rows[i]["content"] = reader["content"].ToString();

                i++;

            }
            return dt;
        }

        public static List<fpost> GetFavPosts(string uid)
        {

            List<fpost> list = new List<fpost>();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT fav.id AS fid, post.id AS pid, fav.uid AS uid, post.title AS title, post.date AS pdate, fav.date AS fdate " +
                "FROM fav, post WHERE fav.uid = @uid AND fav.uid IN (SELECT brogrammer.post.uid FROM brogrammer.post) " +
                "GROUP BY pid ORDER BY pdate DESC";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", uid);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                fpost fp = new fpost();

                fp.id = reader["fid"].ToString();
                fp.uid = reader["uid"].ToString();
                    // create new post object to store pid
                    post p = new post();
                    p.id = reader["pid"].ToString();
                    p.title = reader["title"].ToString();
                    p.date = Convert.ToDateTime(reader["pdate"]);
                    
                // store created post object into fpost object
                fp.post = p;
                fp.date = Convert.ToDateTime(reader["fdate"]);

                list.Add(fp);
            }
            conn.Close();

            return list;
        }

    }

}
