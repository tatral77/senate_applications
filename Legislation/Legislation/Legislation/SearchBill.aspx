<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchBill.aspx.cs" Inherits="Legislation.SearchBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
   
<br />
    <div class="container regularDiv" style="padding: 20px; color: black">
        <div class="row">
            <div class="col-md-4">
                <h4 style="color: #000;">SEARCH BILL</h4>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label19" runat="server" CssClass="small-label" Text="Bill Diary No." for="BillDiary"></asp:Label>
                <asp:TextBox ID="BillDiary" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label18" runat="server" CssClass="small-label" Text="Bill ID" for="BillId"></asp:Label>
                <asp:TextBox ID="BillId" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label1" runat="server" CssClass="small-label" Text="Keyword" for="KeywordsTxt"></asp:Label><asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" class="form-control small-control"></asp:TextBox></div>
            </div>
        
       <div class="row top-buffer">
            <div class="col-md-4">
                <asp:Label ID="Label9" runat="server" CssClass="small-label" Text="Member Name" for="MemberNameTxt"></asp:Label>
                <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                <asp:HiddenField ID="HidMemberId" runat="server" />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label10" runat="server" CssClass="small-label" Text="From Session" for="FromAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FromAssemblySessionDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label11" runat="server" CssClass="small-label" Text="To Session" for="ToAssemblySessionDDL"></asp:Label>
                <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ToAssemblySessionDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label12" runat="server" CssClass="small-label" Text="Category" for="CategoryDDL"></asp:Label>
                <asp:DropDownList ID="CategoryDDL" ClientIDMode="Static" class="form-control small-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Category</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
   
        <div class="row top-buffer">
            <div class="col-md-3">
                <asp:Label ID="Label14" runat="server" CssClass="small-label" Text="Bill Status" for="BillStatusDDL"></asp:Label>
                <asp:DropDownList ID="BillStatusDDL" ClientIDMode="Static" runat="server" class="form-control small-control">
                    <asp:ListItem Selected="True" Value="0">Question Status</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label22" runat="server" CssClass="small-label" Text="Notice Diary No" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="NoticeDiaryNo" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label15" runat="server" CssClass="small-label" Text="From Notice Date" for="DateFromTxt"></asp:Label>
                <asp:TextBox ID="DateFromTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label16" runat="server" CssClass="small-label" Text="To Notice Date" for="DateToTxt"></asp:Label>
                <asp:TextBox ID="DateToTxt" runat="server" ClientIDMode="Static" class="form-control small-control"></asp:TextBox>
            </div>
            </div>

        <div class="row top-buffer">
            <div class="col-md-2" style="margin-top: 5px;">
                <asp:Label ID="Label8" runat="server" CssClass="small-label" Text="Complete Text" for="FullTextCB"></asp:Label>
                <asp:CheckBox ID="FullTextCB" runat="server" CssClass="form-control" />
            </div>

            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Division:</label>
                <div>
                    <asp:TextBox ID="DivisionTxt" runat="server" CssClass="form-control small-control" />
                    <asp:HiddenField ID="HidDivisionId" runat="server" />

                </div>

            </div>

            <div class="col-md-12" style="text-align: right">
            <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
            <asp:Button class="btn btn-custom" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox();" />
            <asp:Button class="btn btn-custom" ID="Button3" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
                <asp:HyperLink class="btn btn-custom" ID="HyperLink1" runat="server" Text="Annual Report" NavigateUrl="BillAnnualReport.aspx" />
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
            </div>  
        </div>
     
        </div>

    <%--<asp:DropDownList ID="BillStatusesDDL" runat="server"></asp:DropDownList>--%>
</asp:Content>

    