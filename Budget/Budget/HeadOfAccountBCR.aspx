<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HeadOfAccountBCR.aspx.cs" Inherits="Budget.HeadOfAccountBCR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-md-12 page-header">
                <label>Budget Control Register</label>
            </div>
            </div>

        <div class="row">
            <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" AutoPostBack="true" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
           <%-- <div class="col-md-4">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                <asp:DropDownList ID="HeadOfAccountDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="HeadOfAccountDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
              <div class="col-md-7">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                <asp:TextBox ID="HeadOfAccountTxt" class="form-control" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:TextBox>
            </div>
             <div class="col-md-2">
                 <br />
                 <asp:Button ID="Button1" runat="server" Text="Get BCR" class="btn btn-success" OnClick="Button1_Click" />
            </div>

        </div>
        
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">
                <div class="page-header"><asp:Label ID="AllottedLbl" runat="server" Text=''></asp:Label></div>
                <table class="table table-hover table-striped table-data">
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
                                <td>
                                 <td colspan="10">
                                    <asp:Label ID="DegreeObtLb" style="width:25% !important;" runat="server" Text='<%#Bind("BillDescription") %>'></asp:Label></td>
                                <td>
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
                                    <asp:Label ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("TotalAmount"))) %>'></asp:Label></td>
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
    </div>
     <script type="text/javascript">
        $(function () {
            $("[id$=HeadOfAccountTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    amount: item.split('=')[2]
                                 
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
                    $("[id$=BudgetLimitTxt]").val(i.item.amount);
                },
                minLength: 1
            });
          });
</script>
</asp:Content>