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
        string uid = "user1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                display_Notifications(uid);
        }

        protected void display_Notifications(string uid)
        {
            List<notification> notifications = new List<notification>();
            notifications = PostSystem.GetNotifications(uid);

            notification_repeater.DataSource = notifications;
            notification_repeater.DataBind();

        }

        protected void notification_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;

            switch (e.CommandName.ToString())
            {
                case "View_Post":
                    string selectedCommentID = e.CommandArgument.ToString();

                    PostSystem.ClearNotification(selectedCommentID, uid);

                    // to direct user to the exact comment record on the page of the post
                    display_Notifications(uid);

                    //Response.Write("User selected: " + selectedCommentID);
                    break;

            }

           

        }
    }
}