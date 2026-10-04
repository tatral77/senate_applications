<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchQuestion.aspx.cs"  Inherits="Notice.SearchQuestion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function clearTextBox() {
            $("#QuestionDiary, #QuestionId, #NoticeDiaryNo, #KeywordsTxt, #DateFromTxt, #DateToTxt, #DivisionTxt").val("");
            $("[id$=HidDivisionId]").val("");
            $("[data-chips]").each(function () { var c = $(this).data("chips"); if (c) { c.clear(); } });
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #CategoryDDL, #QuestionStatusDDL, #GenderDDL, #ReligionDDL, #NotReligionDDL, #FileStatusDDl").each(function () { this.selectedIndex = 0; });
            $("[id$=FullTextCB], [id$=ExactMatchCB]").prop("checked", false);
        }
    </script>
    <script>

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
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Questions Branch</u></div><br>');
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
    <div class="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH QUESTIONS</span>
            <button type="button" class="btn btn-default btn-sm visible-xs qs-more-toggle" data-toggle="collapse" data-target="#qsMore"><span class="glyphicon glyphicon-filter"></span> More filters</button>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="QuestionDiary">Question Diary No.</label>
                    <asp:TextBox ID="QuestionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="QuestionId">Question ID</label>
                    <asp:TextBox ID="QuestionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-6 col-sm-6">
                    <label class="small-label" for="KeywordsTxt">Keyword</label>
                    <asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
            </div>
            <div id="qsMore" class="collapse in">
            <div class="row">
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="memberSearch">Member Name (pick one or more)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetAllMembersByName") %>" data-ids="#<%= HidMemberId.ClientID %>" data-names="#MemberNameTxt" data-placeholder="Type a member name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="FromAssemblySessionDDL">From Session</label>
                    <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="ToAssemblySessionDDL">To Session</label>
                    <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="CategoryDDL">Category</label>
                    <asp:DropDownList ID="CategoryDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Category</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="QuestionStatusDDL">Question Status</label>
                    <asp:DropDownList ID="QuestionStatusDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="NoticeDiaryNo">Notice Diary No</label>
                    <asp:TextBox ID="NoticeDiaryNo" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="DateFromTxt">From Notice Date</label>
                    <asp:TextBox ID="DateFromTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="DateToTxt">To Notice Date</label>
                    <asp:TextBox ID="DateToTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="GenderDDL">Gender</label>
                    <asp:DropDownList ID="GenderDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Gender</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="ReligionDDL">Religion</label>
                    <asp:DropDownList ID="ReligionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Religion</asp:ListItem>
                        <asp:ListItem Value="1">Islam</asp:ListItem>
                        <asp:ListItem Value="2">Christianity</asp:ListItem>
                        <asp:ListItem Value="3">Hinduism</asp:ListItem>
                        <asp:ListItem Value="5">Sikh</asp:ListItem>
                        <asp:ListItem Value="4">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="NotReligionDDL">Not in Religion</label>
                    <asp:DropDownList ID="NotReligionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Not in Religion</asp:ListItem>
                        <asp:ListItem Value="1">Islam</asp:ListItem>
                        <asp:ListItem Value="2">Christianity</asp:ListItem>
                        <asp:ListItem Value="3">Hinduism</asp:ListItem>
                        <asp:ListItem Value="5">Sikh</asp:ListItem>
                        <asp:ListItem Value="4">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="FileStatusDDl">File Status</label>
                    <asp:DropDownList ID="FileStatusDDl" ClientIDMode="Static" class="form-control small-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="FullTextCB">Complete Text</label>
                    <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="ExactMatchCB">Exact Match</label>
                    <asp:CheckBox ID="ExactMatchCB" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-8 col-sm-6">
                    <label class="small-label" for="DivisionTxt">Division</label>
                    <asp:TextBox ID="DivisionTxt" runat="server" CssClass="form-control small-control" />
                    <asp:HiddenField ID="HidDivisionId" runat="server" />
                </div>
            </div>
            </div>
            <div class="qs-actions">
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
            </div>
        </div>
    </div>
<div class="container-fluid qs-results">
        <div class="clearfix"></div>
        <div class="qs-toolbar">
            <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Questions" OnClientClick="return PrintPanel();" />
        </div>
       
        <asp:Panel ID="pnlContents" runat="server">
            

            <table class="table table-hover table-striped table-responsive qs-table" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th class="m-hide">Sr#</th>
                       
                        <th>QID</th>
                      
                       
                        <th>Session Number</th>
                      
                     
                        <th>Subject Matter</th>
                        <th class="m-hide">Notice No / Date</th>
                        <th class="m-hide">Notice Time</th>
                        <th class="m-hide">Category</th>
                        <th>Submitted By</th>
                        <th>Status</th>
                        <th class="m-hide">Origin</th>
                        
                        <th class="hid">Action</th>
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
                              
                              
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                </td>
                              
                               
                              <td class="m-block qs-justify qs-subject" style="text-align: justify;" runat="server" id="FullSearch">
                                    <asp:Label class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Text='<%#Eval("QuestionText") %>' Style="color: black; font-size: 10pt;" Target="_blank"></asp:Label></aasp:Label>
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
                                <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>
                                
                                
                                  <td class="m-hide">
                                    <asp:Label ID="Label30" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("DeviceId"))==1?"Web":"Mobile App"%>' />
                                </td>
                                <td id="fullPrint" runat="server" class="hid">
                                    <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" CssClass="btn btn-custom" />
                                </td>
                                <td id="restrictedPrint" runat="server" visible="false">
                                    <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" CssClass="btn btn-custom" />
                                </td>
                               
                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
       
        
        
        
    </div>
</asp:Content>
