using Entities;
using QuestionBIZ;
using System;

namespace QuestionManagement
{
    public partial class ListByMovement : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        bindListView();
        //        bindFields();

        //    }
        //}

        //private void bindListView()
        //{
        //    List<Questions> Questions = new QuestionBiz().GetQuestions(new QuestionBiz().GetCurrentAssemblySessions());
        //    ListView1.DataSource = Questions;
        //    ListView1.DataBind();


        //}
        //public string GetMinText(string txt)
        //{
        //    if (txt.Length >= 350)
        //        return txt.Substring(0, 350).Trim() + ".................";
        //    else
        //        return txt;

        //}
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        //private void bindFields()
        //{
        //    AssemblySessions ASession = new QuestionBiz().GetCurrentAssemblySessionDetails();
        //    SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
        //    List<AssemblySessions> ASessions = new QuestionBiz().GetAssemblySessions();
        //    foreach (AssemblySessions row in ASessions)
        //    {
        //        ListItem li = new ListItem();
        //        li.Text = row.SessionNumber.ToString();
        //        li.Value = row.AssemblySessionsId.ToString();
        //        FromAssemblySessionDDL.Items.Add(li);
        //        ToAssemblySessionDDL.Items.Add(li);
        //        if (row.AssemblySessionsId == ASession.AssemblySessionsId)
        //            SessionMovementDDL.Items.Add(li);
        //    }
        //    List<QuestionCategories> QCats = new QuestionBiz().GetQuestionCategories();
        //    foreach (QuestionCategories row in QCats)
        //    {
        //        ListItem li = new ListItem();
        //        li.Text = row.Description;
        //        li.Value = row.QuestionCategoriesId.ToString();
        //        CategoryDDL.Items.Add(li);
        //    }



        //    List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionActiveStatus();
        //    foreach (QuestionStatuses row in QStatuses)
        //    {
        //        ListItem li = new ListItem();
        //        li.Text = row.Description;
        //        li.Value = row.QuestionStatusesId.ToString();
        //        QuestionStatusDDL.Items.Add(li);
        //    }

        //}

        //protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int AssemblySessionId = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
        //    BindGroupsDDL(AssemblySessionId);
        //}
        //public void BindGroupsDDL(int AssemblySessionId)
        //{
        //    List<Groups> gps = null;
        //    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //    gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
        //    GroupsDDL.Items.Clear();
        //    GroupsDDL.Items.Add(new ListItem("Select", "0"));

        //    if (gps != null)
        //    {

        //        foreach (Groups obj in gps)
        //        {
        //            ListItem li = new ListItem();
        //            li.Value = obj.GroupsId.ToString();
        //            if (CategoryId == 2)
        //                li.Text = obj.UnstarDesc;
        //            else
        //                li.Text = obj.Description;
        //            GroupsDDL.Items.Add(li);
        //        }
        //    }
        //}
        ////protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    GroupsDDL.Items.Clear();
        ////    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        ////    List<Groups> gps = new QuestionBiz().GetSessionGroups(Convert.ToInt32(AssemblySessionDDL.SelectedItem.Value),CategoryId);
        ////    foreach(Groups obj in gps)
        ////    {
        ////        ListItem li = new ListItem();
        ////        li.Value = obj.GroupsId.ToString();
        ////        li.Text = obj.Description;
        ////        GroupsDDL.Items.Add(li);
        ////    }

        ////}
        //protected string GetCriteria()
        //{
        //    string query = "";
        //    //if (!(String.IsNullOrEmpty(Sess.Text)))
        //    //{
        //    //    if (query != "")
        //    //        query += " AND ";
        //    //    query += " emp_employments.file_no like '" + FileNoTxt.Text + "%'";

        //    //}
        //    if (!(String.IsNullOrEmpty(QuestionId.Text)))
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTIONS.QUESTIONS_ID IN (" + QuestionId.Text + ")";

        //    }
        //    if (FromAssemblySessionDDL.SelectedItem.Value != "0")
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTIONS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

        //    }
        //    if (QuestionStatusDDL.SelectedItem.Value != "0")
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTIONS.QUESTION_STATUS=" + QuestionStatusDDL.SelectedItem.Value;

