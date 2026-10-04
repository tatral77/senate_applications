using CommitteesEntities;
using LegisBIZ;
using LegisEntities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class NoticeBillDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                BindBill();
            }
        }

        public void BindBill()
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillsId"]);
            Bills Bill = new NoticeBiz().GetBill(BillId);

            if (Bill.BillCategoriesId != 0)
            {
                BillCategoryDDL.SelectedValue = Bill.BillCategoriesId.ToString();

            }
            if (Bill.AssemblySessionsId != null)
            {
                AssemblySessionDDL.SelectedValue = Bill.AssemblySessionsId.ToString();
            }
            if (Bill.BillTypeId != null)
            {
                BillTypeDDL.SelectedValue = Bill.BillTypeId.ToString();
            }
            NoticedateTxt.Text = Bill.NoticeDiaryDate.ToShortDateString();
            //QuestionIDTxt.Text = question.QuestionsId.ToString();
            //if (!string.IsNullOrEmpty(question.UrduText))
            //    UrduTxt.Value = question.UrduText.ToString();

            //MemberNameTxt.Text = question.MoverName;
            //HidMemberId.Value = question.Mover.ToString();
            HidMovers.Value = Bill.MembersCSV;
            if (!string.IsNullOrEmpty(Bill.Subject))
                SubjectTxt.Value = Bill.Subject;
            if (!string.IsNullOrEmpty(Bill.BillTitle))
                BillTitleTxt.Value = Bill.BillTitle;
            MoversLB.Text = Bill.MoverNames;
            string NoticeFile = Bill.NoticeFile;
            string Billfile = Bill.BillFile;
            if (!string.IsNullOrEmpty(NoticeFile))
            {
                HyperLink2.NavigateUrl = NoticeFile + "?" + DateTime.Now.Ticks.ToString();
                HyperLink2.Text = "View File";
            }
            else
            {
                HyperLink2.Text = "No File attached";
            }
            if (!string.IsNullOrEmpty(Billfile))
            {
                HyperLink1.NavigateUrl = Billfile + "?" + DateTime.Now.Ticks.ToString();
                HyperLink1.Text = "View File";
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }

            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
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
            List<ParliamentaryYears> parliamentaryYears = new AdministrationBiz().GetParliamentaryYears();

            if (parliamentaryYears != null)
            {
                List<ParliamentaryYears> sorted = parliamentaryYears.OrderByDescending(o => o.FromDate).ToList();
                foreach (ParliamentaryYears row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.ParliamentaryYear;
                    li.Value = row.ParliamentaryYearsId.ToString();
                    ParliamentaryYearDDL.Items.Add(li);
                }
            }
            List<BillCategories> QCats = new NoticeBiz().GetBillCategories();
            foreach (BillCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.BillCategoriesId.ToString();
                BillCategoryDDL.Items.Add(li);
            }
            List<BillTypes> billTypes = new NoticeBiz().GetBillTypes();
            if (billTypes != null)
            {
                foreach (BillTypes row in billTypes)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillTypesId.ToString();
                    BillTypeDDL.Items.Add(li);
                }
            }
        }

        //public void BindStatusHistory(int QuestionId)
        //{
        //    List<QuestionStatusHistory> sh = new List<QuestionStatusHistory>();
        //    sh = new QuestionBiz().GetQuestionStatusHistory(QuestionId);
        //    LVStatus.DataSource = sh;
        //    LVStatus.DataBind();
        //}
        //public void BindMovementHistory(int QuestionId)
        //{
        //    List<QuestionMovementHistory> sh = new List<QuestionMovementHistory>();
        //    sh = new QuestionBiz().GetQuestionMovementHistory(QuestionId);
        //    LVMovement.DataSource = sh;
        //    LVMovement.DataBind();
        //}

        //public void BindQuestionDeferment(int QuestionId)
        //{
        //    List<DeferQuestion> sh = new List<DeferQuestion>();
        //    sh = new QuestionBiz().GetQuestionDeferment(QuestionId);
        //    DeferLv.DataSource = sh;
        //    DeferLv.DataBind();
        //}
        public string GetSession(int SessionNumber)
        {
            AssemblySessions ASession = new AssemblySessions();
            ASession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            return ASession.SessionNumber.ToString();
        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            //int QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            //new QuestionBiz().DeleteQuestion(QuestionsId);
            //Response.Redirect("SearchQuestion.aspx");
        }
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int AssemblySessionId = Convert.ToInt32(HidSessionNumber.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }

        public void UpdateBill()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int id = Convert.ToInt32(Request.QueryString["BillsId"]);
            //id = new NoticeBiz().GetPk("NOTICE_BILLS", "BILLS_ID");
            Bills bill = new Bills();
            bill.InsertedBy = userid;
            bill.ParliamentaryYearId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = Convert.ToDateTime(NoticedateTxt.Text);// //DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", null);
            bill.BillYear = bill.NoticeDiaryDate.Year;
            bill.BillCategoryId = Convert.ToInt32(BillCategoryDDL.SelectedValue);
            bill.HouseTypesId = 1;//1= Senate,2 = NA  Convert.ToInt32(OriginatedInDDL.SelectedValue);
                                  //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
            bill.AssemblySessionsId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            bill.BillTitle = Convert.ToString(BillTitleTxt.Value);
            bill.Subject = Convert.ToString(SubjectTxt.Value);
            bill.BillTypeId = Convert.ToInt32(BillTypeDDL.SelectedValue);
            bill.BillStatusId = 2; //Under Process
            bill.StatusDate = DateTime.Now;
            bill.BillStagesId = 1; //First Reading
            bill.MembersCSV = HidMovers.Value;
            bill.IsActive = 1;
            int Newid=new LegislationBiz().InsertNoticeBill(bill,id);
            if (Newid != 0)
                Response.Redirect("~/BillDetails.aspx?Id=" + Newid);
        }

        

        public DateTime ParseDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }
    }
}