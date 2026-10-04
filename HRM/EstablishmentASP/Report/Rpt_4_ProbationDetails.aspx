<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_4_ProbationDetails.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_4_ProbationDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Styles/MainStyles.css" rel="stylesheet" />
    <link href="../Styles/modern.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>

    <!DOCTYPE html>
    <div class="container">
        <h4  class="page-header" >EMPLOYEE PROBATION DETAILS</h4>
        <h4 class="page-header" style="text-decoration:underline;">
            <asp:Label ID="FName" runat="server"></asp:Label>
        </h4>
        <table class="table table-data table-condensed">
            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Date of Birth:</label></td>
                <td>
                    <asp:Label ID="DOB" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Age:</label></td>
                <td>
                    <asp:Label ID="Age" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Current Designation:</label></td>
                <td>
                    <asp:Label ID="CurrentDesignation" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Current BPS:</label></td>
                <td>
                    <asp:Label ID="bps" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Employee Branch:</label></td>
                <td>
                    <asp:Label ID="CurrentBranch" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Employee Status:</label></td>
                <td>
                    <asp:Label ID="EmployeeStatus" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Govt Service Start Date:</label></td>
                <td>
                    <asp:Label ID="GovtServiceStartDate" runat="server"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Senate Service Start Date:</label></td>
                <td>
                    <asp:Label ID="SenateServiceStartDate" runat="server"></asp:Label></td>
            </tr>
          <%--  <tr>
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
            </tr>--%>
          <%--  <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Superanuation Date:</label></td>
                <td>
                    <asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td>
            </tr>--%>


        </table>
 <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title-Small">PROBATION DETAILS</label>
                </div>
          </div>
  <div id="Probation">
    <table class="table table-hover table-striped table-data">
    <thead style="text-align:center">
       <tr>
            <th>Sr#</th>
  
            <th>Probation Type</th>
            <th>Probation From</th>
            <th>Probation To</th>
            <th>Details</th>
    
      </tr>
    </thead>

    <asp:ListView ID="ProbationLV" runat="server">
    
      

     
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                       
                        <td>                    
                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ProbationType")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                        </td>
                         <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                        </td>
                         <td>
                           <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                       
                        
                    

    </tr>
       </ItemTemplate>
        
        </asp:ListView>
</table>
    </div>
        </div>
</body>
</html>
