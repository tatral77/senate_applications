using IPRBIZ;
using BUDBIZ;
using IPRENTITIES;
using IPRENITITIES;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace IPR
{
    public partial class PrintOutgoingVisitSanction : System.Web.UI.Page
    {
        int CountMember = 0;
        string location = "";
        string category = "";
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateSanction();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01-01-0001") ? string.Empty : date.ToShortDateString();
        }
        protected void CreateSanction()
        {
            int SanctionId = Convert.ToInt32(Request.QueryString["SanctionId"]);
            double TotalDA = 0;
            decimal TotalPKR = 0;
            //Get Sanction Information
            OutgoingVisitSanction outgoingVisitSanction = new IPRBiz().GetOutgoingVisitSanction(SanctionId);
            if (outgoingVisitSanction != null)
            {
                var OutgoingVisit = new IPRBiz().GetOutgoingVisit(outgoingVisitSanction.VisitId);
                var DemandNo = new BudgetBiz().GetFinancialYear(OutgoingVisit.FinancialYearId);

                DateLbl.Text = "Islamabad, the " + outgoingVisitSanction.SanctionDate.ToString("dd MMMM, yyyy");
                MoverLbl.Text = outgoingVisitSanction.MovedBy.Trim();
                MoverLabel2.Text = outgoingVisitSanction.MovedBy.Trim();
                MoverLabel3.Text = outgoingVisitSanction.MovedBy.Trim();
                FileNoLbl.Text = outgoingVisitSanction.FileNo.Trim();
                SubjectLbl.Text = outgoingVisitSanction.Subject.Trim();
                IncurredOnLbl.Text = outgoingVisitSanction.IncurredOn.Trim();
                RuleNoLbl.Text = outgoingVisitSanction.RuleNo.Trim();
                HeadOfAccountLbl.Text = outgoingVisitSanction.HeadOfAccount.Trim();
                FinancialYearLbl1.Text = OutgoingVisit.FinancialYear.TrimEnd();
                FinancialYearLbl2.Text = OutgoingVisit.FinancialYear.TrimEnd();
                DemandNoLbl.Text = DemandNo.DemandNumber;

                DAMember member = new DAMember();
                if (member.IsChairman == 1)
                {
                    ChairmanAllowancesRow1.Visible = true;
                    ChairmanAllowancesRow2.Visible = true;
                    TotalDA += 2000; // $1000 (Personal Discretionary Allowance/ Entertainment Charges for Chairman Senate) / $1000 (Additional Miscellaneous expenses advance for Chairman Senate)
                }

                if (!string.IsNullOrEmpty(OutgoingVisit.TransportChargesDescription))
                {
                    TransportChargesDescLbl.Text = OutgoingVisit.TransportChargesDescription;
                    TransportChargesLbl.Text = $"US${OutgoingVisit.TransportCharges.ToString()}";
                    transportChargesRow.Visible = true;
                    TotalDA += OutgoingVisit.TransportCharges;
                }
                TransportChargesLbl.Text = OutgoingVisit.TransportCharges.ToString("N0");
                TransportChargesDescLbl.Text = OutgoingVisit.TransportChargesDescription;

                //Get Sanction Total Amount
                List<DADetails> dADetails = new IPRBiz().GetDADetails(outgoingVisitSanction.VisitId);
                double dollarRate = OutgoingVisit.DollarRate;

                if (dADetails != null)
                {
                    foreach (DADetails dA in dADetails)
                    {
                        TotalDA += Math.Round(dA.Total);
                        CountMember++;
                    }
                    TotalPKR = Math.Round((decimal)TotalDA * (decimal)dollarRate);
                    TotalPkrLbl.Text = "Rs. " + TotalPKR.ToString("N0") + "/- (Rupees " + DACalculations.ToWords(TotalPKR) + ")";
                    TotalPkrLbl2.Text = TotalPkrLbl.Text;

                }
                GrandTotalLbl.Text = $"US${TotalDA}";
                //Get Composition of the Delegation
                List<Composition> composition = new IPRBiz().GetComposition(outgoingVisitSanction.VisitId);
                if (composition != null)
                {
                    CompositionLV.DataSource = composition;
                    CompositionLV.DataBind();
                }

                //Get Itinerary
                VisitLV.DataSource = dADetails;
                VisitLV.DataBind();

                int a = 0;
            }
        }
        protected void VisitLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var visit = (DADetails)e.Item.DataItem;
                // Find the inner ListView in the current item template
                var visitorsLV = (ListView)e.Item.FindControl("VisitorsLV");
                if (visitorsLV != null)
                {
                    visitorsLV.DataSource = visit.Members;
                    visitorsLV.DataBind();
                }
            }
        }
        public string AddLocationgHeader()
        {
            string currentSemesterValue = Convert.ToString(Eval("DADetailsId"));
            string html = "";
            if (currentSemesterValue != location)
            {
                category = "";
                location = currentSemesterValue;
                i++;
                //html = String.Format("<tr class=group><td colspan=5><b>" + Eval("Location") + "</b></td><tr>");
                //html = String.Format("<tr style='font-weight:bold;'><th style='padding:0px;'><div class='headerrow'><b>" + Eval("Location").ToString().ToUpper() + "</b></div></th><th><div  class='headerrow'><b>" + Eval("Arrangement").ToString().ToUpper() + "</b></div></th><th>FROM : " + Convert.ToDateTime(Eval("FromDate")).ToShortDateString() + "</th><th> TO: " + Convert.ToDateTime(Eval("ToDate")).ToShortDateString() + "</th><th>" + Eval("NoOfNights") + " NIGHTS</th></tr>");
                html = String.Format("<tr style='font-weight:bold;'><th style='padding:0px;' colspan=5><div style='display:flex;background-color: #D3D3D3 !important;'><div class='headerrow' style='text-wrap: nowrap;'><b>" + Eval("Location").ToString().ToUpper() + "</b></div><div  class='headerrow' style='text-wrap: nowrap;'><b>" + Eval("Arrangement").ToString().ToUpper() + "</b></div><div  class='headerrow'>FROM : " + Convert.ToDateTime(Eval("FromDate")).ToShortDateString() + "</div><div  class='headerrow'> TO: " + Convert.ToDateTime(Eval("ToDate")).ToShortDateString() + "</div><div  class='headerrow'>" + Eval("NoOfNights") + " NIGHTS</div></div></th></tr>");
                return html;

            }
            else return String.Empty;
        }
        public string AddLocationgFooter()
        {
            string currentSemesterValue = Convert.ToString(Eval("DADetailsId"));
            double total = new IPRBiz().GetDADetailsTotal(Convert.ToInt32(currentSemesterValue));
            string html = "";
            //if (currentSemesterValue != location)
            //{
            //    category = "";
            //    location = currentSemesterValue;
                html = String.Format("<tr style='font-weight:bold;'><td style='width: 85%'><b>TOTAL</b></td><td><b>US$ " + total + "</b></td></tr>");
                return html;

            //}
            //else return String.Empty;
        }
        public string AddCategoryRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("Category"));

            if (currentSemesterValue != category)
            {
                category = currentSemesterValue;
                i++;
                return String.Format("<tr class=group><td colspan=5><b>" + Eval("Category") + "</b></td><tr>");

            }
            else return String.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", "attachment;filename=Report.doc");
            Response.Charset = "";
            Response.ContentEncoding = Encoding.UTF8;

            using (StringWriter sw1 = new StringWriter())
            using (HtmlTextWriter hw1 = new HtmlTextWriter(sw1))
            {
                pnlContents.RenderControl(hw1);
                Response.Output.Write(sw1.ToString());
            }
            Response.Flush();
            Response.End();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //pnlContents.RenderControl(hw);   // Or GridView, Table, etc.

            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();

            //Response.Write(pdfDoc);
            //Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Needed for exporting entire page
        }
    }
}
