using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUDENTITIES;
using BUDBIZ;

namespace Budget
{
    public partial class HeadOfAccountsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTreeView();
        }
        protected void GetTreeView()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            List<FundCenters> fundCenters = new BudgetBiz().GetFundCentersList(2);
            string treeView = "<ul id='tree1'>";
            foreach (FundCenters fs in fundCenters)
            {
                treeView += "<li class='fs'>" + fs.FundCenter + " (Allocated Rs. " + FormatAmount(fs.FundCenterAmount) +")-" + " (Balance Rs. " + FormatAmount(fs.Remaining) + ")-" + " (Saving/ Un-Allocated Rs. " + FormatAmount(fs.Saving) + ")-" + " (Surrendered Rs. " + FormatAmount(fs.Surrender) + ")";
                if (fs.majorObjects != null)
                {
                    treeView += "<ul>";
                    foreach (MajorObjects mo in fs.majorObjects)
                    {
                        treeView += "<li class='maj'>" + mo.MajorObject + " (Allocated Rs. " + FormatAmount(mo.MajorObjectAmount) + ")-" + " (Balance Rs. " + FormatAmount(mo.MajorObjectRemaining) + ")-" + " (Saving/ Un-Allocated Rs. " + FormatAmount(mo.MajorObjectSaving) + ")-" + " (Surrendered Rs. " + FormatAmount(mo.MajorObjectSurrender) + ")";
                        if (mo.minorObjects != null)
                        {
                            treeView += "<ul>";
                            foreach (MinorObjects min in mo.minorObjects)
                            {
                                treeView += "<li class='min'> " + min.MinorObject + " (Allocated Rs. " + FormatAmount(min.MinorObjectAmount) + ")-" + " (Balance Rs. " + FormatAmount(min.MinorObjectRemaining) + ")-" + " (Saving/ Un-Allocated Rs. " + FormatAmount(min.MinorObjectSaving) + ")-" + " (Surrendered Rs. " + FormatAmount(min.MinorObjectSurrender) + ")"; 
                                if (min.headOfAccounts != null)
                                {
                                    treeView += "<ul>";
                                    foreach (HeadOfAccounts hoa in min.headOfAccounts)
                                    {
                                        treeView += "<li class='hoa'><a href='BranchBills.aspx?HOA=" + hoa.HeadOfAccountId +"&FY="+ FinancialYearId + "'>" + hoa.HeadOfAccount + " (Allocated Rs. " + FormatAmount(hoa.AmountAllocated) + ")-" + " (Balance Rs. " + FormatAmount(hoa.RemainingAmount) + ")-" + " (Saving/ Un-Allocated Rs. " + FormatAmount(hoa.Savings) + ")-" + " (Surrendered Rs. " + FormatAmount(hoa.Surrendered) + ")</a><li>";
                                    }
                                    treeView += "</ul>";
                                }
                                treeView += "</li>";
                            }
                            treeView += "</ul>";
                        }
                        treeView += "</li>";
                    }
                    treeView += "</ul>";
                }
                treeView += "</li>";
            }
            treediv.InnerHtml= treeView;

        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
    }
}