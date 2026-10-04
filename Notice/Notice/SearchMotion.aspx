<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchMotion.aspx.cs" Inherits="QuestionManagement.SearchMotion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function clearTextBox() {
            $("#NoticeDiary, #MotionId, #KeywordsTxt, #DateFromTxt, #DateToTxt").val("");
            $("[data-chips]").each(function () { var c = $(this).data("chips"); if (c) { c.clear(); } });
            $("#FromAssemblySessionDDL, #ToAssemblySessionDDL, #MotionTypeDDL, #MotionStatusDDL").each(function () { this.selectedIndex = 0; });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-search"></span> SEARCH MOTION</span>
            <button type="button" class="btn btn-default btn-sm visible-xs qs-more-toggle" data-toggle="collapse" data-target="#qsMore"><span class="glyphicon glyphicon-filter"></span> More filters</button>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="NoticeDiary">Notice Diary No.</label>
                    <asp:TextBox ID="NoticeDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="small-label" for="MotionId">Motion ID</label>
                    <asp:TextBox ID="MotionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
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
                    <label class="small-label" for="MotionTypeDDL">Motion Type</label>
                    <asp:DropDownList ID="MotionTypeDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Motion Type</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="MotionStatusDDL">Motion Status</label>
                    <asp:DropDownList ID="MotionStatusDDL" ClientIDMode="Static" class="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Motion Status</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="DateFromTxt">From Notice Date</label>
                    <asp:TextBox ID="DateFromTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-4 col-sm-6">
                    <label class="small-label" for="DateToTxt">To Notice Date</label>
                    <asp:TextBox ID="DateToTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
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
 	
<table class="table table-hover table-striped table-responsive qs-table">
    <thead class="thead-inverse">
    <tr>
    <th class="m-hide">Sr#</th>
            <th>MID</th>
            <th>Notice No./Date</th>
            <th class="m-hide">Session Number</th>
            <th class="m-hide">Motion Type</th>
            <th style="width:50%">Subject Matter</th>
            <th>Motion Status</th>
            <th>Movers</th>
            <th>Action</th>
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
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Eval("MotionsId")%>' />
                            <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Eval("MotionsId")%>' />
                        </td>
                         
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + ((DateTime)Eval("NoticeDiaryDate")).ToString("dd/MM/yyyy")%>'></asp:Label>
                        </td>
                         <td class="m-hide" style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Eval("SessionDesc")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Eval("SessionNumber")%>' />
                        </td>
                      
                        <td class="m-hide" >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("MotionType")%>' />
                        </td>
                         <td class="m-block qs-justify" style="text-align:justify">               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/MotionDetail.aspx?MotionId={0}")%>'><%#SelectText(Eval("Description").ToString())%></asp:HyperLink>
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
</asp:Content>
