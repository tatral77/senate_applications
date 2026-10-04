<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewVisitor.aspx.cs" Inherits="VisitorManagement.NewVisitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="Jquery/jquery-1.10.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                <label class="page-title">NEW VISITOR</label>
            </div>
        </div>
          <div class="row">
            <div class="col-md-12">
                <div runat="server" ID="SuccessLbl" class="alert alert-success" style="height:30px;width:100%;padding:5px !important;margin-bottom:10px;" Visible="false" >Visitor added successfully</div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Person To Visit:</label>
                <asp:TextBox ID="RequestedByTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="RequestedByTxt"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="HidRequestedById" runat="server" />
            </div>
        </div>
          <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Date Time:</label>
                <asp:TextBox ID="VisitDateTxt" ReadOnly="true" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </div>
          <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Visit Type:</label>
                <asp:DropDownList ID="VisitTypeDDL" runat="server" class="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" CssClass="text-danger" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Select visit Type" ControlToValidate="VisitTypeDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Visitor Name:</label>
                <asp:TextBox   ID="VisitorNameTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Enter Visitor Name" Display="Dynamic" ControlToValidate="VisitorNameTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
           <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Visitor CNIC:</label>
                <asp:TextBox  PlaceHolder="CNIC:" type="number" ID="CNIC" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <span runat="server" id="cnicerror" class="text-danger" visible="false">CNIC must be of 13 digits.</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Enter Name." Display="Dynamic" ControlToValidate="CNIC"></asp:RequiredFieldValidator>
            </div>
        </div>
          <div class="row">
            <div class="col-md-6">
                  <label class="control-lbl-sm" for="SessionTxt">Visit Purpose:</label>
                <asp:TextBox  PlaceHolder="PURPOSE" TextMode="MultiLine"  ID="PurposeTxt"   class="form-control small-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-6">
                <asp:Button CssClass="btn btn-primary" ID="InsertVisitor" runat="server" Text="Save Details" OnClick="InsertVisitor_Click" />
            </div>
        </div>
    </div>

    <script>
        $(function () {
            $("[id$=RequestedByTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmployeeName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
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
                    $("[id$=HidRequestedById]").val(i.item.val);
                    $("[id$=HidPostId]").val(i.item.val2);
                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=CompanyNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetCompanies") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[1],
                                    val: item.split('=')[0],
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
                    $("[id$=HidCompanyId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
</asp:Content>
