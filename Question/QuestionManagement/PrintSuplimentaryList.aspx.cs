using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintSuplimentaryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate();
        }
        protected void Generate()
        {

            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            SuplementaryListEnt QL = new SuplementaryListEnt();
            QL = new QuestionBiz().GetQuestionSupList(QuestionListId);
            ListNameLbl.Text = QL.ListName;
            List<ListQuestion> questionslist = new List<ListQuestion>();
            if (!String.IsNullOrEmpty(QL.Questions))
            {
                List<int> questions = QL.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (questions != null)
                {
                    foreach (int qs in questions)
                        questionslist.Add(new QuestionBiz().GetListQuestion(qs));
                }
            }
            ListLV.DataSource = questionslist;
            ListLV.DataBind();

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
            return "*(DEF.) QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetListSenatorName(int ListNo, char supno, string MoverName)
        {
            return "*QUESTION NO. " + ListNo + "-" + supno + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }
    }
}