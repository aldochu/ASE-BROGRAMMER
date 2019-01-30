using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Write("<script type=\"text/javascript\">alert('Signed Out!');location.href='LoginPage.aspx'</script>");
        }
    }
}