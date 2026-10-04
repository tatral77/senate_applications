using LegisEntities;
using System;
using LegisBIZ;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Web;

namespace Legislation
{
    public partial class NewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //NoticeDocumentDate.Text = DateTime.Now.ToShortDateString();
               // BillDocumentDate.Text = DateTime.Now.ToShortDateString();
                BindCombos();
            }
        }
        public void BindCombos()
        {
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();

            if (assemblySessions != null)
            {
                List<AssemblySessions> sorted = assemblySessions;
                foreach (AssemblySessions row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    AssemblySessionDDL.Items.Add(li);
                }
            }

            List<ParliamentaryYears> parliamentaryYears = new LegislationBiz().GetParliamentaryYears();
            
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
            List<BillCategories> QCats = new LegislationBiz().GetBillCategories();
            if (QCats != null)
            {
                foreach (BillCategories row in QCats)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillCategoriesId.ToString();
                    BillCategoryDDL.Items.Add(li);
                }
            }
            List<BillTypes> billTypes = new LegislationBiz().GetBillTypes();
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
        public void InsertBill()
        {
                int userid = 0;
                if (Request.Cookies["userInfo"] != null)
                {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                    HttpCookie userInfo = Request.Cookies["userInfo"];
                    userid = Convert.ToInt32(userInfo["userid"]);
                }
                int id = 0;
                id=new LegislationBiz().GetPk("BILLS", "BILLS_ID");
                Bills bill = new Bills();
                bill.InsertedBy = userid;
                bill.ParliamentaryYearId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
                bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = ParseDate(NoticedateTxt.Text);// //DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", null);
                bill.BillYear=bill.NoticeDiaryDate.Year;
                bill.BillCategoryId= Convert.ToInt32(BillCategoryDDL.SelectedValue);
                bill.HouseTypesId = 1;//1= Senate,2 = NA  Convert.ToInt32(OriginatedInDDL.SelectedValue);
                //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
                bill.AssemblySessionsId= Convert.ToInt32(AssemblySessionDDL.SelectedValue);
                bill.BillTitle= Convert.ToString(BillTitleTxt.Value);
                bill.Subject= Convert.ToString(SubjectTxt.Value);
                bill.BillTypeId= Convert.ToInt32(BillTypeDDL.SelectedValue);
                bill.BillStatusId = 2; //Under Process
                 bill.StatusDate = DateTime.Now; 
                bill.BillStagesId = 1; //First Reading
                bill.IsActive = 1;
            MultiPick.ToListBox(MoversLB, HidMemberId, MemberNameTxt);
            MultiPick.ToListBox(MinistersLB, HidMinisterId, MinisterNameTxt);
            MultiPick.ToListBox(MinistryLB, HidMinistryId, MinistryTxt);
                if (MoversLB.Items.Count != 0)
                {
                    bill.BillMovers = new List<BillMovers>();
                    bill.MembersCSV = ",";
                    foreach (ListItem listItem in MoversLB.Items)
                    {
                        BillMovers mover = new BillMovers();
                        mover.SystemUsersId = Convert.ToInt32(listItem.Value);
                        bill.MembersCSV = bill.MembersCSV + mover.SystemUsersId + ",";
                        bill.BillMovers.Add(mover);
                    }
                    bill.MembersCSV = bill.MembersCSV + ",";
                }
            if (MinistersLB.Items.Count != 0)
            {
                bill.BillMinisters = new List<BillMinisters>();
                bill.MinistersCSV = ",";
                foreach (ListItem listItem in MinistersLB.Items)
                {
                    BillMinisters ministers = new BillMinisters();
                    ministers.MinisterId = Convert.ToInt32(listItem.Value);
                    bill.MinistersCSV = bill.MinistersCSV + ministers.MinisterId + ",";
                    bill.BillMinisters.Add(ministers);
                }
                bill.MinistersCSV = bill.MinistersCSV + ",";
            }
            if (MinistryLB.Items.Count != 0)
                {
                    bill.Divisions = new List<Divisions>();
                    bill.DivisionsCSV = ",";
                foreach (ListItem listItem in MinistryLB.Items)
                    {
                        Divisions divisions = new Divisions();
                        divisions.DivisionsId = Convert.ToInt32(listItem.Value);
                    bill.DivisionsCSV = bill.DivisionsCSV + divisions.DivisionsId + ",";
                    bill.Divisions.Add(divisions);
                    }
                bill.DivisionsCSV = bill.DivisionsCSV + ",";
            }
            new LegislationBiz().InsertBill(bill);
            if (id != 0)
                Response.Redirect("~/BillDetail.aspx?Id=" + id);
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewLegislation.aspx");
        }
        public DateTime ParseDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertBill();
        }


    }
}