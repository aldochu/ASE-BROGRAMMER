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

        public static int updatePost(post p)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);



            string query = "UPDATE post SET title = @title, content=@content, file=@file WHERE id=@id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", p.id);
            cmd.Parameters.AddWithValue("@title", p.title);
            cmd.Parameters.AddWithValue("@content", p.content);
            cmd.Parameters.AddWithValue("@file", p.file);

            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Close();
            return result;
        }

        public static int updateComment(comment c)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);



            string query = "UPDATE comment SET content = @content WHERE commentid=@id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", c.commentid);
            cmd.Parameters.AddWithValue("@content", c.content);

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

            string query = "SELECT * FROM comment";


            var cmd = new MySqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Columns.Add("cid");
            dt.Columns.Add("uid");
            dt.Columns.Add("name");
            dt.Columns.Add("content");
            dt.Columns.Add("upvote");
            dt.Columns.Add("downvote");
            dt.Columns.Add("endorseby");
            dt.Columns.Add("date");


            int i = 0;


            while (reader.Read())
            {

                dt.Rows.Add();
                dt.Rows[i]["cid"] = reader["commentid"].ToString();
                dt.Rows[i]["uid"] = reader["userid"].ToString();
                dt.Rows[i]["name"] = reader["name"].ToString();
                dt.Rows[i]["content"] = reader["content"].ToString();
                dt.Rows[i]["upvote"] = reader["upvote"].ToString();
                dt.Rows[i]["downvote"] = reader["downvote"].ToString();
                dt.Rows[i]["endorseby"] = reader["endorseby"].ToString();
                dt.Rows[i]["date"] = reader["date"].ToString();
                i++;

            }
            return dt;
        }

        /////////////////////////////////////////////////////////START SECTION FOR FAVOURITE FUNCTION////////////////////////////////////////////
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

        public static bool RemoveFavPost(string uid, int postid)
        {

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "DELETE FROM fav WHERE fav.uid = @uid AND fav.id = @id";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@id", postid);

            conn.Open();
            int affectedRows = 0;
            affectedRows = cmd.ExecuteNonQuery();
            conn.Close();

            return affectedRows == 1 ? true : false;
        }

        /////////////////////////////////////////////////////////END SECTION FOR FAVOURITE FUNCTION////////////////////////////////////////////

        public static int DeletePost(post p)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            //delete votingrec 1st
            string query = "DELETE FROM votingrec WHERE postid=@id";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", p.id);

            //delete comment 2nd
            query = "DELETE FROM comment WHERE postid=@id";
            var cmd2 = new MySqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@id", p.id);

            //delete post lastly
            query = "DELETE FROM post WHERE id=@id";
            var cmd3 = new MySqlCommand(query, conn);
            cmd3.Parameters.AddWithValue("@id", p.id);

            conn.Open();

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            result = cmd3.ExecuteNonQuery();

            conn.Close();
            return result;
        }


        /////////////////////////////////////////////////////////THIS SECTION FOR COMMENT FUNCTION////////////////////////////////////////////
        public static int createComment(comment c)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "INSERT into comment (commentid,postid,userid,name,content,date) VALUES (@commentid,@postid,@userid,@name,@content,@date)";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@commentid", c.commentid);
            cmd.Parameters.AddWithValue("@postid", c.postid);
            cmd.Parameters.AddWithValue("@userid", c.userid);
            cmd.Parameters.AddWithValue("@name", c.name);
            cmd.Parameters.AddWithValue("@content", c.content);
            cmd.Parameters.AddWithValue("@date", c.date);

            conn.Open();
            result = cmd.ExecuteNonQuery();

            conn.Close();
            return result;
        }

        public static int Upvote(string postid, string commentid, string userid)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "UPDATE comment SET upvote = upvote + 1 where commentid=@commentid";

            //this is to increment the vote
            var cmd = new MySqlCommand(query, conn); 
            cmd.Parameters.AddWithValue("@commentid", commentid);


            //this is to create record into table so user can't vote again
            query = "INSERT into votingrec (postid,commentid,uid) VALUES (@postid,@commentid,@userid)";
            var cmd2 = new MySqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@postid", postid);
            cmd2.Parameters.AddWithValue("@commentid", commentid);
            cmd2.Parameters.AddWithValue("@userid", userid);

            conn.Open();
            cmd2.ExecuteNonQuery();
            result = cmd.ExecuteNonQuery();


            conn.Close();
            return result;
        }

        public static int Downvote(string postid, string commentid, string userid)
        {
            int result = 0;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "UPDATE comment SET downvote = downvote - 1 where commentid=@commentid";

            //this is to increment the vote
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@commentid", commentid);


            //this is to create record into table so user can't vote again
            query = "INSERT into votingrec (postid,commentid,uid) VALUES (@postid,@commentid,@userid)";
            var cmd2 = new MySqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@postid", postid);
            cmd2.Parameters.AddWithValue("@commentid", commentid);
            cmd2.Parameters.AddWithValue("@userid", userid);

            conn.Open();
            cmd2.ExecuteNonQuery();
            result = cmd.ExecuteNonQuery();


            conn.Close();
            return result;
        }

        public static int Checkvote(string commentid, string userid)
        {
            int i=0;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT * FROM votingrec WHERE commentid=@cid AND uid=@uid";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cid", commentid);
            cmd.Parameters.AddWithValue("@uid", userid);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                i++;
            }
            conn.Close();

            return i;
        }

        /////////////////////////////////////////////////////////START SECTION FOR NOTIFICATIONS FUNCTION////////////////////////////////////////////
        public static List<notification> GetNotifications(string uid)
        {

            List<notification> list = new List<notification>();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "SELECT commentid, title, userid, brogrammer.comment.content, brogrammer.comment.flaggednotified FROM brogrammer.post, brogrammer.comment " +
                "WHERE brogrammer.comment.postid = brogrammer.post.id AND brogrammer.comment.userid = @uid AND brogrammer.comment.flaggednotified = @notified " +
                "GROUP BY brogrammer.comment.commentid";

            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@notified", 0);

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                notification notification = new notification();
                notification.commentid = reader["commentid"].ToString();
                notification.title = reader["title"].ToString();
                notification.content = reader["content"].ToString();
                notification.userid = reader["userid"].ToString();
                notification.flaggednotified = Convert.ToInt16(reader["flaggednotified"].ToString());
                list.Add(notification);

            }

            reader.Dispose();

            conn.Close();

            return list;
        }

        public static void clearNotification (string commentid, string userid)
        {

            string dbConnectionString = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            var conn = new MySqlConnection(dbConnectionString);

            string query = "UPDATE comment SET flaggednotified = @clearflag where commentid = @commentid AND userid = @uid";

            //this is to increment the vote
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clearFlag", 1);
            cmd.Parameters.AddWithValue("@commentid", commentid);
            cmd.Parameters.AddWithValue("uid", userid);

            conn.Open();
            cmd.ExecuteNonQuery();
     
            conn.Close();

            /////////////////////////////////////////////////////////END SECTION FOR NOTIFICATIONS FUNCTION////////////////////////////////////////////
        }

   
    }

}
