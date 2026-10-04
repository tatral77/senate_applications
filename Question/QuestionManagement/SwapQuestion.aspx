<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SwapQuestion.aspx.cs" Inherits="QuestionManagement.SwapQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 118px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="page-header"><h4>SWAP QUESTION</h4></div>
        <div class="row">
             <div class="col-md-2">
                 <asp:Label ID="Label1" runat="server" Text="SESSION" for="SessionMovementDDL"></asp:Label>
                <asp:DropDownList ID="SessionMovementDDL" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="SessionMovementDDL_SelectedIndexChanged"></asp:DropDownList>
            </div>

        

        </div>
        <div class="row">
            <div class="col-md-5">
                <div class="page-header"><h5>FIRST GROUP</h5>
                    <asp:DropDownList ID="FirstGroup" style="width:150px" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FirstGroup_SelectedIndexChanged"></asp:DropDownList>
                </div>
              
                <asp:ListBox ID="FirstLB" class="form-control" runat="server" style="height:300px;border-color:black"></asp:ListBox>

            </div>
             <div class="col-md-2">
                 <br /><br /><br /><br /><br /><br /><br /><br />
               <asp:Button ID="Button1" runat="server" Text="Swap Questions" Cssclass="btn btn-custom" OnClick="Button1_Click" />
                 <asp:Label ID="err" runat="server" style="color:brown;font-weight:bold;" Text=""></asp:Label>
            </div>

             <div class="col-md-5">
                <div class="page-header"><h5>SECOND GROUP</h5>
                    <asp:DropDownList ID="SecondGroup" style="width:150px" CssClass="form-control" runat="server" OnSelectedIndexChanged="SecondGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>              
                    <asp:ListBox ID="SecondLB" class="form-control" runat="server" style="height:300px;border-color:black"></asp:ListBox>
            </div>
            </div>
        </div>



</asp:Content>
