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
    public partial class AllMembersSalarySlips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            double totalAllowances=0;
            double totalDeductions=0;
            int CatId = Convert.ToInt32(Request.QueryString["CatId"]);
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            string month=new BudgetBiz().GetMonth(Mon).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(Mon, fy);
            List<Member> Members=new FinBIZ().GetMembersByCategory(CatId);
            string table=null;
            foreach (Member members in Members)
            {
                table = table + "<table style ='width: 100%;'>";
                table = table + "<tr>";
                table = table + "<td style='border-bottom: solid thin; border-color: #000; width: 10%'>";
                table = table + "<img src = 'images\\logo.png' style='width: 80px; height: 80px;'/>";
                table = table + "</td>";
                table = table + "<td style = 'border-bottom: solid thin; border-color: #000; text-align: center; width: 90%'>";
                table = table + "<div style='font-family: Verdana; font-size: 14pt; text-decoration: underline; text-align: center; font-weight: bold'>SENATE OF PAKISTAN</div>";
                table = table + "<div style = 'margin-top: 5px; font-family: Verdana; font-size: 12pt; text-align: center;'> PAY SLIP(" + month + ")</div>";
                table = table + "<div style = 'margin-top: 5px; font-family: Verdana; font-size: 12pt; text-align: right;'></div>";
                table = table + "</td>";
                table = table + "</tr>";
                table = table + "<tr>";
                table = table + "<td style='width: 100%; padding-top: 10px;' colspan='2'>";
                table = table + "<div style = 'font-size: 11pt; font-family: Verdana; text-align: left; font-weight: bold'>";
                table = table + members.MemberName.ToUpper() + " (" + members.MemberSalCategory.ToUpper() + ")";
                table = table + "</div>";
                table = table + "</td>";
                table = table + "</tr>";
                table = table + "</table>";
                table = table + "<table class='table'>";
                table = table + "<tr>";
                table = table + "<td>";
                table = table + "<table class='table table-responsive'>";
                table = table + "<tr>";
                table = table + "<th>PAY AND ALLOWANCES</th>";
                table = table + "<th style = 'text-align: right'> MONTHLY RATE</th>";
                table = table + " <th style = 'text-align: right'> AMOUNT </th> ";
                table = table + "</tr>";


                List<MonthlyAllowance> monthlyallowances = new FinBIZ().GetMonthlyAllowances(members.MemberId, fy, Mon);
                if (monthlyallowances != null)
                { 
                    totalAllowances = 0;
                    foreach (MonthlyAllowance ma in monthlyallowances)
                    {
                        table = table + "<tr><td>" + ma.AllowanceDesc + "</td><td style='text-align: right'>" + FormatAmount(ma.MonthlyRate) + "</td><td style='text-align: right'>" + ma.Amount + "</td></tr>";
                        totalAllowances = totalAllowances + ma.Amount;
                    }
                    table = table + "<tr>";
                    table = table + "<td colspan = '2' style = 'text-align: left; font-weight: bold; border-bottom: solid 2px !important'> Gross Pay and Allowances </td>";


                    table = table + "<td style = 'text-align: right; font-weight: bold; border-bottom: solid 2px !important'> 213,000 </td>";

                    table = table + "</tr>";

                    table = table + "</table>";

                    table = table + "</td>";

                    table = table + "</tr>";



                    table = table + "<tr>";

                    table = table + "<td>";

                    table = table + "<table class='table'>";
                    table = table + "<tr>";
                    table = table + "<th colspan = '2'> DEDUCTIONS </th>";
                    table = table + "<th style='text-align: right'>AMOUNT</th>";
                    table = table + "</tr>";
                    List<MonthlyDeduction> monthlydeductions = new FinBIZ().GetMonthlyDeductions(members.MemberId, fy, Mon);
                    totalDeductions = 0;
                    foreach (MonthlyDeduction md in monthlydeductions)
                    {
                        table = table + "<tr><td colspan=2>" + md.DeductionDesc + " </td><td style='text-align: right'>" + FormatAmount(md.Amount) + "</td></tr>";
                        totalDeductions = totalDeductions + md.Amount;
                    }
                    table = table + "<tr>";
                    table = table + "                <td colspan ='2' style='text-align: left; font-weight: bold; border-bottom: solid 2px !important'> Total Deductions </td>";

                    table = table + "                   <td style = 'text-align: right; font-weight: bold; border-bottom: solid 2px !important'>" + FormatAmount(totalDeductions) + " </td>";

                    table = table + "</tr>";

                    table = table + "</table>";


                    table = table + "</td>";

                    table = table + "</tr>";

                    double amountPayable = totalAllowances - totalDeductions;
                    table = table + "<tr>";
                    table = table + "<td colspan = '2' style = 'text-align: right; font-size: 14pt; font-weight: bold'> Net Payable:" + FormatAmount(amountPayable) + "</td>";

                    table = table + "</tr>";
                    table = table + "<tr>";
                    table = table + "<td style = 'padding-top: 20px;' colspan = '2'>";

                    table = table + "<div style = 'font-size: 11pt; font-family: Verdana; text-align: left; font-weight: bold'>";
                    MemberSalaryDetails sd = new FinBIZ().GetMemberSalaryDetail(members.MemberId, fy, Mon);
                    if (!String.IsNullOrEmpty(sd.BankName))
                        table = table + "BANK: " + sd.BankName.ToUpper() + " (" + sd.BankAccount + ")";
                    else if (!String.IsNullOrEmpty(sd.ChequeNumber))
                        table = table + "CHEQUE NO: " + sd.ChequeNumber.ToUpper();
                    table = table + "</div>";
                    table = table + "</td>";
                    table = table + "</tr>";
                    table = table + "</table>";

                    table = table + "<p style = 'page-break-after: always'></p>";
                }
                slipdiv.InnerHtml = table;
            }
        }

        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
      
    }
}