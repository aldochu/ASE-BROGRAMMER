<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ListOfPost.aspx.cs" Inherits="Brogrammer.ListOfPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Repeater ID="recentPostsRepeater" runat="server" OnItemCommand="recentPostsRepeater_ItemCommand">

                <HeaderTemplate>
                    <table id="recentPostsTB" class="table table-hover">
                        <tr>
                            <th>User</th>
                            <th>Title of Post</th>
                            <th>Date of Post</th>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("uid") %>
                        </td>
                        <td>
                  
                            <asp:LinkButton runat="server" CommandName="VIEW_POST" CommandArgument='<%# Eval("id") %>'><%# truncateTitle(Eval("title").ToString()) %></asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("date") %>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
</asp:Content>
