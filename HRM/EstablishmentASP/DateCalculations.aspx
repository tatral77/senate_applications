<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateCalculations.aspx.cs" Inherits="EstablishmentASP.DateCalculations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Start Date</td>
                <td>
                    <asp:TextBox ID="StartDateTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>End Date</td>
                <td>
                    <asp:TextBox ID="EndDateTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" /></td>
             
            </tr>
            <tr>
                <td colspan="2">
                    
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
             
            </tr>
        </table>
    </div>

    </form>
</body>
</html>
