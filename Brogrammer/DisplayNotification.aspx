﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="DisplayNotification.aspx.cs" Inherits="Brogrammer.DisplayNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .list-group > a:hover {
            z-index: 2;
            color: #fff;
            background-color: #007bff;
            border-color: #007bff;
        }
    </style>

    <h3 style="margin: auto;">Notifications</h3>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="list-group" style="width: 500px; height: 800px; margin: auto; overflow-y: scroll;">

                <asp:Repeater ID="notification_repeater" runat="server" OnItemCommand="notification_repeater_ItemCommand">

                    <ItemTemplate>

                        <asp:LinkButton ID="viewPost" runat="server" CssClass="list-group-item list-group-item-action flex-column align-items-start" CommandName="View_Post" 
                            CommandArgument='<%# Eval("commentid") %>'>
                        
                            <div class="d-flex w-100 justify-content-between">
                                <h4 class="mb-1">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>'></asp:Label></h4>
                            </div>
                            <p class="mb-1" style="background-color: whitesmoke; color: black;">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("content") %>'></asp:Label>
                            </p>
                            <small><i>Commented by: </i>
                                <asp:Label ID="cuid" runat="server" Text='<%# Eval("userid") %>'></asp:Label></small>
                            </asp:LinkButton>

                    </ItemTemplate>

                </asp:Repeater>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
