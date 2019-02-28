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
            background-color: grey;
            color: white;
            float: left;
            align-content: center;
            width: 500px;
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

        <div id="fav-container">

            <asp:Repeater ID="favPostsRepeater" runat="server">

                <HeaderTemplate>
                    <table id="favPostsTB" class="table table-hover">
                        <tr>
                            <th>User</th>
                            <th>Title of Post</th>
                            <th>Date of Post</th>
                            <th>Added On</th>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("uid") %>
                        </td>
                        <td>
                            <a href="~/ViewPost.aspx?pid<%# Eval("post.id") %>"><%# Eval("post.title") %></a>
                        </td>
                        <td>
                            <%# Eval("post.date") %>
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

            <asp:Repeater ID="recentPostsRepeater" runat="server">

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
                            <a href="~/ViewPost.aspx?pid<%# Eval("id") %>"><%# Eval("title") %></a>
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



