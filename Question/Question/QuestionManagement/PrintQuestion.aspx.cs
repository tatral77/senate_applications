using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionId= Convert.ToInt32(Request.QueryString["questionsId"]);
            Questions qs = new QuestionBiz().GetQuestionById(questionId);
            if (qs != null)
            {
                SessionNoLbl.Text = qs.SessionNumber;
                if (qs.QuestionCategory != "")
                    CategoryLbl.Text = qs.QuestionCategory;
                DivisionLbl.Text = qs.Division;
                DiaryNoLbl.Text = qs.QuestionDiaryNo.ToString();
                NotiveDateLbl.Text = qs.QuestionDate.ToShortDateString();
                NoticeTimeLbl.Text = qs.QuestionDiaryTime.ToShortTimeString();
                StatusLBL.Text = qs.QuestionStatus;
                if (qs.QuestionCategoriesId == 1)
                    SenatorNameLbl.Text = "*" + qs.MoverName;
                else
                    SenatorNameLbl.Text = qs.MoverName;
                GroupNoLbl.Text = qs.MinistryGroup;
                QuestionLbl.Text = qs.QuestionText;
            }


        }
    }
}