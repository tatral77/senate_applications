<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMotionList.aspx.cs" Inherits="MotionBranch.PrintMotionList" %>

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
             </div>
         </div>
        <asp:Panel ID="pnlContents" runat="server">

                 <div class="row">
                <table class="table table-condensed" style="width: 100%">
                    <tr>
                        <td colspan="6" style="font-weight: bold; text-decoration: underline; text-align: center">
                            <asp:Label ID="DefferedLabel" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">S.No</th>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">MID / Date</th>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Name of the Mover</th>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Contents of the Motion</th>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Status / Remarks</th>
                        <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold;  vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Ministry</th>
                    </tr>
                    <asp:ListView ID="DefferedLV" runat="server" Visible="false">
                        <ItemTemplate>
                            <tr style="padding-bottom: 1em;">
                                <td style="font-size: 13pt; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:HiddenField ID="HidMotionsId" runat="server" Value='<%#Bind("MotionsId")%>' />
                                    <asp:HiddenField ID="HidListId" runat="server" Value='<%#Container.DataItemIndex + 1%> ' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td style="font-size: 13pt; text-align: left; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                   <asp:Label ID="Label7" runat="server" Text='<%#Eval("MotionsId") + " / " + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString() + " " + Convert.ToDateTime(Eval("NoticeDiaryTime")).ToShortDateString() %>' />
                                    <%-- <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />--%>
                                </td>
                                <td style="font-size: 13pt; text-align: left; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:Label ID="Label6" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />

                                    <%-- <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />--%>
                                </td>
                                <td style="font-size: 13pt; text-align: justify; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("Description")).Trim()%>'></asp:Label></td>
                                <td style="font-size: 14pt; text-align: justify; font-family: 'Times New Roman'; vertical-align: top;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToString(Eval("MotionStatus")).Trim()%>'></asp:Label></td>
                                <td style="font-size: 14pt; text-align: justify; font-family: 'Times New Roman'; vertical-align: top;">
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetMinistries(Convert.ToInt32(Eval("MotionsId")))%>'></asp:Label></td>


                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <tr>
                        <td colspan="6" style="font-weight: bold; text-decoration: underline; text-align: center">
                            <asp:Label ID="MotionListLbl" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                    <asp:ListView ID="MotionLV" runat="server" Visible="false">
                        <ItemTemplate>
                            <tr style="padding-bottom: 1em;">
                                <td style="font-size: 13pt; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:HiddenField ID="HidMotionsId" runat="server" Value='<%#Bind("MotionsId")%>' />
                                    <asp:HiddenField ID="HidListId" runat="server" Value='<%#Container.DataItemIndex + 1%> ' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td style="font-size: 13pt; text-align: left; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("MotionsId") + " / " + Convert.ToDateTime(Eval("NoticeDiaryDate")).ToShortDateString() + " " + Convert.ToDateTime(Eval("NoticeDiaryTime")).ToShortDateString() %>' />
                                    <%-- <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />--%>
                                </td>
                                <td style="font-size: 13pt; text-align: left; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:Label ID="Label6" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />

                                    <%-- <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />--%>
                                </td>
                                <td style="font-size: 13pt; text-align: justify; font-family: 'Times New Roman'; line-height: 1em;">
                                    <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("Description")).Trim()%>'></asp:Label></td>
                                <td style="font-size: 14pt; text-align: justify; font-family: 'Times New Roman'; vertical-align: top;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToString(Eval("MotionStatus")).Trim()%>'></asp:Label></td>
                                <td style="font-size: 14pt; text-align: justify; font-family: 'Times New Roman'; vertical-align: top;">
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetMinistries(Convert.ToInt32(Eval("MotionsId")))%>'></asp:Label></td>


                            </tr>
                        </ItemTemplate>
                    </asp:ListView>

                </table>

                <%-- <div class="row">
                    <table style="width: 100%">
                        <tr>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">S.No</th>
                             <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">MID / Date</th>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Name of the Mover</th>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Contents of the Motion</th>
                        </tr>
                --%>
            </div>
            </asp:Panel>

        </div>
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
     </script>
    </form>
</body>
</html>