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
    public class AutomationService : System.Web.Services.WebService
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
                    empResult.Add(string.Format("{0}={1}={2}", a.MemberName, a.MemberId,a.PostId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }

      
    }
}
