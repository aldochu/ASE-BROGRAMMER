using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a =  Request.Form["POST"];
            Session["POST"] = a;
            Response.Redirect("DisplayPost.aspx");
        }
    }
}