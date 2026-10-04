<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CompareQuestion.aspx.cs" Inherits="QuestionManagement.CompareQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        function validateCompare() {
            var txt = document.getElementById("QuestionToCompareTxt");
            if (!txt || !txt.value.trim()) {
                var hint = document.getElementById("cqHint");
                if (hint) { hint.style.display = "block"; }
                if (txt) { txt.focus(); }
                return false;
            }
            return true;
        }
        $(function () {
            $("#QuestionToCompareTxt").on("input", function () {
                var hint = document.getElementById("cqHint");
                if (hint && this.value.trim()) { hint.style.display = "none"; }
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
                "<!DOCTYPE html><html><head><meta charset='utf-8'><title>Similar Questions</title><style>" + css + "</style></head><body>" +
                "<div class='rpt-head'>" +
                "<div class='rpt-org'>SENATE OF PAKISTAN</div>" +
                "<div class='rpt-dept'>Questions Branch</div>" +
                "<div class='rpt-title'>Compare Questions &ndash; Similar Matches</div>" +
                "</div>" +
                "<div class='rpt-meta'><span>Total matches: <b>" + rows + "</b></span><span>Printed on: <b>" + printedOn + "</b></span></div>" +
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
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "Compare Questions - Similar Matches", fallback: PrintPanel });
        }
        $(function () {
            var $count = $("#cqCount");
            var refresh = function () {
                var n = $("#<%=pnlContents.ClientID %> tbody tr").not(".cq-empty-row").length;
                $count.text(n);
            };
            refresh();
            $("[id$=Button2]").on("click", function () { setTimeout(refresh, 0); });
        });
    </script>
    <style type="text/css">
        .cq-panel { border-radius: 12px; }
        .cq-panel .panel-heading { display: flex; align-items: center; gap: 10px; }
        .cq-title { font-weight: 700; letter-spacing: .5px; color: #124f96; }
        .cq-panel .panel-body { padding: 20px; }
        .cq-panel .small-label { display: block; margin-bottom: 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .cq-hint { display: none; margin-top: 6px; font-size: 12.5px; color: #a5281b; }
        textarea.cq-textarea { resize: vertical; font-size: 13.5px; line-height: 1.5; }
        .cq-actions { display: flex; gap: 8px; margin: 16px -20px -20px; padding: 14px 20px; background: #f6f8fb; border-top: 1px solid #e3e8ef; border-radius: 0 0 12px 12px; }
        .cq-toolbar { display: flex; align-items: center; flex-wrap: wrap; gap: 8px; margin: 18px 0 12px; }
        .cq-count-badge { display: inline-flex; align-items: center; background: #124f96; color: #fff; border-radius: 12px; padding: 2px 12px; font-weight: 700; font-size: 13px; margin-right: 4px; }
        .cq-subject { text-align: justify; min-width: 380px; }
        .cq-pill { display: inline-block; font-size: 11px; font-weight: 700; letter-spacing: .03em; border-radius: 10px; padding: 2px 9px; text-transform: uppercase; }
        .cq-pill-web { background: #e8f0f9; color: #0c3a72; }
        .cq-pill-mobile { background: #f1e9fb; color: #5b2d91; }
        .cq-match { display: inline-block; min-width: 46px; text-align: center; border-radius: 10px; padding: 2px 9px; font-weight: 700; font-size: 12.5px; }
        .cq-match-high { background: #dff2e6; color: #23663c; }
        .cq-match-mid { background: #fdf1d6; color: #8a5a05; }
        .cq-match-low { background: #eef1f5; color: #4b5b6e; }
        .cq-empty { text-align: center; padding: 34px 10px; color: #6b7785; }
        @media (max-width: 767px) {
            .cq-panel .panel-body { padding: 14px; }
            .cq-actions { margin: 16px -14px -14px; padding: 12px 14px; }
            .cq-actions .btn { flex: 1; }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="panel panel-default cq-panel">
        <div class="panel-heading">
            <span class="cq-title"><span class="glyphicon glyphicon-transfer"></span> COMPARE QUESTIONS</span>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Text to compare" AssociatedControlID="QuestionToCompareTxt"></asp:Label>
                    <asp:TextBox ID="QuestionToCompareTxt" ClientIDMode="Static" runat="server" TextMode="MultiLine" CssClass="form-control cq-textarea" Rows="10" placeholder="Paste or type the question text you want to check for duplicates / similar questions raised earlier..." />
                    <div class="cq-hint" id="cqHint">Please enter the question text before searching.</div>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-3">
                    <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From session" AssociatedControlID="FromAssemblySessionDDL"></asp:Label>
                    <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To session" AssociatedControlID="ToAssemblySessionDDL"></asp:Label>
                    <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Minimum match %" AssociatedControlID="PercentageToCompareDDL"></asp:Label>
                    <asp:DropDownList ID="PercentageToCompareDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="small-label">&nbsp;</label>
                    <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClientClick="return validateCompare();" OnClick="Search_Click" style="width:100%" />
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid cq-results">
        <div class="cq-toolbar">
            <span class="cq-count-badge" id="cqCount">0</span>
            <span>similar question(s) found</span>
            <span style="flex:1"></span>
            <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
            <input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        </div>
        <asp:Panel ID="pnlContents" runat="server">
            <table class="table table-hover table-striped table-responsive qs-table">
                <thead class="thead-inverse">
                    <tr>
                        <th class="m-hide">Sr#</th>
                        <th>QID</th>
                        <th class="m-hide">Q-DN</th>
                        <th class="hid m-hide">List No</th>
                        <th>Session</th>
                        <th class="m-hide">Group</th>
                        <th class="m-hide">Division</th>
                        <th>Subject Matter</th>
                        <th class="m-hide">Notice No / Date</th>
                        <th class="m-hide">Notice Time</th>
                        <th class="m-hide">Category</th>
                        <th>Submitted By</th>
                        <th class="m-hide">Status</th>
                        <th class="m-hide">Origin</th>
                        <th>Match %</th>
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
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("QuestionsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                                </td>
                                <td style="text-align: center" class="m-hide">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("QuestionDiaryNo") %>' />
                                </td>
                                <td style="text-align: center" class="hid m-hide">
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#Bind("ListId") %>' />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#Eval("Division")%>' />
                                </td>
                                <td runat="server" id="FullSearch" class="m-block cq-subject">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black; font-size: 10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionsId").ToString())%>'><%#Eval("QuestionText").ToString()%></asp:HyperLink>
                                </td>
                                <td runat="server" id="RestrictedSearch" visible="false" class="m-block cq-subject">
                                    <asp:HyperLink class="table-data" ID="HyperLink3" CssClass="printText" runat="server" Style="color: black; font-size: 10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionsId").ToString())%>'><%#Eval("QuestionText").ToString()%></asp:HyperLink>
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("QuestionCategory")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>
                                <td class="m-hide">
                                    <span class="cq-pill <%# Convert.ToInt32(Eval("DeviceId"))==1 ? "cq-pill-web" : "cq-pill-mobile" %>"><%# Convert.ToInt32(Eval("DeviceId"))==1 ? "Web" : "Mobile App" %></span>
                                    <asp:Label ID="deviceIdLabel" class="table-data" runat="server" Style="display:none" Text='<%#Convert.ToInt32(Eval("DeviceId"))%>'></asp:Label>
                                </td>
                                <td>
                                    <span class="cq-match <%# Convert.ToInt32(Eval("MatchingPercentage")) >= 80 ? "cq-match-high" : (Convert.ToInt32(Eval("MatchingPercentage")) >= 50 ? "cq-match-mid" : "cq-match-low") %>">
                                        <asp:Label ID="Label12" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("MatchingPercentage"))%>'></asp:Label>%
                                    </span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr class="cq-empty-row">
                                <td colspan="15" class="cq-empty">No similar questions found for the given text and filters.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
