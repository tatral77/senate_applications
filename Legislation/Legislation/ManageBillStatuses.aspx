<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageBillStatuses.aspx.cs" Inherits="Legislation.ManageBillStatuses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4 class="page-header">Manage Bill Statuses</h4>
        <div style="text-align: right">
            <asp:Button ID="AddNewBtn" CssClass="btn btn-info" runat="server" OnClick="AddNewBtn_Click" Text="Add New" />
        </div>

        <table class="table table-responsive">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Description</th>
                    <th>Is Active</th>
                    <th>Action</th>
                </tr>
            </thead>
            <asp:ListView runat="server" ID="lv"
                OnItemDeleting="lv_ItemDeleting"
                OnItemEditing="lv_ItemEditing"
                OnItemCanceling="lv_ItemCanceling"
                OnItemInserting="lv_ItemInserting"
                OnItemUpdating="lv_ItemUpdating"
                OnItemDataBound="lv_DataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                            <asp:HiddenField ID="HidStatusId" runat="server" Value='<%#Eval("BillStatusesId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Description" runat="server" Text='<%#Eval("Description") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1?"Yes":"No") %>'></asp:Label></td>
                        <td>
                            <asp:Button ID="EditBtn" Text="Edit" runat="server" CommandName="edit" />
                            <asp:Button ID="DeleteBtn" Text="Delete" runat="server" CommandName="delete" />
                             <asp:Button ID="AddBusinessBtn" Text="Add Agenda" runat="server" CommandName="delete" />
                        </td>


                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                            <asp:HiddenField ID="HidStatusId" runat="server" Value='<%#Eval("BillStatusesId") %>' />
                            <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Eval("IsActive") %>' />

                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="DescriptionTxt" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox></td>
                        <td>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="IsActiveDDL">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="CancelBtn" Text="Cancel" runat="server" CommandName="cancel" />
                            <asp:Button ID="But" Text="Update" runat="server" CommandName="update" />
                        </td>



                    </tr>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="DescriptionTxt" runat="server" Text=""></asp:TextBox></td>
                        <td>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="IsActiveDDL">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="CancelBtn" Text="Cancel" runat="server" CommandName="cancel" />
                            <asp:Button ID="Button1" Text="Save" runat="server" CommandName="insert" />
                        </td>



                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>
