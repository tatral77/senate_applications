<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_2_Superannuation.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_2_Superannuation" %>

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
    <div class="container-fluid">
        <h4 class="page-header">
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
            <tr>
                <td>
                    <label class="control-lbl-sm" for="title">Superanuation Date:</label></td>
                <td>
                    <asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td>
            </tr>


        </table>
    </div>
</body>
</html>
