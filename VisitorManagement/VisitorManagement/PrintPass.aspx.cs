using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BIZ;
using IronBarCode;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace VisitorManagement
{
    public partial class PrintPass : System.Web.UI.Page
    {
        private object imgBarcode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = Convert.ToString(Request.QueryString["Id"]);
                VisitorPasses visitorPasses = new Biz().GetVisitorPass(id);
                if (visitorPasses != null)
                {
                    string OffDays = "Not Allowed";
                    double numberOfDays = 1;
                    //ImageGeneratedBarcode.ImageUrl = GenerateBarcode(visitorPasses.PassId,100,400);
                    //ImageGeneratedBarcode.Visible = true;
                    GenerateBarcode(visitorPasses.PassCode.ToString());
                    // BarCode.Text = "*" + visitorPasses.PassCode.ToString() + "*";
                    RequestedBy.Text = visitorPasses.RequestedBy;// + " - " + visitorPasses.Post + " (" + visitorPasses.Bps + ")";
                    DesignationLbl.Text = visitorPasses.Post;
                    BranchLbl.Text = visitorPasses.Branch.BranchName.ToUpper();
                    DateLbl.Text = "Date : " + visitorPasses.PassDate.ToShortDateString();

                    string passdetails = visitorPasses.VisitPurpose;
                    PassDetailsLbl.Text = passdetails;
                    if (visitorPasses.Saturday == 1 || visitorPasses.Saturday == 1)
                    {
                        OffDays = "Allowed to visit on ";
                        OffDays += (visitorPasses.Saturday == 1) ? "SATURDAY," : "";
                        OffDays += (visitorPasses.Sunday == 1) ? " SUNDAY" : "";
                    }
                    OffDaysLbl.Text = OffDays;
                    //  PassType.Text = visitorPasses.PassTypes.Description;
                    FromDate.Text = "&nbsp&nbsp&nbsp" + visitorPasses.FromDate.ToShortDateString();
                    ToDate.Text = "&nbsp&nbsp&nbsp" + visitorPasses.ToDate.ToShortDateString();
                    if (visitorPasses.ToDate != visitorPasses.FromDate)
                    {
                        numberOfDays = (visitorPasses.ToDate - visitorPasses.FromDate).TotalDays;
                    }
                    //for (DateTime i=visitorPasses.FromDate;i<= visitorPasses.ToDate; i.AddDays(1) )
                    //{
                    //    if (i.DayOfWeek.Equals("Sunday"))
                    //        if (visitorPasses.Sunday == 0)
                    //            numberOfDays--;
                    //    if (i.DayOfWeek.Equals("Saturday"))
                    //        if (visitorPasses.Saturday == 0)
                    //        numberOfDays--;
                    //}

                    if (numberOfDays == 1)
                        DaysLbl.Text = numberOfDays.ToString() + "&nbsp&nbspDay";
                    else
                        DaysLbl.Text = numberOfDays.ToString() + "&nbsp&nbspDays";
                    PassTypeLbl.Text = visitorPasses.PassTypes.Description;
                    if (visitorPasses.Company != null)
                        CompanyLbl.Text = visitorPasses.Company.CompanyName;
                    // Purpose.Text = visitorPasses.VisitPurpose;
                    LV.DataSource = visitorPasses.Visitors;
                    LV.DataBind();
                }


            }
        }
        //protected string GenerateBarcode(string CNIC,int height=50,int width=400)
        //{
        //    string generatebarcode = CNIC;
        //    GeneratedBarcode barcode = BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.Code128);
        //   // barcode.ResizeTo(400, 120);

        //    // Styling a QR code and adding annotation text
        //    //barcode.AddBarcodeValueTextAboveBarcode();
        //    barcode.AddBarcodeValueTextBelowBarcode();
        //    barcode.SetMargins(10);
        //    barcode.ChangeBarCodeColor(Color.Black);
        //    barcode.ResizeTo(width, height);

        //    var folder = Server.MapPath("/GeneratedBarcodeImage");
        //    if (!Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);
        //    }
        //    string filePath = Server.MapPath("/GeneratedBarcodeImage/" + CNIC + ".png");
        //    barcode.SaveAsPng(filePath);
        //    return "/GeneratedBarcodeImage/" + CNIC + ".png";
         
        //}

        protected void GenerateBarcode(string CNIC)
        {
            string barCode = "*" + CNIC + "*";
            using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAutomationHC39M Free Version",16);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString(barCode, oFont, blackBrush, point);
                }
                string filePath = Server.MapPath("/GeneratedBarcodeImage/" + CNIC + ".png");
                bitMap.Save(filePath);
                //  ImageGeneratedBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                //    return "/GeneratedBarcodeImage/" + CNIC + ".png";

                //using (MemoryStream ms = new MemoryStream())
                //{
                // bitMap.Save(ms, ImageFormat.Png);
                // ImageGeneratedBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                ImageGeneratedBarcode.ImageUrl = "./GeneratedBarcodeImage/" + CNIC + ".png";
                ImageGeneratedBarcode.Visible = true;
                // }
            }
        }

    }
}