<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="EstablishmentASP.NewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
</asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row top-buffer">
        <div class="col-md-12">
            <div class="page-header"><h4>New Employee</h4></div>

        </div>
    </div>
    <table class="table">
        <tr><td class="table-data">
    <div class="row top-buffer">
    <div class="col-md-2 table-data">File Number</div>
    <div class="col-md-10"><asp:TextBox ID="FileNumber" Width="400" required="true" runat="server" class="form-control"></asp:TextBox>
        <div class="col-md-5">
            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="File Number" ControlToValidate="FileNumber" ValidationGroup="g1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
    </div>
   
</div>
            </td></tr>
        <tr><td class="table-data">
        <div class="row top-buffer">
    <div class="col-md-2 table-data">Main Head:</div>
    <div class="col-md-10"><asp:DropDownList ID="MainHead" Width="100" class="form-control" runat="server">
    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
    </asp:DropDownList>
        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Select Main Head" ControlToValidate="MainHead" InitialValue="0" ValidationGroup="g1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>
  
</div>
</td></tr>
        <tr><td class="table-data">
<div class="row top-buffer">
    <div class="col-md-2 table-data">Employee Name:</div>
    <div class="col-md-10"><asp:TextBox ID="EmpName" Width="400" required="true" runat="server" class="form-control"></asp:TextBox>
       
    </div>
</div>
    </td></tr>
        <tr><td class="table-data">    
        <div class="row top-buffer">
    <div class="col-md-2 table-data">Gender:</div>
    <div class="col-md-10"><asp:DropDownList ID="Gender" Width="100" class="form-control" runat="server" >
    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Male</asp:ListItem>
    <asp:ListItem Value="2">Female</asp:ListItem>
    </asp:DropDownList>
        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Select Gender" ControlToValidate="Gender" InitialValue="0" ValidationGroup="g1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>
</div>
       </td></tr>
        <tr><td class="table-data">
        

<div class="row top-buffer">
   <div class="col-md-12"><asp:Button ID="Save" runat="server" class="btn btn-custom" Text="Save" onclick="Save_Click" ValidationGroup="g1"/></div>
</div>
            </td></tr>
       
</table>
</div>
</asp:Content>
