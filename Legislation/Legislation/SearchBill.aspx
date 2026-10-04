<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchBill.aspx.cs" Inherits="Legislation.SearchBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container regularDiv" style="padding: 20px; color: black">
        <div class="row">
            <div class="col-md-4">
                <h4 style="color: #000;">SEARCH BILL</h4>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Bill Diary No." for="BillDiary"></asp:Label>
                <asp:TextBox ID="BillDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Bill ID" for="BillId"></asp:Label>
                <asp:TextBox ID="BillIdTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label1" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label>
                <asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox>
            </div>
        </div>

        <div class="row top-buffer">
            <div class="col-md-4">
                <label class="small-label">Members</label>
                <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetEmployeeName") %>" data-ids="#<%= HidMemberId.ClientID %>" data-names="#<%= MemberNameTxt.ClientID %>" data-placeholder="Type a name to add...">
                    <span class="member-chips"></span>
                    <input type="text" class="member-input" autocomplete="off" />
                </div>
                <asp:TextBox ID="MemberNameTxt" runat="server" Style="display: none" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
            <div class="col-md-4">
                <label class="small-label">Ministers (MNA)</label>
                <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetMinisters") %>" data-ids="#<%= HidMinisterId.ClientID %>" data-names="#<%= MinisterNameTxt.ClientID %>" data-placeholder="Type a name to add...">
                    <span class="member-chips"></span>
                    <input type="text" class="member-input" autocomplete="off" />
                </div>
                <asp:TextBox ID="MinisterNameTxt" runat="server" Style="display: none" />
                <asp:HiddenField ID="HidMinisterId" runat="server" />
            </div>

            <div class="col-md-4">
                <label class="small-label">Divisions / Ministries</label>
                <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>" data-ids="#<%= HidDivisionId.ClientID %>" data-names="#<%= DivisionTxt.ClientID %>" data-placeholder="Type a name to add...">
                    <span class="member-chips"></span>
                    <input type="text" class="member-input" autocomplete="off" />
                </div>
                <asp:TextBox ID="DivisionTxt" runat="server" Style="display: none" />
                <asp:HiddenField ID="HidDivisionId" runat="server" />

            </div>
        </div>
        <div class="row top-buffer">
              <div class="col-md-2">
                <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Parliamentary Year" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ParliamentaryYearsDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                     <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
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
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Category" for="CategoryDDL"></asp:Label>
                <asp:DropDownList ID="BillCategoryDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Category</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label3" runat="server" CssClass="small-label" Text="Originated In" for="CategoryDDL"></asp:Label>
                <asp:DropDownList ID="OriginatedInDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                    <asp:ListItem Selected="True" Value="0">Originated In</asp:ListItem>
                    <asp:ListItem Value="1">Senate</asp:ListItem>
                    <asp:ListItem Value="2">National Assembly</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
          <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Bill Status" for="BillStatusDDL"></asp:Label>
                <asp:DropDownList ID="BillStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Bill Status</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-2">
                <asp:Label ID="Label5" runat="server" CssClass="small-label" Text="Bill Type" for="BillStatusDDL"></asp:Label>
                <asp:DropDownList ID="BillTypeDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Bill Type</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-3">
                <asp:Label ID="Label6" runat="server" CssClass="small-label" Text="Concerned Committee" for="BillStatusDDL"></asp:Label>
                <asp:DropDownList ID="CommitteeDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Committee</asp:ListItem>
                </asp:DropDownList>
            </div>
        
        <div class="col-md-3">
                      <asp:Label ID="Label21" runat="server" CssClass="small-label" Text="Committee Recomendation:" for="BillStatusDDL"></asp:Label>
                    <asp:DropDownList ID="CommitteeRecomendationDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">Ammended By Standing Committee</asp:ListItem>
                        <asp:ListItem Value="2">May be Passed as Introduced in the House</asp:ListItem>
                         <asp:ListItem Value="3">Passed without sending to Committee</asp:ListItem>
                    </asp:DropDownList>
                </div>
