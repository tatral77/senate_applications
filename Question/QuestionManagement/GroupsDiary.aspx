<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GroupsDiary.aspx.cs" Inherits="QuestionManagement.GroupsDiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <div class="container">
             <div class="row">
      <div class="col-md-12 ">
          <h4 class="page-header">Group Diary</h4>
      </div>
  </div>
        </div>
         <div class="container  regularDiv">
            
         <div class="row">
             <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionDDL">Session No:</label>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
              
                </asp:DropDownList>
            </div>
               <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control control-txt" Required="true" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged">
              
                </asp:DropDownList>
            </div>
             <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionDDL">Group No:</label>
                <asp:DropDownList ID="GroupDDL" class="form-control control-txt" Required="true"  runat="server">
              
                </asp:DropDownList>
            </div>
              
              <div class="col-md-3">
                  <br />
                  <asp:Button ID="GenerateBtn" runat="server" Text="Generate"  class="btn btn-custom" OnClick="GenerateBtn_Click"/>
           
                  
             <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
        </div>
        </div>
    </div>
<div class="container">
    <div class="row top-buffer">
        <div class="col-md-4">
            <table class="table table-responsive" border="0">
              <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Style="font-size: 10pt;" ID="Label1" runat="server" Text='<%#Eval("Category") %>'></asp:Label>

                        </td>
                        <td Style="font-size: 10pt; text-align:right;">

                            <asp:Label ID="Label2"  runat="server" Text='<%#Eval("ProductCount") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
                  <tr>
                        <td>
                            <asp:Label Style="font-size: 10pt;font-weight:bold" ID="Label12" runat="server" Text="Total Questions"></asp:Label>

                        </td>
                        <td Style="font-size: 10pt; text-align:right;font-weight:bold ">

                           <asp:Label ID="totalquestions" runat="server"></asp:Label>
                        </td>
                    </tr>
                 <tr>
                        <td>
                            <asp:Label Style="font-size: 10pt;" ID="Label1" runat="server" Text="Included in List"></asp:Label>

                        </td>
                        <td Style="font-size: 10pt; text-align:right;">

                           <asp:Label ID="listquestions" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
            </table>
           
        </div>

        <div class="col-md-5">

             <table class="table table-responsive" border="0">
              <asp:ListView ID="MembersCountLv" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Style="font-size: 10pt;" ID="Label1" runat="server" Text='<%#Eval("Category") %>'></asp:Label>

                        </td>
                        <td Style="font-size: 10pt; text-align:right;">

                            <asp:Label ID="Label2"  runat="server" Text='<%#Eval("MemberCount") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
</table>

        </div>
    </div>
</div>
<asp:Panel id="pnlContents" runat = "server">
<div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <asp:Label ID="Headerlbl" runat="server" style="font-weight:bold" Text=""></asp:Label></div>
    <table class="table">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>QID</th>
          <th>QDN</th>
          <th>List Id/Date</th>            
          <th>Mover</th>
          <th>Subject</th>
           <th>Division</th>
          <th>Notice Diary/Date</th>
          <th>Remarks</th>
          <th>Current Status</th>
       
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="LVStatus" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>  runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                            <asp:Label ID="Label1" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#Bind("QuestionId")%>' />
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label11" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                        </td>
                         <td style="text-align:center">
                            <asp:Label ID="Label10" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#GetListNo(Convert.ToInt32(Eval("ListNo")),Convert.ToString(Eval("SupListNo")), Convert.ToDateTime(Eval("ListDate"))) %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label4" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#Bind("Mover")%>' />
                        </td>
                        <td style="text-align:justify">
                            <asp:Label ID="Label2" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>  runat="server" Text='<%#GetMinText(Eval("QuestionText").ToString())%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label5" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#Bind("DivisionName")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label7" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#GetNoticeInfo(Convert.ToInt32(Eval("NoticeDiaryNo")),Convert.ToDateTime(Eval("NoticeDiaryDate")),Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label8" class="table-data" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>   runat="server" Text='<%#Bind("Remarks")%>'/>
                        </td>
                        <td>     
                            <%--<%#GetStatus(Eval("QuestionStatus").ToString()) %>  --%>        
                           <asp:Label ID="descriptionLabel" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%> class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                            <asp:Label ID="Label20" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%> class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                            <asp:Label ID="Label9" class="table-data" runat="server" style=<%#GetColour(Convert.ToString(Eval("QuestionStatus")),Convert.ToInt32(Eval("ListNo")))%>  Text='<%#GetDate(Convert.ToDateTime(Eval("ReplyDate")))%>' />
                        </td>
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
    </div>
            </div>
        </div>
    </asp:Panel>
     <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">


        
       function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html moznomarginboxes mozdisallowselectionprint><head><style> body {font-family: verdana, arial, sans-serif ;font-size: 10px ;}p { page-break-after: always; }.footer { position: fixed; bottom: 0px; }.pagenum::before {counter-increment: page;counter-reset: page 1;content: counter(page+1); }th,td {padding: 1px ;}th {border-bottom: 2px solid #333333 ;font-size: 12px ;font-weight:bold;}td {/*border-bottom: 1px dotted #999999 ;*/ font-size: 12px ;}tfoot td {/* border-bottom-width: 0px ;border-top: 2px solid #333333 ;*/padding-top: 3px ;padding-bottom: 3px;}.Headings{font-size:12px;text-align:center;}.page-break{ page-break-before: always; }.print-tab{padding: 5px;line-height: 1.42857143;vertical-align: top;}@page {size: A4;margin-top:50px;margin-bottom:50px;}@media print {footer {position: fixed;bottom: 0;}header {position: fixed;top: 0;}.content-block, p {page-break-inside: avoid;}}</style><link href='./Content/bootstrap.min.css' rel='stylesheet' /><title></title>");
            printWindow.document.write('</head><body><div class="footer">Page: <span class="pagenum"></span></div>');
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
