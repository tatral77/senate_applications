<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManagePurchases.aspx.cs" Inherits="Administration.ManagePurchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .validation {
            color: palevioletred;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">Manage Purchases</label></h4>
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

                        <th>Invoice Number</th>
                        <th>Invoice Date</th>
                        <th>Vendor</th>
                        <th>Office File Number</th>
                        <th>Office File Date</th>
                        <th>Action</th>
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
                                <asp:HiddenField ID="HidPurchaseId" runat="server" Value='<%#Bind("PurchaseId")%>' />
                                <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink class="details-link" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("PurchaseId","~/ManagePurchaseItems.aspx?PurchaseId={0}")%>'><%#Eval("InvoiceNumber").ToString()%></asp:HyperLink></td>
                                <td class="itemLeft">
                                    <asp:Label ID="InvoiceDateTxt" runat="server" Text='<%#Convert.ToDateTime(Eval("InvoiceDate")).ToShortDateString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("VendorName")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="OfficeFileNoTxt" runat="server" Text='<%#Bind("OfficeFileNo")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="OfficeFileDateTxt" runat="server" Text='<%#Convert.ToDateTime(Eval("OfficeFileDate")).ToShortDateString()%>'></asp:Label></td>
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
                                        <asp:HiddenField ID="HidVendorsId" runat="server" Value='<%#Bind("VendorId")%>' />
                                        <asp:HiddenField ID="HidPurchaseId" runat="server" Value='<%#Bind("PurchaseId")%>' />

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Invoice Number</asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="InvoiceNumberTxt" class="form-control" runat="server" Text='<%#Bind("InvoiceNumber")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" runat="server" ControlToValidate="InvoiceNumberTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Number"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Invoice Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="InvoiceDateTxt" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("InvoiceDate")).ToShortDateString()%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" runat="server" ControlToValidate="InvoiceDateTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Date"></asp:RequiredFieldValidator>
                                            </td>
                                            <tr>
                                                <td class="table-data">
                                                    <asp:Label runat="server">Vendor</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="VendorsDDL" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" runat="server" ControlToValidate="VendorsDDL" InitialValue="0" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Select Vendor"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                        </tr>

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Office File Number</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="OfficeFileNoTxt" class="form-control" runat="server" Text='<%#Bind("OfficeFileNo")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Office File Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="OfficeFileDateTxt" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("OfficeFileDate")).ToShortDateString()%>'></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>

                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
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
                                                <asp:Label runat="server">Invoice Number</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="InvoiceNumberTxt" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" runat="server" ControlToValidate="InvoiceNumberTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Number"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Invoice Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="InvoiceDateTxt" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" runat="server" ControlToValidate="InvoiceDateTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Date"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Vendor</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="VendorsDDL" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator1" runat="server" ControlToValidate="VendorsDDL" InitialValue="0" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Select Vendor"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Office File Number</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="OfficeFileNoTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Office File Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="OfficeFileDateTxt" class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>

                                            <tr>

                                                <tr>
                                                    <td colspan="3">
                                                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                                            ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                                            ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                                    </td>
                                                </tr>
                                    </table>
                                </td>

                            </tr>
                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="7" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>


            </div>
        </div>
  
</asp:Content>
