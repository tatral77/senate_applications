<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangeQuestionsStatus.aspx.cs" Inherits="QuestionManagement.ChangeQuestionsStatus" %>
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

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <br />
    
    <div class="container regularDiv" style="padding:20px;color:black">
            <div class="row">            
                <div class="col-md-4"><h4 style="color:#000;">SEARCH QUESTIONS</h4></div>
                <div class="col-md-2"><asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Question Diary No." for="QuestionDiary"></asp:Label> <asp:TextBox   ID="QuestionDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" /> </div>
                <div class="col-md-2"><asp:Label ID="Label18" runat="server" CssClass="small-label"  Text="Question ID" for="QuestionId"></asp:Label> <asp:TextBox ID="QuestionId"  ClientIDMode="Static" runat="server" CssClass="form-control small-control"/> </div>
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
                                            <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                                            
                                        </asp:DropDownList>
                                        </div>
                                         <div class="col-md-2">   
                                             <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>            
                                            <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                                            
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
                                         <div class="col-md-4">
                                            <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Question Status" for="QuestionStatusDDL"></asp:Label> 
                                         <asp:DropDownList ID="QuestionStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                                            <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                                         </asp:DropDownList>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label> 
                                            <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label> 
                                         <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
                                        </div>                            
                                   </div>
                                    <div class="row top-buffer">
                                        <div class="col-md-9" style="margin-top:5px;"></div>
                                         <div class="col-md-3" style="align-content:center;margin-top:10px">
                                                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
                                                <asp:Button  class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
                                            </div>

                                    </div>
  </div>
    <br />
    <div class="container">
  <div class="clearfix"></div>
 <%--<div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>--%>	
        <div class="row" style="margin-bottom:30px;">
            <div class="col-md-2">
                <asp:Label ID="Label31"  runat="server" Text="Status" for="ChangeStatusDDL" />
                 <asp:DropDownList ID="ChangeStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                   <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label21"  runat="server" Text="Status Date" for="ChangeStatusDDL" />
                <asp:TextBox ID="StatusDateTxt" class="form-control small-control date js-date" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="ChangeStatusBtn" runat="server" Cssclass="btn btn-custom" Text="Change Status" OnClick="ChangeStatusBtn_Click" />
            </div>
        </div>
        
          <asp:Label ID="questionslbl" class="table-data" runat="server" Text='' />
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>QID</th>
           <th>Q-DN</th>
           <th>Session Number</th>
           <th>Group</th>
        <th>Subject Matter</th>
        <th>Notice Date</th>
        <th>Notice Time</th>
       <th>Category</th>
        <th>Submitted By</th>
         <th>Status</th>
      <%--  <th>Carry Fwd</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll_CheckedChanged" /></th>--%>
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
                             <asp:CheckBox ID="SelectCB" runat="server"/>
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Bind("QuestionsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                        </td>
                          <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Bind("SessionNumber")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                        </td>
                         <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>
                         
                        <td style="text-align:justify">               
                          <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/QuestionDetails.aspx?QuestionsId={0}")%>'><%#SelectText(Eval("QuestionText").ToString())%></asp:HyperLink>
                        </td>
                        
                         <td>                           
                            
                         <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                        </td>
                         <td>                           
                            
                         <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                        </td>
        
                        <td >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("QuestionCategory")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                            <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                        </td>
                      <%--   <td>
                            <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#(Convert.ToInt32(Eval("IsCarryFwd"))==1)?"Yes":"No"%>' />
                        </td>--%>
                      <%--  <td>
                            <asp:CheckBox ID="SelectCB" runat="server"  />
                        </td>--%>
                        <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
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
