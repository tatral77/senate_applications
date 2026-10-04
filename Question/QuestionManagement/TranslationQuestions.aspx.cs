using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace QuestionManagement
{
    public partial class TranslationQuestions : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(empName);
            foreach (Member a in mems)
            {
                empResult.Add(a.MemberName);
            }
            return empResult;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();

            }
        }

        private void bindListView()
        {
            List<Questions> Questions = new QuestionBiz().GetTranslationQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            List<Questions> TranslatedQuestions = new QuestionBiz().GetTranslatedQuestions(new AdministrationBiz().GetCurrentAssemblySessions());

            TranslatedLV.DataSource = TranslatedQuestions;
            TranslatedLV.DataBind();

            ListView1.DataSource = Questions;
            ListView1.DataBind();

            List<ResolutionEnt> Resolutions = new ResolutionBiz().GetTranslationResolutions(new AdministrationBiz().GetCurrentAssemblySessions());
            List<ResolutionEnt> TranslatedResolutions = new ResolutionBiz().GetTranslatedResolutions(new AdministrationBiz().GetCurrentAssemblySessions());

            TranslatedResLV.DataSource = TranslatedResolutions;
            TranslatedResLV.DataBind();

            ResolutionsLV.DataSource = Resolutions;
            ResolutionsLV.DataBind();


        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, "<[^>]*>| &nbsp;", "").Trim();
            if (txt.Length >= 350)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
            return text;

        }

        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToString();

        }



    }
}