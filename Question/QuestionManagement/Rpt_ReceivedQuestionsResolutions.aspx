<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_ReceivedQuestionsResolutions.aspx.cs" Inherits="QuestionManagement.Rpt_ReceivedQuestionsResolutions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Panel ID="FilterPanel" runat="server" DefaultButton="GenerateBtn" CssClass="panel panel-default qs-filter">
        <div class="panel-heading">
            <span class="qs-title"><span class="glyphicon glyphicon-list-alt"></span> GROUPS SUMMARY</span>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="FromLbl" runat="server" CssClass="small-label" AssociatedControlID="SessionDDL" Text="From Session"></asp:Label>
                    <asp:DropDownList ID="SessionDDL" class="form-control" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="ToLbl" runat="server" CssClass="small-label" AssociatedControlID="ToSessionDDL" Text="To Session"></asp:Label>
                    <asp:DropDownList ID="ToSessionDDL" class="form-control" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="qs-actions">
                <asp:Button class="btn btn-custom" ID="GenerateBtn" runat="server" Text="Generate" OnClick="GenerateBtn_Click" />
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="MessagePnl" runat="server" Visible="false" CssClass="alert alert-warning" role="alert">
        <span class="glyphicon glyphicon-info-sign"></span>&nbsp;<asp:Label ID="MessageLbl" runat="server" Font-Bold="true"></asp:Label>
    </asp:Panel>

    <div class="container-fluid qs-results">
        <div class="qs-toolbar" id="ToolbarDiv" runat="server" visible="false">
            <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
            <input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        </div>
        <div id="ReportCard" runat="server" visible="false" class="panel panel-default rq-report">
            <div class="panel-body">
                <asp:Panel ID="pnlContents" runat="server">
                    <div style="font-size:12pt;font-weight:bold;text-align:center;margin-bottom:5px;" runat="server" id="ReportHeading"></div>
                  <%--  <div id="heading" style="text-align: center; font-weight: bold; font-size: 12pt" runat="server"></div>
                    <div id="sesionNumber" style="font-weight: bold; font-size: 10pt" runat="server"></div>
                    <div id="DateDiv" style="font-weight: bold; font-size: 10pt" runat="server"></div>--%>
                    <div style="font-weight:bold;font-size:12pt;text-decoration:underline;text-align:center">STARRED QUESTIONS</div>
                    <table class="table table-data printTable compact-table no-cards" style="font-size:12pt!important;font-family:'Bookman Old Style'!important">
                        <tr style="font-size:12pt">
                            <th style="font-size:12pt!important" class="compact-table">Status</th>
                            <th style="font-size:12pt!important" class="compact-table">Total</th>
                            <asp:ListView ID="StarredLV" runat="server">
                                <ItemTemplate>
                                    <tr style="font-size:12pt!important">
                                        <td class="itemCent compact-table" style="font-size:12pt!important;width:80%">
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Bind("QuestionStatus")%>'></asp:Label></td>
                                        <td class="itemLeft compact-table" style="font-size:12pt!important">
                                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("TotalQuestions")%>'></asp:Label></td>
                                      
                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>


                    </table>
                   <div style="font-weight:bold;font-size:12pt;text-decoration:underline;text-align:center">UN-STARRED QUESTIONS</div>
                        <table class="table table-data printTable no-cards" style="font-size:12pt!important;font-family:'Bookman Old Style'!important">
                        <tr style="font-size:12pt">
                            <th style="font-size:12pt!important">Status</th>
                            <th style="font-size:12pt!important">Total</th>
                            <asp:ListView ID="UnStarredLv" runat="server">
                                <ItemTemplate>
                                    <tr style="font-size:12pt!important">
                                        <td class="itemCent" style="font-size:12pt!important;width:80%">
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Bind("QuestionStatus")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("TotalQuestions")%>'></asp:Label></td>
                                      
                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>


                    </table>
                     <div style="font-weight:bold;font-size:12pt;text-decoration:underline;text-align:center">RESOLUTIONS</div>
                        <table class="table table-data printTable no-cards" style="font-size:12pt!important;font-family:'Bookman Old Style'!important">
                        <tr style="font-size:12pt">
                            <th style="font-size:12pt!important">Status</th>
                            <th style="font-size:12pt!important">Total</th>
                            <asp:ListView ID="ResolutionsLv" runat="server">
                                <ItemTemplate>
                                    <tr style="font-size:12pt!important">
                                        <td class="itemCent" style="font-size:12pt!important;width:80%">
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Bind("QuestionStatus")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("TotalQuestions")%>'></asp:Label></td>
                                      
                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>


                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script>
        jQuery(document).ready(function () {

            jQuery('#search').on('click', function (event) {
                event.preventDefault();

            });
        });
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head> <style>table td, table th {line-height: 1.2 !important;padding: 2px !important;}</style><link href='./Content/bootstrap.min.css' rel='stylesheet' /><link href='../Styles/Printing.css' rel='stylesheet' />");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>QUESTION BRANCH</u></div><br><div id="summary">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</div></body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        jQuery(function () {
            // choosing the first session also fills in the last one, so a single session needs one pick
            jQuery('#<%= SessionDDL.ClientID %>').on('change', function () {
                var to = jQuery('#<%= ToSessionDDL.ClientID %>');
                if (to.val() === '0') { to.val(jQuery(this).val()); }
            });
        });
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { fallback: PrintPanel });
        }

    </script>

</asp:Content>
