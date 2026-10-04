<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="Visits.aspx.cs" Inherits="EstablishmentASP.Visits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">FOREIGN VISITS</label>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>


        <div class="row">
            <div class="col-md-11">

                <table class="table table-striped table-condensed table-responsive table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Country</th>
                            <th>Visit Type</th>
                            <th>From</th>
                            <th>To</th>
                             <th>NOC Date</th>
                            <th style="width:40%;">Purpose</th>                          
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                        <td colspan="8">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                    HeaderText="You must enter a value in the following fields:"
                                    DisplayMode="BulletList"
                                    EnableClientScript="true"
                                    ShowSummary="true"
                                    runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                            </tr>
                        <asp:ListView ID="EmpVisitsLv" runat="server"
                            OnItemCreated="ItemCreated"
                            OnItemEditing="ItemEditing"
                            OnItemDataBound="ItemDataBound"
                            OnItemCanceling="ItemCanceling"
                            OnItemUpdating="ItemUpdating"
                            OnItemInserting="ItemInserting"
                            OnItemDeleting="ItemDeleting"
                        >
                            <ItemTemplate>
                                <tr>

                                    <td class="itemLeft">
                                        <asp:HiddenField ID="HidVisitId" runat="server" Value='<%#Bind("ForeignVisitId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="PassportNumber" class="table-data" runat="server" Text='<%#Bind("Country")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("VisitType")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("FromDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("ToDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                     <td class="itemLeft">
                                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("NOCDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Purpose")%>'></asp:Label></td>
                                    <td>
                                        <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <EditItemTemplate>
            <tr>
                <td colspan="8">
                <asp:HiddenField ID="HidVisitId" runat="server" Value='<%#Bind("ForeignVisitId")%>' />
                <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
                <asp:HiddenField ID="HidVisitTypeId" runat="server" Value='<%#Bind("VisitTypeId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CountryDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Visit Type</td>
                    <td>
                        <asp:DropDownList ID="VisitTypeDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Visit Type" ControlToValidate="VisitTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("FromDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date" Text="*" ControlToValidate="FromDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("ToDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="From Date" Text="*" ControlToValidate="ToDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="NOC Date" Text="*" ControlToValidate="ToDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">NOC Date</td>
                    <td>
                        <asp:TextBox ID="NOCDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("NOCDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Purpose</td>
                    <td>
                        <asp:TextBox ID="PurposeTxt" class="form-control" runat="server" Text='<%#Bind("Purpose")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
                            <InsertItemTemplate>
            <tr>
                <td colspan="8">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CountryDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Visit Type</td>
                    <td>
                        <asp:DropDownList ID="VisitTypeDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Visit Type" ControlToValidate="VisitTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text=""></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="NOC Date" Text="*" ControlToValidate="ToDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">NOC Date</td>
                    <td>
                        <asp:TextBox ID="NOCDateTxt" class="form-control js-date" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Purpose</td>
                    <td>
                        <asp:TextBox ID="PurposeTxt" class="form-control" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>
                        </asp:ListView>
                      
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
