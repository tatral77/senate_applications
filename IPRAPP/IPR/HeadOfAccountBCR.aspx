<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HeadOfAccountBCR.aspx.cs" Inherits="IPR.HeadOfAccountBCR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete 
        {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
        .btn-custom
        {
          background-color:#302c2c;
          color:#ffff
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                <h4>Budget Control Register</h4>
                </div>
              </div>
        <div class="row">
            <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" AutoPostBack="true" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-7">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
              <%--  <asp:DropDownList ID="HeadOfAccountDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>--%>
                  <asp:TextBox ID="HeadOfAccountTxt" runat="server" CssClass="form-control"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="g3" ID="RequiredFieldValidator9" runat="server"   style="color:red" ControlToValidate="HeadOfAccountTxt" ErrorMessage="Please enter Head of Account" Display="Dynamic"></asp:RequiredFieldValidator>
                  <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='' />
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="GetBCRBtn" runat="server" CssClass="btn btn-custom" OnClick="GetBCRBtn_Click" ValidationGroup="g3" Text="Get BCR"/>
            </div>
             <div class="col-md-2">
                <br />
             <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print BCR" OnClientClick="return PrintPanel();" />
                 </div>
        </div>
         <asp:Panel ID="pnlContents" runat="server">
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">
                <div class="page-header"><asp:Label ID="AllottedLbl" runat="server" style="font-weight:bold;font-size:14pt;text-decoration:underline;" Text=''></asp:Label></div>
                <table class="table table-hover table-striped table-data" style="border-collapse: collapse;">
                    <thead>
                        <tr>
                          <%--  <th>Sr#</th>--%>
                            <th>Vendor / Company</th>
                            <th>Vendor Number</th>
                           <%-- <th style="width:25% !important;">Bill Detail</th>--%>
                            <th>Bill Number/Date</th>
                            <th>Total Amount</th>
                            <th>Sanction File No</th>
                            <th>Sanction Date</th>
                            <th>Cheque Number/Date</th>
                            <th>Progressive Exp</th>
                            <th>Balance</th>
                            <th>Re-Appropriated Amount</th>
                            <th>Entry Date</th>
                            <th>Branch</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="BillLV" runat="server">
                        <ItemTemplate>
                            <tr style="font-weight:bold;">
                                 <td>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                     <td>
                                    <asp:Label ID="Label13" runat="server" Text='<%#"BID. " + Eval("BillId") %>'></asp:Label></td>
                                         <td colspan="10">
                                    <asp:Label ID="DegreeObtLb" style="width:25% !important;" runat="server" Text='<%#Bind("BillDescription") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <%--<td>
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>--%>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("VendorName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("VendorNumber") %>'></asp:Label></td>
                               <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#GetFormattedText(Convert.ToString(Eval("BillNumber")),GetDate(Convert.ToDateTime(Eval("BillDate"))))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("TotalAmount")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("SanctionFileNumber") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SanctionFileDate")))%>'></asp:Label></td>
                              <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#GetFormattedText(Convert.ToString(Eval("ChequeNumber")),GetDate(Convert.ToDateTime(Eval("ChequeDate"))))%>'></asp:Label></td>
                              <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("ProgressiveExpenditure")))%>'></asp:Label></td>
                                  <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("Balance")))%>'></asp:Label></td>
                                  <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("ReAppropriationType") + " (" + FormatAmount(Convert.ToDouble(Eval("ReAppAmount"))) +")" %>'></asp:Label></td>
                                 <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EntryDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%#GetBranch(Convert.ToInt32(Eval("BranchId")))%>'></asp:Label></td>
                                    
                            </tr>

                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
             </asp:Panel>
    </div>
     <script type="text/javascript">
      
        $(function () {
            $("[id$='HeadOfAccountTxt']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/BudgetService.asmx/GetBranchHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'13'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidHeadOfAccountId]").val(i.item.val);
                },
                minLength: 1
            });
        });
           function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
                var printWindow = window.open('', '', 'height=400,width=800');
                printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
                printWindow.document.write('</head><body >');
                printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
                printWindow.document.write('<div style="font-size:16pt;text-align:center"><u>Automation Branch (BCR)</u></div><br>');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;
            }
         </script>
</asp:Content>
