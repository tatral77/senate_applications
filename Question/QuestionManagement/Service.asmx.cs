using Entities;
using QuestionBIZ;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;

namespace QuestionManagement
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "question.senate.gov.pk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetDivisionsByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Divisions> mems = new AdministrationBiz().GetDivisionsByName(prefix);
            if (mems != null)
            {
                foreach (Divisions a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.Description.Trim(), a.DivisionsId));
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
            List<Divisions> mems = new AdministrationBiz().GetCurrentDivisionsByName(prefix);
            if (mems != null)
            {
                foreach (Divisions a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.Description.Trim(), a.DivisionsId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }

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
                    empResult.Add(string.Format("{0}={1}", a.MemberName.Trim(), a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetMemberMinisterByName(string prefix)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMemberMinisterByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName.Trim(), a.MemberId));
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
            List<Member> mems = new QuestionBiz().GetAllMemberByName(prefix);
            if (mems != null)
            {
                foreach (Member a in mems)
                {
                    empResult.Add(string.Format("{0}={1}", a.MemberName.Trim(), a.MemberId));
                }
            }
            //empResult.Add("Masood");
            //empResult.Add("Malik");
            //empResult.Add("Masroor");

            return empResult.ToArray();

        }
     
    }
}

