<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_GroupsTotalSummary.aspx.cs" Inherits="QuestionManagement.Rpt_GroupsTotalSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-6">
                <h4>
                    <label class="page-header">GROUPS SUMMARY</label></h4>
            </div>
            <div class="col-md-2 page-header ">
                <span class="page-header" style="font-weight: bold">From Session:</span>
                <asp:DropDownList ID="SessionDDL" class="form-control" runat="server" Style="font-weight: bold">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2 page-header ">
                <span class="page-header" style="font-weight: bold">To Session:</span>
                <asp:DropDownList ID="ToSessionDDL" class="form-control" runat="server" Style="font-weight: bold">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-1 page-header ">
                <br />
                <asp:Button class="btn btn-custom" ID="GenerateBtn" runat="server" Text="Generate" OnClick="Generate_Click" />

            </div>
            <div class="col-md-1 page-header ">
                <br />
                <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />

            </div>

        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="pnlContents" runat="server">
                    <div id="heading" style="text-align: center; font-weight: bold; font-size: 12pt" runat="server"></div>
                    <div id="sesionNumber" style="font-weight: bold; font-size: 10pt" runat="server"></div>
                    <div id="DateDiv" style="font-weight: bold; font-size: 10pt" runat="server"></div>
                    <table class="table table-condensed table-striped table-data printTable" style="font-size:12pt!important;font-family:'Bookman Old Style'!important">
                        <tr style="font-size:12pt">
                            <th style="font-size:12pt!important">Sr#</th>
                            <th style="font-size:12pt!important">Name of Ministry</th>
                            <th style="font-size:12pt!important">Starred Questions</th>
                            <th style="font-size:12pt!important">Un-Starred Questions</th>
                            <th style="font-size:12pt!important">Deferred (Starred)</th>
                             <th style="font-size:12pt!important">Deferred (Un-Starred)</th>
                            <asp:ListView ID="ListView1" runat="server">
                                <ItemTemplate>
                                    <%#AddGroupingRow()%>
                                    <tr style="font-size:12pt!important">
                                        <td class="itemCent" style="font-size:12pt!important">
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Bind("SerialNumber")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("Division")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important;">
                                            <asp:Label ID="Label6" runat="server" Text='<%#(Convert.ToInt32(Eval("Starred")))==0?"-":Eval("Starred")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label8" runat="server" Text='<%#(Convert.ToInt32(Eval("Unstarred")))==0?"-":Eval("Unstarred")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label9" runat="server" Text='<%#(Convert.ToInt32(Eval("Deferred")))==0?"-":Eval("Deferred")%>'></asp:Label></td>
                                        <td class="itemLeft" style="font-size:12pt!important">
                                            <asp:Label ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("DeferredUnstarred")))==0?"-":Eval("DeferredUnstarred")%>'></asp:Label></td>
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
            printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><link href='./Content/bootstrap.min.css' rel='stylesheet' />");
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
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { fallback: PrintPanel });
        }

    </script>
</asp:Content>
