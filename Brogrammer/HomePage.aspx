<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Brogrammer.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #body-container {
            width: 100%;
            border-bottom-color: black;
            vertical-align: middle;
            margin: 0 auto;
        }

        #body-sub-container {
            width: 100%;
            height: 100%;
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
            width: 100%;
            overflow-y: scroll;
            height: 50px;
            margin-bottom: 50px;
        }

        .table-scroll {
            max-height: 300px;
            width: 100%;
            overflow-y: scroll;
            font-family: Arial;
            border-bottom: 2px solid blue;
        }

        #recent-container {
            align-content: center;
            width: 100%;
            margin-right: 100px;
            overflow-y: scroll;
            height: 200px;
        }

        #favHeader {
            background-color: #3b5998;
            position: relative;
        }

        #recHeader {
            background-color: red;
            position: relative;
        }

    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="/Scripts/jquery.floatThead.js"></script>
   <%-- Script to prevent table header from being scrolled--%>
    <script>
        $(document).ready(function () {
            var $table = $('table#favPostsTB');
            $table.floatThead({
                scrollContainer: function ($table) {
                    return $table.closest('.table-scroll');
                }
            });

            var $table1 = $('table#recentPostsTB');
            $table1.floatThead({
                scrollContainer: function ($table) {
                    return $table.closest('.table-scroll');
                }
            });
        });
    </script>
    <ol class="breadcrumb">
        <li class="breadcrumb-item active">Home</li>
    </ol>
    <div id="body-container">

        <div id="schl-container">
            <h1><a href="www.google.com.sg" target="_self">SCSE</a></h1>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div id="body-sub-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <h2>Favourite Posts</h2>

                    <%if (recNum == 0)
                        {%>
                    <p>No favourite posts yet</p>
                    <%} %>

                    <%if (favNum != 0)
                        {%>

                    <div class="table-scroll">
                        <asp:Repeater ID="favRepeater" runat="server" OnItemCommand="favPostsRepeater_ItemCommand">
                            <HeaderTemplate>
                                <table id="favPostsTB" class="table table-hover" style="width: 100%;">
                                    <thead id="favHeader">
                                        <tr>
                                            <th>User</th>
                                            <th>Title of Post</th>
                                            <th>Date of Post</th>
                                            <th colspan="2">Added On</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <%# Eval("uid") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" CommandName="VIEW_POST" CommandArgument='<%# Eval("post.id") %>'><%#truncateTitle(Eval("post.title").ToString(), 100)%></asp:LinkButton>
                                    </td>
                                    <td>
                                        <%# Eval("post.date") %>
                                    </td>
                                    <td>
                                        <%# Eval("date") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="deleteBtn" Text="Remove" UseSubmitBehavior="true" runat="server" CommandName="DELETE_ROW" CommandArgument='<%# Eval("id") %>' />

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <hr />

            <h2>Recent Posts</h2>


            <%if (recNum == 0)
                {%>
            <p>No recent posts yet</p>
            <%} %>
            <%if (recNum != 0)
                {%>
            <div class="table-scroll">
                <asp:Repeater ID="recentPostsRepeater" runat="server" OnItemCommand="recentPostsRepeater_ItemCommand">

                    <HeaderTemplate>
                        <table id="recentPostsTB" class="table table-hover">
                            <thead id="recHeader">
                                <tr>
                                    <th>User</th>
                                    <th>Title of Post</th>
                                    <th>Date of Post</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("uid") %>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" CommandName="VIEW_POST" CommandArgument='<%# Eval("id") %>'><%# truncateTitle(Eval("title").ToString(), 100) %></asp:LinkButton>
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
            <%} %>
        </div>
    </div>
</asp:Content>



