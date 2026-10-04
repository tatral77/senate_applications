using Entities;
using QuestionBIZ;
using System;

namespace QuestionManagement
{
    public partial class PrintOriginalQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int questionId = Convert.ToInt32(Request.QueryString["questionsId"]);
                Questions qs = new QuestionBiz().GetQuestionById(questionId);
                if (qs != null)
                {
                    SessionNoLbl.Text = qs.SessionNumber;
                    if (!String.IsNullOrEmpty(qs.QuestionCategory))
                        CategoryLbl.Text = qs.QuestionCategory.ToUpper();
                    if (!String.IsNullOrEmpty(qs.Division))
                        DivisionLbl.Text = qs.Division.ToUpper();
                    DiaryNoLbl.Text = qs.QuestionDiaryNo.ToString();
                    QID.Text = qs.QuestionsId.ToString();
                    NotiveDateLbl.Text = qs.NoticeDiaryDate.ToShortDateString();
                    NoticeTimeLbl.Text = " at " + qs.NoticeDiaryTime.ToShortTimeString();
                    if (!String.IsNullOrEmpty(qs.QuestionStatus))
                        StatusLBL.Text = qs.QuestionStatus.ToUpper();
                    if (qs.QuestionCategoriesId == 1)
                        SenatorNameLbl.Text = "*SENATOR " + qs.MoverName.ToUpper();
                    else
                        SenatorNameLbl.Text = "SENATOR " + qs.MoverName.ToUpper();
                    if (qs.QuestionCategoriesId == 1)
                        GroupNoLbl.Text = qs.GroupSequence.ToString();
                    if (qs.QuestionCategoriesId == 2)
                        GroupNoLbl.Text = qs.UnstarDesc;
                    QuestionLbl.Text = qs.Subject;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<strong>Some error has occoured while printing.<br> Question data may be incomplete.</strong>");
            }


        }
    }
}