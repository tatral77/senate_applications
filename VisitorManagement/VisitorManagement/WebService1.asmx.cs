using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace VisitorManagement
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
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new Biz().GetEmployeeByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.MemberName, a.MemberId, a.PostId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetVisitorByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Visitors> mems = new Biz().GetVisitorByName(prefix);
            if (mems != null)
            {
                foreach (Visitors a in mems)
                {
                    empResult.Add(string.Format("{0}={1}={2}", a.VisitorName,  a.Cnic,a.Details));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCompanies(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Companies> companies = new Biz().GetCompanies(prefix);
            if (companies != null)
            {
                foreach (Companies a in companies)
                {
                    empResult.Add(string.Format("{0}={1}", a.CompanyId, a.CompanyName));
                }
            }
            return empResult.ToArray();

        }
    }
}
