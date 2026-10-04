<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="UpcomingActions.aspx.cs" Inherits="EstablishmentASP.Reports.UpcomingActions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/MainStyles.css" rel="stylesheet" />
   <script src="../Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Styles/modern.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" />

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
      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h3 class="page-header">Attention Required</h3>
        </div>
        <div class="row">
            <h4 class="page-header">List of employees who will retire within 14 months</h4>
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
      <th>Employee Name</th>
      
      <th>Post Held</th>
       <th>Grade</th>       
          <th>Post Status</th>
         <th>Retirement Date</th>
        
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="SuperannuationLV" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("SystemUsersId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="font-weight:bold;color:rgb(17,30,108);" NavigateUrl='<%#Eval("SystemUsersId","~/Reports/Rpt_4_ProbationDetails.aspx?empid={0}")%>'><%#Eval("EmployeeName")%></asp:HyperLink>
                        </td>
                      
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Post")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Bps")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" class="table-data" Text='<%#Bind("EmployeeStatus")%>' />
                        </td>
                       
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#GetDate(Convert.ToDateTime(Eval("SuperannuationDate")))%>' />
                        </td>
                      
                      
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            
        </div>

        <div class="row">
            <h4 class="page-header">List of employees whose probation ending within 6 months</h4>
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
      <th>Employee Name</th>      
      <th>Post Held</th>
       <th>Grade</th>       
          <th>Post Status</th>
            <th>Probation Type</th>
         <th>Probation End Date</th>
        <th>Remarks</th>
        
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ProbationLV" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("SystemUsersId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="font-weight:bold;color:rgb(17,30,108);" NavigateUrl='<%#Eval("SystemUsersId","~/Reports/Rpt_4_ProbationDetails.aspx?empid={0}")%>'><%#Eval("EmployeeName")%></asp:HyperLink>
                        </td>
                      
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Post")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Bps")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" class="table-data" Text='<%#Bind("EmployeeStatus")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Bind("ProbationType")%>' />
                        </td>                      
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationEndDate")))%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label4" runat="server" class="table-data" Text='<%#Bind("Remarks")%>' />
                        </td>
                      
                      
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            
        </div>

        <div class="row">
            <h4 class="page-header">List of employees whose Contract/Adhoc/Re-Employment ending within 6 months</h4>
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
      <th>Employee Name</th>      
      <th>Post Held</th>
       <th>Grade</th>       
          <th>Post Status</th>
            <th>Employment Type</th>
         <th>End Date</th>
        <th>Remarks</th>
        
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="EmploymentLV" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("SystemUsersId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="font-weight:bold;color:rgb(17,30,108);" NavigateUrl='<%#Eval("SystemUsersId","~/Reports/Rpt_4_ProbationDetails.aspx?empid={0}")%>'><%#Eval("EmployeeName")%></asp:HyperLink>
                        </td>
                      
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Post")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Bps")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" class="table-data" Text='<%#Bind("EmployeeStatus")%>' />
                        </td>
                                           
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label4" runat="server" class="table-data" Text='<%#Bind("Remarks")%>' />
                        </td>
                      
                      
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            
        </div>


    </div>
</asp:Content>
