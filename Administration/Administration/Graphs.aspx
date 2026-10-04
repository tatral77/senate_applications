<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" Inherits="Administration.Graphs" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1" ChartType="Doughnut">
                     <Points>
            <asp:DataPoint AxisLabel="Celtics" YValues="17" />
            <asp:DataPoint AxisLabel="Lakers" YValues="15" />
            <asp:DataPoint AxisLabel="Bulls" YValues="6" />
            <asp:DataPoint AxisLabel="Spurs" YValues="4" />
            <asp:DataPoint AxisLabel="76ers" YValues="3" />
            <asp:DataPoint AxisLabel="Pistons" YValues="3" />
            <asp:DataPoint AxisLabel="Warriors" YValues="3" />
         </Points> 
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
