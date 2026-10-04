<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageListNumbers.aspx.cs" Inherits="QuestionManagement.ManageListNumbers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4>
                    <label class="page-header">REMOVE QUESTIONS FROM LISTS</label></h4>
            </div>

        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="Label7" lablefor="QuestionId" runat="server" Text="Enter Question IDs"/>
                <asp:TextBox ID="QuestionId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
                <div class="col-md-2">
                    <br />
                    <asp:Button ID="RemoveBtn" runat="server" Text="Remove" class="btn btn-custom" OnClick="RemoveBtn_Click" />
                </div>


        </div>
        <div class="row">
            <div class="col-md-8">
                 <asp:Label ID="defferederror" runat="server" Text="" Style="color:#b20000"/>
                <asp:Label ID="success" runat="server" Text="" Style="color:#458b00"/>
            </div>
        </div>
    </div>
</asp:Content>
