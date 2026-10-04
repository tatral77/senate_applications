using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace QuestionManagement
{
    public partial class NoticeQuestions : System.Web.UI.Page
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
            int sessionId = new AdministrationBiz().GetCurrentAssemblySessions();
            List<Questions> Questions = new QuestionBiz().GetNoticeQuestions(sessionId);
            ListView1.DataSource = Questions;
            ListView1.DataBind();

            int total = Questions == null ? 0 : Questions.Count;
            int opened = Questions == null ? 0 : Questions.FindAll(q => q.Checked == 1).Count;
            TotalLit.Text = total.ToString();
            OpenedLit.Text = opened.ToString();
            NewLit.Text = (total - opened).ToString();
            try { SessionLit.Text = Server.HtmlEncode(new DashboardBiz().GetSessionNumber(sessionId)); }
            catch { SessionLit.Text = ""; }

            //List<Questions> RevivedQuestions = new QuestionBiz().GetRevivedQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            //RevivedQuestionsLV.DataSource = RevivedQuestions;
            //RevivedQuestionsLV.DataBind();

            //List<Questions> DuplicateQuestions = new QuestionBiz().GetDuplicateQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            //DuplicateLV.DataSource = DuplicateQuestions;
            //DuplicateLV.DataBind();

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
        // A question is new until someone opens it (opening marks it as checked).
        protected bool IsNew(int Checked)
        {
            return Checked != 1;
        }

        // Plain-text preview of the question. Many notices arrive as an image or PDF with no typed text yet.
        protected string Preview(string html, string file, int questionId)
        {
            string url = ResolveUrl("~/NoticeQuestionDetails.aspx?QuestionsId=" + questionId);
            string text = Regex.Replace(html ?? "", "<[^>]*>", " ");
            text = Regex.Replace(HttpUtility.HtmlDecode(text), @"\s+", " ").Trim();
            bool hasFile = !string.IsNullOrWhiteSpace(file);
            string clip = hasFile ? "<span class='glyphicon glyphicon-paperclip nq-clip' title='File attached'></span>" : "";
            if (text.Length == 0)
                return "<a href='" + url + "' target='_blank'>" + clip + "<span class='nq-nofile'>" +
                       (hasFile ? "Text not typed yet - open to view the attached file" : "No text and no file") + "</span></a>";
            if (text.Length > 260) text = text.Substring(0, 260).Trim() + "...";
            return "<a href='" + url + "' target='_blank'>" + clip + Server.HtmlEncode(text) + "</a>";
        }

        protected string GetColour(int Checked)
        {
            if (Checked == 1)
                return "color:Green;";
            else
                return "color:red";
        }

        protected void RevivedQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RevivedQuestions.aspx");
        }

        protected void DuplicateQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DuplicateQuestions.aspx");
        }
    }
}