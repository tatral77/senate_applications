<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionAnnualReport.aspx.cs" Inherits="QuestionManagement.QuestionAnnualReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <style type="text/css">
        .qa-header { margin: 6px 0 16px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; }
            .qa-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .qa-header p { margin: 0; font-size: 14px; color: #6b7785; }

        .qs-head-tools { display: flex; align-items: center; gap: 8px; margin-left: auto; }
        .qs-applied { font-size: 12px; font-weight: 600; padding: 5px 10px; }
        .qs-more-toggle .badge { background: #1f6fc5; margin-left: 2px; }

        .qa-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 18px; }
        .qa-toolbar { display: flex; align-items: center; flex-wrap: wrap; padding: 10px 14px; border-bottom: 1px solid #e4e9ee; }
            .qa-toolbar .btn { margin-left: 8px; }
            .qa-toolbar .qa-grow { flex: 1; }
        .qa-count { display: inline-block; background: #0c3a72; color: #fff; border-radius: 12px; padding: 1px 10px; font-weight: 700; margin-right: 8px; }
        .qa-table { margin: 0; }
            .qa-table th { background: #e8f0f9; color: #0c3a72; font-size: 12px; text-transform: uppercase; letter-spacing: .03em; white-space: nowrap; }
            .qa-table td { font-size: 13px; vertical-align: top !important; }
            .qa-table .qa-sel { width: 40px; text-align: center; }
            .qa-table .qa-sr { width: 56px; text-align: center; color: #6b7785; }
            .qa-table .qa-date { width: 130px; text-align: center; white-space: nowrap; }
            .qa-table .qa-status { width: 170px; text-align: center; }
            .qa-table .qa-subject { text-align: justify; }
            .qa-table .qa-subject a { color: #1f2d3d; }
                .qa-table .qa-subject a:hover { color: #0c3a72; text-decoration: none; }
        .qa-badge { display: inline-block; font-size: 12px; font-weight: 600; border-radius: 10px; padding: 2px 10px; background: #eef1f5; color: #3c4858; }
        .qa-empty { text-align: center; padding: 40px 10px; color: #6b7785; }
        .qa-status-card { background: #f8fafb; border: 1px solid #e4e9ee; border-left: 4px solid #1f6fb5; border-radius: 6px; padding: 14px 18px 4px; margin-bottom: 24px; }
            .qa-status-card h5 { margin: 0 0 4px; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; }
            .qa-status-card .qa-hint { font-size: 12px; color: #6b7785; margin-bottom: 10px; }
            .qa-status-card label { font-size: 13px; font-weight: 600; color: #3c4858; }
        .hit { background: #fff1a8; }
    </style>
    <script type="text/javascript">
        function clearTextBox() {
            $("#QuestionDiary, #QuestionId, #KeywordsTxt, #MemberNameTxt, #NoticeDiaryNo, #DateFromTxt, #DateToTxt, #DivisionTxt").val("");
            $("[id$=HidMemberId], [id$=HidDivisionId]").val("");
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #CategoryDDL, #GroupsDDL, #QuestionStatusDDL").each(function () { this.selectedIndex = 0; });
        }

        $(function () {
            // member search (all members)
            $("[id$=MemberNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetAllMembersByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json", type: "POST", contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var k = item.lastIndexOf('=');
                                return { label: item.substring(0, k), val: item.substring(k + 1) };
                            }));
                        },
                        error: function (r) { alert(r.responseText); }
                    });
                },
                select: function (e, i) { $("[id$=HidMemberId]").val(i.item.val); },
                minLength: 1
            });
            $("[id$=MemberNameTxt]").on('input', function () { if (!this.value) $("[id$=HidMemberId]").val(""); });

            // division search
            $("[id$=DivisionTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json", type: "POST", contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var k = item.lastIndexOf('=');
                                return { label: item.substring(0, k), val: item.substring(k + 1) };
                            }));
                        },
                        error: function (r) { alert(r.responseText); }
                    });
                },
                select: function (e, i) { $("[id$=HidDivisionId]").val(i.item.val); },
                minLength: 1
            });
            $("[id$=DivisionTxt]").on('input', function () { if (!this.value) $("[id$=HidDivisionId]").val(""); });

            // tick / untick every question
            $(document).on('change', '#qaCheckAll', function () {
                $('#<%= pnlContents.ClientID %> .qa-pick input[type=checkbox]').prop('checked', this.checked);
                updatePicked();
            });
            $(document).on('change', '.qa-pick input[type=checkbox]', updatePicked);
            updatePicked();
        });

        function pickedCount() { return $('#<%= pnlContents.ClientID %> .qa-pick input[type=checkbox]:checked').length; }
        function updatePicked() {
            var n = pickedCount();
            $('#qaPicked').text(n ? n + ' selected' : '');
        }

        // Change Status: ask before changing many questions at once
        function confirmStatusChange() {
            var n = pickedCount();
            if (!n) { alert('Please tick the questions first.'); return false; }
            var status = $('#ChangeStatusDDL option:selected').text();
            if ($('#ChangeStatusDDL').val() === '0') { alert('Please choose a status.'); return false; }
            if (!$.trim($('[id$=StatusDateTxt]').val())) { alert('Please enter the status date.'); return false; }
            return confirm('Change the status of ' + n + ' question(s) to "' + status + '"?');
        }

        // Print window: light layout with headings, filters used, record count and footer.
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var rows = panel.querySelectorAll("tbody tr").length;
            var now = new Date();
            var pad = function (n) { return n < 10 ? "0" + n : n; };
            var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            var printedOn = pad(now.getDate()) + " " + months[now.getMonth()] + " " + now.getFullYear() + ", " + pad(now.getHours()) + ":" + pad(now.getMinutes());

            var sessions = "";
            var from = $('#FromAssemblySessionDDL')[0], to = $('#ToAssemblySessionDDL')[0];
            if (from && from.selectedIndex > 0) sessions = "From session " + $(from).find('option:selected').text();
            if (to && to.selectedIndex > 0) sessions += (sessions ? " " : "") + "to session " + $(to).find('option:selected').text();
            var status = $('#QuestionStatusDDL')[0];
            var extra = (status && status.selectedIndex > 0) ? "Status: " + $(status).find('option:selected').text() : "";
            var criteria = [sessions, extra].filter(function (x) { return x; }).join(" | ");

            var css =
                "@page { size: A4; margin: 14mm 12mm 16mm 12mm; }" +
                "* { box-sizing: border-box; }" +
                "body { font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 11px; color: #1f2d3d; margin: 0; }" +
                ".rpt-head { text-align: center; padding-bottom: 8px; margin-bottom: 10px; border-bottom: 2px solid #9db7d5; }" +
                ".rpt-org { font-size: 20px; font-weight: 700; letter-spacing: .12em; color: #0c3a72; }" +
                ".rpt-dept { font-size: 13px; color: #4a5b6d; margin-top: 2px; letter-spacing: .06em; text-transform: uppercase; }" +
                ".rpt-title { font-size: 16px; font-weight: 600; margin-top: 8px; }" +
                ".rpt-note { font-size: 10.5px; color: #5b6b7c; margin-top: 3px; }" +
                ".rpt-meta { display: flex; justify-content: space-between; font-size: 11px; color: #5b6b7c; margin: 0 0 8px; }" +
                ".rpt-meta b { color: #1f2d3d; }" +
                "table { width: 100%; border-collapse: collapse; }" +
                "thead { display: table-header-group; } tr { page-break-inside: avoid; }" +
                "th { background: #e8f0f9; color: #0c3a72; font-size: 10px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; text-align: left; padding: 6px; border: 1px solid #c9d6e4; }" +
                "td { padding: 5px 6px; border: 1px solid #dde5ee; vertical-align: top; font-size: 11px; line-height: 1.4; }" +
                "tbody tr:nth-child(even) td { background: #f7f9fc; }" +
                "a { color: inherit; text-decoration: none; }" +
                ".hid, .qa-sel, .qa-pick, input, select, button, .btn { display: none !important; }" +
                ".rpt-foot { position: fixed; bottom: 0; left: 0; right: 0; display: flex; justify-content: space-between; font-size: 10px; color: #7a8a9a; border-top: 1px solid #dde5ee; padding-top: 4px; background: #fff; }" +
                "@media print { body { -webkit-print-color-adjust: exact; print-color-adjust: exact; } .rpt-body { margin-bottom: 14mm; } }";

            var html = "<!DOCTYPE html><html><head><meta charset='utf-8'><title>Question Annual Report</title><style>" + css + "</style></head><body>" +
                "<div class='rpt-head'><div class='rpt-org'>SENATE OF PAKISTAN</div><div class='rpt-dept'>Questions Branch</div>" +
                "<div class='rpt-title'>Questions &mdash; Annual Report</div>" + (criteria ? "<div class='rpt-note'>" + criteria + "</div>" : "") + "</div>" +
                "<div class='rpt-meta'><span>Total questions: <b>" + rows + "</b></span><span>Printed on: <b>" + printedOn + "</b></span></div>" +
                "<div class='rpt-body'>" + panel.innerHTML + "</div>" +
                "<div class='rpt-foot'><span>Senate of Pakistan &mdash; Questions Branch</span><span>Confidential &middot; for official use</span></div></body></html>";

            var w = window.open('', '_blank', 'height=700,width=1000');
            if (!w) { alert('Please allow pop-ups to print.'); return false; }
            w.document.open(); w.document.write(html); w.document.close(); w.focus();
            setTimeout(function () { w.print(); }, 400);
            return false;
        }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "Questions - Annual Report", fallback: PrintPanel });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="qa-header">
            <h3>Question Annual Report</h3>
            <p>Search questions, print the report, or change the status of several questions at once</p>
        </div>

        <div class="panel panel-default qs-filter">
            <div class="panel-heading">
                <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH QUESTIONS</span>
                <span class="qs-head-tools">
                    <span class="label label-info qs-applied" id="qsApplied" style="display: none"></span>
                    <button type="button" class="btn btn-default btn-sm qs-more-toggle" data-toggle="collapse" data-target="#qsMore" title="Show or hide the extra filters"><span class="glyphicon glyphicon-filter"></span> <span class="qs-more-text">More filters</span> <span class="badge qs-more-badge" style="display: none"></span></button>
                    <button type="button" class="btn btn-default btn-sm" id="qsPanelToggle" title="Show or hide the search form"><span class="glyphicon glyphicon-chevron-up"></span> <span class="qs-panel-text">Hide search</span></button>
                </span>
            </div>
            <div class="panel-body" id="qsBody">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Question Diary No." AssociatedControlID="QuestionDiary"></asp:Label>
                        <asp:TextBox ID="QuestionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Question ID" AssociatedControlID="QuestionId"></asp:Label>
                        <asp:TextBox ID="QuestionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" AssociatedControlID="KeywordsTxt"></asp:Label>
                        <asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
                    </div>
                </div>
                <div id="qsMore" class="collapse">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" AssociatedControlID="MemberNameTxt"></asp:Label>
                            <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" placeholder="Type to search members..." />
                            <asp:HiddenField ID="HidMemberId" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" AssociatedControlID="FromAssemblySessionDDL"></asp:Label>
                            <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" AssociatedControlID="ToAssemblySessionDDL"></asp:Label>
                            <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Category" AssociatedControlID="CategoryDDL"></asp:Label>
                            <asp:DropDownList ID="CategoryDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">Category</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Group" AssociatedControlID="GroupsDDL"></asp:Label>
                            <asp:DropDownList ID="GroupsDDL" ClientIDMode="Static" class="form-control" runat="server">
                                <asp:ListItem Selected="True" Value="0">Group</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Question Status" AssociatedControlID="QuestionStatusDDL"></asp:Label>
                            <asp:DropDownList ID="QuestionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                                <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="Notice Diary No" AssociatedControlID="NoticeDiaryNo"></asp:Label>
                            <asp:TextBox ID="NoticeDiaryNo" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" AssociatedControlID="DateFromTxt"></asp:Label>
                            <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" AssociatedControlID="DateToTxt"></asp:Label>
                            <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-9">
                            <label class="control-lbl-sm small-label" for="DivisionTxt">Division</label>
                            <asp:TextBox ID="DivisionTxt" runat="server" CssClass="form-control small-control" placeholder="Type to search divisions..." />
                            <asp:HiddenField ID="HidDivisionId" runat="server" />
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" AssociatedControlID="FullTextCB"></asp:Label>
                            <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="qs-actions">
                    <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                    <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
                </div>
            </div>
        </div>

        <div class="qa-card">
            <div class="qa-toolbar">
                <span class="qa-count"><asp:Literal ID="CountLit" runat="server">0</asp:Literal></span>
                <span>question(s)</span>
                <span class="text-muted" id="qaPicked" style="margin-left: 12px; font-size: 12px"></span>
                <span class="qa-grow"></span>
                <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Questions" OnClientClick="return PrintPanel();" />
                <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
            </div>
            <asp:Panel ID="pnlContents" runat="server" Style="overflow-x: auto">
                <table class="table table-hover qa-table">
                    <thead>
                        <tr>
                            <th class="qa-sel hid"><input type="checkbox" id="qaCheckAll" title="Tick all" /></th>
                            <th class="qa-sr">Sr#</th>
                            <th>Brief Subject</th>
                            <th class="qa-date">Date</th>
                            <th class="qa-status">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="qa-sel hid qa-pick">
                                        <asp:CheckBox ID="SelectCB" runat="server" />
                                        <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                                        <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                    </td>
                                    <td class="qa-sr"><%# Container.DataItemIndex + 1 %></td>
                                    <td class="qa-subject">
                                        <a href='<%# ResolveUrl(Convert.ToString(Eval("QuestionsId", "~/QuestionDetails.aspx?QuestionsId={0}"))) %>' target="_blank"><%# Preview(Convert.ToString(Eval("QuestionText"))) %></a>
                                    </td>
                                    <td class="qa-date"><%# GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %></td>
                                    <td class="qa-status"><span class="qa-badge"><%# Server.HtmlEncode(Convert.ToString(Eval("QuestionStatus"))) %></span></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="5" class="qa-empty">No questions found. Change the search and try again.</td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </asp:Panel>
        </div>

        <div class="qa-status-card">
            <h5>Change status of selected questions</h5>
            <div class="qa-hint">Tick the questions above, choose the new status and its date, then click Change Status.</div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <asp:Label ID="Label31" runat="server" Text="Question Status" AssociatedControlID="ChangeStatusDDL" />
                    <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                        <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 form-group">
                    <asp:Label ID="Label21" runat="server" Text="Status Date" AssociatedControlID="StatusDateTxt" />
                    <asp:TextBox ID="StatusDateTxt" class="form-control small-control js-date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3 form-group">
                    <label>&nbsp;</label>
                    <div>
                        <asp:Button ID="ChangeStatusBtn" runat="server" Cssclass="btn btn-custom" Text="Change Status" OnClientClick="return confirmStatusChange();" OnClick="ChangeStatusBtn_Click" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script src='<%= ResolveUrl("~/Scripts/searchpanel.js") %>' type="text/javascript"></script>
    <script type="text/javascript">QSPanel.init({ key: 'question-annual' });</script>
</asp:Content>
