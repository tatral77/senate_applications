<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_MotionsReport.aspx.cs" Inherits="MotionBranch.Rpt_MotionsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script type="text/javascript">
        function clearTextBox() {
            $("#MotionId").val("");
            $("#KeywordsTxt").val("");
            $("#MemberNameTxt").val("");
            $("#FromAssemblySessionDDL").each(function () { this.selectedIndex = 0 });
            $("#ToAssemblySessionDDL").each(function () { this.selectedIndex = 0 });
            $("#CategoryDDL").each(function () { this.selectedIndex = 0 });
            $("#GroupsDDL").each(function () { this.selectedIndex = 0 });
            $("#MotionStatusDDL").each(function () { this.selectedIndex = 0 });
            $("#DateFromTxt").val("");
            $("#DateToTxt").val("");

        }

    </script>

    <link href="Styles/MainStyles.css" rel="stylesheet" />
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

        td th tr {
            border-style: solid !important;
            border-color: #000 !important;
            margin: 5px;
        }
    </style>
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
        $(function () {
            $("[id$=MinistryTxt]").autocomplete({
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
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
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
                       $("[id$=HidMinistryId]").val(i.item.val);
                   },
                   minLength: 1
               });
         });

       <%--  $(function () {
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

        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Motion Branch</u></div><br>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />

    <div class="container regularDiv" style="padding: 20px; color: black">
        <div class="row">
            <div class="col-md-4">
                <h4>SEARCH MOTION</h4>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Motion Diary No." for="MotionDiary"></asp:Label>
                <asp:TextBox ID="MotionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Motion ID" for="MotionId"></asp:Label>
                <asp:TextBox ID="MotionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
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
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Motion Type" for="MotionTypeDDL"></asp:Label>
                <asp:DropDownList ID="MotionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Motion Type</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Motion Week" for="MotionWeekCB"></asp:Label>
                <asp:DropDownList ID="MotionWeekCB" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Motion Week</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <div class="row top-buffer">
            <div class="col-md-4">
                <asp:Label ID="Label21" runat="server" CssClass="small-label" Text="Ministry" for="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MinistryTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                <asp:HiddenField ID="HidMinistryId" runat="server" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Motion Status" for="MotionStatusDDL"></asp:Label>
                <asp:DropDownList ID="MotionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="File No" for="FileNoTxt"></asp:Label>
                <asp:TextBox ID="FileNoTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-1" style="margin-top: 5px;">
                <asp:Label ID="Label24" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-8" style="margin-top: 5px;"></div>
            <div class="col-md-3" style="text-align: right; margin-top: 10px">
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
            </div>

        </div>
    </div>
    <br />
    <div class="container">
        <div class="clearfix"></div>
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Motions" OnClientClick="return PrintPanel();" />
        <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>
        <asp:Panel ID="pnlContents" runat="server">
            <div style="font-size:11pt;margin-bottom:10px;">
                 <asp:Label ID="criteriaLbl" runat="server" CssClass="small-label"></asp:Label>
            </div>

            <table class="table" style="border-style: solid!important; border-color: #000!important; border-width: thin; border-collapse: collapse;">
               <%-- <thead style="border-style: solid!important; border-color: #000!important; border-width: thin;">--%>
                    <tr style="height: 30px;">
                        <th>Sr#</th>
                        <th>No. and Date</th>
                        <%--   <th>M-File No</th>--%>
                        <%--  <th class="hid">Motion Diary No</th>--%>
                        <%--  <th>Session Number</th>--%>
                        <%--   <th class="hid">Motion Type</th>--%>
                        <th>Name of Senator(s)</th>
                        <th style="width: 40%">Subject Matter</th>
                        <%--  <th>Notice No./Date</th>--%>
                        <%-- <th class="hid">Motion Week</th>--%>
                        <th>Motion Status / Remarks</th>

                        <%--<th class="hid">Ministries</th>
            <th class="hid">Action</th>--%>
                    </tr>
               <%-- </thead>--%>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">

                        <ItemTemplate>
                            <tr>
                                <td style="border-style: solid!important; border-color: #000!important; border-width: thin; margin: 0px!important; padding: 5px; text-align: center">

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td style="border-style: solid!important; border-color: #000!important; border-width: thin!important; padding: 5px;">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#"File No::" +Eval("FileNo")%>' /><br />
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#"MID:" + Eval("MotionsId")%>' />
                                    <br />
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#"Session:" + Eval("SessionDesc")%>' />
                                    <br />
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#"Notice Diary/Date:" +Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                                </td>

                                <%-- <td style="text-align:center" class="hid">
                            <asp:Label ID="Label23" class="table-data"  runat="server" Text='<%#Eval("MotionDiaryNo")%>' />
                        </td>--%>
                                <%-- <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionDesc")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                        </td>--%>

                                <%--  <td class="hid">
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("MotionType")%>' />
                        </td>--%>
                                <td style="border-style: solid!important; border-color: #000!important; border-width: thin!important; padding: 5px;">
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                                </td>
                                <td style="text-align: justify; border-style: solid!important; border-color: #000!important; border-width: thin; padding: 5px;">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("Description")%>' />
                                </td>


                                <%--    <td class="hid">
                            <asp:Label ID="Label20" class="table-data" runat="server"  Text='<%#GetWeek(Convert.ToInt32(Eval("WeekId")))%>' />
                        </td>--%>
                                <td style="text-align: center; border-style: solid!important; border-color: #000!important; border-width: thin!important; padding: 5px;">
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("MotionStatus")%>' />
                                </td>

                                <%--  <td class="hid">
                            <asp:Label ID="Label22" class="table-data" runat="server"  Text='<%#GetMinistries(Convert.ToInt32(Eval("MotionsId")))%>' />
                        </td>--%>

                                <%--  <td class="hid">
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>  --%>
                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
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
    <br />
    <br />
</asp:Content>
