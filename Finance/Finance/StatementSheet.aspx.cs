using BUDBIZ;
using System;
using System.Collections.Generic;
using FinEntities;
using FinBiz;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finance
{
    public partial class StatementSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                double totalAllowances = 0;
                double totalDeductions = 0;
                int CategoryId = Convert.ToInt32(Request.QueryString["CatId"]);
                int FinancialYearId = Convert.ToInt32(Request.QueryString["fy"]);
                int Month = Convert.ToInt32(Request.QueryString["Mon"]);

                string MonthName = new BudgetBiz().GetMonth(Month).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(Month, FinancialYearId);
                if (CategoryId == 1)
                    headerdiv.InnerText = "STATEMENT SHOWING PAY AND ALLOWANCES OF MEMBERS FOR THE MONTH OF " + MonthName;
                if (CategoryId == 2)
                    headerdiv.InnerText = "STATEMENT SHOWING PAY AND ALLOWANCES OF CHAIRMAN STANDING/FUNCTIONAL COMMITTEES FOR THE MONTH OF " + MonthName;
                double BankAmount = 0;
                double ChequeAmount = 0;
                //                SlipHeading.InnerText = "PAY SLIP (" + month;
                List<Member> Members = new FinBIZ().GetCatMemberWithBankAccount(CategoryId);
                List<Member> MembersWithoutBankAccount = new FinBIZ().GetCatMemberWithoutBankAccount(CategoryId);
                if (Members != null)
                {
                    foreach (Member membersWithoutBankAccount in MembersWithoutBankAccount)
                    {
                        Members.Add(membersWithoutBankAccount);
                    }
                }
                // SalaryStructure sd = new FinBIZ().GetSalaryStructureByCategory(CategoryId);
                //List<MonthlyAllowance> AllowancesNames = new FinBIZ().GetDistinctMonthlyAllownacesList(CategoryId, fy, Mon);
                List<MonthlyAllowance> Allowances = new FinBIZ().GetMonthlyAllownacesList(CategoryId, FinancialYearId, Month);
                List<MonthlyDeduction> Deductions = new FinBIZ().GetMonthlyDeductionsList(CategoryId, FinancialYearId, Month);

                List<MonthlyAllowance> MonthlyAllowances = new List<MonthlyAllowance>();
                List<MonthlyDeduction> MonthlyDeductions = new List<MonthlyDeduction>();
                List<MonthlyDeduction> PayOrderDeductions = new List<MonthlyDeduction>();

                int i = 0;
                int j = 0;
                int cols = 7;
                string table = "<table class='table table-condensed' style='font-size:8pt;'><thead style='display: table-header-group;'><tr><th style='border-bottom:solid thin'>Sr.No</th><th style='border-bottom:solid thin'>Name of Senator</th><th style='border-bottom:solid thin'>Month</th> ";
                if (Allowances != null && Deductions != null)
                {
                    //Prepare Allowances Header of Table
                    foreach (MonthlyAllowance monthlyAllowance in Allowances)
                    {
                        table = table + "<th style='border-bottom:solid thin'>" + monthlyAllowance.AllowanceDesc + "</th>";
                        cols++;
                    }

                    //Header for Total Pay and Allowances
                    table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Pay & Allowances</th>";

                    //Prepare Deductions Header of Table
                    foreach (MonthlyDeduction monthlyDeduction in Deductions)
                    {
                        table = table + "<th style='border-bottom:solid thin'>" + monthlyDeduction.DeductionDesc + "</th>";
                        cols++;
                    }

                    //Header for Total Pay and Deductions and Totals
                    table = table + "<th style='border-bottom:solid thin;text-align:center;'>Total Deductions</th><th style='border-bottom:solid thin'>Net Payable</th><th style='border-bottom:solid thin'>Bank/ Account Number/ Cheque No</th></tr></thead>";

                    if (Members != null)
                        foreach (Member member in Members)
                        {

                            i++;
                            table = table + "<tr><td>" + i + "</td>";  //Serial Number
                            table = table + "<td style='min-width:12%;font-weight:bold;white-space:nowrap;'>" + member.MemberName + "</td>";
                            table = table + "<td style='min-width:8%;white-space:nowrap;'>" + MonthName + "</td>";
                            double TotalAllowance = 0;
                            double TotalDeduction = 0;
                            double NetAmount = 0;

                            foreach (MonthlyAllowance structureallowance in Allowances)
                            {
                                MonthlyAllowance ma = new FinBIZ().GetMonthlyAllowance(member.MemberId, Month, FinancialYearId, structureallowance.AllowanceId);
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

                            if (Deductions != null)
                            {
                                foreach (MonthlyDeduction structuredeductions in Deductions)
                                {
                                    MonthlyDeduction md = new FinBIZ().GetMonthlyDeduction(member.MemberId, Month, FinancialYearId, structuredeductions.DeductionId);
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
                            }
                            table = table + "<td style=font-weight:bold;text-align:right;>" + FormatAmount(TotalDeduction) + "</td>";
                            NetAmount = TotalAllowance - TotalDeduction;
                            if (member.HaveBankAccount == 1)
                                BankAmount = BankAmount + NetAmount;
                            else
                                ChequeAmount = ChequeAmount + NetAmount;
                            table = table + "<td style=font-weight:bold;text-align:right;>" + FormatAmount(NetAmount) + "</td>";
                            MemberSalaryDetails MemSalDetail = new FinBIZ().GetMemberSalaryDetail(member.MemberId, FinancialYearId, Month);
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
                }
                    ///////////////////////////////////////////////////////////////
                    table = table + "<tr style='border-top:solid thin;'><td style='border-top:solid thin;text-align:center;font-weight:bold;' colspan='3'>Total</td>";

                    if (Allowances != null)
                    {
                        foreach (MonthlyAllowance structureallowance in Allowances)
                        {
                            var A = MonthlyAllowances.Where(c => c.AllowanceId == structureallowance.AllowanceId).Sum(c => c.Amount);
                            table = table + "<td style='border-top:solid thin'>" + FormatAmount(A) + "</td>";
                        }
                    }
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount(totalAllowances) + "</td>";
                    if (Deductions != null)
                    {
                        foreach (MonthlyDeduction structuredeductions in Deductions)
                        {
                            var A = MonthlyDeductions.Where(c => c.DeductionId == structuredeductions.DeductionId).Sum(c => c.Amount);
                            table = table + "<td style='border-top:solid thin'>" + FormatAmount(A) + "</td>";
                            if (structuredeductions.ShowInDetail == 1)
                            {
                                MonthlyDeduction PayOrderMonthlydeduction = new MonthlyDeduction();
                                PayOrderMonthlydeduction = structuredeductions;
                                PayOrderMonthlydeduction.Amount = A;
                                PayOrderDeductions.Add(PayOrderMonthlydeduction);
                            }

                            // structuredeductions.Amount = A;

                        }
                    }
                    MonthlyDeduction TotalMonthlyDeduction = new MonthlyDeduction();
                    TotalMonthlyDeduction.Description = "Net Amount Payable";
                    TotalMonthlyDeduction.Amount = (totalAllowances - totalDeductions);
                    PayOrderDeductions.Add(TotalMonthlyDeduction);
                    LV.DataSource = PayOrderDeductions;
                    LV.DataBind();
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount(totalDeductions) + "</td>";
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    table = table + "<td style='font-weight:bold;text-align:right;border-top:solid thin'>" + FormatAmount((totalAllowances - totalDeductions)) + "</td>";

                    table = table + "</tr></table>";
                    div.InnerHtml = table;
                    BankLabel.Text = FormatAmount(BankAmount);
                    ChequeLabel.Text = FormatAmount(ChequeAmount);
                    TotalAmountLbl.Text = FormatAmount(BankAmount + ChequeAmount);
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