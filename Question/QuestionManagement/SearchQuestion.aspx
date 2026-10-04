<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchQuestion.aspx.cs" Inherits="QuestionManagement.SearchQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function clearTextBox() {
            $("#QuestionDiary").val("");
            $("#QuestionId").val("");
            $("#NoticeDiaryNo").val("");
            $("#KeywordsTxt").val("");
            if (window.QMSMembers) { window.QMSMembers.clear(); }
            $("[id$=DivisionTxt]").val("");
            $("[id$=HidDivisionId]").val("");
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #CategoryDDL, #GroupsDDL, #QuestionStatusDDL, #GenderDDL, #ReligionDDL, #NotReligionDDL, #FileStatusDDl, #CoallitionDDL").each(function () { this.selectedIndex = 0; });
            $("#DateFromTxt").val("");
            $("#DateToTxt").val("");
            $("[id$=FullTextCB], [id$=ExactMatchCB]").prop("checked", false);
        }
    </script>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script>
        $(function () {
            var $ids = $("[id$=HidMemberId]");
            var $names = $("#MemberNameTxt");
            var $chips = $("#memberChips");
            var $input = $("#memberSearch");
            var $box = $("#memberBox");
            var members = [];

            function load() {
                members = [];
                var ids = $.grep(($ids.val() || "").split(","), function (s) { return /^\d+$/.test($.trim(s)); });
                var names = ($names.val() || "").split("|");
                for (var i = 0; i < ids.length; i++) {
                    members.push({ id: $.trim(ids[i]), name: $.trim(names[i] || ("Member " + ids[i])) });
                }
            }
            function save() {
                $ids.val($.map(members, function (m) { return m.id; }).join(","));
                $names.val($.map(members, function (m) { return m.name; }).join("|"));
            }
            function has(id) {
                for (var i = 0; i < members.length; i++) { if (members[i].id === String(id)) { return true; } }
                return false;
            }
            function render() {
                $chips.empty();
                $.each(members, function (i, m) {
                    var chip = $('<span class="member-chip"></span>').text(m.name);
                    $('<button type="button" class="member-chip-x" title="Remove">&times;</button>').data("id", m.id).appendTo(chip);
                    $chips.append(chip);
                });
                $input.attr("placeholder", members.length ? "Add another member..." : "Type a member name to add...");
            }
            function add(id, name) {
                if (!has(id)) { members.push({ id: String(id), name: name }); save(); render(); }
                $input.val("");
            }
            function removeId(id) {
                members = $.grep(members, function (m) { return m.id !== String(id); });
                save();
                render();
            }

            $chips.on("click", ".member-chip-x", function () { removeId($(this).data("id")); $input.focus(); });
            $box.on("click", function (e) { if (!$(e.target).is("button")) { $input.focus(); } });
            $input.on("focus", function () { $box.addClass("focus"); }).on("blur", function () { $box.removeClass("focus"); });
            $input.on("keydown", function (e) {
                if (e.which === 13) { e.preventDefault(); }
                if (e.which === 8 && !$input.val() && members.length) { members.pop(); save(); render(); }
            });
            $input.autocomplete({
                minLength: 1,
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetAllMembersByName") %>',
                        data: JSON.stringify({ prefix: request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var list = [];
                            $.each(data.d, function (i, item) {
                                var parts = item.split('=');
                                var id = parts[parts.length - 1];
                                var label = parts.slice(0, parts.length - 1).join('=');
                                if (!has(id)) { list.push({ label: label, value: label, val: id }); }
                            });
                            response(list);
                        },
                        error: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                focus: function () { return false; },
                select: function (event, ui) {
                    add(ui.item.val, ui.item.label);
                    return false;
                }
            });

            load();
            render();
            window.QMSMembers = { clear: function () { members = []; save(); render(); $input.val(""); } };
        });
        jQuery(document).ready(function () {
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
            });
        });
        $(document).ready(function () {
            $(this).on("hide.bs.collapse", function () {
                $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-down"></span>');
            });
            $(this).on("show.bs.collapse", function () {
                $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-up"></span>');
            });
        });
      <%--  $(function () {
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
        });--%>
        jQuery(document).ready(function () {
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
            });
        });
        $(function () {
            $("[id$=DivisionTxt]").autocomplete({
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
                    $("[id$=HidDivisionId]").val(i.item.val);
                    // $("[id$=NoOfQuestionsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');
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
                "<!DOCTYPE html><html><head><meta charset='utf-8'><title>List of Questions</title><style>" + css + "</style></head><body>" +
                "<div class='rpt-head'>" +
                "<div class='rpt-org'>SENATE OF PAKISTAN</div>" +
                "<div class='rpt-dept'>Questions Branch</div>" +
                "<div class='rpt-title'>List of Questions</div>" +
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
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "List of Questions", fallback: PrintPanel });
        }
    </script>
    <style type="text/css">
        .qs-filter { border-radius: 12px; }
        .qs-filter .panel-heading { display: flex; align-items: center; justify-content: space-between; gap: 10px; }
        .qs-title { font-weight: 700; letter-spacing: .5px; color: #124f96; }
        .qs-filter .panel-body { padding: 18px 20px 0; }
        .qs-filter .row { margin-bottom: 12px; }
        .qs-filter .small-label, .qs-filter .control-lbl-sm, .qs-bulk .small-label { display: block; text-align: left; margin-bottom: 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .qs-filter .form-control { width: 100%; }
        .qs-filter textarea.form-control { height: 36px; resize: vertical; }
        .qs-actions { display: flex; gap: 8px; margin: 4px -20px 0; padding: 14px 20px; background: #f6f8fb; border-top: 1px solid #e3e8ef; border-radius: 0 0 12px 12px; }
        .qs-toolbar { display: flex; flex-wrap: wrap; gap: 8px; margin: 4px 0 14px; }
        .qs-toolbar .btn { margin: 0; }
        .qs-bulk { margin: 14px 0 0; padding: 14px 16px 10px; background: #f6f8fb; border: 1px solid #e3e8ef; border-radius: 12px; }
        .qs-bulk .btn { margin-top: 0; }
        .qs-subject { text-align: justify; min-width: 400px; }
        .member-multi { height: auto; min-height: 36px; display: flex; flex-wrap: wrap; align-items: center; gap: 4px; padding: 3px 8px; cursor: text; }
        .member-multi.focus { border-color: #1f6fc5; box-shadow: 0 0 0 3px rgba(31, 111, 197, .20); }
        .member-multi #memberChips { display: contents; }
        .member-chip { display: inline-flex; align-items: center; gap: 2px; padding: 2px 4px 2px 10px; border-radius: 999px; background: #e8f2fd; color: #124f96; font-size: 12.5px; font-weight: 600; }
        .member-chip-x { width: 18px; height: 18px; padding: 0; border: 0; border-radius: 50%; background: transparent; color: #124f96; font-size: 16px; line-height: 1; cursor: pointer; }
        .member-chip-x:hover { background: #c9def5; }
        .member-multi .member-input { flex: 1 1 150px; min-width: 120px; height: 28px; min-height: 0 !important; padding: 2px 4px; border: 0 !important; box-shadow: none !important; outline: 0; background: transparent; font-size: 14px; }
        .ui-autocomplete { max-height: 260px; overflow-y: auto; overflow-x: hidden; z-index: 1100; }
        .qs-head-tools { display: flex; align-items: center; gap: 8px; margin-left: auto; }
        .qs-applied { font-size: 12px; font-weight: 600; padding: 5px 10px; }
        .qs-more-toggle .badge { background: #1f6fc5; margin-left: 2px; }
        @media (max-width: 767px) {
            .qs-filter .panel-body { padding: 14px 14px 0; }
            .qs-actions { margin: 4px -14px 0; padding: 12px 14px; }
            .qs-actions .btn { flex: 1; }
            .qs-filter [class*="col-"] { margin-bottom: 10px; }
            .qs-toolbar .btn { flex: 1 1 45%; }
            .qs-table.card-table > tbody > tr { padding: 2px 14px; margin-bottom: 10px; }
            .qs-table.card-table > tbody > tr > td { padding: 6px 0; }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Question Diary No." for="QuestionDiary"></asp:Label>
                <asp:TextBox ID="QuestionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Question ID" for="QuestionId"></asp:Label>
                <asp:TextBox ID="QuestionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
            </div>
        </div>
        <div id="qsMore" class="collapse">
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="memberSearch"></asp:Label>
                <div id="memberBox" class="form-control member-multi">
                    <span id="memberChips"></span>
                    <input type="text" id="memberSearch" class="member-input" placeholder="Type a member name to add..." autocomplete="off" />
                </div>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" Style="display: none" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" for="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Category" for="CategoryDDL"></asp:Label>
                <asp:DropDownList ID="CategoryDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Category</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Group" for="GroupsDDL"></asp:Label>
                <asp:DropDownList ID="GroupsDDL" ClientIDMode="Static" class="form-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Group</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Question Status" for="QuestionStatusDDL"></asp:Label>
                <asp:DropDownList ID="QuestionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="Notice Diary No" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="NoticeDiaryNo" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off"></asp:TextBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label25" runat="server" CssClass="small-label" Text="Gender" for="QuestionStatusDDL"></asp:Label>
                <asp:DropDownList ID="GenderDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Gender</asp:ListItem>
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="2">Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label26" runat="server" CssClass="small-label" Text="Religion" for="DateFromTxt"></asp:Label>
                <asp:DropDownList ID="ReligionDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Religion</asp:ListItem>
                    <asp:ListItem Value="1">Islam</asp:ListItem>
                    <asp:ListItem Value="2">Christianity</asp:ListItem>
                    <asp:ListItem Value="3">Hinduism</asp:ListItem>
                    <asp:ListItem Value="5">Sikh</asp:ListItem>
                    <asp:ListItem Value="4">Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label27" runat="server" CssClass="small-label" Text="Not in Religion" for="DateFromTxt"></asp:Label>
                <asp:DropDownList ID="NotReligionDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Not in Religion</asp:ListItem>
                    <asp:ListItem Value="1">Islam</asp:ListItem>
                    <asp:ListItem Value="2">Christianity</asp:ListItem>
                    <asp:ListItem Value="3">Hinduism</asp:ListItem>
                    <asp:ListItem Value="5">Sikh</asp:ListItem>
                    <asp:ListItem Value="4">Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label29" runat="server" CssClass="small-label" Text="File Status" for="DateFromTxt"></asp:Label>
                <asp:DropDownList ID="FileStatusDDl" ClientIDMode="Static" runat="server" class="form-control small-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-2" style="margin-top: 5px;">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label28" runat="server" CssClass="small-label" Text="Exact Match" for="ExactMatchCB"></asp:Label>
                <asp:CheckBox ID="ExactMatchCB" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                    <asp:TextBox ID="DivisionTxt" runat="server" CssClass="form-control small-control" />
                    <asp:HiddenField ID="HidDivisionId" runat="server" />
                </div>
            </div>
                <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Coallition:</label>
                <div>
                     <asp:DropDownList ID="CoallitionDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">Goverment</asp:ListItem>
                    <asp:ListItem Value="2">Opposition</asp:ListItem>
                    <asp:ListItem Value="3">Independant</asp:ListItem>
                    <asp:ListItem Value="4">Not yet Decided</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
        </div>
        </div>
        <div class="qs-actions">
            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
            <asp:Button class="btn btn-default" ID="Button1" runat="server" ClientIDMode="Static" Text="Reset" OnClientClick="clearTextBox();" />
        </div>
        </div>
    </div>
    <div class="container-fluid qs-results">
        <div class="clearfix"></div>
        <div class="qs-toolbar">
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Questions" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Annual Report" NavigateUrl="QuestionAnnualReport.aspx" />
        <asp:HyperLink class="btn btn-success" ID="HyperLink4" Target="_blank" runat="server" Text="Deferred Questions" NavigateUrl="Rpt_DefferedQuestions.aspx" />
        <asp:HyperLink class="btn btn-info" ID="HyperLink5" Target="_blank" runat="server" Text="Compare Question" NavigateUrl="~/CompareQuestion.aspx" />
        </div>
        <asp:Panel ID="pnlContents" runat="server">
            <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>
            <table class="table table-hover table-striped table-responsive qs-table">
                <thead class="thead-inverse">
                    <tr>
                        <th class="m-hide">Sr#</th>
                        <th style="text-align: center" class="hid m-hide">Select
              <asp:CheckBox ID="CheckAllCB" runat="server" AutoPostBack="true" ClientIDMode="Static" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
                        </th>
                        <th>QID</th>
                        <th class="m-hide">Q-DN</th>
                        <th class="hid m-hide">List No</th>
                        <th>Session Number</th>
                        <th class="m-hide">Group</th>
                        <th class="m-hide">Division</th>
                         <th>Submitted By</th>
                        <th>Subject Matter</th>
                        <th class="m-hide">Notice No / Date</th>
                        <th class="m-hide">Notice Time</th>
                        <th class="m-hide">Category</th>
                     
                        <th class="m-hide">Status</th>
                          <th class="m-hide">Origin</th>
                        <%--  <th>Carry Fwd</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll_CheckedChanged" /></th>--%>
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
                                <td class="hid m-hide">
                                    <asp:CheckBox ID="SelectCB" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("QuestionsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                                </td>
                                <td style="text-align: center" class="m-hide">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("QuestionDiaryNo") %>' />
                                </td>
                                <td style="text-align:center;width:4%" class="hid m-hide">
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#GetListNo(Convert.ToInt32(Eval("ListId")),Convert.ToString(Eval("SupNo"))) %>' />

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
                                 <td>
                                    <asp:Label ID="Label30" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td runat="server" id="FullSearch" class="m-block qs-subject">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black; font-size: 10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionsId").ToString())%>'><%#SelectText(Eval("QuestionText").ToString())%></asp:HyperLink>
                                </td>
                                <td runat="server" id="RestrictedSearch" visible="false" class="m-block qs-subject">
                                    <asp:HyperLink class="table-data" ID="HyperLink3" CssClass="printText" runat="server" Style="color: black; font-size: 10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionsId").ToString())%>'><%#SelectText(Eval("QuestionText").ToString())%></asp:HyperLink>
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                                      <asp:HiddenField ID="HidNoticeDiaryNo" runat="server" Value='<%#Bind("NoticeDiaryNo")%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>
                                <td class="m-hide">
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("QuestionCategory")%>' />
                                </td>
                               
                                <td class="m-hide">
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>
                                  <td class="m-hide">
                                    <asp:Label ID="Label32" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("DeviceId"))==1?"Notice Office":"Mobile App"%>' />
                                </td>
                                <%--   <td>
                            <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#(Convert.ToInt32(Eval("IsCarryFwd"))==1)?"Yes":"No"%>' />
                        </td>--%>
                                <%--  <td>
                            <asp:CheckBox ID="SelectCB" runat="server"  />
                        </td>--%>
                                <td id="fullPrint" runat="server" class="hid m-hide">
                                    <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" CssClass="btn btn-custom" />
                                </td>
                                <td id="restrictedPrint" runat="server" visible="false" class="m-hide">
                                    <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" CssClass="btn btn-custom" />
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
                <asp:Label ID="Label31" runat="server" Text="Question Status" for="ChangeStatusDDL" CssClass="small-label" />
                <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21" runat="server" Text="Status Date" for="ChangeStatusDDL" CssClass="small-label" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control datepicker" placeholder="dd/mm/yyyy" autocomplete="off" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" CssClass="btn btn-primary" Text="Change Status" OnClick="ChangeStatusBtn_Click" />
            </div>
              <div class="col-md-2">
                <br />
                <asp:Button ID="PrintFrsBtn" runat="server" CssClass="btn btn-primary" Text="Print FRs" OnClick="PrintFrsBtn_Click"/>
            </div>
        </div>
        <%-- <div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:DropDownList ID="MoveQuestionDDL" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">Move Question</asp:ListItem>
                    <asp:ListItem Value="2">Deffer</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>--%>
        <%--  <div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:DropDownList ID="SessionMovementDDL" runat="server" CssClass="form-control">
                   
                </asp:DropDownList>
                </div>
                <div class="col-md-1">
                <asp:Button ID="Button1" runat="server" Text="Carry Forward" Cssclass="btn btn-custom" OnClick="Button1_Click" />
                </div>
            </div>--%>
        <%--<div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:Button ID="MoveBtn" runat="server" Text="Move" Cssclass="btn btn-custom" />
                </div>
            </div>--%>
    </div>
    <script type="text/javascript">
        $(function () {
            if (window.matchMedia && window.matchMedia('(max-width: 767px)').matches) {
                $('#qsMore').removeClass('in');
            }
        });
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
    <script type="text/javascript">QSPanel.init({ key: 'question' });</script>
</asp:Content>
