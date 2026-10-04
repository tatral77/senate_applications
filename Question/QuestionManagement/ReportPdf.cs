using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace QuestionManagement
{
    public class PdfCell
    {
        public string t { get; set; }
        public int cs { get; set; }
        public bool th { get; set; }
    }

    public class PdfBlock
    {
        public string t { get; set; }
        public string text { get; set; }
        public bool grid { get; set; }
        public List<List<PdfCell>> rows { get; set; }
    }

    public class PdfRequest
    {
        public string title { get; set; }
        public string orientation { get; set; }
        public string fileName { get; set; }
        public List<PdfBlock> blocks { get; set; }
    }

    // Renders the content collected by Scripts/qmsexport.js (headings, paragraphs and tables) as a PDF.
    public static class ReportPdf
    {
        private static readonly Color Navy = new Color(18, 79, 150);
        private static readonly Color Banner = new Color(232, 241, 251);
        private static readonly Color Zebra = new Color(245, 249, 253);
        private static readonly Color Line = new Color(197, 210, 224);
        private static readonly Color Grey = new Color(85, 85, 85);
        private const string FontName = "Arial";
        private const int MaxColumns = 30;

        public static byte[] Build(PdfRequest req)
        {
            bool landscape = !string.Equals(req.orientation, "portrait", StringComparison.OrdinalIgnoreCase);
            double usable = landscape ? 269 : 182;
            Document doc = NewDocument(string.IsNullOrEmpty(req.title) ? "Report" : req.title, req.title, landscape);
            Section sec = doc.LastSection;

            if (req.blocks != null)
            {
                foreach (PdfBlock b in req.blocks)
                {
                    if (b == null)
                        continue;
                    if (b.t == "h")
                        AddHeading(sec, b.text);
                    else if (b.t == "p")
                        AddParagraph(sec, b.text);
                    else if (b.t == "table" && b.rows != null && b.rows.Count > 0)
                        AddTable(sec, b, usable);
                }
            }
            return Render(doc);
        }

        public static void Send(HttpResponse response, byte[] pdf, string fileName)
        {
            StringBuilder safe = new StringBuilder();
            foreach (char ch in fileName ?? "Report")
            {
                if ((char.IsLetterOrDigit(ch) && ch < 128) || ch == ' ' || ch == '-' || ch == '_' || ch == '.')
                    safe.Append(ch);
            }
            string name = safe.ToString().Trim();
            if (name.Length == 0)
                name = "Report";

            response.Clear();
            response.ContentType = "application/pdf";
            response.AddHeader("Content-Disposition", "attachment; filename=\"" + name + ".pdf\"");
            response.AddHeader("Content-Length", pdf.Length.ToString(CultureInfo.InvariantCulture));
            response.BinaryWrite(pdf);
            response.Flush();
            response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #region Document

        private static Document NewDocument(string title, string titleBand, bool landscape)
        {
            Document doc = new Document();
            doc.Info.Title = title;
            doc.Info.Author = "Senate of Pakistan - Questions Branch";

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

            Paragraph sub = sec.AddParagraph("QUESTIONS MANAGEMENT SYSTEM  |  QUESTIONS BRANCH");
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

        private static byte[] Render(Document doc)
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

        #region Blocks

        private static void AddHeading(Section sec, string text)
        {
            Paragraph p = sec.AddParagraph();
            AddLines(p, text);
            p.Format.Font.Size = 11;
            p.Format.Font.Bold = true;
            p.Format.Font.Color = Navy;
            p.Format.Shading.Color = Banner;
            p.Format.Borders.Left.Style = BorderStyle.Single;
            p.Format.Borders.Left.Width = Unit.FromPoint(3.5);
            p.Format.Borders.Left.Color = Navy;
            p.Format.Borders.DistanceFromLeft = Unit.FromPoint(6);
            p.Format.Borders.DistanceFromTop = Unit.FromPoint(2);
            p.Format.Borders.DistanceFromBottom = Unit.FromPoint(2);
            p.Format.SpaceBefore = Unit.FromPoint(8);
            p.Format.SpaceAfter = Unit.FromPoint(6);
            p.Format.KeepWithNext = true;
        }

        private static void AddParagraph(Section sec, string text)
        {
            Paragraph p = sec.AddParagraph();
            AddLines(p, text);
            p.Format.Font.Size = 9;
            p.Format.SpaceAfter = Unit.FromPoint(3);
        }

        private static void AddLines(Paragraph p, string text)
        {
            string[] lines = (text ?? "").Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                    p.AddLineBreak();
                p.AddText(lines[i]);
            }
        }

        private static void AddTable(Section sec, PdfBlock b, double usable)
        {
            int cols = 0;
            foreach (List<PdfCell> row in b.rows)
            {
                int n = 0;
                foreach (PdfCell c in row)
                    n += Math.Max(1, c.cs);
                cols = Math.Max(cols, n);
            }
            cols = Math.Min(cols, MaxColumns);
            if (cols == 0)
                return;

            double[] weight = new double[cols];
            bool[] center = new bool[cols];
            for (int i = 0; i < cols; i++)
            {
                weight[i] = 3;
                center[i] = true;
            }
            foreach (List<PdfCell> row in b.rows)
            {
                int col = 0;
                foreach (PdfCell c in row)
                {
                    int span = Math.Max(1, c.cs);
                    if (col >= cols)
                        break;
                    if (span == 1)
                    {
                        int longest = LongestLine(c.t);
                        weight[col] = Math.Max(weight[col], Math.Min(longest, 30));
                        if (!c.th && longest > 14)
                            center[col] = false;
                    }
                    col += span;
                }
            }
            double total = 0;
            foreach (double w in weight)
                total += w;
            double minWidth = Math.Min(9, usable / cols);
            double[] width = new double[cols];
            double sum = 0;
            for (int i = 0; i < cols; i++)
            {
                width[i] = Math.Max(minWidth, weight[i] / total * usable);
                sum += width[i];
            }
            for (int i = 0; i < cols; i++)
                width[i] = width[i] / sum * usable;

            double fontSize = cols <= 6 ? 9 : cols <= 9 ? 8 : cols <= 12 ? 7 : 6.5;

            Table t = sec.AddTable();
            if (b.grid)
            {
                t.Borders.Color = Line;
                t.Borders.Width = Unit.FromPoint(0.5);
            }
            t.LeftPadding = Unit.FromPoint(3);
            t.RightPadding = Unit.FromPoint(3);
            t.TopPadding = Unit.FromPoint(b.grid ? 3 : 1.5);
            t.BottomPadding = Unit.FromPoint(b.grid ? 3 : 1.5);
            for (int i = 0; i < cols; i++)
                t.AddColumn(Unit.FromMillimeter(width[i]));

            bool headerZone = b.grid;
            int bodyIndex = 0;
            foreach (List<PdfCell> row in b.rows)
            {
                bool isHeader = false;
                if (headerZone)
                {
                    isHeader = RowIsHeader(row);
                    if (!isHeader)
                        headerZone = false;
                }

                Row r = t.AddRow();
                r.VerticalAlignment = VerticalAlignment.Center;
                r.Format.Font.Size = isHeader ? Math.Max(6.5, fontSize - 0.5) : fontSize;
                if (isHeader)
                {
                    r.HeadingFormat = true;
                    r.Shading.Color = Navy;
                    r.Borders.Color = Navy;
                    r.Format.Font.Color = Colors.White;
                    r.Format.Font.Bold = true;
                }
                else if (b.grid)
                {
                    bodyIndex++;
                    if (bodyIndex % 2 == 0)
                        r.Shading.Color = Zebra;
                }

                int col = 0;
                foreach (PdfCell c in row)
                {
                    int span = Math.Max(1, c.cs);
                    if (col >= cols)
                        break;
                    if (col + span > cols)
                        span = cols - col;
                    Cell cell = r.Cells[col];
                    if (span > 1)
                        cell.MergeRight = span - 1;
                    Paragraph p = cell.AddParagraph();
                    AddLines(p, c.t);
                    if (isHeader || c.th)
                        p.Format.Alignment = ParagraphAlignment.Center;
                    else
                        p.Format.Alignment = (b.grid && span == 1 && center[col]) ? ParagraphAlignment.Center : ParagraphAlignment.Left;
                    if (c.th && !isHeader)
                        p.Format.Font.Bold = true;
                    col += span;
                }
            }

            Paragraph gap = sec.AddParagraph();
            gap.Format.Font.Size = 2;
            gap.Format.SpaceAfter = Unit.FromPoint(6);
        }

        private static bool RowIsHeader(List<PdfCell> row)
        {
            bool any = false;
            foreach (PdfCell c in row)
            {
                if (!c.th)
                    return false;
                any = true;
            }
            return any;
        }

        private static int LongestLine(string text)
        {
            int longest = 0;
            foreach (string line in (text ?? "").Split('\n'))
                longest = Math.Max(longest, line.Length);
            return longest;
        }

        #endregion
    }
}
