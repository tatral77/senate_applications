using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace QuestionBIZ
{
    // Where the OCR tools are. Filled from web.config by the page.
    public class OcrSettings
    {
        public string TesseractPath { get; set; }     // full path to tesseract.exe, or empty to find it on PATH / Program Files
        public string TessdataPath { get; set; }      // optional folder that holds eng.traineddata, urd.traineddata ...
        public string GhostscriptPath { get; set; }   // optional gswin64c.exe - only needed to read PDF files
        public int MaxPdfPages { get; set; }
        public int TimeoutSeconds { get; set; }
    }

    public class OcrResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }   // problem, or a note for the user
        public string Html { get; set; }      // text as paragraphs, ready for the rich-text editor
        public string Text { get; set; }
        public int Pages { get; set; }
    }

    // Reads text from a scanned image or PDF by running Tesseract (and Ghostscript for PDFs) as separate programs.
    // Nothing is sent outside the server. Works best on clear printed text; handwriting is usually read poorly.
    public class OcrBiz
    {
        private static readonly string[] ImageTypes = { ".jpg", ".jpeg", ".png", ".tif", ".tiff", ".bmp", ".gif" };

        public OcrResult Read(OcrSettings settings, byte[] file, string extension, string language, int rotationDegrees)
        {
            if (settings == null) settings = new OcrSettings();
            extension = (extension ?? "").ToLowerInvariant();
            if (!Regex.IsMatch(language ?? "", "^[a-z]{3}(\\+[a-z]{3})*$"))
                return Fail("Unknown language.");

            string tesseract = FindTool(settings.TesseractPath, new[]
            {
                @"C:\Program Files\Tesseract-OCR\tesseract.exe",
                @"C:\Program Files (x86)\Tesseract-OCR\tesseract.exe"
            }, "tesseract.exe");
            if (tesseract == null)
                return Fail("Text reading is not set up on the server (Tesseract OCR is not installed). Please type the text.");

            string work = Path.Combine(Path.GetTempPath(), "qms-ocr", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(work);
            try
            {
                List<string> pages = new List<string>();
                if (extension == ".pdf")
                {
                    // Ghostscript draws each page (best result). Without it, scanned PDFs are still readable: the page
                    // pictures embedded in the PDF are pulled out directly. Nothing is sent outside the server.
                    string gs = FindTool(settings.GhostscriptPath, new string[0], "gswin64c.exe", "gswin32c.exe", "gs.exe");
                    int max = settings.MaxPdfPages > 0 ? settings.MaxPdfPages : 10;
                    if (gs != null)
                    {
                        string pdf = Path.Combine(work, "in.pdf");
                        File.WriteAllBytes(pdf, file);
                        string args = "-dNOPAUSE -dBATCH -dSAFER -sDEVICE=png16m -r300 -dFirstPage=1 -dLastPage=" + max +
                                      " -sOutputFile=\"" + Path.Combine(work, "page-%02d.png") + "\" \"" + pdf + "\"";
                        RunQuiet(gs, args, work, settings.TimeoutSeconds);
                        pages.AddRange(Directory.GetFiles(work, "page-*.png").OrderBy(p => p));
                    }
                    if (pages.Count == 0)
                    {
                        pages.AddRange(PdfImages.Extract(file, work, max));
                        if (pages.Count == 0)
                            return Fail(gs == null
                                ? "This PDF has no scanned page pictures that can be read here (it may be a text PDF or use an unsupported scan format). Please type the text, or attach the page as an image."
                                : "The PDF could not be turned into pictures to read.");
                    }
                }
                else if (ImageTypes.Contains(extension))
                {
                    string img = Path.Combine(work, "in" + extension);
                    File.WriteAllBytes(img, file);
                    if (rotationDegrees % 360 != 0) img = Rotate(img, rotationDegrees, work);
                    pages.Add(img);
                }
                else
                    return Fail("This file type cannot be read (" + extension + "). Please type the text.");

                StringBuilder all = new StringBuilder();
                foreach (string page in pages)
                {
                    // Urdu notices are usually one column of running text - "assume a single uniform block" (psm 6)
                    // reads this more reliably than "fully automatic" (psm 3): psm 3 was seen (tested against a
                    // known-correct Urdu paragraph) to insert a spurious blank line inside a paragraph, which then
                    // gets split into two separate paragraphs below. (Tried adding preserve_interword_spaces=1 too,
                    // but that dropped spaces between words at line wraps - worse - so it is not used.)
                    string psm = language == "urd" ? "6" : "3";
                    string args = "\"" + page + "\" stdout -l " + language + " --psm " + psm;
                    if (!string.IsNullOrWhiteSpace(settings.TessdataPath)) args += " --tessdata-dir \"" + settings.TessdataPath + "\"";
                    string err;
                    string text = Run(tesseract, args, work, out err, settings.TimeoutSeconds);
                    if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(err))
                    {
                        if (err.IndexOf("Failed loading language", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            err.IndexOf("Error opening data file", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            err.IndexOf("Could not initialize tesseract", StringComparison.OrdinalIgnoreCase) >= 0)
                            return Fail("The '" + language + "' language pack is not installed for Tesseract on the server.");
                        return Fail("The text reader reported a problem: " + Shorten(err));
                    }
                    all.AppendLine(text).AppendLine();
                }

                string clean = Clean(all.ToString());
                if (clean.Length == 0)
                    return new OcrResult { Success = false, Pages = pages.Count, Message = "No text could be read from the file. It may be handwritten or too faint - please type the text." };
                return new OcrResult { Success = true, Pages = pages.Count, Text = clean, Html = ToHtml(clean, language == "urd") };
            }
            catch (Exception ex)
            {
                return Fail("Could not read the file: " + Shorten(ex.Message));
            }
            finally
            {
                try { Directory.Delete(work, true); } catch { }
            }
        }

        // ---- helpers ---------------------------------------------------------------------------

        private static OcrResult Fail(string message) { return new OcrResult { Success = false, Message = message }; }
        private static string Shorten(string s) { s = (s ?? "").Trim(); return s.Length > 300 ? s.Substring(0, 300) + "..." : s; }

        private static string FindTool(string configured, string[] commonPaths, params string[] exeNames)
        {
            if (!string.IsNullOrWhiteSpace(configured) && File.Exists(configured)) return configured;
            foreach (string p in commonPaths) if (File.Exists(p)) return p;
            string path = Environment.GetEnvironmentVariable("PATH") ?? "";
            foreach (string dir in path.Split(new[] { Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries))
                foreach (string exe in exeNames)
                {
                    try { string candidate = Path.Combine(dir.Trim(), exe); if (File.Exists(candidate)) return candidate; } catch { }
                }
            return null;
        }

        private static string Rotate(string imagePath, int degrees, string work)
        {
            RotateFlipType flip;
            switch (((degrees % 360) + 360) % 360)
            {
                case 90: flip = RotateFlipType.Rotate90FlipNone; break;
                case 180: flip = RotateFlipType.Rotate180FlipNone; break;
                case 270: flip = RotateFlipType.Rotate270FlipNone; break;
                default: return imagePath;
            }
            string output = Path.Combine(work, "rotated.png");
            using (Image image = Image.FromFile(imagePath))
            {
                image.RotateFlip(flip);
                image.Save(output, ImageFormat.Png);
            }
            return output;
        }

        private static string Run(string exe, string args, string workDir, out string errorText, int timeoutSeconds)
        {
            ProcessStartInfo psi = new ProcessStartInfo(exe, args)
            {
                WorkingDirectory = workDir,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
            // Tesseract looks for its language files next to itself unless told otherwise
            string dir = Path.GetDirectoryName(exe);
            if (!string.IsNullOrEmpty(dir)) psi.EnvironmentVariables["PATH"] = dir + Path.PathSeparator + Environment.GetEnvironmentVariable("PATH");

            StringBuilder output = new StringBuilder(), error = new StringBuilder();
            using (Process p = new Process { StartInfo = psi })
            {
                p.OutputDataReceived += (s, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                p.ErrorDataReceived += (s, e) => { if (e.Data != null) error.AppendLine(e.Data); };
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                if (!p.WaitForExit((timeoutSeconds > 0 ? timeoutSeconds : 90) * 1000))
                {
                    try { p.Kill(); } catch { }
                    throw new TimeoutException("Reading took too long and was stopped.");
                }
                p.WaitForExit();   // flush the async output
            }
            errorText = error.ToString();
            return output.ToString();
        }

        private static string RunQuiet(string exe, string args, string workDir, int timeoutSeconds)
        {
            string ignored;
            return Run(exe, args, workDir, out ignored, timeoutSeconds);
        }

        // Tidies raw OCR output: drops the Notice Office stamp, joins wrapped lines into paragraphs.
        private static string Clean(string raw)
        {
            List<string> paragraphs = new List<string>();
            StringBuilder current = new StringBuilder();
            foreach (string lineRaw in raw.Replace("\r", "").Split('\n'))
            {
                string line = lineRaw.Trim();
                if (Regex.IsMatch(line, @"notice\s*diary\s*(no|date|time)", RegexOptions.IgnoreCase)) continue;   // stamp added by the Notice Office
                if (line.Length == 0)
                {
                    if (current.Length > 0) { paragraphs.Add(current.ToString()); current.Clear(); }
                    continue;
                }
                if (current.Length > 0)
                {
                    if (current.ToString().EndsWith("-") && char.IsLetter(line[0])) current.Length--;   // word split across lines
                    else current.Append(' ');
                }
                current.Append(line);
            }
            if (current.Length > 0) paragraphs.Add(current.ToString());
            return string.Join("\n\n", paragraphs.Select(p => Regex.Replace(p, @"[ \t]{2,}", " ")));
        }

        // Marks each paragraph right-to-left for Urdu. Without this, a browser guesses direction from the first
        // strong character in the paragraph - if that happens to be a digit or Latin letter (a question number, a
        // date, a stray English word), it guesses left-to-right and visually reorders the Urdu text around it.
        private static string ToHtml(string text, bool rightToLeft = false)
        {
            string dir = rightToLeft ? " dir=\"rtl\"" : "";
            return string.Join("", text.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(p => "<p" + dir + ">" + WebUtility.HtmlEncode(p) + "</p>"));
        }
    }

    // Pulls the page pictures out of a scanned PDF without any external program.
    // Supports JPEG (DCTDecode) pictures - what almost every scanner produces - and Flate-compressed 1/8-bit gray or
    // 24-bit colour pictures. Other formats (CCITT, JBIG2, JPEG2000) are skipped.
    internal static class PdfImages
    {
        public static List<string> Extract(byte[] pdf, string workDir, int maxPages)
        {
            List<string> result = new List<string>();
            Encoding latin = Encoding.GetEncoding(28591);
            string text = latin.GetString(pdf);

            HashSet<string> softMasks = new HashSet<string>();
            foreach (Match m in Regex.Matches(text, @"/(?:SMask|Mask)\s+(\d+)\s+\d+\s+R")) softMasks.Add(m.Groups[1].Value);

            int pos = 0;
            while (result.Count < maxPages)
            {
                int st = text.IndexOf("stream", pos, StringComparison.Ordinal);
                if (st < 0) break;
                pos = st + 6;
                if (st >= 3 && text.Substring(st - 3, 3) == "end") continue;            // "endstream"
                int objAt = text.LastIndexOf(" obj", st, StringComparison.Ordinal);
                if (objAt < 0 || st - objAt > 4000) continue;
                string dict = text.Substring(objAt, st - objAt);
                if (!Regex.IsMatch(dict, @"/Subtype\s*/Image")) continue;
                if (Regex.IsMatch(dict, @"/ImageMask\s+true")) continue;
                int from = Math.Max(0, objAt - 20);
                Match num = Regex.Match(text.Substring(from, objAt - from), @"(\d+)\s+\d+$");
                if (num.Success && softMasks.Contains(num.Groups[1].Value)) continue;

                int w = IntOf(dict, "Width"), h = IntOf(dict, "Height");
                if (w < 100 || h < 100) continue;                                         // logos, lines, masks

                int start = st + 6;
                if (start < pdf.Length && pdf[start] == '\r') start++;
                if (start < pdf.Length && pdf[start] == '\n') start++;
                int end = text.IndexOf("endstream", start, StringComparison.Ordinal);
                if (end < 0) break;
                while (end > start && (pdf[end - 1] == '\n' || pdf[end - 1] == '\r')) end--;
                byte[] data = new byte[end - start];
                Buffer.BlockCopy(pdf, start, data, 0, data.Length);
                pos = end;

                try
                {
                    string path = Path.Combine(workDir, "pdfimg-" + (result.Count + 1).ToString("00") + ".png");
                    string filterText = Regex.Match(dict, @"/Filter\s*(\[[^\]]*\]|/\w+)").Value;
                    List<string> filters = Regex.Matches(filterText, @"/(\w+)").Cast<Match>()
                                                .Select(x => x.Groups[1].Value).Where(x => x != "Filter").ToList();
                    bool jpeg = false, ok = true;
                    foreach (string f in filters)
                    {
                        if (f == "FlateDecode" || f == "Fl") data = Inflate(data);
                        else if (f == "DCTDecode" || f == "DCT") jpeg = true;
                        else { ok = false; break; }                                       // CCITT / JBIG2 / JPX / LZW ...
                    }
                    if (!ok) continue;
                    if (jpeg)
                    {
                        path = Path.ChangeExtension(path, ".jpg");
                        File.WriteAllBytes(path, data);
                    }
                    else
                    {
                        int bpc = IntOf(dict, "BitsPerComponent"); if (bpc == 0) bpc = 8;
                        int predictor = IntOf(dict, "Predictor");
                        if (predictor >= 10) data = Unpredict(data, w, bpc, dict);
                        if (!SaveRaw(data, w, h, bpc, Regex.IsMatch(dict, @"/Decode\s*\[\s*1\s+0\s*\]"), path)) continue;
                    }
                    result.Add(path);
                }
                catch { /* skip a picture we cannot decode */ }
            }
            return result;
        }

        private static int IntOf(string dict, string key)
        {
            Match m = Regex.Match(dict, "/" + key + @"\s+(\d+)");
            return m.Success ? int.Parse(m.Groups[1].Value) : 0;
        }

        private static byte[] Inflate(byte[] zlib)
        {
            using (MemoryStream input = new MemoryStream(zlib, 2, Math.Max(0, zlib.Length - 2)))
            using (DeflateStream deflate = new DeflateStream(input, CompressionMode.Decompress))
            using (MemoryStream output = new MemoryStream())
            {
                try { deflate.CopyTo(output); } catch (InvalidDataException) { }          // keep what was decoded
                return output.ToArray();
            }
        }

        // PNG-style row predictors (10-15) used with Flate pictures.
        private static byte[] Unpredict(byte[] d, int width, int bpc, string dict)
        {
            int colors = Math.Max(1, IntOf(dict, "Colors"));
            int cols = IntOf(dict, "Columns"); if (cols == 0) cols = width;
            int bpp = Math.Max(1, colors * bpc / 8);
            int rowLen = (cols * colors * bpc + 7) / 8;
            int rows = d.Length / (rowLen + 1);
            byte[] o = new byte[rows * rowLen];
            for (int r = 0; r < rows; r++)
            {
                int type = d[r * (rowLen + 1)];
                int si = r * (rowLen + 1) + 1, di = r * rowLen;
                for (int i = 0; i < rowLen; i++)
                {
                    int x = d[si + i];
                    int a = i >= bpp ? o[di + i - bpp] : 0;
                    int b = r > 0 ? o[di - rowLen + i] : 0;
                    int c = (r > 0 && i >= bpp) ? o[di - rowLen + i - bpp] : 0;
                    switch (type)
                    {
                        case 1: x += a; break;
                        case 2: x += b; break;
                        case 3: x += (a + b) / 2; break;
                        case 4:
                            int pa = Math.Abs(b - c), pb = Math.Abs(a - c), pc = Math.Abs(a + b - 2 * c);
                            x += (pa <= pb && pa <= pc) ? a : (pb <= pc ? b : c); break;
                    }
                    o[di + i] = (byte)x;
                }
            }
            return o;
        }

        // Turns raw pixel data into a PNG: 1-bit gray, 8-bit gray or 24-bit RGB (worked out from the data size).
        private static bool SaveRaw(byte[] d, int w, int h, int bpc, bool invert, string path)
        {
            PixelFormat format; int bytesPerRow;
            if (bpc == 1) { format = PixelFormat.Format1bppIndexed; bytesPerRow = (w + 7) / 8; }
            else if (bpc == 8 && d.Length >= w * h * 3) { format = PixelFormat.Format24bppRgb; bytesPerRow = w * 3; }
            else if (bpc == 8 && d.Length >= w * h) { format = PixelFormat.Format8bppIndexed; bytesPerRow = w; }
            else return false;
            if (d.Length < bytesPerRow * h) { h = d.Length / bytesPerRow; if (h < 100) return false; }

            using (Bitmap bmp = new Bitmap(w, h, format))
            {
                if (format == PixelFormat.Format8bppIndexed)
                {
                    ColorPalette pal = bmp.Palette;
                    for (int i = 0; i < 256; i++) pal.Entries[i] = Color.FromArgb(i, i, i);
                    bmp.Palette = pal;
                }
                BitmapData bd = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, format);
                try
                {
                    byte[] row = new byte[bytesPerRow];
                    int stride = bd.Stride;
                    for (int y = 0; y < h; y++)
                    {
                        Buffer.BlockCopy(d, y * bytesPerRow, row, 0, bytesPerRow);
                        if (format == PixelFormat.Format24bppRgb)                          // PDF stores RGB, GDI+ wants BGR
                            for (int x = 0; x < w; x++) { byte t = row[x * 3]; row[x * 3] = row[x * 3 + 2]; row[x * 3 + 2] = t; }
                        if (invert) for (int x = 0; x < bytesPerRow; x++) row[x] = (byte)~row[x];
                        System.Runtime.InteropServices.Marshal.Copy(row, 0, new IntPtr(bd.Scan0.ToInt64() + (long)y * stride), bytesPerRow);
                    }
                }
                finally { bmp.UnlockBits(bd); }
                bmp.Save(path, ImageFormat.Png);
            }
            return true;
        }
    }
}
