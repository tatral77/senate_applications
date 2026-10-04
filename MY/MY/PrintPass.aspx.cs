using Entities;
using MyBIZ;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MY
{
    public partial class PrintPass : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Convert.ToString(Request.QueryString["Id"]);
                VisitorPasses visitorPasses = new vmsBiz().GetVisitorPass(id);
                if (visitorPasses != null)
                {
                    GenerateBarcode(visitorPasses.PassCode.ToString());
                    PassCodeLbl.Text = Server.HtmlEncode(visitorPasses.PassCode);
                    RequestedBy.Text = Server.HtmlEncode(visitorPasses.RequestedBy);
                    DesignationLbl.Text = Server.HtmlEncode(visitorPasses.Post);
                    BranchLbl.Text = visitorPasses.Branch != null ? Server.HtmlEncode(visitorPasses.Branch.BranchName.ToUpper()) : "";
                    DateLbl.Text = "Date: " + visitorPasses.PassDate.ToString("dd/MM/yyyy");
                    PassDetailsLbl.Text = Server.HtmlEncode(visitorPasses.VisitPurpose);

                    string offDays = "Not allowed";
                    if (visitorPasses.Saturday == 1 || visitorPasses.Sunday == 1)
                    {
                        List<string> days = new List<string>();
                        if (visitorPasses.Saturday == 1) days.Add("Saturday");
                        if (visitorPasses.Sunday == 1) days.Add("Sunday");
                        offDays = "Allowed on " + string.Join(" and ", days);
                    }
                    OffDaysLbl.Text = offDays;

                    FromDate.Text = visitorPasses.FromDate.ToString("dd/MM/yyyy");
                    ToDate.Text = visitorPasses.ToDate.ToString("dd/MM/yyyy");

                    // days of validity: every calendar day of the visit, less weekend days that are not allowed
                    int numberOfDays = 0;
                    for (DateTime i = visitorPasses.FromDate.Date; i <= visitorPasses.ToDate.Date; i = i.AddDays(1))
                    {
                        if (i.DayOfWeek == DayOfWeek.Sunday && visitorPasses.Sunday == 0)
                            continue;
                        if (i.DayOfWeek == DayOfWeek.Saturday && visitorPasses.Saturday == 0)
                            continue;
                        numberOfDays++;
                    }
                    DaysLbl.Text = numberOfDays + (numberOfDays == 1 ? " Day" : " Days");
                    PassTypeLbl.Text = visitorPasses.PassTypes != null ? Server.HtmlEncode(visitorPasses.PassTypes.Description) : "";
                    if (visitorPasses.Company != null)
                        CompanyLbl.Text = " of " + Server.HtmlEncode(visitorPasses.Company.CompanyName);
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
                    Font oFont = new Font("IDAutomationHC39M Free Version", 16);
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