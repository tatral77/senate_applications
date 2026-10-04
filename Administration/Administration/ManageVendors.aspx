<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageVendors.aspx.cs" Inherits="Administration.ManageVendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <div class="row">
            <div class="col-md-11">
                <h4>
                    <label class="page-header">Manage Vendors</label></h4>
            </div>
            <div class="col-md-1 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Vendor</th>
                        <th>Vendor Number</th>
                        <th style="width: 15%">Address</th>
                        <th>Contacts</th>
                        <th>Emails</th>
                        <th>Details</th>
                        <th>NTN</th>
                        <th>Bank Account No</th>
                        <th colspan="2">Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft" style="font-weight: bold">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("Vendor")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("VendorNumber")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="AddressTxt" runat="server" Text='<%#Bind("Address")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="ContactsTxt" runat="server" Text='<%#Bind("Contacts")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="EmailsTxt" runat="server" Text='<%#Bind("Emails")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DetailsTxt" runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="NTNTxt" runat="server" Text='<%#Bind("NTN")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("BankName") + " (" + Eval("BankAccount") + ")" %>'></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="btn btn-custom" ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VendorId","~/ManageRateLists.aspx?Id={0}")%>'>Rate Lists</asp:HyperLink></td>

                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                        <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Vendor</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="Vendor" class="form-control" runat="server" Text='<%#Bind("Vendor")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Vendor Number</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="VendorNumberTxt" class="form-control" runat="server" Text='<%#Bind("VendorNumber")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Address</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="AddressTxt" class="form-control" TextMode="MultiLine" runat="server" Text='<%#Bind("Address")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Contacts</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ContactsTxt" class="form-control" runat="server" Text='<%#Bind("Contacts")%>'></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Emails</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="EmailsTxt" class="form-control" runat="server" Text='<%#Bind("Emails")%>'></asp:TextBox>
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
                                                <asp:Label runat="server">NTN</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="NTNTxt" class="form-control" runat="server" Text='<%#Bind("NTN")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Bank Name</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BankNameTxt" class="form-control" runat="server" Text='<%#Bind("BankName")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Bank Account No</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BankAccountTxt" class="form-control" runat="server" Text='<%#Bind("BankAccount")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
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
                                            <td class="table-data">
                                                <asp:Label runat="server">Vendor</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="Vendor" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Vendor Number</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="VendorNumberTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Address</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="AddressTxt" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Contacts</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ContactsTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Emails</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="EmailsTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Details</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="DetailsTxt" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">NTN</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="NTNTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Bank Name</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BankNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Bank Account No</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BankAccountTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr>

                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
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
        </div>

</asp:Content>
