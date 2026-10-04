using BIZ;
using Entities;
using System;

namespace Translation
{
    public partial class MotionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                //   PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                Bind();
            }

        }
        [System.Web.Services.WebMethod]
        public void Bind()
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionsId"]);
            Motion Motion = new TranslationBiz().GetMotion(MotionId);
            QuestionIdLabel.Text = "Motion ID : " + Motion.MotionsId;

            QTxt.Value = Motion.Description;
            if (!string.IsNullOrEmpty(Motion.UrduText))
            {
                UrduTxt.Value = Motion.UrduText;
                urdudiv.Visible = true;
            }
            string file = Motion.MotionFile;
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
                urdudiv.Visible = true;

            }
            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QTxt.Value))
            {
                int MotionId = Convert.ToInt32(Request.QueryString["MotionsId"]);
                int saved = new TranslationBiz().SaveMotionTranslation(MotionId, QTxt.Value);
            }
        }
        protected void FinalizeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QTxt.Value))
            {
                int MotionId = Convert.ToInt32(Request.QueryString["MotionsId"]);
                int saved = new TranslationBiz().FinalizeMotionTranslation(MotionId, QTxt.Value);
            }
        }
    }
}