using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ViewQuestion : System.Web.UI.Page
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
                //DivisionTxt.Attributes.Add("onblur", "javascript:CallMe('" + DivisionTxt.ClientID + "', '" + GroupTxt.ClientID + "', '" + SessionDDL.ClientID + "', '" + HidMemberId.ClientID  + "', '" + CategoryDDL.ClientID + "')");
                BindCombos();

            }
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            BindQuestion(QuestionId);
        }
        [System.Web.Services.WebMethod]
        public string GetContactName(int divisionid, int assemblysessionid, int moverid, int CategoryId)
        {
            //int divisionid = Convert.ToInt32(HidDivisionId.Value);
            //int moverid = Convert.ToInt32(HidMemberId.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //int assemblysessionid = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);
            int groupid = 0;
            foreach (DivisionGroups obj in dgs)
            {
                int numberofquestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(moverid, obj.GroupId, CategoryId, 3);
                if (CategoryId == 1 && numberofquestions < 3 && obj.GroupSequence <= 10 && groupid == 0)
                {
                    groupid = obj.GroupId;
                }
                if (CategoryId == 2 && numberofquestions < 5 && obj.GroupSequence <= 5 && groupid == 0)
                {
                    groupid = obj.GroupId;
                }
                if (groupid == 0 && obj.GroupSequence > 10)
                    groupid = obj.GroupId;

            }
            Groups gp = new QuestionBiz().GetGroupById(groupid);
            //GroupTxt.Text = gp.Description;
            //HidGroupId.Value = gp.GroupsId.ToString();
            return gp.Description;
            //if (custid == null || custid.Length == 0)
            //    return String.Empty;
            ////SqlConnection conn = null;
            //try
            //{
            //    //string connection = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            //    //conn = new SqlConnection(connection);
            //    //string sql = "Select ContactName from Customers where CustomerId = @CustID";
            //    //SqlCommand cmd = new SqlCommand(sql, conn);
            //    //cmd.Parameters.AddWithValue("CustID", custid);
            //    //conn.Open();
            //    //string contNm = Convert.ToString(cmd.ExecuteScalar());
            //    //return contNm;
            //    return "Masood";
            //}
            //catch (SqlException ex)
            //{
            //    return "error";
            //}
            //finally
            //{
            //    //conn.Close();
            //}
        }
        public void BindQuestion(int QuestionId)
        {
            Questions question = new QuestionBiz().GetQuestionById(QuestionId);
            if (question.SessionNumberId != 0)
            {
                BindGroupsDDL(question.SessionNumberId, question.QuestionCategoriesId);
                GroupDDL.SelectedValue = question.MinistryGroupId.ToString();

            }
            if (question.DivisionId != 0)
            {
                BindDivisionDDL(question.MinistryGroupId);
                DivisionDDL.SelectedValue = question.DivisionId.ToString();

            }
            if (question.QuestionCategoriesId != 0)
            {
                CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();

            }
            if (question.QuestionStatusId != 0)
            {
                QuestionStatusDDL.SelectedValue = question.QuestionStatusId.ToString();

            }
            HidMemberId.Value = question.Mover.ToString();
            SessionDDL.SelectedValue = question.SessionNumberId.ToString();
            NoticeDiaryNoTxt.Text = question.NoticeDiaryNo.ToString();
            NoticeDiaryDateTxt.Text = question.NoticeDiaryDate.ToShortDateString();
            NoticeDiaryTimeTxt.Text = question.NoticeDiaryTime.ToString();
            QuestionDiaryNoTxt.Text = question.QuestionsId.ToString();
            QuestionDiaryDateTxt.Text = question.QuestionDiaryDate.ToShortDateString();
            QuestionStatusDDL.SelectedValue = question.QuestionStatusId.ToString();
            CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();
            MemberNameTxt.Text = question.MoverName;
            HidMemberId.Value = question.Mover.ToString();
            QTxt.Value = question.QuestionText;
            if (String.Compare("01/01/0001 12:00:00 AM", question.ReplyDate.ToString()) != 0)
                ReplyDateTxt.Text = question.ReplyDate.ToString();
            RepTxt.Value = "Some Text";// question.Reply;



        }
        public void BindCombos()
        {

            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionDDL.Items.Add(li);
            }
            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }

            List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionStatuses();
            foreach (QuestionStatuses row in QStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionStatusesId.ToString();
                QuestionStatusDDL.Items.Add(li);
            }


        }

        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId, CategoryId);
        }
        public void BindGroupsDDL(int AssemblySessionId, int CategoryId)
        {
            List<Groups> gps = null;
            gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            GroupDDL.Items.Clear();
            GroupDDL.Items.Add(new ListItem("Select", "0"));

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
                    GroupDDL.Items.Add(li);
                }
            }

        }


        protected void UpdateQuestion_Click(object sender, EventArgs e)
        {
            Questions question = new Questions();
            question.QuestionsId = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            question.SessionNumberId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            question.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            question.QuestionDate = Convert.ToDateTime(QuestionDiaryDateTxt.Text);
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionStatusId = Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            question.MinistryGroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            question.DivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);
            if (QTxt.Value.ToString() == "")
                QTxt.Value = "Contents not entered";
            else
                question.QuestionText = Convert.ToString(QTxt.Value);
            question.ReplyDate = Convert.ToDateTime(ReplyDateTxt.Text);
            question.Reply = Convert.ToString(RepTxt.Value);
            t1.Text = RepTxt.Value;
            //    new QuestionBiz().UpdateQuestions(question);
            //   UpdateQuestionBtn.Enabled = false;
        }

        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            int GroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            BindDivisionDDL(GroupId);
            //int MemberId = 0;
            //string category = "";
            //if (hfCustomerId.Value != "")
            //    MemberId = Convert.ToInt32(hfCustomerId.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //category = CategoryDDL.SelectedItem.Text.ToString();
            //NoOfQuestionsTxt.Text = category + ": " + new QuestionBiz().GetMemberGroupQuestions(MemberId, GroupId, CategoryId).ToString();

        }
        public void BindDivisionDDL(int GroupId)
        {

            DivisionDDL.Items.Clear();
            DivisionDDL.Items.Add(new ListItem("Select", "0"));
            List<Divisions> divs = new List<Divisions>();
            divs = new AdministrationBiz().GetDivisions(GroupId);
            if (divs != null)
            {

                foreach (Divisions div in divs)
                {
                    ListItem temp = new ListItem();
                    temp.Value = div.DivisionsId.ToString();
                    temp.Text = div.Description;
                    DivisionDDL.Items.Add(temp);
                }
            }

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void txtSearch_TextChanged1(object sender, EventArgs e)
        //{
        //    NoOfQuestionsTxt.Text = "";
        //}

        protected void CheckGroupBtn_Click(object sender, EventArgs e)
        {
            AssignGroup();
        }
        public void AssignGroup()
        {
            // int divisionid = Convert.ToInt32(HidDivisionId.Value);
            // int moverid = Convert.ToInt32(HidMemberId.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //int assemblysessionid = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            //List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);
            //int groupid = 0;
            //foreach (DivisionGroups obj in dgs)
            //{
            //    int numberofquestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(moverid, obj.GroupId, CategoryId, 3);
            //    if (CategoryId == 1 && numberofquestions < 3 && obj.GroupSequence <= 10 && groupid == 0)
            //    {
            //        groupid = obj.GroupId;
            //    }
            //    if (CategoryId == 2 && numberofquestions < 5 && obj.GroupSequence <= 5 && groupid == 0)
            //    {
            //        groupid = obj.GroupId;
            //    }
            //    if (groupid == 0 && obj.GroupSequence > 10)
            //        groupid = obj.GroupId;

            //}
            //Groups gp = new QuestionBiz().GetGroupById(groupid);
            //GroupTxt.Text = gp.Description;
            //HidGroupId.Value = gp.GroupsId.ToString();
            //return gp.Description;
            ////GroupDDL.SelectedValue = groupid.ToString();
        }
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId, CategoryId);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
    }
}