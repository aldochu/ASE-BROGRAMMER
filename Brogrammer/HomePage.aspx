﻿<%@ Page Title="HomePage" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Brogrammer.HomePage" %>

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

        /*#body-sub-container {
            width: 100%;
            height: 100%;
        }*/

        #schl-container {
            align-content: center;
            width: 200px;
            margin: auto;
            text-align: center;
        }

        #schl-container > h1 > a {
            color: #3498db;
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
            overflow-x: hidden;
            border-bottom: 1px solid #D3D3D3;
        }

        #recent-container {
            align-content: center;
            width: 100%;
            margin-right: 100px;
            overflow-y: scroll;
            height: 200px;
        }

        #favHeader {
            background-color: black;
            position: relative;
            color: white;
            opacity: 0.7;
        }

        #recHeader {
            background-color: black;
            position: relative;
            color: white;
            opacity: 0.7;
        }

    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="/Scripts/jquery.floatThead.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
			<%--<asp:LinkButton id="LinkButton1" Text="FORUM"  OnClick="LinkButton_Click" runat="server"/>--%>
            <h1><a href="www.google.com.sg" target="_self">SCSE</a></h1>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div id="body-sub-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
					<%if (role == "student")
							{%>
                    <h2 style="font-weight: bold;">Favourite Posts</h2>

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
                                            <th></th>
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
                                        <%# Eval("date") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <asp:LinkButton ID="deleteBtn" Text="Remove" UseSubmitBehavior="true" runat="server" CssClass="btn btn-info btn-sm" CommandName="DELETE_ROW" CommandArgument='<%# Eval("id") %>'>
                                           <span class="glyphicon glyphicon-trash" style="color: white; font-size: 10px;"></span><span style="color: white;"> Trash</span></asp:LinkButton>

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <%}
							} %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <hr />

            <h2 style="font-weight: bold;">Recent Posts</h2>


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



