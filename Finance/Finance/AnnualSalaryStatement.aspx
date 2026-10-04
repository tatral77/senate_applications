<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnualSalaryStatement.aspx.cs" Inherits="Finance.AnnualSalaryStatement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="./Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        .saltable th {
            font-weight: lighter !important;
            border: solid thin !important;
        }

        .saltable td {
            font-weight: lighter !important;
            border: solid thin !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; font-weight: bold; font-size: 12pt; text-decoration: underline;">SENATE SECRETARIAT</div>
        <div id="headerdiv" runat="server" style="text-align: center; font-weight: bold; font-size: 10pt; margin-top: 10px; text-decoration: underline;"></div>
<%--        <div id="monthheaderdiv" runat="server" style="text-align: center; font-weight: bold; font-size: 10pt; margin-top: 10px; text-decoration: underline;"></div>--%>
        <div id="senatornamediv" runat="server" style="text-align: center; font-size: 11pt; margin-top: 10px; text-decoration: underline"></div>

        <div id="div" runat="server" style="margin-top: 10px;">
        </div>
    </form>
</body>
</html>
