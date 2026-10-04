using CommitteesEntities;
using LegisBIZ;
using LegisEntities;
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
    public partial class BillDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int BillId = Convert.ToInt32(Request.QueryString["Id"]);
                BindCombos();
                BindBill(BillId);
                BindDocumentsLV();
                DocumentDateTxt.Text=DateTime.Now.ToShortDateString();
                AssemblySessions ASession = new LegislationBiz().GetCurrentAssemblySessionDetails();
                SessionTxt.Text = ASession.SessionNumber.ToString();
                HidSessionNumber.Value = ASession.AssemblySessionsId.ToString();
            }
        }
        public void BindCombos()
        {
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
            List<BillStatuses> billStatuses = new LegislationBiz().GetBillStatuses();
            if (QCats != null)
            {
                foreach (BillStatuses row in billStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillStatusesId.ToString();
                    BillStatusDDL.Items.Add(li);
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
            ParliamentaryPeriods parliamentaryPeriods = new CommitteesBiz().GetActiveParliamentaryPeriod();
            List<Committees> committees = new CommitteesBiz().GetCommitteesByParliamentaryPeriod(parliamentaryPeriods.ParliamentaryPeriodId);
                ;
            if (billTypes != null)
            {
                foreach (Committees row in committees)
                {
                    ListItem li = new ListItem();
                    li.Text = row.CommitteeName;
                    li.Value = row.CommitteesId.ToString();
                    CommitteeDDL.Items.Add(li);
                }
            }
            List<DocumentTypes> documentTypes = new LegislationBiz().GetDocumentTypes();
            if (documentTypes != null)
            {
                foreach (DocumentTypes row in documentTypes)
                {
                    ListItem li = new ListItem();
                    li.Text = row.DocumentType;
                    li.Value = row.DocumentTypeId.ToString();
                    DocumentTypeDDL.Items.Add(li);
                }
            }
        }
        public void BindBill(int BillId)
        {
            Bills bill = null;
            if (BillId != 0)
            {
                bill=new Bills();
                bill = new LegislationBiz().GetBill(BillId);
                HidSessionNumber.Value = bill.AssemblySessionsId.ToString();
                BillIdTxt.Text = bill.BillsId.ToString();
                if(!string.IsNullOrEmpty(bill.FileNumber))
                FileNumberTxt.Text=bill.FileNumber.ToString();
                NoticeDateTxt.Text=bill.NoticeDiaryDate.ToShortDateString();
                BillCategoryDDL.SelectedValue= bill.BillCategoriesId.ToString();
                BillStatusDDL.SelectedValue= bill.BillStatusId.ToString();
                HidBillStatusId.Value= bill.BillStatusId.ToString();
                //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
                BillTitleTxt.Value= bill.BillTitle;
                SubjectTxt.Value = bill.Subject;
                BillTypeDDL.SelectedValue= bill.BillTypeId.ToString();
                bill.BillStagesId = 1;
                IsActiveDDL.SelectedValue= bill.IsActive.ToString();
                BillLink.NavigateUrl = bill.BillFile;
                NoticeLink.NavigateUrl = bill.NoticeFile;

              //  PresentedInHouseOnTxt.Text=bill.hou
                if(bill.BillMovers!=null)
                {
                    if(bill.BillMovers.Count>0)
                    {
                        foreach(var m in bill.BillMovers)
                        {
                            ListItem item = new ListItem
                            {
                                Value = m.SystemUsersId.ToString(),
                                Text = m.Mover
                            };
                            MoversLB.Items.Add(item);
                        }
                    }
                }
                if (bill.BillMinisters != null)
                {
                    if (bill.BillMinisters.Count > 0)
                    {
                        foreach (var m in bill.BillMinisters)
                        {
                            ListItem item = new ListItem
                            {
                                Value = m.MinisterId.ToString(),
                                Text = m.MinisterName
                            };
                            MinistersLB.Items.Add(item);
                        }
                    }
                }
              
                if (bill.BillDivisions != null)
                {
                    if (bill.BillDivisions.Count > 0)
                    {
                        foreach (var m in bill.BillDivisions)
                        {
                            ListItem item = new ListItem
                            {
                                Value = m.DivisionsId.ToString(),
                                Text = m.Division
                            };
                            MinistryLB.Items.Add(item);
                        }
                    }
                }
            }
            BindBillStatusHistory(BillId);

          
        }
        public void BindBillStatusHistory(int BillsId)
        {
            List<BillStatusHistory> billStatusHistories = new List<BillStatusHistory>();
            billStatusHistories = new LegislationBiz().GetBillStatusHistory(BillsId);
            BillStatusHistoryLV.DataSource = billStatusHistories;
            BillStatusHistoryLV.DataBind();
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
            int id = 0;
            Bills bill = new Bills();
            bill.BillsId = Convert.ToInt32(Request.QueryString["id"]);
            bill.AssemblySessionsId = Convert.ToInt32(HidSessionNumber.Value);
            bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = Convert.ToDateTime(NoticeDateTxt.Text);
            bill.BillYear = bill.NoticeDiaryDate.Year;
            bill.BillCategoryId = Convert.ToInt32(BillCategoryDDL.SelectedValue);
            bill.BillStatusId = Convert.ToInt32(BillStatusDDL.SelectedValue);
            bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
            bill.BillTitle = Convert.ToString(BillTitleTxt.Value);
            bill.Subject = Convert.ToString(SubjectTxt.Value);
            bill.BillTypeId = Convert.ToInt32(BillTypeDDL.SelectedValue);
            bill.BillStagesId = 1;
            bill.IsActive = Convert.ToInt32(IsActiveDDL.SelectedValue); 
            if (MoversLB.Items.Count != 0)
            {
                bill.BillMovers = new List<BillMovers>();
                foreach (ListItem listItem in MoversLB.Items)
                {
                    BillMovers mover = new BillMovers();
                    mover.SystemUsersId = Convert.ToInt32(listItem.Value);
                    bill.BillMovers.Add(mover);
                }
            }
            if (MinistersLB.Items.Count != 0)
            {
                bill.BillMinisters = new List<BillMinisters>();
                foreach (ListItem listItem in MinistersLB.Items)
                {
                    BillMinisters ministers = new BillMinisters();
                    ministers.MinisterId = Convert.ToInt32(listItem.Value);
                    bill.BillMinisters.Add(ministers);
                }
            }
            if (MinistryLB.Items.Count != 0)
            {
                bill.Divisions = new List<Divisions>();
                foreach (ListItem listItem in MinistryLB.Items)
                {
                    Divisions divisions = new Divisions();
                    divisions.DivisionsId = Convert.ToInt32(listItem.Value);
                    bill.Divisions.Add(divisions);
                }
            }
            if (BillStatusDDL.SelectedItem.Value != HidBillStatusId.Value)
            {
                BillStatusHistory sh = new BillStatusHistory();
                sh.BillsId = bill.BillsId;
                sh.BillStatusesId = bill.BillStatusId;
                sh.StatusDate = DateTime.Now;
                sh.UpdatedById = userid;
                new LegislationBiz().InsertBillStatusHistory(sh);
            }
            new LegislationBiz().UpdateBill(bill);
            if (BillUpload.HasFile)
            {
                string strname = BillUpload.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
                string filename = bill.BillsId + "-" + DocumentId + ext;
                BillUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
                string url = "./contents/bills/" + filename;
                bill.BillFile = url;
                //question.QuestionFile = url;
                BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                billDocumentsEnt.DocumentDescription = "Bill";
                billDocumentsEnt.DocumentTypeId = 2;
                billDocumentsEnt.Url = url;
                billDocumentsEnt.BillId = bill.BillsId;
                new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            }
            if (NoticeUpload.HasFile)
            {
                string strname = NoticeUpload.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
                string filename = bill.BillsId + "-" + DocumentId + ext;
                NoticeUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
                string url = "./contents/bills/" + filename;
                bill.NoticeFile = url;
                BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                billDocumentsEnt.DocumentDescription = "Notice";
                billDocumentsEnt.DocumentTypeId = 3;
                billDocumentsEnt.Url = url;
                billDocumentsEnt.BillId = bill.BillsId;
                new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            }
            Response.Redirect("~/BillDetail.aspx?Id=" + bill.BillsId);
           
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewLegislation.aspx");
        }

        protected void AddMover_Click(object sender, EventArgs e)
        {
            int found = 0;
            int moverid = 0;
            string movername = "";

            if (!String.IsNullOrEmpty(HidMemberId.Value))
            {
                moverid = Convert.ToInt32(HidMemberId.Value);
                movername = MemberNameTxt.Text;
                foreach (ListItem listItem in MoversLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == moverid)
                        found = 1;
                }
            }
            if (found == 0)
            {
                //string movername = new LegislationBiz().GetMemberNameById(moverid);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(moverid);
                Temp.Text = Convert.ToString(movername);
                MoversLB.Items.Add(Temp);
                HidMemberId.Value = "";
                MemberNameTxt.Text = "";
                err.Text = "";
            }
            else
                err.Text = "Mover already exist";

        }
        protected void DeleteMover_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            foreach (ListItem listItem in MoversLB.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                MoversLB.Items.Remove(listItem);
            }

        }
        protected void AddMinistry_Click(object sender, EventArgs e)
        {
            int found = 0;
            int ministryid = 0;
            string ministryname = "";

            if (!String.IsNullOrEmpty(HidMinistryId.Value))
            {
                ministryid = Convert.ToInt32(HidMinistryId.Value);
                ministryname = MinistryTxt.Text;
                foreach (ListItem listItem in MinistryLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == ministryid)
                        found = 1;
                }
            }
            if (found == 0)
            {
                //string ministryname = new LegislationBiz().GetMinistryNameById(ministryid);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(ministryid);
                Temp.Text = Convert.ToString(ministryname);
                MinistryLB.Items.Add(Temp);
                HidMinistryId.Value = "";
                MinistryTxt.Text = "";
                err2.Text = "";
            }
            else
                err2.Text = "Ministry already exist";
        }
        protected void DeleteMinistry_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            foreach (ListItem listItem in MinistryLB.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                MinistryLB.Items.Remove(listItem);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            errorlbl.Text = "";
            BillDocumentsEnt itb = new BillDocumentsEnt();
            itb.BillId = BillId;
            itb.DocumentId = DocumentId;
            itb.DocumentDescription = DocumentDescTxt.Text;
            itb.DocumentTypeId = Convert.ToInt32(DocumentTypeDDL.SelectedValue);
            if (BillDocumentFileUpload.HasFile)
            {
                string strname = BillDocumentFileUpload.FileName.ToString();
                //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = itb.BillId + "-" + itb.DocumentId + ext;
                BillDocumentFileUpload.PostedFile.SaveAs(Server.MapPath("~//Contents//Bills//") + filename);
                itb.Url = "./contents/bills/" + filename;
                new LegislationBiz().InsertBillDocument(itb);
              
            }
            else
                errorlbl.Text = " Please select document";
            UpdateBill();
        }
        protected void AddMinister_Click(object sender, EventArgs e)
        {
            int found = 0;
            int moverid = 0;
            string movername = "";

            if (!String.IsNullOrEmpty(HidMinisterId.Value))
            {
                moverid = Convert.ToInt32(HidMinisterId.Value);
                movername = MinisterNameTxt.Text;
                foreach (ListItem listItem in MinistersLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == moverid)
                        found = 1;
                }
            }
            if (found == 0)
            {
                //string movername = new LegislationBiz().GetMemberNameById(moverid);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(moverid);
                Temp.Text = Convert.ToString(movername);
                MinistersLB.Items.Add(Temp);
                HidMinisterId.Value = "";
                MinisterNameTxt.Text = "";
                MinisterErr.Text = "";
            }
            else
                MinisterErr.Text = "Minister already exists";
        }

        protected void DeleteMinister_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            foreach (ListItem listItem in MinistersLB.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                MinistersLB.Items.Remove(listItem);
            }
        }

        #region Bill Documents
        protected void BindDocumentsLV()
        {
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            List<BillDocumentsEnt> drivers = new LegislationBiz().GetBillDocuments(BillId);
            DriversLV.DataSource = drivers;
            DriversLV.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
          


        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            //int ModelId = Convert.ToInt32(Request.QueryString["Id"]);
            //HiddenField DriverId = (HiddenField)DriversLV.Items[e.ItemIndex].FindControl("HidDriverId");
            //int driverid = Convert.ToInt32(DriverId.Value);
            //BillDocumentsEnt driver = new BudgetBiz().GetBillDocument(driverid);
            //File.Delete(Server.MapPath("~//Bills//" + driver.Url));
            //new BudgetBiz().DeleteBillDocument(driverid);
            //Response.Redirect("BillDocuments.aspx?Id=" + ModelId);
        }
        #endregion

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToString();

        }

    }
}