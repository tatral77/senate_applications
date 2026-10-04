<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PrintResolutionList.aspx.cs" Inherits="QuestionManagement.PrintResolutionList" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Resolution List</title>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <style type="text/css">
        /* ---- on screen: a sheet of paper on a light background ---- */
        html, body { background: #eef1f5; }
        .toolbar { max-width: 210mm; margin: 16px auto 12px; display: flex; align-items: center; }
            .toolbar .btn { margin-right: 8px; }
            .toolbar .note { margin-left: auto; font-size: 12px; color: #6b7785; }
        .sheet {
            background: #fff;
            max-width: 210mm;
            margin: 0 auto 30px;
            padding: 16mm 15mm 18mm;
            box-shadow: 0 2px 12px rgba(0,0,0,.15);
            font-family: 'Times New Roman', Times, serif;
            color: #111;
        }

        .doc-head { text-align: center; padding-bottom: 10px; margin-bottom: 14px; border-bottom: 2px solid #4a6a94; }
        .doc-org { font-size: 20pt; font-weight: bold; letter-spacing: .1em; color: #0c3a72; }
        .doc-sub { font-size: 12pt; letter-spacing: .06em; text-transform: uppercase; color: #4a5b6d; margin-top: 2px; }
        .doc-title { font-size: 15pt; font-weight: bold; margin-top: 10px; }
        .doc-meta { display: flex; justify-content: space-between; font-size: 11pt; color: #444; margin: 0 0 10px; }

        .res-table { width: 100%; border-collapse: collapse; }
            .res-table thead { display: table-header-group; }
            .res-table th { background: #e8f0f9; color: #0c3a72; font-size: 11pt; font-weight: bold; text-align: left; padding: 8px 10px; border-top: 1px solid #9db7d5; border-bottom: 2px solid #9db7d5; }
            .res-table td { padding: 10px; vertical-align: top; border-bottom: 1px solid #d9dfe6; font-size: 12pt; line-height: 1.5; }
            .res-table tbody tr:nth-child(even) td { background: #f8fafc; }
            .res-table tr { page-break-inside: avoid; }
            .res-table .c-sl { width: 7%; text-align: center; }
            .res-table .c-mover { width: 25%; text-align: left; }
            .res-table .c-text { text-align: justify; }
        .rd-no { display: inline-block; margin-top: 4px; font-size: 10pt; color: #555; }

        .doc-foot { margin-top: 16px; padding-top: 6px; border-top: 1px solid #d9dfe6; display: flex; justify-content: space-between; font-size: 9pt; color: #777; }

        /* ---- on paper ---- */
        @page { size: A4; margin: 16mm 14mm 18mm 14mm; }
        @media print {
            html, body { background: #fff; }
            .toolbar { display: none !important; }
            .sheet { box-shadow: none; max-width: none; margin: 0; padding: 0; }
            .res-table tbody tr:nth-child(even) td { background: transparent; }
            .res-table th { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
            .doc-foot { position: fixed; bottom: 0; left: 0; right: 0; background: #fff; }
            .res-table { margin-bottom: 14mm; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="toolbar">
            <a class="btn btn-default" href="ResolutionList.aspx">&larr; Back to lists</a>
            <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
            <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
            <span class="note">In the print window, turn on &ldquo;Background graphics&rdquo; to keep the heading shading.</span>
        </div>

        <div class="sheet">
            <asp:Panel ID="pnlContents" runat="server">

                <div class="doc-head">
                    <div class="doc-org">SENATE OF PAKISTAN</div>
                    <div class="doc-sub">List of Resolutions</div>
                    <div class="doc-title"><asp:Literal ID="ListNameLit" runat="server"></asp:Literal></div>
                </div>
                <div class="doc-meta">
                    <span><asp:Literal ID="MetaLit" runat="server"></asp:Literal></span>
                    <span><asp:Literal ID="CountLit" runat="server"></asp:Literal></span>
                </div>

                <table class="res-table">
                    <thead>
                        <tr>
                            <th class="c-sl">Sl. No</th>
                            <th class="c-mover">Name of the Mover</th>
                            <th class="c-text">Contents of the Resolution</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="ResolutionLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="c-sl">
                                        <asp:HiddenField ID="HidResolutionsId" runat="server" Value='<%#Bind("ResolutionsId")%>' />
                                        <asp:HiddenField ID="HidListId" runat="server" Value='<%#Container.DataItemIndex + 1%> ' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                    <td class="c-mover">
                                        <asp:Label ID="Label6" runat="server" Text='<%#GetMembers(Convert.ToInt32(Eval("ResolutionsId")))%>' /><br />
                                        <span class="rd-no"><asp:Label ID="Label3" runat="server" Text='<%#"R.D. NO." + Eval("ResolutionDiaryNo")%>' /></span>
                                    </td>
                                    <td class="c-text">
                                        <asp:Label ID="QuestionLbl" runat="server" Text='<%#Convert.ToString(Eval("Description")).Trim()%>'></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>

                <div class="doc-foot">
                    <span>Senate of Pakistan &mdash; Questions Branch</span>
                    <span>Printed on <asp:Literal ID="PrintedLit" runat="server"></asp:Literal></span>
                </div>

            </asp:Panel>
        </div>

        <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
        <script type="text/javascript">
            // The page itself is laid out for paper (see the print styles above), so printing is just window.print().
            function PrintPanel() {
                window.print();
                return false;
            }
            function ExportPdf() {
                return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "<%= ExportTitle %>", fallback: PrintPanel });
            }
        </script>
    </form>
</body>
</html>
