using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class HeadOfAccountBCR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<FinancialYears> fys = new BudgetBiz().GetFinancialYears();
                if (fys != null)
                {
                    foreach (FinancialYears row in fys)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.FinancialYear;
                        li.Value = row.FinancialYearId.ToString();
                        FinancialYearDDL.Items.Add(li);
                    }
                }
                //  int BranchId = 23;
                int FinancialYearsId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                //List<BranchHead> branch = new BudgetBiz().GetBranchHeads(BranchId, FinancialYearsId);
                //if (branch != null)
                //{
                //    foreach (BranchHead row in branch)
                //    {
                //        ListItem li = new ListItem();
                //        li.Text = row.HeadOfAccount;
                //        li.Value = row.HeadOfAccountId.ToString();
                //        HeadOfAccountDDL.Items.Add(li);
                //    }
                //}
            }
        }
        protected string GetDate(DateTime date)
        {
            return (date < Convert.ToDateTime("01/01/1900")) ? string.Empty : date.ToShortDateString();
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected void HeadOfAccountDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FY = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int HOA = Convert.ToInt32(HidHeadOfAccountId.Value);
            HeadOfAccountBudget hoa = new BudgetBiz().GetBranchBudget(HOA, FY, 13);
            AllottedLbl.Text = "Allocated Amount:" + hoa.Amount.ToString();
            List<Bcr> bcr = new BudgetBiz().GetBCR(FY, HOA);
            double CurrentBalance = hoa.Amount;
            double ProgressiveEpenditure = 0;
            List<Bcr> FinalBcr = new List<Bcr>();
            if (bcr != null)
            {
                var sortedbcr = from p in bcr
                                orderby p.EntryDate
                                select p;

                foreach (Bcr sortbcr in sortedbcr)
                {
                    if (sortbcr.TotalAmount != 0)
                    {
                        ProgressiveEpenditure = ProgressiveEpenditure + sortbcr.TotalAmount;
                        sortbcr.ProgressiveExpenditure = ProgressiveEpenditure;
                        CurrentBalance = CurrentBalance - sortbcr.TotalAmount;
                        sortbcr.Balance = CurrentBalance;
                    }
                    else if (sortbcr.FromHeadOfAccountId == HOA)
                    {
                        sortbcr.ReAppropriationType = "-";
                        CurrentBalance = CurrentBalance - sortbcr.ReAppAmount;
                        sortbcr.Balance = CurrentBalance;
                    }
                    else if (sortbcr.ToHeadOfAccountId == HOA)
                    {
                        sortbcr.ReAppropriationType = "+";
                        CurrentBalance = CurrentBalance + sortbcr.ReAppAmount;
                        sortbcr.Balance = CurrentBalance;
                    }

                }
                BillLV.DataSource = sortedbcr;
                BillLV.DataBind();
            }
            else
            {
                BillLV.DataSource = null;
                BillLV.DataBind();
            }



        }

        protected string GetFormattedText(string s1, string s2)
        {
            if (!String.IsNullOrEmpty(s1))
                return s1 + "</br>" + s2;
            else
                return "";
        }
        protected string GetBranch(int BranchId)
        {
            Branch branch = new BudgetBiz().GetBranch(BranchId);
            if (branch != null)
                return branch.Description;
            else
                return "";
        }
        protected void GetBCRBtn_Click(object sender, EventArgs e)
        {

            int FY = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int HOA = Convert.ToInt32(HidHeadOfAccountId.Value);
            HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(HOA, FY);
            AllottedLbl.Text = HeadOfAccountTxt.Text + "--(Allocated Amount:" + FormatAmount(hoa.Amount).ToString() + ")";
            List<Bcr> bcr = new BudgetBiz().GetBCR(FY, HOA);

            double CurrentBalance = hoa.Amount;
            double ProgressiveEpenditure = 0;
            List<Bcr> FinalBcr = new List<Bcr>();
            if (bcr != null)
            {
                var sortedbcr = from p in bcr
                                orderby p.EntryDate
                                select p;

                foreach (Bcr sortbcr in sortedbcr)
                {
                    if (sortbcr.TotalAmount != 0)
                    {
                        ProgressiveEpenditure = ProgressiveEpenditure + sortbcr.TotalAmount;
                        sortbcr.ProgressiveExpenditure = ProgressiveEpenditure;
                        CurrentBalance = CurrentBalance - sortbcr.TotalAmount;
                        sortbcr.Balance = CurrentBalance;
                    }
                    else if (sortbcr.FromHeadOfAccountId == HOA)
                    {
                        sortbcr.ReAppropriationType = "-";
                        CurrentBalance = CurrentBalance - sortbcr.ReAppAmount;
                        sortbcr.Balance = CurrentBalance;
                    }
                    else if (sortbcr.ToHeadOfAccountId == HOA)
                    {
                        sortbcr.ReAppropriationType = "+";
                        CurrentBalance = CurrentBalance + sortbcr.ReAppAmount;
                        sortbcr.Balance = CurrentBalance;
                    }

                }
                BillLV.DataSource = sortedbcr;
                BillLV.DataBind();
            }
            else
            {
                BillLV.DataSource = null;
                BillLV.DataBind();
            }

        }
    }
}