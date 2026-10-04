<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Processing.aspx.cs" Inherits="QuestionManagement.Processing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="ChangeGroupsBtn" runat="server" Text="Change Groups" OnClick="ChangeGroupsBtn_Click" />
        <asp:Button ID="CalculateDaysBtn" runat="server" Text="Calculate Days" OnClick="CalculateDaysBtn_Click" />
        <asp:Button ID="Button3" runat="server" Text="Button" /><br />
        
    Start Date <asp:TextBox ID="StartDateTxt" runat="server" CssClass="js-date"></asp:TextBox><br />
        End date<asp:TextBox ID="EndDateTxt" runat="server" CssClass="js-date"></asp:TextBox><br />
        No Of Days<asp:TextBox ID="NumberOfDaysTxt" runat="server"></asp:TextBox>

    </div>
    </form>
</body>
</html>
