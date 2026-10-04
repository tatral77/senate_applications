<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmployeeNOC.aspx.cs" Inherits="EstablishmentASP.EmployeeNOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">NOC</label>
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
                           
                            <th>NOC Date</th>
                            <th>NOC Type</th>
                            <th>Details</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpNocsLv" runat="server"
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
                                        <asp:HiddenField ID="HidNocId" runat="server" Value='<%#Bind("NocId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                   <td>
                                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("NocType")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
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
                <td colspan="5">
                    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:" DisplayMode="BulletList" EnableClientScript="true" ShowSummary="true" runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                <asp:HiddenField ID="HidNocId" runat="server" Value='<%#Bind("NocId")%>' />
                <asp:HiddenField ID="HidNocTypeId" runat="server" Value='<%#Bind("NocTypeId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">NOC Date</td>
                    <td>
                        <asp:TextBox ID="NOCDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="NOC Date" ControlToValidate="NOCDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Group1" ControlToValidate="NOCDateTxt" runat="server" ErrorMessage="Not a valid NOC Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">NOC Type</td>
                    <td>
                        <asp:DropDownList ID="NOCTypeDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="NOC Type" ControlToValidate="NOCTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Purpose</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Remarks")%>' TextMode="MultiLine" Rows="3"></asp:TextBox>
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
                <td colspan="5">
                    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:" DisplayMode="BulletList" EnableClientScript="true" ShowSummary="true" runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">NOC Date</td>
                    <td>
                        <asp:TextBox ID="NOCDateTxt" class="form-control js-date" runat="server" Text=""></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Group1" ControlToValidate="NOCDateTxt" runat="server" ErrorMessage="Not a valid NOC Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" Type="Date" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="NOC Date" ControlToValidate="NOCDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">NOC Type</td>
                    <td>
                        <asp:DropDownList ID="NOCTypeDDL" class="form-control" runat="server" AutoPostBack="False"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="NOC Type" ControlToValidate="NOCTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Purpose</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text="" TextMode="MultiLine" Rows="3"></asp:TextBox>
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
