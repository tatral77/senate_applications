using BIZ;
using Entities;
using System;

namespace Notice
{
    public partial class PrintQuestion : System.Web.UI.Page
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
                  
                    DiaryNoLbl.Text = qs.QuestionsId.ToString();
                 
                    NotiveDateLbl.Text = qs.NoticeDiaryDate.ToShortDateString();
                    NoticeTimeLbl.Text = " at " + qs.NoticeDiaryTime.ToShortTimeString();
                                      if (qs.QuestionCategoriesId == 1)
                        SenatorNameLbl.Text = "*SENATOR " + qs.MoverName.ToUpper();
                    else
                        SenatorNameLbl.Text = "SENATOR " + qs.MoverName.ToUpper();
                    if (qs.QuestionCategoriesId == 1)
                        DeviceLbl.Text = (qs.DeviceId==1)?"Web":"Mobile App";
                    QuestionLbl.Text = qs.QuestionText;
                }
            }
            catch(Exception ex)
            {
                throw ex;
                Response.Write("<strong>Some error has occoured while printing.<br> Question data may be incomplete.</strong>");

            }


        }
    }
}