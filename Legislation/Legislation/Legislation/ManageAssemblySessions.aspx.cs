using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LegisBIZ;
using LegisEntities;

namespace QuestionManagement
{
    public partial class ManageAssemblySessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                BindListBox();
                BindSession();
              
                confirmdiv.Visible = false;
                BusinessSessionsdiv.Visible = false;
            }
        }
        public void BindSession()
        {
            AssemblySessions AssSession = new LegislationBiz().GetCurrentAssemblySessionDetails();
            ParliamentaryYears pyear = new LegislationBiz().GetCurrentParliamentaryYear();
            LegislativeYear.Text = pyear.ParliamentaryYear;
            HidParliamentaryYearId.Value = pyear.ParliamentaryYearsId.ToString();
            AssemblySessionLbl.Text = AssSession.SessionNumber.ToString();
            HidAssemblySessionId.Value = AssSession.AssemblySessionsId.ToString();
            StartDateTxt.Text = AssSession.StartDate.ToShortDateString();
            if (!String.IsNullOrEmpty(AssSession.BusinessSessions))
            {
                List<string> BSessions = AssSession.BusinessSessions.Split(',').Select(s => Convert.ToString(s)).ToList();
                foreach (var a in BSessions)
                {
                    foreach (ListItem b in BusinessSessionsLB.Items)
                    {

                        if (Convert.ToInt32(a)==Convert.ToInt32(b.Value))
                            b.Selected = true;
                    }
                }
            }
            EndDateTxt.Text = AssSession.EndDate.ToShortDateString();
            CalledByDDL.SelectedValue = Convert.ToString(AssSession.CalledBy);
        }
        public void BindCombos()
        {

            //List<AssemblySessions> ASessions = new LegislationBiz().GetAssemblySessions();
            //foreach (AssemblySessions row in ASessions)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.SessionNumber.ToString();
            //    li.Value = row.AssemblySessionsId.ToString();
            //    SessionDDL.Items.Add(li);
            //}
        }
        //protected void ProrogueBtn_Click(object sender, EventArgs e)
        //{
        //    string sess = "0";
        //    List<int> sessions = new List<int>();
        //    int CurrentSession = new LegislationBiz().GetCurrentAssemblySessions();
        //    sessions.Add(CurrentSession);
        //    foreach(ListItem li in BusinessSessionsLB.Items)
        //    {
        //        if (li.Selected == true)
        //            sessions.Add(Convert.ToInt32(li.Value));
        //    }
        //    if (Convert.ToInt32(MotionsDDL.SelectedItem.Value) == 2) //if business close
        //    {
        //        if (sessions != null)
        //        {
        //            foreach (int intli in sessions)
        //            {
        //                new LegislationBiz().LapseMotion(intli);
        //            }
        //        }
        //    }
        //    if (Convert.ToInt32(ResolutionsDDL.SelectedItem.Value) == 2) //if business close
        //    {
        //        if (sessions != null)
        //        {
        //            foreach (int intli in sessions)
        //            {
        //                new LegislationBiz().LapseResolution(intli);
        //            }
        //        }
        //    }


        //    if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 2) //if business close
        //    {
        //        foreach (int intli in sessions)
        //        {
        //            new LegislationBiz().LapseQuestion(intli);
        //            new LegislationBiz().LapseMotion(intli);
        //            new LegislationBiz().LapseResolution(intli);

        //            List<Questions> admitted = new QuestionBiz().GetQuestionsByStatus(intli, 9);
        //            if (admitted != null)
        //            {
        //                foreach (Questions row in admitted)
        //                {
        //                    QuestionStatusHistory sh = new QuestionStatusHistory();
        //                    sh.AssemblySessionId = intli;
        //                    sh.QuestionId = row.QuestionsId;
        //                    sh.QuestionStatusId = row.QuestionStatusId;
        //                    sh.StatusDate = DateTime.Now;
        //                    new QuestionBiz().InsertQuestionStatusHistory(sh);

        //                }
        //            }
        //            List<Questions> underprocess = new QuestionBiz().GetQuestionsByStatus(intli, 8);
        //            if (underprocess != null)
        //            {
        //                foreach (Questions row in underprocess)
        //                {
        //                    QuestionStatusHistory sh = new QuestionStatusHistory();
        //                    sh.AssemblySessionId = intli;
        //                    sh.QuestionId = row.QuestionsId;
        //                    sh.QuestionStatusId = row.QuestionStatusId;
        //                    sh.StatusDate = DateTime.Now;
        //                    new QuestionBiz().InsertQuestionStatusHistory(sh);

        //                }
        //            }
        //        }
        //        BusinessSessionsLB.SelectedIndex = -1;
        //        ProrogueSession("0");
        //    }
        //    else
        //    {
        //        sess = CarryForward();


        //    }          

        //}

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
                string sess = CarryForward();
                AssemblySessions asession = new AssemblySessions();
                asession.AssemblySessionsId = Convert.ToInt32(HidAssemblySessionId.Value);
                asession.SessionNumber = Convert.ToInt32(AssemblySessionLbl.Text);
                asession.ParliamentaryYearsId = Convert.ToInt32(HidParliamentaryYearId.Value);
                asession.BusinessSessions = sess;
                asession.BusinessStatus = Convert.ToInt32(BusinessDDL.SelectedItem.Value);
                asession.CalledBy = CalledByDDL.SelectedValue;
                asession.StartDate = Convert.ToDateTime(StartDateTxt.Text);
                asession.EndDate = Convert.ToDateTime(EndDateTxt.Text);
                // asession.Purpose = Convert.ToString(SessionPurposeTxt.Text);
                new LegislationBiz().UpdateAssemblySessions(asession);
        }
        protected string CarryForward()
        {
            string sess = "0";
            if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 1 && BusinessSessionsLB.SelectedIndex == -1)
                errorlbl.Text = "Please select any session to carry forward business.";
            else
            {
                errorlbl.Text = "";
                if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 1)
                {

                    foreach (ListItem sessions in BusinessSessionsLB.Items)
                    {
                        if (sessions.Selected)
                        {
                            if (sess.Equals("0"))
                                sess = "";
                            if (!String.IsNullOrEmpty(sess))
                                sess = sess + ",";
                            sess = sess + sessions.Value;
                        }

                    }
                }
                ProrogueSession(sess);
            }
            return sess;
        }
        public void ProrogueSession(string sess)
        {
            ParliamentaryYears pyear = new LegislationBiz().GetCurrentParliamentaryYear();
            int CurrentSession = new LegislationBiz().GetCurrentAssemblySessions();
            AssemblySessions asession = new AssemblySessions();
            asession.ParliamentaryYearsId = pyear.ParliamentaryYearsId;
            asession.SessionNumber = Convert.ToInt32(AssemblySessionLbl.Text) + 1;
            asession.StartDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            // asession.BusinessStatus = Convert.ToInt32(BusinessDDL.SelectedItem.Value);
            if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 1)
                asession.BusinessSessions = sess;
            if (Convert.ToInt32(MotionsDDL.SelectedItem.Value) == 1)
                asession.MotionSessions = sess;
            if (Convert.ToInt32(ResolutionsDDL.SelectedItem.Value) == 1)
                asession.ResolutionSessions = sess;
            asession.CalledBy = "Government";
            int NewSessionId = new LegislationBiz().InsertAssemblySessions(asession);
            new LegislationBiz().CopySessionGroups(NewSessionId, CurrentSession);
            BindSession();
            confirmlabel.ForeColor = System.Drawing.Color.Green;
            confirmlabel.Text = "The Session Prorogued successfully";
        }

        public void BindListBox()
        {
            List<AssemblySessions> ASessions = new LegislationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                BusinessSessionsLB.Items.Add(li);
            }
        }
        protected void Prorogue1_Click(object sender, EventArgs e)
        {
            string sess = "previous";
            foreach (ListItem sessions in BusinessSessionsLB.Items)
            {
               
                if (sessions.Selected)
                {
                    if (sess.Equals("previous"))
                        sess = "";
                    if (!String.IsNullOrEmpty(sess))
                        sess = sess + ",";
                    sess = sess + sessions.Text;
                }

            }
            confirmdiv.Visible = true;
            if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 1)
                confirmlabel.Text = "The Business from " +  sess + " sessions will be carried forward.";
            if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 2)
            {
                confirmlabel.ForeColor = System.Drawing.Color.Green;
                confirmlabel.Text = "The Business from previous session will lapse.";
            }
        }
        protected void NoBtn_Click(object sender, EventArgs e)
        {
            confirmdiv.Visible = false;
        }

        protected void BusinessDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(BusinessDDL.SelectedItem.Value) == 1 || Convert.ToInt32(MotionsDDL.SelectedItem.Value) == 1 || Convert.ToInt32(ResolutionsDDL.SelectedItem.Value) == 1)
                BusinessSessionsdiv.Visible = true;
            else
                BusinessSessionsdiv.Visible = false;
        }
    }
}