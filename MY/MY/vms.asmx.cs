using Entities;
using MyBIZ;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace MY
{
    /// <summary>
    /// Summary description for vms
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class vms : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetVisitorByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Visitors> items = new vmsBiz().GetVisitorByName(prefix);
            if (items != null)
            {
                foreach (Visitors a in items)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.VisitorName, a.Cnic, a.Details));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetVisitorByCNIC(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Visitors> items = new vmsBiz().GetVisitorByCNIC(prefix);
            if (items != null)
            {
                foreach (Visitors a in items)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.VisitorName, a.Cnic,a.Details));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCompanies(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Companies> items = new vmsBiz().GetCompanies(prefix);
            if (items != null)
            {
                foreach (Companies a in items)
                {
                    empResult.Add(string.Format("{0}={1}", a.CompanyId, a.CompanyName));
                }
            }
            return empResult.ToArray();
        }

    }
}
