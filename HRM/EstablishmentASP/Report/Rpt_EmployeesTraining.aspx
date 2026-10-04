<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Rpt_EmployeesTraining.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_EmployeesTraining" %>

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
        .style2 {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
            width: 69px;
        }

        .style3 {
            width: 69px;
        }

        @media print {
            a[href]:after {
                content: none !important;
            }
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
            <asp:Button class="btn btn-custom" ID="ClearSearch" runat="server" Text="Clear Search Results" OnClick="ClearSearch_Click" />
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
            <input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
        </div>
    </div>

<div id="myModal" class="modal fade in" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->

                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Search Employees</h4>
                        <div class="row">
                            <div class="col-md-3">
                                <label class="control-label" for="EligibleDDL">Trainings Attended:</label>
                                <asp:TextBox ID="TrainingsAttendedTxt" runat="server" CssClass="form-control>                               form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label" for="EligibleDDL">Trainings Institute:</label>
                                <asp:TextBox ID="TrainingInstituteTxt" runat="server" CssClass="form-control>                               form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label" for="EligibleDDL">Training Field:</label>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <br />
                                <label class="control-label">Mandatory:</label>
                                <asp:CheckBox ID="Mandatory" runat="server" />
                                <br />
                                <label class="control-label">Foreign:</label>
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
                                    <asp:DropDownList ID="BPSFrom" class="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6 col-md-4">
                                    <label class="control-label" for="BPSTo">BPS To:</label>
                                    <asp:DropDownList ID="BPSTo" class="form-control" runat="server">
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
                        <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                        <button id="Cancel" class="btn btn-custom" data-dismiss="modal">Cancel</button>

                    </div>
                </div>
            </div>
        </div>



        <div class="clearfix"></div>
        <asp:Panel ID="pnlContents" runat="server">
<div class="regularDiv report-ui">
         <div class="sec-head"><h5>EMPLOYEES TRAINING</h5></div>
            <div class="report-criteria">
                <asp:Label ID="CriteriaLbl" runat="server" Text="<b>REPORT BASED ON FOLLOWING PARAMETERS</b><br>"></asp:Label>
            </div>
            <table class="table table-hover table-striped table-condensed table-data rpt-fixed">
                <thead>
                   <tr>
                        <th style="width:31%">Name/BPS/Age</th>
                        <th style="width:23%">Govt Service</th>
                        <th style="width:23%">Appointment/Promotion</th>
                        <th style="width:23%">Probation</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="EmpListView" runat="server">
                        <ItemTemplate>
                            <tr class="emp-row">
                                <%#AddNameAndAge(Convert.ToInt32(Eval("EmpId")))%>
                            </tr>
                            <tr class="train-row">
            
                                             <td>
                                                <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("TrainingsAttended")%>' />
                                            </td>
                                            <td>
                                           
                                                <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Eval("TrainingInstitute")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" class="table-data" Text='<%#"From :" + GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" class="table-data" Text='<%#"To:" + GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
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
            return HRMPrint.print("<%=pnlContents.ClientID %>", { title: "EMPLOYEES TRAINING" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: "EMPLOYEES TRAINING" });
        }
    </script>
</asp:Content>
