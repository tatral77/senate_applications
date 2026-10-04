<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NoticeResolutions.aspx.cs" Inherits="QuestionManagement.NoticeResolutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        .nr-header { margin: 6px 0 16px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .nr-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .nr-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .nr-header .nr-actions { float: right; margin-top: 4px; }

        .nr-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 18px; }
        .nr-card-title { padding: 11px 18px; border-bottom: 1px solid #e4e9ee; background: #f8fafb; border-radius: 6px 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; display: flex; align-items: center; }
            .nr-card-title .nr-grow { flex: 1; }
        .nr-card-body { padding: 16px 18px 6px; }
            .nr-card-body .form-group { margin-bottom: 14px; }
            .nr-card-body label, .nr-card-body .small-label { font-size: 13px; font-weight: 600; color: #3c4858; margin-bottom: 4px; display: block; }
        .nr-filter-actions { text-align: right; padding: 0 18px 16px; }
            .nr-filter-actions .btn { margin-left: 6px; }

        .nr-toolbar { display: flex; align-items: center; padding: 10px 14px; border-bottom: 1px solid #e4e9ee; }
        .nr-count { display: inline-block; background: #0c3a72; color: #fff; border-radius: 12px; padding: 1px 10px; font-weight: 700; margin-right: 8px; }
        .nr-quick { margin-left: auto; min-width: 260px; }
        .nr-table { margin: 0; }
            .nr-table th { background: #e8f0f9; color: #0c3a72; font-size: 12px; text-transform: uppercase; letter-spacing: .03em; white-space: nowrap; }
            .nr-table td { font-size: 13px; vertical-align: top !important; }
        .nr-subject a { color: #1f2d3d; }
            .nr-subject a:hover { color: #0c3a72; text-decoration: none; }
        .nr-nofile { color: #6b7785; font-style: italic; }
        .nr-clip { color: #1f6fb5; margin-right: 4px; }
        .nr-empty { text-align: center; padding: 40px 10px; color: #6b7785; }
        .hit { background: #fff1a8; }
    </style>
    <script type="text/javascript">
        function clearTextBox() {
            $("#NoticeDiary, #ResolutionId, #KeywordsTxt, #MemberNameTxt, #DateFromTxt, #DateToTxt").val("");
            $("[id$=HidMemberId]").val("");
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #ResolutionTypeDDL, #ResolutionStatusDDL").each(function () { this.selectedIndex = 0; });
        }

        $(function () {
            // member search: the service returns "Name=Id"
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
                                var k = item.lastIndexOf('=');
                                return { label: item.substring(0, k), val: item.substring(k + 1) };
                            }));
                        },
                        error: function (response) { alert(response.responseText); }
                    });
                },
                select: function (e, i) { $("[id$=HidMemberId]").val(i.item.val); },
                minLength: 1
            });
            $("[id$=MemberNameTxt]").on('input', function () { if (!this.value) $("[id$=HidMemberId]").val(""); });

            // quick filter over the rows already on screen
            var $rows = $('#nrTable tbody tr');
            $('#nrQuick').on('input', function () {
                var q = $.trim(this.value).toLowerCase(), shown = 0;
                $rows.each(function () {
                    var ok = !q || $(this).text().toLowerCase().indexOf(q) !== -1;
                    $(this).toggle(ok);
                    if (ok) shown++;
                });
                $('#nrEmpty').text('No resolutions match.').toggle($rows.length > 0 && shown === 0);
            });
            if (!$rows.length) $('#nrEmpty').text('No resolutions found.').show();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="nr-header">
            <div class="nr-actions">
                <button type="button" class="btn btn-default" data-toggle="collapse" data-target="#<%= SearchPanel.ClientID %>">Search filters</button>
            </div>
            <h3>Resolutions from Notice Office</h3>
            <p>Session <asp:Literal ID="SessionLit" runat="server"></asp:Literal> &middot; open a resolution to check it and assign it</p>
        </div>

        <div class="nr-card">
            <asp:Panel ID="SearchPanel" runat="server" CssClass="collapse" DefaultButton="Button2">
                <div class="nr-card-title">Search</div>
                <div class="nr-card-body">
                    <div class="row">
                        <div class="col-md-2 form-group">
                            <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Notice Diary No." AssociatedControlID="NoticeDiary"></asp:Label>
                            <asp:TextBox ID="NoticeDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                        </div>
                        <div class="col-md-2 form-group">
                            <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Resolution ID" AssociatedControlID="ResolutionId"></asp:Label>
                            <asp:TextBox ID="ResolutionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" AssociatedControlID="KeywordsTxt"></asp:Label>
                            <asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" AssociatedControlID="MemberNameTxt"></asp:Label>
                            <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" placeholder="Type to search members..." />
                            <asp:HiddenField ID="HidMemberId" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 form-group">
                            <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" AssociatedControlID="FromAssemblySessionDDL"></asp:Label>
                            <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 form-group">
                            <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" AssociatedControlID="ToAssemblySessionDDL"></asp:Label>
                            <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Resolution Type" AssociatedControlID="ResolutionTypeDDL"></asp:Label>
                            <asp:DropDownList ID="ResolutionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                                <asp:ListItem Selected="True" Value="0">Resolution Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Resolution Status" AssociatedControlID="ResolutionStatusDDL"></asp:Label>
                            <asp:DropDownList ID="ResolutionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                                <asp:ListItem Selected="True" Value="0">Resolution Status</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 form-group">
                            <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" AssociatedControlID="DateFromTxt"></asp:Label>
                            <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" AssociatedControlID="DateToTxt"></asp:Label>
                            <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="nr-filter-actions">
                    <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                    <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Reset" UseSubmitBehavior="false" OnClientClick="window.location.href = window.location.pathname; return false;" />
                </div>
            </asp:Panel>
        </div>

        <div class="nr-card">
            <div class="nr-toolbar">
                <span class="nr-count"><asp:Literal ID="CountLit" runat="server">0</asp:Literal></span>
                <span>resolution(s)</span>
                <input type="text" id="nrQuick" class="form-control nr-quick" placeholder="Filter these results..." autocomplete="off" />
            </div>
            <div style="overflow-x: auto">
                <table class="table table-hover nr-table" id="nrTable">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Notice No./Date</th>
                            <th>Session Number</th>
                            <th>Resolution Type</th>
                            <th>Subject Matter</th>
                            <th>Resolution Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.DataItemIndex + 1 %></td>
                                    <td>
                                        <a href='<%# ResolveUrl(Convert.ToString(Eval("ResolutionsId", "~/NoticeResolutionDetail.aspx?ResolutionId={0}"))) %>' target="_blank"><b><%# Eval("ResolutionsId") %></b></a><br />
                                        <%# GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %>
                                    </td>
                                    <td style="text-align: center"><%# Eval("SessionNumber") %></td>
                                    <td><%# Server.HtmlEncode(Convert.ToString(Eval("ResType"))) %></td>
                                    <td class="nr-subject" style="min-width: 340px"><%# Preview(Convert.ToString(Eval("Description")), Convert.ToString(Eval("ResolutionFile")), Convert.ToInt32(Eval("ResolutionsId"))) %></td>
                                    <td><%# Server.HtmlEncode(Convert.ToString(Eval("ResolutionStatus"))) %></td>
                                    <td>
                                        <a class="btn btn-default btn-xs" target="_blank" href='<%# ResolveUrl(Convert.ToString(Eval("ResolutionsId", "~/PrintResolution.aspx?ResolutionId={0}"))) %>'>Print</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
                <div class="nr-empty" id="nrEmpty" style="display: none"></div>
            </div>
        </div>

    </div>
</asp:Content>
