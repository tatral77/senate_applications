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
    public partial class SearchResolution : System.Web.UI.Page
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
            List<ResolutionEnt> Resolutions = new ResolutionBiz().GetResolutions(new AdministrationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Resolutions;
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
        protected string GetMembers(int ResolutionId)
        {
            string moverslist = "";
            List<ResolutionSubmittersEnt> movers = new ResolutionBiz().GetResolutionSubmitters(ResolutionId);
            if (movers != null)
            {
                foreach (ResolutionSubmittersEnt temp in movers)
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

            List<ResolutionTypesEnt> QCats = new ResolutionBiz().GetResolutionTypes();
            foreach (ResolutionTypesEnt row1 in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row1.Description;
                li.Value = row1.ResTypesId.ToString();
                ResolutionTypeDDL.Items.Add(li);
            }
            List<ResolutionStatusesEnt> QStatuses = new ResolutionBiz().GetResolutionStatuses();
            foreach (ResolutionStatusesEnt row2 in QStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row2.Description;
                li.Value = row2.ResolutionStatusesId.ToString();
                ResolutionStatusDDL.Items.Add(li);
            }

        }


        protected string GetCriteria()
        {
            string query = "";

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.ASSEMBLY_SESSIONS_ID>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.ASSEMBLY_SESSIONS_ID<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(ResolutionId.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTIONS_ID IN (" + ResolutionId.Text + ")";

            }
            if (!(String.IsNullOrEmpty(ResolutionDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTION_DIARY_NO = ('" + ResolutionDiary.Text + "')";

            }

            if (ResolutionStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTION_STATUS=" + ResolutionStatusDDL.SelectedItem.Value;

            }

            if (ResolutionTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTION_TYPE=" + ResolutionTypeDDL.SelectedItem.Value;

            }
            string memberIds = string.Join(",", FormInput.ParseIds(HidMemberId.Value));
            if (memberIds != "")
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTIONS_ID IN (SELECT RESOLUTION_SUBMITTERS.RESOLUTIONS_ID FROM RESOLUTION_SUBMITTERS WHERE RESOLUTION_SUBMITTERS.SYSTEM_USERS_ID IN (" + memberIds + "))";
            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.DESCRIPTION LIKE N'%" + KeywordsTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + FormInput.ParseDate(DateFromTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + FormInput.ParseDate(DateToTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

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
                string query = "SELECT  RESOLUTIONS.RESOLUTIONS_ID, RESOLUTIONS.NOTICE_DIARY_NO, RESOLUTIONS.NOTICE_DIARY_DATE, RESOLUTIONS.ASSEMBLY_SESSIONS_ID, RESOLUTIONS.MOVED_DATE, RESOLUTIONS.PASSED_DATE, RESOLUTIONS.DISCUSSED_DATE, ";
                query += " RESOLUTIONS.DESCRIPTION, ASSEMBLY_SESSIONS.SESSION_NUMBER,RESOLUTIONS.RES_TYPES_ID, RES_TYPES.DESCRIPTION AS RESOLUTION_TYPE, RESOLUTION_STATUSES.DESCRIPTION AS RESOLUTION_STATUS, ";
                query += " RESOLUTIONS.RES_TYPES_ID AS RESOLUTION_TYPE_ID, RESOLUTIONS.RESOLUTION_DIARY_NO, RESOLUTIONS.RESOLUTION_DIARY_DATE, RESOLUTIONS.RESOLUTION_DIARY_TIME, RESOLUTIONS.RESOLUTION_STATUS AS RESOLUTION_STATUS_ID  ";
                query += " FROM RESOLUTIONS INNER JOIN ";
                query += " RESOLUTION_STATUSES ON RESOLUTIONS.RESOLUTION_STATUS = RESOLUTION_STATUSES.RESOLUTION_STATUSES_ID INNER JOIN ";
                query += " RES_TYPES ON RESOLUTIONS.RES_TYPES_ID = RES_TYPES.RES_TYPES_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON RESOLUTIONS.ASSEMBLY_SESSIONS_ID = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                query += " ORDER BY RESOLUTIONS.NOTICE_DIARY_DATE DESC  ";
                List<ResolutionEnt> Questions = new ResolutionBiz().SearchResolutions(query);
                ListView1.DataSource = Questions;
                ListView1.DataBind();
            }
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();

        }

        //public string GetGroupName(int GroupId)
        //{
        //    Groups gp = new QuestionBiz().GetGroupById(GroupId);
        //    if (gp != null)
        //        return gp.Description;
        //    else
        //        return "Not Mentioned";

        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            FromAssemblySessionDDL.SelectedItem.Value = "0";
            ToAssemblySessionDDL.SelectedItem.Value = "0";
            ResolutionStatusDDL.SelectedItem.Value = "0";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            ResolutionId.Text = "";

        }
    }
}