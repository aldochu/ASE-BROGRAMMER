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
        public string role;


        protected void Page_Load(object sender, EventArgs e)
        {

            //for testing purposes
            a.id = "user1";
            a.name = "stud1";
            Session["Account"] = a; //saving to session
            Session["ROLE"] = "admi2n";

            /////////////////


            role = (string)Session["ROLE"];

            a = (account)Session["Account"]; //to get the session


            Get_and_Bind_Post(); //this method is to get the post  
            

            //this is to bind all comments into the list
            if (!Page.IsPostBack)
            {
                bindAccounts();
            }
        }


        private void Get_and_Bind_Post() //this is to display the post on the page
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
            lblContents.Rows = (lblContents.Text.Split('\n').Length);
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

        //this function is for post update
        protected void btnUpdatepost_click(object sender, EventArgs e)
        {
            //since the postID is still in the session, we don't have to do anything

            //for testing purposes
            Session["Post"] = p; //saving to session


            Response.Redirect("EditPostPage.aspx"); //redirect
        }



        //this function is for upvote
        protected void btnUpVote(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblID = grdAllCom.Rows[i].FindControl("lblID") as System.Web.UI.WebControls.Label; //get id of the specific row
            String id = lblID.Text; //this is comment ID

            if (PostSystem.Checkvote(id, a.id)==0)
            { 
                PostSystem.Upvote(p.id,id, a.id);
            Response.Write("<script type=\"text/javascript\">alert('Upvoted!');location.href='DisplayPost.aspx'</script>");
            }else
                AlertPopup.Show();
        }

        protected void btnDownVote(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblID = grdAllCom.Rows[i].FindControl("lblID") as System.Web.UI.WebControls.Label; //get id of the specific row
            String id = lblID.Text; //this is comment ID

            if (PostSystem.Checkvote(id, a.id) == 0)
            {
                PostSystem.Downvote(p.id,id, a.id);
                Response.Write("<script type=\"text/javascript\">alert('Downvoted!');location.href='DisplayPost.aspx'</script>");
            }
            else
                AlertPopup.Show();
        }

        protected void btnEditComment(object sender, EventArgs e)
        {
            comment c = new comment();

            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            System.Web.UI.WebControls.Label lblID = grdAllCom.Rows[i].FindControl("lblID") as System.Web.UI.WebControls.Label; //get id of the specific row
            System.Web.UI.WebControls.TextBox txtContent = grdAllCom.Rows[i].FindControl("txtContent") as System.Web.UI.WebControls.TextBox; //get id of the specific row
            c.commentid = lblID.Text; //this is comment ID
            c.content = txtContent.Text;




            Session["Comment"] = c; //saving comment id into session

            Response.Redirect("EditCommentPage.aspx"); //redirect

        }

        protected void btnDeletepost_click(object sender, EventArgs e)
        {
            

            Response.Write("<script type=\"text/javascript\">alert('Post Deleted! Redirct to homepage');location.href='HomePage.aspx'</script>");

        }
        

        //THIS IS TO CREATE COMMENT
        protected void create_Click(object sender, EventArgs e)
        {

        bool check = true;

            lblTitle.Text = lblContent.Text = "";

            if (Validation.isEmpty(txtContent.Text))
            {
                lblContent.Text = "Comment cannot be empty";
                check = false;
            }



            if (check == true)
            {
                comment c = new comment();

                c.commentid = DateTime.Now.ToString("ddMMyyyyHHmm");
                c.postid = p.id;
                c.userid = a.id;
                if (id.Checked == true)
                {
                    c.name = a.name;
                }
                else
                    c.name = "Anon";
                c.content = txtContent.Text;
                c.date = DateTime.Now;

                PostSystem.createComment(c);

                Response.Write("<script type=\"text/javascript\">alert('Comment added');location.href='DisplayPost.aspx'</script>");

            }

        }
    }
}