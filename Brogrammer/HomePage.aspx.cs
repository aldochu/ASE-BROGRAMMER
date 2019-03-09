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

        String user = "user1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Your code for Bind data 
                displayFavPosts(user);
                displayRecentPosts(user);
            }
            
        }

        protected void displayFavPosts(String userId)
        {
            List<fpost> favPosts = PostSystem.GetFavPosts(user);

            favRepeater.DataSource = favPosts;
            favRepeater.DataBind();

        }

        protected void displayRecentPosts(String userId)
        {
            List<post> recentPosts = PostSystem.GetPostTest(user);

            recentPostsRepeater.DataSource = recentPosts;
            recentPostsRepeater.DataBind();
        }

        protected string truncateTitle(String postTitle)
        {
            return postTitle.Length >= 21? postTitle.Substring(0, 20) + "..." : postTitle;
        }

        protected void favPostsRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "DELETE_ROW":
                    int selectedPost = Convert.ToInt32(e.CommandArgument);

                    bool result = PostSystem.RemoveFavPost(user, selectedPost);

                    if (result)
                    {
                        displayFavPosts(user);
                    }
                    break;

                case "VIEW_POST":
                    string selectedPostID = e.CommandArgument.ToString();

                    // to direct user to the exact comment record on the page of the post
                    Session["POST"] = selectedPostID;
                    Response.Redirect("DisplayPost.aspx");
                    break;

            }
            //if (e.CommandName == "DELETE_ROW")
            //{
            //    int selectedRow = Convert.ToInt32(e.CommandArgument);
            //    bool result = PostSystem.RemoveFavPost(user, selectedRow);

            //    if (result)
            //    {
            //        displayFavPosts(user);
            //        //Response.Redirect("HomePage.aspx");
            //    }
            //}
            
        }

        protected void recentPostsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;

            switch (e.CommandName.ToString())
            {
                case "VIEW_POST":
                    string selectedPostID = e.CommandArgument.ToString();

                    // to direct user to the exact comment record on the page of the post
                    Session["POST"] = selectedPostID;
                    Response.Redirect("DisplayPost.aspx");

                    //Response.Write("User selected: " + selectedCommentID);
                    break;

            }
        }
    }
}