<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Rpt_LeaveEnchashment.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_LeaveEnchashment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
  
      
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
            <asp:Button class="btn btn-custom" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" /> <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
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
                               <div class="col-md-4"> <label  class="control-label" for="EligibleDDL">Eligible:</label><asp:DropDownList ID="EligibleDDL" runat="server" CssClass="form-control>                               form-control">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                          </asp:DropDownList>
                              </div>
                                 <div class="col-md-4"> <label  class="control-label" for="EligibleDDL">Calculate Leave Credit From:</label><asp:DropDownList ID="ServiceDDL" runat="server" CssClass="form-control>                               form-control">
                                    <asp:ListItem Value="0">Govt Service Date</asp:ListItem>
                                    <asp:ListItem Value="1">Senate Service Date</asp:ListItem>
                                 
                                          </asp:DropDownList>
                              </div>
                            </div>
                            <div class="modal-body">
                                
                                <div class="container-fluid">
                                <div class="row"> 
                                     <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="EmpName">Personal No:</label>
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
                                    <div class="col-sm-6 col-md-3">
                                         <label class="control-label" for="BPSFrom">BPS From:</label>               
                                         <asp:DropDownList ID="BPSFrom"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                         <label class="control-label" for="BPSTo">BPS To:</label>               
                                         <asp:DropDownList ID="BPSTo"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="EmpPoolDDL">Pool:</label>
                                        <asp:DropDownList ID="EmpPoolDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-sm-6 col-md-3">
                                            <label class="control-label" for="CurrentStatusDDL">Current Status:</label>
                                            <asp:DropDownList ID="CurrentStatusDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>   
                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                         <label class="control-label" for="IsActiveCB">Is Active:</label>
                                        <asp:DropDownList ID="IsActiveCB" class="form-control" runat="server">
                                            <asp:ListItem Value="select">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                   
                                    <div class="col-sm-6 col-md-3">
                                        <label class="control-label" for="Gender">Gender:</label>
                                        <asp:DropDownList class="form-control" ID="Gender" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-sm-6 col-md-3">
                                         <label class="control-label" for="Branch">Branch:</label>
                                        <asp:DropDownList class="form-control" ID="Branch" runat="server">
                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                 <%--   <div class="col-sm-6 col-md-3">
                                            <label class="control-label" for="Designation">Designation:</label>
                                            <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>--%>
                                   
                                      <div class="col-sm-6 col-md-3">
                                            <label class="control-label" for="Designation">Appointment Mode:</label>
                                              <asp:DropDownList ID="AppointmentModeDDL" runat="server" class="form-control">
                                                   
                                            </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-sm-12 col-md-1">
                                        <label class="control-label" for="AgeFrom">Age From:</label>                    
                                        <asp:TextBox class="form-control" ID="AgeFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-12 col-md-1">
                                        <label class="control-label" for="AgeTo">Age To:</label>
                                        <asp:TextBox class="form-control" ID="AgeTo" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-2">
                                          <label class="control-label" for="GExpFrom">Govt Exp From:</label>
                                          <asp:TextBox class="form-control" ID="GExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-2">
                                          <label class="control-label" for="GExpFrom">Gov Exp To:</label>
                                          <asp:TextBox class="form-control" ID="GExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                    <div class="col-sm-6 col-md-2">
                                          <label class="control-label" for="SExpFrom">Sen Exp From:</label>
                                          <asp:TextBox class="form-control" ID="SExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-6 col-md-2">
                                          <label class="control-label" for="SExpFrom">Sen Exp To:</label>
                                          <asp:TextBox class="form-control" ID="SExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                     <div class="col-sm-6 col-md-2">
                                          <label class="control-label" for="ExpFrom">Not Employed in Senate:</label>
                                         <asp:CheckBox ID="NotEmpInSen" runat="server" class="form-control" />
                           
                                     </div>
                                </div>
                                <div class="row">
                                   
                              </div>
                                 <div class="row">
                                       <div class="col-sm-6 col-md-3">
                                            <label class="control-label" for="Designation">Designation:</label>
                                         <%--   <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        <asp:ListBox CssClass="form-control" Rows="8" ID="DesignationLb" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                            
                                    </div>
                                      <div class="col-sm-6 col-md-2">
                                         <label class="control-label" for="EmpStatusLb">Employee Status:</label>
                                         <asp:ListBox CssClass="form-control" Rows="8" ID="EmpStatusLb" SelectionMode="Multiple" runat="server"></asp:ListBox>
   
                                    </div>
                                    <div class="col-sm-6 col-md-2">
                                            <label class="control-label" for="CurrentStatusDDL">Current Status:</label>
                                            <asp:ListBox CssClass="form-control" Rows="8" ID="CurrentStatusLb" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                    </div>
                                   <%-- <div class="col-sm-6 col-md-2">
                                         <label class="control-label" for="Branch">Year:</label>
                                           <asp:DropDownList ID="YearDDL" runat="server" class="form-control">
                                                   
                                            </asp:DropDownList>

                                    </div>--%>
                                    <%--<div class="col-sm-6 col-md-2">
                                            <label class="control-label" for="Designation">Till:</label>
                                              <asp:TextBox ID="DateToTxt" runat="server" class="form-control" Text="31/12/2018"></asp:TextBox>
                                    </div>--%>
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
         <div class="sec-head"><h5>LEAVE ENCASHMENT REPORT</h5></div>
     <div class="report-criteria">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b>REPORT BASED ON FOLLOWING PARAMETERS</b><br>"></asp:Label></div>
<table class="table table-hover table-striped table-condensed table-data rpt-fixed">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th style="width:6%">Sr#</th>
     <th style="width:24%">Employee Name</th>
      <th style="width:21%">Post Held</th>
       <th style="width:10%">Grade</th>
        <th style="width:13%">This Year Credit</th>
        <th style="width:13%">Available for Encashment</th>
         <th style="width:13%">Total Credit</th>
       
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="EmpListView" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td class="text-center">
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("EmpId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" Target="_blank"  runat="server" NavigateUrl='<%#Eval("EmpId","~/LeaveDetails.aspx?empid={0}")%>'><%#Eval("EmpName")%></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("EmpDesignation")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Bps")%>'></asp:Label>
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("CurrentYearCredit")%>' />
                        </td>
                          <td style="text-align:center">
                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("CreditAvailableForEncashment")%>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Bind("TotalLeaveCredit")%>' />
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
            return HRMPrint.print("<%=pnlContents.ClientID %>", { title: "LEAVE ENCASHMENT REPORT" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: "LEAVE ENCASHMENT REPORT" });
        }
    </script> 
</asp:Content>
