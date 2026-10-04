<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HOAReappropriationDetails.aspx.cs" Inherits="Budget.HOAReappropriationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style type="text/css">
        .textboxline {
            border: none;
            border-bottom: solid thin;
            font-size: 15px;
            border-bottom-color: #000;
            height: 30px;
            background-color: #fff;
            color: #000;
            font-size: 11pt;
            border-radius: unset;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
          <div class="row">
            <div class="col-md-11 page-header">
                <label>Re-Appropriation Details</label>
            </div>
            </div>
        <div class="row">
            <div class="col-md-3">
                <label style="font-size: small; font-weight: bold">FinancialY Year</label>
                <asp:DropDownList ID="FinancialYearDDL" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label style="font-size: small; font-weight: bold">Head of Account</label>
                <asp:TextBox CssClass="form-control hoafrom " ID="HOATxt" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='' />
            </div>
            <div class="col-md-5">
                <br />
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Get Details" class="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px">
            <div class="col-md-11">
                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Head of Account From</th>
                            <th>Head of Account To</th>
                            <th>Amount</th>
                            <th>Date</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="ReappLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("FromHeadOfAccount")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("ToHeadOfAccount") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("Amount") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ReApprpriationDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id$='HOATxt']").autocomplete({
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
        $(function () {
            $("[id$=VendorNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetBranchVendorByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'" + $('#ContentPlaceHolder1_BranchDDL').val() + "'}",
                        // data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2]
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
                    $("[id$=HidVendorId]").val(i.item.val);
                    $("[id$=VendorNumberTxt]").val(i.item.val2);
                },
                minLength: 1
            });
        });
    </script>
</asp:Content>
