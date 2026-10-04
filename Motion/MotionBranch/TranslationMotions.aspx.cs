using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
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
            List<MotionEnt> Motions = new MotionBiz().GetTranslationMotions(new AdministrationBiz().GetCurrentAssemblySessions());
            List<MotionEnt> TranslatedMotions = new MotionBiz().GetTranslatedMotions(new AdministrationBiz().GetCurrentAssemblySessions());

            TranslatedLV.DataSource = TranslatedMotions;
            TranslatedLV.DataBind();

            ListView1.DataSource = Motions;
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