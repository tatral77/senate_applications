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
    public partial class NewNABill : System.Web.UI.Page
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
        public DateTime ParseDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
        }
        public void InsertNABill()
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
            bill.PassedByNADate = ParseDate(PassedByNADateTxt.Text); //DateTime.ParseExact(PassedByNADateTxt.Text, "dd/MM/yyyy", null);
                bill.ReceivedFromNADate = ParseDate(NAMessageReceiptDate.Text); //DateTime.ParseExact(NAMessageReceiptDate.Text, "dd/MM/yyyy", null);
            bill.BillYear=bill.NoticeDiaryDate.Year;
                bill.BillCategoryId= Convert.ToInt32(BillCategoryDDL.SelectedValue);
                bill.HouseTypesId = 2;//  Convert.ToInt32(OriginatedInDDL.SelectedValue);
                //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
                bill.AssemblySessionsId= Convert.ToInt32(AssemblySessionDDL.SelectedValue);
                bill.BillTitle= Convert.ToString(BillTitleTxt.Value);
                bill.Subject= Convert.ToString(SubjectTxt.Value);
                bill.BillTypeId= Convert.ToInt32(BillTypeDDL.SelectedValue);
                bill.BillStatusId = 2;
                bill.StatusDate = DateTime.Now; 
                bill.BillStagesId = 1;
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
            new LegislationBiz().InsertNABill(bill);
            //if (BillUpload.HasFile)
            //{
            //    string strname = BillUpload.FileName.ToString();
            //    ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            //    string filename = id + "-" + DocumentId + ext;
            //    BillUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
            //    string url = "./contents/bills/" + filename;
            //    bill.BillFile = url;
            //    //question.QuestionFile = url;
            //    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
            //    billDocumentsEnt.DocumentId = DocumentId;
            //    billDocumentsEnt.DocumentDescription = "Bill";
            //    billDocumentsEnt.AttachmentDate = DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    billDocumentsEnt.Url = url;
            //    billDocumentsEnt.DocumentTypeId = 2;
            //    billDocumentsEnt.BillId = id;
            //    new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            //}
            //if (NoticeUpload.HasFile)
            //{
            //    string strname = NoticeUpload.FileName.ToString();
            //    ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            //    string filename = id + "-" + DocumentId + ext;
            //    NoticeUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
            //    string url = "./contents/bills/" + filename;
            //    bill.NoticeFile = url;
            //    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
            //    billDocumentsEnt.DocumentId = DocumentId;
            //    billDocumentsEnt.DocumentDescription = "Notice";
            //    billDocumentsEnt.Url = url;
            //    billDocumentsEnt.BillId = id;
            //    billDocumentsEnt.AttachmentDate = DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
            //    billDocumentsEnt.DocumentTypeId = 3;
            //    new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            //}
           
            if (id != 0)
                Response.Redirect("~/NABillDetail.aspx?Id=" + id);
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewLegislation.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertNABill();
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    InsertBill();
        //}


    }
}