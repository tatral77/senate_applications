using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Budget
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] GetEmployeeByName(string prefix)
        //{

        //    List<string> empResult = new List<string>();
        //    List<Visitor> senators = new List<Visitor>();
        //    List<Visitor> employees = new List<Visitor>();
        //    List<Visitor> allvisitors = new List<Visitor>();
        //    senators = new IPRBiz().GetSenatorByName(prefix);
        //    employees = new IPRBiz().GetEmployeeByName(prefix);
        //    if (senators != null)
        //    {
        //        foreach (Visitor b in senators)
        //        {
        //            empResult.Add(string.Format("{0}={1}={2}={3}", b.VisitorName, b.SystemUsersId, b.CategoryId, b.IsEmployee));
        //        }
        //    }
        //    if (employees != null)
        //    {
        //        foreach (Visitor a in employees)
        //        {
        //            empResult.Add(string.Format("{0}={1}={2}={3}", a.VisitorName, a.SystemUsersId, a.CategoryId, a.IsEmployee));
        //        }
        //    }
        //    return empResult.ToArray();
        //}
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetVendorByName(string prefix)
        {

            List<string> empResult = new List<string>();
            List<Vendors>  vendors = new BudgetBiz().GetVendorByName(prefix);

            if (vendors != null)
            {
                foreach (Vendors a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.Vendor + "(" + a.VendorNumber + ")", a.VendorId,a.VendorNumber));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetBranchVendorByName(string prefix,string BranchId)
        {

            List<string> empResult = new List<string>();
            List<Vendors> vendors = new BudgetBiz().GetBranchVendorByName(Convert.ToInt32(BranchId),prefix);

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
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetHeadOfAccountsByName(prefix,fy.FinancialYearId);

            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId, a.Savings));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetBranchHeadOfAccountByName(string prefix,int BranchId)
        {
            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetBranchHeadOfAccountsByName(prefix, fy.FinancialYearId,BranchId);

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
        public string[] GetEmployeeHeadOfAccountByName(string prefix,int EmpId)
        {

            FinancialYears fy = new BudgetBiz().GetCurrentFinancialYear();
            List<string> empResult = new List<string>();
            List<HeadOfAccounts> vendors = new BudgetBiz().GetEmployeeHeadOfAccountByName(prefix, fy.FinancialYearId,EmpId,9);

            if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId, a.Savings));
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
            List<HeadOfAccounts> vendors = new BudgetBiz().GetFromHeadOfAccountsWithBudget(prefix,fy.FinancialYearId);
           if (vendors != null)
            {
                foreach (HeadOfAccounts a in vendors)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId,a.Savings));
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
                    empResult.Add(string.Format("{0}={1}={2}", a.HeadOfAccount, a.HeadOfAccountId, a.Savings));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Employees> items = new BudgetBiz().GetEmployeeByName(prefix);
            if (items != null)
            {
                foreach (Employees a in items)
                {
                    empResult.Add(string.Format("{0}-{1}-{2}", a.EmployeeName, a.EmployeeId, a.VendorNumber));
                }
            }
            return empResult.ToArray();
        }


    }
}
