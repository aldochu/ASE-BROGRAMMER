using Brogrammer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class Master_Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            account a = new account();
            a = (account)Session["Account"]; //this is to get cookie

            if (a != null)
            {
                switch (a.role) //this is to limit access, so that different role will go different page
                {
                    case "student":
                        Label1.Text = a.name;
                        break;
                    case "prof":
                        Label2.Text = a.name;
                        break;
                    case "admin":
                        Label3.Text = a.name;
                        break;
                    default:
                        break;

                };

               
            }
        }
    }
}