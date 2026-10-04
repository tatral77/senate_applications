using System.Globalization;
using Notice.Utilities;
using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class SearchMotion : System.Web.UI.Page
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
            if (txt.Length >= 350)
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
            return (date.Year < 1900) ? string.Empty : FormInput.FormatDate(date);

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

            List<MotionTypeEnt> QCats = new AdministrationBiz().GetMotionTypes(2);
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
            string query = "";

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
            if (!(String.IsNullOrEmpty(NoticeDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_NO = ('" + NoticeDiary.Text + "')";

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
            string memberIds = string.Join(",", FormInput.ParseIds(HidMemberId.Value));
            if (memberIds != "")
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.MOTIONS_ID IN (SELECT MOTION_MOVERS.MOTIONS_ID FROM MOTION_MOVERS WHERE MOTION_MOVERS.SYSTEM_USERS_ID IN (" + memberIds + "))";
            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DESCRIPTION LIKE '%" + KeywordsTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + FormInput.ParseDate(DateFromTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + FormInput.ParseDate(DateToTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

            }


            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string criteria = GetCriteria();
            if (GetCriteria() == String.Empty)
                bindListView();
            else
            {
                string query = "SELECT DISTINCT MOTIONS.MOTIONS_ID, MOTIONS.NOTICE_DIARY_NO, MOTIONS.NOTICE_DIARY_DATE,MOTIONS.NOTICE_DIARY_TIME ,MOTIONS.SESSION_NUMBER, MOTIONS.REFFERED_SC_DATE, MOTIONS.MOVING_HOUSE_DATE, MOTIONS.DISCUSSION_DATE, ";
                query += " MOTIONS.DESCRIPTION AS MOTION_TEXT, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_DESC, MOTION_TYPES.DESCRIPTION AS MOTION_TYPE, MOTION_STATUSES.DESCRIPTION AS MOTION_STATUS, ";
                query += " MOTIONS.MOTION_TYPE AS MOTION_TYPE_ID, MOTIONS.MOTION_DIARY_NO, MOTIONS.MOTION_DIARY_DATE, MOTIONS.MOTION_DIARY_TIME, MOTIONS.MOTION_STATUS AS MOTION_STATUS_ID, ";
                query += " MOTIONS.ADMISSION_DATE, MOTIONS.PRESENT_HOUSE_DATE ";
                query += " FROM MOTIONS INNER JOIN ";
                query += " MOTION_STATUSES ON MOTIONS.MOTION_STATUS = MOTION_STATUSES.MOTION_STATUSES_ID INNER JOIN ";
                query += " MOTION_TYPES ON MOTIONS.MOTION_TYPE = MOTION_TYPES.MOTION_TYPES_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON MOTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                query += " AND PROCESSED=1 ORDER BY MOTIONS.NOTICE_DIARY_DATE DESC  ";
                List<MotionEnt> Questions = new MotionBiz().SearchMotion(query);
                ListView1.DataSource = Questions;
                ListView1.DataBind();
            }
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();

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