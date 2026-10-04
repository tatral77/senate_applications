<%@ Page Title="Audit Logs" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="EstablishmentASP.Logs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .lg-summary { margin: 0 0 12px; color: #4b5b6e; font-size: 13px; }
        .lg-filters { display: grid; grid-template-columns: repeat(4, 1fr); gap: 0 16px; }
        .lg-filters .lg-f { margin-bottom: 12px; min-width: 0; }
        .lg-filters label { display: block; margin: 0 0 4px; font-size: 12px; font-weight: 600; text-transform: uppercase; letter-spacing: .3px; color: #4b5b6e; }
        .lg-filters .form-control { width: 100%; }
        .lg-actions { display: flex; flex-wrap: wrap; gap: 8px; padding-top: 4px; }
        .lg-actions .btn { margin: 0; }
        .lg-badge { display: inline-block; padding: 2px 9px; border-radius: 999px; font-size: 11.5px; font-weight: 700; letter-spacing: .2px; white-space: nowrap; }
        .lg-insert { background: #e3f6ea; color: #1b6b3a; }
        .lg-update { background: #e3effc; color: #1f5a9e; }
        .lg-delete { background: #fde6e6; color: #a32626; }
        .lg-ui { background: #eef1f5; color: #4b5b6e; }
        .lg-other { background: #fff2dc; color: #8a5a10; }
        .lg-details summary { cursor: pointer; color: #0b5fb3; font-weight: 600; font-size: 12.5px; }
        .lg-kv { margin: 6px 0 0; border-collapse: collapse; width: 100%; }
        .lg-kv td { padding: 2px 8px 2px 0; border: 0 !important; vertical-align: top; font-size: 12.5px; word-break: break-word; }
        .lg-kv td:first-child { color: #6b7a8c; white-space: nowrap; width: 1%; }
        .lg-h { margin: 8px 0 2px; font-size: 11.5px; font-weight: 700; text-transform: uppercase; color: #4b5b6e; letter-spacing: .3px; }
        .lg-newvals { font-size: 12.5px; color: #3b4a5e; }
        .lg-newvals b { color: #4b5b6e; font-weight: 600; }
        .lg-pager { display: flex; align-items: center; gap: 10px; margin: 8px 0 16px; flex-wrap: wrap; }
        .lg-pager .btn { margin: 0; }
        .lg-msg { padding: 12px 16px; border-radius: 10px; background: #fff8e6; border: 1px solid #f1d9a0; color: #6b4a06; }
        @media (max-width: 991px) { .lg-filters { grid-template-columns: repeat(2, 1fr); } }
        @media (max-width: 575px) { .lg-filters { grid-template-columns: 1fr; } }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="nf-head">
            <h4>AUDIT LOGS</h4>
            <div class="nf-toolbar">
                <asp:Button ID="ExportBtn" runat="server" Text="Export CSV" CssClass="btn btn-custom" OnClick="ExportBtn_Click" />
            </div>
        </div>

        <asp:Panel ID="NoAccessPnl" runat="server" Visible="false">
            <div class="lg-msg">
                <asp:Label ID="NoAccessLbl" runat="server"></asp:Label>
            </div>
        </asp:Panel>

        <asp:Panel ID="ContentPnl" runat="server">
            <div class="regularDiv">
                <div class="sec-head"><h5>Filters</h5></div>
                <div class="lg-filters">
                    <div class="lg-f">
                        <label for="<%= FromTxt.ClientID %>">From date</label>
                        <asp:TextBox ID="FromTxt" runat="server" CssClass="form-control js-date" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= ToTxt.ClientID %>">To date</label>
                        <asp:TextBox ID="ToTxt" runat="server" CssClass="form-control js-date" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= UserTxt.ClientID %>">User (name or id)</label>
                        <asp:TextBox ID="UserTxt" runat="server" CssClass="form-control" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= KindDDL.ClientID %>">Type</label>
                        <asp:DropDownList ID="KindDDL" runat="server" CssClass="form-control">
                            <asp:ListItem Value="" Text="All entries" />
                            <asp:ListItem Value="DATA" Text="Data changes (insert, update, delete)" />
                            <asp:ListItem Value="UI" Text="Page actions (buttons)" />
                        </asp:DropDownList>
                    </div>
                    <div class="lg-f">
                        <label for="<%= ActionDDL.ClientID %>">Action</label>
                        <asp:DropDownList ID="ActionDDL" runat="server" CssClass="form-control" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= TableTxt.ClientID %>">Table / page</label>
                        <asp:TextBox ID="TableTxt" runat="server" CssClass="form-control" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= EmployeeTxt.ClientID %>">Employee id</label>
                        <asp:TextBox ID="EmployeeTxt" runat="server" CssClass="form-control" />
                    </div>
                    <div class="lg-f">
                        <label for="<%= RecordTxt.ClientID %>">Record id</label>
                        <asp:TextBox ID="RecordTxt" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="lg-actions">
                    <asp:Button ID="SearchBtn" runat="server" Text="Search" CssClass="btn btn-custom" OnClick="SearchBtn_Click" />
                    <asp:Button ID="ClearBtn" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="ClearBtn_Click" CausesValidation="false" />
                </div>
                <asp:Label ID="ErrorLbl" runat="server" ForeColor="#CC0000" EnableViewState="false"></asp:Label>
            </div>

            <div class="regularDiv report-ui">
                <div class="sec-head"><h5>Entries</h5></div>
                <div class="lg-summary"><asp:Label ID="SummaryLbl" runat="server"></asp:Label></div>

                <table class="table table-hover table-striped table-condensed table-data rpt-fixed">
                    <thead>
                        <tr>
                            <th style="width:10%">When</th>
                            <th style="width:11%">User</th>
                            <th style="width:14%">Action</th>
                            <th style="width:10%">Table / page</th>
                            <th style="width:6%">Record</th>
                            <th style="width:7%">Employee</th>
                            <th style="width:30%">New values</th>
                            <th style="width:12%">Details</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="LogsLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("ActionOn", "{0:dd/MM/yyyy}") %><br /><small><%# Eval("ActionOn", "{0:HH:mm:ss}") %></small></td>
                                    <td><%# Server.HtmlEncode(Convert.ToString(Eval("UserName"))) %><small><%# Eval("UserId") == DBNull.Value ? "" : " (#" + Eval("UserId") + ")" %></small></td>
                                    <td><span class='lg-badge <%# BadgeClass(Convert.ToString(Eval("Action"))) %>'><%# Server.HtmlEncode(Convert.ToString(Eval("Action"))) %></span></td>
                                    <td><%# Server.HtmlEncode(Convert.ToString(Eval("TableName"))) %></td>
                                    <td><%# Server.HtmlEncode(Convert.ToString(Eval("RecordId"))) %></td>
                                    <td><%# Eval("EmployeeId") %></td>
                                    <td class="lg-newvals"><%# NewValuesPreview(Container.DataItem) %></td>
                                    <td>
                                        <details class="lg-details">
                                            <summary>View</summary>
                                            <%# DetailsHtml(Container.DataItem) %>
                                        </details>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr><td colspan="8" style="text-align:center">No log entries match these filters.</td></tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </tbody>
                </table>

                <div class="lg-pager">
                    <asp:Button ID="FirstBtn" runat="server" Text="&laquo; First" CssClass="btn btn-default" OnClick="FirstBtn_Click" CausesValidation="false" />
                    <asp:Button ID="PrevBtn" runat="server" Text="&lsaquo; Previous" CssClass="btn btn-default" OnClick="PrevBtn_Click" CausesValidation="false" />
                    <asp:Label ID="PageLbl" runat="server"></asp:Label>
                    <asp:Button ID="NextBtn" runat="server" Text="Next &rsaquo;" CssClass="btn btn-default" OnClick="NextBtn_Click" CausesValidation="false" />
                    <asp:Button ID="LastBtn" runat="server" Text="Last &raquo;" CssClass="btn btn-default" OnClick="LastBtn_Click" CausesValidation="false" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
