<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticeBillDetails.aspx.cs" Inherits="Legislation.NoticeBillDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="CustomScripts/jquery.min.js"></script>
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
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
                NEW BILL
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Parliamentary Year:</label>
                <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session:</label>
                <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
            <div class="col-md-3 bootst">
                <label class="control-lbl-sm" for="LegislationDiaryNoTxt">File Number:</label>
                <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter Legislation Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row top-buffer">


            <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Notice Date:</label>
                <asp:TextBox ID="NoticedateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticedateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="BillCategoryDDL">Bill Category:</label>
                <asp:DropDownList ID="BillCategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillCategoryDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="BillTypeDDL">Bill Type:</label>
                <asp:DropDownList ID="BillTypeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillTypeDDL"></asp:RequiredFieldValidator>
            </div>
              <div class="col-md-1">
                  <br />
                   <label class="control-lbl-sm" for="BillTypeDDL">Notice:</label>
                    <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                </div>
              <div class="col-md-1">
                  <br />
                   <label class="control-lbl-sm" for="BillTypeDDL">Bill:</label>
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                </div>
                <div class="col-md-1">
                      <br />
                    <asp:Button ID="UpdateQuestionBtn" runat="server" Text="Update" OnClick="Button1_Click" CssClass="btn btn-custom" />
                </div>

        </div>
       
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">Bill Title:</label>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <%--<CKEditor:CKEditorControl ID="BillTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                <textarea id="BillTitleTxt" name="BillTitleTxt" style="height: 70px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_BillTitleTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="BillTitleTxt"></asp:RequiredFieldValidator>

                <%--<textarea id="BillTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
        </div>
        <div class="row top-buffer">


            <div class="col-md-4">

                <label class="control-lbl-sm" for="SenatorDDL">Bill Movers (Senators):</label>
                <asp:Label ID="MoversLB" runat="server" class="form-control" Text=""></asp:Label>
                <asp:HiddenField runat="server" ID="HidMovers" Value="" />
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
        </div>
    </div>
    <br />
    <div class="container">
    </div>
    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">English Text:</label>
            </div>

        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <%--<CKEditor:CKEditorControl ID="BillTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                <textarea id="SubjectTxt" name="BillTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_SubjectTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="rfvBillTxt" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="SubjectTxt"></asp:RequiredFieldValidator>

                <%--<textarea id="BillTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
        </div>

    </div>


    <br />
    <div class="container">
        <div class="col-md-12" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            <%-- <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" CssClass="btn btn-custom" OnClick="PrintBtn_Click" />--%>
        </div>
    </div>

    <br />



    <script type="text/javascript">

        //$('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
        //    template: false,
        //    showInputs: false,
        //    defaultTime: false,
        //    minuteStep: 5
        //});



        //$(document).ready(function () {
        //    $('.date').mask('00/00/0000');
        //});
        $(function () {
            $(".datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 99999999999999);
                    }, 0);
                },
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: 0,
                onSelect: function (dateText, inst) { }
            });
        });

        $(function () {
            $("[id$=MinistryTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>',
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
                    $("[id$=HidMinistryId]").val(i.item.val);
                    $("[id$=NoOfBillsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');


                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=MemberNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
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
                    $("[id$=HidMemberId]").val(i.item.val);
                },
                minLength: 2
            });
        });

        $(function () {
            $("[id$=MinisterNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetMinisters") %>',
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
                    $("[id$=HidMinisterId]").val(i.item.val);
                },
                minLength: 2
            });
        });



    </script>
</asp:Content>
