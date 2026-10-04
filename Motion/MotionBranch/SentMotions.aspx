<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SentMotions.aspx.cs" Inherits="MotionBranch.SentMotions" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     

   
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
        
}</script>

        <link href="Styles/MainStyles.css" rel="stylesheet" />
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
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
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
                    $("[id$=HidMemberId]").val(i.item.val);
                },
                minLength: 1
            });
          });

</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <br />
    
    <div class="container" style="padding:20px;color:black">
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
                                         <div class="col-md-2">
                                            <asp:Label ID="Label13" runat="server" CssClass="small-label" Text="Motion Week" for="MotionWeekCB"></asp:Label> 
                                         <asp:DropDownList ID="MotionWeekCB" ClientIDMode="Static" runat="server" class="form-control small-control">
                                         <asp:ListItem Selected="True" Value="0">Motion Week</asp:ListItem>
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
                                            <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="File No" for="FileNoTxt"></asp:Label> 
                                            <asp:TextBox ID="FileNoTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
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
                                        <div class="col-md-9" style="margin-top:5px;"></div>
                                         <div class="col-md-3" style="align-content:center;margin-top:10px">
                                                <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
                                                <asp:Button  class="btn btn-primary" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
                                            </div>

                                    </div>
  </div>
    <br />
    <div class="container">
  <div class="clearfix"></div>
 <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>	
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
            <th>MID</th>
            <th>M-File No</th>
            <th>Session Number</th>
            <th>Motion Type</th>
            <th>Subject Matter</th>
            <th>Notice No./Date</th>
            <th>Motion Week</th>
            <th>Motion Status</th>
            <th>Movers</th>
            <th>Action</th>
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Eval("MotionsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Eval("MotionsId")%>' />
                        </td>
                          <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Eval("FileNo")%>' />
                          
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionDesc")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                        </td>
                      
                        <td >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("MotionType")%>' />
                        </td>
                         <td style="text-align:justify">               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/NoticeMotionDetail.aspx?MotionId={0}")%>'><%#GetMinText(Eval("Description").ToString())%></asp:HyperLink>
                        </td>

                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                        </td>
                          <td >
                            <asp:Label ID="Label20" class="table-data" runat="server"  Text='<%#GetWeek(Convert.ToInt32(Eval("WeekId")))%>' />
                        </td>
                           <td >
                            <asp:Label ID="Label2" class="table-data" runat="server"  Text='<%#Eval("MotionStatus")%>' />
                        </td>
                         <td >
                            <asp:Label ID="Label6" class="table-data" runat="server"  Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                        </td>
                    
                        <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" CssClass="btn btn-primary"/>
                        </td>                     
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
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
                <asp:Button ID="Button1" runat="server" Text="Carry Forward" CssClass="btn btn-primary" OnClick="Button1_Click" />
                </div>
            </div>--%>
        <%--<div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:Button ID="MoveBtn" runat="server" Text="Move" CssClass="btn btn-primary" />
                </div>
            </div>--%>
            
        </div>
   <br /><br />
</asp:Content>