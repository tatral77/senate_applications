using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class Rpt_GroupMinistryMeberSummary : System.Web.UI.Page
    {
        string lastrec = "";
        string ministry = "";
        int i = 0;
        int j = 0;
        GroupSummaryReport sumSummary = new GroupSummaryReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSessionCB();


            }
        }
        public void BindSessionCB()
        {
            List<AssemblySessions> AssSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions div in AssSessions)
            {
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(div.AssemblySessionsId);
                Temp.Text = Convert.ToString(div.SessionNumber);
                SessionDDL.Items.Add(Temp);
                ToSessionDDL.Items.Add(Temp);
            }
        }
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("Group"));

            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                if (i != 0)
                {


                }
                i++;
                return String.Format("<tr class='group line'><td colspan=10 style='font-size:12pt!important;text-align:center;background-color:#D3D3D3'><b>" + Eval("Group") + "</b></td><tr>");

            }
            else return String.Empty;
        }
        protected string AddMinistryGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("Ministry"));

            if (currentSemesterValue != ministry)
            {
                ministry = currentSemesterValue;
                if (i != 0)
                {


                }
                i++;
                return String.Format("<tr class=group><td colspan=10 style='font-size:12pt!important;background-color:#D3D3D3'><b>" + Eval("Ministry") + "</b></td><tr>");

            }
            else return String.Empty;
        }
        protected string AddSumRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("Group"));

            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;

                i++;

                return String.Format("<tr class=group><td colspan=10><b>" + Eval("Group") + "</b></td><tr>");

            }
            else return String.Empty;
        }
        protected void Generate_Click(object sender, EventArgs e)
        {

            int fromSessions = Convert.ToInt32(SessionDDL.SelectedValue);
            int toSession = Convert.ToInt32(ToSessionDDL.SelectedValue);
            heading.InnerText = "MINISTRY WISE STATEMENT OF ADMITTED STARRED QUESTIONS FOR";
            sesionNumber.InnerText = "Session Number : " + SessionDDL.SelectedItem.Text + " To " + ToSessionDDL.SelectedItem.Text;
            DateDiv.InnerText = "Report Date: " + DateTime.Now.ToShortDateString();


            List<GroupMinistryMembersQuestions> groupSummaryReports = new QuestionBiz().GetGroupMinistryMembersQuestions(fromSessions, toSession);
            List<GroupMinistryMembersQuestions> distinctgroupSummaryReports = (List<GroupMinistryMembersQuestions>)groupSummaryReports.GroupBy(o => new { o.Ministry, o.MoverName }).Select(o => o.FirstOrDefault()).ToList();

            if (distinctgroupSummaryReports != null)
            {
                //List<Groups> groups = new QuestionBiz().GetSessionGroups(fromSessions, 1);
                foreach (GroupMinistryMembersQuestions g in distinctgroupSummaryReports)
                {
                    g.MemberTotal = groupSummaryReports.Count(o => o.Ministry == g.Ministry && o.MoverName == g.MoverName);
                }
            }
            ListView1.DataSource = distinctgroupSummaryReports;
            ListView1.DataBind();
        }
        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}