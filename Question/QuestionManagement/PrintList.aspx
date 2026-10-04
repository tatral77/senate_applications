<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintList.aspx.cs" Inherits="QuestionManagement.PrintList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%-- <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />  
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>  
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script> --%>
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="CustomScripts/jquery-ui.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <style>
        hr {
    border: 0;
    width: 96%;
    color: #FFFF00;
    height: 1px;
}
         table { page-break-inside:auto }
    tr    { page-break-inside:avoid; page-break-after:auto }
    thead { display:table-header-group }
    tfoot { display:table-footer-group }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container container-fluid">
            <div class="row">
                <div class="col-md-12 page-header">
                    <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
                </div>
            </div>
            <asp:Panel ID="pnlContents" runat="server">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center; font-family: 'Times New Roman'">
                        <u>
                            <asp:Label ID="Label2" Style="text-align: center; font-size: 14pt" runat="server" Text="SENATE SECRETARIAT"></asp:Label></u><br />
                        <asp:Label ID="Label3" Style="text-align: center; font-size: 12pt" runat="server" Text=""></asp:Label><br />
                        <br />
                        <u>
                            <asp:Label ID="ListNameLbl" Style="text-align: center; font-size: 14pt" runat="server" Text="Label"></asp:Label><br />
                            <br />
                        </u>
                        <asp:Label ID="DeferedQuestionsLbl" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="container" style="width:60%;margin-bottom:20px;">

                
                        <asp:ListView ID="DivisionsLV" runat="server">
                            <ItemTemplate>
                                <div style="display:flex;flex-direction:row;gap:50px;">
                                    <div style="padding-top: 0px; padding-bottom: 0px;text-align:left;width:100%">
                                        <asp:Label ID="NoticeLbl" Style="font-size: 13.5pt; font-style: italic;font-family: 'Times New Roman';" runat="server" Text='<%#Eval("MinistryName")%>'></asp:Label></div>
                                    <div style="font-size: 13.5pt; text-align: right; font-style: italic; font-family: 'Times New Roman';width:100%">
                                        <asp:Label ID="QuestionLbl" runat="server" Text='<%#FormatQuestions(Convert.ToInt32(Eval("Questions")))%>'></asp:Label></div>
                                    <hr/>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                       <div style="display:flex;flex-direction:row">
                        <asp:Label ID="NoticeLbl" Style="font-size: 13.5pt; font-style: italic; font-weight: bold; font-family: 'Times New Roman';width:100%;text-align:left;" runat="server" Text='TOTAL QUESTIONS'></asp:Label></td>

                       <div style="font-size: 13.5pt; text-align: left; font-style: italic; font-weight: bold; font-family: 'Times New Roman';width:100%;text-align:right;">
                                <asp:Label ID="TotalQuestionsLbl" runat="server" Text='0'></asp:Label></div>
                           </div>
                </div>
                <div class="row">
                    <table style="width: 650px;">
                        <asp:ListView ID="DeferLV" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td style="padding-top: 0px; padding-bottom: 0px;">
                                        <u>
                                            <asp:Label Style="padding-top: 0px; padding-bottom: 0px; font-size: 13.5pt; font-family: 'Times New Roman'; font-weight: bold; font-style: italic;" ID="SenatorNameLbl" runat="server" Text='<%#GetDefSenatorName(Convert.ToInt32(Eval("ListNo")),Convert.ToString(Eval("MoverName")))%>'></asp:Label></u></td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 0px; padding-bottom: 0px;">
                                        <asp:Label ID="NoticeLbl" Style="font-size: 13.5pt; font-style: italic; font-family: 'Times New Roman';" runat="server" Text='<%#GetNoticeDateTime(Convert.ToDateTime(Eval("NoticeDiaryDate")),Convert.ToDateTime(Eval("NoticeDiaryTime")),Convert.ToInt32(Eval("QuestionId")))%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-size: 13.5pt; text-align: justify; font-style: italic; font-family: 'Times New Roman'; line-height: 1.6">
                                        <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("QuestionText")).Trim()%>'></asp:Label></td>


                                </tr>

                            </ItemTemplate>
                        </asp:ListView>

                        <asp:ListView ID="ListLV" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td style="padding-top: 0px; padding-bottom: 0px;">
                                        <u>
                                            <asp:Label Style="padding-top: 0px; padding-bottom: 0px; font-size: 13.5pt; font-family: 'Times New Roman'; font-weight: bold; font-style: italic;" ID="SenatorNameLbl" runat="server" Text='<%#GetListSenatorName(Convert.ToInt32(Eval("ListNo")),Convert.ToString(Eval("MoverName")))%>'></asp:Label></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 0px; padding-bottom: 0px;">
                                        <asp:Label ID="NoticeLbl" Style="font-size: 13.5pt; font-style: italic; font-family: 'Times New Roman';" runat="server" Text='<%#GetNoticeDateTime(Convert.ToDateTime(Eval("NoticeDiaryDate")),Convert.ToDateTime(Eval("NoticeDiaryTime")),Convert.ToInt32(Eval("QuestionId")))%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-size: 13.5pt; text-align: justify; font-style: italic; font-family: 'Times New Roman'; line-height: 1.6; padding-bottom: 10px; padding-top: 10px;">
                                        <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("QuestionText")).Trim()%>'></asp:Label></td>


                                </tr>

                            </ItemTemplate>
                        </asp:ListView>
                    </table>
                </div>
            </asp:Panel>

        </div>
        <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">




            function PrintPanel() {
                var panel = document.getElementById("<%=pnlContents.ClientID %>");
                var printWindow = window.open('', '', 'height=500,width=1000');
                printWindow.document.write("<html><head><style> body {font-family:'Times New Roman' ;font-size: 18px ;margin-left:50px!important;} p { page-break-after: always; }.footer { position: fixed; bottom: 0px; }.pagenum::before {counter-increment: page;counter-reset: page 1;content: counter(page+1); }th,td {padding: 1px ;}th {border-bottom: 2px solid #333333 ;font-size: 12px ;font-weight:bold;}td {/*border-bottom: 1px dotted #999999 ;*/ font-size: 12px ;}tfoot td {/* border-bottom-width: 0px ;border-top: 2px solid #333333 ;*/padding-top: 3px ;padding-bottom: 3px;}.Headings{font-size:12px;text-align:center;}.page-break{ page-break-before: always; }.print-tab{padding: 5px;line-height: 1.42857143;vertical-align: top;}@page {size: A4;margin-top:50px;margin-bottom:50px;}@media print {footer {position: fixed;bottom: 0;}header {position: fixed;top: 0;}.content-block, p {page-break-inside: avoid;}}</style><link href='./Content/bootstrap.min.css' rel='stylesheet' /><title></title>");
                printWindow.document.write('</head><body><div class="footer">Page: <span class="pagenum"></span></div>');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    document.location.href = "";
                    printWindow.print();
                }, 500);
                return false;
            }
            function ExportPdf() {
                return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { fallback: PrintPanel });
            }
        </script>
    </form>
</body>
</html>
