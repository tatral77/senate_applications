using BIZ;
using Entities;
using ManBIZ;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Translation
{
    public partial class UserQuestions : System.Web.UI.Page
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
            int userid = 0;
            User user = null;
            List<Questions> Questions = null;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
                user = new ManBiz().GetUser(userid);
            }
            if (user.Role.Equals("Translator"))
            {
                Questions = new TranslationBiz().GetTranslationQuestionsByUser(userid);
            }
            else
            {
                Questions = new TranslationBiz().GetTranslationQuestions();
            }
            ListView1.DataSource = Questions;
            ListView1.DataBind();

            List<Questions> TranslatedQuestions = new TranslationBiz().GetTranslatedQuestionsByUser(userid);

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