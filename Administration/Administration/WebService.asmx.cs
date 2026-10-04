using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Administration
{
    /// <summary>
    /// Summary description for AutomationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AutomationService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetItemName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Items> items = new AdminBIZ().GetItemByName(prefix);
            if (items != null)
            {
                foreach (Items a in items)
                {
                    empResult.Add(string.Format("{0}-{1}", a.ItemId, a.ItemName));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        public string GetThresholdLevel()
        {
            List<Items> items = new AdminBIZ().GetThresholdItems();
            if (items != null)
                return items.Count().ToString();
            else
                return "1";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetItemNameNotAssigned(string prefix, string Id)
        {
            List<string> empResult = new List<string>();
            List<Items> items = new AdminBIZ().GetItemNameNotAssigned(prefix,Convert.ToInt32(Id));
            if (items != null)
            {
                foreach (Items a in items)
                {
                    empResult.Add(string.Format("{0}-{1}", a.ItemId, a.ItemName));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Employees> items = new AdminBIZ().GetEmployeeByName(prefix);
            if (items != null)
            {
                foreach (Employees a in items)
                {
                    empResult.Add(string.Format("{0}-{1}-{2}", a.EmployeeId, a.EmployeeName,a.PostId));
                }
            }
            return empResult.ToArray();
        }
    }
}
