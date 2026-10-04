<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SearchResolution.aspx.cs" Inherits="QuestionManagement.SearchResolution" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     

       <meta name="viewport" content="width=device-width, initial-scale=1">
   
    <script type="text/javascript">
        function clearTextBox() {
            $("#ResolutionDiary").val("");
            $("#ResolutionId").val("");
            $("#NoticeDiaryNo").val("");
            $("#KeywordsTxt").val("");
            if (window.QMSMembers) { window.QMSMembers.clear(); }
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #ResolutionTypeDDL, #ResolutionStatusDDL").each(function () { this.selectedIndex = 0; });
            $("[id$=ResolutionNoTxt]").val("");
            $("#DateFromTxt").val("");
            $("#DateToTxt").val("");
            $("[id$=FullTextCB], [id$=NonMuslim]").prop("checked", false);
        }
    </script>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/qmsmembers.js") %>' type="text/javascript"></script>
    <script>
        $(function () {
            QMSMembers.init({ service: '<%=ResolveUrl("~/Service.asmx/GetAllMembersByName") %>' });
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

        <%-- $(function () {
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
    <style type="text/css">
        .qs-head-tools { display: flex; align-items: center; gap: 8px; margin-left: auto; }
        .qs-applied { font-size: 12px; font-weight: 600; padding: 5px 10px; }
        .qs-more-toggle .badge { background: #1f6fc5; margin-left: 2px; }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <div class="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH RESOLUTION</span>
            <span class="qs-head-tools">
                <span class="label label-info qs-applied" id="qsApplied" style="display: none"></span>
                <button type="button" class="btn btn-default btn-sm qs-more-toggle" data-toggle="collapse" data-target="#qsMore" title="Show or hide the extra filters"><span class="glyphicon glyphicon-filter"></span> <span class="qs-more-text">More filters</span> <span class="badge qs-more-badge" style="display: none"></span></button>
                <button type="button" class="btn btn-default btn-sm" id="qsPanelToggle" title="Show or hide the search form"><span class="glyphicon glyphicon-chevron-up"></span> <span class="qs-panel-text">Hide search</span></button>
            </span>
        </div>
        <div class="panel-body" id="qsBody">
            <div class="row">
                <div class="col-md-3"><asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Resolution Diary No." for="ResolutionDiary"></asp:Label> <asp:TextBox   ID="ResolutionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /> </div>
                <div class="col-md-3"><asp:Label ID="Label18" runat="server" CssClass="small-label"  Text="Resolution ID" for="ResolutionId"></asp:Label> <asp:TextBox ID="ResolutionId"  ClientIDMode="Static" runat="server" CssClass="form-control small-control"/> </div>
                <div class="col-md-6"><asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control" ></asp:TextBox></div>                                  
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
                                            <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                                            
                                        </asp:DropDownList>
                                        </div>
                                         <div class="col-md-2">   
                                             <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>            
                                            <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server"  >
                                            
                                        </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Resolution Type" for="ResolutionTypeDDL"></asp:Label> 
                                            <asp:DropDownList ID="ResolutionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server" >
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
                                                <div class="col-md-2" style="margin-top:5px;"> <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label> 
                                                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control"/></div>
                                          <div class="col-md-2" style="margin-top:5px;"> <asp:Label ID="Label23" runat="server" CssClass="small-label" Text="Non-Muslim" for="FullTextCB"></asp:Label> 
                                                <asp:CheckBox ID="NonMuslim" runat="server" CssClass="form-control"/></div>
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
         <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Resolutions" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
          <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Motion Annual Report" NavigateUrl="~/ResolutionAnnualReport.aspx"/>
        </div>
        <asp:Panel id="pnlContents" runat = "server">   
 <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>	
<table class="table table-hover table-striped table-responsive qs-table">
    <thead class="thead-inverse">
    <tr>
    <th class="m-hide">Sr#</th>
     <th style="text-align:center" class="hid m-hide">Select
              <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
         </th>
            <th>RID</th>
            
            <th class="m-hide">Res-DN</th>
            <th>Session Number</th>
            <th class="m-hide">Resolution Type</th>
            <th style="max-width:50%;word-wrap:break-word">Subject Matter</th>
            <th class="m-hide">Notice No./Date</th>
            <th class="m-hide">Resolution Status</th>
            <th class="m-hide">Passing Date</th>
            <th>Movers</th>
            <th class="m-hide">Ministries</th>
         <th class="m-hide">Origin</th>
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
                         <td class="m-hide hid">
                             <asp:CheckBox ID="SelectCB" CssClass="form-control" runat="server"/>
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Eval("ResolutionsId")%>' />
                             <asp:HiddenField ID="HidResolutionId" runat="server" Value='<%#Eval("ResolutionsId")%>' />
                        </td>
                          <td style="text-align:center" class="m-hide">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Eval("ResolutionDiaryNo")%>' />
                          
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionNumber")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("AssemblySessionsId")%>' />
                        </td>
                      
                        <td class="m-hide">
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("ResType")%>' />
                        </td>
                         <td class="m-block qs-justify">               
                           <asp:HyperLink class="table-data" CssClass="printText" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("ResolutionsId","~/ResolutionDetail.aspx?ResolutionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
                        </td>

                        <td class="m-hide">
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                        </td>
                           <td class="m-hide">
                            <asp:Label ID="Label2" class="table-data" runat="server"  Text='<%#Eval("ResolutionStatus")%>' />
                        </td>
                         <td class="m-hide">
                            <asp:Label ID="Label20" class="table-data" runat="server"  Text='<%#GetDate(Convert.ToDateTime(Eval("PassedDate")))%>' />
                        </td>
                          <td >
                            <asp:Label ID="Label6" class="table-data" runat="server"  Text='<%#GetMembers(Convert.ToInt32(Eval("ResolutionsId")))%>' />
                        </td>
                          <td class="m-hide">
                            <asp:Label ID="Label24" class="table-data" runat="server"  Text='<%#GetMinistries(Convert.ToInt32(Eval("ResolutionsId")))%>' />
                        </td>
                         <td class="m-hide">
                                    <asp:Label ID="Label32" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("DeviceId"))==1?"Web":"Mobile App"%>' />
                                </td>
                        <td class="m-hide hid">
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("ResolutionsId","~/PrintResolution.aspx?ResolutionId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
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
                 <asp:Label ID="Label31"  runat="server" Text="Resolution Status" for="ChangeStatusDDL" CssClass="small-label" />
                 <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" ValidationGroup="StatusGroup" class="form-control small-control">
                   <asp:ListItem Selected="True" Value="0">Resolution Status</asp:ListItem>
                 </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="StatusGroup" Display="None" InitialValue="0" ControlToValidate="ChangeStatusDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21"  runat="server" Text="Status Date" for="ChangeStatusDDL" CssClass="small-label" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control" ValidationGroup="StatusGroup" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="StatusGroup" Display="None"  ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" Cssclass="btn btn-custom" Text="Change Status" OnClick="ChangeStatusBtn_Click" ValidationGroup="StatusGroup" />
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
   <br /><br />
    <script src='<%= ResolveUrl("~/Scripts/searchpanel.js") %>' type="text/javascript"></script>
    <script type="text/javascript">QSPanel.init({ key: 'resolution' });</script>
</asp:Content>