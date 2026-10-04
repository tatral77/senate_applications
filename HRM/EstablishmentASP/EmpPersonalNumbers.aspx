<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="EmpPersonalNumbers.aspx.cs" Inherits="EstablishmentASP.EmpPersonalNumbers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
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
      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
    <div class="row">
            
            <div class="col-md-8"><h4 style="font-weight:bold">MANAGE PERSONNEL NUMBERS</h4></div>
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
                                    <div class="col-xs-3">
                                        <label class="control-label" for="AgeFrom">Age From:</label>                    
                                        <asp:TextBox class="form-control" ID="AgeFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-3">
                                        <label class="control-label" for="AgeTo">Age To:</label>
                                        <asp:TextBox class="form-control" ID="AgeTo" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-3">
                                          <label class="control-label" for="ExpFrom">Job Exp From:</label>
                                          <asp:TextBox class="form-control" ID="ExpFrom" runat="server"></asp:TextBox>
                                     </div>
                                     <div class="col-xs-3">
                                          <label class="control-label" for="ExpFrom">Job Exp To:</label>
                                          <asp:TextBox class="form-control" ID="ExpTo" runat="server"></asp:TextBox>
                           
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
 <div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text=""></asp:Label></div>	
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Employee Name</th>
<th>CNIC</th>
<th>Personnel Number</th>
<th>Main Head</th>
<th>Vendor Number</th>
</tr>
 <asp:ListView ID="EmpListView" runat="server"
     OnItemCreated="EmpListView_ItemCreated"
     OnItemDataBound="EmpListView_ItemDataBound">
 <%-- OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"

 >--%>

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="SystemUsersId" runat="server" Value='<%#Bind("SystemUsersId")%>' />
     <asp:HiddenField ID="HidEmployeePoolsId" runat="server" Value='<%#Bind("EmployeePoolsId")%>' />
    <td class="itemCent">
    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemCent"> <a class="tooltip table-data" style="font-weight:bold;" href="#"><%#Eval("EmpName") + " / " + Eval("Post") + " (" + Eval("BPS") + ")<br>" + Eval("CNIC")  %>
         <span class="hid">
                                    <img class="hid" src='<%#"images/uploads/" + Eval("imageurl")%>' style="width:90px;height:110px;"> 
                                   
                                </span>
                         </a></td>
       <td class="itemLeft"><asp:TextBox class="form-control" ID="CNICTxt" runat="server" Text='<%#Bind("CNIC")%>'></asp:TextBox></td>
     <td class="itemLeft"><asp:TextBox class="form-control" ID="PersonalNumberTxt" runat="server" Text='<%#Bind("PersonalNumber")%>'></asp:TextBox></td>
          <td class="itemLeft">  
              <asp:DropDownList ID="EmployeePoolsIdDDL" class="form-control" runat="server">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
          <td class="itemLeft"><asp:TextBox class="form-control" ID="VendorNumberTxt" runat="server" Text='<%#Bind("VendorNumber")%>'></asp:TextBox></td>
 
  </tr>
 </ItemTemplate>
      </asp:ListView>
 
    
   </table>
                <asp:Button ID="Save" runat="server" CssClass="btn btn-custom" Text="Save" OnClick="Save_Click" /> 
   
</div>

</asp:Content>
