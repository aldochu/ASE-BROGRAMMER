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
            moduleRepeater.DataSource = ModuleSystem.getAllModule();
            moduleRepeater.DataBind();

        }
        protected void moduleRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item = e.Item;

            switch (e.CommandName.ToString())
            {
                case "VIEW_POST":
                    string selectedModCode = e.CommandArgument.ToString();

                    // to direct uid to the exact comment record on the page of the post
                    Session["MODCODE"] = selectedModCode;
                    Response.Redirect("ListOfPost.aspx");

                    //Response.Write("User selected: " + selectedCommentID);
                    break;

            }
        }
    }
}