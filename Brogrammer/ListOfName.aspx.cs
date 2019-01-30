using Brogrammer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Brogrammer.Controller;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class ListOfName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            account a = new account();
            a = (account)Session["Account"];

            if (a == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!a.role.Equals("admin"))
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!Page.IsPostBack)
            {
                bindAccounts();
            }
        }

        private void bindAccounts()
        {
            grdAllAcc.DataSource = AccountManagement.getAllAcc();
            grdAllAcc.DataBind();

        }

        protected void grdAllAcc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAllAcc.PageIndex = e.NewPageIndex;
            bindAccounts();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblAccountID = grdAllAcc.Rows[i].FindControl("lblAccountID") as System.Web.UI.WebControls.Label; //get id of the specific row
            String id = lblAccountID.Text;
            Session["acc_id"] = id; //save into session
            Response.Redirect("AdminUpdateAccPage.aspx"); //go to another page that do some actions that update the acc
        }

        protected void btnDelete_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblAccountID = grdAllAcc.Rows[i].FindControl("lblAccountID") as System.Web.UI.WebControls.Label;
            //int accountID = Convert.ToInt32(lblAccountID.Text);
            lbl_id.Text = lblAccountID.Text;
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