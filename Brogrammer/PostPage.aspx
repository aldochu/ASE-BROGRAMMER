<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="PostPage.aspx.cs" Inherits="Brogrammer.PostPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.auto-style2 {
			width: 200px;
            height: 10px;
		}
        body{
            background-image:url(images/login_bg.jpg);
        }
        .font_style_two {
            font-family: 'Karma', serif;
            font-weight: 500;
            font-size: 20px;
        }
	</style>
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showpreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrap mb-5 mt-5" style="max-width:800px; background-color:white;box-shadow: 1px 2px 4px rgba(0, 0, 0, .5);">
        <h1 class="font_style_one mb-3 mt-2 text-center">Create New Thread!</h1>
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
				<td class="auto-style2 font_style_two" style="padding-top:20px;">Upload file</td>
				<td>
					<asp:FileUpload ID="FileUpload" runat="server" Width="280px" onchange="showpreview(this);" />
				</td>
			</tr>

			<tr>
				<td></td>
				<td style="padding-top:30px; padding-bottom:30px" ><asp:Button ID="Button2" runat="server" OnClick="create_Click" Text="Submit" CssClass="btn btn-primary mb-1 ml-5" Width="200px" /></td>
			</tr>
		</table>
        </div>
		</asp:Content>