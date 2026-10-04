<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SentMotions.aspx.cs" Inherits="Notice.SentMotions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        .qs-panel { background:#fff; border:1px solid #d9dee5; border-radius:8px; box-shadow:0 1px 4px rgba(0,0,0,.08); padding:0; color:#000; }
        .qs-panel .qs-heading { display:flex; align-items:center; justify-content:space-between; gap:10px; padding:16px 24px; border-bottom:2px solid #e9edf2; }
        .qs-panel .qs-title { margin:0; font-weight:600; letter-spacing:.5px; color:#1f2d3d; }
        .qs-panel .qs-body { padding:20px 24px 0; }
        .qs-panel .row { margin-bottom:10px; }
        .qs-panel .small-label { display:block; margin-bottom:3px; font-size:12px; font-weight:600; color:#5b6773; text-transform:uppercase; }
        .qs-actions { text-align:right; border-top:1px solid #e9edf2; padding:14px 24px; margin:6px -24px 0; background:#f6f8fb; border-radius:0 0 8px 8px; }
        .qs-actions .btn { min-width:90px; margin-left:6px; }
        .qs-applied { font-size:12px; font-weight:600; padding:5px 10px; }
        .qs-table > thead > tr > th { background:#2c3e50; color:#fff; font-weight:600; font-size:12px; text-transform:uppercase; white-space:nowrap; border-bottom:0; }
        .qs-table > tbody > tr > td { vertical-align:middle; }
        .ui-autocomplete { max-height:240px; overflow-y:auto; overflow-x:hidden; z-index:2000; }

        .qs-toolbar { display:flex; align-items:center; padding:10px 2px 14px; }
        .qs-count { display:inline-block; background:#2c3e50; color:#fff; border-radius:12px; padding:1px 11px; font-weight:700; font-size:13px; margin-right:8px; }
        .qs-pill { display:inline-block; font-size:11px; font-weight:700; letter-spacing:.03em; border-radius:10px; padding:2px 9px; text-transform:uppercase; }
        .qs-pill-status { background:#eef1f5; color:#3c4858; text-transform:none; font-weight:600; }
        .qs-justify a { color:#1f2d3d; }
        .qs-justify a:hover { color:#0c3a72; text-decoration:none; }
        .qs-actbtns { white-space:nowrap; }
        .qs-actbtns .btn { margin-right:4px; }
        .qs-empty { text-align:center; padding:36px 10px; color:#6b7785; }
    </style>
    <script type="text/javascript">
        function clearTextBox() {
            $("#MotionId, #NoticeDiary, #KeywordsTxt, #MemberNameTxt, #DateFromTxt, #DateToTxt").val("");
            $("[id$=HidMemberId]").val("");
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #MotionTypeDDL, #MotionStatusDDL").each(function () { this.selectedIndex = 0; });
        }

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
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />

    <div class="container-fluid qs-panel qs-filter">
        <div class="qs-heading">
            <h4 class="qs-title"><span class="glyphicon glyphicon-search"></span> Search Motions</h4>
            <span class="qs-head-tools" style="margin-left:auto">
                <span class="label label-info qs-applied" id="qsApplied" style="display:none"></span>
                <button type="button" class="btn btn-default btn-sm" id="qsPanelToggle" title="Show or hide the search form"><span class="glyphicon glyphicon-chevron-up"></span> <span class="qs-panel-text">Hide search</span></button>
            </span>
        </div>
        <div class="qs-body" id="qsBody">
        <div class="row">
            <div class="col-md-3 col-sm-6"><asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Notice Diary No." AssociatedControlID="NoticeDiary"></asp:Label><asp:TextBox ID="NoticeDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /></div>
            <div class="col-md-3 col-sm-6"><asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Motion ID" AssociatedControlID="MotionId"></asp:Label><asp:TextBox ID="MotionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /></div>
            <div class="col-md-6"><asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" AssociatedControlID="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /></div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" AssociatedControlID="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" placeholder="Type to search members..." />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
            <div class="col-md-2 col-sm-4">
                <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" AssociatedControlID="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2 col-sm-4">
                <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" AssociatedControlID="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-4 col-sm-4">
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Motion Type" AssociatedControlID="MotionTypeDDL"></asp:Label>
                <asp:DropDownList ID="MotionTypeDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Motion Type</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Motion Status" AssociatedControlID="MotionStatusDDL"></asp:Label>
                <asp:DropDownList ID="MotionStatusDDL" ClientIDMode="Static" runat="server" CssClass="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4 col-sm-6">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" AssociatedControlID="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" CssClass="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
            </div>
            <div class="col-md-4 col-sm-6">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" AssociatedControlID="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" CssClass="form-control small-control" placeholder="dd.mm.yyyy"></asp:TextBox>
            </div>
        </div>
        </div>
        <div class="qs-actions">
            <asp:Button CssClass="btn btn-default" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox(); return false;" />
            <asp:Button CssClass="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
        </div>
    </div>
    <br />
    <div class="container-fluid qs-results">
        <div class="qs-toolbar">
            <span class="qs-count"><asp:Literal ID="CountLit" runat="server">0</asp:Literal></span>
            <span>motion(s) sent to the Assembly Branch</span>
        </div>
        <table class="table table-hover table-striped table-responsive qs-table">
            <thead class="thead-inverse">
                <tr>
                    <th class="m-hide">Sr#</th>
                    <th>Notice No./Date</th>
                    <th>M-DN</th>
                    <th>Session Number</th>
                    <th>Motion Type</th>
                    <th>Subject Matter</th>
                    <th>Motion Status</th>
                    <th>Movers</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="ListView1" OnItemDeleting="ListView1_ItemDeleting" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="m-hide">
                                <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                            </td>
                            <td>
                                <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                                <asp:HiddenField ID="HidMotionId" runat="server" Value='<%#Eval("MotionsId")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Eval("MotionDiaryNo")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("SessionDesc")%>' />
                                <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                            </td>
                            <td>
                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("MotionType")%>' />
                            </td>
                            <td class="m-block qs-justify" style="text-align: justify; min-width: 280px">
                                <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/MotionDetail.aspx?MotionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
                            </td>
                            <td>
                                <span class="qs-pill qs-pill-status"><asp:Label ID="Label2" runat="server" Text='<%#Eval("MotionStatus")%>' /></span>
                            </td>
                            <td>
                                <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                            </td>
                            <td class="qs-actbtns">
                                <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" CssClass="btn btn-default btn-xs" />
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-danger btn-xs" runat="server" CommandName="delete"
                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td colspan="9" class="qs-empty">No sent motions match your search.</td>
                        </tr>
                    </EmptyDataTemplate>
                </asp:ListView>
            </tbody>
        </table>
    </div>
    <br />
    <br />
    <script src='<%= ResolveUrl("~/Scripts/searchpanel.js") %>' type="text/javascript"></script>
    <script type="text/javascript">QSPanel.init({ key: 'sent-motion' });</script>
</asp:Content>
