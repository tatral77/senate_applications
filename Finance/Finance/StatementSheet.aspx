<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatementSheet.aspx.cs" Inherits="Finance.StatementSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script src="./Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        .saltable th {
            font-weight: lighter !important;
            border: solid thin !important;
        }

        .saltable td {
            font-weight: lighter !important;
            border: solid thin !important;
        }
    </style>
</head>
<body style="margin-left:.5in;margin-right:.5in">
    <form id="form1" runat="server">
    <div style="text-align:center;font-weight:bold;font-size:12pt;text-decoration:underline;">SENATE SECRETARIAT</div>
        <div id="headerdiv" runat="server" style="text-align:center;font-weight:bold;font-size:10pt;margin-top:10px;text-decoration:underline;"></div>
    <div id="div" runat="server" style="margin-top:10px;">
    
    </div>
        <div style="float:left;width:40%">
        <table class="table table-condensed" style="width:80%;font-size:8pt;">
            <tr>
                <td>Statement No.1 Members who have Bank Account </td><td style="text-align:right;"><asp:Label CssClass="table-data" ID="BankLabel" runat="server"></asp:Label></td>
            </tr>
              <tr>
                <td>Statement No.2 Members do not have Bank Account </td><td style="text-align:right;"><asp:Label CssClass="table-data" ID="ChequeLabel" runat="server"></asp:Label></td>
            </tr>
              <tr>
                <td style="text-align:center;font-weight:bold">Total </td><td style="text-align:right;font-weight:bold";><asp:Label CssClass="table-data" ID="TotalAmountLbl" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>

         <div style="float:left;width:50%">
        <table class="table table-condensed" style="width:100%;font-size:8pt;">
            <thead>
                <tr>
                    <th>
                        PAY ORDER
                    </th>
                     <th>
                        DEDUCTION
                    </th>
                    <th>
                        DETAILS
                    </th>
                    <th>AMOUNT</th>
                    <th>ACCOUNT OFFICER</th>
                </tr>
            </thead>
            <asp:ListView ID="LV" runat="server">
                <ItemTemplate>
            <tr>
                <td> <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                  <td><asp:Label CssClass="table-data" ID="Label1" runat="server" Text='<%#Eval("DeductionDesc")%>'></asp:Label></td>
                <td><asp:Label CssClass="table-data" ID="Label2" runat="server" Text='<%#Eval("Description")%>'></asp:Label></td>

                <td><asp:Label CssClass="table-data" ID="Label3" runat="server" Text='<%#"Rs. " + FormatAmount(Convert.ToDouble(Eval("Amount"))) + " (" + NumberToWords(Convert.ToInt32(Eval("Amount"))) + ")"%>'></asp:Label></td>
 
                <td><asp:Label CssClass="table-data" ID="Label5" runat="server"></asp:Label></td>
            </tr>
            </ItemTemplate>
            </asp:ListView>

        </table>
        </div>
   

    </form>
</body>
</html>
