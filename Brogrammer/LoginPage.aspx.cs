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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            bool check = true;

            lblID.Text = lblPassword.Text = "";
            if (Validation.isEmpty(txtID.Text))
            {
                lblID.Text = "NRIC cannot be empty";
                check = false;
            }
            if (Validation.isEmpty(txtPassword.Text))
            {
                lblPassword.Text = "Password cannot be empty";
                check = false;
            }



            if (check == true)
            {
                account a = AccountVerificationSystem.LoginAccount(txtID.Text, txtPassword.Text);

                if (a.id == null)
                {
                    lblPassword.Text = "Invalid id or password";
                }

                else if (a != null)
                {
                    Session["Account"] = a; //saving to session
                    Session["ROLE"] = a.role; //saving to session

                    switch (a.role) //this is to limit access, so that different role will go different page
                    {
                        case "student":
                            Response.Write("<script type=\"text/javascript\">alert('Welcome Back!');location.href='HomePage.aspx'</script>"); 
                            break;
                        case "prof":
                            Response.Write("<script type=\"text/javascript\">alert('Welcome Back Prof!');location.href='HomePage.aspx'</script>");
                            break;
                        case "admin":
                            Response.Write("<script type=\"text/javascript\">alert('Welcome Back Admin!');location.href='ListOfName.aspx'</script>");
                            break;
                        default:
                            Response.Write("<script type=\"text/javascript\">alert('Login Failed!');location.href='LoginPage.aspx'</script>");
                            break;

                    };
                }



            }
        }
}
}