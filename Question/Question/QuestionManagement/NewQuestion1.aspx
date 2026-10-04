<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewQuestion1.aspx.cs" Inherits="QuestionManagement.NewQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4 class="page-header">
PERSONAL DETAILS
</h4>

    <div class="container">
        <div class="row">
            <div class="col-md-8 col-sm-6">
          
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="title">Title:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="title" runat="server" class="form-control control-txt" style="Width:100px"></asp:TextBox>
             </div>
       </div>
       <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="EmpNametxt">Name:</label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="EmpNametxt" runat="server" class="form-control control-txt" required="true" style="Width:330px"></asp:TextBox>
                </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ControlToValidate="EmpNametxt" ValidationGroup="Group1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            
       </div>
       <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="title" >Father/Husband Name:</label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="FatherNametxt" ValidationGroup="Group1" class="form-control control-txt" runat="server" Width="328px"></asp:TextBox>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Gender:</label>
            </div>
            <div class="col-md-6">
               <asp:DropDownList ID="Gender" class="form-control control-txt" runat="server" ValidationGroup="Group1" style="Width:100px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidaor4" Text="*" runat="server" ErrorMessage="Select Gender" ControlToValidate="Gender" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
             </div>
       </div>
         <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Date of Bitrth:</label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="DOB" runat="server" class="form-control control-txt" ValidationGroup="Group1" required="true" style="Width:100px"></asp:TextBox>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Place of Birth:</label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="BirthPlace" class="form-control control-txt" runat="server" style="Width:200px">
                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">CNIC No:</label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="CNIC" runat="server" class="form-control control-txt" style="Width:150px"></asp:TextBox>
             </div>
       </div>
         <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm"="control-label" for="Gender">Issue Date:</label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="CNICDate" class="form-control control-txt" ValidationGroup="Group1" runat="server" style="Width:100px"></asp:TextBox>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Place of Issue:</label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="CNICIssuePlace" class="form-control control-txt" runat="server" style="Width:200px">
                <asp:ListItem Value="0"  Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm"="control-label" for="Gender">NTN:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="NTN" class="form-control control-txt" runat="server" style="Width:100px"></asp:TextBox>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Religion:</label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="Religion" class="form-control control-txt" runat="server" style="Width:150px">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Marital Status:</label>
            </div>
            <div class="col-md-6">
                 <asp:DropDownList ID="MaritalStatus" class="form-control control-txt" runat="server" style="Width:150px">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
             </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Province:</label>
            </div>
            <div class="col-md-6">
                 <asp:DropDownList ID="PermProvince" style="Width:250px" class="form-control control-txt" runat="server"  AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Province" ControlToValidate="PermProvince" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
             </div>
       </div>
         <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Domicile:</label>
            </div>
            <div class="col-md-6">
                 <asp:DropDownList ID="DomDistrict" style="Width:250px" class="form-control control-txt" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Permanent Address:</label>
            </div>
            <div class="col-md-6">
                 <asp:TextBox ID="PermAddress" class="form-control control-txt" runat="server" Height="73px" Width="328px" 
               TextMode="MultiLine"></asp:TextBox>
                </div>
             <div class="col-md-3">
             <asp:DropDownList ID="PermCity" class="form-control control-txt" runat="server" style="Width:200px">
                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
       </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="Gender">Local Address:</label>
            </div>
            <div class="col-md-6">
                 <asp:TextBox ID="LocalAddress" class="form-control control-txt" runat="server" Height="74px" Width="325px" 
               TextMode="MultiLine"></asp:TextBox>
          </div>
             <div class="col-md-3">
           <asp:DropDownList ID="LocalCity" class="form-control control-txt" runat="server" style="Width:200px" >
           <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
           </asp:DropDownList>
            </div>
       </div>
                  <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm"="control-label" for="Gender">Email:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="EmailTxt" class="form-control control-txt" type="email" runat="server" style="Width:300px"></asp:TextBox>
                
             </div>
       </div>
      
       <div class="row top-buffer">
            <div class="col-md-9">
        <asp:Button ID="LinkButton1" class="btn btn-primary" runat="server" Text="Add New" CommandName="new"  />  
        </div>
           </div>
                </div>
            </div>
        </div>
</asp:Content>
