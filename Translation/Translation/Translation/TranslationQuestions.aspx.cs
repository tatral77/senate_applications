using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Translation
{
    public partial class TranslationQuestions : System.Web.UI.Page
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
            List<Questions> Questions = new TranslationBiz().GetTranslationQuestions(new TranslationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Questions;
            ListView1.DataBind();

            List<Questions> TranslatedQuestions = new TranslationBiz().GetTranslatedQuestions(new TranslationBiz().GetCurrentAssemblySessions());

            TranslatedLV.DataSource = TranslatedQuestions;
            TranslatedLV.DataBind();


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