</div>

        <div class="row top-buffer">

            <div class="col-md-3">
                <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="File Number" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="FileNumberTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="NoticeDateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="NoticeDateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label4" runat="server" CssClass="small-label" Text="Presented in House on:" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="HousePresentDateTxt" runat="server" ClientIDMode="Static" class="form-control small-control datepicker"></asp:TextBox>
            </div>
        </div>

        <div class="row top-buffer">
            <div class="col-md-2" style="margin-top: 5px;">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>


            <div class="col-md-12" style="text-align: right">
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox(); return false;" />
                <asp:Button class="btn btn-custom" ID="Button3" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
                <asp:Button class="btn btn-custom" ID="ExportPdfBtn" runat="server" Text="Export PDF" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="return ExportPdf('Bill-Search', 'landscape');" />
                <asp:HyperLink class="btn btn-custom" ID="HyperLink1" runat="server" Text="Annual Report" NavigateUrl="BillAnnualReport.aspx" />
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
            </div>
        </div>

    </div>
     <div class="container">
        <%--<div class="clearfix"></div>
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Questions" OnClientClick="return PrintPanel();" />
                <asp:HyperLink class="btn btn-primary" ID="AnnualReportBtn" runat="server" Text="Annual Report" NavigateUrl="QuestionAnnualReport.aspx" />--%>
        <asp:Panel ID="pnlContents" runat="server">
            <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>

            <table class="table table-hover table-striped table-responsive" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <%--<th style="text-align:center" class="hid">Select
              <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
         </th>--%>
                         <th>File Number</th>
                        <th>BID</th>
                       
                        <th >Notice Date</th>
                        <th>Parliamentary Year</th>
                        <th>Session Number</th>
                        <th>Bill Title</th>
                        <th>Bill Category</th>
                     <%--   <th >Remarks</th>--%>
                        <th>Bill Status</th>
                       
                       <%-- <th class="hid">Action</th>--%>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server">

                        <ItemTemplate>
                            <tr style='<%#(Convert.ToInt32(Eval("HouseTypesId"))==1)?"color:red":"color:green"%>'>
                                <td>

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                             <%--   <td class="hid">
                                    <asp:CheckBox ID="SelectCB" CssClass="form-control" runat="server" />
                                </td>--%>
                                  <td style="text-align: center">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("FileNumber") %>' />

                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("BillsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("BillsId")%>' />
                                </td>
                              
                                <td style="text-align: center" class="hid">
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate"))) %>' />

                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("ParliamentaryYears.ParliamentaryYear")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("ParliamentaryYearID")%>' />
                                </td>
                                 <td style="text-align: center">
                                    <asp:Label ID="Label17" class="table-data" runat="server" Text='<%#Bind("AssemblySessions.SessionNumber")%>' />
                                </td>
                                <%-- <td>
                                    <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#Eval("Division")%>' />
                                </td>--%>
                                <td style="text-align: justify;min-width:400px !important;" runat="server" ID="FullSearch">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black;font-size:10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("BillsId").ToString(),Eval("HouseTypesId").ToString())%>'><%#SelectText(Eval("BillTitle").ToString())%></asp:HyperLink>
                                </td>
                               <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("BillCategories.Description")%>' />
                                </td>
                             <%--   <td>
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                                </td>--%>
                                <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("BillStatuses.Description")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                </td>
                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
        </asp:Panel>
      <%--  <div class="row img-rounded" style="padding-bottom: 5px; background-color: #4a9fe4;">
            <div class="col-md-3"></div>

            <div class="col-md-4">
                <asp:Label ID="Label31" runat="server" Text="Question Status" for="ChangeStatusDDL" Style="color: #fff;" />
                <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21" runat="server" Text="Status Date" for="ChangeStatusDDL" Style="color: #fff;" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" Cssclass="btn btn-primary" Text="Change Status" OnClick="ChangeStatusBtn_Click" />
            </div>
        </div>--%>
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
            $(".datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 99999999999999);
                    }, 0);
                },
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: 0,
                onSelect: function (dateText, inst) { }
            });
        });
        //$('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
        //    template: false,
        //    showInputs: false,
        //    defaultTime: false,
        //    minuteStep: 5
        //});



        //$(document).ready(function () {
        //    $('.date').mask('00/00/0000');
        //});


        

        
        




    </script>
</asp:Content>

