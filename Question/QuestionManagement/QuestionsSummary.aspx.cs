using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class QuestionsSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindListView1();
                bindFields();
            }

        }
        private void bindFields()
        {
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                FromAssemblySessionDDL.Items.Add(li);
                ToAssemblySessionDDL.Items.Add(li);
            }
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            int fromsession = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
            int tosession = Convert.ToInt32(ToAssemblySessionDDL.SelectedItem.Value);
            List<QuestionSummary> QSummary = new QuestionBiz().GetStatusNoOfQuestions(fromsession, tosession);
            List<ListQuestion> questionsLists = new QuestionBiz().GetAllDeferedQuestions(tosession);
            if (QSummary != null)
            {
                TotalLabelLbl.Visible = true;
                int questions = QSummary.Select(t => t.Questions).Sum();
                TotalQuestionsLbl.Text = questions.ToString();
                foreach(QuestionSummary q in QSummary)
                {
                    if(q.Status.Equals("Deferred"))
                        if(questionsLists!=null)
                        q.Questions=questionsLists.Count();
                }
                //  var categoryCounts =
                //from p in QSummary
                //group p by p.Status into g
                //select new { Category = g.Key, ProductCount = g.Count() };
                // var ordered = categoryCounts.OrderBy(x => x.Category);
                ListView1.DataSource = QSummary;
                ListView1.DataBind();
            }
            else
                TotalLabelLbl.Visible = false;


        }
    }
}