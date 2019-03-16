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
            p = (post)Session["PostDetail"];

            loadData();

        }

        public void loadData()
        {
            txtTitle.Attributes.Add("placeholder", p.title);
            txtContent.Attributes.Add("placeholder", p.content);

            if (p.file != "")
            {
                myframe.Attributes["src"] = "~/upload/" + p.file;
                //Response.Redirect("LoginPage.aspx");
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            bool check = true;

            if (!Validation.isEmpty(txtTitle.Text))
            {
                p.title = txtContent.Text;
            }
            if (!Validation.isEmpty(txtContent.Text))
            {
                p.content = txtContent.Text;
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

                if (FileUpload.HasFile)
                {
                    p.file = Path.GetFileName(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(Server.MapPath("~/upload/") + p.file);
                }

                PostSystem.updatePost(p);

                Response.Write("<script type=\"text/javascript\">alert('Post is updated successfully!');location.href='DisplayPost.aspx'</script>");

            }

        }

    }
}