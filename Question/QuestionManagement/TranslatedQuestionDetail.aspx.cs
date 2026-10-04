using Entities;
using QuestionBIZ;
using System;
using System.Web;

namespace QuestionManagement
{
    public partial class TranslatedQuestionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                //   PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                BindQuestion();
            }


        }
        public void BindQuestion()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Questions question = new QuestionBiz().GetQuestionByIdMin(QuestionId);
            QuestionIdLbl.Text = "Question ID: " + question.QuestionsId;
            QTxt.Value = question.QuestionText;
            UrduTxt.Value = question.UrduText;
            string file = question.QuestionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file;
                HyperLink1.Text = "View File";
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }
            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;

        }

        protected void ApprovedBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            new QuestionBiz().ApproveTranslation(QuestionId, userid);
            Response.Redirect("~/QuestionDetails.aspx?QuestionsId=" + QuestionId);

        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            if (!string.IsNullOrEmpty(UrduTxt.Value))
            {
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                new QuestionBiz().SendForTranslation(QuestionId, userid);
                UrduLbl.Visible = false;
                SuccessLbl.InnerText = "Question sent for translation";
                SuccessLbl.Visible = true;
            }
            else
            {
                UrduLbl.Text = "No text found for translation";
                UrduLbl.Visible = true;
            }
        }
    }
}