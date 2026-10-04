<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_MemberWiseQuestions.aspx.cs" Inherits="QuestionManagement.Rpt_MemberWiseQuestions" %>
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
        }
    </script>
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
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>***QUESTION BRANCH***</u></div><br>');
            //printWindow.document.write('<div style="font-size:large;text-align:center">Member Wise Questions</div><br>');
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
                <h4 style="color: #000;">MEMBER WISE QUESTIONS SUMMARY</h4>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Question Diary No." for="QuestionDiary"></asp:Label>
                <asp:TextBox ID="QuestionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Question ID" for="QuestionId"></asp:Label>
                <asp:TextBox ID="QuestionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" TextMode="MultiLine" CssClass="form-control small-control" />
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
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
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
            <div class="col-md-6">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                    <asp:TextBox ID="DivisionTxt" runat="server" CssClass="form-control small-control" />
                    <asp:HiddenField ID="HidDivisionId" runat="server" />
                </div>
            </div>
            <div class="col-md-2" style="margin-top: 10px">
                <br />
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="clearfix"></div>
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Questions" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Annual Report" NavigateUrl="QuestionAnnualReport.aspx" />
        <asp:HyperLink class="btn btn-success" ID="HyperLink4" Target="_blank" runat="server" Text="Deferred Questions" NavigateUrl="Rpt_DefferedQuestions.aspx" />
        <asp:HyperLink class="btn btn-info" ID="HyperLink5" Target="_blank" runat="server" Text="Compare Question" NavigateUrl="~/CompareQuestion.aspx" />
        <asp:Panel ID="pnlContents" runat="server">
            <div>
            <div id="HeadingDiv" class="table-data" runat="server" Text="" style="font-weight:bold;font-family:'Times New Roman', Times, serif;font-size:12pt;text-align:center"></div>
            <div ID="SessionDiv" class="table-data" runat="server" Text="" style="font-weight:bold;font-family:'Times New Roman', Times, serif;font-size:12pt;text-align:center"></div>
                </div>
            <table class="table table-hover table-striped table-responsive" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>QID /Session</th>
                        <th>Division</th>
                        <th>Subject Matter</th>
                        <th>Category / Status</th>
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
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#"QID: " + Eval("QuestionsId")%>' /><br />
                                      <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#"Session No: " + Eval("SessionNumber")%>' />
                                  
                                </td>
                           
                               <%-- <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                </td>--%>
                              
                                <td>
                                    <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#Eval("Division")%>' />
                                </td>
                                <td style="text-align: justify; min-width: 400px !important;" runat="server" id="FullSearch">
                                     <div><%#Eval("QuestionHtmlText")%></div>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#"Category: " + Eval("QuestionCategory")%>' /><br />
                                     <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#"Status: " + Eval("QuestionStatus")%>' /><br />
                                </td>
                             <%--   <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

