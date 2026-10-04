using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using EstablishmentBIZ;
using EstablishmentENT;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MY
{
    public static class LeavePdf2
    {
        internal static readonly Color Navy = new Color(31, 58, 95);
        internal static readonly Color Banner = new Color(234, 240, 247);
        internal static readonly Color Label = new Color(243, 246, 250);
        internal static readonly Color Zebra = new Color(245, 248, 252);
        internal static readonly Color Total = new Color(227, 235, 246);
        internal static readonly Color Line = new Color(197, 207, 220);
        internal static readonly Color Grey = new Color(85, 85, 85);

        internal const string FontName = "Arial";

        public static byte[] EmployeeLeaves(string employeeLine, IList<EmployeeLeave> leaves)
        {
            Document doc = NewDocument("Leave Details", "LEAVE DETAILS - REVISED LEAVE RULES, 1980");
            Section sec = doc.LastSection;
            AddEmployeeBanner(sec, employeeLine);

            string[] headers = { "Sr#", "Leave Type", "Leave Sub Type", "Ex-Pakistan", "Is Extension", "Start Date", "Leave Applied", "End Date", "Joining Date", "LFP Debited", "Details" };
            double[] widths = { 10, 28, 36, 17, 17, 22, 22, 22, 22, 20, 53 };
            bool[] leftAligned = { false, true, true, false, false, false, false, false, false, false, true };
            Table table = NewGrid(sec, headers, widths);

            int n = 0;
            if (leaves != null)
            {
                foreach (EmployeeLeave l in leaves)
                {
                    n++;
                    int debit = LeaveRules2.DebitDays(l.LeaveTypeId, l.LeaveSubTypeId, LeaveRules2.CalendarDays(l.StartDate, l.EndDate));
                    string details = LeaveRules2.HasMedicalCertificate(l.Remarks)
                        ? (LeaveRules2.StripMedicalTag(l.Remarks) + " (Medical Certificate)").Trim()
                        : l.Remarks;
                    string[] cells = {
                        n.ToString(CultureInfo.InvariantCulture),
                        l.LeaveType,
                        l.LeaveSubType,
                        l.ExPakistan == 1 ? "Yes" : "No",
                        l.IsExtension == 1 ? "Yes" : "No",
                        Date(l.StartDate),
                        l.NumberOfDays + " Days",
                        Date(l.EndDate),
                        Date(l.ExpectedJoiningDate),
                        debit == 0 ? "-" : debit + " Days",
                        details
                    };
                    AddGridRow(table, cells, leftAligned, n % 2 == 0, 0, 9);
                }
            }
            if (n == 0)
            {
                Row r = table.AddRow();
                r.Cells[0].MergeRight = headers.Length - 1;
                r.Cells[0].AddParagraph("No Data Found");
            }

            return Render(doc);
        }

        public static byte[] LeaveAccount(string employeeLine, string dated, IList<KeyValuePair<string, string>> details,
            string sectionTitle, IList<LeaveYear2> years, IList<LeaveTypeSummary2> summary)
        {
            Document doc = NewDocument("Leave Account", "LEAVE ACCOUNT - REVISED LEAVE RULES, 1980");
            Section sec = doc.LastSection;

            Paragraph heading = sec.AddParagraph("SERVICE DETAILS");
            StyleHeading(heading);
            Paragraph date = sec.AddParagraph(dated);
            date.Format.Alignment = ParagraphAlignment.Center;
            date.Format.Font.Size = 9;
            date.Format.Font.Bold = true;
            date.Format.Font.Color = Grey;
            date.Format.SpaceAfter = Unit.FromPoint(2);

            AddEmployeeBanner(sec, employeeLine);

            AddDetailsGrid(sec, details);

            Paragraph section = sec.AddParagraph(sectionTitle);
            StyleHeading(section);
            section.Format.SpaceBefore = Unit.FromPoint(10);
            Paragraph rules = sec.AddParagraph("As per the Revised Leave Rules, 1980");
            rules.Format.Alignment = ParagraphAlignment.Center;
            rules.Format.Font.Size = 8;
            rules.Format.Font.Italic = true;
            rules.Format.Font.Color = Grey;
            rules.Format.SpaceAfter = Unit.FromPoint(4);

            string[] headers = { "Sr#", "Year", "LFP to be Earned", "Earned LFP", "Unearned LFP", "Availed LFP", "Leave Period", "EOL", "Credit in this year", "Encashment Availed", "Total Credit" };
            double[] widths = { 12, 19, 26, 24, 24, 24, 24, 16, 32, 37, 31 };
            bool[] leftAligned = new bool[headers.Length];
            Table table = NewGrid(sec, headers, widths);
            int n = 0;
            if (years != null)
            {
                foreach (LeaveYear2 y in years)
                {
                    n++;
                    string[] cells = {
                        n.ToString(CultureInfo.InvariantCulture),
                        y.Year.ToString(CultureInfo.InvariantCulture),
                        y.GrossEarned.ToString(CultureInfo.InvariantCulture),
                        y.NetEarned.ToString(CultureInfo.InvariantCulture),
                        y.NotEarned.ToString(CultureInfo.InvariantCulture),
                        y.Availed.ToString(CultureInfo.InvariantCulture),
                        y.LeavePeriod.ToString(CultureInfo.InvariantCulture),
                        y.EolDays.ToString(CultureInfo.InvariantCulture),
                        y.YearCredit.ToString(CultureInfo.InvariantCulture),
                        y.Encashed.ToString(CultureInfo.InvariantCulture),
                        y.Balance.ToString(CultureInfo.InvariantCulture)
                    };
                    AddGridRow(table, cells, leftAligned, n % 2 == 0, 1, 10);
                }
            }

            Paragraph note = sec.AddParagraph("Total Credit includes the leave credit brought forward from the previous department. Leave earned is 4 days for every calendar month with more than 15 days of duty (Rule 3); no leave is earned during leave, and a leave running from one month into the next credits one month only (Rule 3(2)). Casual leave is outside the leave account.");
            note.Format.Font.Size = 7.5;
            note.Format.Font.Italic = true;
            note.Format.Font.Color = Grey;
            note.Format.SpaceBefore = Unit.FromPoint(5);

            if (summary != null && summary.Count > 0)
            {
                Paragraph st = sec.AddParagraph("LEAVE AVAILED BY TYPE");
                StyleHeading(st);
                st.Format.SpaceBefore = Unit.FromPoint(12);
                st.Format.KeepWithNext = true;
                st.Format.SpaceAfter = Unit.FromPoint(4);

                string[] sHeaders = { "Leave Type", "No. of Entries", "Days of Leave", "Debited to LFP" };
                double[] sWidths = { 70, 40, 40, 40 };
                bool[] sLeft = { true, false, false, false };
                Table t2 = NewGrid(sec, sHeaders, sWidths);
                t2.Rows.Alignment = RowAlignment.Center;
                int k = 0;
                foreach (LeaveTypeSummary2 s in summary)
                {
                    k++;
                    string[] cells = {
                        s.Description,
                        s.Spells.ToString(CultureInfo.InvariantCulture),
                        s.Days.ToString(CultureInfo.InvariantCulture),
                        s.Debited.ToString(CultureInfo.InvariantCulture)
                    };
                    AddGridRow(t2, cells, sLeft, k % 2 == 0, -1, -1);
                }
            }

            return Render(doc);
        }

        public static void Send(HttpResponse response, byte[] pdf, string fileName)
        {
            StringBuilder safe = new StringBuilder();
            foreach (char ch in fileName ?? "Leave")
            {
                if ((char.IsLetterOrDigit(ch) && ch < 128) || ch == ' ' || ch == '-' || ch == '_' || ch == '.')
                    safe.Append(ch);
            }
            string name = safe.ToString().Trim();
            if (name.Length == 0)
                name = "Leave";

            response.Clear();
            response.ContentType = "application/pdf";
            response.AddHeader("Content-Disposition", "attachment; filename=\"" + name + ".pdf\"");
            response.AddHeader("Content-Length", pdf.Length.ToString(CultureInfo.InvariantCulture));
            response.BinaryWrite(pdf);
            response.Flush();
            response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #region Building blocks

        internal static Document NewDocument(string title, string titleBand)
        {
            return NewDocument(title, titleBand, true);
        }

        internal static Document NewDocument(string title, string titleBand, bool landscape)
        {
            Document doc = new Document();
            doc.Info.Title = title;
            doc.Info.Author = "Senate of Pakistan - PMS";

            Style normal = doc.Styles["Normal"];
            normal.Font.Name = FontName;
            normal.Font.Size = 9;
            normal.ParagraphFormat.SpaceAfter = 0;

            Section sec = doc.AddSection();
            sec.PageSetup.PageFormat = PageFormat.A4;
            sec.PageSetup.Orientation = landscape ? Orientation.Landscape : Orientation.Portrait;
            sec.PageSetup.LeftMargin = Unit.FromMillimeter(14);
            sec.PageSetup.RightMargin = Unit.FromMillimeter(14);
            sec.PageSetup.TopMargin = Unit.FromMillimeter(12);
            sec.PageSetup.BottomMargin = Unit.FromMillimeter(16);
            sec.PageSetup.FooterDistance = Unit.FromMillimeter(8);

            Paragraph org = sec.AddParagraph("SENATE OF PAKISTAN");
            org.Format.Alignment = ParagraphAlignment.Center;
            org.Format.Font.Size = 19;
            org.Format.Font.Bold = true;
            org.Format.Font.Color = Navy;

            Paragraph sub = sec.AddParagraph("PMS  |  PERSONAL MANAGEMENT SYSTEM");
            sub.Format.Alignment = ParagraphAlignment.Center;
            sub.Format.Font.Size = 9;
            sub.Format.Font.Color = Grey;
            sub.Format.SpaceAfter = Unit.FromPoint(6);

            if (!string.IsNullOrEmpty(titleBand))
            {
                Table band = sec.AddTable();
                band.Rows.Alignment = RowAlignment.Center;
                band.AddColumn(Unit.FromMillimeter(landscape ? 120 : 110));
                Row br = band.AddRow();
                br.Shading.Color = Navy;
                br.Height = Unit.FromPoint(18);
                br.VerticalAlignment = VerticalAlignment.Center;
                Paragraph bp = br.Cells[0].AddParagraph(titleBand);
                bp.Format.Alignment = ParagraphAlignment.Center;
                bp.Format.Font.Size = 11.5;
                bp.Format.Font.Bold = true;
                bp.Format.Font.Color = Colors.White;
            }

            Paragraph rule = sec.AddParagraph();
            rule.Format.SpaceBefore = Unit.FromPoint(6);
            rule.Format.SpaceAfter = Unit.FromPoint(6);
            rule.Format.Borders.Bottom.Style = BorderStyle.Single;
            rule.Format.Borders.Bottom.Width = Unit.FromPoint(2);
            rule.Format.Borders.Bottom.Color = Navy;
            rule.Format.Font.Size = 2;

            Paragraph footer = sec.Footers.Primary.AddParagraph();
            footer.Format.Alignment = ParagraphAlignment.Right;
            footer.Format.Font.Size = 7.5;
            footer.Format.Font.Color = Grey;
            footer.Format.Borders.Top.Style = BorderStyle.Single;
            footer.Format.Borders.Top.Width = Unit.FromPoint(0.5);
            footer.Format.Borders.Top.Color = Line;
            footer.AddText("Computer generated report  |  Printed on " + DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) + "  |  Page ");
            footer.AddPageField();
            footer.AddText(" of ");
            footer.AddNumPagesField();

            return doc;
        }

        private static void StyleHeading(Paragraph p)
        {
            p.Format.Alignment = ParagraphAlignment.Center;
            p.Format.Font.Size = 10.5;
            p.Format.Font.Bold = true;
            p.Format.Font.Color = Navy;
        }

        private static void AddEmployeeBanner(Section sec, string text)
        {
            Table t = sec.AddTable();
            t.AddColumn(Unit.FromMillimeter(269));
            Row r = t.AddRow();
            r.Shading.Color = Banner;
            r.Borders.Left.Style = BorderStyle.Single;
            r.Borders.Left.Width = Unit.FromPoint(4);
            r.Borders.Left.Color = Navy;
            r.Height = Unit.FromPoint(20);
            r.VerticalAlignment = VerticalAlignment.Center;
            Paragraph p = r.Cells[0].AddParagraph(text ?? "");
            p.Format.Font.Size = 12;
            p.Format.Font.Bold = true;
            p.Format.Font.Color = Navy;
            p.Format.LeftIndent = Unit.FromPoint(6);
            Paragraph gap = sec.AddParagraph();
            gap.Format.SpaceAfter = Unit.FromPoint(4);
            gap.Format.Font.Size = 2;
        }

        private static void AddDetailsGrid(Section sec, IList<KeyValuePair<string, string>> details)
        {
            if (details == null || details.Count == 0)
                return;
            Table t = sec.AddTable();
            t.Borders.Color = Line;
            t.Borders.Width = Unit.FromPoint(0.5);
            t.LeftPadding = Unit.FromPoint(6);
            t.TopPadding = Unit.FromPoint(2.5);
            t.BottomPadding = Unit.FromPoint(2.5);
            t.AddColumn(Unit.FromMillimeter(56));
            t.AddColumn(Unit.FromMillimeter(78.5));
            t.AddColumn(Unit.FromMillimeter(56));
            t.AddColumn(Unit.FromMillimeter(78.5));

            int rows = (details.Count + 1) / 2;
            for (int i = 0; i < rows; i++)
            {
                Row r = t.AddRow();
                for (int side = 0; side < 2; side++)
                {
                    int index = i + side * rows;
                    Cell labelCell = r.Cells[side * 2];
                    Cell valueCell = r.Cells[side * 2 + 1];
                    labelCell.Shading.Color = Label;
                    if (index < details.Count)
                    {
                        Paragraph lp = labelCell.AddParagraph(details[index].Key);
                        lp.Format.Font.Bold = true;
                        lp.Format.Font.Color = new Color(44, 62, 87);
                        valueCell.AddParagraph(details[index].Value ?? "");
                    }
                }
            }
        }

        internal static Table NewGrid(Section sec, string[] headers, double[] widths)
        {
            Table t = sec.AddTable();
            t.Borders.Color = Line;
            t.Borders.Width = Unit.FromPoint(0.5);
            t.LeftPadding = Unit.FromPoint(3);
            t.RightPadding = Unit.FromPoint(3);
            t.TopPadding = Unit.FromPoint(3);
            t.BottomPadding = Unit.FromPoint(3);
            foreach (double w in widths)
                t.AddColumn(Unit.FromMillimeter(w));

            Row h = t.AddRow();
            h.HeadingFormat = true;
            h.Shading.Color = Navy;
            h.Borders.Color = Navy;
            h.Format.Font.Color = Colors.White;
            h.Format.Font.Bold = true;
            h.Format.Font.Size = 8;
            h.Format.Alignment = ParagraphAlignment.Center;
            h.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < headers.Length; i++)
                h.Cells[i].AddParagraph(headers[i]);
            return t;
        }

        private static void AddGridRow(Table t, string[] cells, bool[] leftAligned, bool zebra, int boldColumn, int emphasisColumn)
        {
            Row r = t.AddRow();
            r.VerticalAlignment = VerticalAlignment.Center;
            r.Format.Font.Size = 8.5;
            if (zebra)
                r.Shading.Color = Zebra;
            for (int i = 0; i < cells.Length; i++)
            {
                Paragraph p = r.Cells[i].AddParagraph(cells[i] ?? "");
                p.Format.Alignment = leftAligned[i] ? ParagraphAlignment.Left : ParagraphAlignment.Center;
                if (i == boldColumn)
                {
                    p.Format.Font.Bold = true;
                    p.Format.Font.Color = Navy;
                }
                if (i == emphasisColumn)
                {
                    p.Format.Font.Bold = true;
                    r.Cells[i].Shading.Color = Total;
                }
            }
        }

        private static string Date(DateTime d)
        {
            return d.Year <= 1 ? "" : d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        internal static byte[] Render(Document doc)
        {
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            using (MemoryStream ms = new MemoryStream())
            {
                renderer.PdfDocument.Save(ms, false);
                return ms.ToArray();
            }
        }

        #endregion
    }
}
