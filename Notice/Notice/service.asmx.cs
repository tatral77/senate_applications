using BIZ;
using Entities;
using LegisEntities;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;

namespace Notice
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName, a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSeatEmployeeName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetSeatMembersByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName, a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCurrentDivisionsByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Divisions> mems = new BillBiz().GetCurrentDivisionsByName(prefix);
            if (mems != null)
            {
                foreach (Divisions a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.Description, a.DivisionsId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetMinisters(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Ministers> mems = new BillBiz().GetMinistersByName(prefix);
            if (mems != null)
            {
                foreach (Ministers a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MinisterName, a.MinisterId));
                }
            }
            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetMemberMinisterByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new BillBiz().GetMemberMinisterByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName, a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetAllMembersByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new BillBiz().GetAllMemberByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName, a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }

    }
}
