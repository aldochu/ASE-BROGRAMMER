using Brogrammer.Entity;
using Brogrammer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindModule();
            }
           
        }
        private void bindModule()
        {
            DisplayModule.DataSource = ModuleSystem.getAllModule();
            DisplayModule.DataBind();

        }
        protected void DisplayMod_databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.DisplayModule, "Select$" + e.Row.RowIndex);
            }
        }

        protected void DisplayModule_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Write("<script type=\"text/javascript\">alert('Post favorited!')</script>");
        }
    }
}