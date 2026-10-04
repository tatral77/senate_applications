using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class Rpt_GroupsTotalSummary : System.Web.UI.Page
    {
        string lastrec = "";
        int i = 0;
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
                return String.Format("<tr class=group><td colspan=10 style='font-size:12pt!important;background-color:#D3D3D3'><b>" + Eval("Group") + "</b></td><tr>");

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
            heading.InnerText = "MINISTRY WISE STATEMENT OF ADMITTED STARRED, UN-STARRED AND DEFERRED QUESTIONS";
            sesionNumber.InnerText = "Session Number : " + SessionDDL.SelectedItem.Text + " To " + ToSessionDDL.SelectedItem.Text;
            DateDiv.InnerText = "Report Date: " + DateTime.Now.ToShortDateString();


            List<GroupSummaryReport> groupSummaryReports = new QuestionBiz().GetQuestionGroupSummary(fromSessions, toSession);
            if (groupSummaryReports != null)
            {
                List<Groups> groups = new QuestionBiz().GetSessionGroups(fromSessions, 1);
                List<GroupSummaryReport> groupSummaryReport = new List<GroupSummaryReport>();
                List<GroupSummaryReport> groupSummaryReportWithSum = new List<GroupSummaryReport>();
                GroupSummaryReport groupSummaryReportWithGrandSum = new GroupSummaryReport();
                groupSummaryReportWithGrandSum.Division = "<b>Grand Total</b>";
                foreach (Groups gps in groups)
                {
                    int i = 1;
                    List<GroupSummaryReport> gsr = groupSummaryReports.Where(t => t.Group.Equals(gps.Description)).ToList();
                    GroupSummaryReport sum = new GroupSummaryReport();
                    if (gsr.Count != 0)
                    {
                        foreach (GroupSummaryReport g in gsr)
                        {
                            g.SerialNumber = i.ToString();
                            groupSummaryReportWithSum.Add(g);
                            i++;
                        }
                        sum.Group = gps.Description;
                        sum.Division = "<b>Total</b>";
                        foreach (GroupSummaryReport g in gsr)
                        {
                            sum.Starred += g.Starred;
                            sum.UnStarred += g.UnStarred;
                            sum.Deferred += g.Deferred;
                            sum.DeferredUnstarred += g.DeferredUnstarred;
                            groupSummaryReportWithGrandSum.Starred += g.Starred;
                            groupSummaryReportWithGrandSum.UnStarred += g.UnStarred;
                            groupSummaryReportWithGrandSum.Deferred += g.Deferred;
                            groupSummaryReportWithGrandSum.DeferredUnstarred += g.DeferredUnstarred;

                        }
                        groupSummaryReportWithSum.Add(sum);
                    }
                }
                groupSummaryReportWithSum.Add(groupSummaryReportWithGrandSum);
                ListView1.DataSource = groupSummaryReportWithSum;
                ListView1.DataBind();
            }
        }
        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}