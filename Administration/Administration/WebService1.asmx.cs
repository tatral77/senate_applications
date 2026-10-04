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
                    empResult.Add(string.Format("{0}-{1}", a.ItemName, a.ItemId));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetItemNameNotAssigned(string prefix, string Id)
        {
            List<string> empResult = new List<string>();
            List<Items> items = new AdminBIZ().GetItemNameNotAssigned(prefix, Convert.ToInt32(Id));
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
        public string GetThresholdLevel()
        {
            List<Items> items = new AdminBIZ().GetThresholdItems();
            if (items != null)
                return items.Count().ToString();
            else
                return "";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetItemsNotInRateList(string prefix, string Id)        
        {
            List<string> empResult = new List<string>();
            List<Items> items = new AdminBIZ().GetItemsNotInRateList(prefix, Convert.ToInt32(Id));
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
        public string[] GetItemsNotInPurchase(string prefix, string Id)
        {
            List<string> empResult = new List<string>();
            List<Items> items = new AdminBIZ().GetItemsNotInPurchase(prefix, Convert.ToInt32(Id));
            if (items != null)
            {
                foreach (Items a in items)
                {
                    empResult.Add(string.Format("{0}-{1}-{2}-{3}", a.ItemId, a.ItemName,a.Price,a.PriceUnit));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Employees> items = new AdminBIZ().GetEmployeeByName(prefix);
            if (items != null)
            {
                foreach (Employees a in items)
                {
                    empResult.Add(string.Format("{0}-{1}-{2}", a.EmployeeName, a.EmployeeId, a.PostId));
                }
            }
            return empResult.ToArray();
        }




    }
}
