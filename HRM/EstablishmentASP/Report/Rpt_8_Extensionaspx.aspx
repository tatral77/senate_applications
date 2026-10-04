<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Rpt_8_Extensionaspx.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_8_Extensionaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1"/>
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
                            </div>
                            <div class="modal-body">
                                
                                <div class="container-fluid">
                                     <div class="row"> 
                                    <div class="col-sm-12">
                                          <label class="control-label" for="Province">Reports:</label>
                                        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem  Value="1">Superannuation</asp:ListItem>
                                             <asp:ListItem  Value="3">Regular Employees on Probation</asp:ListItem>
                                              <asp:ListItem Value="5">Employees Designation in Specific Period</asp:ListItem>
                                             <asp:ListItem Value="6">Pending ACRs</asp:ListItem>
                                            <asp:ListItem Value="7">Gender Based Employees List</asp:ListItem>
                                            <asp:ListItem Value="8">Employees with Contract Extended</asp:ListItem>
                                             <asp:ListItem Value="9">Employees with Deputation Extended</asp:ListItem>
                                            <asp:ListItem Value="10">Employees with Ad-hoc Extended</asp:ListItem>
                                            <asp:ListItem Value="11">Re-Employed Employees</asp:ListItem>
                                            <asp:ListItem Value="12">Employees with Re-Employment Extended</asp:ListItem>
                                             <asp:ListItem Value="13">Employees with Lien</asp:ListItem>
                                            <asp:ListItem Value="14">Employees performed other duties</asp:ListItem>
                                            <asp:ListItem Value="15">Employees on Disciplinary Action Proceedings</asp:ListItem>
                                            <asp:ListItem Value="16">Employees Currently Suspended</asp:ListItem>


                                        </asp:DropDownList>
                                    </div>
                                     </div>





                                <div class="row"> 
                                    <div class="col-sm-4">
                                        <label class="control-label" for="EmpName">Employee Name</label>
                                        <asp:TextBox ID="EmpName" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="FileNoTxt">File No:</label>
                                        <asp:TextBox ID="FileNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="Province">Province/Unit:</label>
                                        <asp:DropDownList ID="Province" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div> 

                                <div class="row">
                                    <div class="col-sm-4">
                                         <label class="control-label" for="BPSFrom">BPS From:</label>               
                                         <asp:DropDownList ID="BPSFrom"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                         <label class="control-label" for="BPSTo">BPS To:</label>               
                                         <asp:DropDownList ID="BPSTo"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="EmpPoolDDL">Pool:</label>
                                        <asp:DropDownList ID="EmpPoolDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>   
                                <div class="row">
                                    <div class="col-sm-4">
                                         <label class="control-label" for="IsActiveCB">Is Active:</label>
                                        <asp:DropDownList ID="IsActiveCB" class="form-control" runat="server">
                                            <asp:ListItem Value="select">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                         <label class="control-label" for="EmpStatusDDL">Employee Status:</label>
                                         <asp:DropDownList ID="EmpStatusDDL" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                         </asp:DropDownList>
   
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label" for="Gender">Gender:</label>
                                        <asp:DropDownList class="form-control" ID="Gender" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <label class="control-label" for="AgeFrom">Age From:</label>                    
                                        <asp:TextBox class="form-control" ID="AgeFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-3">
                                        <label class="control-label" for="AgeTo">Age To:</label>
                                        <asp:TextBox class="form-control" ID="AgeTo" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-3">
                                          <label class="control-label" for="ExpFrom">Job Exp From:</label>
                                          <asp:TextBox class="form-control" ID="ExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-sm-3">
                                          <label class="control-label" for="ExpFrom">Job Exp To:</label>
                                          <asp:TextBox class="form-control" ID="ExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                         <label class="control-label" for="Branch">Branch:</label>
                                        <asp:DropDownList class="form-control" ID="Branch" runat="server">
                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-sm-4">
                                            <label class="control-label" for="Designation">Designation:</label>
                                            <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                            <label class="control-label" for="CurrentStatusDDL">Current Status:</label>
                                            <asp:DropDownList ID="CurrentStatusDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                              </div>
                                <%-- <div class="row">
                                    <div class="col-sm-6">
                                         <label class="control-label" for="Branch">Date From:</label>
                                         <asp:TextBox ID="DateFromTxt" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-6">
                                            <label class="control-label" for="Designation">Date To:</label>
                                              <asp:TextBox ID="DateToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                              </div>  --%>
                                  
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
     <div class="sec-head"><h5><asp:Label ID="ReportLabel" runat="server"></asp:Label> <asp:Label ID="lblHeader" runat="server" ></asp:Label></h5></div>
<table class="table table-hover table-striped table-condensed table-data rpt-fixed">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th style="width:3%">Sr#</th>
      <th style="width:13%">Employee Name</th>
         <th style="width:11%">Post </th>
         <th style="width:6%">BPS</th>
             <th style="width:11%">Branch</th>
        <th style="width:13%">Employee Status</th>
        <th style="width:7%">Employment Date</th>
        <th style="width:7%">Last Extended To</th>
        <th style="width:9%">Total Employment including Extensions</th>
        <th style="width:20%">Details</th>
       
       
    </tr>
         </thead> 
    <tbody>
      
    <asp:ListView ID="EmpListView" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("SystemUsersId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="font-weight:bold;color:rgb(17,30,108);" NavigateUrl='<%#Eval("SystemUsersId","Rpt_8b_ContractExtension.aspx?empid={0}")%>'><%#Eval("EmployeeName")%></asp:HyperLink>
                        </td>
                     <%--  <td>
                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("EmployeeName")%>' />
                        </td>--%>
                      
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Post")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("Bps")%>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("Branch")%>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Bind("EmpStatus")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" class="table-data" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDAte")))%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" class="table-data" Text='<%#GetDuration(Convert.ToDateTime(Eval("FromDAte")),Convert.ToDateTime(Eval("ToDate")))%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Eval("Remarks")%>' />
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
    <script>
       
                
       
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });
            jQuery('#btnPrint').on('click', function (event) {
                event.preventDefault();
            });
        });
      
    
             function PrintPanel() {
                 return HRMPrint.print("<%=pnlContents.ClientID %>", { title: (((document.getElementById("<%=ReportLabel.ClientID %>") || {}).innerText || "") + " " + ((document.getElementById("<%=lblHeader.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
             }
             function ExportPdf() {
                 return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: (((document.getElementById("<%=ReportLabel.ClientID %>") || {}).innerText || "") + " " + ((document.getElementById("<%=lblHeader.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
             }
       

</script>
</asp:Content>
