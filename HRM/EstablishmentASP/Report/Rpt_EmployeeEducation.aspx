<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Rpt_EmployeeEducation.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_EmployeeEducation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
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
      <div class="container-fluid">
    <div class="nf-head nf-right">
        
        <div class="nf-toolbar">
            <button id="search" class="btn btn-custom" data-toggle="modal" data-target="#myModal">Search Employee</button>
            <asp:Button class="btn btn-custom" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" />
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
            <input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
        </div>
    </div>

<div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <!-- Modal content-->
                      
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Search Employees</h4>
                                   <div class="row">
                                     <div class="col-md-2">
                                    <label  class="control-label" for="EligibleDDL">Education Level:</label>
                                   <asp:DropdownList ID="EducationLevelDDL" runat="server" CssClass="form-control"> 
                                       <asp:ListItem Value="0">Select</asp:ListItem>
                               </asp:DropdownList>
                              </div>
                                 <div class="col-md-2">
                                    <label  class="control-label" for="EligibleDDL">Discipline:</label>
                                   <asp:TextBox ID="DisciplineTxt" runat="server" CssClass="form-control">  
                               </asp:TextBox>
                              </div>
                                      <div class="col-md-2">
                                    <label  class="control-label" for="EligibleDDL">Institution:</label>
                                  <asp:TextBox ID="InstitutionTxt" runat="server" class="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2">
                                    <label  class="control-label" for="EligibleDDL">Subjects:</label>
                                  <asp:TextBox ID="SubjectsTxt" runat="server" class="form-control"></asp:TextBox>
                              </div>
                                   <div class="col-md-3">
                                       <br />
                              <label  class="control-label" >Foreign:</label>
                                     <asp:CheckBox ID="Foreign" runat="server" />
                                  
                              </div>
                                </div>
                          
                                <!-- <div class="col-md-3">
                                    <label  class="control-label" for="EligibleDDL">Date:</label>
                                  <asp:TextBox ID="DateTxt" runat="server" class="form-control js-date"></asp:TextBox>
                              </div>-->
                            </div>
                            <div class="modal-body">
                                
                                <div class="container-fluid">

                                <div class="row"> 
                                     <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="EmpName">Personnel Number:</label>
                                        <asp:TextBox ID="PeronalNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="EmpName">Employee Name:</label>
                                        <asp:TextBox ID="EmpName" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="FileNoTxt">File No:</label>
                                        <asp:TextBox ID="FileNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="Province">Province/Unit:</label>
                                        <asp:DropDownList ID="Province" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div> 

                                <div class="row">
                                    <div class="col-sm-6 col-md-4">
                                         <label class="control-label" for="BPSFrom">BPS From:</label>               
                                         <asp:DropDownList ID="BPSFrom"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                         <label class="control-label" for="BPSTo">BPS To:</label>               
                                         <asp:DropDownList ID="BPSTo"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                        <label class="control-label" for="EmpPoolDDL">Pool:</label>
                                        <asp:DropDownList ID="EmpPoolDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>   
                                <div class="row">
                                    <div class="col-sm-6 col-md-4">
                                         <label class="control-label" for="IsActiveCB">Is Active:</label>
                                        <asp:DropDownList ID="IsActiveCB" class="form-control" runat="server">
                                            <asp:ListItem Value="select">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                         <label class="control-label" for="EmpStatusDDL">Employee Status:</label>
                                         <asp:DropDownList ID="EmpStatusDDL" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                         </asp:DropDownList>
   
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                        <label class="control-label" for="Gender">Gender:</label>
                                        <asp:DropDownList class="form-control" ID="Gender" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="AgeFrom">Age From:</label>                    
                                        <asp:TextBox class="form-control" ID="AgeFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="AgeTo">Age To:</label>
                                        <asp:TextBox class="form-control" ID="AgeTo" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-3">
                                          <label class="control-label" for="ExpFrom">Job Exp From:</label>
                                          <asp:TextBox class="form-control" ID="ExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-3">
                                          <label class="control-label" for="ExpFrom">Job Exp To:</label>
                                          <asp:TextBox class="form-control" ID="ExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-md-4">
                                         <label class="control-label" for="Branch">Branch:</label>
                                        <asp:DropDownList class="form-control" ID="Branch" runat="server">
                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                            <label class="control-label" for="Designation">Designation:</label>
                                            <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                            <label class="control-label" for="CurrentStatusDDL">Current Status:</label>
                                            <asp:DropDownList ID="CurrentStatusDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                              </div>
                                 <div class="row">
                                     <div class="col-sm-6 col-md-4">
                                            <label class="control-label" for="Designation">Appointment Mode:</label>
                                              <asp:DropDownList ID="AppointmentModeDDL" runat="server" class="form-control">
                                                   
                                            </asp:DropDownList>
                                    </div>
                                   
                              </div>  
                                   
                                  
                            </div>
            </div>
        <div class="modal-footer">
            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
            <button id="Cancel" class="btn btn-custom" data-dismiss="modal">Cancel</button>
           
      </div>
                         </div>
 </div>
 </div>
        


    <div class="clearfix"></div>
<asp:Panel id="pnlContents" runat = "server">
<div class="regularDiv report-ui">
         <div class="sec-head"><h5>EMPLOYEES EDUCATION</h5></div>
     <div class="report-criteria">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b>REPORT BASED ON FOLLOWING PARAMETERS</b><br>"></asp:Label></div>
<table class="table table-hover table-striped table-condensed table-data rpt-fixed">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th style="width:4%">Sr#</th>
     
        <th style="width:11%">Education Level</th>
         <th style="width:12%">Discipline</th>
            <th style="width:25%">Subjects</th>
        <th style="width:12%">Institution</th>
     
        <th style="width:6%">Completion Year</th>
        <th style="width:6%">Country</th>
         <th style="width:6%">Grade</th>
        <th style="width:6%">CGPA</th>
        <th style="width:6%">Percentage</th>
        <th style="width:6%">Division</th>
      
       
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="EmpListView" runat="server">
   
    <ItemTemplate>

          <%#AddGroupingRow()%>
    <tr>
                        <td class="text-center">
                            
                            
                        </td>
                     
        
                        <td>
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("DegreeLevel")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Bind("Discipline")%>' />
                        </td>
                          <td>
                            <asp:Label ID="Label6" runat="server" class="table-data" Text='<%#Bind("Subjects")%>' />
                        </td>
                       <td>
                            <asp:Label ID="Label9" runat="server" class="table-data" Text='<%#Bind("Institution")%>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="Label7" runat="server" class="table-data" Text='<%#Eval("CompletionYear")%>' />
                        </td>
                        </td>
                         <td >
                            <asp:Label ID="Label10" runat="server" class="table-data" Text='<%#Bind("Country")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#Bind("Grade")%>' />
                        </td>
                          <td>
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#GetResult(Eval("Cgpa").ToString())%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label4" runat="server" class="table-data" Text='<%#GetResult(Eval("Percentage").ToString())%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label5" runat="server" class="table-data" Text='<%#GetResult(Eval("Division").ToString())%>' />
                        </td>

                       
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
</div>
</asp:Panel>
  </div>  
    <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
       function PrintPanel() {
           return HRMPrint.print("<%=pnlContents.ClientID %>", { title: "EMPLOYEES EDUCATION" });
       }
       function ExportPdf() {
           return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: "EMPLOYEES EDUCATION" });
       }
    </script> 
</asp:Content>
