<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalarySlip.aspx.cs" EnableEventValidation = "false"  Inherits="Finance.SalarySlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><% %></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        th {
            border-bottom:solid thin !important;
            border-top:solid 2px !important;
        }
    </style>
</head>
<body style="margin: 0px;">


    <form id="form1" runat="server">
        <%-- <asp:Button ID="PrintBtn" runat="server" Text="Send Email" OnClick="PrintBtn_Click"/>--%>
        <asp:Panel id="slippanel" runat="server">
        <div class="container">
           
            <table style="width: 100%;">
                <tr>
                    <td style="border-bottom: solid thin; border-color: #000; width: 10%">
                        <img src="images\logo.png" style="width: 80px; height: 80px;" />
                    </td>
                    <td style="border-bottom: solid thin; border-color: #000; text-align: center; width: 90%">
                        <div style="font-family: Verdana; font-size: 14pt; text-decoration: underline; text-align: center;font-weight:bold">SENATE OF PAKISTAN</div>
                        <div style="margin-top: 5px; font-family: 'Verdana'; font-size: 12pt; text-align: center;" runat="server" id="SlipHeading"></div>
                          <div style="margin-top: 5px; font-family: 'Verdana'; font-size: 12pt; text-align: right;" runat="server" id="IdDiv"></div>

                    </td>
                </tr>
                <tr>

                    <td style="width: 100%; padding-top: 10px;" colspan="2">
                        <div style="float: left">
                            <div style="font-size: 11pt;font-family: 'Verdana'; text-align: left;font-weight:bold" id="SenatorNameDiv" runat="server"></div>
                            <div style="font-size: 11pt;font-family: 'Verdana'; text-align: left;" id="StatusDiv" runat="server"></div>
                            
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 30px;"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table class="table table-responsive">
                            <tr>
                                <th>PAY AND ALLOWANCES</th>
                                <th style="text-align:right">MONTHLY RATE</th>
                                <th style="text-align: right">AMOUNT</th>
                            </tr>
                            <asp:ListView ID="AllowancesLV" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("AllowanceDesc")%>'></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("MonthlyRate")))%>'></asp:Label>
                                        </td>

                                        <td style="text-align: right">
                                            <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Amount")))%>'></asp:Label>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:ListView>
                            <tr>
                                <td colspan="2" style="text-align: left;font-weight:bold;border-bottom:solid 2px !important">Gross Pay and Allowances
                                </td>
                                <td style="text-align:right;font-weight:bold;border-bottom:solid 2px !important">
                                    <asp:Label ID="TotalAllowancesLbl" runat="server"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>

                <tr>
                    <td style="padding-top: 30px;"></td>
                </tr>

                <tr>
                    <td colspan="2">
                        <table class="table table-responsive">
                            <tr>
                                <th colspan="2">DEDUCTIONS</th>
                                <th style="text-align: right">AMOUNT</th>
                            </tr>
                              <asp:ListView ID="DeductionsLV" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("DeductionDesc")%>'></asp:Label>
                                        </td>

                                        <td style="text-align: right">
                                            <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Amount")))%>'></asp:Label>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:ListView>
                            <tr>
                                <td colspan="2" style="text-align:left;font-weight:bold;border-bottom:solid 2px !important">Total Deductions
                                </td>
                                <td style="text-align:right;font-weight:bold;border-bottom:solid 2px !important">
                                    <asp:Label ID="TotalDeductionsLbl" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                    <td style="padding-top: 30px;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:right;font-size:14pt;font-weight:bold">
                          <asp:Label ID="NetAmountLbl" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("AmountPayable")))%>'></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td style="padding-top: 30px;" colspan="2">
                          <div style="font-size: 11pt;font-family: 'Verdana'; text-align:left;font-weight:bold" id="BankDiv" runat="server">
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Bank")%>'></asp:Label>
                          </div>
                    </td>
                </tr>
                  <tr>
                    <td colspan="2" style="text-align:left;font-size:12pt;text-decoration:underline">
                        <%--  <asp:Label ID="InWords" runat="server"></asp:Label>--%>
                    </td>
                </tr>
               
              



            </table>
        </div>
        </asp:Panel>
    </form>
</body>
</html>
