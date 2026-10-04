<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="IPR.Countries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     .btn-custom
      {
          background-color:#302c2c;
          color:#ffff
      }
    </style>
     <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
               <h4> <label class="page-header">MANAGE COUNTRIES</label></h4>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Country</th>
<th>Is Active</th>
<th>Action</th>
</tr>
 <asp:ListView ID="ListView1" runat="server"
  OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"
  OnItemDataBound="ItemDataBound"
  OnItemCreated="ItemCreated"
 >

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("CountryId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft">
    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("CountryId","~/ManageLocations.aspx?Id={0}")%>'><%#Eval("CountryName")%></asp:HyperLink></td>
    <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
    <td>
    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
    <asp:HyperLink class="btn btn-custom" ID="HyperLink3" runat="server" Target="_blank" NavigateUrl='<%#Eval("CountryId","~/ManageLocations.aspx?Id={0}")%>'>Locations</asp:HyperLink>
    <asp:HyperLink class="btn btn-custom" ID="HyperLink4" runat="server" Target="_blank" NavigateUrl='<%#Eval("CountryId","~/ManageCities.aspx?Id={0}")%>'>Cities</asp:HyperLink>
    <asp:HyperLink class="btn btn-custom" ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%#Eval("CountryId","~/Rates.aspx?Id={0}")%>'>Rates</asp:HyperLink>
    </td>
  </tr>
 </ItemTemplate>
 
  <EditItemTemplate>
   <tr>
        <td colspan="7">
        <table class="table table-condensed table-data" >
                        <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
                        <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                          <tr>
                                <td class="table-data"><asp:Label runat="server" >City</asp:Label></td>
                                <td><asp:TextBox ID="CountryNameTxt"  class="form-control control-txt" runat="server" Text='<%#Bind("CountryName")%>' ></asp:TextBox>
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
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
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
                                <td class="table-data"><asp:Label runat="server" >Country</asp:Label></td>
                                <td><asp:TextBox ID="CountryNameTxt"  class="form-control control-txt" runat="server" ></asp:TextBox>
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
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert"
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
