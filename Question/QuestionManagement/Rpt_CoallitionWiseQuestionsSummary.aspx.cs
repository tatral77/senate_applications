using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class Rpt_CoallitionWiseQuestionsSummary : System.Web.UI.Page
    {
       


        string PartyRec = "";
        string SessionRec = "";
        string CoalitionRec = "";
        int i = 0;
        int j = 0;
        int k = 0;
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
            List<Coalition> coalitions = new AdministrationBiz().GetCoalitions();
            int fromsession = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
            int tosession = Convert.ToInt32(ToAssemblySessionDDL.SelectedItem.Value);
            List<AssemblySessions> assemblySessions = new List<AssemblySessions>();
            for (int i = fromsession; i <= tosession; i++)
            {
                AssemblySessions assemblySession = new AdministrationBiz().GetAssemblySession(i);
                assemblySessions.Add(assemblySession);
            }
                List<QuestionSummary> AllQuestions = new QuestionBiz().GetCoalitionNoOfQuestions(fromsession, tosession);
            List<PoliticalParty> politicalParties = new AdministrationBiz().GetPoliticalPartiesOrderByCoalition();
            //politicalParties=politicalParties.OrderBy()
            List<QuestionStatuses> questionStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            //
            List<QuestionSummary> QuestionsSummary = new List<QuestionSummary>();
            foreach (Coalition pp in coalitions)
            {
                foreach (AssemblySessions asession in assemblySessions)
                {
                    foreach (QuestionStatuses qs in questionStatuses)
                    {

                        QuestionSummary questionSummary = new QuestionSummary();
                        int TotalQuestions = AllQuestions.Where(p => p.CoalitionId == pp.CoalitionId && p.StatusId == qs.QuestionStatusesId &&p.SenateSessionId==asession.AssemblySessionsId).Count();// AllQuestions.Where(t => t.PoliticalPartyId == pp.PartyId && t.StatusId==qs.QuestionStatusesId).Count();//AllQuestions.GroupBy(p => p.PoliticalPartyId).Select(g => g.First()).ToList();
                        questionSummary.CoalitionId = pp.CoalitionId;
                        questionSummary.Coalition = pp.CoalitionDesc;
                        questionSummary.StatusId = qs.QuestionStatusesId;
                        questionSummary.SenateSessionId = asession.AssemblySessionsId;
                        questionSummary.SenateSession = asession.SessionNumber;
                        questionSummary.Status = qs.Description;
                        questionSummary.Questions = TotalQuestions;
                        QuestionsSummary.Add(questionSummary);
                    }
                }
            }

            
            //if (QSummary != null)
            //{
            //    TotalLabelLbl.Visible = true;
            //    int questions = QSummary.Select(t => t.Questions).Sum();
            //    TotalQuestionsLbl.Text = questions.ToString();

            //    //  var categoryCounts =
            //    //from p in QSummary
            //    //group p by p.Status into g
            //    //select new { Category = g.Key, ProductCount = g.Count() };
            //    // var ordered = categoryCounts.OrderBy(x => x.Category);
               ListView1.DataSource = QuestionsSummary;
               ListView1.DataBind();
            //}
            //else
            //    TotalLabelLbl.Visible = false;


        }
        public string AddCoalitionGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("Coalition"));

            if (currentSemesterValue != CoalitionRec)
            {
                CoalitionRec = currentSemesterValue;
                if (i != 0)
                {


                }
                i++;
                return String.Format("<tr class=group><td colspan=10 style='font-size:12pt!important;background-color:#D3D3D3'><b>" + Eval("Coalition") + "</b></td><tr>");

            }
            else return String.Empty;
        }
        public string AddSessionGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("SenateSession"));

            if (currentSemesterValue != SessionRec)
            {
                SessionRec = currentSemesterValue;
                if (k != 0)
                {


                }
                k++;
                return String.Format("<tr class=group><td colspan=10 style='font-size:12pt!important;background-color:#D3D3D3'><b>Session " + Eval("SenateSession") + "</b></td><tr>");

            }
            else return String.Empty;
        }
        public string AddPartyGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("PoliticalParty"));

            if (currentSemesterValue != PartyRec)
            {
                PartyRec = currentSemesterValue;
                if (j != 0)
                {


                }
                j++;
                return String.Format("<tr class=group><td colspan=10 style='font-size:12pt!important;background-color:#D3D3D3'><b>" + Eval("PoliticalParty") + "</b></td><tr>");

            }
            else return String.Empty;
        }
    }
}