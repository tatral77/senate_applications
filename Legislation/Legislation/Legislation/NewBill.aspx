<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewBill.aspx.cs" Inherits="Legislation.NewBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="Scripts/jquery.mask.js"></script>
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
                NEW BILL (ORIGINATED BY SENATE)
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />
            </div>

            <div class="col-md-3 bootst">
                <label class="control-lbl-sm" for="LegislationDiaryNoTxt">File Number:</label>
                <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter Legislation Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
            </div>
             <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Notice Date:</label>
                <asp:TextBox ID="NoticedateTxt" ValidationGroup="Group1" class="form-control small-control date js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticedateTxt"></asp:RequiredFieldValidator>
            </div>

            <%--  <div class="col-md-3 bootstrap-timepicker">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Legislation Diary Time:</label>
                <asp:TextBox ID="LegislationDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryTimeTxt" runat="server" ErrorMessage="Enter Legislation Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="LegislationDiaryTimeTxt"></asp:RequiredFieldValidator>
            </div>--%>
           <%-- <div class="col-md-3">
                <label class="control-lbl-sm">Bill Diary No:</label>
                <asp:TextBox ID="BillDiaryNoTxt" class="form-control small-control" runat="server"></asp:TextBox>
            </div>--%>
        </div>

        <div class="row top-buffer">



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
            <%--  <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Originated By:</label>
                <asp:DropDownList ID="OriginatedByDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                     <asp:ListItem Value="1">Senate</asp:ListItem>
                     <asp:ListItem Value="2">National Assembly</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="OriginatedByDDL"></asp:RequiredFieldValidator>
            </div>
              <div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Concerned Committee:</label>
                <asp:DropDownList ID="CommitteeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="CommitteeDDL"></asp:RequiredFieldValidator>
            </div>--%>
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
                        $('#ContentPlaceHolder1_BillTxt').summernote(
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
                <label class="control-lbl-sm" for="SenatorDDL">Search Senator:</label>
                <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <asp:HiddenField ID="HidMemberId" ClientIDMode="Static" runat="server" />
                <asp:Label ID="err" runat="server" Text="" Style="color: red"></asp:Label>
            </div>

            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMover" runat="server" Text=">>" Style="margin-bottom: 2px;" class="btn btn-custom" OnClick="AddMover_Click" /><br />
                <asp:Button ID="DeleteMover" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMover_Click" />
            </div>

            <div class="col-md-4">

                <label class="control-lbl-sm" for="SenatorDDL">Bill Movers (Senators):</label>
                <asp:ListBox ID="MoversLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; font-size: 10pt">Notice File</asp:Label>
                <asp:FileUpload ID="NoticeUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" />
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Search Minister:</label>
                <asp:TextBox ID="MinisterNameTxt" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <asp:HiddenField ID="HidMinisterId" ClientIDMode="Static" runat="server" />
                <asp:Label ID="MinisterErr" runat="server" Text="" Style="color: red"></asp:Label>
            </div>

            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMinister" runat="server" Text=">>" Style="margin-bottom: 2px;" class="btn btn-custom" OnClick="AddMinister_Click" /><br />
                <asp:Button ID="DeleteMinister" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMinister_Click" />
            </div>

            <div class="col-md-4">

                <label class="control-lbl-sm" for="SenatorDDL">Bill Movers (Ministers):</label>
                <asp:ListBox ID="MinistersLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Search Ministry:</label>
                <asp:TextBox ID="MinistryTxt" AutoCompleteType="Disabled" runat="server" CssClass="form-control" />
                <asp:HiddenField ID="HidMinistryId" runat="server" />
                <asp:Label ID="err2" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMinistry" runat="server" Text=">>" class="btn btn-custom" Style="margin-bottom: 2px;" OnClick="AddMinistry_Click" /><br />
                <asp:Button ID="DeleteMinistry" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMinistry_Click" />
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Ministries:</label>
                <asp:ListBox ID="MinistryLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>

            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Style="font-weight: bold; font-size: 10pt">Bill File</asp:Label>
                <asp:FileUpload ID="BillUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" />
            </div>
        </div>
    </div>
    <div class="row top-buffer">
    </div>
    <div class="row top-buffer">
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
                        $('#ContentPlaceHolder1_BillTxt').summernote(
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
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">Urdu Text:</label>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

                <%--<CKEditor:CKEditorControl ID="BillTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                <textarea id="UrduTxt" name="UrduTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_UrduTxt').summernote(
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
