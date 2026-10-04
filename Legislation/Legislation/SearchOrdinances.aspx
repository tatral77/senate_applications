<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchOrdinances.aspx.cs" Inherits="Legislation.SearchOrdinances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nf-head">
        <h4>SEARCH ORDINANCES</h4>
        <a href="NewOrdinance.aspx" class="btn btn-custom"><span class="glyphicon glyphicon-plus"></span> New Ordinance</a>
    </div>

    <div class="panel panel-default qs-filter">
        <div class="panel-heading"><span class="glyphicon glyphicon-search"></span> <span class="qs-title">FILTERS</span></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-sm-6">
                    <label class="small-label" for="OrdinanceIdTxt">Ordinance ID</label>
                    <asp:TextBox ID="OrdinanceIdTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-6 col-sm-6">
                    <label class="small-label" for="KeywordsTxt">Keyword (title or remarks)</label>
                    <asp:TextBox ID="KeywordsTxt" ClientIDMode="Static" runat="server" CssClass="form-control small-control" />
                </div>
                <div class="col-md-4">
                    <label class="small-label" for="<%= StatusDDL.ClientID %>">Status</label>
                    <asp:DropDownList ID="StatusDDL" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-4">
                    <label class="small-label" for="ParliamentaryYearsDDL">Parliamentary Year</label>
                    <asp:DropDownList ID="ParliamentaryYearsDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-4">
                    <label class="small-label" for="FromAssemblySessionDDL">From Session</label>
                    <asp:DropDownList ID="FromAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-4">
                    <label class="small-label" for="ToAssemblySessionDDL">To Session</label>
                    <asp:DropDownList ID="ToAssemblySessionDDL" ClientIDMode="Static" CssClass="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="qs-actions">
                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" OnClick="Search_Click" />
                <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Reset" OnClientClick="clearTextBox(); return false;" />
                <span style="flex: 1"></span>
                <asp:Button class="btn btn-default" ID="Button3" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
                <asp:Button class="btn btn-default" ID="ExportPdfBtn" runat="server" Text="Export PDF" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="return ExportPdf('Ordinance-Search', 'landscape');" />
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlContents" runat="server">
        <div class="nm-count"><%= ListView1.Items.Count %> ordinance(s) found</div>
        <table class="table table-hover table-striped qs-table">
            <thead>
                <tr>
                    <th>Sr#</th>
                    <th>OID</th>
                    <th>Title</th>
                    <th>Parliamentary Year</th>
                    <th>Session</th>
                    <th>Promulgation Date</th>
                    <th>Date of Laying in the Senate</th>
                    <th>Remarks</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("OrdinanceId")%>' />
                            </td>
                            <td class="qs-justify m-block" style="min-width: 320px" runat="server" id="FullSearch">
                                <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Target="_blank" NavigateUrl='<%#GetLink(Eval("OrdinanceId").ToString())%>'><%#SelectText(Eval("Title").ToString())%></asp:HyperLink>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ParliamentaryYears.ParliamentaryYear")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label17" class="table-data" runat="server" Text='<%#Eval("AssemblySessions.SessionNumber")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DateOfPromulgation"))) %>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DateOfLaying"))) %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
                            </td>
                            <td>
                                <span class="label label-primary"><asp:Label ID="Label6" runat="server" Text='<%#Eval("OrdinanceStatuses.OrdinanceStatus")%>' /></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td colspan="9" style="text-align: center; padding: 28px; color: #6b7280">No ordinances match the search.</td>
                        </tr>
                    </EmptyDataTemplate>
                </asp:ListView>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
