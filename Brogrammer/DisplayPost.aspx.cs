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
        public account a = new account();
        public post p = new post();


        protected void Page_Load(object sender, EventArgs e)
        {

            //for testing purposes
            a.id = "user1";
            Session["Account"] = a; //saving to session
            /////////////////


            a = (account)Session["Account"]; //to get the session

            


            Get_and_Bind_Post(); //this method is to get the post     

            if (!Page.IsPostBack)
            {
                bindAccounts();
            }




        }

        private void Get_and_Bind_Post()
        {
            //This line is a placeholder to get postID from session 1st
            String postID = "user1230220191627";

            p = PostSystem.GetPost(postID);//this is the session id

            if (p.file != "")
            {
                myframe.Attributes["src"] = "~/upload/" + p.file;
                //Response.Redirect("LoginPage.aspx");
            }

            lblUid.Text = p.uid;
            lblTitle.Text = p.title;
            lblContents.Text = p.content;
            lblDate.Text = p.date.ToString();
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

        protected void btnUpdatepost_click(object sender, EventArgs e)
        {
            //since the postID is still in the session, we don't have to do anything

            //for testing purposes
            Session["Post"] = p; //saving to session


            Response.Redirect("EditPostPage.aspx"); //redirec
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