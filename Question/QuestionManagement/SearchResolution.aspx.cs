using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.UI;
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
            if (txt.Length >= 350 && FullTextCB.Checked == false)
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
        protected string GetMinistries(int ResolutionId)
        {
            string moverslist = "";
            List<ResolutionMinistries> resolutionMinistries = new ResolutionBiz().GetResolutionMinistries(ResolutionId);
            if (resolutionMinistries != null)
            {
                foreach (ResolutionMinistries temp in resolutionMinistries)
                {
                    moverslist += temp.MinistryName + ", ";
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
            if (date > Convert.ToDateTime("01/01/1900"))
                return date.ToShortDateString();
            else
                return string.Empty;
            //   return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.;

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
            List<ResolutionStatusesEnt> ChStatuses = new ResolutionBiz().GetResolutionStatuses();
            foreach (ResolutionStatusesEnt row3 in ChStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row3.Description;
                li.Value = row3.ResolutionStatusesId.ToString();
                ChangeStatusDDL.Items.Add(li);
            }

        }


        // Dates come from the calendar as dd/MM/yyyy; the older dd.MM.yyyy and dd-MM-yyyy typing is still accepted.
        private static readonly string[] DateFormats = { "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "d/M/yyyy", "d.M.yyyy", "d-M-yyyy" };

        private static DateTime ParseDate(string text)
        {
            DateTime date;
            if (DateTime.TryParseExact((text ?? "").Trim(), DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            return Convert.ToDateTime(text);
        }

        // The selected members arrive as a comma separated list of ids; only whole numbers are accepted.
        private string GetSelectedMemberIds()
        {
            List<string> ids = new List<string>();
            foreach (string part in (HidMemberId.Value ?? "").Split(','))
            {
                int id;
                if (int.TryParse(part.Trim(), out id) && !ids.Contains(id.ToString()))
                    ids.Add(id.ToString());
            }
            return string.Join(",", ids);
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

            if (!(String.IsNullOrEmpty(ResolutionNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.RESOLUTION_NUMBER=" + ResolutionNoTxt.Text;

            }
            //if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " RESOLUTION_SUBMITTERS.SYSTEM_USERS_ID=" + HidMemberId.Value;

            //}
            string memberIds = GetSelectedMemberIds();
            if (memberIds != "")
            {
                if (query != "")
                    query += " AND ";
                // a resolution is listed once, whichever of the selected members submitted it
                query += " RESOLUTIONS.RESOLUTIONS_ID IN (SELECT RESOLUTION_SUBMITTERS.RESOLUTIONS_ID FROM RESOLUTION_SUBMITTERS WHERE RESOLUTION_SUBMITTERS.SYSTEM_USERS_ID IN (" + memberIds + "))";

            }

            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.DESCRIPTION LIKE N'%" + KeywordsTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(NoticeDiaryNo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.NOTICE_DIARY_NO  IN (" + NoticeDiaryNo.Text + ") ";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + ParseDate(DateFromTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " RESOLUTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + ParseDate(DateToTxt.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 120)";

            }


            if (query != "")
                query += " AND ";
            query += " IS_DELETED=0 ";
            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            search();
        }
        protected void search()
        {
            string criteria = GetCriteria();
            //if (GetCriteria() == String.Empty)
            //    bindListView();
            //else
            //{
            string query = "SELECT  RESOLUTIONS.RESOLUTIONS_ID, RESOLUTIONS.NOTICE_DIARY_NO, RESOLUTIONS.NOTICE_DIARY_DATE, RESOLUTIONS.ASSEMBLY_SESSIONS_ID, RESOLUTIONS.MOVED_DATE, RESOLUTIONS.PASSED_DATE, RESOLUTIONS.DISCUSSED_DATE,RESOLUTIONS.RESOLUTION_DIARY_TIME, ";
            query += " RESOLUTIONS.DESCRIPTION, ASSEMBLY_SESSIONS.SESSION_NUMBER,RESOLUTIONS.RES_TYPES_ID, RES_TYPES.DESCRIPTION AS RESOLUTION_TYPE, RESOLUTION_STATUSES.DESCRIPTION AS RESOLUTION_STATUS,ENG_SUBJECT, DEVICE_ID, ";
            query += " RESOLUTIONS.RES_TYPES_ID AS RESOLUTION_TYPE_ID, RESOLUTIONS.RESOLUTION_DIARY_NO, RESOLUTIONS.RESOLUTION_DIARY_DATE, RESOLUTIONS.RESOLUTION_DIARY_TIME, RESOLUTIONS.RESOLUTION_STATUS AS RESOLUTION_STATUS_ID, RESOLUTIONS.IS_DELETED,CLUBED_WITH,CLUBED_RESOLUTIONS,INSERTED_BY,INSERTED_ON, DELETED_BY,DELETED_ON, RECOVERED_BY,RECOVERED_ON,UPDATED_BY,Updated_On,SENT_FOR_TRANSLATION_BY,SENT_FOR_TRANS_ON,TRANS_APPROVED_BY,TRANS_APPROVED_ON  ";
            query += " FROM RESOLUTIONS INNER JOIN ";
            query += " RESOLUTION_STATUSES ON RESOLUTIONS.RESOLUTION_STATUS = RESOLUTION_STATUSES.RESOLUTION_STATUSES_ID INNER JOIN ";
            query += " RES_TYPES ON RESOLUTIONS.RES_TYPES_ID = RES_TYPES.RES_TYPES_ID INNER JOIN ";
            query += " ASSEMBLY_SESSIONS ON RESOLUTIONS.ASSEMBLY_SESSIONS_ID = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
            if (GetCriteria() != String.Empty)
            {
                query += " WHERE ";
                query += GetCriteria();
            }
            query += " ORDER BY ASSEMBLY_SESSIONS_ID DESC, RESOLUTIONS.PASSED_DATE,RESOLUTIONS.RESOLUTION_DIARY_NO  ";
            List<ResolutionEnt> Resolutions = new ResolutionBiz().SearchResolutions(query);
            List<ResolutionEnt> FinalResolutions = new List<ResolutionEnt>();
            if (NonMuslim.Checked == true)
            {
                bool found = false;
                foreach(ResolutionEnt re in Resolutions)
                {
                    found = false;
                    foreach(ResolutionSubmittersEnt rsubmitters in re.Submitters)
                    {
                        if (rsubmitters.ReligionId != 1)
                            found = true;
                           
                    }
                    if (found == true)
                        FinalResolutions.Add(re);
                }
                ListView1.DataSource = FinalResolutions;
            }
            else
            {
                ListView1.DataSource = Resolutions;
            }
            
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
            ResolutionStatusDDL.SelectedItem.Value = "0";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            ResolutionId.Text = "";
            FullTextCB.Checked = false;

        }
        protected void ChangeStatusBtn_Click(object sender, EventArgs e)
        {
            List<int> questions = new List<int>();
            int ischecked = 0;
            foreach (ListViewItem li in ListView1.Items)
            {
                CheckBox cb = (CheckBox)li.FindControl("SelectCB");

                if (cb.Checked)
                {
                    ischecked = 1;
                    HiddenField resolutionid = (HiddenField)li.FindControl("HidResolutionId");
                    HiddenField SessionNumber = (HiddenField)li.FindControl("HidSessionId");
                    int qid = (Convert.ToInt32(resolutionid.Value));
                    int StatusId = Convert.ToInt32(ChangeStatusDDL.SelectedValue);
                    int AssemblySessionId = Convert.ToInt32(SessionNumber.Value);
                    DateTime StatusDate = ParseDate(StatusDateTxt.Text);
                    ResolutionStatusHistory sh = new ResolutionStatusHistory();
                    sh.ResolutionId = qid;
                    sh.ResolutionStatusId = StatusId;
                    sh.AssemblySessionId = AssemblySessionId;
                    sh.StatusDate = StatusDate;
                 //   new ResolutionBiz().UpdateResolutionStatus(qid, StatusId, AssemblySessionId, StatusDate);
                    //new QuestionBiz().InsertQuestionStatusHistory(sh);
                }
            }
            if (ischecked == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Satus updated Successfully')", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Resolutions')", true);
            if (String.IsNullOrEmpty(ResolutionId.Text))
                Response.Redirect("~/SearchResolution.aspx");
            else
                search();
        }
        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in ListView1.Items)
            {
                CheckBox cb = (CheckBox)li.FindControl("SelectCB");
                if (cb != null)
                {
                    if (CheckAll.Checked == true)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }
            }

        }
    }
}