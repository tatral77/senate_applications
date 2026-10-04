using System;
using System.Web;
using System.Web.Script.Serialization;

namespace QuestionManagement
{
    // Receives report content collected by Scripts/qmsexport.js and returns it as a PDF download.
    public class PdfExport : IHttpHandler
    {
        private const int MaxBlocks = 5000;
        private const int MaxRows = 30000;

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Cookies["userInfo"] == null)
            {
                context.Response.StatusCode = 403;
                context.Response.Write("Please sign in again.");
                return;
            }

            string json = context.Request.Form["data"];
            if (string.IsNullOrEmpty(json))
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Nothing to export.");
                return;
            }

            PdfRequest req;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = int.MaxValue;
                serializer.RecursionLimit = 20;
                req = serializer.Deserialize<PdfRequest>(json);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("The report content could not be read.");
                return;
            }

            if (req == null || req.blocks == null || req.blocks.Count == 0 || req.blocks.Count > MaxBlocks)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("The report is empty or too large to export.");
                return;
            }
            int rows = 0;
            foreach (PdfBlock b in req.blocks)
            {
                if (b != null && b.rows != null)
                    rows += b.rows.Count;
            }
            if (rows > MaxRows)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("The report is too large to export.");
                return;
            }

            byte[] pdf = ReportPdf.Build(req);
            ReportPdf.Send(context.Response, pdf, req.fileName);
        }
    }
}
