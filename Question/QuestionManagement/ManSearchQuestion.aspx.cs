using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManSearchQuestion : System.Web.UI.Page
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
            List<Questions> Questions = new QuestionBiz().GetQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Questions;
            ListView1.DataBind();


        }

        public string GetLink(string QuestionId)
        {
            string link = "~/QuestionDetails.aspx?QuestionsId=" + QuestionId;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                string role = Convert.ToString(userInfo["role"]);
                if (role.Equals("SO"))
                    link = "~/QuestionDetailsRest.aspx?QuestionsId=" + QuestionId;
            }
            return link;

        }
        public string GetListNo(int ListNo, string SupNo)
        {
            if (SupNo != "Z")
            {
                return ListNo + "-" + SupNo;
            }
            return ListNo.ToString();

        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, @"<[^>]+>|&nbsp;", "").Trim();
            if (txt.Length >= 350 && FullTextCB.Checked == false)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
            return text;

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
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }
        private void bindFields()
        {
            List<FileStatuses> fileStatuses = new AdministrationBiz().GetFileStatuses();
            FileStatusDDl.Items.Add(new ListItem("Select", "0"));
            foreach (FileStatuses row in fileStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row.FileStatus.ToString();
                li.Value = row.FileStatusId.ToString();
                FileStatusDDl.Items.Add(li);
            }
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

            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }



            List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            foreach (QuestionStatuses row in QStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionStatusesId.ToString();
                QuestionStatusDDL.Items.Add(li);
            }

            List<QuestionStatuses> ChStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            foreach (QuestionStatuses items in ChStatuses)
            {
                ListItem li = new ListItem();
                li.Text = items.Description;
                li.Value = items.QuestionStatusesId.ToString();
                ChangeStatusDDL.Items.Add(li);
            }

        }

        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);
        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            List<Groups> gps = null;
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            GroupsDDL.Items.Clear();
            GroupsDDL.Items.Add(new ListItem("Select", "0"));

            if (gps != null)
            {

                foreach (Groups obj in gps)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.GroupsId.ToString();
                    if (CategoryId == 2)
                        li.Text = obj.UnstarDesc;
                    else
                        li.Text = obj.Description;
                    GroupsDDL.Items.Add(li);
                }
            }
        }
        //protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GroupsDDL.Items.Clear();
        //    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //    List<Groups> gps = new QuestionBiz().GetSessionGroups(Convert.ToInt32(AssemblySessionDDL.SelectedItem.Value),CategoryId);
        //    foreach(Groups obj in gps)
        //    {
        //        ListItem li = new ListItem();
        //        li.Value = obj.GroupsId.ToString();
        //        li.Text = obj.Description;
        //        GroupsDDL.Items.Add(li);
        //    }

        //}
        protected string GetCriteria()
        {
            string query = "";

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (GenderDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " SYSTEM_USERS.GENDER=" + GenderDDL.SelectedItem.Value;

            }
            if (ReligionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " SYSTEM_USERS.RELIGIONS_ID=" + ReligionDDL.SelectedItem.Value;

            }
            if (NotReligionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " SYSTEM_USERS.RELIGIONS_ID<>" + NotReligionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (FileStatusDDl.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.FILE_STATUS_ID=" + FileStatusDDl.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(QuestionId.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.QUESTIONS_ID IN (" + QuestionId.Text + ")";

            }
            if (!(String.IsNullOrEmpty(QuestionDiary.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.QUESTION_DIARY_NO = ('" + QuestionDiary.Text + "')";

            }

            if (QuestionStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.QUESTION_STATUS=" + QuestionStatusDDL.SelectedItem.Value;

            }

            if (CategoryDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTION_CATEGORY=" + CategoryDDL.SelectedItem.Value;

            }
            if (GroupsDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += "(GROUPS.GROUP_SEQUENCE = (SELECT GROUP_SEQUENCE FROM GROUPS AS GROUPS_1 WHERE (GROUPS_ID = " + GroupsDDL.SelectedItem.Value + ")))";
                // query += "  MINISTRY_GROUP=" + GroupsDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " MOVER IN(" + HidMemberId.Value.Trim(',') + ")";

            }
            if (!(String.IsNullOrEmpty(DivisionTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DIVISION=" + HidDivisionId.Value;

            }
            if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                if (ExactMatchCB.Checked == true)
                {
                    query += " (LOWER(QUESTION_TEXT) LIKE '%" + " " + KeywordsTxt.Text.ToLower() + " " + " %' COLLATE SQL_Latin1_General_CP1_CS_AS ";
                    query += " OR LOWER(SUBJECT) LIKE '%" + " " + KeywordsTxt.Text.ToLower() + " " + "%' COLLATE SQL_Latin1_General_CP1_CS_AS) ";
                }
                else
                    query += " (QUESTION_TEXT LIKE '%" + KeywordsTxt.Text + "%' OR SUBJECT LIKE '%" + KeywordsTxt.Text + "%')";

            }
            if (!(String.IsNullOrEmpty(NoticeDiaryNo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.NOTICE_DIARY_NO  IN (" + NoticeDiaryNo.Text + ") ";

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104)";

            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)";

            }
            if (CoallitionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " COALITIONS.COALITIONS_ID = " + CoallitionDDL.SelectedItem.Value;

            }

            if (query != "")
                query += " AND ";
            query += " IS_DELETED=0 AND PROCESSED=1 ";
            return query;

        }
        protected void search()
        {
            string criteria = GetCriteria();
            if (GetCriteria() == String.Empty)
                bindListView();
            else
            {
                string query = "SELECT QUESTIONS.QUESTIONS_ID,QUESTIONS.LIST_NO,QUESTIONS.SUP_NO, QUESTIONS.PARLIAMENTARY_YEAR, QUESTIONS.MOVER, QUESTIONS.QUESTION_CATEGORY,QUESTIONS.STATUS_DATE, QUESTIONS.QUESTION_DATE, QUESTIONS.QUESTION_TIME, QUESTIONS.SUBJECT, ";
                query += " QUESTIONS.QUESTION_TEXT, QUESTIONS.MINISTRY, QUESTIONS.MINISTRY_GROUP, QUESTIONS.DIVISION,DIVISIONS.DESCRIPTION AS DIVISION_NAME, QUESTIONS.DEPARTMENTS_ID, QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE, QUESTIONS.REPLY_DATE,  ";
                query += " QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.ADMITTED_NUMBER,QUESTIONS.IS_CARRY_FWD, QUESTIONS.QUESTION_DIARY_NO, QUESTIONS.QUESTION_DIARY_DATE, QUESTIONS.QUESTION_DIARY_TIME, QUESTIONS.SESSION_NUMBER,  ";
                query += " QUESTIONS.SESSION_SITTINGS_ID, CONCAT(SYSTEM_USERS.F_NAME,' ' ,SYSTEM_USERS.M_NAME,' ',SYSTEM_USERS.L_NAME) AS F_NAME, QUESTION_STATUSES.DESCRIPTION AS QUESTION_STATUS, QUESTION_CATEGORIES.DESCRIPTION AS CATEGORY,ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME,GROUPS.GROUP_SEQUENCE,QUESTIONS.DELETED_BY,QUESTIONS.DELETION_DATE   ";
                query += ", COALITIONS.COALITIONS_ID,POLITICAL_PARTIES.DESCRIPTION AS POLITICAL_PARTY_DESC, MEMBERS.POLITICAL_PARTY, COALITIONS.DESCRIPTION AS COALLITION_DESC";
                query += " FROM QUESTIONS INNER JOIN  ";
                query += " QUESTION_CATEGORIES ON QUESTIONS.QUESTION_CATEGORY = QUESTION_CATEGORIES.QUESTION_CATEGORIES_ID INNER JOIN  ";
                query += " QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN  ";
                query += " DIVISIONS ON QUESTIONS.DIVISION = DIVISIONS.DIVISIONS_ID INNER JOIN  ";
                query += " SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID INNER JOIN ";
                query += " MEMBERS ON SYSTEM_USERS.SYSTEM_USERS_ID = MEMBERS.SYSTEM_USERS_ID INNER JOIN ";
                query += " POLITICAL_PARTIES ON MEMBERS.POLITICAL_PARTY = POLITICAL_PARTIES.POLITICAL_PARTIES_ID INNER JOIN ";
                query += " COALITIONS ON POLITICAL_PARTIES.COALITIONS_ID = COALITIONS.COALITIONS_ID INNER JOIN";
                query += " GROUPS ON QUESTIONS.MINISTRY_GROUP = GROUPS.GROUPS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                // query += " ORDER BY QUESTIONS.REPLY_DATE  ";
                query += " ORDER BY QUESTIONS.NOTICE_DIARY_DATE DESC,QUESTIONS.NOTICE_DIARY_TIME,QUESTIONS.NOTICE_DIARY_NO  ";
                List<Questions> Questions = new QuestionBiz().SearchQuestion(query);
                ListView1.DataSource = Questions;
                ListView1.DataBind();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string membersid = HidMemberId.Value;

            search();
            // HidMemberId.Value = "";
            // MemberNameTxt.Text = "";
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

        //protected void SelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    int items = ListView1.Items.Count - 1;
        //    foreach(ListViewItem a in ListView1.Items)
        //    {

        //        CheckBox cb = a.FindControl("SelectCB") as CheckBox;
        //        if (SelectAll.Checked == true)
        //            cb.Checked = true;
        //        else
        //            cb.Checked = false;
        //    }

        //}

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupsDDL.Items.Clear();
            int AssemblySessionId = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FromAssemblySessionDDL.SelectedItem.Value = "0";
            ToAssemblySessionDDL.SelectedItem.Value = "0";
            CategoryDDL.SelectedItem.Value = "0";
            GroupsDDL.SelectedItem.Value = "0";
            QuestionStatusDDL.SelectedItem.Value = "0";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            QuestionId.Text = "";

        }

        protected void ChangeStatusBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ischecked = 0;
            List<int> questions = new List<int>();
            foreach (ListViewItem li in ListView1.Items)
            {
                CheckBox cb = (CheckBox)li.FindControl("SelectCB");

                if (cb.Checked)
                {
                    ischecked = 1;
                    HiddenField questionid = (HiddenField)li.FindControl("HidQuestionId");
                    HiddenField SessionNumber = (HiddenField)li.FindControl("HidSessionId");
                    int qid = (Convert.ToInt32(questionid.Value));
                    int StatusId = Convert.ToInt32(ChangeStatusDDL.SelectedValue);
                    int AssemblySessionId = Convert.ToInt32(SessionNumber.Value);
                    DateTime StatusDate = Convert.ToDateTime(StatusDateTxt.Text);
                    QuestionStatusHistory sh = new QuestionStatusHistory();
                    sh.QuestionId = qid;
                    sh.QuestionStatusId = StatusId;
                    sh.AssemblySessionId = AssemblySessionId;
                    sh.StatusDate = StatusDate;
                    sh.InsertedBy = userid;
                    sh.InsertedOn = DateTime.Now;
                    new QuestionBiz().UpdateQuestionStatus(sh);
                    //new QuestionBiz().InsertQuestionStatusHistory(sh);
                }
            }

            search();
            if (ischecked == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Questions Satus updated Successfully')", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Question')", true);
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (SessionMovementDDL.SelectedValue != "0")
        //    {
        //        foreach (ListViewDataItem item in ListView1.Items)
        //        {
        //            CheckBox checkslct = item.FindControl("SelectCB") as CheckBox;
        //            if (checkslct != null)
        //            {
        //                if (checkslct.Checked)
        //                {
        //                    CarryForward cf = new CarryForward();
        //                    HiddenField QuestionId = item.FindControl("HidQuestionId") as HiddenField;
        //                    HiddenField SessionNumber = item.FindControl("HidSessionId") as HiddenField;
        //                    cf.QuestionId = Convert.ToInt32(QuestionId.Value);
        //                    cf.FromSession= Convert.ToInt32(SessionNumber.Value);
        //                    cf.ToSession= Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
        //                    cf.CarryFwdDate = DateTime.Now;
        //                    new QuestionBiz().CaryFwdQuestion(cf);


        //                }
        //            }
        //        }
        //    }
        //}
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