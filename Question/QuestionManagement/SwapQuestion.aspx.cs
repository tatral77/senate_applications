using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class SwapQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
                List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
                foreach (AssemblySessions row in ASessions)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    SessionMovementDDL.Items.Add(li);
                }
            }

        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            List<Groups> gps = null;
            gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, 1);
            FirstGroup.Items.Clear();
            FirstGroup.Items.Add(new ListItem("Select", "0"));

            if (gps != null)
            {

                foreach (Groups obj in gps)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.GroupsId.ToString();
                    li.Text = obj.Description;
                    FirstGroup.Items.Add(li);
                }
            }
        }

        protected void SessionMovementDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);

        }
        protected void FirstLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string GetGroupName(int GroupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(GroupId);
            return gp.Description;

        }
        protected void FirstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionsId = Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
            int firstgroup = Convert.ToInt32(FirstGroup.SelectedItem.Value);
            SecondGroup.Items.Clear();
            SecondGroup.Items.Add(new ListItem("Select", "0"));

            Groups gp = new QuestionBiz().GetGroupById(firstgroup);
            List<Groups> gps = new QuestionBiz().GetSessionCorrespondingGroup(AssemblySessionsId, gp.CorrespondingGroup);
            if (gps != null)
            {

                foreach (Groups obj in gps)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.GroupsId.ToString();
                    li.Text = obj.Description;
                    if (obj.GroupsId != firstgroup)
                        SecondGroup.Items.Add(li);
                }
            }

            PopulateFirstGroupQuestions();
        }
        public string GetMinText(string txt)
        {
            if (txt.Length >= 350)
                return txt.Substring(0, 350).Trim() + ".................";
            else
                return txt;

        }
        public List<Questions> GetGroupQuestions(int AssemblySessionId, int GroupId)
        {
            string query = "SELECT QUESTIONS.QUESTIONS_ID, QUESTIONS.PARLIAMENTARY_YEAR, QUESTIONS.MOVER, QUESTIONS.QUESTION_CATEGORY, QUESTIONS.QUESTION_DATE, QUESTIONS.QUESTION_TIME, QUESTIONS.SUBJECT, ";
            query += " QUESTIONS.QUESTION_TEXT, QUESTIONS.MINISTRY, QUESTIONS.MINISTRY_GROUP, QUESTIONS.DIVISION, QUESTIONS.DEPARTMENTS_ID, QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE,  ";
            query += " QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.ADMITTED_NUMBER,QUESTIONS.IS_CARRY_FWD, QUESTIONS.QUESTION_DIARY_NO, QUESTIONS.QUESTION_DIARY_DATE, QUESTIONS.QUESTION_DIARY_TIME, QUESTIONS.SESSION_NUMBER,  ";
            query += " QUESTIONS.SESSION_SITTINGS_ID, CONCAT(SYSTEM_USERS.F_NAME,' ' ,SYSTEM_USERS.M_NAME,' ',SYSTEM_USERS.L_NAME) AS F_NAME, QUESTION_STATUSES.DESCRIPTION AS QUESTION_STATUS, QUESTION_CATEGORIES.DESCRIPTION AS CATEGORY,ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME  ";
            query += " FROM QUESTIONS INNER JOIN  ";
            query += " QUESTION_CATEGORIES ON QUESTIONS.QUESTION_CATEGORY = QUESTION_CATEGORIES.QUESTION_CATEGORIES_ID INNER JOIN  ";
            query += " QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN  ";
            query += " SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
            query += " WHERE QUESTIONS.SESSION_NUMBER=" + AssemblySessionId + " AND QUESTIONS.MINISTRY_GROUP=" + GroupId + " AND QUESTIONS.QUESTION_STATUS IN (3,7)";
            query += " ORDER BY QUESTIONS.NOTICE_DIARY_DATE DESC,QUESTIONS.NOTICE_DIARY_TIME DESC  ";
            List<Questions> questions = new QuestionBiz().SearchQuestion(query);
            return questions;

        }

        protected void SecondGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSecondGroupQuestions();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int firstquestion = 0;
            int secondquestion = 0;
            int firstgroup = Convert.ToInt32(FirstGroup.SelectedItem.Value);
            int secondgroup = Convert.ToInt32(SecondGroup.SelectedItem.Value);
            if (FirstLB.SelectedItem == null || SecondLB.SelectedItem == null)
            {

                err.Text = "Please select questions to swap;";
            }
            else
            {
                err.Text = "";
                firstquestion = Convert.ToInt32(FirstLB.SelectedItem.Value);
                secondquestion = Convert.ToInt32(SecondLB.SelectedItem.Value);
                new QuestionBiz().SwapQuestion(firstgroup, firstquestion, secondgroup, secondquestion);
                PopulateFirstGroupQuestions();
                PopulateSecondGroupQuestions();
            }
        }

        public void PopulateFirstGroupQuestions()
        {
            FirstLB.Items.Clear();
            int AssemblySessionsId = Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
            int firstgroup = Convert.ToInt32(FirstGroup.SelectedItem.Value);
            List<Questions> qs = GetGroupQuestions(AssemblySessionsId, firstgroup);
            if (qs != null)
            {
                foreach (Questions div in qs)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(div.QuestionsId);
                    Temp.Text = Convert.ToString(div.QuestionsId) + " --- " + div.QuestionStatus + " --- " + Convert.ToString(div.MoverName);
                    FirstLB.Items.Add(Temp);
                }
            }
        }

        public void PopulateSecondGroupQuestions()
        {
            SecondLB.Items.Clear();
            int secondgroup = Convert.ToInt32(SecondGroup.SelectedItem.Value);
            int AssemblySessionsId = Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
            Groups gp = new QuestionBiz().GetGroupById(secondgroup);
            List<Questions> qs = GetGroupQuestions(AssemblySessionsId, secondgroup);

            if (qs != null)
            {
                foreach (Questions div in qs)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(div.QuestionsId);
                    Temp.Text = Convert.ToString(div.QuestionsId) + " --- " + div.QuestionStatus + " --- " + Convert.ToString(div.MoverName);
                    SecondLB.Items.Add(Temp);
                }
            }

        }
    }
}