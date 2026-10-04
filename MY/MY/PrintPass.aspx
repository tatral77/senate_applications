<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPass.aspx.cs" Inherits="MY.PrintPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visitors Entry Pass</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style type="text/css">
        * { box-sizing: border-box; }
        html, body { margin: 0; }
        body { font-family: "Segoe UI", "Helvetica Neue", Calibri, Arial, sans-serif; font-size: 10.5pt; color: #111; background: #f0f0f0; -webkit-print-color-adjust: exact; print-color-adjust: exact; }

        .toolbar { max-width: 210mm; margin: 14px auto 0; display: flex; gap: 8px; justify-content: flex-end; }
        .toolbar button { padding: 8px 20px; border: 1px solid #bbb; border-radius: 999px; background: #fff; color: #111; font: 600 13px "Segoe UI", Arial, sans-serif; cursor: pointer; }
        .toolbar button:hover { background: #f4f4f4; }

        .sheet { width: 210mm; min-height: 297mm; margin: 12px auto 30px; padding: 20mm 22mm 16mm; background: #fff; border-radius: 4px; box-shadow: 0 6px 24px rgba(0, 0, 0, .14); }

        /* letterhead */
        .letterhead { padding-bottom: 12px; margin-bottom: 22px; position: relative; text-align: center; }
        .letterhead:after { content: ""; position: absolute; left: 0; bottom: 0; width: 100%; height: 1px; background: #cfcfcf; }
        .letterhead:before { content: ""; position: absolute; left: 0; bottom: -1px; left: 50%; margin-left: -28px; width: 56px; height: 3px; background: #111; z-index: 1; }
        .letterhead .org { font-size: 19pt; font-weight: 700; letter-spacing: 3.5px; line-height: 1.15; }
        .letterhead .branch { margin-top: 3px; font-size: 10pt; font-weight: 600; letter-spacing: 2px; color: #555; text-transform: uppercase; }

        /* reference + date */
        .refline { display: flex; justify-content: space-between; align-items: flex-end; margin-bottom: 22px; }
        .refline .lbl { display: block; font-size: 8pt; font-weight: 600; letter-spacing: 1.5px; text-transform: uppercase; color: #777; }
        .refline .val { font-size: 12pt; font-weight: 700; }
        .refline .r { text-align: right; }
        .refline .r .val { font-weight: 600; }

        .subject { margin: 0 0 16px; font-size: 14pt; font-weight: 700; letter-spacing: .5px; }
        .subject .k { display: block; margin-bottom: 2px; font-size: 8pt; font-weight: 600; letter-spacing: 1.5px; text-transform: uppercase; color: #777; }

        p { margin: 0 0 14px; line-height: 1.7; }
        p.lead { font-size: 11pt; }

        /* terms: small label beside the value, no borders */
        .terms { width: 100%; margin: 0 0 22px; border-collapse: collapse; }
        .terms td { padding: 6px 12px 6px 0; vertical-align: top; border: 0; }
        .terms td.k { width: 34mm; font-size: 8pt; font-weight: 600; letter-spacing: 1.2px; text-transform: uppercase; color: #777; padding-top: 9px; }
        .terms td.v { font-weight: 500; line-height: 1.5; }

        /* visitors: no borders, soft rows */
        table.visitors { width: 100%; margin: 4px 0 22px; border-collapse: separate; border-spacing: 0 3px; }
        table.visitors th { padding: 6px 10px; border: 0; background: transparent; font-size: 8pt; font-weight: 600; letter-spacing: 1.2px; text-transform: uppercase; color: #777; text-align: left; }
        table.visitors td { padding: 9px 10px; border: 0; background: #f6f6f6; font-size: 10.5pt; }
        table.visitors td:first-child { border-radius: 6px 0 0 6px; color: #777; }
        table.visitors td:last-child { border-radius: 0 6px 6px 0; }
        table.visitors td.n { font-weight: 600; }
        table.visitors tr { page-break-inside: avoid; }
        .empty { padding: 16px; text-align: center; color: #666; }

        .closing { color: #444; }
        .foot { display: flex; align-items: flex-end; justify-content: space-between; gap: 20px; margin-top: 30px; page-break-inside: avoid; }
        .foot .code { flex: 1; }
        .foot .code img { max-width: 100%; height: auto; max-height: 60px; }
        .foot .sign { min-width: 64mm; text-align: center; }
        .foot .sign .line { height: 38px; border-bottom: 1px solid #111; }
        .foot .sign .name { margin-top: 6px; font-weight: 700; }
        .foot .sign div { line-height: 1.4; }
        .foot .sign .role { font-size: 9.5pt; color: #555; }
        .note { margin-top: 26px; font-size: 8pt; letter-spacing: .5px; color: #888; text-align: center; }

        @page { size: A4; margin: 0; }
        @media print {
            body { background: #fff; }
            .toolbar { display: none !important; }
            .sheet { width: auto; min-height: 0; margin: 0; padding: 18mm 22mm 12mm; box-shadow: none; border-radius: 0; }
        }
        @media (max-width: 800px) { .sheet { width: auto; margin: 10px; padding: 18px; min-height: 0; } .toolbar { margin: 10px; } }
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
        <div class="toolbar">
            <button type="button" onclick="window.print()">Print</button>
            <button type="button" class="alt" onclick="window.close()">Close</button>
        </div>

        <div class="sheet">
            <div class="letterhead">
                <div class="org">SENATE OF PAKISTAN</div>
                <div class="branch">
                    <asp:Label ID="BranchLbl" runat="server"></asp:Label></div>
            </div>

            <div class="refline">
                <div>
                    <span class="lbl">Pass ID</span>
                    <span class="val">
                        <asp:Label ID="PassCodeLbl" runat="server"></asp:Label></span>
                </div>
                <div class="r">
                    <span class="val">
                        <asp:Label ID="DateLbl" runat="server"></asp:Label></span>
                </div>
            </div>

            <div class="subject"><span class="k">Subject</span><asp:Label ID="Label2" Text="VISITORS ENTRY PASS" runat="server"></asp:Label></div>

            <p class="lead">
                Kindly allow entry to the following visitor(s)<asp:Label ID="CompanyLbl" runat="server"></asp:Label>
                from <b>
                    <asp:Label ID="FromDate" runat="server"></asp:Label></b> to <b>
                        <asp:Label ID="ToDate" runat="server"></asp:Label></b>
                (<asp:Label ID="DaysLbl" runat="server"></asp:Label>).
            </p>

            <table class="terms">
                <tr>
                    <td class="k">Purpose of visit</td>
                    <td class="v">
                        <asp:Label ID="PassDetailsLbl" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="k">Visit type</td>
                    <td class="v">
                        <asp:Label ID="PassTypeLbl" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="k">Off days</td>
                    <td class="v">
                        <asp:Label ID="OffDaysLbl" runat="server"></asp:Label></td>
                </tr>
            </table>

            <table class="visitors">
                <thead>
                    <tr>
                        <th style="width: 8%">Sr#</th>
                        <th>Name of Visitor</th>
                        <th style="width: 24%">CNIC</th>
                        <th style="width: 28%">Details (Vehicle etc)</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="LV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                <td class="n">
                                    <asp:Label ID="VisitorName" runat="server" Text='<%#Eval("VisitorName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Cnic")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Details")%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="empty">No visitors are listed on this pass.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>

            <p class="closing">Submitted for necessary action, please.</p>

            <div class="foot">
                <div class="code">
                    <asp:Image ID="ImageGeneratedBarcode" runat="server" Visible="false" />
                </div>
                <div class="sign">
                    <div class="line"></div>
                    <div class="name">
                        <asp:Label ID="RequestedBy" runat="server"></asp:Label></div>
                    <div class="role">
                        <asp:Label ID="DesignationLbl" runat="server"></asp:Label></div>
                </div>
            </div>

            <div class="note">Computer generated pass.</div>
        </div>
    </form>
</body>
</html>
