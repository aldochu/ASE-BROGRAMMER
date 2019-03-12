using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brogrammer.Entity;
using Brogrammer.Controller;
using System.Web.UI.HtmlControls;

namespace Brogrammer
{
    public partial class DisplayNotification : System.Web.UI.Page
    {
        string uid = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
                uid = ((account)Session["Account"]).id;

            else
                Response.Redirect("LoginPage.aspx");

            if (!Page.IsPostBack)
            {
                display_Notifications(uid);
            }
        }

        protected void display_Notifications(string uid)
        {
            List<notification> notifications = new List<notification>();
            notifications = PostSystem.GetNotifications(uid);

            if (notifications.Count <= 0)
                Response.Redirect("ListOfPost.aspx");

            notification_repeater.DataSource = notifications;
            notification_repeater.DataBind();

        }

        protected void notification_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string commentid = commandArgs[0];
            string selectedPostID = commandArgs[1];

            switch (e.CommandName.ToString())
            {
                case "VIEW_POST":

                    if (PostSystem.ClearNotification(commentid, uid) != 0)
                        Response.Write("<p>notification cleared!</p>");

                    // to direct uid to the exact comment record on the page of the post
                    display_Notifications(uid);

                    Session["POST"] = selectedPostID;
                    Response.Redirect("DisplayPost.aspx");

                    //Response.Write("User selected: " + selectedCommentID);
                    break;

            }

           

        }
    }
}