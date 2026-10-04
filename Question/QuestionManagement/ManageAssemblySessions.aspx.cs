using Entities;
using MotionBIZ;
using QuestionBIZ;
using ResolutionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageAssemblySessions : System.Web.UI.Page
    {
        private const int CarryForwardChoice = 1;
        private const int LapseChoice = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListBox();
                BindSession();

                confirmdiv.Visible = false;
            }
        }

        public void BindSession()
        {
            AssemblySessions AssSession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
            ParliamentaryYears pyear = new AdministrationBiz().GetCurrentParliamentaryYear();
            LegislativeYear.Text = pyear.ParliamentaryYear;
            HidParliamentaryYearId.Value = pyear.ParliamentaryYearsId.ToString();
            AssemblySessionLbl.Text = AssSession.SessionNumber.ToString();
            HidAssemblySessionId.Value = AssSession.AssemblySessionsId.ToString();
            StartDateTxt.Text = AssSession.StartDate.ToString("dd/MM/yyyy");
            if (!String.IsNullOrEmpty(AssSession.BusinessSessions))
            {
                // sessions whose business was carried into this session are ticked by default
                foreach (string a in AssSession.BusinessSessions.Split(','))
                {
                    int id;
                    if (!int.TryParse(a.Trim(), out id))
                        continue;
                    foreach (ListItem b in BusinessSessionsLB.Items)
                    {
                        if (id == Convert.ToInt32(b.Value))
                            b.Selected = true;
                    }
                }
            }
            EndDateTxt.Text = AssSession.EndDate.Year > 1900 ? AssSession.EndDate.ToString("dd/MM/yyyy") : "";
            CalledByDDL.SelectedValue = Convert.ToString(AssSession.CalledBy);
        }

        public void BindListBox()
        {
            int current = new AdministrationBiz().GetCurrentAssemblySessions();
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            if (ASessions == null)
                return;
            // newest session first
            foreach (AssemblySessions row in ASessions.OrderByDescending(s => s.AssemblySessionsId))
            {
                ListItem li = new ListItem();
                li.Text = "Session " + row.SessionNumber + (row.AssemblySessionsId == current ? " (current)" : "");
                li.Value = row.AssemblySessionsId.ToString();
                BusinessSessionsLB.Items.Add(li);
            }
        }

        // ids of the sessions ticked in the list
        private List<int> SelectedSessionIds()
        {
            List<int> ids = new List<int>();
            foreach (ListItem li in BusinessSessionsLB.Items)
            {
                int id;
                if (li.Selected && int.TryParse(li.Value, out id))
                    ids.Add(id);
            }
            return ids;
        }

        private string SelectedSessionNames()
        {
            return string.Join(", ", BusinessSessionsLB.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Text.Replace(" (current)", "").Replace("Session ", "")));
        }

        private int QuestionsChoice { get { return Convert.ToInt32(BusinessDDL.SelectedItem.Value); } }
        private int MotionsChoice { get { return Convert.ToInt32(MotionsDDL.SelectedItem.Value); } }
        private int ResolutionsChoice { get { return Convert.ToInt32(ResolutionsDDL.SelectedItem.Value); } }

        private static string ChoiceText(int choice)
        {
            return choice == CarryForwardChoice ? "carried forward" : "lapsed";
        }

        private void ShowMessage(string text, string kind)
        {
            MessagePnl.CssClass = "alert alert-" + kind;
            MessageLbl.Text = Server.HtmlEncode(text);
            MessagePnl.Visible = true;
        }

        // step 1: check the choices and ask for confirmation
        protected void Prorogue1_Click(object sender, EventArgs e)
        {
            MessagePnl.Visible = false;
            if (!Page.IsValid)
                return;

            bool carry = QuestionsChoice == CarryForwardChoice || MotionsChoice == CarryForwardChoice || ResolutionsChoice == CarryForwardChoice;
            if (carry && SelectedSessionIds().Count == 0)
            {
                confirmdiv.Visible = false;
                ShowMessage("Please tick at least one session whose business is to be carried forward.", "warning");
                return;
            }

            string text = "Questions will be " + ChoiceText(QuestionsChoice) + ", motions will be " + ChoiceText(MotionsChoice) + " and resolutions will be " + ChoiceText(ResolutionsChoice) + ".";
            if (carry)
                text += " Business of session(s) " + SelectedSessionNames() + " moves into the new session.";
            confirmlabel.Text = Server.HtmlEncode(text);
            confirmdiv.Visible = true;
        }

        // step 2: carry forward / lapse the business and start the next session
        protected void ProrogueBtn_Click(object sender, EventArgs e)
        {
            // the session has already been prorogued from this page: never do it a second time
            if (!Prorogue1.Enabled)
                return;
            if (QuestionsChoice == 0 || MotionsChoice == 0 || ResolutionsChoice == 0)
            {
                confirmdiv.Visible = false;
                ShowMessage("Select what happens to Questions, Motions and Resolutions first.", "warning");
                return;
            }

            bool carryQuestions = QuestionsChoice == CarryForwardChoice;
            bool carryMotions = MotionsChoice == CarryForwardChoice;
            bool carryResolutions = ResolutionsChoice == CarryForwardChoice;
            List<int> selected = SelectedSessionIds();
            if ((carryQuestions || carryMotions || carryResolutions) && selected.Count == 0)
            {
                confirmdiv.Visible = false;
                ShowMessage("Please tick at least one session whose business is to be carried forward.", "warning");
                return;
            }

            try
            {
                // business that lapses: the current session and any ticked session
                List<int> sessions = new List<int>();
                sessions.Add(new AdministrationBiz().GetCurrentAssemblySessions());
                foreach (int id in selected)
                {
                    if (!sessions.Contains(id))
                        sessions.Add(id);
                }

                if (QuestionsChoice == LapseChoice)
                {
                    foreach (int intli in sessions)
                    {
                        new QuestionBiz().LapseQuestion(intli);
                        RecordStatusHistory(intli, 9); // admitted
                        RecordStatusHistory(intli, 8); // under process
                    }
                }
                if (MotionsChoice == LapseChoice)
                {
                    foreach (int intli in sessions)
                        new QuestionBiz().LapseMotion(intli);
                }
                if (ResolutionsChoice == LapseChoice)
                {
                    foreach (int intli in sessions)
                        new QuestionBiz().LapseResolution(intli);
                }

                foreach (int id in selected)
                {
                    if (carryQuestions)
                        new QuestionBiz().CarryForwardQuestions(id);
                    if (carryMotions)
                        new MotionBiz().CarryForwardMotions(id);
                    if (carryResolutions)
                        new ResolutionBiz().CarryForwardResolutions(id);
                }

                ProrogueSession(carryQuestions || carryMotions || carryResolutions ? string.Join(",", selected) : "0");
            }
            catch (Exception ex)
            {
                confirmdiv.Visible = false;
                ShowMessage("The session could not be prorogued: " + ex.Message, "danger");
            }
        }

        private void RecordStatusHistory(int sessionId, int statusId)
        {
            List<Questions> questions = new QuestionBiz().GetQuestionsByStatus(sessionId, statusId);
            if (questions == null)
                return;
            foreach (Questions row in questions)
            {
                QuestionStatusHistory sh = new QuestionStatusHistory();
                sh.AssemblySessionId = sessionId;
                sh.QuestionId = row.QuestionsId;
                sh.QuestionStatusId = row.QuestionStatusId;
                sh.StatusDate = DateTime.Now;
                new QuestionBiz().InsertQuestionStatusHistory(sh);
            }
        }

        public void ProrogueSession(string sess)
        {
            ParliamentaryYears pyear = new AdministrationBiz().GetCurrentParliamentaryYear();
            int CurrentSession = new AdministrationBiz().GetCurrentAssemblySessions();
            string prorogued = AssemblySessionLbl.Text;
            AssemblySessions asession = new AssemblySessions();
            asession.ParliamentaryYearsId = pyear.ParliamentaryYearsId;
            asession.SessionNumber = Convert.ToInt32(AssemblySessionLbl.Text) + 1;
            asession.StartDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (QuestionsChoice == CarryForwardChoice || MotionsChoice == CarryForwardChoice || ResolutionsChoice == CarryForwardChoice)
                asession.BusinessSessions = sess;
            if (MotionsChoice == CarryForwardChoice)
                asession.MotionSessions = sess;
            if (ResolutionsChoice == CarryForwardChoice)
                asession.ResolutionSessions = sess;
            asession.CalledBy = "Government";
            int NewSessionId = new AdministrationBiz().InsertAssemblySessions(asession);
            new QuestionBiz().CopySessionGroups(NewSessionId, CurrentSession);
            BindSession();
            ShowProrogued(prorogued);
        }

        // Shows the success message and locks the page so the same session cannot be prorogued again.
        private void ShowProrogued(string proroguedSession)
        {
            ShowMessage("Session " + proroguedSession + " has been prorogued successfully. Questions were " + ChoiceText(QuestionsChoice)
                + ", motions were " + ChoiceText(MotionsChoice) + " and resolutions were " + ChoiceText(ResolutionsChoice) + ". Session " + AssemblySessionLbl.Text + " has now started.", "success");
            confirmdiv.Visible = false;
            Prorogue1.Enabled = false;
            Prorogue1.Text = "Session Prorogued";
            ProrogueBtn.Enabled = false;
            CalledByDDL.Enabled = false;
            BusinessDDL.Enabled = false;
            MotionsDDL.Enabled = false;
            ResolutionsDDL.Enabled = false;
            BusinessSessionsLB.Enabled = false;
            StartDateTxt.Enabled = false;
            EndDateTxt.Enabled = false;
        }

        protected void NoBtn_Click(object sender, EventArgs e)
        {
            confirmdiv.Visible = false;
        }
    }
}
