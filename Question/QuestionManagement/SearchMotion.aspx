<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="SearchMotion.aspx.cs" Inherits="QuestionManagement.SearchMotion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function clearTextBox() {
            $("#MotionDiary").val("");
            $("#MotionId").val("");
            $("#KeywordsTxt").val("");
            $("#MemberNameTxt").val("");
            $("#HidMemberId").val("");
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #MotionTypeDDL, #MotionStatusDDL").each(function () { this.selectedIndex = 0; });
            $("#NoticeDiaryNo").val("");
            $("#DateFromTxt").val("");
            $("#DateToTxt").val("");
            $("[id$=FullTextCB]").prop("checked", false);
        }
    </script>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $(this).on("hide.bs.collapse", function () {
                $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-down"></span>');
            });
            $(this).on("show.bs.collapse", function () {
                $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-up"></span>');
            });
        });
        $(function () {
            $("[id$=MemberNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetAllMembersByName") %>',
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
                minLength: 1
            });
        });
        // Builds the print window: light, professional layout with headings, record count and page footer.
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var rows = panel.querySelectorAll("tbody tr").length;
            var now = new Date();
            var pad = function (n) { return n < 10 ? "0" + n : n; };
            var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            var printedOn = pad(now.getDate()) + " " + months[now.getMonth()] + " " + now.getFullYear() +
                ", " + pad(now.getHours()) + ":" + pad(now.getMinutes());

            var css =
                "@page { size: A4 landscape; margin: 14mm 10mm 16mm 10mm; }" +
                "* { box-sizing: border-box; }" +
                "body { font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 11px; color: #1f2d3d; margin: 0; }" +
                ".rpt-head { text-align: center; padding-bottom: 8px; margin-bottom: 10px; border-bottom: 2px solid #9db7d5; }" +
                ".rpt-org { font-size: 20px; font-weight: 700; letter-spacing: .12em; color: #0c3a72; }" +
                ".rpt-dept { font-size: 13px; color: #4a5b6d; margin-top: 2px; letter-spacing: .06em; text-transform: uppercase; }" +
                ".rpt-title { font-size: 16px; font-weight: 600; margin-top: 8px; color: #1f2d3d; }" +
                ".rpt-meta { display: flex; justify-content: space-between; font-size: 11px; color: #5b6b7c; margin: 0 0 8px; }" +
                ".rpt-meta b { color: #1f2d3d; }" +
                "table { width: 100%; border-collapse: collapse; table-layout: auto; }" +
                "thead { display: table-header-group; }" +
                "tr { page-break-inside: avoid; }" +
                "th { background: #e8f0f9; color: #0c3a72; font-size: 10px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; text-align: left; padding: 6px 6px; border: 1px solid #c9d6e4; vertical-align: middle; }" +
                "td { padding: 5px 6px; border: 1px solid #dde5ee; vertical-align: top; font-size: 11px; line-height: 1.35; }" +
                "tbody tr:nth-child(even) td { background: #f7f9fc; }" +
                "a { color: inherit; text-decoration: none; }" +
                ".hid, input, select, button, .btn { display: none !important; }" +
                ".rpt-foot { position: fixed; bottom: 0; left: 0; right: 0; display: flex; justify-content: space-between; font-size: 10px; color: #7a8a9a; border-top: 1px solid #dde5ee; padding-top: 4px; background: #fff; }" +
                "@media print { body { -webkit-print-color-adjust: exact; print-color-adjust: exact; } .rpt-body { margin-bottom: 14mm; } }";

            var html =
                "<!DOCTYPE html><html><head><meta charset='utf-8'><title>List of Motions</title><style>" + css + "</style></head><body>" +
                "<div class='rpt-head'>" +
                "<div class='rpt-org'>SENATE OF PAKISTAN</div>" +
                "<div class='rpt-dept'>Questions Branch</div>" +
                "<div class='rpt-title'>List of Motions</div>" +
                "</div>" +
                "<div class='rpt-meta'><span>Total records: <b>" + rows + "</b></span><span>Printed on: <b>" + printedOn + "</b></span></div>" +
                "<div class='rpt-body'>" + panel.innerHTML + "</div>" +
                "<div class='rpt-foot'><span>Senate of Pakistan &mdash; Questions Branch</span><span>Confidential &middot; for official use</span></div>" +
                "</body></html>";

            var printWindow = window.open('', '_blank', 'height=700,width=1100');
            if (!printWindow) { alert('Please allow pop-ups to print.'); return false; }
            printWindow.document.open();
            printWindow.document.write(html);
            printWindow.document.close();
            printWindow.focus();
            setTimeout(function () { printWindow.print(); }, 400);
            return false;
        }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "List of Motions", fallback: PrintPanel });
        }
    </script>
    <style type="text/css">
        .qs-filter { border-radius: 12px; }
        .qs-filter .panel-heading { display: flex; align-items: center; justify-content: space-between; gap: 10px; }
        .qs-title { font-weight: 700; letter-spacing: .5px; color: #124f96; }
        .qs-filter .panel-body { padding: 18px 20px 0; }
        .qs-filter .row { margin-bottom: 12px; }
        .qs-filter .small-label { display: block; text-align: left; margin-bottom: 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .qs-filter .form-control { width: 100%; }
        .qs-actions { display: flex; gap: 8px; margin: 4px -20px 0; padding: 14px 20px; background: #f6f8fb; border-top: 1px solid #e3e8ef; border-radius: 0 0 12px 12px; }
        .qs-toolbar { display: flex; flex-wrap: wrap; gap: 8px; margin: 4px 0 14px; }
        .qs-toolbar .btn { margin: 0; }
        .qs-bulk { margin: 14px 0 0; padding: 14px 16px 10px; background: #f6f8fb; border: 1px solid #e3e8ef; border-radius: 12px; }
        .qs-bulk .btn { margin-top: 0; }
        .qs-bulk .small-label { display: block; margin-bottom: 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .qs-subject { text-align: justify; min-width: 400px; }
        .qs-head-tools { display: flex; align-items: center; gap: 8px; margin-left: auto; }
        @media (max-width: 767px) {
            .qs-filter .panel-body { padding: 14px 14px 0; }
            .qs-actions { margin: 4px -14px 0; padding: 12px 14px; }
            .qs-actions .btn { flex: 1; }
            .qs-filter [class*="col-"] { margin-bottom: 10px; }
            .qs-toolbar .btn { flex: 1 1 45%; }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH MOTION</span>
            <span class="qs-head-tools">
                <button type="button" class="btn btn-default btn-sm" id="qsPanelToggle" title="Show or hide the search form"><span class="glyphicon glyphicon-chevron-up"></span> <span class="qs-panel-text">Hide search</span></button>
            </span>
        </div>
        <div class="panel-body" id="qsBody">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Motion Diary No." for="MotionDiary"></asp:Label>
                <asp:TextBox ID="MotionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Motion ID" for="MotionId"></asp:Label>
                <asp:TextBox ID="MotionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" for="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Motion Type" for="MotionTypeDDL"></asp:Label>
                <asp:DropDownList ID="MotionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Motion Type</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Motion Status" for="MotionStatusDDL"></asp:Label>
                <asp:DropDownList ID="MotionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="Notice Diary No" for="NoticeDiaryNo"></asp:Label>
                <asp:TextBox ID="NoticeDiaryNo" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off"></asp:TextBox>
            </div>
            <div class="col-md-2" style="margin-top: 5px;">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>
        </div>
        </div>
        <div class="qs-actions">
            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
            <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
        </div>
    </div>
    <div class="container-fluid qs-results">
        <div class="clearfix"></div>
        <div class="qs-toolbar">
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Motions" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Motion Annual Report" NavigateUrl="~/MotionAnnualReport.aspx" />
        </div>
        <asp:Panel ID="pnlContents" runat="server">
            <table class="table table-hover table-striped table-responsive qs-table">
                <thead class="thead-inverse">
                    <tr>
                        <th class="m-hide">Sr#</th>
                        <th>MID</th>
                        <th style="text-align: center" class="m-hide">Select
              <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
                        </th>
                        <th class="m-hide">M-DN</th>
                        <th>Session Number</th>
                        <th class="m-hide">Motion Type</th>
                        <th>Subject Matter</th>
                        <th class="m-hide">Notice No./Date</th>
                        <th class="m-hide">Motion Status</th>
                        <th style="width: 150px;">Movers</th>
                        <th class="hid m-hide">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="m-hide">
                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Eval("MotionsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Eval("MotionsId")%>' />
                                </td>
                                <td style="text-align: center" class="m-hide">
                                    <asp:CheckBox ID="SelectCB" runat="server"> </asp:CheckBox>
                                </td>
                                <td style="text-align: center" class="m-hide">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Eval("MotionDiaryNo")%>' />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("SessionDesc")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("MotionType")%>' />
                                </td>
                                <td class="m-block qs-subject">
                                    <asp:HyperLink CssClass="printText table-data" ID="HyperLink1" runat="server" style="color: black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/MotionDetail.aspx?MotionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("MotionStatus")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                                </td>
                                <td class="hid m-hide">
                                    <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" Cssclass="btn btn-custom" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
        <div class="row qs-bulk">
            <div class="col-md-3"></div>
            <div class="col-md-4">
                <asp:Label ID="Label31" runat="server" Text="Motion Status" for="ChangeStatusDDL" CssClass="small-label" />
                <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" ValidationGroup="StatusGroup" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="StatusGroup" Display="None" InitialValue="0" ControlToValidate="ChangeStatusDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21" runat="server" Text="Status Date" for="StatusDateTxt" CssClass="small-label" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off" ValidationGroup="StatusGroup" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="StatusGroup" Display="None" ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" CssClass="btn btn-custom" Text="Change Status" OnClick="ChangeStatusBtn_Click" ValidationGroup="StatusGroup" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var opts = { dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true, showAnim: 'fadeIn' };
            var $from = $('#DateFromTxt');
            var $to = $('#DateToTxt');
            $('.datepicker').not($from).not($to).datepicker(opts);
            $from.datepicker($.extend({}, opts, { onClose: function (d) { $to.datepicker('option', 'minDate', d || null); } }));
            $to.datepicker($.extend({}, opts, { onClose: function (d) { $from.datepicker('option', 'maxDate', d || null); } }));
        });
    </script>
    <script src='<%= ResolveUrl("~/Scripts/searchpanel.js") %>' type="text/javascript"></script>
    <script type="text/javascript">QSPanel.init({ key: 'motion' });</script>
</asp:Content>
