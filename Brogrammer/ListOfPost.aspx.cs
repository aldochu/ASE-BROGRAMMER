﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brogrammer.Entity;
using Brogrammer.Controller;
using System.Web.Services;

namespace Brogrammer
{
    public partial class ListOfPost : System.Web.UI.Page
    {
        protected string abc;
        protected void Page_Load(object sender, EventArgs e)
        {
            abc = (string)Session["MODCODE"];


            /* String user = "f";

             if (!IsPostBack)
             {
                 displayRecentPosts(user);
             }*/
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostPage.aspx");
        }

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }
        /*protected void displayRecentPosts(String filter)
{
List<post> recentPosts = PostSystem.getPostByModuleCode(filter);

recentPostsRepeater.DataSource = recentPosts;
recentPostsRepeater.DataBind();
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
protected string truncateTitle(String postTitle)
{
return postTitle.Length >= 21 ? postTitle.Substring(0, 20) + "..." : postTitle;
}
*/

    }
}