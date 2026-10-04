using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class DuplicateQuestions : System.Web.UI.Page
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

            List<Questions> RevivedQuestions = new QuestionBiz().GetDuplicateQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            DuplicateLV.DataSource = RevivedQuestions;
            DuplicateLV.DataBind();

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
                return date.ToShortDateString();

        }
        protected string GetColour(int Checked)
        {
            if (Checked == 1)
                return "color:Green;";
            else
                return "color:red";
        }
        protected void RecoverBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int QuestionId = Convert.ToInt32(((Button)sender).CommandArgument);
            new QuestionBiz().RecoverDuplicateQuestion(QuestionId, userid);
            bindListView();

        }
    }
}