using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintList : System.Web.UI.Page
    {
        private class MinistryQuestions
        {
            public int MinistryId { get; set; }
            public string MinistryName { get; set; }
            public int Questions { get; set; }
        }
        int Category = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate();
        }
        protected void Generate()
        {
            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            string DeferedQuestions = null;
            QuestList QuestionsList = new QuestList();
            QuestionsList = new QuestionBiz().GetQuestionList(QuestionListId);

            Category = QuestionsList.CategoryId;
            if (Category == 2)
                Label3.Text = "(UN-STARED QUESTIONS)";
            else
                Label3.Text = "(STARED QUESTIONS)";

            ListNameLbl.Text = QuestionsList.ListName;
            //Deffered Questions
            List<ListQuestion> DefferedQusestionsList = new List<ListQuestion>();
            if (!String.IsNullOrEmpty(QuestionsList.DefQuestions))
            {
                QuestionsList.DefQuestions = QuestionsList.DefQuestions.TrimEnd(',');
                List<int> DefQuestions = QuestionsList.DefQuestions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (DefQuestions != null)
                {
                    foreach (int dq in DefQuestions)
                        DefferedQusestionsList.Add(new QuestionBiz().GetListQuestion(dq));
                }
            }
            if (DefferedQusestionsList != null)
            {
                foreach (ListQuestion lqs in DefferedQusestionsList)
                    DeferedQuestions = DeferedQuestions + lqs.ListNo + ",";
                DeferedQuestionsLbl.Text = DeferedQuestions;
            }

            //Admitted Questions
            List<ListQuestion> questionslist = new List<ListQuestion>();
            if (!String.IsNullOrEmpty(QuestionsList.Questions))
            {
                QuestionsList.Questions = QuestionsList.Questions.TrimEnd(',');
                List<int> Questions = QuestionsList.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (Questions != null)
                {
                    foreach (int qs in Questions)
                        questionslist.Add(new QuestionBiz().GetListQuestion(qs));
                }
            }
            List<ListQuestion> AllQuestions = new List<ListQuestion>();
            AllQuestions.AddRange(DefferedQusestionsList);
            AllQuestions.AddRange(questionslist);
            List<ListQuestion> Divisions= AllQuestions.GroupBy(a => a.DivisionId).Select(a => a.FirstOrDefault()).ToList();
            List<MinistryQuestions> ministryQuestions = new List<MinistryQuestions>();
            int TotalQuestions = 0;
            foreach(ListQuestion lq in Divisions)
            {
                MinistryQuestions ministryQuestion = new MinistryQuestions();
                ministryQuestion.MinistryId = lq.DivisionId;
                ministryQuestion.MinistryName = lq.Division;
                ministryQuestion.Questions = AllQuestions.Where(e => e.DivisionId == lq.DivisionId).Count();
                TotalQuestions = TotalQuestions + ministryQuestion.Questions;
                ministryQuestions.Add(ministryQuestion);
            }

            DivisionsLV.DataSource = ministryQuestions.OrderBy(o => o.MinistryName).ToList();
            DivisionsLV.DataBind();
            TotalQuestionsLbl.Text = FormatQuestions(TotalQuestions);
            DeferLV.DataSource = DefferedQusestionsList;
            DeferLV.DataBind();
            ListLV.DataSource = questionslist;
            ListLV.DataBind();

        }
        public string FormatQuestions(int questions)
        {
            if (questions < 10)
                return "0" + questions.ToString();
            else
                return questions.ToString();
        }
        public string GetGroupName(int GroupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(GroupId);
            if (gp != null)
                return gp.Description;
            else
                return "Not Mentioned";

        }
        public string GetSessionName(int AssemblySessionId)
        {
            AssemblySessions asession = new AdministrationBiz().GetAssemblySession(AssemblySessionId);
            if (asession != null)
                return asession.SessionNumber.ToString();
            else
                return "Not Mentioned";

        }
        public string GetDefSenatorName(int ListNo, string MoverName)
        {
            if (Category == 2)
                return "(DEF.) QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
            else
                return "*(DEF.) QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetListSenatorName(int ListNo, string MoverName)
        {
            if (Category == 2)

                return "QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";

            else
                return "*QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";


        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }

    }
}
