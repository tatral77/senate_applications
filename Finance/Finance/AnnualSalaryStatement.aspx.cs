using BUDBIZ;
using BUDENTITIES;
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
    public partial class AnnualSalaryStatement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                double totalAllowances = 0;
                double totalDeductions = 0;
                string startMonth = null;
                string endMonth = null;
                int MemberId = Convert.ToInt32(Request.QueryString["MemberId"]);
                Member member = new FinBIZ().GetMemberById(MemberId);
                int fy = Convert.ToInt32(Request.QueryString["fy"]);
                List<Months> FinancialYearMonths = new List<Months>();
                FinancialYearMonths = new BudgetBiz().GetMonths();
                foreach (Months financialYearMonths in FinancialYearMonths)
                {
                    financialYearMonths.FinancialYearId = fy;
                    financialYearMonths.MonthDescription = new BudgetBiz().GetMonth(financialYearMonths.MonthId).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(financialYearMonths.MonthId, fy);
                    if (financialYearMonths.MonthId == 7)
                        startMonth = financialYearMonths.MonthDescription;
                    if (financialYearMonths.MonthId == 6)
                        endMonth = financialYearMonths.MonthDescription;

                }
                headerdiv.InnerText = "STATEMENT OF SALARY AND ALLOWANCES (EXCLUDING TA/DA) PAID FROM " + startMonth + " - " + endMonth;
                senatornamediv.InnerText = " TO SENATOR REMAN MALIK";// 

               // List<Member> members = new FinBIZ().GetMembersByCategory(CatId);
                // SalaryStructure sd = new FinBIZ().GetSalaryStructureByCategory(CatId);
                List<MonthlyAllowance> Allowances = new FinBIZ().GetMemberFinYearAllownacesList(MemberId, fy);
                List<MonthlyDeduction> Deductions = new FinBIZ().GetMemberFinYearDeductionsList(MemberId, fy);
                List<MonthlyAllowance> MonthlyAllowances = new List<MonthlyAllowance>();
                List<MonthlyDeduction> MonthlyDeductions = new List<MonthlyDeduction>();
                List<MonthlyDeduction> PayOrderDeductions = new List<MonthlyDeduction>();

                int i = 0;
                string table = "<table class='table table-condensed' style='font-size:8pt;'><thead style='display: table-header-group;'><tr><th style='border-bottom:solid thin'>Sr.No</th><th style='border-bottom:solid thin'>Month</th> ";
                foreach (MonthlyAllowance sa in Allowances)
                {
                    table = table + "<th style='border-bottom:solid thin'>" + sa.AllowanceDesc + "</th>";
                }
                table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Pay & Allowances</th>";
                foreach (MonthlyDeduction sded in Deductions)
                {
                    table = table + "<th style='border-bottom:solid thin'>" + sded.DeductionDesc + "</th>";
                }
                table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Deductions</th><th style='border-bottom:solid thin'>Net Payable</th></tr></thead>";
                foreach (Months month in FinancialYearMonths)
                {
                    //FinancialYearSalaryDetail fydetail = new FinBIZ().GetFinancialYearSalaryDetails(month.MonthId, fy);
                    //if (fydetail.Finalized == 1)
                    //{
                        i++;
                        table = table + "<tr><td>" + i + "</td>";
                        table = table + "<td style='min-width:8%;white-space:nowrap;'>" + month.MonthDescription + "</td>";
                        double TotalAllowance = 0;
                        double TotalDeduction = 0;
                        double NetAmount = 0;

                        foreach (MonthlyAllowance structureallowance in Allowances)
                        {
                            MonthlyAllowance ma = new FinBIZ().GetMonthlyAllowance(member.MemberId, month.MonthId, fy, structureallowance.AllowanceId);
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
                            MonthlyDeduction md = new FinBIZ().GetMonthlyDeduction(member.MemberId, month.MonthId, fy, structuredeductions.DeductionId);
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
                        table = table + "<td style=font-weight:bold;text-align:right;>" + FormatAmount(NetAmount) + "</td>";
                        table = table + "</tr>";
                    }
                    ///////////////////////////////////////////////////////////////
                    table = table + "<tr style='border-top:solid thin;'><td style='border-top:solid thin;text-align:center;font-weight:bold;' colspan='2'>Total</td>";
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
                    }
                    MonthlyDeduction mded2 = new MonthlyDeduction();
                    mded2.Description = "Net Amount Payable";
                    mded2.Amount = (totalAllowances - totalDeductions);
                    PayOrderDeductions.Add(mded2);

                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount(totalDeductions) + "</td>";
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount((totalAllowances - totalDeductions)) + "</td>";

                    table = table + "</tr></table>";
                    div.InnerHtml = table;
                }
            //}
        
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