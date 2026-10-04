<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SentBills.aspx.cs" Inherits="Notice.SentBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <div class="container-fluid qs-results">
  <div class="clearfix"></div>
 	
<table class="table table-hover table-striped table-responsive qs-table">
    <thead class="thead-inverse">
    <tr>
    <th class="m-hide">Sr#</th>
          <th>QID</th>
           <th>Diary No</th>
             <th>Notice Date</th>
        <th>Notice Time</th>
           <th>Session Number</th>
           <th>Subject Matter</th>
       
       <th>Category</th>
        <th>Submitted By</th>
         <th>Status</th>
        <th>Origin</th>
        <th>Action</th>
       
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1" OnItemDeleting="ListView1_ItemDeleting" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td class="m-hide">
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data"  runat="server" Text='<%#Bind("BillsId")%>' />
                             <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("BillsId")%>' />
                        </td>
                          <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("NoticeDiaryNo")%>' />
                          
                        </td>
          <td>                           
                            
                         <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                        </td>
                         <td>                           
                            
                         <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label4" class="table-data"  runat="server" Text='<%#Bind("AssemblySessions.SessionNumber")%>' />
                             <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("AssemblySessionsId")%>' />
                        </td>
                     
                         
                        <td class="m-block qs-justify" style="text-align:justify">               
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#Eval("BillsId","~/BillDetails.aspx?BillsId={0}")%>'><%#Eval("BillTitle")%></asp:HyperLink>
                            
                        </td>
                        <td >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("BillCategories.Description")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("MoverNames")%>'></asp:Label>
                        </td>
                        <td>
                                    <asp:Label ID="Label30" class="table-data" runat="server" Text='<%#Convert.ToInt32(Eval("DeviceId"))==1?"Web":"Mobile App"%>' />
                                </td>
                        <td>
                               <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                              <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" NavigateUrl='<%#Eval("BillsId","~/PrintBill.aspx?BillsId={0}")%>' Text="Print" CssClass="btn btn-custom" />
                        </td>
       
                                            
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
        </div>
</asp:Content>
