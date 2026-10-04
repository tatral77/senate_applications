<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMemberBankAccounts.aspx.cs" Inherits="Finance.ManageMemberBankAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 page-header">
                <asp:Label ID="header" runat="server"></asp:Label>

            </div>
            <div class="col-md-2 page-header">
                 <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="Button1_Click" class="btn btn-success" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Bank Name</th>
                            <th>Account Number</th>
                            <th>Is Salaried</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="LV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDeleting="AllowanceItemDeleting"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMemberBankAccountId" runat="server" Value='<%#Bind("MemberBankAccountId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("BankName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("AccountNumber")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsSalaried"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                </td>
                            </tr>


                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:TextBox class="form-control" ID="BankNameTxt" runat="server" Text="ABL P. House Br. Ibd"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" ID="AccountNumberTxt" runat="server" Text="CD-00100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox class="table-data" ID="IsSalariedCB" runat="server" Checked="true"></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <tr>

                                <td>
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                                    <asp:HiddenField ID="HidMemberBankAccountId" runat="server" Value='<%#Bind("MemberBankAccountId")%>' />
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" ID="BankNameTxt" runat="server" Text='<%#Eval("BankName")%>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="form-control" ID="AccountNumberTxt" runat="server" Text='<%#Eval("AccountNumber")%>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox class="form-control" ID="IsSalariedCB" runat="server" Checked='<%#(Convert.ToInt32(Eval("IsSalaried"))==1)?true :false%>'></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            </tr>

                        </EditItemTemplate>


                    </asp:ListView>


                </table>
            </div>
        </div>
    </div>
</asp:Content>
