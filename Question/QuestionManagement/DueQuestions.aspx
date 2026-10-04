<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DueQuestions.aspx.cs" Inherits="QuestionManagement.DueQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <style>
        .dq-header { margin: 6px 0 16px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .dq-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .dq-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .dq-header .dq-actions { float: right; margin-top: 4px; }
            .dq-header .dq-actions .btn { margin-left: 6px; }
        .dq-rule { background: #f3f7fc; border: 1px solid #d5e2f2; border-left: 4px solid #12867f; border-radius: 6px; padding: 10px 14px; margin-bottom: 16px; font-size: 13px; color: #3c4858; }
            .dq-rule b { color: #0c3a72; }
        .dq-count { display: inline-block; background: #12867f; color: #fff; border-radius: 12px; padding: 1px 10px; font-weight: 700; margin-right: 6px; }
        .dq-table { background: #fff; }
            .dq-table th { background: #e8f0f9; color: #0c3a72; font-size: 12px; text-transform: uppercase; letter-spacing: .03em; }
            .dq-table td { font-size: 13px; vertical-align: top !important; }
            .dq-table .dq-subject a { color: #1f2d3d; }
        .dq-empty { text-align: center; padding: 40px 10px; color: #6b7785; }
    </style>
    <script type="text/javascript">
        // Print window: light layout with headings, record count and footer.
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var rows = panel.querySelectorAll("tbody tr").length;
            var now = new Date();
            var pad = function (n) { return n < 10 ? "0" + n : n; };
            var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            var printedOn = pad(now.getDate()) + " " + months[now.getMonth()] + " " + now.getFullYear() + ", " + pad(now.getHours()) + ":" + pad(now.getMinutes());
            var title = "Questions Due for the List";
            var note = document.getElementById("dqRuleText") ? document.getElementById("dqRuleText").innerText : "";

            var css =
                "@page { size: A4 landscape; margin: 14mm 10mm 16mm 10mm; }" +
                "* { box-sizing: border-box; }" +
                "body { font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 11px; color: #1f2d3d; margin: 0; }" +
                ".rpt-head { text-align: center; padding-bottom: 8px; margin-bottom: 10px; border-bottom: 2px solid #9db7d5; }" +
                ".rpt-org { font-size: 20px; font-weight: 700; letter-spacing: .12em; color: #0c3a72; }" +
                ".rpt-dept { font-size: 13px; color: #4a5b6d; margin-top: 2px; letter-spacing: .06em; text-transform: uppercase; }" +
                ".rpt-title { font-size: 16px; font-weight: 600; margin-top: 8px; }" +
                ".rpt-note { font-size: 10.5px; color: #5b6b7c; text-align: center; margin-top: 3px; }" +
                ".rpt-meta { display: flex; justify-content: space-between; font-size: 11px; color: #5b6b7c; margin: 0 0 8px; }" +
                ".rpt-meta b { color: #1f2d3d; }" +
                "table { width: 100%; border-collapse: collapse; }" +
                "thead { display: table-header-group; } tr { page-break-inside: avoid; }" +
                "th { background: #e8f0f9; color: #0c3a72; font-size: 10px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; text-align: left; padding: 6px; border: 1px solid #c9d6e4; }" +
                "td { padding: 5px 6px; border: 1px solid #dde5ee; vertical-align: top; font-size: 11px; line-height: 1.35; }" +
                "tbody tr:nth-child(even) td { background: #f7f9fc; }" +
                "a { color: inherit; text-decoration: none; }" +
                ".hid, input, select, button, .btn { display: none !important; }" +
                ".rpt-foot { position: fixed; bottom: 0; left: 0; right: 0; display: flex; justify-content: space-between; font-size: 10px; color: #7a8a9a; border-top: 1px solid #dde5ee; padding-top: 4px; background: #fff; }" +
                "@media print { body { -webkit-print-color-adjust: exact; print-color-adjust: exact; } .rpt-body { margin-bottom: 14mm; } }";

            var html = "<!DOCTYPE html><html><head><meta charset='utf-8'><title>" + title + "</title><style>" + css + "</style></head><body>" +
                "<div class='rpt-head'><div class='rpt-org'>SENATE OF PAKISTAN</div><div class='rpt-dept'>Questions Branch</div>" +
                "<div class='rpt-title'>" + title + "</div><div class='rpt-note'>" + note + "</div></div>" +
                "<div class='rpt-meta'><span>Total records: <b>" + rows + "</b></span><span>Printed on: <b>" + printedOn + "</b></span></div>" +
                "<div class='rpt-body'>" + panel.innerHTML + "</div>" +
                "<div class='rpt-foot'><span>Senate of Pakistan &mdash; Questions Branch</span><span>Confidential &middot; for official use</span></div></body></html>";

            var w = window.open('', '_blank', 'height=700,width=1100');
            if (!w) { alert('Please allow pop-ups to print.'); return false; }
            w.document.open(); w.document.write(html); w.document.close(); w.focus();
            setTimeout(function () { w.print(); }, 400);
            return false;
        }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "Questions Due for the List", fallback: PrintPanel });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="dq-header">
            <div class="dq-actions">
                <a class="btn btn-default" href="Home.aspx">&larr; Home</a>
                <button type="button" class="btn btn-primary" onclick="return PrintPanel();">Print</button>
                <button type="button" class="btn btn-primary" onclick="return ExportPdf();">Export PDF</button>
            </div>
            <h3>Questions Due for the List</h3>
            <p>Waiting time is over, but the question is still Under Process or Under Correspondence</p>
        </div>

        <div class="dq-rule">
            <span class="dq-count"><asp:Literal ID="CountLit" runat="server"></asp:Literal></span>
            <span id="dqRuleText"><asp:Literal ID="RuleLit" runat="server"></asp:Literal></span>
        </div>
        <asp:Label ID="ErrorLbl" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

        <asp:Panel ID="pnlContents" runat="server">
            <table class="table table-hover table-striped table-responsive dq-table">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>QID</th>
                        <th>Q-DN</th>
                        <th>List No</th>
                        <th>Session Number</th>
                        <th>Group</th>
                        <th>Division</th>
                        <th>Submitted By</th>
                        <th>Subject Matter</th>
                        <th>Notice No / Date</th>
                        <th>Notice Time</th>
                        <th>Category</th>
                        <th>Status</th>
                        <th>Origin</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItemIndex + 1 %></td>
                                <td><%# Eval("QuestionsId") %></td>
                                <td style="text-align: center"><%# Eval("QuestionDiaryNo") %></td>
                                <td style="text-align: center"><%# GetListNo(Convert.ToInt32(Eval("ListId")), Convert.ToString(Eval("SupNo"))) %></td>
                                <td style="text-align: center"><%# Eval("SessionNumber") %></td>
                                <td><%# Server.HtmlEncode(GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("Division"))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("MoverName"))) %></td>
                                <td class="dq-subject" style="min-width: 320px">
                                    <a href='<%# ResolveUrl(GetLink(Eval("QuestionsId").ToString())) %>' target="_blank"><%# GetMinText(Convert.ToString(Eval("QuestionText"))) %></a>
                                </td>
                                <td><%# Eval("NoticeDiaryNo") %><br /><%# GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %></td>
                                <td><%# GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime"))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("QuestionCategory"))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("QuestionStatus"))) %><br /><%# GetDate(Convert.ToDateTime(Eval("QuestionStatusDate"))) %></td>
                                <td><%# Convert.ToInt32(Eval("DeviceId")) == 1 ? "Notice Office" : "Mobile App" %></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="14" class="dq-empty">No questions are waiting for the list right now.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
