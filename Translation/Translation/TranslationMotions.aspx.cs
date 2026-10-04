using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Translation
{
    public partial class TranslationMotions : System.Web.UI.Page
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
            List<Motion> Motions = new TranslationBiz().GetTranslationMotions(new TranslationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Motions;
            ListView1.DataBind();

            List<Motion> TranslatedMotions = new TranslationBiz().GetTranslatedMotions(new TranslationBiz().GetCurrentAssemblySessions());

            TranslatedLV.DataSource = TranslatedMotions;
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