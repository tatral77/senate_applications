using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Budget
{
    public partial class BranchHOAReAppropriation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
                fylabel.Text = "Financial Year (" + fy.FinancialYear + ")";
                List<Branch> branch = new BudgetBiz().GetBudgetBranches();
                if (branch != null)
                {
                    foreach (Branch row in branch)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.Description;
                        li.Value = row.Branchid.ToString();
                        BranchDDL.Items.Add(li);
                    }
                }
            }
        }
        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            HeadOfAccountDDL.Items.Clear();
            HeadOfAccountDDL.Items.Add(new ListItem("Select", "0"));
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
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
        protected void HeadOfAccountDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(Convert.ToInt32(HeadOfAccountDDL.SelectedValue), fy.FinancialYearId);
            AmountTxt.Text = hoa.RemainingBalance.ToString();
            //GetBills();

        }
        protected void transfer_Click(object sender, EventArgs e)
        {

            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            ReApproprationEnt reapp = new ReApproprationEnt();
            reapp.FromHeadOfAccountId = Convert.ToInt32(HidhoaFrom.Value);
            reapp.ToHeadOfAccountId = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            string amount1 = FromHOATxt.Text.Remove(0, FromHOATxt.Text.IndexOf("s.") + 2);
            //string amount2 = ToHOATxt.Text.Remove(0, ToHOATxt.Text.IndexOf("s.") + 2);
            string amount2 = AmountTxt.Text;
            double FromCurrentAmount = Convert.ToDouble(amount1);
            reapp.Amount = Convert.ToDouble(amount2);
            double amount = Convert.ToDouble(AmountTxt.Text);
            reapp.ReApprpriationDate = Convert.ToDateTime(ReAppDate.Text);
            reapp.Remarks = Convert.ToString(RemarksTxt.Text);
            reapp.FinancialYearId = fy.FinancialYearId;
            if (FromCurrentAmount < reapp.Amount)
            {
                success.Text = "";
                err.Text = "Amount is exceeded from balance.";
            }
            else
            {
                new BUDBIZ.BudgetBiz().InsertReAppropriation(reapp);
                err.Text = "";
                success.Text = "Successfully Transfered.";
            }
        }
    }
}