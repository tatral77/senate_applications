using BIZ;
using Entities;
using System;

namespace Translation
{
    public partial class ResolutionDetail : System.Web.UI.Page
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
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionsId"]);
            Resolution Resolution = new TranslationBiz().GetResolution(ResolutionId);
            QuestionIdLabel.Text = "Resolution ID : " + Resolution.ResolutionsId;

            QTxt.Value = Resolution.Description;
            if (!string.IsNullOrEmpty(Resolution.UrduText))
            {
                UrduTxt.Value = Resolution.UrduText;
                urdudiv.Visible = true;
            }
            string file = Resolution.ResolutionFile;
            if (!string.IsNullOrEmpty(file))
            {
                if (file.Contains("pdf"))
                {
                    pdfDiv.InnerHtml = "<object data=\"" + file + "\" type=\"application/pdf\" style=\"width:100%\" height=\"700\">\r\n alt:<a href=\"" + file + "\">View File</a>\r\n  </object>";
                    pdfDiv.Visible = true;
                    urdudiv.Visible = false;
                }
                else
                {
                    HyperLink1.NavigateUrl = file;
                    HyperLink1.Text = "View File";
                    imgdiv.Visible = true;
                    QuestionImage.ImageUrl = file;
                    urdudiv.Visible = false;
                }
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
                int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionsId"]);
                int saved = new TranslationBiz().SaveResolutionTranslation(ResolutionId, QTxt.Value);
            }
        }
        protected void FinalizeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QTxt.Value))
            {
                int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionsId"]);
                int saved = new TranslationBiz().FinalizeResolutionTranslation(ResolutionId, QTxt.Value);
            }
        }
    }
}