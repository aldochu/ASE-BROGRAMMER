<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ListOfName.aspx.cs" Inherits="Brogrammer.ListOfName" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.auto-style1 {
			height: 26px;
		}
		.auto-style2 {
			width: 152px;
            height: 10px;
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
          body{
            background-image:url(images/ad_bg.jpg);
        }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container text-center">
	<h1 class="font_style_one mt-5 mb-4">Delete Account</h1>
    </div>
    <div class="content-wrap" style="max-width:810px;">
            <h4><asp:Label ID="lblHistory" runat="server" Text="Account List"></asp:Label></h4>
            <asp:GridView ID="grdAllAcc" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"  OnPageIndexChanging="grdAllAcc_PageIndexChanging" AllowPaging="True" PagerStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EmptyDataRowStyle-HorizontalAlign="Center" BorderStyle="Solid" CellPadding="10">
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Warning">
                        <ItemTemplate>
                            <asp:Label ID="lblWarning" runat="server" Text='<%# Eval("Warning") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_click" CssClass="btn btn-dark" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_click" CssClass="btn btn-danger"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="HiddenField1" runat="server" />

		<cc1:modalpopupextender id="deletePopup" runat="server" popupcontrolid="Panel2" targetcontrolid="HiddenField1" cancelcontrolid="btnNo" backgroundcssclass="modalBackground"></cc1:modalpopupextender>
        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup1" align="center" Style="display: none">
             <asp:Label ID="Label3" runat="server" Text="Are you sure you want to delete your account?" Visible="true"></asp:Label><br />
            <br />
            <asp:Label ID="lbl_id" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button ID="Button4" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
            <asp:Button ID="btnNo" runat="server" Text="Cancel"/>
            <div class="m-2"></div>
        </asp:Panel>

        </div>
</asp:Content>
