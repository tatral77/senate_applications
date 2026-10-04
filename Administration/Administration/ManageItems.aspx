<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ManageItems.aspx.cs" Inherits="Administration.ManageItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <%-- <div class="row">
            <div class="col-md-9">
                <h4>
                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" NavigateUrl="~/ManageCategories.aspx">Back to Categories</asp:HyperLink>
                </h4>
            </div>
            </div>--%>
        <div class="row" style="margin-top: 0px;">
            <div class="col-md-9 page-header">
                <h4>
                    <asp:HyperLink CssClass="details-link" ID="HyperLink1" runat="server"><asp:Label ID="heading" runat="server"></asp:Label></asp:HyperLink>
                </h4>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Item</th>
                        <th>Details</th>
                        <th>Main Item</th>
                        <th>Opening Balance (Items)</th>
                         <th>Threshold Level (Items)</th>
                        <th>Unit</th>
                         <th>Items in Packing</th>
                          <th>Total Current Items</th>
                        <th>Active</th>
                        <th style="width:10%">Action</th>
                    </tr>
                    <asp:ListView ID="MainItemLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemDeleting="ItemDeleting"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidItemId" runat="server" Value='<%#Bind("ItemId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Descriptiontxt" runat="server" Text='<%#Bind("ItemName")%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label4"  runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("MainItem")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("CurrentBalance")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("ThresholdLevel")%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("Unit")%>'></asp:Label></td>
                                  <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("ItemsInPacking")%>'></asp:Label></td>
                                  <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("TotalCurrentItems")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                      <asp:Label runat="server" style="color:crimson" ID="err"></asp:Label>
                                    <asp:HiddenField ID="HidItemId" runat="server" Value='<%#Bind("ItemId")%>' />
                                    <asp:HiddenField ID="HidMainItemId" runat="server" Value='<%#Bind("MainItemId")%>' />
                                     <asp:HiddenField ID="HidUnitId" runat="server" Value='<%#Bind("UnitId")%>' />
                                    <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Item</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ItemTxt" class="form-control" runat="server" Text='<%#Bind("ItemName")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr"  ValidationGroup="g1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Item Name" ControlToValidate="ItemTxt"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Details</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="DetailsTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Details")%>'></asp:TextBox>

                                            </td>

                                        </tr>
                                     
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Main Item</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="MainItemDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator  ValidationGroup="g1" ControlToValidate="MainItemDDL" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Main Item"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Threshold Level: (Items)</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ThresholdLevelTxt" class="form-control" runat="server" Text='<%#Bind("ThresholdLevel")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr"  ValidationGroup="g1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Threshold Level" ControlToValidate="ThresholdLevelTxt"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Opening Balance: (Items)</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CurrentBalanceLbl" class="form-control" runat="server" Text='<%#Bind("CurrentBalance")%>'></asp:TextBox>

                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Unit</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator  ValidationGroup="g1" ControlToValidate="UnitDDL" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Unit"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Items In Packing</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ItemsInPackingTxt" class="form-control" runat="server" Text='<%#Bind("ItemsInPacking")%>'></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g3" class="btn btn-custom" runat="server" CommandName="cancel"
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
                                       <asp:Label runat="server" ID="err" style="color:crimson"></asp:Label>
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Item</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ItemTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ValidationGroup="g1" ErrorMessage="Enter Item Name" ControlToValidate="ItemTxt"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Details</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="DetailsTxt" TextMode="MultiLine" class="form-control" runat="server" Text=''></asp:TextBox>

                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Threshold Level: (Items)</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ThresholdLevelTxt"  class="form-control" runat="server" Text='5'></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr"  ValidationGroup="g1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Threshold Level" ControlToValidate="ThresholdLevelTxt"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                        
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Opening Balance: (Items)</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CurrentBalanceTxt" class="form-control" runat="server" Text='0'></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator3" ValidationGroup="g1" runat="server" ErrorMessage="Enter Current Balance" ControlToValidate="CurrentBalanceTxt"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                           <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Unit</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator  ValidationGroup="g1" ControlToValidate="UnitDDL" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select Unit"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Items In Packing</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ItemsInPackingTxt" class="form-control" runat="server" Text=''></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>

                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="LinkButton2" class="btn btn-custom" ValidationGroup="g3" runat="server" CommandName="cancel"
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

                  
                </table>


            </div>
        </div>
    </div>
</asp:Content>
