<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="DisplayModulePage.aspx.cs" Inherits="Brogrammer.WebForm1"  EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="moduleRepeater" runat="server" OnItemCommand="moduleRepeater_ItemCommand">

                    <HeaderTemplate>
                        <table id="recentPostsTB">
                            <thead id="recHeader">
                                <tr>
                                    <th>ID</th>
                                    <th>Module Code</th>
                                    <th>Module Name</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("mid") %>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" CommandName="VIEW_POST" CommandArgument='<%# Eval("modcode") %>'><%# Eval("modcode") %></asp:LinkButton>
                            </td>
                            <td>
                                <%# Eval("modname") %>
                            </td>
                        </tr>
                   
                    </ItemTemplate>

                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
</asp:Content>



