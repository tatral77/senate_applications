using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class ManageSavings : System.Web.UI.Page
    {
        int BranchId = 16;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
                List<BranchHead> branch = new BudgetBiz().GetBranchHeads(BranchId, fy.FinancialYearId);
                if (branch != null)
                {
                    foreach (BranchHead row in branch)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.HeadOfAccount;
                        li.Value = row.HeadOfAccountId.ToString();
                        HeadOfAccountDDL.Items.Add(li);
                    }
                }
            }
        }

        protected void SavingBtn_Click(object sender, EventArgs e)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            SavingSurrenderEnt sav = new SavingSurrenderEnt();
            sav.BranchId = 23;
            sav.HeadOfAccountId = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            sav.FinancialYearId = fy.FinancialYearId;
            sav.Amount = Convert.ToDouble(AmountTxt.Text);
            sav.SavingDate = DateTime.Now;
            HeadOfAccountBudget branchbudget = new BudgetBiz().GetBranchBudget(sav.HeadOfAccountId, sav.FinancialYearId, sav.BranchId);
            if (sav.Amount > branchbudget.RemainingBalance)
                error.Text = "Amount exceeded from current balancae";
            else
            {
                error.Text = "";
                new BudgetBiz().InsertBranchHeadSavings(sav);
            }

        }
        protected void SurrenderBtn_Click(object sender, EventArgs e)
        {

            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            SavingSurrenderEnt sav = new SavingSurrenderEnt();
            sav.BranchId = 23;
            sav.HeadOfAccountId = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);

            sav.FinancialYearId = fy.FinancialYearId;
            sav.Amount = Convert.ToDouble(AmountTxt.Text);
            sav.SavingDate = DateTime.Now;
            HeadOfAccountBudget branchbudget = new BudgetBiz().GetBranchBudget(sav.HeadOfAccountId, sav.FinancialYearId, sav.BranchId);
            if (sav.Amount > branchbudget.RemainingBalance)
                error.Text = "AmountTxt exceeded from current balancae";
            else
            {
                error.Text = "";
                new BudgetBiz().InsertBranchHeadSurrender(sav);
            }
        }

        protected void HeadOfAccountDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            int HeadOfAccountId = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            List<SavingSurrenderEnt> saving = new BudgetBiz().GetBranchHeadSavings(fy.FinancialYearId, HeadOfAccountId, 23);
            SavingLV.DataSource = saving;
            SavingLV.DataBind();
        }
    }
}