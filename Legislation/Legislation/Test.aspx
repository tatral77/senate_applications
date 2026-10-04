<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Legislation.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary  style="color:red" ID="ValidationSummary1" ValidationGroup="g1" DisplayMode="BulletList" runat="server" />

        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="color:red" Display="Dynamic" ValidationGroup="g1" Text="Enter value in textbox 1"  ControlToValidate="TextBox1" runat="server" ErrorMessage="Error Message for textbox 1"></asp:RequiredFieldValidator>

        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" style="color:red" ValidationGroup="g1" Text="Enter value in textbox 2"  ControlToValidate="TextBox2" runat="server" ErrorMessage="Error Message for textbox 2"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" ValidationGroup="g1"  runat="server" Text="Button1" />



         <asp:ValidationSummary  style="color:red" ID="ValidationSummary2" ValidationGroup="g2" DisplayMode="BulletList" runat="server" />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" style="color:red" ValidationGroup="g2" Text="Enter value in textbox 3"  ControlToValidate="TextBox3" runat="server" ErrorMessage="Error Message for textbox 3"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" style="color:red" ValidationGroup="g2" Text="Enter value in textbox 4"  ControlToValidate="TextBox4" runat="server" ErrorMessage="Error Message for textbox 4"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox3" ErrorMessage="CompareValidator"></asp:CompareValidator>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">Select</asp:ListItem>
             <asp:ListItem Value="1">Male</asp:ListItem>
             <asp:ListItem Value="2">Female</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" style="color:red" ValidationGroup="g2" Text="Select Value"  ControlToValidate="DropDownList1" runat="server" ErrorMessage="Select Value"></asp:RequiredFieldValidator>
        <asp:Button ID="Button2" ValidationGroup="g2"  runat="server" Text="Button2" />
        


         <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ValidationGroup="g2" Text="Not valid email" ValidationExpression="[a-z0-9]+@[a-z]+\.[a-z]{2,3}" ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>

    </form>
</body>
</html>
