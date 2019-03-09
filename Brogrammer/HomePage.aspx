<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Brogrammer.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #body-container {
            width: 100%;
            background-color: red;
            border-bottom-color: black;
            vertical-align: middle;
            margin: 0 auto;
        }

        #schl-container {
            align-content: center;
            width: 200px;
            margin: auto;
            text-align: center;
        }

        #schl-container > h1 > a {
            color: yellow;
            text-decoration: none;
        }

        #fav-container {
            color: black;
            float: left;
            align-content: center;
            width: 700px;
            margin-left: 100px;
            overflow-y: scroll;
            height: 200px;
        }

        #recent-container {
            float: right;
            align-content: center;
            width: 500px;
            margin-right: 100px;
            overflow-y: scroll;
            height: 200px;
        }
    </style>
    <p>SUCCESS!!!!</p>
    <div id="body-container">

        <div id="schl-container">
            <h1><a href="www.google.com.sg" target="_self">SCSE</a></h1>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="fav-container">
                    <asp:Repeater ID="favRepeater" runat="server" OnItemCommand="favPostsRepeater_ItemCommand">

                        <HeaderTemplate>
                            <table id="favPostsTB" class="table table-hover" style="width: 100%;">
                                <tr>
                                    <th>User</th>
                                    <th>Title of Post</th>
                                    <th>Date of Post</th>
                                    <th colspan="2">Added On</th>
                                </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("uid") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="VIEW_POST" CommandArgument='<%# Eval("post.id") %>'><%#truncateTitle(Eval("post.title").ToString())%></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("post.date") %>
                                </td>
                                <td>
                                    <%# Eval("date") %>
                                </td>
                                <td>
                                    <asp:Button ID="deleteBtn" Text="Delete" UseSubmitBehavior="true" runat="server" CommandName="DELETE_ROW" CommandArgument='<%# Eval("id") %>' />

                                </td>
                            </tr>
                        </ItemTemplate>
                        <%--<Columns>

                            <asp:BoundField DataField="uid"
                                ReadOnly="true"
                                HeaderText="User"
                                ItemStyle-Wrap="False" />
                            <asp:BoundField
                                ReadOnly="true"
                                HeaderText="Title of Post"
                                ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="post.date"
                                ConvertEmptyStringToNull="true"
                                HeaderText="Date of Post"
                                ItemStyle-Wrap="False" />
                            <asp:BoundField DataField="date"
                                ConvertEmptyStringToNull="true"
                                HeaderText="Added On"
                                ItemStyle-Wrap="False" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="deleteBtn" Text="Delete" UseSubmitBehavior="true" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>--%>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--
        <div id="recent-container">

            <p>post 1</p>
            <p>post 2</p>
            <p>post 3</p>
            <p>post 4</p>
            <p>post 5</p>
            <p>post 6</p>

            

        </div>--%>

        <div id="recent-container">

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
                            <%--<a href="~/ViewPost.aspx?pid<%# Eval("id") %>"><%# Eval("title") %></a>--%>
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
        </div>

    </div>
</asp:Content>



