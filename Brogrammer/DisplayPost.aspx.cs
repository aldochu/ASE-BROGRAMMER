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
    public partial class DisplayPost : System.Web.UI.Page
    {
        public List<post> list = new List<post>();



        protected void Page_Load(object sender, EventArgs e)
        {
            account a = new account();
            a = (account)Session["Account"]; //to get the session
            if (a != null)
            {
            }
            else
            {
                myframe.Attributes["src"] = "~/upload/" + "PrintablePage.pdf";
                //Response.Redirect("LoginPage.aspx");
            }

            if (!Page.IsPostBack)
            {
                bindAccounts();
            }
        }

        private void bindAccounts()
        {
            grdAllCom.DataSource = PostSystem.getAllCom();
            grdAllCom.DataBind();

        }

        protected void grdAllCom_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAllCom.PageIndex = e.NewPageIndex;
            bindAccounts();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblID = grdAllCom.Rows[i].FindControl("lblID") as System.Web.UI.WebControls.Label; //get id of the specific row
            String id = lblID.Text;
            Session["acc_id"] = id; //save into session
            Response.Redirect("AdminUpdateAccPage.aspx"); //go to another page that do some actions that update the acc
        }

        protected void btnDelete_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblID = grdAllCom.Rows[i].FindControl("lblID") as System.Web.UI.WebControls.Label;
            //int accountID = Convert.ToInt32(lblAccountID.Text);
            lbl_id.Text = lblID.Text;
            deletePopup.Show(); //this is using ajax
        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            String accountID = lbl_id.Text;
            AccountManagement.DeleteAccount(accountID);
            Response.Write("<script type=\"text/javascript\">alert('Account Deleted!');location.href='ListOfName.aspx'</script>");
        }
    }
}