<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CountryCities.ascx.cs" Inherits="EstablishmentASP.CountryCities" %>
<table>
<tr>
    <td>
        <asp:DropDownList width="204px" ID="CountriesDDL" runat="server" AutoPostBack="True" 
            onselectedindexchanged="CountriesDDL_SelectedIndexChanged">
        <asp:ListItem Value="0">Select</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td>
        <asp:DropDownList width="203px" ID="CitiesDDL" runat="server">
        <asp:ListItem Value="0">Select</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
</table>
