<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MonthlyChangesList.aspx.cs" Inherits="Finance.MonthlyChangesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header" id="monthdiv" runat="server" style="font-size:14pt;color:#000">

            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="font-weight: bold">
                Allowances
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover table-striped table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Member Name</th>
                            <th style="width: 40%">Allowance</th>
                            <th>Amount</th>
                            <th>Remarks</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="LV" runat="server"
                        OnItemDeleting="ItemDeleting">
                       
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMonthlyChangeId" runat="server" Value='<%#Bind("MonthlyChangeId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Amount")))%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label6" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                </td>
                            </tr>


                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="6" style="text-align:center;font-size:10pt;">No Monthly Change in Allowances</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
</div>

            <div class="row">

                <div class="col-md-12" style="font-weight: bold">
                    Deductions
                </div>
                <div class="col-md-12">
                    <table class="table table-hover table-striped table-condensed table-responsive">
                        <thead>
                            <tr>
                                <th>Sr#</th>
                                <th>Member NAme</th>
                                <th>Deduction</th>
                                <th>Amount</th>
                                <th>Limit</th>
                                 <th>Remarks</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <asp:ListView ID="DLV" runat="server"
                             OnItemDeleting="ItemDeductionDeleting">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidMonthlyChangeId" runat="server" Value='<%#Bind("MonthlyChangeId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                     <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                    <td>
                                        <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Amount")))%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label class="table-data" ID="Label4" runat="server" Text='<%#Eval("Limit")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label class="table-data" ID="Label5" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <%--<asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                    </td>
                                </  tr>
                            </ItemTemplate>
                               <EmptyDataTemplate>
                            <tr>
                                <td colspan="7" style="text-align:center;font-size:10pt;">No Monthly Change in Deductions</td>
                            </tr>
                        </EmptyDataTemplate>
                        </asp:ListView>
                    </table>

                </div>
            </div>
    </div>
</asp:Content>
