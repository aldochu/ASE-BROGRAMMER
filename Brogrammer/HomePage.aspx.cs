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

            favGridView.DataSource = favPosts;
            favGridView.DataBind();

            for (int i = 0; i < favGridView.Rows.Count; i++)
            {
                HyperLink hlContro = new HyperLink();
                hlContro.NavigateUrl = "./newPage.aspx?ID=" + favPosts[i].post.id;
                hlContro.Text = favPosts[i].post.title;
                favGridView.Rows[i].Cells[1].Controls.Add(hlContro);
            }
        }

        protected void displayRecentPosts(String userId)
        {
            List<post> recentPosts = PostSystem.GetPostTest(user);

            recentPostsRepeater.DataSource = recentPosts;
            recentPostsRepeater.DataBind();
        }

        protected void favGridView_delete(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRow = e.RowIndex;
            if (e.CommandName == "DeleteRow")
            {
                int selectedRow = Convert.ToInt32(e.CommandArgument);
                bool result = PostSystem.RemoveFavPost(user, selectedRow);

                if (result)
                {
                    displayFavPosts(user);
                    //Response.Redirect("HomePage.aspx");
                }
            }
            
        }


    }
}