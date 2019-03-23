<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Brogrammer.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:Table id="Table1" runat="server"
        HorizontalAlign="Center">
          <asp:TableRow >
            <asp:TableCell>
                <img src="upload/1999200_2.jpg" alt="Sample Photo" height="640" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Computer Graphics: From a Small Formula to Cyberworlds
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Alexei Sourin
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
 This book is a revised and amended edition of the book “Computer graphics: from a small formula to virtual worlds” which was printed in 2004 and 2005.
                Besides overall revisions and corrections of the text, the third part of the book is significantly enlarged by adding more programming exercises 
                on function-based shape modeling and building cyberworlds.           

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
