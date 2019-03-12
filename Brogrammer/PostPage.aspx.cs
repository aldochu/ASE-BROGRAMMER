using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brogrammer.Controller;
using Brogrammer.Entity;

namespace Brogrammer
{
    public partial class PostPage : System.Web.UI.Page
    {
        account a = new account();

        protected void Page_Load(object sender, EventArgs e)
        {

            a = (account)Session["Account"]; //this is to get cookie
        }

        protected void create_Click(object sender, EventArgs e)
        {
            bool check = true;

            lblTitle.Text = lblContent.Text = "";
            if (Validation.isEmpty(txtTitle.Text))
            {
                lblTitle.Text = "Title cannot be empty";
                check = false;
            }
            if (Validation.isEmpty(txtContent.Text))
            {
                lblContent.Text = "Content cannot be empty";
                check = false;
            }


            if (FileUpload.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);

                if (!Validation.ImageCheck(ext)) //check filetype
                {
                    check = false;
                    lblImage.Text = "This file format is not supported by the system";
                }

            }


            if (check == true)
            {
                post p = new post();
                p.id = "user1" + DateTime.Now.ToString("ddMMyyyyHHmm"); //user1 is just a placeholder, will use session to get the id
                p.uid = "user1"; //uid id
                p.title = txtContent.Text;
                p.content = txtContent.Text;
                p.date = DateTime.Now;

                if (FileUpload.HasFile)
                {
                    p.file = Path.GetFileName(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(Server.MapPath("~/upload/") + p.file);
                }

                PostSystem.createPost(p);

                Response.Write("<script type=\"text/javascript\">alert('Post is created successfully!');location.href='HomePage.aspx'</script>");

            }

        }

    }
}