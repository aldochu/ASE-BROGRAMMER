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
    public partial class ForumMasterPage : System.Web.UI.MasterPage
    {
        public int notifications_count = 0;

        public string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            Get_Notifications_Count(((account)Session["Account"]).id);

            name = ((account)Session["Account"]).id;
        }

        protected void Get_Notifications_Count(string uid)
        {
            List<notification> notifications = PostSystem.GetNotifications(uid);
            notifications_count = notifications.Count;
        }

    }
}