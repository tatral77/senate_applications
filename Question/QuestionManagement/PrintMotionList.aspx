<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMotionList.aspx.cs" Inherits="QuestionManagement.PrintMotionList" %>
<!DOCTYPE html>
<html>
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

<style type="text/css">
    th {
        padding-bottom:10px;
        background-color: #fff;
        text-align: center;
        color: #000;
        font-size: 14pt;
        font-weight: bold;
        vertical-align: top;
        font-family: 'Times New Roman';
       
    }
    td{
        padding-top:10px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container container-fluid">
         <div class="row">
             <div class="col-md-12 page-header" >
                   <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
             </div>
         </div>
        <asp:Panel ID="pnlContents" runat="server">

                <div class="row">
                    <table style="width:7in">
                        <tr style="border-bottom:solid 1px;border-top: solid 1px;border-top-color:#000;margin-bottom:15px;">
                            <th>Sl. No</th>
                            <th>Name of the Mover</th>
                            <th >Contents of the Motion</th>
                        </tr>
                        <asp:ListView ID="MotionLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 10%; font-size: 14pt; text-align: center; vertical-align: top; font-family: 'Times New Roman';" > 
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                        <td style="width:35%; font-size: 14pt; text-align: left; vertical-align: top; font-family: 'Times New Roman';">
                                        <asp:Label ID="Label6" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' /><br />
                                        <asp:Label ID="Label3" runat="server" Text='<%#"M.D. NO." + Eval("MotionDiaryNo")%>' />
                                        <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />
                                    </td>
                                    <td style="width: 55%; font-size: 14pt; text-align: justify; font-family: 'Times New Roman'; vertical-align:top;" >
                                        <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("Description")).Trim()%>'></asp:Label></td>


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
            printWindow.document.write("<html><head><style> body {font-family:'Times New Roman' ;font-size: 18px ;} p { page-break-after: always; }.footer { position: fixed; bottom: 0px; }.pagenum::before {counter-increment: page;counter-reset: page 1;content: counter(page+1); }th,td {padding: 1px ;}th {border-bottom: 2px solid #333333 ;font-size: 12px ;font-weight:bold;}td {/*border-bottom: 1px dotted #999999 ;*/ font-size: 12px ;}tfoot td {/* border-bottom-width: 0px ;border-top: 2px solid #333333 ;*/padding-top: 3px ;padding-bottom: 3px;}.Headings{font-size:12px;text-align:center;}.page-break{ page-break-before: always; }.print-tab{padding: 5px;line-height: 1.42857143;vertical-align: top;}@page {size: A4;margin-top:50px;margin-bottom:50px;}@media print {footer {position: fixed;bottom: 0;}header {position: fixed;top: 0;}.content-block, p {page-break-inside: avoid;}}</style><link href='./Content/bootstrap.min.css' rel='stylesheet' /><title></title>");
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
