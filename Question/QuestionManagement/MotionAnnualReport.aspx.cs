using Entities;
using MotionBIZ;
using MotionEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class MotionAnnualReport : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(empName);
            foreach (Member a in mems)
            {
                empResult.Add(a.MemberName);
            }
            return empResult;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }
        }

        private void bindListView()
        {
            List<MotionEnt> Motions = new MotionBiz().GetMotions(new AdministrationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Motions;
            ListView1.DataBind();

        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, @"<[^>]+>|&nbsp;", "").Trim(); ;
            if (txt.Length >= 350 && FullTextCB.Checked == false)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
            return text;


        }
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += temp.MoverName + ", ";
                }
            }
            return moverslist;
        }
        public string SelectText(string Text)
        {
            string keywords = KeywordsTxt.Text;
            if (Text != string.Empty && keywords != string.Empty)
            {
                string[] sKeywords = keywords.Split(' ');
                foreach (string sKeyword in sKeywords)
                {
                    try
                    {
                        Text = Regex.Replace(Text, sKeyword, string.Format("<strong><span class=\"hit\">{0}</span></strong>", "$0"), RegexOptions.IgnoreCase);
                        // Text = Regex.Replace(Text, sKeyword, string.Format("<strong>{0}</strong>", "$0"), RegexOptions.IgnoreCase);
                    }
                    catch
                    {
                        //
                    }
                }

                return Text;
            }
            else
                return GetMinText(Text);
        }
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        private void bindFields()
        {
            AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
            // SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            FromAssemblySessionDDL.Items.Add(new ListItem("Select", "0"));
            ToAssemblySessionDDL.Items.Add(new ListItem("Select", "0"));
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                FromAssemblySessionDDL.Items.Add(li);
                ToAssemblySessionDDL.Items.Add(li);
                //if (row.AssemblySessionsId == ASession.AssemblySessionsId)
                //    SessionMovementDDL.Items.Add(li);
            }
            //FromAssemblySessionDDL.SelectedIndex = 1;
            //ToAssemblySessionDDL.SelectedIndex = 1;

            List<MotionTypeEnt> QCats = new AdministrationBiz().GetMotionTypes();
            foreach (MotionTypeEnt row1 in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row1.Description;
                li.Value = row1.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
            List<MotionStatusEnt> QStatuses = new AdministrationBiz().GetMotionStatuses();
            foreach (MotionStatusEnt row2 in QStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row2.Description;
                li.Value = row2.MotionStatusId.ToString();
                MotionStatusDDL.Items.Add(li);
            }

        }


        protected string GetCriteria()
        {
            string query = " MOTIONS.MOTION_TYPE IN (SELECT MOTION_TYPES_ID FROM MOTION_TYPES WHERE IS_FOR_MOTIONS=2) ";

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MotionId.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.MOTIONS_ID IN (" + MotionId.Text + ")";

            }
            if (!(String.IsNullOrEmpty(MotionDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.MOTION_DIARY_NO = ('" + MotionDiary.Text + "')";

            }

            if (MotionStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.MOTION_STATUS=" + MotionStatusDDL.SelectedItem.Value;

            }

            if (MotionTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.MOTION_TYPE=" + MotionTypeDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTION_MOVERS.SYSTEM_USERS_ID=" + HidMemberId.Value;

            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.DESCRIPTION LIKE '%" + KeywordsTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(NoticeDiaryNo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_NO  IN (" + NoticeDiaryNo.Text + ") ";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)";

            }


            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            search();
        }
        protected void search()
        {
            if (String.IsNullOrEmpty(MemberNameTxt.Text))
                HidMemberId.Value = null;
            string criteria = GetCriteria();
            //if (GetCriteria() == String.Empty)
            //    bindListView();
            //else
            //{
            string query = "SELECT DISTINCT MOTIONS.MOTIONS_ID, MOTIONS.NOTICE_DIARY_NO, MOTIONS.NOTICE_DIARY_DATE,MOTIONS.NOTICE_DIARY_TIME ,MOTIONS.SESSION_NUMBER, MOTIONS.REFFERED_SC_DATE, MOTIONS.MOVING_HOUSE_DATE, MOTIONS.DISCUSSION_DATE, ";
            query += " MOTIONS.DESCRIPTION AS MOTION_TEXT, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_DESC, MOTION_TYPES.DESCRIPTION AS MOTION_TYPE, MOTION_STATUSES.DESCRIPTION AS MOTION_STATUS, ";
            query += " MOTIONS.MOTION_TYPE AS MOTION_TYPE_ID, MOTIONS.MOTION_DIARY_NO, MOTIONS.MOTION_DIARY_DATE, MOTIONS.MOTION_DIARY_TIME, MOTIONS.MOTION_STATUS AS MOTION_STATUS_ID, ";
            query += " MOTIONS.ADMISSION_DATE, MOTIONS.PRESENT_HOUSE_DATE ";
            if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                query += " , MOTION_MOVERS.SYSTEM_USERS_ID ";
            query += " FROM MOTIONS INNER JOIN ";
            query += " MOTION_STATUSES ON MOTIONS.MOTION_STATUS = MOTION_STATUSES.MOTION_STATUSES_ID INNER JOIN ";
            query += " MOTION_TYPES ON MOTIONS.MOTION_TYPE = MOTION_TYPES.MOTION_TYPES_ID INNER JOIN ";
            query += " ASSEMBLY_SESSIONS ON MOTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
            if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                query += " INNER JOIN MOTION_MOVERS ON MOTIONS.MOTIONS_ID = MOTION_MOVERS.MOTIONS_ID ";
            if (GetCriteria() != String.Empty)
            {
                query += " WHERE ";
                query += GetCriteria();
            }
            query += " ORDER BY MOTIONS.MOTION_DIARY_NO";
            List<MotionEnt> Questions = new MotionBiz().SearchMotion(query);
            ListView1.DataSource = Questions;
            ListView1.DataBind();
            //}
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();

        }

        public string GetGroupName(int GroupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(GroupId);
            if (gp != null)
                return gp.Description;
            else
                return "Not Mentioned";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            FromAssemblySessionDDL.SelectedItem.Value = "0";
            ToAssemblySessionDDL.SelectedItem.Value = "0";
            MotionStatusDDL.SelectedItem.Value = "0";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            MotionId.Text = "";

        }


    }
}