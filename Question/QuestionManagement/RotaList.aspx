<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RotaList.aspx.cs" Inherits="QuestionManagement.RotaList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /* ---- on screen: the annexure as a sheet of paper ---- */
        .rota-toolbar { max-width: 230mm; margin: 12px auto; display: flex; align-items: center; flex-wrap: wrap; }
            .rota-toolbar .btn { margin-right: 8px; }
            .rota-toolbar .rota-note { margin-left: auto; font-size: 12px; color: #6b7785; }
        .rota-sheet {
            background: #fff;
            max-width: 230mm;
            margin: 0 auto 30px;
            padding: 16mm 15mm 18mm;
            border: 1px solid #e4e9ee;
            box-shadow: 0 2px 12px rgba(0,0,0,.12);
            font-family: 'Times New Roman', Times, serif;
            color: #111;
        }
        .rota-annex { text-align: right; font-size: 12pt; font-weight: bold; text-decoration: underline; margin-bottom: 8px; }
        .rota-title { text-align: justify; font-size: 12pt; line-height: 1.6; padding-bottom: 12px; margin-bottom: 14px; border-bottom: 2px solid #4a6a94; }
            .rota-title span { display: block; }

        .rota { width: 100%; border-collapse: collapse; }
            .rota thead { display: table-header-group; }
            .rota th { background: #e8f0f9; color: #0c3a72; font-size: 11pt; font-weight: bold; text-align: left; text-transform: uppercase; letter-spacing: .03em; padding: 9px 12px; border-top: 1px solid #9db7d5; border-bottom: 2px solid #9db7d5; }
            .rota td { padding: 11px 12px; vertical-align: top; border-bottom: 1px solid #d9dfe6; font-size: 12pt; line-height: 1.45; }
            .rota tbody tr:nth-child(even) td { background: #f8fafc; }
            .rota tr { page-break-inside: avoid; }
            .rota .c-list { width: 20%; font-weight: bold; }
            .rota .c-divs { width: 56%; }
            .rota .c-date { width: 24%; font-weight: bold; }
        .rota-group { display: inline-block; margin-bottom: 6px; padding: 1px 12px; border-radius: 10px; background: #0c3a72; color: #fff; font-family: 'Segoe UI', Tahoma, Arial, sans-serif; font-size: 10pt; font-weight: 700; letter-spacing: .03em; }
        .rota-divs { margin: 0; padding-left: 22px; }
            .rota-divs li { padding: 1px 0; }
        .rota-empty { text-align: center; padding: 30px; color: #6b7785; font-family: 'Segoe UI', Tahoma, Arial, sans-serif; }

        /* ---- on paper: only the annexure ---- */
        @page { size: A4; margin: 15mm 14mm 16mm 14mm; }
        @media print {
            .app-header, .app-navbar, #title-sec, #top-navbar, .rota-toolbar { display: none !important; }
            html, body { background: #fff !important; }
            .app-content, .app-content > .row, .app-content .col-md-12 { padding: 0 !important; margin: 0 !important; width: 100% !important; }
            .rota-sheet { border: 0; box-shadow: none; max-width: none; margin: 0; padding: 0; }
            .rota tbody tr:nth-child(even) td { background: transparent; }
            .rota th { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
            .rota-group { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
        }
    </style>
    <script src='<%= ResolveUrl("~/Scripts/qmsexport.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        // The page is laid out for paper (see the print styles), so printing is just window.print().
        function PrintPanel() {
            window.print();
            return false;
        }
        function ExportPdf() {
            return QMSExport.exportPdf("<%=pnlContents.ClientID %>", { title: "Rota List", fallback: PrintPanel });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="rota-toolbar">
        <a class="btn btn-default" href="SessionsRotaList.aspx">&larr; Back to rota lists</a>
        <asp:Button class="btn btn-primary" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
        <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
        <span class="rota-note">In the print window, turn on &ldquo;Background graphics&rdquo; to keep the heading shading.</span>
    </div>

    <div class="rota-sheet">
        <asp:Panel ID="pnlContents" runat="server">
            <div class="rota-annex">ANNEXURE</div>
            <div class="rota-title">
                <asp:Label ID="monthlbl" runat="server"></asp:Label>
            </div>
            <div id="divisions" runat="server"></div>
        </asp:Panel>
    </div>
</asp:Content>
