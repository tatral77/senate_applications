<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeClassificationPrint.aspx.cs" Inherits="Budget.CodeClassificationPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .td-bordered
        {
            border:solid;
            border-width:thin;
            border-collapse:collapse;
            text-align:center;
            width:20px;
        }
         .td-bordered2
        {
              font-size:11pt;
            border:solid;
            border-width:thin;
            border-collapse:collapse;
            text-align:center;
         }
         .heading-td
         {
             font-size:11pt;
             padding-bottom:5px;
             width:3.2in;
         }
    </style>
</head>
    
<body style="margin-top:.5in;margin-left:.5in;margin-right:.5in">
    <form id="form1" runat="server">

    <table>
        <tr>
            <td colspan="2"><table style="border-collapse:collapse;" align="right"><tr><td class="td-bordered2">TOTAL NO. OF VOUCHERS</td><td class="td-bordered2" style="width:60px;"></td></tr></table></td>
        </tr>
        <tr>
            <td style="text-align:center"><h3>CODE CLASSIFICATION PROFORMA</h3></td>
        </tr>
        <tr>
            <td colspan="2"><u>PRE-AUDIT SECTION</u></td>
        </tr>
         
        <tr>
            <td style="border-right:solid">
                <table>
                      <tr>
                        <td>Ministry /  Division / Department</td>
                        <td style="font-size:12pt;text-decoration:underline;margin-bottom:10px;font-weight:bold;">SENATE SECRETARIAT</td>
                         
                    </tr>
                    <tr>
                        <td class="heading-td">(1) DEMAND NO:</td>
                        <td><div id="demandno" runat="server"></div></td>
                    </tr>
                      <tr>
                        <td class="heading-td">(2) VOUCHER NO:</td>
                        <td></td>
                    </tr>
                      
                     <tr>
                        <td class="heading-td">(3) VENDOR NO:</td>
                        <td><div id="vendornumber" runat="server"></div></td>
                    </tr>
                    <tr>
                        <td class="heading-td">(4) NAME OF PAYEE'S:</td>
                        <td><div id="vendor" style="text-decoration:underline" runat="server"></div></td>
                    </tr>
                      <tr>
                        <td class="heading-td">(5) BANK ACCOUNT NUMBER:</td>
                        <td><div id="bankaccount" style="text-decoration:underline" runat="server"></div></td>
                    </tr>
                      <tr>
                        <td class="heading-td">(6) BANK'S NAME & BRANCH:</td>
                        <td><div id="bank" style="text-decoration:underline" runat="server"></div></td>
                    </tr>
                    <tr>
                        <td class="heading-td">(7) COUNTER NUMBER:</td>
                        <td><table style="border-collapse:collapse;"><tr><td class="td-bordered">1</td><td style="width:20px;"></td><td class="td-bordered">P</td><td class="td-bordered">N</td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td><td class="td-bordered"></td></tr></table></td>
                    </tr>
                    <tr>
                        <td class="heading-td" style="min-width:2.5in">(8) CONTROLLING OFFICER/DDO CODE:</td>
                        <td><div id="ddo" runat="server"></div></td>
                    </tr>
                     <tr>
                        <td class="heading-td">(9) MAJOR FUNCTION:</td>
                        <td><table style="border-collapse:collapse;"><tr><td class="td-bordered">0</td><td class="td-bordered">1</td></tr></table></td>
                    </tr>
                     <tr>
                        <td class="heading-td">(10) MINOR FUNCTION:</td>
                        <td><table style="border-collapse:collapse;"><tr><td class="td-bordered">0</td><td class="td-bordered">1</td><td class="td-bordered">1</td></tr></table></td>
                    </tr>
                     <tr>
                        <td class="heading-td">(11) DETAILED FUNCTION:</td>
                        <td><table style="border-collapse:collapse;"><tr><td class="td-bordered">0</td><td class="td-bordered">1</td><td class="td-bordered">1</td><td class="td-bordered">1</td></tr></table></td>
                    </tr>
                     <tr>
                        <td class="heading-td">(12) SUB-DETAILED FUNCTION CODE:</td>
                        <td><table style="border-collapse:collapse;"><tr><td class="td-bordered">0</td><td class="td-bordered">1</td><td class="td-bordered">1</td><td class="td-bordered">1</td><td class="td-bordered">0</td><td class="td-bordered">1</td></tr></table></td>
                    </tr>
                      <tr>
                        <td class="heading-td">(13) CL CODE:</td>
                        <td><div id="clcode" runat="server"></div></td>
                    </tr>
                      <tr>
                        <td class="heading-td">(14) CN CODE:</td>
                        <td><div id="cncode" runat="server"></div></td>
                    </tr>
                     <tr>
                        <td colspan="2" class="heading-td">(15) CURRENT EXPENDITURE (MET FROM REVENUE/MET FROM CAPITAL)</td>

                    </tr>
                     <tr>
                        <td colspan="2" class="heading-td">(16) DEVELOPMENT EXPENDITURE  (MET FROM REVENUE/MET FROM CAPITAL) :</td>

                    </tr>
                     <tr>
                        <td colspan="2" class="heading-td">(17) VOTED EXPENDITURE OR CHARGED:</td>

                    </tr>
                </table>
            </td>
            <td style="vertical-align:top;text-align:center;font-size:9pt;width:1in">space for Token<br />(For use in AGPR)</td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="width:100%;border-collapse:collapse;">
                    <tr>
                        <td style="border-bottom:solid;border-top:solid;text-align:center;border-right:solid" colspan="3">PAYMENTS</td>
                         <td style="border-bottom:solid;border-top:solid;text-align:center" colspan="3">DEDUCTIONS</td>
                    </tr>
                    <tr >
                        <td style="padding-bottom:10px;">Minor Objects</td>
                        <td style="padding-bottom:10px;">Detailed Object</td>
                        <td style="border-right:solid;padding-bottom:10px">Amount</td>
                         <td style="padding-bottom:10px;">Minor Objects</td>
                        <td style="padding-bottom:10px;">Detailed Object</td>
                        <td style="padding-bottom:10px;">Amount</td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;"><div id="paymentminor" runat="server"></div></td>
                        <td style="vertical-align:top"><div id="paymentobject" runat="server"></div></td>
                        <td style="border-right:solid;vertical-align:top"><div id="paymentamount" runat="server"></div></td>
                        <td style="vertical-align: top">
                            <div id="dedminortax" runat="server"></div>
                        </td>
                        <td style="vertical-align:top"><div id="dedobjecttax" runat="server">B01187</div></td>
                        <td style="vertical-align:top"><div id="dedamounttax" runat="server"></div></td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top"></td><td style="vertical-align:top"></td><td style="vertical-align:top;border-right:solid"></td>
                        <td style="vertical-align:top"><div id="dedminorgst" runat="server"></div></td>
                        <td style="vertical-align:top"><div id="dedobjectgst" runat="server">B02341</div></td>
                        <td style="vertical-align:top"><div id="dedamountgst" runat="server"></div></td>
                            
                    </tr>
                    <tr>
                        <td style="border-top:solid;border-bottom:solid"></td><td style="border-top:solid;border-bottom:solid">Total:</td><td style="border-top:solid;border-bottom:solid"><div id="totalpayment" runat="server"></div></td>
                        <td style="border-top:solid;border-bottom:solid"></td><td style="border-top:solid;border-bottom:solid">Total:</td><td style="border-top:solid;border-bottom:solid"><div id="totaldeduction" runat="server"></div></td>
                    </tr>
                  
                </table>
            </td>
        </tr>
        <tr>
           <td style="padding-top:10px;font-weight:bold;text-align:center;"><div id="netamount" runat="server"></div></td>
        </tr>
    </table>
     
    </form>
</body>
</html>
