<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResolutionList.aspx.cs" Inherits="QuestionManagement.ResolutionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rl-header { margin: 6px 0 18px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; }
            .rl-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .rl-header p { margin: 0; font-size: 14px; color: #6b7785; }

        .rl-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 20px; }
        .rl-card-title { padding: 11px 18px; border-bottom: 1px solid #e4e9ee; background: #f8fafb; border-radius: 6px 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; display: flex; align-items: center; }
            .rl-card-title .rl-grow { flex: 1; }
        .rl-card-body { padding: 16px 18px 6px; }
            .rl-card-body .form-group { margin-bottom: 14px; }
            .rl-card-body label { font-size: 13px; font-weight: 600; color: #3c4858; margin-bottom: 4px; }

        .rl-steps { display: flex; flex-wrap: wrap; margin: 0 0 14px; padding: 0; list-style: none; font-size: 12px; color: #6b7785; }
            .rl-steps li { margin-right: 18px; }
            .rl-steps li b { display: inline-block; width: 20px; height: 20px; line-height: 20px; text-align: center; border-radius: 50%; background: #e8f0f9; color: #0c3a72; margin-right: 5px; }
        .rl-actions { display: flex; align-items: center; }
            .rl-actions .btn { margin-right: 8px; height: 34px; }
        .rl-error { color: #c0392b; font-size: 13px; padding: 0 18px 10px; }

        .rl-table { margin: 0; }
            .rl-table th { background: #e8f0f9; color: #0c3a72; font-size: 12px; text-transform: uppercase; letter-spacing: .03em; }
            .rl-table td { font-size: 13px; vertical-align: middle !important; }
            .rl-table .rl-btns { white-space: nowrap; text-align: right; }
            .rl-table .rl-btns .btn { margin-left: 4px; }
        .rl-count { display: inline-block; background: #0c3a72; color: #fff; border-radius: 12px; padding: 1px 10px; font-weight: 700; margin-left: 8px; font-size: 12px; letter-spacing: 0; }
        .rl-hint { text-align: center; padding: 34px 14px; color: #6b7785; font-size: 13px; }
        .rl-doc { padding: 0; }
        .rl-scroll { max-height: 70vh; overflow: auto; }
        .rl-preview { width: 100%; border-collapse: separate; border-spacing: 0; }
            .rl-preview th { position: sticky; top: 0; z-index: 2; background: #e8f0f9; color: #0c3a72; font-size: 12px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; text-align: left; padding: 10px 14px; border-bottom: 2px solid #c9d6e4; }
            .rl-preview td { padding: 12px 14px; vertical-align: top; border-bottom: 1px solid #edf1f5; font-family: Georgia, 'Times New Roman', serif; font-size: 14px; line-height: 1.6; color: #1f2d3d; }
            .rl-preview tbody tr:nth-child(even) td { background: #f8fafc; }
            .rl-preview tbody tr:hover td { background: #eef5fc; }
            .rl-preview .rl-sl { width: 64px; text-align: center; }
            .rl-preview .rl-mover { width: 26%; min-width: 200px; }
            .rl-preview .rl-body { text-align: justify; }
        .rl-num { display: inline-block; min-width: 30px; height: 30px; line-height: 30px; border-radius: 15px; background: #0c3a72; color: #fff; font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 12px; font-weight: 700; text-align: center; }
        .rl-rd { display: inline-block; margin-top: 6px; padding: 1px 9px; border-radius: 10px; background: #eef1f5; color: #4a5b6d; font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 11px; font-weight: 600; letter-spacing: .02em; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">

        <div class="rl-header">
            <h3>Resolution Lists</h3>
            <p>Create the list of admitted resolutions for a session, and manage the lists already saved</p>
        </div>

        <%-- Create a list --%>
        <div class="rl-card">
            <div class="rl-card-title">Create a new list</div>
            <div class="rl-card-body">
                <ol class="rl-steps">
                    <li><b>1</b>Choose the session</li>
                    <li><b>2</b>Click Generate to preview the admitted resolutions</li>
                    <li><b>3</b>Name the list, set its date and Save</li>
                </ol>
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="SessionDDL">Session No</label>
                        <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" AutoPostBack="true" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSession" runat="server" ControlToValidate="SessionDDL" InitialValue="0" ErrorMessage="Select a session" ValidationGroup="GenerateGroup" Display="Dynamic" ForeColor="#c0392b"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="ListName">List Name</label>
                        <asp:TextBox ID="ListName" CssClass="form-control" runat="server" Required="true" placeholder="e.g. Resolutions - Session 320"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="ListName" ErrorMessage="Enter a list name" ValidationGroup="SaveGroup" Display="Dynamic" ForeColor="#c0392b"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="ListDateTxt">List Date</label>
                        <asp:TextBox ID="ListDateTxt" CssClass="form-control js-date" runat="server" Required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="ListDateTxt" ErrorMessage="Enter the list date" ValidationGroup="SaveGroup" Display="Dynamic" ForeColor="#c0392b"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5 form-group">
                        <label>&nbsp;</label>
                        <div class="rl-actions">
                            <asp:Button ID="GenerateBtn" runat="server" Text="Generate" class="btn btn-info" ValidationGroup="GenerateGroup" OnClick="GenerateBtn_Click" />
                            <asp:Button ID="SaveList" runat="server" Text="Save list" class="btn btn-custom" ValidationGroup="SaveGroup" OnClick="SaveList_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="ErrorLbl" runat="server" CssClass="rl-error" Visible="false"></asp:Label>
        </div>

        <%-- Preview of the list being created --%>
        <div class="rl-card">
            <div class="rl-card-title"><span class="rl-grow">Preview of the list <asp:Literal ID="CountLit" runat="server"></asp:Literal></span></div>
            <asp:Panel ID="HintPnl" runat="server" CssClass="rl-hint">
                <asp:Literal ID="HintLit" runat="server"></asp:Literal>
            </asp:Panel>
            <div class="rl-doc">
                <asp:Panel ID="pnlContents" runat="server">
                    <div class="rl-scroll">
                    <table class="rl-preview">
                        <thead>
                            <tr>
                                <th class="rl-sl">Sl. No</th>
                                <th class="rl-mover">Name of the Mover</th>
                                <th>Contents of the Resolution</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="ResolutionLV" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="rl-sl">
                                            <asp:HiddenField ID="HidResolutionsId" runat="server" Value='<%#Bind("ResolutionsId")%>' />
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Container.DataItemIndex + 1%> ' />
                                            <span class="rl-num"><asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></span></td>
                                        <td class="rl-mover">
                                            <asp:Label ID="Label7" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("ResolutionsId")))%>' />
                                            <div class="rl-rd"><asp:Label ID="Label8" runat="server" Text='<%#"R.D. No. " + Eval("ResolutionDiaryNo")%>' /></div>
                                        </td>
                                        <td class="rl-body">
                                            <asp:Label ID="Label9" runat="server" Text='<%#Convert.ToString(Eval("Description")).Trim()%>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                    </div>
                </asp:Panel>
            </div>
        </div>

        <%-- Lists already saved --%>
        <div class="rl-card">
            <div class="rl-card-title">Saved lists for the selected session</div>
            <table class="table table-hover rl-table">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>List Name</th>
                        <th>Session Number</th>
                        <th>List Date</th>
                        <th style="text-align: right">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemDeleting="ItemDeleting">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidResolutionListNo" runat="server" Value='<%#Bind("ResolutionsListId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ListName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#GetSessionName(Convert.ToInt32(Eval("AssemblySessionsId")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Convert.ToDateTime(Eval("ListDate")).ToShortDateString()%>'></asp:Label></td>
                                <td class="rl-btns">
                                    <asp:HyperLink ID="PrintBtn" NavigateUrl='<%#GetPrintLink(Eval("ResolutionsListId").ToString())%>' class="btn btn-default btn-sm" runat="server" Target="_blank"
                                        ToolTip="Print this list"><span class="glyphicon glyphicon-print"></span> Print</asp:HyperLink>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger btn-sm" runat="server" CommandName="delete"
                                        ToolTip="Delete this list" OnClientClick="return confirm('Delete this list? Its resolutions will become available for a new list.');"><span class="glyphicon glyphicon-trash"></span> Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="5" class="rl-hint">No list has been saved for this session yet.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>

    </div>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=500,width=1000');
            printWindow.document.write("<html><head><style> body {font-family:'Times New Roman' ;font-size: 18px ;} p { page-break-after: always; }.footer { position: fixed; bottom: 0px; }.pagenum::before {counter-increment: page;counter-reset: page 1;content: counter(page+1); }th,td {padding: 1px ;}th {border-bottom: 2px solid #333333 ;font-size: 12px ;font-weight:bold;}td {font-size: 12px ;}tfoot td {padding-top: 3px ;padding-bottom: 3px;}.Headings{font-size:12px;text-align:center;}.page-break{ page-break-before: always; }.print-tab{padding: 5px;line-height: 1.42857143;vertical-align: top;}@page {size: A4;margin-top:50px;margin-bottom:50px;}@media print {footer {position: fixed;bottom: 0;}header {position: fixed;top: 0;}.content-block, p {page-break-inside: avoid;}}</style><link href='./Content/bootstrap.min.css' rel='stylesheet' /><title></title>");
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
