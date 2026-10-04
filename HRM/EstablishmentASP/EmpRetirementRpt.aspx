<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpRetirementRpt.aspx.cs" Inherits="EstablishmentASP.EmpRetirementRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
      <asp:Button class="btn btn-custom page-header" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
     <asp:Panel ID="pnlContents" runat="server"> 
    <div class="container-fluid">
<div class="row">
    <div class="col-md-12">
    <h4 class="page-header">
<asp:Label ID="FName" runat="server" style="text-decoration:underline;"></asp:Label>
</h4>
    <table class="table table-data table-responsive" style="width:8in">
         <tr>
            <td><label class="control-lbl-sm" for="title">Qualification:</label></td>
            <td><asp:Label ID="QualificationLbl" runat="server"></asp:Label></td>
      </tr>
      <tr>
            <td><label class="control-lbl-sm" for="title">Date of Birth:</label></td>
            <td><asp:Label ID="DOB" runat="server"></asp:Label></td>
      </tr>
        <tr>
            <td><label class="control-lbl-sm" for="title">Age:</label></td>
            <td><asp:Label ID="Age" runat="server"></asp:Label></td>
      </tr>
          
           <tr>
            <td>
                <label class="control-lbl-sm" for="title">Current Designation:</label></td>
            <td><asp:Label ID="CurrentDesignation" runat="server"></asp:Label></td>
           </tr>

          <tr>
            <td><label class="control-lbl-sm" for="title">Current BPS:</label></td>
            <td><asp:Label ID="bps" runat="server"></asp:Label></td>
           </tr>
       
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Employee Branch:</label></td>
            <td><asp:Label ID="CurrentBranch" runat="server"></asp:Label></td>
         </tr>

        <tr>
            <td>
                <label class="control-lbl-sm" for="title">Employee Status:</label></td>
            <td><asp:Label ID="EmployeeStatus" runat="server"></asp:Label></td>
        </tr>
        
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Govt Service Start Date:</label></td>
           <td><asp:Label ID="GovtServiceStartDate" runat="server"></asp:Label></td>
         </tr>

          <tr>
            <td>
                <label class="control-lbl-sm" for="title">Senate Service Start Date:</label></td>
         <td>
                 <asp:Label ID="SenateServiceStartDate" runat="server"></asp:Label></td>
         </tr>
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Total Govt Service:</label></td>
         <td>
                 <asp:Label ID="GovtService" runat="server"></asp:Label></td>
         </tr>
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Total Service in Senate:</label></td>
         <td>
                 <asp:Label ID="HouseService" runat="server"></asp:Label></td>
         </tr>
        <tr>
            <td>
                <label class="control-lbl-sm" for="title">Superanuation Date:</label></td>
         <td>
                 <asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td>
         </tr>
        
        
</table>
        </div>
    </div>
        </div>
         </asp:Panel>
      <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script>
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });
        });
           function PrintPanel() {
               return HRMPrint.print("<%=pnlContents.ClientID %>", {});
           }
           function ExportPdf() {
               return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", {});
           }
      
</script>
</asp:Content>
