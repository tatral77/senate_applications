<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DuplicateQuestions.aspx.cs" Inherits="QuestionManagement.DuplicateQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
     <div class="row">
            <div class="col-md-9">
               <h4> <label class="page-header">DUPLICATE QUESTIONS</label></h4>
                </div>
       </div>
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>Notice Diary Number</th>
                    <th>Session Number</th>
           <th>Subject Matter</th>
        <th>Notice Date</th>
        <th>Notice Time</th>
       <th>Category</th>
        <th>Submitted By</th>
          <%--<th>Action</th>--%>
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="DuplicateLV" runat="server">
   
    <ItemTemplate>
    <tr style=<%#GetColour(Convert.ToInt32(Eval("Checked")))%>>
                        <td style=<%#GetColour(Convert.ToInt32(Eval("Checked")))%>>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Bind("QuestionsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                        </td>
                        <%--  <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>--%>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Bind("SessionNumber")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                        </td>
                       <%--  <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>--%>
                         
                        <td style="text-align:justify">               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/NoticeQuestionDetails.aspx?QuestionsId={0}")%>'><%#Eval("QuestionText").ToString()%></asp:HyperLink>
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
                      <%-- <td>
                            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Not Duplicate" CommandArgument='<%#Bind("QuestionsId")%>' />
                        </td>   --%>                
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
    </div>
</asp:Content>
