<%@ Page Title="" Language="C#" MasterPageFile="~/Application.master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="Management.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">Roles</label>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Role</th>
<th>Active</th>
<th>Action</th>
</tr>
 <asp:ListView ID="RoleLv" runat="server"
  OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"
 >

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidRoleId" runat="server" Value='<%#Bind("RoleId")%>' />
    <td class="itemCent">
    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft">
        <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;"  NavigateUrl='<%#"~/ManageRoleMenus.aspx?RoleId=" + Eval("RoleId") + "&Id=" + Eval("ApplicationId")%>'><%#Eval("RoleName").ToString()%></asp:HyperLink>
      
    <td class="itemCent"><asp:Label ID="Label1" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("IsActive")))%>'></asp:Label></td>
    
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
    <asp:HiddenField ID="HidRoleId" runat="server" Value='<%#Bind("RoleId")%>' />
    <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
    
    <td class="altCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="altLeft"><asp:TextBox ID="RoleNameTxt" class="form-control" runat="server" Text='<%#Bind("RoleName")%>' ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Role" ControlToValidate="RoleNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
    
    
    
    <td class="altLeft"><asp:DropDownList class="form-control" ID="IsActiveDDL" runat="server">
    <asp:ListItem Value="1">Yes</asp:ListItem>
    <asp:ListItem Value="0">No</asp:ListItem>
    </asp:DropDownList>
    </td>
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
    <td class="altLeft"><asp:TextBox ID="RoleNameTxt" class="form-control" runat="server" Text='' ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Role Name" ControlToValidate="RoleNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
    
    
    
    <td class="altLeft"><asp:DropDownList ID="IsActiveDDL"  class="form-control" runat="server">
    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
    <asp:ListItem Value="0">No</asp:ListItem>
    </asp:DropDownList>
    </td>
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
