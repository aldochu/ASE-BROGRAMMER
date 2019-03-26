using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using Brogrammer.Entity;
using MySql.Data.MySqlClient;

namespace Brogrammer
{
    /// <summary>
    /// Summary description for getPost
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class getPost : System.Web.Services.WebService
    {

        [WebMethod]
        public void getPosts(string searchID)
        {
            string cs = ConfigurationManager.ConnectionStrings["Brogrammer"].ConnectionString;
            List<mpost> posts = new List<mpost>();
            using (var conn = new MySqlConnection(cs))
            {
                string query = "SELECT * ,  COALESCE(SUM(upvote), 0) as total from post left join comment on post.id = comment.postid group by post.id HAVING post.mod_code = @code";
       

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", searchID);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mpost p = new mpost();
                    
                    p.id = reader["id"].ToString();
                    p.uid = reader["uid"].ToString();
                    p.title = reader["title"].ToString();
                    p.content = reader["content"].ToString();
                    p.date = Convert.ToDateTime(reader["date"]);
                    p.file = reader["file"].ToString();
                    p.upvote = reader["total"].ToString();

                    posts.Add(p);
                }
            }
            var js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(posts));
        }
    }
   }
