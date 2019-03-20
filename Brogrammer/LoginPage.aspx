<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Login.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Brogrammer.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <div class="container">
        <div class="content-wrap" style="max-width:450px; margin-top:50px; box-shadow: 1px 2px 4px rgba(0, 0, 0, .5); background-color:white;">
            <div class="row justify-content-center">
             </div>
            <h1 class="font_style_one mt-3 text-center">Login to your Account</h1>
            <asp:TextBox ID="txtID" runat="server" CssClass="form-control mt-1" placeholder="ID" Width="300px"></asp:TextBox>
            <asp:Label ID="lblID" runat="server" ForeColor="Red" CssClass="ml-1 mb-1" ></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" Width="300px"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" ForeColor="Red" CssClass="ml-1"></asp:Label><br />
             <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" CssClass="btn btn-primary mt-1 mb-2" Width="300px" />
            </div>
        </div>
</asp:Content>
