<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="DisplayPost.aspx.cs" Inherits="Brogrammer.DisplayPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Brogrammer.Controller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .font_style_two {
            font-family: 'Karma', serif;
            font-weight: 500;
            font-size: 20px;
			word-wrap: break-word;
        }
		.font_style_three {
            font-family: 'Karma', serif;
            font-weight: 400;
            font-size: 14px;
			word-wrap: break-word;
        }
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup1 {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: auto;
            height: auto;
        }
		.auto-style1 {
			 margin-left: auto;
            margin-right: auto;
		}
		.auto-style2 {
			 font-size: small;
		}
    	.center {
    		margin: auto;
			width: 100%;
			text-align: center;
			margin-left: auto;
			margin-right: auto;
    	}

		.right {
    		margin: auto;
			width: 100%;
			text-align: right;
			margin-left: auto;
			margin-right: auto;
			padding-right: 1em;
    	}

		tr.noBorder td {
			border: 0;
			border-top:hidden;

		}


		.Edit

{

background-color:cadetblue;
}

  .tableStyle {
            margin-left: auto;
            margin-right: auto;
        }

  table, th, td {
  border: 1px solid black;
}

  .Post{

  padding-bottom: 80px;

}
	</style>

	<script type="text/javascript">
function setHeight(txtdesc) {
txtdesc.style.height = txtdesc.scrollHeight + "px";
}

