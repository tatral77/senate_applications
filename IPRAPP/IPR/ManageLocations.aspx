<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageLocations.aspx.cs" Inherits="IPR.ManageLocations" %>
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
                <h4>
                    <label id="heading" runat="server" class="page-header"></label></h4>
            </div>
            <div class="col-md-2 page-header hideadd">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Location</th>
                        <th>City</th>
                        <th class="hideall">Action</th>
                    </tr>
                    <asp:ListView ID="LocationLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemDeleting="ItemDeleting"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidLocationId" runat="server" Value='<%#Bind("LocationId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                      <asp:Label ID="Label1" runat="server" Text='<%#Bind("LocationName")%>'></asp:Label>
                                    
                                </td>

                                 <td class="itemLeft">
                                      <asp:Label ID="Label2" runat="server" Text='<%#Bind("CityName")%>'></asp:Label>
                                    
                                </td>
                                <td class="itemCent hideall">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom hideedit" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom hidedelete" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidLocationId" runat="server" Value='<%#Bind("LocationId")%>' />
                                    <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("CityId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Location Name</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="LocationNameTxt" class="form-control" runat="server" Text='<%#Bind("LocationName")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="LocationNameTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Location"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">City</asp:Label></td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="CityDDL" CssClass="form-control">
                                                    <asp:ListItem Value="0">All Cities</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
                                            <td class="table-data">
                                                <asp:Label runat="server">Location Name</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="LocationNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="LocationNameTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Location"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">City</asp:Label></td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="CityDDL" CssClass="form-control">
                                                    <asp:ListItem Value="0">All Cities</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
        </div>
    </div>
</asp:Content>
