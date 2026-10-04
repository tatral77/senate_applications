using Entities;
using MotionBIZ;
using MotionEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintMotionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate();
        }
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            int count = movers.Count();
            int chk = 0;
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += "Senator " + temp.MoverName;
                    if (chk != count)
                        moverslist += ",<br>";
                    chk++;

                }
            }
            return moverslist;
        }
        protected void Generate()
        {

            int MotionListId = Convert.ToInt32(Request.QueryString["MotionListId"]);
            ListEntity QL = new ListEntity();
            QL = new MotionBiz().GetMotionListById(MotionListId);
            //  ListNameLbl.Text = QL.ListName;
            List<MotionEnt> motions = new List<MotionEnt>();
            if (!String.IsNullOrEmpty(QL.ListMotions))
            {
                List<int> DefQuestions = QL.ListMotions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (DefQuestions != null)
                {
                    foreach (int dq in DefQuestions)
                        motions.Add(new MotionBiz().GetMotion(dq));
                }
            }

            MotionLV.DataSource = motions;
            MotionLV.DataBind();

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
        public string GetListSenatorName(int ListNo, string MoverName)
        {
            return "*QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }


    }
}