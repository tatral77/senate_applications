using Entities;
using ManBIZ;
using ManEntities;
//using MODI;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NewQuestion1 : System.Web.UI.Page
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
                //  NoticeDiaryDateTxt.Text = DateTime.Now.ToShortDateString();
                //QuestionDiaryDateTxt.Text = DateTime.Now.ToShortDateString();
                BindCombos();
                AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                //SessionTxt.Text = ASession.SessionNumber.ToString();
                //HidSessionNumber.Value = ASession.AssemblySessionsId.ToString();
                // BindGroupsDDL(ASession.AssemblySessionsId);
                // NoticeDiaryNoTxt.Focus();

            }
            //PrintHL.Enabled = false;
        }
        public void BindCombos()
        {


            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                AssemblySessionDDL.Items.Add(li);
            }
            AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
            AssemblySessionDDL.SelectedValue = ASession.AssemblySessionsId.ToString();
            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }

            //List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionStatus();
            //foreach (QuestionStatuses row in QStatuses)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.QuestionStatusesId.ToString();
            //    QuestionStatusDDL.Items.Add(li);
            //}
            //QuestionStatusDDL.SelectedValue = "7";
        }

        protected void DivisionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //QuestionTxt.Value = "<p align='justify'>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspWill the Minister for " + DivisionDDL.SelectedItem.Text + " be pleased to state:</p><p align='justify'>";
            //QuestionTxt.Focus();
        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            //List<Groups> gps = null;
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            //GroupDDL.Items.Clear();
            //GroupDDL.Items.Add(new ListItem("Select", "0"));

            //if (gps != null)
            //{

            //    foreach (Groups obj in gps)
            //    {
            //        ListItem li = new ListItem();
            //        li.Value = obj.GroupsId.ToString();
            //        if (CategoryId == 2)
            //            li.Text = obj.UnstarDesc;
            //        else
            //            li.Text = obj.Description;
            //        GroupDDL.Items.Add(li);
            //    }
            //}

        }
        public void InsertQuestion()
        {
            //DateTime notcedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            //if (notcedate > DateTime.Now || notcedate < DateTime.Now.AddDays(-30))
            //{
            //    DateError.Text = "Notice date must within 30 days and not greater than from current date.";
            //}
            //else
            //{
            //    DateError.Text = "";
            //    int id = 0;
            //    Questions question = new Questions();
            //    question.SessionNumberId = Convert.ToInt32(HidSessionNumber.Value);
            //    question.QuestionDiaryNo= Convert.ToInt32(QuestionDiaryNoTxt.Text);
            //    question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            //    question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            //    DateTime noticedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            //    String datetime = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;
            //    //DateTime noticetime = DateTime.ParseExact(datetime,
            //    //                      "dd.MM.yyyy HH:mm",
            //    //                      CultureInfo.InvariantCulture);
            //    string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            //    DateTime dt = new DateTime();
            //    DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            //    question.NoticeDiaryTime = dt;
            //    question.QuestionDate = noticedate;
            //    question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //    question.QuestionStatusId = 7;// Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
            //    question.Mover = Convert.ToInt32(HidMemberId.Value);
            //    question.MinistryGroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            //    question.DivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);

            //    if (QuestionTxt.Value.ToString() == "")
            //        QuestionTxt.Value = "Contents not entered";
            //    else
            //        question.QuestionText = Convert.ToString(QuestionTxt.Value);

            //    int NumberOfQuestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(question.Mover, question.MinistryGroupId, question.QuestionCategoriesId, question.QuestionStatusId);
            //    Groups gp = new QuestionBiz().GetGroupById(question.MinistryGroupId);
            //    if (question.QuestionCategoriesId == 1 && NumberOfQuestions >= 3 && gp.GroupSequence < 10)
            //        Error.Text = "Member already have three starred questions in this group";
            //    else if (question.QuestionCategoriesId == 2 && NumberOfQuestions >= 5 && gp.GroupSequence < 10)
            //        Error.Text = "Member already have five un-starred questions in this group";
            //    else
            //    {
            //        Error.Text = "";
            //        id = new QuestionBiz().InsertQuestions(question);
            //        QuestionIDTxt.Text = id.ToString();
            //        Button1.Enabled = false;
            //        return id;
            //        //PrintBtn.Enabled = true;
            //    }

            //}
            //return 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            int userid = 0;
            User user = null;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
                int roleid = Convert.ToInt32(userInfo["roleid"]);

                user = new ManBiz().GetUser(userid);
            }
            //DateTime notcedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            //if (notcedate > DateTime.Now || notcedate < DateTime.Now.AddDays(-30))
            //{
            //    DateError.Text = "Notice date must within 30 days and not greater than from current date.";
            //}
            //else
            //{
            //    DateError.Text = "";

            Questions question = new Questions();
            question.QuestionsId = Convert.ToInt32(QuestionIdTxt.Text);
            question.SessionNumberId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            DateTime noticedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            String datetime = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;
            //DateTime noticetime = DateTime.ParseExact(datetime,
            //                      "dd.MM.yyyy HH:mm",
            //                      CultureInfo.InvariantCulture);
            string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            question.NoticeDiaryTime = dt;
            question.QuestionDate = noticedate;
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionStatusId = 7;// Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
            question.QuestionStatusDate = DateTime.Now;
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            question.InsertedBy = Convert.ToInt32(userid);
            question.FileStatusId = 1;
            //question.MinistryGroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            question.DivisionId = Convert.ToInt32(HidDivisionId.Value);

            if (QuestionTxt.Value.ToString() == "")
                QuestionTxt.Value = "Contents not entered";
            else
                question.QuestionText = Convert.ToString(QuestionTxt.Value);
            if (UrduTxt.Value.ToString() == "")
                UrduTxt.Value = "Contents not entered";
            else
                question.UrduText = Convert.ToString(UrduTxt.Value);
            question.MinistryGroupId = AssignGroup();
            //int NumberOfQuestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(question.Mover, question.MinistryGroupId, question.QuestionCategoriesId, question.QuestionStatusId);
            //Groups gp = new QuestionBiz().GetGroupById(question.MinistryGroupId);
            //if (question.QuestionCategoriesId == 1 && NumberOfQuestions >= 3 && gp.GroupSequence < 10)
            //    Error.Text = "Member already have three starred questions in this group";
            //else if (question.QuestionCategoriesId == 2 && NumberOfQuestions >= 5 && gp.GroupSequence < 10)
            //    Error.Text = "Member already have five un-starred questions in this group";
            //else
            //{
            //    Error.Text = "";
            id = new QuestionBiz().InsertQuestions(question);
            //QuestionIDTxt.Text = id.ToString();

            Button1.Enabled = false;
            Response.Redirect("~/QuestionDetails.aspx?QuestionsId=" + question.QuestionsId);

            //}

            //  }



        }

        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DivisionDDL.Items.Clear();
            //DivisionDDL.Items.Add(new ListItem("Select", "0"));
            //int GroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            //List<Divisions> divs = new List<Divisions>();
            //divs = new AdministrationBiz().GetDivisions(GroupId);
            //if (divs != null)
            //{

            //    foreach (Divisions div in divs)
            //    {
            //        ListItem temp = new ListItem();
            //        temp.Value = div.DivisionsId.ToString();
            //        temp.Text = div.Description;
            //        DivisionDDL.Items.Add(temp);
            //    }
            //}

            //int MemberId = 0;
            //string category = "";
            //if (HidMemberId.Value != "")
            //    MemberId = Convert.ToInt32(HidMemberId.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //category = CategoryDDL.SelectedItem.Text.ToString();
            //DivisionDDL.Focus();
            //  NoOfQuestionsTxt.Text = category + ": " + new QuestionBiz().GetMemberGroupQuestions(MemberId, GroupId, CategoryId).ToString();

        }
        protected int AssignGroup()
        {
            int divisionid = Convert.ToInt32(HidDivisionId.Value);
            int moverid = Convert.ToInt32(HidMemberId.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //  int assemblysessionid = Convert.ToInt32(HidSessionNumber.Value);
            int assemblysessionid = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);

            int groupid = 0;
            foreach (DivisionGroups obj in dgs)
            {

                groupid = obj.GroupId;


            }
            // HidGroupId.Value = groupid.ToString();
            // Groups gp = new QuestionBiz().GetGroupById(groupid);
            //if (CategoryId == 1)
            //    GroupTxt.Text = gp.Description;
            //if (CategoryId == 2)
            //    GroupTxt.Text = gp.UnstarDesc;
            return groupid;
        }
        //protected void CheckGroupBtn_Click(object sender, EventArgs e)
        //{
        //    int divisionid = Convert.ToInt32(HidDivisionId.Value);
        //    int moverid = Convert.ToInt32(HidMemberId.Value);
        //    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //   // int assemblysessionid = Convert.ToInt32(HidSessionNumber.Value);
        //    List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);
        //    int groupid = 0;
        //    string group = null;
        //    int StatusId = 1;
        //    foreach (DivisionGroups obj in dgs)
        //    {
        //        int numberofquestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(moverid, obj.GroupId, CategoryId, StatusId);
        //        if (CategoryId == 1 && numberofquestions < 3 && obj.GroupSequence <= 10 && groupid == 0)
        //        {
        //            groupid = obj.GroupId;

        //        }
        //        if (CategoryId == 2 && numberofquestions < 5 && obj.GroupSequence <= 5 && groupid == 0)
        //        {
        //            groupid = obj.GroupId;
        //        }
        //        if (groupid == 0 && obj.GroupSequence > 10)
        //            groupid = obj.GroupId;

        //    }
        //    //GroupDDL.SelectedValue = groupid.ToString();
        //    //HidGroupId.Value = groupid.ToString();
        //    Groups gp = new QuestionBiz().GetGroupById(groupid);
        //    //if (CategoryId == 1)
        //    //    GroupTxt.Text = gp.Description;
        //    //if (CategoryId == 2)
        //    //    GroupTxt.Text = gp.UnstarDesc;

        //}

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(CategoryDDL.SelectedItem.Value) != 0)
            //{
            //    int AssemblySessionId = Convert.ToInt32(HidSessionNumber.Value);
            //    BindGroupsDDL(AssemblySessionId);
            //}
            //else
            //{
            //    DivisionDDL.Items.Clear();
            //    DivisionDDL.Items.Add(new ListItem("Select", "0"));
            //    GroupDDL.Items.Clear();
            //    GroupDDL.Items.Add(new ListItem("Select", "0"));

            //}
            //MemberNameTxt.Focus();
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filePath = Server.MapPath("~/Uploads/" + Path.GetFileName(FileUpload1.PostedFile.FileName));
                FileUpload1.SaveAs(filePath);
                string extractText = this.ExtractTextFromImage(filePath);
                QuestionTxt.Value += extractText.Replace(Environment.NewLine, "<p>");
            }
        }

        private string ExtractTextFromImage(string filePath)
        {
            //Document modiDocument = new Document();
            //modiDocument.Create(filePath);
            //modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            //MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            //string extractedText = modiImage.Layout.Text;
            //modiDocument.Close();
            //return extractedText;
            return "abc";
        }
    }
}
