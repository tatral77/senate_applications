<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="EstablishmentASP.SearchEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <meta name="viewport" content="width=device-width, initial-scale=1">

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
        a>div { display: none; }
        a:hover>div { display: block;
                     
        }
        .tooltip
{
  text-decoration:none;
  position:relative;
}
 
 
.tooltip span
{
  display:none;
  -moz-border-radius:6px;
  -webkit-border-radius:6px;
  border-radius:6px;
  color:black;
  background:white; 
}
 
 
.tooltip span img
{
  float:left;
  margin:0px 2px 2px 0;
}
 
 
.tooltip:hover span
{
  display:block;
  position:absolute;
  top:0;
  left:0;
  z-index:1000;
  width:auto;
  max-width:320px;
  min-height:128px;
  border:1px solid black;
  margin-top:12px;
  margin-left:70px;
  overflow:hidden;
  padding:8px;
}


    </style>
    <script>
        jQuery(document).ready(function () {

            jQuery('#search').on('click', function (event) {
                event.preventDefault();

            });
        });

     
        //jQuery(document).ready(function searchKeyPress(e) {
        //    // look for window.event in case event isn't passed in
        //    e = e || window.event;
        //    if (e.keyCode == 13) {
        //        document.getElementById('Button2').click();
        //        return false;
        //    }
        //    return true;
        //});

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    <div class="row">
            
            <div class="col-md-6"><h4 style="font-weight:bold">SEARCH EMPLOYEES</h4></div>
        <div class="col-md-6" style="text-align:right;"><button id="search" class="btn btn-custom" data-toggle="modal" data-target="#myModal">Search Employee</button>
            <asp:Button class="btn btn-custom" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" />
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
           
        </div>
    </div>
       

    <div id="myModal" class="modal fade in"" role="dialog">
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
                                     <div class="col-xs-3">
                                        <label class="control-label" for="EmpName">Personal No:</label>
                                        <asp:TextBox ID="PeronalNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label class="control-label" for="EmpName">Employee Name:</label>
                                        <asp:TextBox ID="EmpName" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label class="control-label" for="FileNoTxt">File No:</label>
                                        <asp:TextBox ID="FileNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <label class="control-label" for="Province">Province/Unit:</label>
                                        <asp:DropDownList ID="Province" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div> 

                                <div class="row">
                                    <div class="col-xs-4">
                                         <label class="control-label" for="BPSFrom">BPS From:</label>               
                                         <asp:DropDownList ID="BPSFrom"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                         <label class="control-label" for="BPSTo">BPS To:</label>               
                                         <asp:DropDownList ID="BPSTo"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                        <label class="control-label" for="EmpPoolDDL">Pool:</label>
                                        <asp:DropDownList ID="EmpPoolDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>   
                                <div class="row">
                                    <div class="col-xs-4">
                                         <label class="control-label" for="IsActiveCB">Is Active:</label>
                                        <asp:DropDownList ID="IsActiveCB" class="form-control" runat="server">
                                            <asp:ListItem Value="select">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                         <label class="control-label" for="EmpStatusDDL">Employee Status:</label>
                                         <asp:DropDownList ID="EmpStatusDDL" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                         </asp:DropDownList>
   
                                    </div>
                                    <div class="col-xs-4">
                                        <label class="control-label" for="Gender">Gender:</label>
                                        <asp:DropDownList class="form-control" ID="Gender" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-1">
                                        <label class="control-label" for="AgeFrom">Age From:</label>                    
                                        <asp:TextBox class="form-control" ID="AgeFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-1">
                                        <label class="control-label" for="AgeTo">Age To:</label>
                                        <asp:TextBox class="form-control" ID="AgeTo" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-2">
                                          <label class="control-label" for="GExpFrom">Govt Exp From:</label>
                                          <asp:TextBox class="form-control" ID="GExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-2">
                                          <label class="control-label" for="GExpFrom">Gov Exp To:</label>
                                          <asp:TextBox class="form-control" ID="GExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                    <div class="col-xs-2">
                                          <label class="control-label" for="SExpFrom">Sen Exp From:</label>
                                          <asp:TextBox class="form-control" ID="SExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-2">
                                          <label class="control-label" for="SExpFrom">Sen Exp To:</label>
                                          <asp:TextBox class="form-control" ID="SExpTo" runat="server"></asp:TextBox>
                           
                                     </div>
                                     <div class="col-xs-2">
                                          <label class="control-label" for="ExpFrom">Not Employed in Senate:</label>
                                         <asp:CheckBox ID="NotEmpInSen" runat="server" class="form-control" />
                           
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-4">
                                         <label class="control-label" for="Branch">Branch:</label>
                                        <asp:DropDownList class="form-control" ID="Branch" runat="server">
                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-xs-4">
                                            <label class="control-label" for="Designation">Designation:</label>
                                            <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                            <label class="control-label" for="CurrentStatusDDL">Current Status:</label>
                                            <asp:DropDownList ID="CurrentStatusDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                              </div>
                                 <div class="row">
                                     <div class="col-xs-3">
                                            <label class="control-label" for="Designation">Appointment Mode:</label>
                                              <asp:DropDownList ID="AppointmentModeDDL" runat="server" class="form-control">
                                                   
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                         <label class="control-label" for="Branch">Senate Employment Date From:</label>
                                         <asp:TextBox ID="DateFromTxt" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-xs-2">
                                            <label class="control-label" for="Designation">Senate Employment Date To:</label>
                                              <asp:TextBox ID="DateToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                        <div class="col-xs-2">
                                            <label class="control-label" for="Designation">Active:</label>
                                               <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control">
                                                    <asp:ListItem Selected="true" Value="-1">Select</asp:ListItem>
                                                    <asp:ListItem  Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                   <%--   <div class="col-xs-2">
                                         <label class="control-label" for="Branch">Temporary Employment Date From:</label>
                                         <asp:TextBox ID="TempServiceFromDate" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-xs-2">
                                            <label class="control-label" for="Designation">Temporary Employment Date To:</label>
                                              <asp:TextBox ID="TempServiceToDate" runat="server" class="form-control"></asp:TextBox>
                                    </div>--%>
                              </div>  
                                   
                                  
                            </div>
            </div>
        <div class="modal-footer">
             <div class="row">
                 <div class="col-xs-8"></div>
                 <div class="col-xs-2">
                     <asp:CheckBox CssClass="form-control" Text="Search only by name"  ID="ForceCB" runat="server" />
                 </div>
                 
                <div class="col-xs-2">
                    <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
                    <button id="Cancel" class="btn btn-custom" data-dismiss="modal">Cancel</button>
               </div>
                 </div>
           
      </div>
      </div>
 </div>
 </div>
        


    <div class="clearfix"></div>
        <asp:Panel id="pnlContents" runat = "server">   
    <div class="container-fluid">
 <div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>SEARCH PARAMETERS</u></b><br>"></asp:Label></div>	
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th class="m-hide">Sr#</th>
    <th class="m-hide">Personal Number</th>
    <th class="m-hide">File Number</th>
     <th>Employee Name</th>
     <th class="m-hide">Age</th>
      <th>Post Held</th>
       <th>Grade</th>
        <th class="m-hide">Status</th>
         <th class="m-hide">Address</th>
        <th class="hid m-hide"></th>
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="EmpListView" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td class="m-hide">
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="m-hide">
                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Bind("PersonalNumber")%>' />
                        </td>
                        <td class="m-hide">
                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Filenumber")%>' />
                        </td>
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("EmpId")%>' />
                           <a class="tooltip table-data" style="font-weight:bold;" href='<%#Eval("EmpId","../PersonalInformation.aspx?empid={0}")%>'> <%#Eval("EmpName")%>
                               <%-- <span class="hid">
                                    <img class="hid" src='<%#"images/uploads/" + Eval("ImageUrl")%>' style="width:90px;height:110px;"> 
                                   
                                </span>--%>

                           </a>
                        </td>
                        <td class="m-hide">
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Age")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("EmpDesignation")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("BPS")%>' />
                        </td>
                        <td class="m-hide">
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Bind("Empstatus")%>' />
                        </td>
                        <td class="m-hide">
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#Bind("EmpAddress")%>' />
                        </td>
                        <td class="hid m-hide">
                            <asp:HyperLink class="btn btn-custom" Target="_blank" ID="HyperLink2" runat="server" style="font-weight:bold;"  NavigateUrl='<%#Eval("EmpId","~/EmployeeProfile.aspx?empid={0}")%>'>Profile</asp:HyperLink>
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
           return HRMPrint.print("<%=pnlContents.ClientID %>", {});
       }
       function ExportPdf() {
           return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", {});
       }
    </script> 
</asp:Content>
