<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NoticeMotions.aspx.cs" Inherits="QuestionManagement.NoticeMotions" %>
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
 
    

    <div class="container">

  <div class="row">
            <div class="col-md-9">
               <h4> <label class="page-header">MOTIONS RECEIVED FROM NOTICE OFFICE</label></h4>
                </div>
       </div>
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
            <th>MID</th>
            <th>M-DN</th>
            <th>Session Number</th>
            <th>Motion Type</th>
            <th>Subject Matter</th>
            <th>Notice No./Date</th>
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
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Eval("MotionDiaryNo")%>' />
                          
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionDesc")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                        </td>
                      
                        <td >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("MotionType")%>' />
                        </td>
                         <td style="text-align:justify">               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/MotionDetail.aspx?MotionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
                        </td>

                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString()%>'></asp:Label>
                        </td>
                           <td >
                            <asp:Label ID="Label2" class="table-data" runat="server"  Text='<%#Eval("MotionStatus")%>' />
                        </td>
                          <td >
                            <asp:Label ID="Label6" class="table-data" runat="server"  Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                        </td>
                    
                        <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/PrintMotion.aspx?MotionId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>                     
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
      
        </div>
   <br /><br />
</asp:Content>
