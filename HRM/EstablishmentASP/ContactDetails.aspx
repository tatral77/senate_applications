<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ContactDetails.aspx.cs" Inherits="EstablishmentASP.Reports.ContactDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
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
            
            <div class="col-md-8"><h4 style="font-weight:bold">CONTACT DETAILS</h4></div>
        <div class="col-md-4"><button id="search" class="btn btn-custom" data-toggle="modal" data-target="#myModal">Search Employee</button>
            <asp:Button class="btn btn-custom" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" />
           
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
                                    <div class="col-sm-6">
                                         <label class="control-label" for="Branch">Branch:</label>
                                        <asp:DropDownList class="form-control" ID="Branch" runat="server">
                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-sm-6">
                                            <label class="control-label" for="Designation">Designation:</label>
                                            <asp:DropDownList ID="Designation" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
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
	
<table class="table table-hover table-striped table-responsive table-data">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr> 
    <th>Sr#</th>
    <th>Employee Name</th>
     <th>Age</th>
      <th>Post Held</th>
       <th>Grade</th>
        <th>Local Address</th>
        <th>Permanent Address</th>
        <th>Email</th>
       
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
                         <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("EmpName")%>' />
                           
                        </td>
                        <td>
                            <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Age")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("EmpDesignation")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("BPS")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" class="table-data" Text='<%#Bind("EmpAddress")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" class="table-data" Text='<%#Bind("LocalAddress")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" class="table-data" Text='<%#Bind("EmailAddress")%>' />
                        </td>
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
  </div>   
</asp:Content>
