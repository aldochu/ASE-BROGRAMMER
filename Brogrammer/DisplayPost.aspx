<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="DisplayPost.aspx.cs" Inherits="Brogrammer.DisplayPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Brogrammer.Controller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .font_style_two {
            font-family: 'Karma', serif;
            font-weight: 500;
            font-size: 20px;
			word-wrap: break-word;
        }
		.font_style_three {
            font-family: 'Karma', serif;
            font-weight: 400;
            font-size: 14px;
			word-wrap: break-word;
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
		.auto-style1 {
			 margin-left: auto;
            margin-right: auto;
		}
    	.center {
    		margin: auto;
			width: 100%;
			text-align: center;
			margin-left: auto;
			margin-right: auto;
    	}

  .tableStyle {
            margin-left: auto;
            margin-right: auto;
        }

  table, th, td {
  border: 1px solid black;
}

  .Post{

  padding-bottom: 80px;

}
	</style>

	<script type="text/javascript">
function setHeight(txtdesc) {
txtdesc.style.height = txtdesc.scrollHeight + "px";
}
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Post">
		<table class="tableStyle" >
			<tr>
					<td class="auto-style2 font_style_two">Posted by:			
				    <asp:Label ID="lblUid" runat="server" CssClass="font_style_two"></asp:Label>				
				</td>							
			</tr>
			<tr>
				<td class="auto-style2 font_style_two">Title:			
				    <asp:Label ID="lblTitle" runat="server" CssClass="font_style_two"></asp:Label>				
				</td>								
			</tr>
			<tr>
					<td class="auto-style2 font_style_two">			
				    <asp:Label Width="700px" ID="lblContents" runat="server" CssClass="font_style_three"></asp:Label>							
					<br />
						<%if (p.file != ""){%>
					<iframe class="center" name="myframe" id="myframe" width="400" height="600" runat=server></iframe><br />
						<%}%>
				</td>			
			</tr>
			<tr>
				<td class="auto-style2">	
					Date of Post:<asp:Label ID="lblDate" runat="server"></asp:Label>	
					<%if (p.uid == a.id){%>
					<asp:Button ID="btnUpdatepost" runat="server" Text="Edit" OnClick="btnUpdatepost_click" CssClass="btn btn-dark" />
					<%}%>
				</td>	
			</tr>
		</table>
		</div>

	<div>
		<table class="tableStyle" >
			<tr>
				<td>
					 <asp:GridView ID="grdAllCom" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"  OnPageIndexChanging="grdAllCom_PageIndexChanging" AllowPaging="True" PagerStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" EmptyDataRowStyle-HorizontalAlign="Center" BorderStyle="Solid" Width="200px">
                		 <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>	
                    </asp:TemplateField>
					<asp:TemplateField  HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Uid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
							<asp:TextBox ID="txtContent" TextMode="multiline" runat="server" Width="550px" Text='<%# Eval("Content") %>'  Height='<%# (Eval("Content").ToString().Length/4)+30%>' ReadOnly="true"></asp:TextBox>
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
					</td>
				</tr>
			</table>
			</div>


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
</asp:Content>