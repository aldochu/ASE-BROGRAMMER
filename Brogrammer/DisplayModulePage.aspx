<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="DisplayModulePage.aspx.cs" Inherits="Brogrammer.WebForm1"  EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="DisplayModule" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" OnRowDataBound="DisplayMod_databound" OnSelectedIndexChanged="DisplayModule_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="ModuleID" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="mid" runat="server" Text='<%# Eval("mid") %>'></asp:Label>
                        </ItemTemplate>	
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ModuleCode" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="modcode" runat="server" Text='<%# Eval("modcode") %>'></asp:Label>
                        </ItemTemplate>	
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ModuleName" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="modname" runat="server" Text='<%# Eval("modname") %>'></asp:Label>
                        </ItemTemplate>	
            </asp:TemplateField>
            </Columns>

</asp:GridView>

</asp:Content>



