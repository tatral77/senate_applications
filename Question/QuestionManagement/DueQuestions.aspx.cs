using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace QuestionManagement
{
    // Questions that have waited 8 clear working days (Saturdays and Sundays excluded) and are still
    // Under Process or Under Correspondence. Same columns as the Search Question page.
    public partial class DueQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            DateTime today = DateTime.Today;
            DateTime latest = DueQuestionsBiz.LatestReadyNoticeDate(today);
            try
            {
                int sessionId = new AdministrationBiz().GetCurrentAssemblySessions();
                DueQuestionsBiz biz = new DueQuestionsBiz();
                List<Questions> questions = biz.GetList(sessionId, today);

                ListView1.DataSource = questions;
                ListView1.DataBind();

                int count = questions == null ? 0 : questions.Count;
                CountLit.Text = count.ToString();
                RuleLit.Text = Server.HtmlEncode(
                    (count == 1 ? "question" : "questions") + " in the current session, notice received on or before " +
                    latest.ToString("dd MMM yyyy") + " (" + DueQuestionsBiz.ClearDays +
                    " clear days, Saturdays and Sundays not counted), still Under Process or Under Correspondence.");
            }
            catch (Exception ex)
            {
                CountLit.Text = "-";
                RuleLit.Text = "";
                ErrorLbl.Text = "The list could not be loaded: " + Server.HtmlEncode(ex.Message);
                ErrorLbl.Visible = true;
            }
        }

        public string GetLink(string questionId)
        {
            string link = "~/QuestionDetails.aspx?QuestionsId=" + questionId;
            if (Request.Cookies["userInfo"] != null)
            {
                string role = Convert.ToString(Request.Cookies["userInfo"]["role"]);
                if (role.Equals("SO"))
                    link = "~/QuestionDetailsRest.aspx?QuestionsId=" + questionId;
            }
            return link;
        }

        public string GetListNo(int listNo, string supNo)
        {
            return supNo != "Z" ? listNo + "-" + supNo : listNo.ToString();
        }

        // Plain-text preview of the question (the stored text is HTML from the editor).
        public string GetMinText(string html)
        {
            string text = Regex.Replace(html ?? "", @"<[^>]+>", " ");
            text = Regex.Replace(HttpUtility.HtmlDecode(text), @"\s+", " ").Trim();
            if (text.Length > 350) text = text.Substring(0, 350).Trim() + "...";
            return Server.HtmlEncode(text);
        }

        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }

        public string GetDate(DateTime date)
        {
            return date < Convert.ToDateTime("01/01/1900") ? "" : date.ToShortDateString();
        }

        public string GetGroupName(int groupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(groupId);
            return gp != null ? gp.Description : "Not Mentioned";
        }
    }
}
