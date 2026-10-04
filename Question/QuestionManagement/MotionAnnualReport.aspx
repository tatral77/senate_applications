<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MotionAnnualReport.aspx.cs" Inherits="QuestionManagement.MotionAnnualReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
        .style2
        {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
            width: 69px;
        }
        .style3
        {
            width: 69px;
        }
    </style>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script>
      
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });

          
         
        });

$(document).ready(function(){
    $(this).on("hide.bs.collapse", function () {
    $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-down"></span>');
  });
    $(this).on("show.bs.collapse", function () {
    $(this).find(".abc").html('<span class="glyphicon glyphicon-collapse-up"></span>');
  });
});
      
         $(function () {
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
          });
        function PrintPanel() {
           var panel = document.getElementById("<%=pnlContents.ClientID %>");
           var printWindow = window.open('', '', 'height=400,width=800');
           printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
           printWindow.document.write('</head><body >');
           printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Questions Branch</u></div><br>');
            printWindow.document.write('<div style="font-size:large;text-align:center;font-size:medium;"><u>Motions</u></div><br>');
           printWindow.document.write(panel.innerHTML);
           printWindow.document.write('</body></html>');
           printWindow.document.close();
           setTimeout(function () {
               printWindow.print();
           }, 500);
           return false;
       }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "Motions", fallback: PrintPanel });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <br />
    
    <div class="container regularDiv" style="padding:20px;color:black;">
            <div class="row">            
                <div class="col-md-4"><h4>SEARCH MOTION</h4></div>
                <div class="col-md-2"><asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Motion Diary No." for="MotionDiary"></asp:Label> <asp:TextBox   ID="MotionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /> </div>
                <div class="col-md-2"><asp:Label ID="Label18" runat="server" CssClass="small-label"  Text="Motion ID" for="MotionId"></asp:Label> <asp:TextBox ID="MotionId"  ClientIDMode="Static" runat="server" CssClass="form-control small-control"/> </div>
                <div class="col-md-4"><asp:Label ID="Label17" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" class="form-control small-control" ></asp:TextBox></div>                                  
            </div>
    
                                    <div class="row">
                                         <div class="col-md-4">
                                             <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="MemberNameTxt"></asp:Label>
                                            <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /> 
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
                                            <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Motion Type" for="MotionTypeDDL"></asp:Label> 
                                            <asp:DropDownList ID="MotionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server" >
                                            <asp:ListItem Selected="True" Value="0">Motion Type</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>                                
                                                                        
                                 </div>
                                    <div class="row top-buffer">
                                         <div class="col-md-3">
                                            <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Motion Status" for="MotionStatusDDL"></asp:Label> 
                                         <asp:DropDownList ID="MotionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                                            <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
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
                                        <div class="col-md-7"></div>
                                         <div class="col-md-3" style="margin-top:10px">
                                             <br />
                                                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
                                                <asp:Button  class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
                                            </div>

                                    </div>
  </div>
    <br />
    <div class="container">
  <div class="clearfix"></div>
         <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Motions" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:Panel id="pnlContents" runat = "server">   
 <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>	
<table class="table table-hover table-striped table-responsive" style="border-collapse:collapse;">
    <thead class="thead-inverse">
    <tr>
    <%--<th>Sr#</th>--%>
         <%--   <th>MID</th>
             <th style="text-align:center">Select
              <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckAll_CheckedChanged"></asp:CheckBox>
         </th>--%>
          <%--  <th>M-DN</th>
            <th>Session Number</th>--%>
            <th style="width:20%">Motion Type</th>
            <th style="width:40%" >Subject Matter</th>
            <th style="width:20%">Date</th>
            <th style="width:20%">Motion Status</th>
          <%--  <th style="width:150px;">Movers</th>
             
            <th class="hid">Action</th>--%>
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1" runat="server">
   
    <ItemTemplate>
    <tr>
                     <%--   <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Eval("MotionsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Eval("MotionsId")%>' />
                        </td>
                          <td style="text-align:center">
                            <asp:CheckBox ID="SelectCB" runat="server"> </asp:CheckBox>
                          </td>
                          <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Eval("MotionDiaryNo")%>' />
                          
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionDesc")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                        </td>
                      --%>
                        <td style="border-bottom:none;border-top:none;margin-bottom:20px; text-align: center">
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("MotionType")%>' />
                        </td>
                         <td style="border-bottom:none;border-top:none;margin-bottom:20px; text-align:justify;padding-right:10px;padding-left:10px;">               
                           <asp:HyperLink CssClass="printText" class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/MotionDetail.aspx?MotionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
                        </td>

                        <td style="border-bottom:none;border-top:none;margin-bottom:20px; text-align: center">
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                        </td>
                           <td style="border-bottom:none;border-top:none;margin-bottom:20px; text-align: center">
                            <asp:Label ID="Label2" class="table-data" runat="server"  Text='<%#Eval("MotionStatus")%>' />
                        </td>
                        <%--  <td >
                            <asp:Label ID="Label6" class="table-data" runat="server"  Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                        </td>
                       
                    
                        <td class="hid">
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>                    --%> 
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            </asp:Panel>
             <%--<div class="row img-rounded" style="padding-bottom:5px;background-color:#086623;">
               <div class="col-md-3"></div>
               
            <div class="col-md-4">
                 <asp:Label ID="Label31"  runat="server" Text="Motion Status" for="ChangeStatusDDL" style="color:#fff;" />
                 <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" ValidationGroup="StatusGroup" class="form-control small-control">
                   <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                 </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="StatusGroup" Display="None" InitialValue="0" ControlToValidate="ChangeStatusDDL"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21"  runat="server" Text="Status Date" for="ChangeStatusDDL"  style="color:#fff;" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control" ValidationGroup="StatusGroup" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="StatusGroup" Display="None"  ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" Cssclass="btn btn-custom" Text="Change Status" OnClick="ChangeStatusBtn_Click" ValidationGroup="StatusGroup" />
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
   <br /><br />
</asp:Content>
