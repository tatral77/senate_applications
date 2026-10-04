<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NoticeQuestions.aspx.cs" Inherits="QuestionManagement.NoticeQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .nq-header { margin: 6px 0 16px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .nq-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .nq-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .nq-header .nq-actions { float: right; margin-top: 4px; }
            .nq-header .nq-actions .btn { margin-left: 6px; }

        .nq-toolbar { display: flex; align-items: center; flex-wrap: wrap; margin-bottom: 14px; }
        .nq-chips { display: flex; flex-wrap: wrap; margin-right: 16px; }
        .nq-chip { border: 1px solid #d5dde5; background: #fff; color: #3c4858; border-radius: 18px; padding: 5px 14px; margin: 0 8px 6px 0; font-size: 13px; cursor: pointer; }
            .nq-chip b { margin-left: 4px; }
            .nq-chip:hover { background: #f3f6f8; }
            .nq-chip.active { background: #0c3a72; border-color: #0c3a72; color: #fff; }
            .nq-chip.new b { color: #c0392b; } .nq-chip.opened b { color: #2e7d4f; }
            .nq-chip.active b { color: #fff; }
        .nq-search { margin-left: auto; min-width: 260px; }
            .nq-search input { width: 100%; }

        .nq-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); overflow-x: auto; }
        .nq-table { margin: 0; }
            .nq-table th { background: #e8f0f9; color: #0c3a72; font-size: 12px; text-transform: uppercase; letter-spacing: .03em; white-space: nowrap; }
            .nq-table td { font-size: 13px; vertical-align: top !important; }
            .nq-table tr.is-new td:first-child { box-shadow: inset 4px 0 0 #c0392b; }
            .nq-table tr.is-opened td:first-child { box-shadow: inset 4px 0 0 #2e8b57; }
        .nq-badge { display: inline-block; font-size: 11px; font-weight: 700; border-radius: 10px; padding: 1px 9px; text-transform: uppercase; letter-spacing: .04em; }
            .nq-badge.new { background: #fbe4e1; color: #b02a1c; }
            .nq-badge.opened { background: #dff2e6; color: #23663c; }
        .nq-subject a { color: #1f2d3d; }
            .nq-subject a:hover { color: #0c3a72; text-decoration: none; }
        .nq-nofile { color: #6b7785; font-style: italic; }
        .nq-clip { color: #1f6fb5; margin-right: 4px; }
        .nq-empty { text-align: center; padding: 40px 10px; color: #6b7785; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="nq-header">
            <div class="nq-actions">
                <asp:Button ID="RevivedQuestions" runat="server" Text="Revived Questions" class="btn btn-default" OnClick="RevivedQuestions_Click" />
                <asp:Button ID="DuplicateQuestions" runat="server" Text="Duplicate Questions" class="btn btn-default" OnClick="DuplicateQuestions_Click" />
            </div>
            <h3>Questions from Notice Office</h3>
            <p>Session <asp:Literal ID="SessionLit" runat="server"></asp:Literal> &middot; open a question to type its text, check for similar questions and assign it</p>
        </div>

        <div class="nq-toolbar">
            <div class="nq-chips">
                <button type="button" class="nq-chip active" data-filter="all">All <b><asp:Literal ID="TotalLit" runat="server">0</asp:Literal></b></button>
                <button type="button" class="nq-chip new" data-filter="new">New <b><asp:Literal ID="NewLit" runat="server">0</asp:Literal></b></button>
                <button type="button" class="nq-chip opened" data-filter="opened">Opened <b><asp:Literal ID="OpenedLit" runat="server">0</asp:Literal></b></button>
            </div>
            <div class="nq-search">
                <input type="text" id="nqSearch" class="form-control" placeholder="Search diary no, member, category, text..." autocomplete="off" />
            </div>
        </div>

        <div class="nq-card">
            <table class="table table-hover nq-table" id="nqTable">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Notice Diary Number</th>
                        <th>Session Number</th>
                        <th>Subject Matter</th>
                        <th>Notice Date</th>
                        <th>Notice Time</th>
                        <th>Category</th>
                        <th>Submitted By</th>
                        <th>Origin</th>
                        <th>State</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <tr class='<%# IsNew(Convert.ToInt32(Eval("Checked"))) ? "is-new" : "is-opened" %>' data-state='<%# IsNew(Convert.ToInt32(Eval("Checked"))) ? "new" : "opened" %>'>
                                <td><%# Container.DataItemIndex + 1 %></td>
                                <td><a href='<%# ResolveUrl(Convert.ToString(Eval("QuestionsId", "~/NoticeQuestionDetails.aspx?QuestionsId={0}"))) %>' target="_blank"><b><%# Eval("QuestionsId") %></b></a></td>
                                <td style="text-align: center"><%# Eval("SessionNumber") %></td>
                                <td class="nq-subject" style="min-width: 340px">
                                    <%# Preview(Convert.ToString(Eval("QuestionText")), Convert.ToString(Eval("QuestionFile")), Convert.ToInt32(Eval("QuestionsId"))) %>
                                </td>
                                <td><%# GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %></td>
                                <td><%# GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime"))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("QuestionCategory"))) %></td>
                                <td><%# Server.HtmlEncode(Convert.ToString(Eval("MoverName"))) %></td>
                                <td><%# Convert.ToInt32(Eval("DeviceId")) == 1 ? "Notice Office" : "Mobile App" %></td>
                                <td><span class='nq-badge <%# IsNew(Convert.ToInt32(Eval("Checked"))) ? "new" : "opened" %>'><%# IsNew(Convert.ToInt32(Eval("Checked"))) ? "New" : "Opened" %></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tbody>
            </table>
            <div class="nq-empty" id="nqEmpty" style="display: none">No questions match.</div>
        </div>

    </div>

    <script type="text/javascript">
        (function () {
            var filter = 'all';
            var $rows = $('#nqTable tbody tr');

            function apply() {
                var q = $.trim($('#nqSearch').val()).toLowerCase(), shown = 0;
                $rows.each(function () {
                    var $r = $(this);
                    var okState = filter === 'all' || $r.data('state') === filter;
                    var okText = !q || $r.text().toLowerCase().indexOf(q) !== -1;
                    var show = okState && okText;
                    $r.toggle(show);
                    if (show) shown++;
                });
                $('#nqEmpty').toggle($rows.length > 0 && shown === 0);
            }

            $('.nq-chip').on('click', function () {
                $('.nq-chip').removeClass('active');
                $(this).addClass('active');
                filter = $(this).data('filter');
                apply();
            });
            $('#nqSearch').on('input', apply);
            $('.nq-chip').on('mousedown', function (e) { e.preventDefault(); });   // keep the search box focus
            if (!$rows.length) {
                $('#nqEmpty').text('No questions have been received from the Notice Office in this session.').show();
            }
        })();
    </script>
</asp:Content>
