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
            List<post> posts = new List<post>();
            using (var conn = new MySqlConnection(cs))
            {
                string query = "SELECT * FROM post where title like @code order by date desc ";
                

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", "%" + searchID + "%");

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
                
                    posts.Add(p);
                }
            }
            var js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(posts));
        }
    }
   }
