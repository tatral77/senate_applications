using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QuestionManagement
{
    public partial class TranslationResolutions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();

            }
        }

        private void bindListView()
        {
            List<ResolutionEnt> Resolutions = new ResolutionBiz().GetTranslationResolutions(new AdministrationBiz().GetCurrentAssemblySessions());
            List<ResolutionEnt> TranslatedResolutions = new ResolutionBiz().GetTranslatedResolutions(new AdministrationBiz().GetCurrentAssemblySessions());

            TranslatedLV.DataSource = TranslatedResolutions;
            TranslatedLV.DataBind();

            ListView1.DataSource = Resolutions;
            ListView1.DataBind();


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