<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FriendshipGroups.aspx.cs" Inherits="IPR.FriendshipGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
               <h4> <label class="page-header" id="header" runat="server"></label></h4>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-success"  />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Friendship Group</th>
<th>Friendship Group</th>
<th>Action</th>
</tr>
 <asp:ListView ID="ListView1" runat="server">
 <%-- OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
OnItemDeleting="ItemDeleting"
  OnItemUpdating="ItemUpdating"
  OnItemDataBound="ItemDataBound"
  OnItemCreated="ItemCreated"
 >--%>

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("FriendshipGroupId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#Bind("GroupName")%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label2" runat="server" Text='<%#Bind("Country")%>'></asp:Label></td>
   <td class="itemCent">
                                 <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
        <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>
 </ItemTemplate>
 
<%--  <EditItemTemplate>
   <tr>
        <td colspan="7">
        <table class="table table-condensed table-data" >
                        <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("CityId")%>' />
                        <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
                        <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                          <tr>
                                <td class="table-data"><asp:Label runat="server" >City</asp:Label></td>
                                <td><asp:TextBox ID="CityTxt"  class="form-control control-txt" runat="server" Text='<%#Bind("CityName")%>' ></asp:TextBox>
                                 </td>
                            </tr>
                          
                            <tr>
                                <td class="table-data"><asp:Label runat="server" >Country</asp:Label></td>
                                <td><asp:DropDownList ID="CountryDDL"  class="form-control control-txt" runat="server">
                                </asp:DropDownList>
                                 </td>
                            </tr>
                            <tr>
                                <td><asp:Label runat="server" >Active</asp:Label></td>
                                <td><asp:DropDownList ID="IsActiveDDL"  class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                 </td>
                            </tr>
                             <tr>
                              
                        <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
   </td>
                        </tr>
             </table>           
                </td>    

      </tr>

 </EditItemTemplate>
 <InsertItemTemplate>
 <tr>
        <td colspan="7">
        <table class="table table-condensed table-data">
                           <tr>
                                <td class="table-data"><asp:Label runat="server" >City</asp:Label></td>
                                <td><asp:TextBox ID="CityTxt"  class="form-control control-txt" runat="server" ></asp:TextBox>
                                 </td>
                            </tr>
                            
                          
                            <tr>
                                <td><asp:Label runat="server" >Active</asp:Label></td>
                                <td><asp:DropDownList ID="IsActiveDDL"  class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                 </td>
                            </tr>
                             <tr>
                              
                        <tr>
                      
                        <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="LinkButton2" class="btn btn-success" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server"  CommandName="insert"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
   </td>
                        </tr>
             </table>           
                </td>    

      </tr>
</InsertItemTemplate>
 <EmptyDataTemplate>
    <tr>
    <td colspan="4" class="altCent" align="center">No Data Found</td>
    </tr>
    </EmptyDataTemplate>--%>
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
    <script type="text/javascript">
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 13)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder1_ListView1_saveImageButton_0').click();
                return false;
            }
        });
    </script>
</asp:Content>
