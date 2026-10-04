<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ManageDataEntry.aspx.cs" Inherits="EstablishmentASP.ManageDataEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
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
     <div class="container">
    <div class="row"> 
        <div class="col-md-6"><button id="search" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Search Employee</button>
            <asp:Button class="btn btn-primary" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" />
              <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
           
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
                                        <label class="control-label" for="EmpName">Personnel Number:</label>
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
                                     <div class="col-xs-4">
                                            <label class="control-label" for="Designation">Appointment Mode:</label>
                                              <asp:DropDownList ID="AppointmentModeDDL" runat="server" class="form-control">
                                                   
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                         <label class="control-label" for="Branch">Date From:</label>
                                         <asp:TextBox ID="DateFromTxt" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-xs-4">
                                            <label class="control-label" for="Designation">Date To:</label>
                                              <asp:TextBox ID="DateToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                              </div>  
                              <div class="row">
                                     <div class="col-xs-3">
                                            <label class="control-label" for="Designation">Entered By:</label>
                                             <asp:TextBox ID="EnteredByTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                         <label class="control-label" for="Branch">Entered From:</label>
                                         <asp:TextBox ID="EnteredFromTxt" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-xs-3">
                                            <label class="control-label" for="Designation">Entered To:</label>
                                              <asp:TextBox ID="EnteredToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                     <div class="col-xs-3">
                                            <label class="control-label" for="Designation">Rechecked By:</label>
                                              <asp:TextBox ID="RecheckedByTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                              </div>  
                                   
                                  
                            </div>
            </div>
        <div class="modal-footer">
            <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
            <button id="Cancel" class="btn btn-primary" data-dismiss="modal">Cancel</button>
           
      </div>
                         </div>
 </div>
 </div>
        


    <div class="clearfix"></div>

 <asp:Panel id="pnlContents" runat = "server">
      <div class="row">
         <div class="col-md-12">
             <h4  runat="server">DATA ENTRY INFORMATION</h4>
         </div>
     </div>
     <div class="row">
         <div class="col-md-12">

             <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label>
         </div>
     </div>
<div class="row"><div class="col-md-12">
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
    <th>Personal Number</th>
    <th>File Number</th>
     <th>Employee Name</th>
      <th>Entered By</th>
       <th>Entered On</th>
        <th>Rechecked By</th>
          <th class="hid">Action</th>
    </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="EmpListView" runat="server"
        OnItemUpdating="ItemUpdating" >
   
    <ItemTemplate>
    <tr>
                        <td>
                            <asp:HiddenField ID="HidEmpId" runat="server" Value='<%#Bind("EmpId")%>' />
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Bind("PersonalNumber")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Filenumber")%>' />
                        </td>
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("EmpId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="font-weight:bold;color:rgb(17,30,108);" NavigateUrl='<%#Eval("EmpId","~/PersonalInformation.aspx?empid={0}")%>'><%#Eval("EmpName")%></asp:HyperLink>
                           <br /> <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Eval("EmpDesignation") + " (" + Eval("BPS") + ")"%>'></asp:Label>
                        </td>
                      <%--  <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Age")%>' />
                        </td>--%>
                     <%--   <td>
                            
                        </td>--%>
                        <td>
                            <asp:TextBox ID="EnteredBy" class="form-control control-label"  runat="server" Text='<%#Bind("EnteredBy")%>' ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="EnteredOn" class="form-control control-label js-date"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EnteredOn")))%>' ></asp:TextBox>
                        </td>
                        <td>
                           <asp:TextBox ID="RecheckedBy" class="form-control control-label hid"  runat="server" Text='<%#Bind("RecheckedBy")%>' TextMode="MultiLine" ></asp:TextBox>
                            <asp:Label ID="RecheckedLabel" runat="server" Text='<%#Eval("RecheckedBy")%>' style="display:none;width:200px;" CssClass="unhid"></asp:Label>
                        </td>
                        <%--<td>
                            <asp:HyperLink class="table-data" ID="HyperLink2" runat="server" style="font-weight:bold;color:rgb(17,30,108);"  NavigateUrl='<%#Eval("EmpId","~/EmployeeProfile.aspx?empid={0}")%>'>Profile</asp:HyperLink>
                        </td>--%>
                        <td class="hid">
                           <asp:LinkButton class="btn btn-primary" ID="saveImageButton" runat="server" AlternateText="Save" CommandName="update"
                            ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        </td>
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
    </div></div>
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
               return HRMPrint.print("<%=pnlContents.ClientID %>", {});
           }
           function ExportPdf() {
               return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", {});
           }


</script>

</asp:Content>
