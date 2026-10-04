using BUDBIZ;
using BUDENTITIES;
using FinBiz;
using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Finance
{
    /// <summary>
    /// Summary description for BudgetService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetBranchHeadOfAccountByName(string prefix, string BranchId,string CatId)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            SalaryStructure fs = new FinBIZ().GetSalaryStructureByCategory(Convert.ToInt32(CatId));
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetBranchHeadOfAccountsWithBudgetByFundCenter(prefix, fy.FinancialYearId, 10,fs.FundCenterId);
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
        public string[] GetBranchHeadOfAccountByName(string prefix, string BranchId)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetBranchHeadOfAccountsByName(prefix, fy.FinancialYearId, 10);
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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetMemberByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new FinBIZ().GetMemberByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}-{1}-{2}", a.MemberName + " (" + a.MemberSalCategory + ")", a.MemberId,a.MemberSalCategoryId ));
                }
            }
            return empResult.ToArray();

        }
    }
}
