using Entities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class QuestionDetails : System.Web.UI.Page
    {

        int userid = 0;
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
                ReplyDateTxt.Text = DateTime.Now.ToShortDateString();
                //DivisionTxt.Attributes.Add("onblur", "javascript:CallMe('" + DivisionTxt.ClientID + "', '" + GroupTxt.ClientID + "', '" + SessionDDL.ClientID + "', '" + HidMemberId.ClientID  + "', '" + CategoryDDL.ClientID + "')");
                BindCombos();
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                PrintUrduHL.NavigateUrl = "~/PrintUrduQuestion.aspx?questionsId=" + QuestionId;
                BindQuestion();
            }

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
        public void BindQuestion()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            string role = "";
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                role = userInfo["role"];
                if (role.Equals("Admin"))
                    deleteDiv.Visible = true;
            }
            Questions question = new QuestionBiz().GetQuestionByIdMin(QuestionId);
            string UpdatedLabelText = "";
            if (question.UpdatedBy != 0)
            {
                UpdatedLabelText = GetUserName(question.UpdatedBy);
                if (question.UpdatedOn != null && question.UpdatedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string updatedon = question.UpdatedOn.ToString();
                    UpdatedLabelText += " on " + updatedon;
                }
                UpdatedByLbl.Text = UpdatedLabelText;

            }
            string InsertLabelText = "";
            if (question.InsertedBy != 0)
            {
                InsertLabelText = GetUserName(question.InsertedBy);
                if (question.InsertedOn != null && question.InsertedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string insertedon = question.InsertedOn.ToString();
                    InsertLabelText += " on " + insertedon;
                }
                InsertedByLbl.Text = InsertLabelText;

            }



            string TranslationLabelText = "";
            if (question.SentForTranslationBy != 0)
            {
                TranslationLabelText = GetUserName(question.SentForTranslationBy);
                if (question.SentForTranslationOn != null && question.SentForTranslationOn > Convert.ToDateTime("1/1/1900"))
                {
                    string translatedon = question.SentForTranslationOn.ToString();
                    TranslationLabelText += " on " + translatedon;
                }
                SentForTransByLbl.Text = TranslationLabelText;

            }

            string ApprovedByLbl = "";
            if (question.TranslationApprovedBy != 0)
            {
                ApprovedByLbl = GetUserName(question.TranslationApprovedBy);
                if (question.TranslationApprovedOn != null && question.TranslationApprovedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string approvedon = question.TranslationApprovedOn.ToString();
                    ApprovedByLbl += " on " + approvedon;
                }
                TransApprovedByLbl.Text = ApprovedByLbl;

            }

            string DeleteLabelTxt = "";
            if (question.DeletedBy != 0)
            {
                DeleteLabelTxt = GetUserName(question.DeletedBy);
                if (question.DeletedOn != null && question.DeletedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string deletedon = question.DeletedOn.ToString();
                    DeleteLabelTxt += " on " + deletedon;
                }
                DeletedByLbl.Text = DeleteLabelTxt;

            }

            string RecoveredLabelTxt = "";
            if (question.RecoveredBy != 0)
            {
                RecoveredLabelTxt = GetUserName(question.RecoveredBy);
                if (question.RecoveredOn != null && question.RecoveredOn > Convert.ToDateTime("1/1/1900"))
                {
                    string recoverdon = question.RecoveredOn.ToString();
                    RecoveredLabelTxt += " on " + recoverdon;
                }
                RecoveredByLbl.Text = RecoveredLabelTxt;
            }
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
            if (question.FileStatusId != 0)
            {
                FileStatusDDL.SelectedValue = question.FileStatusId.ToString();
                HidFileStatus.Value = question.FileStatusId.ToString();

            }
            if (question.QuestionStatusId != 0)
            {
                QuestionStatusDDL.SelectedValue = question.QuestionStatusId.ToString();

            }
            HidMemberId.Value = question.Mover.ToString();
            HidCurrentMemberId.Value = question.Mover.ToString();
            if (question.SessionNumber != null)
            {
                SessionTxt.Text = question.SessionNumber.ToString();
                HidSessionNumber.Value = question.SessionNumberId.ToString();
            }
            NoticeDiaryNoTxt.Text = question.NoticeDiaryNo.ToString();
            QuestionIDTxt.Text = question.QuestionsId.ToString();
            QuestionDiaryNoTxt.Text = question.QuestionDiaryNo.ToString();
            MoveNoticeDiaryTxt.Text = question.NoticeDiaryNo.ToString();
            NoticeDiaryDateTxt.Text = question.NoticeDiaryDate.ToShortDateString();
            MoveNoticeDateTxt.Text = question.NoticeDiaryDate.ToShortDateString();
            NoticeDiaryTimeTxt.Text = question.NoticeDiaryTime.ToShortTimeString();
            MoveNoticeDiaryTimeTxt.Text = question.NoticeDiaryTime.ToShortTimeString();
            // QuestionDiaryDateTxt.Text = question.QuestionDate.ToShortDateString();
            HidQuestionStatusId.Value = question.QuestionStatusId.ToString();
            QuestionStatusDDL.SelectedValue = question.QuestionStatusId.ToString();
            MoveQuestionStatusDDL.SelectedValue = question.QuestionStatusId.ToString();
            CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();
            FileStatusDDL.SelectedValue = question.FileStatusId.ToString();
            if (question.DivisionId != 0)
                DivisionDDL.SelectedValue = question.DivisionId.ToString(); ;
            MemberNameTxt.Text = question.MoverName;
            HidMemberId.Value = question.Mover.ToString();
            QTxt.Value = question.QuestionText;
            OriginalTxt.Value = question.Subject;
            UrduTxt.Value = question.UrduText;
            string file = question.QuestionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file;
                HyperLink1.Text = "View File";
                HidQuestionFile.Value = file;
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }


            //  QuestionImage.ImageUrl = file;
            if (question.Priority == 1)
                PriorityCB.Checked = true;
            else
                PriorityCB.Checked = false;
            ReplyDateTxt.Text = question.ReplyDate.ToShortDateString();
            RepTxt.Value = question.Reply;
            if (ReplyDateTxt.Text == "1/01/0001")
                ReplyDateTxt.Text = "";

            BindDeferDDL(question.SessionNumberId);
            PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
            PrintOriginalHL.NavigateUrl = "~/PrintOriginalQuestion.aspx?questionsId=" + QuestionId;
            BindStatusHistory(QuestionId);
            BindRevivalHistory(QuestionId);
            BindQuestionDeferment(QuestionId);
            BindFileHistory(QuestionId);



        }
        public string GetUserName(int UserId)
        {
            User user = new ManBiz().GetUser(UserId);
            if (user != null)
            {
                return user.FullName;
            }
            return "";
        }
        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int AssemblySessionId = Convert.ToInt32(MoveAssemblySessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField DeferId = (HiddenField)DeferLv.Items[e.ItemIndex].FindControl("HidDeferId");
            int deferid = Convert.ToInt32(DeferId.Value);
            new QuestionBiz().DeleteDeferedQuestion(deferid);
            BindQuestion();
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Response.Redirect("~/QuestionDetails.aspx?QuestionsId=" + QuestionId);
        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            List<Groups> gps = null;
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            MoveGroupsDDL.Items.Clear();
            MoveGroupsDDL.Items.Add(new ListItem("Select", "0"));

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
                    MoveGroupsDDL.Items.Add(li);
                }
            }

        }
        protected void MoveGroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            MoveDivisionDDL.Items.Clear();
            MoveDivisionDDL.Items.Add(new ListItem("Select", "0"));
            int GroupId = Convert.ToInt32(MoveGroupsDDL.SelectedItem.Value);
            List<Divisions> divs2 = new List<Divisions>();
            divs2 = new AdministrationBiz().GetDivisions(GroupId);
            if (divs2 != null)
            {

                foreach (Divisions div in divs2)
                {
                    ListItem temp = new ListItem();
                    temp.Value = div.DivisionsId.ToString();
                    temp.Text = div.Description;
                    MoveDivisionDDL.Items.Add(temp);
                }
            }

        }
        public void BindDeferDDL(int SessionNumberId)
        {
            List<AssemblySessions> AsSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in AsSessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                if (Convert.ToInt32(li.Value) > SessionNumberId)
                {
                    DefferAssemblySessionDDL.Items.Add(li);
                    MoveAssemblySessionDDL.Items.Add(li);
                }

            }

        }
        public void BindCombos()
        {
            List<FileStatuses> fileStatuses = new AdministrationBiz().GetActiveFileStatuses();
            if (fileStatuses != null)
            {
                foreach (FileStatuses row in fileStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.FileStatus.ToString();
                    li.Value = row.FileStatusId.ToString();
                    FileStatusDDL.Items.Add(li);
                }
            }
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            if (ASessions != null)
            {
                foreach (AssemblySessions row in ASessions)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                }
            }

            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            if (QCats != null)
            {
                foreach (QuestionCategories row in QCats)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.QuestionCategoriesId.ToString();
                    CategoryDDL.Items.Add(li);
                }
            }

            List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            if (QStatuses != null)
            {
                foreach (QuestionStatuses row in QStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.QuestionStatusesId.ToString();
                    QuestionStatusDDL.Items.Add(li);
                    MoveQuestionStatusDDL.Items.Add(li);
                }
            }


        }
        public void BindStatusHistory(int QuestionId)
        {
            List<QuestionStatusHistory> sh = new List<QuestionStatusHistory>();
            sh = new QuestionBiz().GetQuestionStatusHistory(QuestionId);
            LVStatus.DataSource = sh;
            LVStatus.DataBind();
        }
        public void BindFileHistory(int QuestionId)
        {
            List<FileStatusHiostory> sh = new List<FileStatusHiostory>();
            sh = new QuestionBiz().GetFileStatusHistory(QuestionId);
            LVFileStatus.DataSource = sh;
            LVFileStatus.DataBind();
        }
        //public void BindMovementHistory(int QuestionId)
        //{
        //    List<QuestionMovementHistory> sh = new List<QuestionMovementHistory>();
        //    sh = new QuestionBiz().GetQuestionMovementHistory(QuestionId);
        //    LVMovement.DataSource = sh;
        //    LVMovement.DataBind();
        //}
        public void BindRevivalHistory(int QuestionId)
        {
            List<RevivalHistory> sh = new List<RevivalHistory>();
            sh = new QuestionBiz().GetQuestionRevivalHistory(QuestionId);
            LVMovement.DataSource = sh;
            LVMovement.DataBind();
        }

        public void BindQuestionDeferment(int QuestionId)
        {
            List<DeferQuestion> sh = new List<DeferQuestion>();
            sh = new QuestionBiz().GetQuestionDeferment(QuestionId);
            DeferLv.DataSource = sh;
            DeferLv.DataBind();
        }
        public string GetSession(int SessionNumber)
        {
            AssemblySessions ASession = new AssemblySessions();
            ASession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            return ASession.SessionNumber.ToString();

        }
        //protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
        //    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //    BindGroupsDDL(AssemblySessionId, CategoryId);
        //}
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

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            new QuestionBiz().DeleteQuestion(QuestionsId, userid);
            Response.Redirect("SearchQuestion.aspx");
        }
        protected void UpdateQuestion_Click(object sender, EventArgs e)
        {
            UpdateQuestion();
            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + Convert.ToInt32(QuestionIDTxt.Text));

        }
        protected void UpdateQuestion()
        {

            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            Questions question = new Questions();
            question.QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            question.SessionNumberId = Convert.ToInt32(HidSessionNumber.Value);
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            question.NoticeDiaryTime = dt;
            question.QuestionDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionStatusId = Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            question.MinistryGroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            question.DivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);
            question.FileStatusId = Convert.ToInt32(FileStatusDDL.SelectedItem.Value);
            question.Priority = (PriorityCB.Checked == true) ? 1 : 0;
            if (OriginalTxt.Value.ToString() == "")
                OriginalTxt.Value = "Contents not entered";
            else
                question.Subject = Convert.ToString(OriginalTxt.Value);
            if (QTxt.Value.ToString() == "")
                QTxt.Value = "Contents not entered";
            else
                question.QuestionText = Convert.ToString(QTxt.Value);
            if (UrduTxt.Value.ToString() == "")
                UrduTxt.Value = "Contents not entered";
            else
                question.UrduText = Convert.ToString(UrduTxt.Value);
            if (!String.IsNullOrEmpty(ReplyDateTxt.Text))
                question.ReplyDate = Convert.ToDateTime(ReplyDateTxt.Text);
            int CheckMemberQuestions = 0;
            question.Reply = Convert.ToString(RepTxt.Value);
            question.QuestionFile = HidQuestionFile.Value;
            question.UpdatedBy = userid;
            question.UpdatedOn = DateTime.Now;
            //t1.Text = RepTxt.Value;

            //CheckMemberQuestions = GetMemberQuestions(question, question.Mover);
            //if (CheckMemberQuestions == 1)
            //    errorlbl.Text = "Member already have three starred questions in this group";
            //else if (CheckMemberQuestions == 2)
            //    errorlbl.Text = "Member already have five un-starred questions in this group";

            //CheckMemberQuestions = 0;
            //int memberid = Convert.ToInt32(HidMemberId.Value);
            //CheckMemberQuestions = GetMemberQuestions(question, memberid);
            //if (CheckMemberQuestions == 1)
            //    errorlbl.Text = "Member already have three starred questions in this group";
            //else if (CheckMemberQuestions == 2)
            //    errorlbl.Text = "Member already have five un-starred questions in this group";
            //else
            //{

            errorlbl.Text = "";
            if (QuestionStatusDDL.SelectedItem.Value != HidQuestionStatusId.Value)
            {
                QuestionStatusHistory sh = new QuestionStatusHistory();
                sh.QuestionId = question.QuestionsId;
                sh.QuestionStatusId = question.QuestionStatusId;
                sh.AssemblySessionId = question.SessionNumberId;

                if (!String.IsNullOrEmpty(ReplyDateTxt.Text))
                    sh.StatusDate = Convert.ToDateTime(ReplyDateTxt.Text);
                else
                    sh.StatusDate = DateTime.Now;
                sh.InsertedBy = userid;
                sh.InsertedOn = DateTime.Now;
                question.QuestionStatusDate = DateTime.Now;
                new QuestionBiz().UpdateQuestionStatus(sh);
            }
            if (FileStatusDDL.SelectedItem.Value != HidFileStatus.Value)
            {
                FileStatusHiostory sh = new FileStatusHiostory();
                sh.QuestionsId = question.QuestionsId;
                sh.FileStatusId = question.FileStatusId;
                sh.UserId = userid;
                sh.StatusHistoryDate = DateTime.Now;
                question.QuestionStatusDate = DateTime.Now;
                new QuestionBiz().InsertFileStatusHistory(sh);
            }
            HidQuestionStatusId.Value = question.QuestionStatusId.ToString();
            new QuestionBiz().UpdateQuestions(question);

            //  BindStatusHistory(question.QuestionsId);
            //UpdateQuestionBtn.Enabled = false;
            //}
            //int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            //PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
            // BindQuestion();

            // }
        }



        public int GetMemberQuestions(Questions question, int currentmemberid)
        {
            int NumberOfQuestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(currentmemberid, question.MinistryGroupId, question.QuestionCategoriesId, question.QuestionStatusId);
            Groups gp = new QuestionBiz().GetGroupById(question.MinistryGroupId);
            if (question.QuestionCategoriesId == 1 && NumberOfQuestions >= 3 && gp.GroupSequence < 10)
                return 1;

            else if (question.QuestionCategoriesId == 2 && NumberOfQuestions >= 5 && gp.GroupSequence < 10)
                return 2;
            else
                return 0;

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
            int AssemblySessionId = Convert.ToInt32(HidSessionNumber.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId, CategoryId);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToString();

        }

        //protected void MoveQuestionBtn_Click(object sender, EventArgs e)
        //{
        //    int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
        //    //if (MoveAssemblySessionDDL.SelectedValue != "0")
        //    //{
        //    //    string questions = "";
        //    //    new QuestionBiz().MoveQuestion(Convert.ToInt32(MoveAssemblySessionDDL.SelectedValue), questions);
        //    //}
        //    Questions question = new Questions();
        //    question.PreviousQuestionId = QuestionId;
        //    question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
        //    question.PreviousSessionNumber = Convert.ToInt32(HidSessionNumber.Value);
        //    question.SessionNumberId = Convert.ToInt32(MoveAssemblySessionDDL.SelectedItem.Value);
        //    question.QuestionDiaryNo= Convert.ToInt32(MoveQuestionDiaryTxt.Text);
        //    question.NoticeDiaryNo = Convert.ToInt32(MoveNoticeDiaryTxt.Text);
        //    question.NoticeDiaryDate = Convert.ToDateTime(MoveNoticeDateTxt.Text);
        //    string str = MoveNoticeDateTxt.Text + " " + MoveNoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
        //    DateTime dt = new DateTime();
        //    DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
        //    question.NoticeDiaryTime = dt;
        //    //question.QuestionDate = Convert.ToDateTime(QuestionDiaryDateTxt.Text);
        //    question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //    question.QuestionStatusId = Convert.ToInt32(MoveQuestionStatusDDL.SelectedItem.Value);
        //    question.Mover = Convert.ToInt32(HidMemberId.Value);
        //    question.MinistryGroupId = Convert.ToInt32(MoveGroupsDDL.SelectedItem.Value);
        //    question.DivisionId = Convert.ToInt32(MoveDivisionDDL.SelectedItem.Value);
        //    question.Priority = 0;
        //    if (QTxt.Value.ToString() == "")
        //        QTxt.Value = "Contents not entered";
        //    else
        //        question.QuestionText = Convert.ToString(QTxt.Value);
        //    if(!String.IsNullOrEmpty(ReplyDateTxt.Text))
        //    question.ReplyDate = Convert.ToDateTime(ReplyDateTxt.Text);
        //    question.Reply = Convert.ToString(RepTxt.Value);
        //    //t1.Text = RepTxt.Value;
        //    int memberid = Convert.ToInt32(HidMemberId.Value);
        //    //int CheckMemberQuestions = GetMemberQuestions(question, memberid);
        //    //if (CheckMemberQuestions == 1)
        //    //    errorlbl.Text = "Member already have three starred questions in this group";
        //    //else if (CheckMemberQuestions == 2)
        //    //    errorlbl.Text = "Member already have five un-starred questions in this group";

        //    //else
        //    //{
        //        Error.Text = "";
        //        errorlbl.Text = "";
        //        if (QuestionStatusDDL.SelectedItem.Value != HidQuestionStatusId.Value || QuestionStatusDDL.SelectedItem.Value!= MoveQuestionStatusDDL.SelectedItem.Value)
        //        {
        //            QuestionStatusHistory sh = new QuestionStatusHistory();
        //            sh.QuestionId = question.QuestionsId;
        //            sh.QuestionStatusId = question.QuestionStatusId;
        //            sh.AssemblySessionId = question.SessionNumberId;
        //            sh.StatusDate = DateTime.Now;
        //            question.QuestionStatusDate = DateTime.Now;
        //            new QuestionBiz().InsertQuestionStatusHistory(sh);
        //        }
        //       // HidQuestionStatusId.Value = question.QuestionStatusId.ToString();
        //        int QID=new QuestionBiz().CopyQuestion(question);
        //      //  BindStatusHistory(question.QuestionsId);
        //       // BindMovementHistory(question.QuestionsId);
        //       // BindQuestion();
        //        //UpdateQuestionBtn.Enabled = false;
        //        //}

        //        Response.Redirect("QuestionDetails.aspx?QuestionsId=" + QID.ToString());
        //  //  }


        //}

        protected void MoveQuestionBtn_Click(object sender, EventArgs e)
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            //if (MoveAssemblySessionDDL.SelectedValue != "0")
            //{
            //    string questions = "";
            //    new QuestionBiz().MoveQuestion(Convert.ToInt32(MoveAssemblySessionDDL.SelectedValue), questions);
            //}
            Questions question = new Questions();
            question.QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            int CurrentQuestionSession = Convert.ToInt32(HidSessionNumber.Value);
            question.SessionNumberId = Convert.ToInt32(MoveAssemblySessionDDL.SelectedItem.Value);
            question.QuestionDiaryNo = Convert.ToInt32(MoveQuestionDiaryTxt.Text);
            question.NoticeDiaryNo = Convert.ToInt32(MoveNoticeDiaryTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(MoveNoticeDateTxt.Text);
            string str = MoveNoticeDateTxt.Text + " " + MoveNoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            question.NoticeDiaryTime = dt;
            //question.QuestionDate = Convert.ToDateTime(QuestionDiaryDateTxt.Text);
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionStatusId = Convert.ToInt32(MoveQuestionStatusDDL.SelectedItem.Value);
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            question.MinistryGroupId = Convert.ToInt32(MoveGroupsDDL.SelectedItem.Value);
            question.DivisionId = Convert.ToInt32(MoveDivisionDDL.SelectedItem.Value);
            question.Priority = 0;
            if (QTxt.Value.ToString() == "")
                QTxt.Value = "Contents not entered";
            else
                question.QuestionText = Convert.ToString(QTxt.Value);
            if (!String.IsNullOrEmpty(ReplyDateTxt.Text))
                question.ReplyDate = Convert.ToDateTime(ReplyDateTxt.Text);
            question.Reply = Convert.ToString(RepTxt.Value);
            //t1.Text = RepTxt.Value;
            int memberid = Convert.ToInt32(HidMemberId.Value);
            //int CheckMemberQuestions = GetMemberQuestions(question, memberid);
            //if (CheckMemberQuestions == 1)
            //    errorlbl.Text = "Member already have three starred questions in this group";
            //else if (CheckMemberQuestions == 2)
            //    errorlbl.Text = "Member already have five un-starred questions in this group";

            //else
            //{
            Error.Text = "";
            errorlbl.Text = "";
            if (QuestionStatusDDL.SelectedItem.Value != HidQuestionStatusId.Value || QuestionStatusDDL.SelectedItem.Value != MoveQuestionStatusDDL.SelectedItem.Value)
            {
                QuestionStatusHistory sh = new QuestionStatusHistory();
                sh.QuestionId = question.QuestionsId;
                sh.QuestionStatusId = question.QuestionStatusId;
                sh.AssemblySessionId = question.SessionNumberId;
                sh.StatusDate = DateTime.Now;
                sh.InsertedBy = userid;
                sh.InsertedOn = DateTime.Now;
                question.QuestionStatusDate = DateTime.Now;
                question.UpdatedBy = userid;
                question.UpdatedOn = DateTime.Now;
                new QuestionBiz().InsertQuestionStatusHistory(sh);
            }
            // HidQuestionStatusId.Value = question.QuestionStatusId.ToString();
            new QuestionBiz().MoveQuestion(CurrentQuestionSession, question);
            //  BindStatusHistory(question.QuestionsId);
            // BindMovementHistory(question.QuestionsId);
            // BindQuestion();
            //UpdateQuestionBtn.Enabled = false;
            //}

            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + QuestionId.ToString());
            //  }


        }
        protected void DeferQuestionBtn_Click(object sender, EventArgs e)
        {
            int fromsession = Convert.ToInt32(HidSessionNumber.Value);
            int tosession = Convert.ToInt32(DefferAssemblySessionDDL.SelectedItem.Value);
            string sessionname = DefferAssemblySessionDDL.SelectedItem.Text;
            int checkdeferment = new QuestionBiz().CheckQuestionDeferment(Convert.ToInt32(QuestionIDTxt.Text), tosession);
            if (checkdeferment == 1)
                Deferror.Text = "Question already deffered to this session";
            else
            {
                Deferror.Text = "";
                DeferQuestion dq = new DeferQuestion();
                dq.QuestionId = Convert.ToInt32(QuestionIDTxt.Text);
                dq.AssemblySessionId = tosession;
                dq.DeferDate = Convert.ToDateTime(DeferDateTxt.Text);
                dq.Remarks = "Deferd to " + sessionname + " on " + DeferDateTxt.Text;
                dq.InsertedBy = userid;
                dq.InsertedOn = DateTime.Now;
                new QuestionBiz().DeferQuestions(dq);
                BindQuestionDeferment(dq.QuestionId);
            }
            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + Convert.ToInt32(QuestionIDTxt.Text));

        }

        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            UpdateQuestion();
            //if (!string.IsNullOrEmpty(UrduTxt.Value))
            //{
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int QuestionId = Convert.ToInt32(QuestionIDTxt.Text);
            new QuestionBiz().SendForTranslation(QuestionId, userid);
            UrduLbl.Visible = false;
            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + Convert.ToInt32(QuestionIDTxt.Text));
            //}
            //else
            //{
            //    UrduLbl.Text = "No text found for translation";
            //    UrduLbl.Visible = true;
            //}
        }

        protected void QuestionFilesDtn_Click(object sender, EventArgs e)
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Response.Redirect("QuestionDocuments.aspx?QuestionsId=" + QuestionId);
        }
    }
}