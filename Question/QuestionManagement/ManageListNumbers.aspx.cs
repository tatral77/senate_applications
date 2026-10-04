using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
namespace QuestionManagement
{
    public partial class ManageListNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RemoveBtn_Click(object sender, EventArgs e)
        {
            List<int> questions = QuestionId.Text.Split(',').Select(s => Convert.ToInt32(s)).ToList();
            string deffered = null;
            foreach (int a in questions)
            {
                Questions question = new QuestionBiz().GetQuestionById(a);
                if (question.QuestionStatusId == 4 || question.QuestionStatusId == 15)
                    deffered += a.ToString() + ",";

            }
            if (!String.IsNullOrEmpty(deffered))
            {
                deffered = "Following Deffered or Replied Questions can not be removed from lists <br/> " + deffered;
                defferederror.Text = deffered;
            }
            else
            {
                string query = "Update questions set list_no=0,sup_no='Z' where questions_id in (" + QuestionId.Text + ")";
                new QuestionBiz().RemoveListNumbers(query);
                defferederror.Text = "";
                success.Text = "Questions removed from list successfully";
            }

        }
    }
}