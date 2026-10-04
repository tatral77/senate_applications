<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingsProfile.aspx.cs" Inherits="EstablishmentASP.Reports.TrainingsProfile" %>
<!DOCTYPE html>
<head>
    <title></title>
     <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="../Styles/MainStyles.css" rel="stylesheet" />
    <link href="../Styles/modern.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
     <form runat="server">   
         <br /><br />
<div class="container-fluid"> <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />      </div>         
<asp:Panel id="pnlContents" runat = "server">
<div class="regularDiv report-ui">   
    <div class="container-fluid">
    <h4 class="page-header">
<asp:Label ID="FName" runat="server"></asp:Label>
</h4>
    <table class="table table-data table-condensed" style="width:700px">
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
      
        <%--<div class="row">
<div class="col-md-10">
    <hr />
      <h4>Educational Qualification:</h4>
<table class="table table-striped table-condensed table-data rpt-fixed">
    <thead>
<tr>
<th style="width:4%">Sr#</th>
<th style="width:13%">Degree Level</th>
<th style="width:15%">Discipline</th>
<th style="width:15%">Institution</th>
<th style="width:8%">Country</th>
<th style="width:13%">City</th>
<th style="width:8%">Completion Year</th>
<th style="width:8%">Grade</th>
<th style="width:8%">CGPA</th>
<th style="width:8%">Percentage</th>



</tr>
        </thead>
    <tbody>
<asp:ListView ID="EmpQualificationLv" runat="server" >
    
    <ItemTemplate>
        <tr>
    <td> <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%# GetDegreeLevel(Convert.ToInt32(Eval("Degree_Level_Id")))%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("Degree_Obtained") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("Institution_Name") %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("Country_Id")))%>'></asp:Label></td>
<td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%# GetCity(Convert.ToInt32(Eval("City_Id")))%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label1" runat="server" Text='<%#Bind("Completion_Year")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label3" runat="server" Text='<%#Bind("Grade")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label4" runat="server" Text='<%# Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label8" runat="server" Text='<%# Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>'></asp:Label></td>
    </tr>
    </ItemTemplate>
     
</asp:ListView>
    </tbody>    
    </table>

</div>
      
        
     </div>--%>  
    
   
<div class="row">
      
        <div class="col-md-10">
            <hr />
            <h4>Trainings:</h4>

<table class="table table-striped table-condensed table-responsive table-data rpt-fixed">
<thead>
<tr>
<th style="width:4%">Sr#</th>
<th style="width:25%">Course Name</th>
<th style="width:13%">Course Type</th>
<th style="width:11%">Deg/Dip/Cert</th>
<th style="width:13%">Institution</th>
<th style="width:7%">Country</th>

<th style="width:8%">From</th>
<th style="width:8%">To</th>
<th style="width:11%">Sponsored By</th>


</tr>
</thead>
<tbody>
   
    <asp:ListView ID="EmpCoursesLv" runat="server">

    <ItemTemplate>
 <tr>
    
     
     <td><asp:Label ID="Label6" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="PassportNumber" class="table-data" runat="server" Text='<%#Bind("CourseName")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label7"  class="table-data" runat="server" Text='<%#GetCourseType(Convert.ToInt32(Eval("CourseTypeId")))%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label9"  class="table-data" runat="server" Text='<%#Bind("DegDipCert")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="IssuePlace" class="table-data" runat="server" Text='<%#Bind("InstitutionName") %>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label10" class="table-data" runat="server" Text='<%# GetCountry1(Convert.ToInt32(Eval("CountryId")))%>'></asp:Label></td>

    <td class="itemLeft"><asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Bind("FromDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label12" class="table-data" runat="server" Text='<%#Bind("ToDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label13" class="table-data" runat="server" Text='<%#Bind("SponsoredBy")%>'></asp:Label></td>
   </tr>
  

</ItemTemplate>
</asp:ListView>
    </tbody></table>
            </div>
    </div>
         </div>
    </div>
</asp:Panel>
  <%--<div class="row">      
        <div class="col-md-10">
            <hr />
            <h4>Posting Details:</h4>
<table class="table table-hover table-striped table-condensed table-data table-responsive">
    <thead>
<tr>
<th>Sr#</th>
<th>Post</th>
<th>BPS</th>
<th>Branch</th>
<th>From Date</th>
<th>To Date</th>
<th>Working</th>
<th>Remarks</th>
</tr>
   
<asp:ListView ID="EmpPostingLv" runat="server">
 <ItemTemplate>
<tr>    
   
     <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPSDesc") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("Branch") %>'></asp:Label></td>
    <td><asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("Date_From"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("Date_To"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label4" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("Working"))=="1")?"Yes":"No"%>' /></td>
    <td><asp:Label ID="Label3" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
    
  </tr>

</ItemTemplate>
    </asp:ListView>
    </table>







            </div>
  </div>--%>
        
        
 <%--<div class="row">      
        <div class="col-md-10">
            <hr />
            <h4>Posting Summary:</h4>

<table class="table table-striped table-condensed table-responsive table-data rpt-fixed">
<thead>
<tr>

<th style="width:10%">Sr#</th>
<th style="width:41%">Branch Name</th>
<th style="width:18%">Years</th>
<th style="width:31%">Months</th>




</tr>
        </thead>
   <tbody>
<asp:ListView ID="EmpPostingSumLv" runat="server">

 <ItemTemplate>
<tr>    
    
     <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("BranchName")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("TotalYears") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("TotalMonths") %>'></asp:Label></td>
  
   </tr>

</ItemTemplate>   
    </asp:ListView>  
</tbody>
    </table>
  </div>
           
</div>--%>

   

      <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
       function PrintPanel() {
           return HRMPrint.print("<%=pnlContents.ClientID %>", { title: ("TRAINING PROFILE - " + ((document.getElementById("<%=FName.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
       }
       function ExportPdf() {
           return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: ("TRAINING PROFILE - " + ((document.getElementById("<%=FName.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
       }
    </script> 
             </form>
</body>
