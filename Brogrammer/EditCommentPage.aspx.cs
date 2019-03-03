using Brogrammer.Controller;
using Brogrammer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Brogrammer
{
    public partial class EditCommentPage : System.Web.UI.Page
    {
        public comment c = new comment();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this is to get cookie
            c = (comment)Session["Comment"];

            loadData();

        }

        public void loadData()
        {
           
            txtContent.Attributes.Add("placeholder", c.content);
        }

        protected void update_Click(object sender, EventArgs e)
        {

            if (!Validation.isEmpty(txtContent.Text))
            {
                c.content = txtContent.Text;
            }



                PostSystem.updateComment(c);

                Response.Write("<script type=\"text/javascript\">alert('Comment is updated successfully!');location.href='DisplayPost.aspx'</script>");

       

        }

    
}
}