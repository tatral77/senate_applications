using Entities;
using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
{
    public partial class SentMotions : System.Web.UI.Page
    {

        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new AdministrationBiz().GetMembersByName(empName);
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
            List<MotionEnt> Motions = new MotionBiz().GetSentMotions(new MotionBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Motions;
            ListView1.DataBind();

        }
        public string GetMinText(string txt)
        {
            if (txt.Length >= 350)
                return txt.Substring(0, 350).Trim() + ".................";
            else
                return txt;

        }
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += temp.MoverName + ",<br> ";
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
            // AssemblySessions ASession = new MotionBiz().GetCurrentAssemblySessionDetails();
            // SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
            List<AssemblySessions> ASessions = new MotionBiz().GetAssemblySessions();
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

            List<MotionTypeEnt> QCats = new MotionBiz().GetMotionTypes();
            foreach (MotionTypeEnt row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
            List<MotionStatusEnt> motionstatus = new MotionBiz().GetMotionStatuses();
            foreach (MotionStatusEnt row in motionstatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionStatusId.ToString();
                MotionStatusDDL.Items.Add(li);
            }
            List<MotionWeek> motionweeks = new MotionBiz().GetMotionWeeks();
            foreach (MotionWeek row in motionweeks)
            {
                ListItem li = new ListItem();
                li.Text = row.WeekName.ToString();
                li.Value = row.WeekId.ToString();
                MotionWeekCB.Items.Add(li);
            }

        }


        protected string GetCriteria()
        {
            string query = "";
            query = " PROCESSED=0 ";
            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MotionId.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.MOTIONS_ID IN (" + MotionId.Text + ")";

            }
            if (!(String.IsNullOrEmpty(MotionDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.MOTION_DIARY_NO = ('" + MotionDiary.Text + "')";

            }

            if (MotionStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.MOTION_STATUS=" + MotionStatusDDL.SelectedItem.Value;

            }

            if (MotionTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.MOTION_TYPE=" + MotionTypeDDL.SelectedItem.Value;

            }
            if (MotionWeekCB.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.MB_WEEK_ID=" + MotionWeekCB.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTION_MOVERS.SYSTEM_USERS_ID=" + HidMemberId.Value;

            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.DESCRIPTION LIKE '%" + KeywordsTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.FILE_NO LIKE '%" + FileNoTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MB_MOTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)";

            }


            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MemberNameTxt.Text))
                HidMemberId.Value = null;
            string criteria = GetCriteria();
            if (GetCriteria() == String.Empty)
                bindListView();
            else
            {
                string query = "SELECT DISTINCT MB_MOTIONS.MOTIONS_ID,MB_MOTIONS.FILE_NO,MB_MOTIONS.MB_WEEK_ID,MB_MOTIONS.MB_WEEK_ID, MB_MOTIONS.NOTICE_DIARY_NO, MB_MOTIONS.NOTICE_DIARY_DATE, MB_MOTIONS.SESSION_NUMBER, MB_MOTIONS.REFFERED_SC_DATE, MB_MOTIONS.MOVING_HOUSE_DATE, MB_MOTIONS.DISCUSSION_DATE, ";
                query += " MB_MOTIONS.DESCRIPTION AS MOTION_TEXT, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_DESC, MOTION_TYPES.DESCRIPTION AS MOTION_TYPE, MOTION_STATUSES.DESCRIPTION AS MOTION_STATUS, ";
                query += " MB_MOTIONS.MOTION_TYPE AS MOTION_TYPE_ID, MB_MOTIONS.MOTION_DIARY_NO, MB_MOTIONS.MOTION_DIARY_DATE, MB_MOTIONS.MOTION_DIARY_TIME, MB_MOTIONS.MOTION_STATUS AS MOTION_STATUS_ID, ";
                query += " MB_MOTIONS.ADMISSION_DATE, MB_MOTIONS.PRESENT_HOUSE_DATE ";
                if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                    query += " , MB_MOTION_MOVERS.SYSTEM_USERS_ID ";
                query += " FROM MB_MOTIONS INNER JOIN ";
                query += " MOTION_STATUSES ON MB_MOTIONS.MOTION_STATUS = MOTION_STATUSES.MOTION_STATUSES_ID INNER JOIN ";
                query += " MOTION_TYPES ON MB_MOTIONS.MOTION_TYPE = MOTION_TYPES.MOTION_TYPES_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON MB_MOTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
                if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                    query += " INNER JOIN MB_MOTION_MOVERS ON MB_MOTIONS.MOTIONS_ID = MB_MOTION_MOVERS.MOTIONS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                query += " ORDER BY MB_MOTIONS.NOTICE_DIARY_DATE DESC  ";
                List<MotionEnt> Questions = new MotionBiz().SearchMotion(query);
                ListView1.DataSource = Questions;
                ListView1.DataBind();
            }
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();

        }

        public string GetGroupName(int GroupId)
        {
            Groups gp = new MotionBiz().GetGroupById(GroupId);
            if (gp != null)
                return gp.Description;
            else
                return "Not Mentioned";

        }
        public string GetWeek(int weekid)
        {
            MotionWeek gp = new MotionBiz().GetMotionWeek(weekid);
            if (gp != null)
                return gp.WeekName;
            else
                return "Not Mentioned";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            FromAssemblySessionDDL.SelectedItem.Value = "0";
            ToAssemblySessionDDL.SelectedItem.Value = "0";
            MotionStatusDDL.SelectedItem.Value = "0";
            MotionWeekCB.SelectedItem.Value = "0";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            MotionId.Text = "";

        }


    }
}
