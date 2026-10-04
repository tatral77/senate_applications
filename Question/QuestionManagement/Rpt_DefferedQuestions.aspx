<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_DefferedQuestions.aspx.cs" Inherits="QuestionManagement.Rpt_DefferedQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<!DOCTYPE html><html><head><link href='../Styles/Printing2.css' rel='stylesheet' /> <link href='./Content/bootstrap.min.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Questions Branch</u></div><br>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                   <div class="row page-header">
            <div class="col-md-12">
                <h4 style="color: #000;">DEFFERED QUESTIONS (CURRENT SESSION)</h4>
            </div>
        </div>
          <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
<input type="button" class="btn btn-primary" value="Export PDF" onclick="return ExportPdf();" />
        <asp:Panel ID="pnlContents" ClientIDMode="Static" runat="server" CssClass="print-panel">
        <table class="table table-condensed table-data" style="border-collapse: collapse;width:100%">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>QID</th>
                        <th class="no-print">Q-DN</th>
                        <th class="no-print">List No</th>
                        <th>Session Number</th>
                        <th>Group / Division</th>
                        <th>Notice No / Date /Time</th>
                       <%--  <th>Subject Matter</th>--%>
                        <th>Category</th>
                        <th>Submitted By</th>
                        <th>Status</th>
                        <%--  <th>Carry Fwd</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll_CheckedChanged" /></th>--%>
                        <th class="no-print">Action</th>
                    </tr>
                </thead>
               
                    <asp:ListView ID="DefferedLV" runat="server">

                        <ItemTemplate>
                            <tbody class="keep-together">
                            <tr>
                                <td>

                                    <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                             
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("QuestionId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionId")%>' />
                                </td>
                                <td style="text-align:center" class="no-print">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("QuestionDiaryNo") %>' />

                                </td>
                                <td style="text-align:center" class="no-print">
                                    <asp:Label ID="Label23"  runat="server" Text='<%#Bind("ListNo") %>' />

                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("SessionName")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionId")%>' />
                                </td>
                               <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Group")%>' /><br />
                                    <asp:Label ID="Label24" runat="server" Text='<%#Eval("Division")%>' />
                                </td>
                                <td>

                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' /><br />
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>
                                
                              <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Category")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="rankLabel" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="descriptionLabel" runat="server" Text='<%#Bind("Status")%>' /><br />
                                    <asp:Label ID="Label20" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                </td>
                                <td id="fullPrint" runat="server"  class="no-print">
                                    <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom" />
                                </td>
                                  <td ID="restrictedPrint" runat="server" Visible="false">
                                    <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom" />
                                </td>

                            </tr>
                            <tr>
                                   <td colspan="10"  style="text-align: justify;" class="subject-matter" runat="server" ID="FullSearch">
                                    <asp:HyperLink  ID="HyperLink1" CssClass="table-data" runat="server" style="color:black;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionId").ToString())%>'><%#Eval("QuestionText")%></asp:HyperLink>
                                </td>
                                  <td colspan="10" style="text-align: justify;" runat="server" ID="RestrictedSearch" visible="false">
                                    <asp:HyperLink  ID="HyperLink3" CssClass="table-data" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionId").ToString())%>'><%#Eval("QuestionText")%></asp:HyperLink>
                                </td>
                            </tr>
                            </tbody>
                        </ItemTemplate>

                    </asp:ListView>
               
            </table>
            </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
