<%@ Page Title="" Language="C#" MasterPageFile="~/OutgoingVisits.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ManageVisitDA.aspx.cs" Inherits="IPR.ManageVisitDA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
              <div class="col-md-9 page-header">
                <label id="Label2" runat="server">Miscellaneous Expenditure ( in PKR )</label>
                  <asp:TextBox ID="CashTxt" runat="server" style="width:300px" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="col-md-3 page-header" >
                <label id="Label8" runat="server" >1 Dollar equals to ( PKR ) </label>
                  <asp:TextBox ID="DollarRateTxt" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>

        </div>
        <div class="row">
            <div class="col-md-6">

                     <label id="Label3" runat="server" class="page-header">Daily Allowance ( in US Dollar )</label>
                    <label id="TotalDADollarsLbl" runat="server" class="page-header">0.0</label>
            </div>
             <div class="col-md-6">

                     <label id="Label10" runat="server" class="page-header">Daily Allowance ( in PKR )</label>
                    <label id="TotalDARupeesLbl" runat="server" class="page-header">0.0</label>
            </div>
             
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Name</th>
                        <th>Category</th>
                        <th>Status</th>
                        <th>Status Date</th>
                        <th>Remarks</th>
                    </tr>
                    <asp:ListView ID="CompositionLV" runat="server">
                        <ItemTemplate>
                            <tr style="background-color:#000;color:#fff">
                                <asp:HiddenField ID="HidCompositionId" runat="server" Value='<%#Bind("CompositionId")%>' />
                                <asp:HiddenField ID="arr" runat="server" Value='1' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" style="font-weight:bold" Text='<%#Bind("VisitorName")%>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("CategoryName")%>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("VisitorStatus")%>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Convert.ToDateTime(Eval("VisitorStatusDate")).ToShortDateString()%>'></asp:Label>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table class="table">
                                        <tr>
                                            <td style="width:25%">
                                                <label>Arrangement Type</label>
                                                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ArrangementDDL" runat="server" OnSelectedIndexChanged="ArrangementDDL_SelectedIndexChanged" >
                                                    <asp:ListItem Value="1">Own Arrangement</asp:ListItem>
                                                    <asp:ListItem Value="2">State Guest</asp:ListItem>
                                                     <asp:ListItem Value="3">Partial Arrangement</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width:25%">
                                                <div id="facilitydiv" runat="server">
                                                <label>Facility Offered</label>
                                                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="FacilityDDL" runat="server" OnSelectedIndexChanged="FacilityDDL__SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Board / Lodge</asp:ListItem>
                                                    <asp:ListItem  Value="2">Board / Lodging / Cash Payment</asp:ListItem>
                                                    <asp:ListItem  Value="3">Only Furnished Accommodation</asp:ListItem>
                                                    <asp:ListItem  Value="4">Cash Payment/ Lodging/ No Boarding</asp:ListItem>
                                                    <asp:ListItem  Value="5">Cash Payment / Board / No Lodging</asp:ListItem>
                                                    <asp:ListItem  Value="6">No Board / No Lodging / No Cash</asp:ListItem>
                                                    <asp:ListItem  Value="7">Cash Payment Only </asp:ListItem>
                                                    <asp:ListItem  Value="18">Free Transport</asp:ListItem>
                                                </asp:DropDownList>
                                                    </div>
                                            </td>
                                            <td style="width:25%">
                                                  <div id="Div1" runat="server">
                                                <label>Cash</label>
                                               <asp:TextBox ID="CashTxt" runat="server" CssClass="form-control"></asp:TextBox>
                                                      </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
        <div class="row">
              <div class="col-md-12">
                  <asp:Button ID="SaveDADetails" runat="server" Text="Save" OnClick="SaveDADetails_Click" CssClass="btn btn-success" />
              </div>
            </div>

    </div>
    <script type="text/javascript">
        $(function () {
            $("[id$=VisitorNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmployeeByName") %>',
                        //data: "{ 'prefix': '" + request.term + "','type': '" + document.getElementById("ContentPlaceHolder1_EmpMenues_CompositionLV_VisitorTypeDDL").value + "'}",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2],
                                    val3: item.split('=')[3]
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
                    $("[id$=HidSystemUserId]").val(i.item.val);
                    $("[id$=HidCategoryId]").val(i.item.val2);
                    $("[id$=CategoryTxt]").val('CATEGORY-' + i.item.val2);
                    $("[id$=HidIsEmployee]").val(i.item.val3);
                },
                minLength: 1
            });
        });
    </script>
</asp:Content>
