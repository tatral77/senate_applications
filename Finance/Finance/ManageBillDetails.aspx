<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageBillDetails.aspx.cs" Inherits="Finance.ManageBillDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row page-header">
            <div class="col-md-10">
                Bill Details
            </div>
             <div class="col-md-2">
                <asp:Button ID="NewDetailBtn" runat="server" CommandName="new" Text="Add New" OnClick="NewDetailBtn_Click" class="btn btn-success" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <table class="table table-responsive">
                    <tr>
                        <th>Sr#</th>
                        <th>Category</th>
                        <th>Amount</th>
                         <th>Action</th>
                    </tr>
                    <asp:ListView ID="CategoryLV" runat="server"
                        OnItemCanceling="CategoryLV_ItemCanceling"
                        OnItemDeleting="CategoryLV_ItemDeleting"
                        OnItemEditing="CategoryLV_ItemEditing"
                        OnItemInserting="CategoryLV_ItemInserting"
                        OnItemUpdating="CategoryLV_ItemUpdating"
                        OnItemCreated="ItemCreated"
                        OnItemDataBound="CategoryLV_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidBillDetailId" runat="server" Value='<%#Bind("BillDetailId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="AllowanceTxt" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </td>
                                <td>
                                   <%-- <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:DropDownList ID="CategoryDDL" class="form-control" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="AmountTxt" required="true" class="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td class="altCent">
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="LinkButton2" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="Label3" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                            </tr>
                        </InsertItemTemplate>
                     <%--   <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidBillDetailId" runat="server" Value='<%#Bind("BillDetailId")%>' />
                                    <asp:HiddenField ID="HidCategoryId" runat="server" Value='<%#Bind("CategoryId")%>' />
                                </td>
                                <td>
                                    <asp:DropDownList ID="CategoryDDL" class="form-control" runat="server">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="AmountTxt" required="true" class="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td class="altCent">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>

                            </tr>
                        </EditItemTemplate>--%>
                    </asp:ListView>
                </table>
            </div>
        </div>
         <div class="row page-header">
            <div class="col-md-10">
                Bill Deductions
            </div>
             <div class="col-md-2">
                <asp:Button ID="NewDeductionBtn" runat="server" CommandName="new" Text="Add New" OnClick="NewDeductionBtn_Click" class="btn btn-success" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                 <table class="table table-responsive">
                    <tr>
                        <th>Sr#</th>
                        <th>Deduction Detail</th>
                        <th>Amount</th>
                        <th>Action</th>
                    </tr>
                <asp:ListView ID="DeductionLV" runat="server"
                    OnItemCanceling="DeductionLV_ItemCanceling"
                    OnItemDeleting="DeductionLV_ItemDeleting"
                    OnItemEditing="DeductionLV_ItemEditing"
                    OnItemInserting="DeductionLV_ItemInserting"
                    OnItemUpdating="DeductionLV_ItemUpdating">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="HidBillDeductionId" runat="server" Value='<%#Bind("BillDeductionId")%>' />
                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                            <td>
                                <asp:Label class="table-data" ID="AllowanceTxt" runat="server" Text='<%#Eval("DeductionDetail")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                    ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                            <td>
                                <asp:TextBox ID="DeductionDetailTxt" required="true" class="form-control" runat="server" Text=''></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="AmountTxt" required="true" class="form-control" runat="server" Text=''></asp:TextBox>
                            </td>
                            <td class="altCent">
                                <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="insert"
                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                            </td>

                        </tr>
                    </InsertItemTemplate>
                  <%--  <EditItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                            <td>
                                <asp:HiddenField ID="HidBillDeductionId" runat="server" Value='<%#Bind("BillDeductionId")%>' />
                                <asp:TextBox ID="DeductionDetailTxt" required="true" class="form-control" runat="server" Text='<%#Bind("DeductionDetail")%>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="AmountTxt" required="true" class="form-control" runat="server" Text='<%#Bind("Amount")%>'></asp:TextBox>
                            </td>
                            <td class="altCent">
                                <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                    ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                            </td>

                        </tr>
                    </EditItemTemplate>--%>
                </asp:ListView>
                     </table>
            </div>
        </div>
    </div>
</asp:Content>
