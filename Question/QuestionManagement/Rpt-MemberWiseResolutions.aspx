<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt-MemberWiseResolutions.aspx.cs" Inherits="QuestionManagement.Rpt_MemberWiseResolutions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function clearTextBox() {
            $("#QuestionId").val("");
            $("#KeywordsTxt").val("");
            $("#MemberNameTxt").val("");
            $("#FromAssemblySessionDDL").each(function () { this.selectedIndex = 0 });
            $("#ToAssemblySessionDDL").each(function () { this.selectedIndex = 0 });
            $("#CategoryDDL").each(function () { this.selectedIndex = 0 });
            $("#GroupsDDL").each(function () { this.selectedIndex = 0 });
            $("#QuestionStatusDDL").each(function () { this.selectedIndex = 0 });
            $("#DateFromTxt").val("");
            $("#DateToTxt").val("");

        }</script>
    <style type="text/css">
        .style2 {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
            width: 69px;
        }
        .style3 {
            width: 69px;
        }
    </style>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script>
        $(function () {
            function splitval(val) {
                return val.split(/,\s*/);
            }
            function extractLast(term) {
                return splitval(term).pop();
            }

            $("#MemberNameTxt")
                // don't navigate away from the field on tab when selecting an item
                .on("keydown", function (event) {
                    if (event.keyCode === $.ui.keyCode.TAB &&
                        $(this).autocomplete("instance").menu.active) {
                        event.preventDefault();
                    }
                })
                .autocomplete({
                    minLength: 0,
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/Service.asmx/GetAllMembersByName") %>',
                            data: "{ 'prefix': '" + extractLast(request.term) + "'}",
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
                            // alert(request.term);
                            //var memberslist = $.ui.autocomplete.filter(
                            //    data.d, extractLast(request.term));
                            //alert(memberslist);
                            //response(memberslist);

                            //},
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                    },
                    focus: function () {
                        // prevent value inserted on focus
                        return false;
                    },
                    select: function (event, ui) {
                        var ids = $("[id$=HidMemberId]").val();
                        $("[id$=HidMemberId]").val(ids + "," + ui.item.val);
                        var terms = splitval(this.value);
                        //var id = $("[id$=HidMemberId]").val();
                        //$("[id$=HidMemberId]").val(id + "," + ui.item.value.split('=')[1]);
                        // remove the current input
                        terms.pop();
                        // add the selected item
                        //  var membername = ui.item.value.split('=')[0];
                        terms.push(ui.item.label);
                        // add placeholder to get the comma-and-space at the end
                        terms.push("");
                        this.value = terms.join(", ");

                        return false;
                    }
                });
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
        jQuery(document).ready(function () {

            jQuery('#search').on('click', function (event) {
                event.preventDefault();

            });
        });
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Questions Branch</u></div><br>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { fallback: PrintPanel });
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />

    <div class="container regularDiv" style="padding: 20px; color: black">
        <div class="row">
            <div class="col-md-4">
                <h4>SEARCH RESOLUTION</h4>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Resolution Diary No." for="ResolutionDiary"></asp:Label>
                <asp:TextBox ID="ResolutionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Resolution ID" for="ResolutionId"></asp:Label>
                <asp:TextBox ID="ResolutionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox></div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" TextMode="MultiLine" CssClass="form-control small-control" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" for="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Resolution Type" for="ResolutionTypeDDL"></asp:Label>
                <asp:DropDownList ID="ResolutionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Resolution Type</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Colour Res. No" for="ResolutionTypeDDL"></asp:Label>
                <asp:TextBox ID="ResolutionNoTxt" runat="server" CssClass="form-control small-control" />
            </div>

        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Resolution Status" for="ResolutionStatusDDL"></asp:Label>
                <asp:DropDownList ID="ResolutionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Resolution Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="Notice Diary No" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="NoticeDiaryNo" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-2" style="margin-top: 5px;">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-7"></div>
            <div class="col-md-3" style="align-content:right; margin-top: 10px">
                <br />
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
            </div>

        </div>
    </div>
    <br />
    <div class="container">
        <div class="clearfix"></div>
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Resolutions" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Motion Annual Report" NavigateUrl="~/ResolutionAnnualReport.aspx" />
        <asp:Panel ID="pnlContents" runat="server">
            <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>
            <table class="table table-hover table-striped table-responsive" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th style="text-align: center" class="hid">Select
              <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
                        </th>
                        <th>RID/ Session No.</th>

                        <th>Resolution Type / Status</th>
                        <th style="max-width: 50%; word-wrap: break-word">Subject Matter</th>

                        <th>Movers</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">

                        <ItemTemplate>
                              <%#AddGroupingRow()%>
                            <tr>
                                <td>

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td style="width:10%">
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#"RID: " + Eval("ResolutionsId")%>' /><br />
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#"Session: " +Eval("SessionNumber")%>' />
                                </td>
                                <td style="width:10%">
                                   <%-- <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#"Res Type: " + Eval("ResType")%>' /><br />--%>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#"Status: " + Eval("ResolutionStatus")%>' />
                                </td>
                                <td style="text-align: justify">
                                    <div><%#Eval("Description")%></div>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("ResolutionsId")))%>' />
                                </td>

                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
            </asp:Panel>
        </div>
</asp:Content>
