using Brogrammer.Controller;
using Brogrammer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Brogrammer
{
    public partial class EditPostPage : System.Web.UI.Page
    {
        account a = new account();
        public post p = new post();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this is to get cookie
            a = (account)Session["Account"]; 
            p = (post)Session["Post"];

            loadData();

        }

        public void loadData()
        {
            txtTitle.Text = p.title;
            txtContent.Text = p.content;

            if (p.file != "")
            {
                myframe.Attributes["src"] = "~/upload/" + p.file;
                //Response.Redirect("LoginPage.aspx");
            }
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
                p.uid = "user1"; //user id
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