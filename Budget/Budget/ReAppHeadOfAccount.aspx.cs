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
    public partial class ReAppHead_OfAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            fylabel.Text = "Head of Account Re-Appropriation - - Financial Year (" + fy.FinancialYear + ")";
        }

        protected void transfer_Click(object sender, EventArgs e)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            ReApproprationEnt reapp = new ReApproprationEnt();
            reapp.FromHeadOfAccountId = Convert.ToInt32(HidhoaFrom.Value);
            reapp.ToHeadOfAccountId = Convert.ToInt32(HidhoaTo.Value);
            string amount1 = FromHOATxt.Text.Remove(0, FromHOATxt.Text.IndexOf("s.") + 2);
            //string amount2 = ToHOATxt.Text.Remove(0, ToHOATxt.Text.IndexOf("s.") + 2);
            string amount2 = AmountTxt.Text;
            double FromCurrentAmount = Convert.ToDouble(amount1);
            reapp.Amount = Convert.ToDouble(amount2);
            double amount = Convert.ToDouble(AmountTxt.Text);
            reapp.ReApprpriationDate = Convert.ToDateTime(ReAppDate.Text);
            reapp.Remarks = Convert.ToString(RemarksTxt.Text);
            reapp.FinancialYearId = fy.FinancialYearId;
            if(FromCurrentAmount<reapp.Amount)
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