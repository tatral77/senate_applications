<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProcessMemberSalary.aspx.cs" Inherits="Finance.ProcessMemberSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn-print {
            background-color: #000000;
            color: #fff;
        }

        .btn-row {
            background-color: #008080;
            color: #fff;
        }
        .btn-main {
            background-color: #2E8B57;
            font-size: small;
            color: #fff;
            vertical-align: middle !important;
        }
        .btn-important
        {
             background-color:#CD5C5C;
            color: #fff;
            font-weight:bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MontshDDL').focus(
            function () {
                $(this).css({ 'background-color': '#FFFFEEE' });
            });

            $('#MonthsDDL').blur(
            function () {
                $(this).css({ 'background-color': '#DFD8D1'});
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                PROCESS MEMBERS SALARY
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" AutoPostBack="true" runat="server" class="form-control">
                </asp:DropDownList>

            </div>
            <div class="col-md-2">
                <label style="font-size: small; font-weight: bold">Month</label>
                <asp:DropDownList ID="MonthsDDL" runat="server" class="form-control" ValidationGroup="g1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator SetFocusOnError="true" style="color:#FF0000;font-size:10pt;" ID="abc" Display="Dynamic" ControlToValidate="MonthsDDL" ValidationGroup="g1" InitialValue="0" runat="server" Text="Select month" ErrorMessage="Please Select Month"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <br />
                <asp:Button ID="ProcessBtn" ValidationGroup="g1" CssClass="btn btn-main" runat="server" Text="Process Salary" OnClientClick="return confirm('Are you sure you want to process the salary?');" OnClick="ProcessBtn_Click" />
                <asp:Button ID="ChequeDetailsBtn" ValidationGroup="g1" CssClass="btn btn-main" runat="server" Text="Add Cheque Details" OnClick="ChequeDetailsBtn_Click" />
                <asp:Button ID="MonthlyChangesList" ValidationGroup="g1" CssClass="btn btn-main" runat="server" Text="View Monthly Changes" OnClick="MonthlyChangesList_Click" OnClientClick="target ='_blank';" />
            </div>
            <div class="col-md-2" style="text-align: right">
                <br />
                <asp:Button ID="FinalizeSalaryBtn" ValidationGroup="g1" CssClass="btn btn-important" runat="server" Text="Finalize Salary" OnClientClick="return confirm('Are you sure you want to finalize the salary? Amount from the respective Head of Accounts will be deducted');" OnClick="FinalizeSalaryBtn_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="err" runat="server" style="color: red; margin-top: 10px;"></div>
                <div id="success" runat="server" style="color: green; margin-top: 10px;"></div>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-5" style="font-weight: bold; font-size: 14pt;">
                <asp:Label runat="server" ID="Label6" Text="MEMBERS"></asp:Label>
            </div>
             <div class="col-md-7" align="right">
                <asp:Button CssClass="btn btn-print" ID="Button4" CommandArgument="1" ValidationGroup="g1" runat="server" Text="Salary Sheet" OnClick="PrintMemsSalSheetBtn_Click" OnClientClick="target ='_blank';" />
                <asp:Button CssClass="btn btn-print" ID="Button5" CommandArgument="1" ValidationGroup="g1" runat="server" Text="Salary Slips" OnClick="Button2_Click" OnClientClick="target ='_blank';" />
                 <asp:Button CssClass="btn btn-print" ID="Button6" CommandArgument="1" ValidationGroup="g1" runat="server" Text="Account Holders Sheet" OnClick="Bank_Click" OnClientClick="target ='_blank';" />
                 <asp:Button CssClass="btn btn-print" ID="Button7" CommandArgument="1" ValidationGroup="g1" runat="server" Text="Paid By Cheque Sheet" OnClick="Cheque_Click" OnClientClick="target ='_blank';" />
            </div>
        </div>
        <div class="row">

            <div class="col-md-12">
                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Member Name</th>
                            <th>Salary Category</th>
                            <th>Salary Active</th>
                            <th>Bank Details</th>
                            <th colspan="3"></th>
                        </tr>
                    </thead>

                    <asp:ListView ID="MembersLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidSalaryStructureId" runat="server" Value='<%#Bind("MemberId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label3" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label2" runat="server" Text='<%#Eval("MemberSalCategory")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("SalaryStatus"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                <td>

                                    <asp:Label CssClass="table-data" ID="Label5" runat="server" Text='<%#Eval("BankName") + " - " + Eval("BankAccount")%>'></asp:Label>
                                </td>
                                <%--<td>
                                    <asp:TextBox class="table-data" ID="CheckNoTxt" runat="server" Text='<%#Eval("BankName") + " - " + Eval("BankAccount")%>'></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ValidationGroup="g1" Target="_blank" ID="Button1" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Monthly Change" OnClick="Button1_Click" OnClientClick="target ='_blank';" />
                                </td>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ID="ManageChangeVtn" Target="_blank" ValidationGroup="g1" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Print Salary Slip" OnClick="PrintSlipBtn_Click" OnClientClick="target ='_blank';" />
                                </td>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ID="PrintAnnualStatement" Target="_blank" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Annual Statement" OnClick="PrintAnnualStatement_Click" OnClientClick="target ='_blank';" />
                                </td>


                            </tr>

                        </ItemTemplate>

                    </asp:ListView>


                </table>
            </div>
        </div>

        <div class="row">
            <div class="col-md-5" style="font-weight: bold; font-size: 14pt;">
                <asp:Label runat="server" ID="Label4" Text="CHAIRMAN COMMITTEES"></asp:Label>
            </div>
             <div class="col-md-7" align="right">
                <asp:Button CssClass="btn btn-print" ID="Button2" CommandArgument="2" ValidationGroup="g1" runat="server" Text="Salary Sheet" OnClick="PrintMemsSalSheetBtn_Click" OnClientClick="target ='_blank';" />
                <asp:Button CssClass="btn btn-print" ID="Button8" CommandArgument="2" ValidationGroup="g1" runat="server" Text="Salary Slips" OnClick="Button2_Click" OnClientClick="target ='_blank';" />
                 <asp:Button CssClass="btn btn-print" ID="Button9" CommandArgument="2" ValidationGroup="g1" runat="server" Text="Account Holders Sheet" OnClick="Bank_Click" OnClientClick="target ='_blank';" />
                 <asp:Button CssClass="btn btn-print" ID="Button10" CommandArgument="2" ValidationGroup="g1" runat="server" Text="Paid By Cheque Sheet" OnClick="Cheque_Click" OnClientClick="target ='_blank';" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Member Name</th>
                            <th>Salary Category</th>
                            <th>Salary Active</th>
                            <th>Bank Details</th>
                            <th colspan="3"></th>
                          

                        </tr>
                    </thead>
                    <asp:ListView ID="ChairmanLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidSalaryStructureId" runat="server" Value='<%#Bind("MemberId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label3" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label2" runat="server" Text='<%#Eval("MemberSalCategory")%>'></asp:Label>
                                </td>

                                <td>
                                    <asp:Label CssClass="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("SalaryStatus"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label CssClass="table-data" ID="Label5" runat="server" Text='<%#Eval("BankName") + " - " + Eval("BankAccount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ValidationGroup="g1" ID="Button1" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Monthly Change" OnClick="Button1_Click" OnClientClick="target ='_blank';" />
                                </td>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ID="ManageChangeVtn" ValidationGroup="g1" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Print Salary Slip" OnClick="PrintSlipBtn_Click" OnClientClick="target ='_blank';" />
                                </td>
                                <td>
                                    <asp:Button CssClass="btn btn-row" ID="PrintAnnualStatement" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Annual Statement" OnClick="PrintAnnualStatement_Click" OnClientClick="target ='_blank';" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>


                </table>
            </div>
        </div>
    </div>
</asp:Content>
