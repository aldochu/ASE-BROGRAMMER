<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="ListOfPost.aspx.cs" Inherits="Brogrammer.ListOfPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.18/css/jquery.dataTables.css"/>
<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.18/js/jquery.dataTables.js"></script>
 <script type="text/javascript" src="https://cdn.rawgit.com/mgalante/jquery.redirect/master/jquery.redirect.js"></script>
<script type="text/javascript">  
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "getPost.asmx/getPosts",
            success: function (data) {

                var datatableVariable = $('#postTable').DataTable({
                    data: data,
                    columns: [
                        { 'data': 'id' },
                        { 'data': 'uid' },
                        { 'data': 'title' },
                        {
                            'data': 'date', 'render': function (date) {
                                var date = new Date(parseInt(date.substr(6)));
                                var month = date.getMonth() + 1;
                                return date.getDate() + "/" + month + "/" + date.getFullYear() +" - " + date.getHours() +":"  + date.getMinutes() + ":" + date.getSeconds();
                            }
                        }]
                });

                $('#postTable tbody').on('click', 'tr', function () {
                    var table = $('#postTable').DataTable().rows(this).data();
                    console.log(table[0].id);
                    alert("" + table[0].id);
                    $.redirect("/DisplayPost", { POST: table[0].id}, "POST"); 
                });

            }
        })
             });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <asp:Repeater ID="recentPostsRepeater" runat="server" OnItemCommand="recentPostsRepeater_ItemCommand">

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
    </asp:Repeater>--%>
     <table id="postTable" class="display">  
      <thead>  
              <tr>  
                        <th>ID</th>  
                        <th>Uid</th>  
                        <th>Title</th>  
                        <th>Date</th>  
            </tr>
    </thead>
    <tbody>

    </tbody>
</table>
</asp:Content>
