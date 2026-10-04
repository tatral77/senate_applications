  <%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MotionList.aspx.cs" Inherits="QuestionManagement.MotionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h4 class="page-header">MOTIONS LIST</h4>
            </div>
        </div>
    </div>
    <div class="container  regularDiv">

        <div class="row">
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionDDL">Session No:</label>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" AutoPostBack="true" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
                </asp:DropDownList>
            </div>
      
        <div class="col-md-2">
            <label class="control-lbl-sm" for="StartNoTxt">List Name:</label>
            <asp:TextBox ID="ListName" CssClass="form-control" runat="server" Required="true"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label class="control-lbl-sm" for="StartNoTxt">List Date:</label>
            <asp:TextBox ID="ListDateTxt" CssClass="form-control js-date" runat="server" Required="true"></asp:TextBox>
        </div>

       
            <div class="col-md-2">
                <br />
                <asp:Button ID="GenerateBtn" runat="server" Text="Generate" class="btn btn-custom" OnClick="GenerateBtn_Click" />

                <asp:Button ID="SaveList" runat="server" Text="Save" class="btn btn-custom" OnClick="SaveList_Click" />
                <%--  <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />--%>
            </div>
        </div>
    </div>
        <br />
        <div class="container  regularDiv">

            <div class="row">
                <div class="col-md-12">
                    <table class="table table-condensed table-striped table-data">
                        <tr>
                            <th>Sr#</th>
                            <th>List Name</th>
                            <th>Session Number</th>
                            <th>List Date</th>
                            <th>Action</th>
                        </tr>
                        <asp:ListView ID="ListView1" runat="server"
                            OnItemDeleting="ItemDeleting">

                            <ItemTemplate>
                                <tr>

                                    <asp:HiddenField ID="HidMotionListNo" runat="server" Value='<%#Bind("MotionListId")%>' />
                                    <td class="itemCent">
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ListName")%>'></asp:Label></td>

                                    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#GetSessionName(Convert.ToInt32(Eval("AssemblySessionsId")))%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Convert.ToDateTime(Eval("ListDate")).ToShortDateString()%>'></asp:Label></td>
                                    <td class="itemCent">
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                        <asp:HyperLink ID="PrintBtn" NavigateUrl='<%#GetPrintLink(Eval("MotionListId").ToString())%>'  class="btn btn-custom" runat="server"  
                                 ToolTip="Print"><span class="glyphicon glyphicon-print"></span></asp:HyperLink>
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:ListView>
                    </table>
                </div>
            </div>
        </div>
        <div class="container">
            <asp:Panel ID="pnlContents" runat="server">

                <div class="row">
                    <table style="width: 100%">
                        <tr>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Sl.No</th>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Name of the Mover</th>
                            <th style="background-color: #fff; color: #000; font-size: 13pt; font-weight: bold; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1.7em;">Contents of the Motion</th>
                        </tr>
                        <asp:ListView ID="MotionLV" runat="server">
                            <ItemTemplate>
                                <tr style="padding-bottom:1em;">


                                    <td style="width: 5em; font-size: 13pt; text-align: justify; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;"> 
                                        <asp:HiddenField ID="HidMotionsId" runat="server" Value='<%#Bind("MotionsId")%>' />
                                        <asp:HiddenField ID="HidListId" runat="server" Value='<%#Container.DataItemIndex + 1%> ' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td style="width: 45em; font-size: 13pt; text-align: left; vertical-align: top; font-family: 'Times New Roman'; line-height: 1em;">
                                        <asp:Label ID="Label6" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("MotionsId")))%>' />
                                        <asp:Label ID="Label3" runat="server" Text='<%#"(M.D. NO." + Eval("MotionDiaryNo") + ")"%>' />
                                       <%-- <asp:Label ID="Label5" runat="server" Text='<%#" (MID-" + Eval("MotionsId") + ")"%>' />--%>
                                    </td>
                                    <td style="width: 75em; font-size: 13pt; text-align: justify; font-family: 'Times New Roman'; line-height: 1em;">
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
             printWindow.print();



         }
            function ExportPdf() {
                return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { fallback: PrintPanel });
            }
        </script>
</asp:Content>
