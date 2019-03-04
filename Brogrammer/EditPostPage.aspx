<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="EditPostPage.aspx.cs" Inherits="Brogrammer.EditPostPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="content-wrap mb-5 mt-5" style="max-width:800px; background-color:white;box-shadow: 1px 2px 4px rgba(0, 0, 0, .5);">
        <h1 class="font_style_one mb-3 mt-2 text-center">Edit Thread!</h1>
		<table style="width:100%;">
			<tr>
				<td class="auto-style2 font_style_two">Title</td>
				<td>
					<asp:TextBox ID="txtTitle" runat="server" Width="500px" CssClass="form-control mt-1"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="auto-style2"></td>
				<td>
					<asp:Label ID="lblTitle" runat="server" ForeColor="Red" CssClass="mt-1"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="auto-style2 font_style_two">Content</td>
				<td>
					<asp:TextBox ID="txtContent" TextMode="multiline" Rows="15" runat="server" Width="500px" CssClass="form-control mt-1"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="auto-style2"></td>
				<td>
					<asp:Label ID="lblContent" runat="server" ForeColor="Red" CssClass="mt-1"></asp:Label>
				</td>
			</tr>
					
			<tr>
				<td class="auto-style2"></td>
				<td>
					<asp:Label ID="lblImage" runat="server" ForeColor="Red" CssClass="mt-1"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="auto-style2 font_style_two" style="padding-top:20px;">Reupload file</td>
				<td>
					<%if (p.file != ""){%>
					<iframe class="center" name="myframe" id="myframe" width="500" height="700" runat=server></iframe><br />
					<%}%>
					<asp:FileUpload ID="FileUpload" runat="server" Width="280px"/>				
				</td>
			</tr>
			<tr>
				<td></td>
				<td>*Reuploading the file will overwrite the current file.</td>
			</tr>

			<tr>
				<td></td>
				<td style="padding-top:30px; padding-bottom:30px" ><asp:Button ID="Button2" runat="server" OnClick="update_Click" Text="Submit" CssClass="btn btn-primary mb-1 ml-5" Width="200px" /></td>
			</tr>
		</table>
        </div>
</asp:Content>
