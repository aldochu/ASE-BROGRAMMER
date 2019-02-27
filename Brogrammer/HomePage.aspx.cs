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
            displayRecentPosts(user);
        }

        protected void displayRecentPosts(String userId)
        {
            List<post> recentPosts = PostSystem.GetPostTest(user);

            recentPostsRepeater.DataSource = recentPosts;
            recentPostsRepeater.DataBind();
        }
    }
}