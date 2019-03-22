using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brogrammer.Entity;
using Brogrammer.Controller;

namespace Brogrammer
{
    public partial class HomePage : System.Web.UI.Page
    {
        public int favNum = 0;
        public int recNum = 0;
        string uid = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
                uid = ((account)Session["Account"]).id;
            else
                Response.Redirect("LoginPage.aspx");
            
            if (!IsPostBack)
            {
                //Your code for Bind data 
                displayFavPosts(uid);
                displayRecentPosts(uid);
            }
            
        }

        protected void displayFavPosts(String userId)
        {
            List<fpost> favPosts = PostSystem.GetFavPosts(uid);
            favNum = favPosts.Count;

            favRepeater.DataSource = favPosts;
            favRepeater.DataBind();

        }

        protected void displayRecentPosts(String userId)
        {
            List<post> recentPosts = PostSystem.GetPostTest(uid);
            recNum = recentPosts.Count;

            recentPostsRepeater.DataSource = recentPosts;
            recentPostsRepeater.DataBind();
        }

        protected string truncateTitle(String text, int limit)
        {
            return text.Length >= limit? text.Substring(0, limit-1) + "..." : text;
        }

        protected void favPostsRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "DELETE_ROW":
                    int selectedPost = Convert.ToInt32(e.CommandArgument);

                    bool result = PostSystem.RemoveFavPost(uid, selectedPost);

                    if (result)
                    {
                        displayFavPosts(uid);
                    }
                    break;

                case "VIEW_POST":
                    string selectedPostID = e.CommandArgument.ToString();

                    // to direct uid to the exact comment record on the page of the post
                    Session["POST"] = selectedPostID;
                    Response.Redirect("DisplayPost.aspx");
                    break;

            }
            
        }
        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ListOfPost.aspx");
        }

        protected void recentPostsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;

            switch (e.CommandName.ToString())
            {
                case "VIEW_POST":
                    string selectedPostID = e.CommandArgument.ToString();

                    // to direct uid to the exact comment record on the page of the post
                    Session["POST"] = selectedPostID;
                    Response.Redirect("DisplayPost.aspx");

                    //Response.Write("User selected: " + selectedCommentID);
                    break;

            }
        }
    }
}