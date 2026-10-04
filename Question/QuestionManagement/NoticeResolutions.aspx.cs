using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NoticeResolutions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();
            }
            else
            {
                SearchPanel.CssClass = "collapse in";   // stay open while the user is searching
            }
        }

        // shows the results and their count
        private void ShowResults(List<ResolutionEnt> resolutions)
        {
            ListView1.DataSource = resolutions;
            ListView1.DataBind();
            CountLit.Text = (resolutions == null ? 0 : resolutions.Count).ToString();
        }

        private void bindListView()
        {
            int sessionId = new AdministrationBiz().GetCurrentAssemblySessions();
            ShowResults(new ResolutionBiz().GetSentResolutions(sessionId));
            try { SessionLit.Text = Server.HtmlEncode(new DashboardBiz().GetSessionNumber(sessionId)); }
            catch { SessionLit.Text = ""; }

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
        //protected string GetMembers(int ResolutionId)
        //{
        //    string moverslist = "";
        //    List<ResolutionMoversEnt> movers = new ResolutionBiz().GetResolutionMovers(ResolutionId);
        //    if (movers != null)
        //    {
        //        foreach (ResolutionMoversEnt temp in movers)
        //        {
        //            moverslist += temp.MoverName + ", ";
        //        }
        //    }
        //    return moverslist;
        //}
        // Plain-text preview of the resolution with the searched keywords highlighted.
        // Many resolutions arrive as an image or PDF with no typed text yet.
        protected string Preview(string html, string file, int resolutionId)
        {
            string url = ResolveUrl("~/NoticeResolutionDetail.aspx?ResolutionId=" + resolutionId);
            string text = Regex.Replace(html ?? "", "<[^>]*>", " ");
            text = Regex.Replace(HttpUtility.HtmlDecode(text), @"\s+", " ").Trim();
            bool hasFile = !string.IsNullOrWhiteSpace(file);
            string clip = hasFile ? "<span class='glyphicon glyphicon-paperclip nr-clip' title='File attached'></span>" : "";
            if (text.Length == 0)
                return "<a href='" + url + "' target='_blank'>" + clip + "<span class='nr-nofile'>" +
                       (hasFile ? "Text not typed yet - open to view the attached file" : "No text and no file") + "</span></a>";
            if (text.Length > 300) text = text.Substring(0, 300).Trim() + "...";
            string safe = Server.HtmlEncode(text);
            foreach (string keyword in (KeywordsTxt.Text ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try { safe = Regex.Replace(safe, Regex.Escape(Server.HtmlEncode(keyword)), "<mark class='hit'>$0</mark>", RegexOptions.IgnoreCase); }
                catch { }
            }
            return "<a href='" + url + "' target='_blank'>" + clip + safe + "</a>";
        }

        // Makes a typed value safe to put between quotes in the search query.
        private static string Sql(string value)
        {
            return (value ?? "").Trim().Replace("'", "''");
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

            List<ResolutionTypesEnt> QCats = new ResolutionBiz().GetResolutionTypes();
            if (QCats != null)
            {
                foreach (ResolutionTypesEnt row1 in QCats)
                {
                    ListItem li = new ListItem();
                    li.Text = row1.Description;
                    li.Value = row1.ResTypesId.ToString();
                    ResolutionTypeDDL.Items.Add(li);
                }
            }
            List<ResolutionStatusesEnt> QStatuses = new ResolutionBiz().GetResolutionStatuses();
            if (QStatuses != null)
            {
                foreach (ResolutionStatusesEnt row2 in QStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row2.Description;
                    li.Value = row2.ResolutionStatusesId.ToString();
                    ResolutionStatusDDL.Items.Add(li);
                }
            }

        }


        protected string GetCriteria()
        {
            string query = "";

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(ResolutionId.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.ResolutionS_ID IN (" + Regex.Replace(ResolutionId.Text, "[^0-9,]", "").Trim(',') + ")";

            }
            if (!(String.IsNullOrEmpty(NoticeDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.NOTICE_DIARY_NO = ('" + Sql(NoticeDiary.Text) + "')";

            }

            if (ResolutionStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.Resolution_STATUS=" + ResolutionStatusDDL.SelectedItem.Value;

            }

            if (ResolutionTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.Resolution_TYPE=" + ResolutionTypeDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " Resolution_MOVERS.SYSTEM_USERS_ID=" + Convert.ToInt32(HidMemberId.Value);

            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DESCRIPTION LIKE '%" + Sql(KeywordsTxt.Text) + "%'";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + Sql(DateFromTxt.Text) + "', 104)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " ResolutionS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + Sql(DateToTxt.Text) + "', 104)";

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
                string query = "SELECT DISTINCT ResolutionS.ResolutionS_ID, ResolutionS.NOTICE_DIARY_NO, ResolutionS.NOTICE_DIARY_DATE,ResolutionS.NOTICE_DIARY_TIME ,ResolutionS.SESSION_NUMBER, ResolutionS.REFFERED_SC_DATE, ResolutionS.MOVING_HOUSE_DATE, ResolutionS.DISCUSSION_DATE, ";
                query += " ResolutionS.DESCRIPTION AS Resolution_TEXT, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_DESC, Resolution_TYPES.DESCRIPTION AS Resolution_TYPE, Resolution_STATUSES.DESCRIPTION AS Resolution_STATUS, ";
                query += " ResolutionS.Resolution_TYPE AS Resolution_TYPE_ID, ResolutionS.Resolution_DIARY_NO, ResolutionS.Resolution_DIARY_DATE, ResolutionS.Resolution_DIARY_TIME, ResolutionS.Resolution_STATUS AS Resolution_STATUS_ID, ";
                query += " ResolutionS.ADMISSION_DATE, ResolutionS.PRESENT_HOUSE_DATE ";
                if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                    query += " , Resolution_MOVERS.SYSTEM_USERS_ID ";
                query += " FROM ResolutionS INNER JOIN ";
                query += " Resolution_STATUSES ON ResolutionS.Resolution_STATUS = Resolution_STATUSES.Resolution_STATUSES_ID INNER JOIN ";
                query += " Resolution_TYPES ON ResolutionS.Resolution_TYPE = Resolution_TYPES.Resolution_TYPES_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON ResolutionS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
                if (!String.IsNullOrEmpty(HidMemberId.Value) || !String.IsNullOrEmpty(MemberNameTxt.Text))
                    query += " INNER JOIN Resolution_MOVERS ON ResolutionS.ResolutionS_ID = Resolution_MOVERS.ResolutionS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                query += " AND PROCESSED=0 ORDER BY ResolutionS.NOTICE_DIARY_DATE DESC  ";
                ShowResults(new ResolutionBiz().SearchResolutions(query));
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