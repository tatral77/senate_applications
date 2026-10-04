<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListByMovement.aspx.cs" Inherits="QuestionManagement.ListByMovement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    
    <div class="container">
  <div class="clearfix"></div>
 <div class="col-md-12">
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>Question ID</th>
           <th>Session No.</th>
           <th>Group</th>
        <th>Subject Matter</th>
        <th>Notice Date</th>
        <th>Notice Time</th>
       <th>Category</th>
        <th>Submitted By</th>
         <th>Status</th>
        <th>Carry Fwd</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll_CheckedChanged" /></th>
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
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Bind("QuestionsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Bind("SessionNumber")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                        </td>
                         <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>
                         
                        <td>               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/QuestionDetails.aspx?QuestionsId={0}")%>'><%#GetMinText(Eval("QuestionText").ToString())%></asp:HyperLink>
                        </td>
                        
                         <td>                           
                            
                         <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                        </td>
                         <td>                           
                            
                         <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                        </td>
        
                        <td >
                            <asp:Label ID="Label5" class="table-data"  runat="server"  Text='<%#Bind("QuestionCategory")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="descriptionLabel"  class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#(Convert.ToInt32(Eval("IsCarryFwd"))==1)?"Yes":"No"%>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="SelectCB" runat="server"  />
                        </td>
                        <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>                     
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
    
            <div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:DropDownList ID="SessionMovementDDL" runat="server" CssClass="form-control">
                   
                </asp:DropDownList>
                </div>
                <div class="col-md-1">
                <asp:Button ID="Button1" runat="server" Text="Carry Forward" Cssclass="btn btn-custom" OnClick="Button1_Click" />
                </div>
            </div>
     
            
        </div>
        </div>
   <br /><br />

</asp:Content>
