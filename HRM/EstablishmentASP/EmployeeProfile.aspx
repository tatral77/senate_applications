<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="EstablishmentASP.EmployeeProfile" %>
<!DOCTYPE html>
<head>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <link href="Styles/modern.css" rel="stylesheet" />
    <style type="text/css">
        body { background: #f3f7fc; color: #3b4a5e; }
        .pf-page { max-width: 1120px; margin: 0 auto; padding: 0 16px 30px; }
        .pf-bar { display: flex; flex-wrap: wrap; gap: 8px; justify-content: flex-end; padding: 16px 0 12px; }
        .pf-bar .btn { margin: 0; border-radius: 999px; padding: 6px 20px; font-weight: 600; }
        .pf-bar .btn-print { background: #fff !important; border: 1px solid #b9d3ef !important; color: #2563a8 !important; }
        .pf-bar .btn-pdf { background: #e8f2fd !important; border: 1px solid #b9d3ef !important; color: #1f5a9e !important; }
        .pf-bar .btn:hover { background: #d9eafb !important; box-shadow: none; }

        .pf-hero { display: flex; align-items: center; gap: 16px; padding: 22px 26px; margin: 0 0 16px; background: linear-gradient(100deg, #eaf4ff 0%, #f7fbff 60%, #ffffff 100%); border: 1px solid #d5e6f8; border-left: 6px solid #4a9be8; border-radius: 16px; box-shadow: 0 2px 10px rgba(74, 155, 232, .12); }
        .pf-hero .pf-avatar { flex: none; width: 58px; height: 58px; border-radius: 50%; background: #d4e8fb; color: #2563a8; display: flex; align-items: center; justify-content: center; font-size: 26px; }
        .pf-hero .pf-cap { font-size: 11.5px; font-weight: 600; letter-spacing: 1.5px; text-transform: uppercase; color: #6b93bd; }
        .pf-hero h4 { margin: 2px 0 0; padding: 0; border: 0; font-size: 26px; font-weight: 700; line-height: 1.25; color: #1f5a9e; text-transform: none; letter-spacing: 0; }

        .pf-card { background: #fff; border: 1px solid #dfeaf6; border-radius: 16px; box-shadow: 0 2px 8px rgba(74, 130, 190, .08); padding: 16px 20px 10px; margin: 0 0 16px; }
        .pf-card h4 { display: flex; align-items: center; gap: 10px; margin: 0 0 12px; padding: 0 0 9px; border-bottom: 2px solid #e3eefa; font-size: 14px; font-weight: 700; letter-spacing: .8px; text-transform: uppercase; color: #2f6fb5; }
        .pf-card h4:before { content: ""; width: 5px; height: 16px; border-radius: 3px; background: #6fb1f0; }
        .pf-inner { margin: 0; padding: 0; }

        .pf-kvt { width: 100%; border-collapse: collapse; margin: 0 0 6px; }
        .pf-kvt td { padding: 9px 12px; border-bottom: 1px solid #edf3fa; vertical-align: top; }
        .pf-kvt td.k { width: 17%; font-size: 11.5px; font-weight: 600; text-transform: uppercase; letter-spacing: .4px; color: #6f89a6; background: #f8fbfe; }
        .pf-kvt td.k:empty { background: none; }
        .pf-kvt td.v { width: 33%; font-size: 14.5px; font-weight: 600; color: #34485f; }
        .pf-kvt td.v span:empty::after { content: "\2014"; color: #c3d2e2; font-weight: 400; }

        .pf-card .table { width: 100%; margin: 0 0 8px; border: 1px solid #e3eefa; border-radius: 12px; overflow: hidden; background: #fff; }
        .pf-card .table > thead > tr > th { background: #eaf3fc; color: #2f6fb5; font-size: 12px; font-weight: 700; letter-spacing: .3px; padding: 9px 10px; border: 0; border-bottom: 1px solid #d5e6f8; text-shadow: none; }
        .pf-card .table > tbody > tr > td { padding: 8px 10px; border-top: 1px solid #edf3fa; color: #3b4a5e; }
        .pf-card .table-striped > tbody > tr:nth-of-type(odd) { background: #fafcff; }
        @media (max-width: 767px) { .pf-kvt, .pf-kvt tbody, .pf-kvt tr, .pf-kvt td { display: block; width: 100% !important; } .pf-hero h4 { font-size: 21px; } .pf-hero { padding: 16px; } }
        @media print { .pf-bar { display: none; } }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>

    <form id="profile" runat="server">
        <div class="pf-page">
        <div class="pf-bar">
            <asp:Button class="btn btn-print" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" UseSubmitBehavior="false" />
            <input type="button" class="btn btn-pdf" value="Export PDF" onclick="return ExportPdf();" />
        </div>
 <asp:Panel ID="pnlContents" runat="server">
        <div class="pf-hero">
            <div class="pf-avatar"><span class="glyphicon glyphicon-user"></span></div>
            <div>
                <div class="pf-cap">Employee Profile</div>
                <h4><asp:Label ID="FName" runat="server"></asp:Label></h4>
            </div>
        </div>

        <div class="pf-card">
            <h4>Personal and Current Post</h4>
            <table class="pf-kvt">
                <tr><td class="k">Date of Birth</td><td class="v"><asp:Label ID="DOB" runat="server"></asp:Label></td><td class="k">Age</td><td class="v"><asp:Label ID="Age" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Current Designation</td><td class="v"><asp:Label ID="CurrentDesignation" runat="server"></asp:Label></td><td class="k">Current BPS</td><td class="v"><asp:Label ID="bps" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Employee Branch</td><td class="v"><asp:Label ID="CurrentBranch" runat="server"></asp:Label></td><td class="k">Employee Status</td><td class="v"><asp:Label ID="EmployeeStatus" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Current Status</td><td class="v"><asp:Label ID="CurrentStatusLbl" runat="server"></asp:Label></td><td class="k"></td><td class="v"></td></tr>
            </table>
        </div>

        <div class="pf-card">
            <h4>Service</h4>
            <table class="pf-kvt">
                <tr><td class="k">Govt Service Start Date</td><td class="v"><asp:Label ID="GovtServiceStartDate" runat="server"></asp:Label></td><td class="k">Senate Service Start Date</td><td class="v"><asp:Label ID="SenateServiceStartDate" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Total Govt Service</td><td class="v"><asp:Label ID="GovtService" runat="server"></asp:Label></td><td class="k">Total Service in Senate</td><td class="v"><asp:Label ID="HouseService" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Superanuation Date</td><td class="v"><asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td><td class="k"></td><td class="v"></td></tr>
            </table>
        </div>

        <div class="pf-card" id="Education" runat="server" visible="false">
<div class="pf-inner">
      <h4>Educational Qualification</h4>
<table class="table table-striped table-condensed table-data pf-table">
    <thead>
<tr>
<th>Sr#</th>
<th>Degree Level</th>
<th>Discipline</th>
<th>Institution</th>
<th>Country</th>
<%--<th>City</th>--%>
<th>Completion Year</th>
<th>Grade</th>
<th>CGPA</th>
<th>Percentage</th>



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
<%--    <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%# GetCity(Convert.ToInt32(Eval("City_Id")))%>'></asp:Label></td>--%>
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
      
        
     </div>  
                
      
<%--<div class="row">
      
        <div class="col-md-10">
            <hr />
            <h4>Trainings:</h4>

<table class="table table-striped table-condensed table-responsive table-data">
<thead>
<tr>
<th>Sr#</th>
<th>Course Name</th>
<th>Course Type</th>
<th>Deg/Dip/Cert</th>
<th>Institution</th>
<th>Country</th>

<th>From</th>
<th>To</th>
<th>Sponsored By</th>


</tr>
</thead>
<tbody>
   
    <asp:ListView ID="EmpCoursesLv" runat="server">

    <ItemTemplate>
 <tr>
    
     
     <td><asp:Label ID="Label6" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="PassportNumber" class="table-data" runat="server" Text='<%#Bind("CourseName")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetCourseType(Convert.ToInt32(Eval("CourseTypeId")))%>'></asp:Label></td>
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
    </div>--%>
  <div class="pf-card" id="Postings" runat="server" visible="false">
<div class="pf-inner">
      <h4>Posting Details</h4>
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
<th>Details</th>
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
  </div>
        
        
 <div class="pf-card" id="PostingSum" runat="server" visible="false">
<div class="pf-inner">
      <h4>Posting Summary</h4>

<table class="table table-striped table-condensed table-responsive table-data">
<thead>
<tr>

<th>Sr#</th>
<th>Branch Name</th>
<th>Years</th>
<th>Months</th>




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
           
</div>


 <div class="pf-card" id="NOC" runat="server" visible="false">
<div class="pf-inner">
      <h4>NOCs ISSUED</h4>

 <table class="table table-striped table-condensed table-responsive table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                           
                            <th>NOC Date</th>
                            <th>NOC Type</th>
                            <th>Details</th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpNocsLv" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td class="itemLeft">
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                   <td>
                                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("NocType")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
                                   
                                </tr>

                            </ItemTemplate>
    </asp:ListView>  
</tbody>
    </table>
  </div>
           
</div>
 
 <div class="pf-card" id="Medical" runat="server" visible="false">
<div class="pf-inner">
      <h4>Medical</h4>

 <table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Medical Type</th>
<th>Post</th>
<th>BPS</th>
<th>Checkup Date</th>
<th>Year</th>
<th>Submitted</th>
</tr>
 <asp:ListView ID="MedicalLv" runat="server" >

 <ItemTemplate>
 <tr>
    
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#Bind("MedicalType")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#Bind("BPS")%>'></asp:Label></td>
       <td class="itemLeft"><asp:Label ID="Label3" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("OnDate")))%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label4" runat="server" Text='<%#Bind("MedYear")%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%#(Convert.ToString(Eval("IsSubmitted"))=="1")?"Yes":"No"%>'></asp:Label></td>

   
  </tr>
 </ItemTemplate>
    </asp:ListView>  

    </table>
  </div>
           
</div>

    
     </asp:Panel>
    </div>
     <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script>
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });
        });
           function PrintPanel() {
               return HRMPrint.print("<%=pnlContents.ClientID %>", { title: "EMPLOYEE PROFILE" });
           }
           function ExportPdf() {
               return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: "EMPLOYEE PROFILE" });
           }
      
</script>
        </form>
</body>
   

    
