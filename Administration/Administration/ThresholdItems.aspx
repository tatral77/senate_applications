<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ThresholdItems.aspx.cs" Inherits="Administration.ThresholdItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />

            <div class="row">            
                <div class="col-md-4"><h4 style="font-weight:bold">THRESHOLD ITEMS</h4></div>
                
            </div>
<div class="row"> 
    <div class="col-md-12">
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>Item</th>
           <th>Main Item</th>
           <th>Category</th>
           <th>Current Balance</th>
            <th>Threshold Level</th>
     
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
                             <asp:HyperLink ID="HyperLink2" class="details-link" runat="server" Target="_blank" NavigateUrl='<%#Eval("MainItemId","~/ManageItems.aspx?MainItemId={0}")%>' Text='<%#Eval("ItemName") %>' />
                        </td>
                          <td>
                            <asp:HyperLink ID="HyperLink1" class="details-link" runat="server" Target="_blank" NavigateUrl='<%#Eval("MainItemId","~/ManageItems.aspx?MainItemId={0}")%>' Text='<%#Eval("MainItem") %>' />
                          
                        </td>
                         <td>
                            <asp:HyperLink class="details-link" ID="HyperLink3" runat="server" NavigateUrl='<%#Eval("CategoryId","~/ManageMainItems.aspx?CategoryId={0}")%>'><%#Eval("Category").ToString()%></asp:HyperLink>
                             
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Eval("CurrentBalance")%>' />
                             
                        </td>
        <td>
                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("ThresholdLevel")%>' />
                             
                        </td>
                       
                         
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
       </div>     
        </div>


</asp:Content>