        //    }
        //    if (ToAssemblySessionDDL.SelectedItem.Value != "0")
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTIONS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

        //    }
        //    if (CategoryDDL.SelectedItem.Value != "0")
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTION_CATEGORY=" + CategoryDDL.SelectedItem.Value;

        //    }
        //    if (GroupsDDL.SelectedItem.Value != "0")
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += "  MINISTRY_GROUP=" + GroupsDDL.SelectedItem.Value;

        //    }
        //    if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " MOVER=" + HidMemberId.Value;

        //    }
        //    if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTION_TEXT LIKE '%" + KeywordsTxt.Text + "%' OR SUBJECT LIKE '%" + KeywordsTxt.Text + "%'";

        //    }
        //    if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTION_DATE>=CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104)";

        //    }
        //    if (!(String.IsNullOrEmpty(DateToTxt.Text)))
        //    {
        //        if (query != "")
        //            query += " AND ";
        //        query += " QUESTION_DATE<=CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)";

        //    }


        //    return query;

        //}

        //protected void Search_Click(object sender, EventArgs e)
        //{
        //    string query = "SELECT QUESTIONS.QUESTIONS_ID, QUESTIONS.PARLIAMENTARY_YEAR, QUESTIONS.MOVER, QUESTIONS.QUESTION_CATEGORY, QUESTIONS.QUESTION_DATE, QUESTIONS.QUESTION_TIME, QUESTIONS.SUBJECT, ";
        //    query += " QUESTIONS.QUESTION_TEXT, QUESTIONS.MINISTRY, QUESTIONS.MINISTRY_GROUP, QUESTIONS.DIVISION, QUESTIONS.DEPARTMENTS_ID, QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE,  ";
        //    query += " QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.ADMITTED_NUMBER,QUESTIONS.IS_CARRY_FWD, QUESTIONS.QUESTION_DIARY_NO, QUESTIONS.QUESTION_DIARY_DATE, QUESTIONS.QUESTION_DIARY_TIME, QUESTIONS.SESSION_NUMBER,  ";
        //    query += " QUESTIONS.SESSION_SITTINGS_ID, SYSTEM_USERS.F_NAME, QUESTION_STATUSES.DESCRIPTION AS QUESTION_STATUS, QUESTION_CATEGORIES.DESCRIPTION AS CATEGORY,ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME  ";
        //    query += " FROM QUESTIONS INNER JOIN  ";
        //    query += " QUESTION_CATEGORIES ON QUESTIONS.QUESTION_CATEGORY = QUESTION_CATEGORIES.QUESTION_CATEGORIES_ID INNER JOIN  ";
        //    query += " QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN  ";
        //    query += " SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
        //    query += " ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
        //    if (GetCriteria() != String.Empty)
        //    {
        //        query += " WHERE ";
        //        query += GetCriteria();
        //    }
        //    query += " ORDER BY QUESTIONS.NOTICE_DIARY_DATE DESC,QUESTIONS.NOTICE_DIARY_TIME DESC  ";
        //    List<Questions> Questions = new QuestionBiz().SearchQuestion(query);
        //    ListView1.DataSource = Questions;
        //    ListView1.DataBind();

        //}
        //protected void ClearSearch_Click(object sender, EventArgs e)
        //{
        //    bindListView();

        //}

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
        //    foreach (ListViewItem a in ListView1.Items)
        //    {

        //        CheckBox cb = a.FindControl("SelectCB") as CheckBox;
        //        if (SelectAll.Checked == true)
        //            cb.Checked = true;
        //        else
        //            cb.Checked = false;
        //    }

        //}

        ////protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    GroupsDDL.Items.Clear();
        ////    int AssemblySessionId = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
        ////    BindGroupsDDL(AssemblySessionId);

        ////}

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
        //                    cf.FromSession = Convert.ToInt32(SessionNumber.Value);
        //                    cf.ToSession = Convert.ToInt32(SessionMovementDDL.SelectedItem.Value);
        //                    cf.CarryFwdDate = DateTime.Now;
        //                    new QuestionBiz().CaryFwdQuestion(cf);


        //                }
        //            }
        //        }
        //    }
        //}

    }
}