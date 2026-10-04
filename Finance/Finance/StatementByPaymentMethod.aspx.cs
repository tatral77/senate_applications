using BUDBIZ;
using FinBiz;
using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finance
{
    public partial class StatementSheetBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                double totalAllowances = 0;
                double totalDeductions = 0;
                int CatId = Convert.ToInt32(Request.QueryString["CatId"]);
                int fy = Convert.ToInt32(Request.QueryString["fy"]);
                int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
                int PaymentType = Convert.ToInt32(Request.QueryString["ptype"]);
                string month = new BudgetBiz().GetMonth(Mon).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(Mon, fy);
                if (CatId == 1)
                    headerdiv.InnerText = "STATEMENT SHOWING PAY AND ALLOWANCES OF MEMBERS FOR THE MONTH OF " + month;
                if (CatId == 2)
                    headerdiv.InnerText = "STATEMENT SHOWING PAY AND ALLOWANCES OF CHAIRMAN STANDING/FUNCTIONAL COMMITTEES FOR THE MONTH OF " + month;
                double BankAmount = 0;
                double ChequeAmount = 0;
                //                SlipHeading.InnerText = "PAY SLIP (" + month;
                List<Member> members = null;
                if (PaymentType == 1)
                {
                    members = new FinBIZ().GetCatMemberWithBankAccount(CatId);
                    paymethod.InnerText = "MEMBERS WITH BANK ACCOUNTS";
                }
                if (PaymentType == 2)
                {
                    members = new FinBIZ().GetCatMemberWithoutBankAccount(CatId);
                    paymethod.InnerText = "MEMBERS PAID BY CHEQUE";
                }
                //foreach (Member withoutBankAccount in members2)
                //{
                //    members.Add(withoutBankAccount);
                //}
                // SalaryStructure sd = new FinBIZ().GetSalaryStructureByCategory(CatId);
                List<MonthlyAllowance> Allowances = new FinBIZ().GetMonthlyAllownacesList(CatId, fy, Mon);
                List<MonthlyDeduction> Deductions = new FinBIZ().GetMonthlyDeductionsList(CatId, fy, Mon);
                List<MonthlyAllowance> MonthlyAllowances = new List<MonthlyAllowance>();
                List<MonthlyDeduction> MonthlyDeductions = new List<MonthlyDeduction>();
                List<MonthlyDeduction> PayOrderDeductions = new List<MonthlyDeduction>();

                int i = 0;
                int j = 0;
                int cols = 7;
                string table = "<table class='table table-condensed' style='font-size:8pt;'><thead style='display: table-header-group;'><tr><th style='border-bottom:solid thin'>Sr.No</th><th style='border-bottom:solid thin'>Name of Senator</th><th style='border-bottom:solid thin'>Month</th> ";
                if (Allowances != null)
                {
                    foreach (MonthlyAllowance sa in Allowances)
                    {
                        table = table + "<th style='border-bottom:solid thin'>" + sa.AllowanceDesc + "</th>";
                        cols++;
                    }
                    table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Pay & Allowances</th>";
                    foreach (MonthlyDeduction sded in Deductions)
                    {
                        table = table + "<th style='border-bottom:solid thin'>" + sded.DeductionDesc + "</th>";
                        cols++;
                    }
                    table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Deductions</th><th style='border-bottom:solid thin'>Net Payable</th><th style='border-bottom:solid thin'>Bank/ Account Number/ Cheque No</th></tr></thead>";
                    foreach (Member mem in members)
                    {

                        i++;
                        table = table + "<tr><td>" + i + "</td>";
                        table = table + "<td style='min-width:12%;font-weight:bold;white-space:nowrap;'>" + mem.MemberName + "</td>";
                        table = table + "<td style='min-width:8%;white-space:nowrap;'>" + month + "</td>";
                        double TotalAllowance = 0;
                        double TotalDeduction = 0;
                        double NetAmount = 0;

                        foreach (MonthlyAllowance structureallowance in Allowances)
                        {
                            MonthlyAllowance ma = new FinBIZ().GetMonthlyAllowance(mem.MemberId, Mon, fy, structureallowance.AllowanceId);
                            if (!String.IsNullOrEmpty(ma.AllowanceDesc))
                            {
                                table = table + "<td>" + FormatAmount(ma.Amount) + "</td>";
                                TotalAllowance = TotalAllowance + ma.Amount;
                                totalAllowances = totalAllowances + ma.Amount;
                                MonthlyAllowances.Add(ma);
                            }
                            else
                                table = table + "<td>-</td>";
                        }
                        table = table + "<td style=font-weight:bold;text-align:right;style='border-right:solid thin';>" + FormatAmount(TotalAllowance) + "</td>";
                        foreach (MonthlyDeduction structuredeductions in Deductions)
                        {
                            MonthlyDeduction md = new FinBIZ().GetMonthlyDeduction(mem.MemberId, Mon, fy, structuredeductions.DeductionId);
                            if (!String.IsNullOrEmpty(md.DeductionDesc))
                            {
                                table = table + "<td>" + FormatAmount(md.Amount) + "</td>";
                                TotalDeduction = TotalDeduction + md.Amount;
                                totalDeductions = totalDeductions + md.Amount;
                                MonthlyDeductions.Add(md);
                            }
                            else
                                table = table + "<td>-</td>";
                        }
                        table = table + "<td style=font-weight:bold;text-align:right;>" + FormatAmount(TotalDeduction) + "</td>";
                        NetAmount = TotalAllowance - TotalDeduction;
                        if (mem.HaveBankAccount == 1)
                            BankAmount = BankAmount + NetAmount;
                        else
                            ChequeAmount = ChequeAmount + NetAmount;
                        table = table + "<td style=font-weight:bold;text-align:right;>" + FormatAmount(NetAmount) + "</td>";
                        MemberSalaryDetails MemSalDetail = new FinBIZ().GetMemberSalaryDetail(mem.MemberId, fy, Mon);
                        if (!String.IsNullOrEmpty(MemSalDetail.BankName))
                            table = table + "<td style='white-space:nowrap;'>" + MemSalDetail.BankName + " / " + MemSalDetail.BankAccount + "</td>";
                        else
                            table = table + "<td style='white-space:nowrap;'>" + MemSalDetail.ChequeNumber + "</td>";

                        table = table + "</tr>";
                        if (i % 25 == 0)
                        {
                            table = table + "<tr style = 'page-break-after: always'></tr>";
                        }

                    }
                    ///////////////////////////////////////////////////////////////
                    table = table + "<tr style='border-top:solid thin;'><td style='border-top:solid thin;text-align:center;font-weight:bold;' colspan='3'>Total</td>";
                    foreach (MonthlyAllowance structureallowance in Allowances)
                    {
                        var A = MonthlyAllowances.Where(c => c.AllowanceId == structureallowance.AllowanceId).Sum(c => c.Amount);
                        table = table + "<td style='border-top:solid thin'>" + FormatAmount(A) + "</td>";
                    }
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount(totalAllowances) + "</td>";
                    foreach (MonthlyDeduction structuredeductions in Deductions)
                    {
                        var A = MonthlyDeductions.Where(c => c.DeductionId == structuredeductions.DeductionId).Sum(c => c.Amount);
                        table = table + "<td style='border-top:solid thin'>" + FormatAmount(A) + "</td>";
                        if (structuredeductions.ShowInDetail == 1)
                        {
                            MonthlyDeduction mded = new MonthlyDeduction();
                            mded = structuredeductions;
                            mded.Amount = A;
                            PayOrderDeductions.Add(mded);
                        }

                        // structuredeductions.Amount = A;

                    }
                    MonthlyDeduction mded2 = new MonthlyDeduction();
                    mded2.Description = "Net Amount Payable";
                    mded2.Amount = (totalAllowances - totalDeductions);
                    PayOrderDeductions.Add(mded2);
                    //LV.DataSource = PayOrderDeductions;
                    //LV.DataBind();
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount(totalDeductions) + "</td>";
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount((totalAllowances - totalDeductions)) + "</td>";

                    table = table + "</tr></table>";
                    div.InnerHtml = table;
                    //BankLabel.Text = FormatAmount(BankAmount);
                   // ChequeLabel.Text = FormatAmount(ChequeAmount);
                   // TotalAmountLbl.Text = FormatAmount(BankAmount + ChequeAmount);
                }
            }
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected string NumberToWords(int Amount)
        {
            return new FinBIZ().NumberToWords(Amount, true);
        }
    }
}