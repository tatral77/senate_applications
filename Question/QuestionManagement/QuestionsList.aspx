<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionsList.aspx.cs" Inherits="QuestionManagement.QuestionsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
         <div class="row">
             <div class="col-md-3">
                <h4 class="page-header">QUESTIONS LIST</h4>
            </div>
        </div>
    </div>
     <div class="container  regularDiv">

         <div class="row">
             <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionDDL">Session No:</label>
                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" AutoPostBack="true"  runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
              
                </asp:DropDownList>
            </div>
               <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionDDL">Category:</label>
                <asp:DropDownList ID="CategoryDDL" class="form-control control-txt" Required="true" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged">
              
                </asp:DropDownList>
            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionDDL">Group No:</label>
                <asp:DropDownList ID="GroupDDL" class="form-control control-txt" Required="true"  runat="server" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged">
              
                </asp:DropDownList>
            </div>
               <div class="col-md-2">
                <label class="control-lbl-sm" for="StartNoTxt">Start No:</label>
                   <asp:TextBox ID="StartNoTxt" Type="number" CssClass="form-control" runat="server" Required="true"></asp:TextBox>
            </div>
            
               <div class="col-md-2">
                <label class="control-lbl-sm" for="StartNoTxt">List Name:</label>
                   <asp:TextBox ID="ListName" CssClass="form-control" runat="server" Required="true"></asp:TextBox>
            </div>
              <div class="col-md-2">
                <label class="control-lbl-sm" for="StartNoTxt">House Lay Date:</label>
                   <asp:TextBox ID="ListDateTxt" CssClass="form-control datepicker js-date" runat="server" Required="true"></asp:TextBox>
            </div>
            
        </div>
           <div class="row">
             <br />
               <div class="col-md-3">      
                   <label class="control-lbl-sm" for="StartNoTxt">Include Deffered Questions:</label>       
                   <asp:CheckBox ID="AddDefferCB" CssClass="form-control" runat="server" Checked="true" />
              </div>


               <div class="col-md-2">
             <br />
                  <asp:Button ID="GenerateBtn" runat="server" Text="Generate"  class="btn btn-custom" OnClick="GenerateBtn_Click"/>
                  <asp:Button ID="SaveList" runat="server" Text="Save"  class="btn btn-custom" OnClick="SaveList_Click" />
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
<th> List Name</th>
<th>Session Number</th>
<th>List Date</th>
<th>Group</th>
<th>Category</th>
<th>Start Number</th>
<th>Action</th>
</tr>
 <asp:ListView ID="ListView1" runat="server"
     OnItemDeleting="ItemDeleting">

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidQuestionsListNo" runat="server" Value='<%#Bind("QuestionsListId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#Eval("ListName")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#GetSessionName(Convert.ToInt32(Eval("AssemblySessionsId")))%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label2" runat="server" Text='<%#Convert.ToDateTime(Eval("ListDate")).ToShortDateString()%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="DescriptionTxt" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("GroupsId")))%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label3" runat="server" Text='<%#Eval("Category")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="StartNo" runat="server" Text='<%#Eval("StartNo") + " - " + Eval("LastNumber")%>'></asp:Label></td>
    <%--<td class="itemLeft" style="text-wrap:normal"><%#Eval("Questions")%></td>--%>
    <td class="itemCent">
                              <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                          <asp:HyperLink ID="PrintBtn" Target="_blank" NavigateUrl='<%#GetPrintLink(Eval("QuestionsListId").ToString())%>'  class="btn btn-custom" runat="server"  
                                 ToolTip="Print"><span class="glyphicon glyphicon-print"></span></asp:HyperLink>
                          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#GetSuplementaryLink(Eval("QuestionsListId").ToString())%>'  class="btn btn-custom" runat="server"  
                                 ToolTip="Print">Supplementary</span></asp:HyperLink>
                        </td>
  </tr>
 </ItemTemplate>

                 </asp:ListView>
     </table>
             </div>
        </div>
    </div>
    <div class="container container-fluid">
        <asp:Panel id="pnlContents" runat = "server">
           
         <div class="row">
             <table  style="width:650px;margin:20px">
               <asp:ListView ID="DeferLV" runat="server">
                 <ItemTemplate>
                     <tr>                         
                         <td>
                                <asp:HiddenField ID="HidQid" Value='<%#Eval("QuestionId")%>' runat="server" />
                                <asp:HiddenField ID="HidListNo" Value='<%#Eval("ListNo")%>' runat="server" />

                             <u><asp:Label Style="font-size:13pt;font-family:'Times New Roman';font-weight:bold;font-style: italic;line-height:1.7em" ID="SenatorNameLbl" runat="server" Text='<%#GetDefSenatorName(Convert.ToInt32(Eval("ListNo")),Eval("SuplementaryNo").ToString(),Convert.ToString(Eval("MoverName")))%>'></asp:Label></u></td>
                         </tr>
                    <tr>
                         <td><asp:Label ID="NoticeLbl" style="font-size:13pt;font-style: italic;line-height:1.7em" runat="server" Text='<%#GetNoticeDateTime(Convert.ToDateTime(Eval("NoticeDiaryDate")),Convert.ToDateTime(Eval("NoticeDiaryTime")),Convert.ToInt32(Eval("QuestionId")))%>'></asp:Label></td>
                         </tr>
                    <tr>
                         <td style="font-size:13pt;text-align:justify;font-style: italic;font-family:'Times New Roman';line-height:1.7em"><asp:Label ID="QuestionLbl"  runat="server" Text='<%#Convert.ToString(Eval("QuestionText")).Trim()%>'></asp:Label></td>


                     </tr>

                 </ItemTemplate>
             </asp:ListView>
                
             <asp:ListView ID="ListLV" runat="server">
                  <ItemTemplate>
                     <tr>
                        
                         <td>
                              <asp:HiddenField ID="HidQid" Value='<%#Eval("QuestionId")%>' runat="server" />
                         <asp:HiddenField ID="HidListNo" Value='<%#Eval("ListNo")%>' runat="server" />
                             <u><asp:Label Style="font-size:13pt;font-family:'Times New Roman';font-weight:bold;font-style: italic;line-height:1.5;" ID="SenatorNameLbl" runat="server" Text='<%#GetListSenatorName(Convert.ToInt32(Eval("ListNo")),Convert.ToString(Eval("MoverName")))%>'></asp:Label></u></td>
                         </tr>
                    <tr>
                         <td><asp:Label ID="NoticeLbl" style="font-size:13pt;font-style: italic; line-height:1.5;" runat="server" Text='<%#GetNoticeDateTime(Convert.ToDateTime(Eval("NoticeDiaryDate")),Convert.ToDateTime(Eval("NoticeDiaryTime")),Convert.ToInt32(Eval("QuestionId")))%>'></asp:Label></td>
                         </tr>
                    <tr>
                         <td style="font-size:13pt;text-align:justify;font-style: italic;font-family:'Times New Roman';line-height:1.5;"><asp:Label ID="QuestionLbl"  runat="server" Text='<%#Convert.ToString(Eval("QuestionText")).Trim()%>'></asp:Label></td>


                     </tr>

                 </ItemTemplate>
             </asp:ListView>

                </table>
         </div>
            </asp:Panel>

        </div>
     
     <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
         $(document).ready(function () {
             $('.datepicker').datepicker({ dateFormat: 'dd-mm-yy' });
         });
        
       
        
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
