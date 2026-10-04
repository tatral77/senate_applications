using BIZ;
using Entities;
using System;

namespace Translation
{
    public partial class QuestionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                //   PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                BindQuestion();
            }

        }
        [System.Web.Services.WebMethod]
        public void BindQuestion()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Questions question = new TranslationBiz().GetQuestionByIdMin(QuestionId);
            QuestionIdLabel.Text = "Question ID : " + question.QuestionsId;

            QTxt.Value = question.QuestionText;
            if (!string.IsNullOrEmpty(question.UrduText))
            {
                UrduTxt.Value = question.UrduText;
                urdudiv.Visible = true;
            }
            string file = question.QuestionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file;
                HyperLink1.Text = "View File";
                imgdiv.Visible = true;
                QuestionImage.ImageUrl = file;
                urdudiv.Visible = false;
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }
            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QTxt.Value))
            {
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                int saved = new TranslationBiz().SaveQuestionTranslation(QuestionId, QTxt.Value);
            }
        }
        protected void FinalizeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QTxt.Value))
            {
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                int saved = new TranslationBiz().FinalizeQuestionTranslation(QuestionId, QTxt.Value);
            }
        }
    }
}