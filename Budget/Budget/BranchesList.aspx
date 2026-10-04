<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BranchesList.aspx.cs" Inherits="Budget.BranchesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">Branches</label>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Branch</th>
<th>Active</th>
</tr>
 <asp:ListView ID="BranchLv" runat="server">

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Bind("BranchId")%>' />
    <td class="itemCent">
    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td><asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("BranchId","~/ManageBranchFinance.aspx?BR={0}")%>'><%#Eval("Description")%></asp:HyperLink>
    </td>
    <td class="itemCent"><asp:Label ID="Label1" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("Is_active")))%>'></asp:Label></td>
  </tr>
 </ItemTemplate>
 </asp:ListView>
 
   </table>
    
   
</div>
</div></div>
     
</asp:Content>
