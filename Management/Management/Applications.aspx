<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Applications.aspx.cs" Inherits="Management.Applications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Styles/MainStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">Applications</label>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Application</th>
<th>Action</th>
</tr>
 <asp:ListView ID="ApplicationLV" runat="server"
  OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"

 >

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidApplicationId" runat="server" Value='<%#Bind("ApplicationId")%>' />
    <td class="itemCent">
    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft">
         <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" NavigateUrl='<%#Eval("ApplicationId","~/ManageRoles.aspx?Id={0}")%>'><%#Eval("ApplicationName")%></asp:HyperLink>
    </td>
    
    
    <td class="itemCent">
                                 <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                               <%-- <asp:ImageButton ID="deleteImageButton" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the passport of Employee');" />--%>
                        </td>
  </tr>
 </ItemTemplate>
 
  <EditItemTemplate>
  <tr>
    <asp:HiddenField ID="HidApplicationId" runat="server" Value='<%#Bind("ApplicationId")%>' />
    
    <td class="altCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="altLeft"><asp:TextBox ID="ApplicationTxt" class="form-control" runat="server" Text='<%#Bind("ApplicationName")%>' ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Application Name" ControlToValidate="ApplicationTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
    <td class="altCent" width="10%">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
    </td>
    </tr>

 </EditItemTemplate>
 <InsertItemTemplate>
 <tr>
   
    <td class="altCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="altLeft"><asp:TextBox ID="ApplicationTxt" class="form-control" runat="server" Text='' ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Application Name" ControlToValidate="ApplicationTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
    
    
    
   
    <td class="altCent" width="10%">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert"
                             ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
    </td>
    </tr>
</InsertItemTemplate>
 <EmptyDataTemplate>
    <tr>
    <td colspan="4" class="altCent" align="center">No Data Found</td>
    </tr>
    </EmptyDataTemplate>
 </asp:ListView>
 
    <tr>
    <td align="left" colspan="4">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
   </table>
    
   
</div>
</div></div>

</asp:Content>