</script>

	<script runat="server">

		void CommentGridView_ChangeColor(Object sender, GridViewRowEventArgs e)
		{
			if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Endorseby")).Length > 3)
			{
				e.Row.BackColor = System.Drawing.Color.Cornsilk;
			}
				

		}

		protected void changecolor(object sender, System.EventArgs e)
		{
			TextBox box = (TextBox)(sender);

			if(Convert.ToString(Eval("Endorseby")).Length>3)
				box.BackColor = System.Drawing.Color.Cornsilk;

			box.Rows = Convert.ToString(Eval("Endorseby")).Split('\n').Length + 1;
  
		}

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="HomePage.aspx">Home</a></li>
        <li class="breadcrumb-item active"><asp:Label ID="breadcrumbTitle" runat="server"></asp:Label></li>
    </ol>
    <div class="Post">
		<table class="tableStyle" >
			<tr class="center">
				<td class="font_style_two">Title: &nbsp			
				    <asp:Label ID="lblTitle" runat="server" CssClass="font_style_two"></asp:Label>				
				</td>								
			</tr>
			<tr>
					<td class="center">			
					<asp:TextBox ID="lblContents" TextMode="multiline" runat="server" Width="700px" Text='<%# Eval("Content") %>'  Height='<%# (Eval("Content").ToString().Length/2)%>' ReadOnly="true" Font-Size="9"></asp:TextBox>
						
					<br />
						<%if (p.file != ""){%>
					<iframe class="center" name="myframe" id="myframe" width="400" height="600" runat=server></iframe><br />
						<%}%>
				</td>			
			</tr>
			<tr class="right">
					<td class="right auto-style2 font_style_two">Posted by:&nbsp			
				    <asp:Label ID="lblUid" runat="server" CssClass="font_style_two" Font-Size="10"></asp:Label>				
				</td>							
			</tr>
			<tr class="noBorder">
				<td class="right auto-style2 font_style_two">	
					Date of Post:&nbsp<asp:Label ID="lblDate" runat="server" Font-Size="10"></asp:Label>
				</td>
			</tr>
			<tr>
				<td  class="right">
					<%if (p.uid == a.id){%>
					<asp:Button ID="btnUpdatepost" runat="server" Text="Edit" OnClick="btnUpdatepost_click" CssClass="btn btn-dark" Font-Size="10"/>
					<%}%>
					<%if (role == "admin"){%>
					<asp:Button ID="Button1" runat="server" Text="Delete" OnClick="btnDeletepost_click" CssClass="btn btn-danger" Font-Size="10" />
					<%}%>
					<%if (p.uid != a.id && role == "student"){%>
					<asp:Button ID="Button3" runat="server" Text="Fav" OnClick="btnFavpost_click" CssClass="btn btn-dark"  Font-Size="10"/>
					<%}%>
				</td>
				
			</tr>
		</table>
		</div>


	<%if (role == "student")
		{%>
	<div class="Post">
		<h1 class="font_style_one mb-3 mt-2 text-center">Comments</h1>
		<table class="tableStyle" >
			<tr>
				<td>
					 <asp:GridView ID="grdAllCom" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"  OnPageIndexChanging="grdAllCom_PageIndexChanging" AllowPaging="True" PagerStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EmptyDataRowStyle-HorizontalAlign="Center" BorderStyle="Solid" Width="200px" onrowdatabound="CommentGridView_ChangeColor" >
                		 <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="CID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Font-Size="10" Text='<%# Eval("CID") %>'></asp:Label>
                        </ItemTemplate>	
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="UID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Font-Size="10" Text='<%# Eval("UID") %>'></asp:Label>
                        </ItemTemplate>	
                    </asp:TemplateField>
					<asp:TemplateField  HeaderText="Name" HeaderStyle-Font-Size="6" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Font-Size="10" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Font-Size="6" HeaderText="Comment" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
							<asp:TextBox OnDataBinding="changecolor" Font-Size="10" ID="txtContent" TextMode="multiline" runat="server" Width="400px" Text='<%# Eval("Content") %>' ReadOnly="true"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField>
                        <ItemTemplate>
							<asp:Button ID="btnEditComment" Font-Size="6" runat="server" Text="Edit Comment" OnClick="btnEditComment" visible='<%# (Convert.ToString(Eval("UID"))==a.id)%>' CssClass="btn btn-success" />
                            <asp:Button ID="btnUpvote" runat="server" Font-Size="10" Width="100%" Text="Up" OnClick="btnUpVote" visible='<%# (Convert.ToString(Eval("UID"))!=a.id)%>' CssClass="btn btn-dark" />
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="Upvote" HeaderStyle-Font-Size="6" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblupvote" runat="server" Font-Size="10" Width="20px" Text='<%# Eval("Upvote") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Font-Size="10" Text="Down" OnClick="btnDownVote" visible='<%# (Convert.ToString(Eval("UID"))!=a.id)%>' CssClass="btn btn-danger"/>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="Downvote" HeaderStyle-Font-Size="6" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblDownvote" runat="server" Font-Size="10" Width="20px" Text='<%# Eval("Downvote") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField >
					<asp:TemplateField  HeaderText="Date" HeaderStyle-Font-Size="6" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Width="60px" Font-Size="8" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField  HeaderText="Endorsed" HeaderStyle-Font-Size="6" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblEndorse" runat="server" Width="60px" Font-Size="10" Text='<%# Eval("Endorseby") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
					</td>
				</tr>
			</table>
			</div>
	<%} %>


	<%if (role != "student"){ %>
	<div class="Post">
		<h1 class="font_style_one mb-3 mt-2 text-center">Comments</h1>
		<table class="tableStyle" >
			<tr>
				<td>
					 <asp:GridView ID="grdAllCom2" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"  OnPageIndexChanging="grdAllCom_PageIndexChanging" AllowPaging="True" PagerStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EmptyDataRowStyle-HorizontalAlign="Center" BorderStyle="Solid" Width="200px" onrowdatabound="CommentGridView_ChangeColor">
                		 <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="CID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("CID") %>' Font-Size="10"></asp:Label>
                        </ItemTemplate>	
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="UID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%# Eval("UID") %>' Font-Size="10"></asp:Label>
                        </ItemTemplate>	
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="Name" HeaderStyle-Font-Size="6" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' Font-Size="10"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Font-Size="6" HeaderText="Comment" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
							<asp:TextBox OnDataBinding="changecolor" ID="txtContent" TextMode="multiline" Font-Size="10" runat="server" Width="400px" Text='<%# Eval("Content") %>' ReadOnly="true"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField>
                        <ItemTemplate>
							<asp:Button ID="btnEndorseComment" Font-Size="6" runat="server" Text="Endorse Comment" OnClick="btnEndorseComment" visible='<%# (role != "admin")%>' CssClass="btn btn-success" />
							<asp:Button ID="btnDeleteComment" Font-Size="6" runat="server" Text="Delete Comment" OnClick="btnDeleteComment" visible='<%# (role == "admin")%>' CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField  HeaderText="Date" HeaderStyle-Font-Size="6" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Width="60px" Font-Size="10" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
					 </td>
				</tr>
			</table>
			</div>


	<%} %>



	<div class="content-wrap mb-5 mt-5" style="max-width:840px;">
        <h1 class="font_style_one mb-3 mt-2 text-center">Add Comment</h1>
		<table style="width:100%;">

			<tr>
				<td>
					<asp:TextBox ID="txtContent" TextMode="multiline" Rows="15" runat="server" Width="100%" CssClass="form-control mt-1"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="padding-left:36%">
					<asp:Label ID="lblContent" runat="server" ForeColor="Red" CssClass="mt-1"></asp:Label>
				</td>
			</tr>	
			<tr>
				<td style="padding-left:33%;font-size:13px">Comment as:&nbsp;&nbsp;&nbsp;
					<asp:RadioButton id="id" runat="server" Font-Size="10" Text="ID" GroupName="measurementSystem" Checked="true"></asp:RadioButton>&nbsp; &nbsp;
					<asp:RadioButton id="anon" runat="server" Font-Size="10" Text="Anon" GroupName="measurementSystem"></asp:RadioButton>
				</td>
			</tr>
			<tr>
				<td style="padding-top:10px; padding-bottom:10px; padding-left:33%" ><asp:Button ID="Button2" runat="server" OnClick="create_Click" Text="Submit" CssClass="btn btn-primary mb-1 ml-5" Width="200px" /></td>
			</tr>
		</table>
        </div>

	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="HiddenField1" runat="server" />

		<cc1:modalpopupextender id="AlertPopup" runat="server" popupcontrolid="Panel2" targetcontrolid="HiddenField1" cancelcontrolid="btnNo" backgroundcssclass="modalBackground"></cc1:modalpopupextender>
        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup1" align="center" Style="display: none">
            <asp:Label ID="warningtext" runat="server" Text="Voting failed, you have already voted       " Visible="true"></asp:Label><br />
            <br />
            <asp:Label ID="lbl_id" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button ID="btnNo" runat="server" Text="Okay"/>
            <div style="padding:10px" class="m-2"></div>
        </asp:Panel>

</asp:Content>