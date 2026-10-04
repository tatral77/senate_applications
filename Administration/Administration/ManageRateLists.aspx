<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageRateLists.aspx.cs" Inherits="Administration.ManageRateLists" %>

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
                    <label class="page-header">Manage Rate Lists</label></h4>
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

                        <th>Rate List Description</th>
                        <th>List Date</th>
                        <th>Vendor</th>
                        <th>Remarks</th>
                        <th>Active</th>
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
                                <asp:HiddenField ID="HidRateListId" runat="server" Value='<%#Bind("RateListId")%>' />
                                <asp:HiddenField ID="HidVendorId" runat="server" Value='<%#Bind("VendorId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink class="details-link" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("RateListId","~/ManageRateListItems.aspx?Id={0}")%>'><%#Eval("RateListDes").ToString()%></asp:HyperLink></td>
                                <td class="itemLeft">
                                    <asp:Label ID="OfficeFileDateTxt" runat="server" Text='<%#Convert.ToDateTime(Eval("RateListDate")).ToShortDateString()%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("VendorName")%>'></asp:Label></td>

                                <td class="itemLeft">
                                    <asp:Label ID="RemarksTxt" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
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
                                        <asp:HiddenField ID="HidRateListId" runat="server" Value='<%#Bind("RateListId")%>' />
                                        <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />

                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">List Description</asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="DescriptionTxt" class="form-control" runat="server" Text='<%#Bind("RateListDes")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescriptionTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Number"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">List Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ListDateTxt" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("RateListDate")).ToShortDateString()%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" runat="server" ControlToValidate="ListDateTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Date"></asp:RequiredFieldValidator>
                                            </td>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Remarks</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                             <tr>
                                            <td class="table-data">
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
                                                <asp:Label runat="server">List Description</asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="DescriptionTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescriptionTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Number"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">List Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ListDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validation" ID="RequiredFieldValidator3" runat="server" ControlToValidate="ListDateTxt" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Enter Invoice Date"></asp:RequiredFieldValidator>
                                            </td>
                                             <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Active</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Remarks</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </td>
                                        </tr>


                                 
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
