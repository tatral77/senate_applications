using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Notice.Utilities
{
    public static class Utils
    {
        public static void AddTextToPdf(string inputPdfPath, string outputPdfPath, string textToAdd)
        {
            //variables
            string pathin = inputPdfPath;
            string pathout = outputPdfPath;
            //create PdfReader object to read from the existing document
            using (PdfReader reader = new PdfReader(pathin))
            //create PdfStamper object to write to get the pages from reader 
            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create)))
            {
                ////select two pages from the original document
                //reader.SelectPages("1-2");

                ////gettins the page size in order to substract from the iTextSharp coordinates




                //add content to the page using ColumnText
                iTextSharp.text.Font font = new iTextSharp.text.Font();
                //iTextSharp.text.BaseColor color= new iTextSharp.text.BaseColor;
                font.Size = 10;
                font.Color = BaseColor.GREEN;

                for (int pageIndex = 1; pageIndex <= reader.NumberOfPages; pageIndex++)
                {
                    // PdfContentByte from stamper to add content to the pages over the original content
                    PdfContentByte pbover = stamper.GetOverContent(pageIndex);
                    var pageSize = reader.GetPageSize(pageIndex);
                    //setting up the X and Y coordinates of the document
                    // iTextSharp.text.Rectangle pagesize = reader.GetCropBox(pageIndex);
                    float x = pageSize.GetRight(100);// point.X;
                    float y = pageSize.GetBottom(10);// point.Y;

                    // y = (int)(pageSize.Height - y);

                    ColumnText.ShowTextAligned(pbover, Element.ALIGN_RIGHT, new Phrase(textToAdd, font), x, y, 0);

                }

            }
        }
    }
}