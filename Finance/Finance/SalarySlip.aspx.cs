using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinEntities;
using FinBiz;
using BUDBIZ;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;

namespace Finance
{
    public partial class SalarySlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            int fy= Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            string month = new BudgetBiz().GetMonth(Mon).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(Mon, fy) + ")";
          
            SlipHeading.InnerText = "PAY SLIP (" + month ;
           // MemberBankAccounts ba = new FinBIZ().GetMemberSalaryAccount(MemberId);
            Member member = new FinBIZ().GetMemberById(MemberId);
            IdDiv.InnerText = new FinBIZ().GetIdByCategory(member.MemberSalCategoryId).FundCenter;
          MemberSalaryDetails sd = new FinBIZ().GetMemberSalaryDetail(MemberId, fy, Mon);
            SenatorNameDiv.InnerText = member.MemberName.ToUpper() + " (" + member.MemberSalCategory.ToUpper() + ")";
           // StatusDiv.InnerText = "STATUS: " +;
            if (!String.IsNullOrEmpty(sd.BankName))
                BankDiv.InnerText = "BANK: " + sd.BankName.ToUpper() + " (" + sd.BankAccount + ")";
            else if (!String.IsNullOrEmpty(sd.ChequeNumber))
                BankDiv.InnerText = "CHEQUE NO: " + sd.ChequeNumber.ToUpper();// + " (" + sd.ChequeDate + ")";
            Page.Title = member.MemberName + "(" + month + ")";
            List<MonthlyAllowance> monthlyallowances = new FinBIZ().GetMonthlyAllowances(MemberId, fy, Mon);
            double TotalAllowances = 0;
            double TotalDeductions = 0;
            if (monthlyallowances!=null)
            {
                foreach (MonthlyAllowance ma in monthlyallowances)
                {
                    TotalAllowances = TotalAllowances + ma.Amount;
                }
            }
            List<MonthlyDeduction> monthlydeductions=new FinBIZ().GetMonthlyDeductions(MemberId, fy, Mon);
            DeductionsLV.DataSource = monthlydeductions;
            DeductionsLV.DataBind();
            if (monthlydeductions!= null)
            {
                foreach (MonthlyDeduction ded in monthlydeductions)
                {
                    TotalDeductions = TotalDeductions + ded.Amount;
                }
            }
            double NetAmount = TotalAllowances - TotalDeductions;
            NetAmountLbl.Text = "Net Amount Payable: " + FormatAmount(NetAmount);
           // InWords.Text = new FinBIZ().NumberToWords(Convert.ToInt32(NetAmount),false);
            TotalAllowancesLbl.Text = FormatAmount(TotalAllowances).ToString();
            TotalDeductionsLbl.Text = FormatAmount(TotalDeductions).ToString();
            AllowancesLV.DataSource = monthlyallowances;
            AllowancesLV.DataBind();

        }

        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    protected void PrintBtn_Click(object sender, EventArgs e)
        {
            //var doc1 = new Document();
            //string path = Server.MapPath("PDF");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));
            //doc1.Open();
            //doc1.Add(new Paragraph(slippanel.));
            //doc1.Close();

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //this.Page.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();





            //Initialize HTML to PDF converter 
            // HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            // WebKitConverterSettings settings = new WebKitConverterSettings();
            // //Set temporary path to generate temporary files
            //// settings.TempPath=@"D:/HtmlConversion/Temp/";
            // //Set WebKit path
            // settings.WebKitPath = Server.MapPath("~/QtBinaries");
            // //Assign WebKit settings to HTML converter
            // htmlConverter.ConverterSettings = settings;
            // //Get the current URL
            // string url = HttpContext.Current.Request.Url.AbsoluteUri;
            // //Convert URL to PDF
            // PdfDocument document = htmlConverter.Convert(url);
            // //Save the document
            // document.Save("Output.pdf",HttpContext.Current.Response, HttpReadType.Save);
        }
        }
}