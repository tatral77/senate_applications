<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NoticeSummary.aspx.cs" Inherits="Notice.NoticeSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".date").datepicker(
                {
                    dateFormat: 'dd/mm/y',//check change
                    changeMonth: true,
                    changeYear: true
                });


        });
    </script>
    <style type="text/css">
  .avoid {
    page-break-inside: avoid !important;
    page-break-after: avoid !important;
    page-break-before:avoid !important;
   /* margin: 4px 0 4px 0;   to keep the page break from cutting too close to the text in the div */
  }
  p{
       page-break-inside: avoid !important;
    page-break-after: avoid !important;
    page-break-before:avoid !important;
  }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <h4 class="page-header">Notice Summary</h4>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="From Date" for="FromdateTxt"></asp:Label>
                <asp:TextBox ID="FromdateTxt" ClientIDMode="Static" CssClass="form-control date js-date" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label4" runat="server" Text="To Date" for="ToDateTxt"></asp:Label>
                <asp:TextBox ID="ToDateTxt" ClientIDMode="Static" CssClass="form-control date js-date" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2" style="padding-top: 20px">
                <asp:Button Cssclass="btn btn-custom" ID="Button2" runat="server" Text="View Summary" OnClick="Button1_Click" />
            </div>
            <div class="col-md-4">
                <br />
                  <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print Report" OnClientClick="return PrintPanel();" />
            </div>
        </div>
          <asp:Panel ID="pnlContents" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h3>Questions</h3>
                </div>
                <table class="table table-condensed">
                    <tr>
                        <th>Sr#</th>
                        <th>Notice Diary Number</th>
                        <th>Notice Diary Date</th>
                        <th>Notice Diary Time</th>
                        <th>Session Number</th>
                        <th>Mover</th>
                        <th>Category</th>
                        <th>Description</th>
                        <%-- <th>File Attached</th>
                              <th>Status</th>--%>
                        <th>Receipt confirmed</th>
                        <th>Action Taken</th>

                    </tr>

                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />

                                </td>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("NoticeOfficeDiaryNo")%>' />
                                </td>


                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NotiiceOfficeDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Convert.ToDateTime(Eval("NoticeOfficeTime")).ToShortTimeString()%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("AssemblySession")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("Mover")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Bind("BusinessType")%>' />
                                </td>
                                <td>
                                    <div class="avoid"><%#Eval("BusinessText")%></div>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetStatus(Convert.ToInt32(Eval("Checked")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#GetActionTaken(Convert.ToInt32(Eval("Processed")))%>' />
                                </td>

                            </tr>
                        </ItemTemplate>


                    </asp:ListView>
                </table>
            </div>
        </div>




           <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h3>Motions</h3>
                </div>
                <table class="table table-condensed">
                    <tr>
                        <th>Sr#</th>
                        <th>Notice Diary Number</th>
                        <th>Notice Diary Date</th>
                        <th>Notice Diary Time</th>
                        <th>Session Number</th>
                        <th>Mover</th>
                        <th>Category</th>
                        <th>Description</th>
                        <%-- <th>File Attached</th>
                              <th>Status</th>--%>
                        <th>Receipt confirmed</th>
                        <th>Action Taken</th>

                    </tr>

                    <asp:ListView ID="MotionsLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />

                                </td>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("NoticeOfficeDiaryNo")%>' />
                                </td>


                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NotiiceOfficeDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Convert.ToDateTime(Eval("NoticeOfficeTime")).ToShortTimeString()%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("AssemblySession")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("Mover")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Bind("BusinessType")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Bind("BusinessText")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetStatus(Convert.ToInt32(Eval("Checked")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#GetActionTaken(Convert.ToInt32(Eval("Processed")))%>' />
                                </td>

                            </tr>
                        </ItemTemplate>


                    </asp:ListView>
                </table>
            </div>
        </div>

          <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h3>Resolutions</h3>
                </div>
                <table class="table table-condensed">
                    <tr>
                        <th>Sr#</th>
                        <th>Notice Diary Number</th>
                        <th>Notice Diary Date</th>
                        <th>Notice Diary Time</th>
                        <th>Session Number</th>
                        <th>Mover</th>
                        <th>Category</th>
                        <th>Description</th>
                        <%-- <th>File Attached</th>
                              <th>Status</th>--%>
                        <th>Receipt confirmed</th>
                        <th>Action Taken</th>

                    </tr>

                    <asp:ListView ID="ResolutionsLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />

                                </td>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("NoticeOfficeDiaryNo")%>' />
                                </td>


                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NotiiceOfficeDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Convert.ToDateTime(Eval("NoticeOfficeTime")).ToShortTimeString()%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("AssemblySession")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("Mover")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Bind("BusinessType")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Bind("BusinessText")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetStatus(Convert.ToInt32(Eval("Checked")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#GetActionTaken(Convert.ToInt32(Eval("Processed")))%>' />
                                </td>

                            </tr>
                        </ItemTemplate>


                    </asp:ListView>
                </table>
            </div>
        </div>
</asp:Panel>
    </div>
    <script>
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head><link href='../Styles/Printing.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div style="font-size:x-large;text-align:center"><u>SENATE OF PAKISTAN</u></div>');
            printWindow.document.write('<div style="font-size:large;text-align:center"><u>Notice Branch</u></div><br>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

</asp:Content>
