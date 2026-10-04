using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Administration
{
    /// <summary>
    /// Summary description for BudgetService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BudgetService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetBranchHeadOfAccountByName(string prefix, string BranchId)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetBranchHeadOfAccountsWithBudget(prefix, fy.FinancialYearId, 16);
            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}", a.HeadOfAccount, a.HeadOfAccountId));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetBranchVendorByName(string prefix, string BranchId)
        {

            List<string> empResult = new List<string>();
            List<Vendors> vendors = new BudgetBiz().GetBranchVendorByName(Convert.ToInt32(BranchId), prefix);

            if (vendors != null)
            {
                foreach (Vendors a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.Vendor + "(" + a.VendorNumber + ")", a.VendorId, a.VendorNumber));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetHeadOfAccountByName(string prefix)
        {

            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetHeadOfAccountsByName(prefix);

            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}", a.HeadOfAccount, a.HeadOfAccountId));
                }
            }
            return empResult.ToArray();
        }
       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetFromHeadOfAccountsWithBudget(string prefix)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetFromHeadOfAccountsWithBudget(prefix, fy.FinancialYearId);
            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId, a.RemainingAmount));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetToHeadOfAccountsWithBudget(string prefix)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetToHeadOfAccountsWithBudget(prefix, fy.FinancialYearId);
            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId, a.RemainingAmount));
                }
            }
            return empResult.ToArray();
        }
    }
}
