using System;
using System.Collections.Generic;
using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace EstablishmentASP
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

    // Renders the content collected from a report page (headings, paragraphs and tables) as a PDF that matches the print layout.
    public static class ReportPdf2
    {
        private const int MaxColumns = 30;

        public static byte[] Build(PdfRequest req)
        {
            bool landscape = !string.Equals(req.orientation, "portrait", StringComparison.OrdinalIgnoreCase);
            double usable = landscape ? 269 : 182;
            Document doc = LeavePdf2.NewDocument(string.IsNullOrEmpty(req.title) ? "Report" : req.title, req.title, landscape);
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
            return LeavePdf2.Render(doc);
        }

        private static void AddHeading(Section sec, string text)
        {
            Paragraph p = sec.AddParagraph();
            AddLines(p, text);
            p.Format.Font.Size = 11;
            p.Format.Font.Bold = true;
            p.Format.Font.Color = LeavePdf2.Navy;
            p.Format.Shading.Color = LeavePdf2.Banner;
            p.Format.Borders.Left.Style = BorderStyle.Single;
            p.Format.Borders.Left.Width = Unit.FromPoint(3.5);
            p.Format.Borders.Left.Color = new Color(159, 191, 230);
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
                t.Borders.Color = LeavePdf2.Line;
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
                    r.Shading.Color = new Color(227, 236, 247);
                    r.Borders.Color = new Color(185, 201, 221);
                    r.Format.Font.Color = LeavePdf2.Navy;
                    r.Format.Font.Bold = true;
                }
                else if (b.grid)
                {
                    bodyIndex++;
                    if (bodyIndex % 2 == 0)
                        r.Shading.Color = LeavePdf2.Zebra;
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
    }
}
