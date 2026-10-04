<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SeatingPlanList.aspx.cs" Inherits="Notice.SeatingPlanList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">Members Seating Plan</div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    
            <th>Seat Number</th>
            <th>English Name</th>
            <th>Urdu Name</th>
           
            <th>Updated On</th>
            <th>Updated By</th>
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1" runat="server">
   
    <ItemTemplate>
    <tr style='<%#Convert.ToString("background-color:" + Eval("SeatColour"))%>'>
                         
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("SeatNumber")%>'></asp:Label>
                        </td>
                         <td style='<%#Convert.ToString("background-color:" + Eval("SeatColour"))%>'>
                            <asp:Label ID="Label4"   runat="server" style="text-align:left" Text='<%#Eval("MemberEnglishName")%>' />
                        </td>
                      
                        <td style="text-align:right;<%#Convert.ToString("background-color:" + Eval("SeatColour"))%>">
                            <asp:Label ID="Label5"   runat="server"  Text='<%#Bind("MemberUrduName")%>' />
                        </td>
                      
                          <td >
                            <asp:Label ID="Label6" class="table-data" runat="server"  Text='<%#Eval("UpdatedOn")%>' />
                        </td>
                         <td >
                            <asp:Label ID="Label1" class="table-data" runat="server"  Text='<%#Eval("UpdatedBy")%>' />
                        </td>
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            </div>
        </div>
    </div>
</asp:Content>
