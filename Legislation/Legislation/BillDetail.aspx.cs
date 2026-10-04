using CommitteesEntities;
using LegisBIZ;
using LegisEntities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            }
        }
        public void BindCombos()
        {
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

           
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();
            if (assemblySessions != null)
            {
                //ListItem listitem = new ListItem
                //{
                //    Value = "0",
                //    Text = "Select"
                //};
                //ConsiderationSessionDDL.Items.Add(listitem);
                //IntroduceSessionDDL.Items.Add(listitem);
              
                foreach (AssemblySessions row in assemblySessions)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    ConsiderationSessionDDL.Items.Add(li);
                    IntroduceSessionDDL.Items.Add(li);
                    AssemblySessionDDL.Items.Add(li);
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
            List<BillStatuses> billStatuses = new LegislationBiz().GetActiveBillStatuses();
            if (billStatuses != null)
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
            ParliamentaryTerms parliamentaryPeriods = new CommitteesBiz().GetActiveParliamentaryTerm();
            List<Committees> committees = new CommitteesBiz().GetCommitteesByParliamentaryTerm(parliamentaryPeriods.ParliamentaryTermsId);
                ;
            if (committees != null)
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

        public DateTime ParseDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
        }
        public void BindBill(int BillId)
        {
            Bills bill = null;
            if (BillId != 0)
            {
                bill=new Bills();
                bill = new LegislationBiz().GetBill(BillId);
                ParliamentaryYearDDL.SelectedValue = bill.ParliamentaryYearId.ToString();
                BillIdTxt.Text = bill.BillsId.ToString();
                if(!string.IsNullOrEmpty(bill.FileNumber))
                FileNumberTxt.Text=bill.FileNumber.ToString();
                NoticeDateTxt.Text=GetDate(bill.NoticeDiaryDate);
                BillCategoryDDL.SelectedValue= bill.BillCategoriesId.ToString();
                BillStatusDDL.SelectedValue= bill.BillStatusId.ToString();
                HidBillStatusId.Value= bill.BillStatusId.ToString();
                StatusDateTxt.Text= GetDate(bill.StatusDate);
                ParliamentaryYearDDL.SelectedValue = bill.ParliamentaryYearId.ToString();
                AssemblySessionDDL.SelectedValue = bill.AssemblySessionsId.ToString();
                //OriginatedInDDL.SelectedValue = 1;// bill.HouseTypesId.ToString();
                PassedByNADate.Text = GetDate(bill.PassedByNADate);
                //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
                BillTitleTxt.Value= bill.BillTitle;
                SubjectTxt.Value = bill.Subject;
                SenatePassageDate.Text = GetDate(bill.BillPassageDate);
                BillTypeDDL.SelectedValue= bill.BillTypeId.ToString();
                bill.BillStagesId = 1;
                IsActiveDDL.SelectedValue= bill.IsActive.ToString();
                BillRemarksTxt.Value = bill.Remarks;
                //BillLink.NavigateUrl = bill.BillFile;
                //NoticeLink.NavigateUrl = bill.NoticeFile;

                //  PresentedInHouseOnTxt.Text=bill.hou
                IntroducedInHouseOnTxt.Text = GetDate(bill.IntroducedInHouseOn);
                CommitteeDDL.SelectedValue = bill.CommitteeId.ToString();
                CommitteeTimeLimitTxt.Text= bill.CommitteeTimeLimit.ToString();
                CommitteeRefDateTxt.Text=GetDate(bill.CommitteeRefDate);
                CommitteeRecomendationDDL.SelectedValue= bill.CommitteeRecommendationId.ToString();
                IntroduceSessionDDL.SelectedValue= bill.AssemblySessionsId.ToString();
               // CommitteeRemarksTxt.InnerText= bill.CommitteeRemarks;
                CommitteeReportDateTxt.Text= GetDate(bill.CommitteeReportDate);

                ToNAMessageDate.Text= GetDate(bill.SentToNaDate);
                FromNAMessageDate.Text = GetDate(bill.ReceivedFromNADate);
               // NARemarksTxt.InnerText = bill.NARemarks;


                MemberPassWithdrawStatusDDL.SelectedValue= bill.MemberWithdrawStatusId.ToString();
                PassWithdrawDateTxt.Text = GetDate(bill.MemberWithdrawStatusDate);
                ConsiderationSessionDDL.SelectedValue = bill.ConsiderationSessionId.ToString();
                HouseForConsiderationDate.Text = GetDate(bill.HouseForConsiderationDate);
               // MemberRemarksTxt.Value = bill.MemberRemarks;

                if (bill.BillMovers!=null)
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

            MultiPick.FromListBox(MoversLB, HidMemberId, MemberNameTxt);
            MultiPick.FromListBox(MinistersLB, HidMinisterId, MinisterNameTxt);
            MultiPick.FromListBox(MinistryLB, HidMinistryId, MinistryTxt);

            BindUserDetails(bill);
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
            bill.UpdatedBy = userid;
            bill.BillsId = Convert.ToInt32(Request.QueryString["id"]);
            //bill.ParliamentaryYearId= Convert.ToInt32(IntroduceSessionDDL.SelectedValue);
            bill.AssemblySessionsId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = ParseDate(NoticeDateTxt.Text);
            bill.BillYear = bill.NoticeDiaryDate.Year;
            bill.BillCategoryId = Convert.ToInt32(BillCategoryDDL.SelectedValue);
            bill.BillStatusId = Convert.ToInt32(BillStatusDDL.SelectedValue);
            bill.StatusDate=Convert.ToDateTime(StatusDateTxt.Text);
            bill.ParliamentaryYearId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            bill.HouseTypesId = 1;// Convert.ToInt32(OriginatedInDDL.SelectedValue);
            bill.BillTitle = Convert.ToString(BillTitleTxt.Value);
            bill.Subject = Convert.ToString(SubjectTxt.Value);
            bill.BillTypeId = Convert.ToInt32(BillTypeDDL.SelectedValue);
            bill.BillStagesId = 1;
            bill.Remarks = BillRemarksTxt.Value;
            bill.IsActive = Convert.ToInt32(IsActiveDDL.SelectedValue);

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
            if (BillStatusDDL.SelectedItem.Value != HidBillStatusId.Value)
            {
                BillStatusHistory sh = new BillStatusHistory();
                sh.BillsId = bill.BillsId;
                sh.BillStatusesId = bill.BillStatusId;
                sh.StatusDate = ParseDate(StatusDateTxt.Text); //DateTime.ParseExact(.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                sh.UpdatedById = userid;
                new LegislationBiz().InsertBillStatusHistory(sh);
            }
            new LegislationBiz().UpdateBill(bill);
            //if (BillUpload.HasFile)
            //{
            //    string strname = BillUpload.FileName.ToString();
            //    ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            //    string filename = bill.BillsId + "-" + DocumentId + ext;
            //    BillUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
            //    string url = "./contents/bills/" + filename;
            //    bill.BillFile = url;
            //    //bill.QuestionFile = url;
            //    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
            //    billDocumentsEnt.DocumentDescription = "Bill";
            //    billDocumentsEnt.DocumentTypeId = 2;
            //    billDocumentsEnt.Url = url;
            //    billDocumentsEnt.BillId = bill.BillsId;
            //    new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            //}
            //if (NoticeUpload.HasFile)
            //{
            //    string strname = NoticeUpload.FileName.ToString();
            //    ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            //    string filename = bill.BillsId + "-" + DocumentId + ext;
            //    NoticeUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
            //    string url = "./contents/bills/" + filename;
            //    bill.NoticeFile = url;
            //    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
            //    billDocumentsEnt.DocumentDescription = "Notice";
            //    billDocumentsEnt.DocumentTypeId = 3;
            //    billDocumentsEnt.Url = url;
            //    billDocumentsEnt.BillId = bill.BillsId;
            //    new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            //}
            Response.Redirect("~/BillDetail.aspx?Id=" + bill.BillsId);
           
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewLegislation.aspx");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }

        private static readonly string[] AllowedDocumentTypes = { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".jpg", ".jpeg", ".png" };
        private const int MaxDocumentBytes = 25 * 1024 * 1024;

        // Returns an error message, or "" when the uploaded file may be stored.
        private string CheckDocument(FileUpload upload)
        {
            string ext = Path.GetExtension(upload.FileName).ToLowerInvariant();
            if (Array.IndexOf(AllowedDocumentTypes, ext) < 0)
                return "This file type is not allowed. Use PDF, Word, Excel, JPG or PNG.";
            if (upload.PostedFile.ContentLength > MaxDocumentBytes)
                return "The file is larger than 25 MB.";
            return "";
        }

        private string SaveDocument(FileUpload upload, int billId, int documentId)
        {
            string folder = Server.MapPath("~/Contents/Bills/");
            Directory.CreateDirectory(folder);
            string filename = billId + "-" + documentId + Path.GetExtension(upload.FileName).ToLowerInvariant();
            upload.PostedFile.SaveAs(Path.Combine(folder, filename));
            return "./contents/bills/" + filename;
        }

        // "PDF", "DOCX"... shown on the download button
        protected string FileLabel(object url)
        {
            string ext = Path.GetExtension(Convert.ToString(url) ?? "").TrimStart('.').ToUpperInvariant();
            return ext == "" ? "Download" : "Download " + ext;
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            errorlbl.Text = "";
            if (!BillDocumentFileUpload.HasFile)
            {
                errorlbl.Text = "Please select a document.";
                return;
            }
            string problem = CheckDocument(BillDocumentFileUpload);
            if (problem != "")
            {
                errorlbl.Text = problem;
                return;
            }
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            BillDocumentsEnt itb = new BillDocumentsEnt();
            itb.BillId = BillId;
            itb.DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            itb.DocumentDescription = DocumentDescTxt.Text;
            itb.DocumentTypeId = Convert.ToInt32(DocumentTypeDDL.SelectedValue);
            itb.AttachmentDate = ParseDate(DocumentDateTxt.Text);
            itb.Url = SaveDocument(BillDocumentFileUpload, BillId, itb.DocumentId);
            new LegislationBiz().InsertBillDocument(itb);
            Response.Redirect("~/BillDetail.aspx?Id=" + BillId + "#BillDocuments");
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
        protected void DriversLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            DriversLV.InsertItemPosition = InsertItemPosition.None;
            DriversLV.SelectedIndex = -1;
            DriversLV.EditIndex = e.NewEditIndex;
            BindDocumentsLV();
            e.Cancel = true;
        }

        protected void DriversLV_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            DriversLV.EditIndex = -1;
            BindDocumentsLV();
            e.Cancel = true;
        }

        protected void DriversLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidDocumentId = DriversLV.EditItem.FindControl("HidDocumentId") as HiddenField;
            HiddenField HidUrl = DriversLV.EditItem.FindControl("HidUrl") as HiddenField;
            TextBox DocumentDescriptionTxt = (TextBox)DriversLV.EditItem.FindControl("DocumentDescriptionTxt");
            TextBox EditDateTxt = (TextBox)DriversLV.EditItem.FindControl("EditDateTxt");
            FileUpload FileUpload1 = (FileUpload)DriversLV.EditItem.FindControl("FileUpload1");
            DropDownList DocumentTypeDDL = (DropDownList)DriversLV.EditItem.FindControl("DocumentTypeDDL");
            e.Cancel = true;
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            BillDocumentsEnt itb = new BillDocumentsEnt();
            itb.DocumentId = Convert.ToInt32(HidDocumentId.Value);
            itb.BillId = BillId;
            itb.DocumentDescription = Convert.ToString(DocumentDescriptionTxt.Text);
            DateTime date;
            itb.AttachmentDate = DateTime.TryParse(EditDateTxt.Text, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat, System.Globalization.DateTimeStyles.None, out date) ? date : DateTime.Now;
            itb.DocumentTypeId = Convert.ToInt32(DocumentTypeDDL.SelectedValue);
            itb.Url = Convert.ToString(HidUrl.Value);

            if (FileUpload1.HasFile)
            {
                string problem = CheckDocument(FileUpload1);
                if (problem != "")
                {
                    errorlbl.Text = problem;
                    return;
                }
                itb.Url = SaveDocument(FileUpload1, itb.BillId, itb.DocumentId);
            }
            new LegislationBiz().UpdateBillDocument(itb);
            Response.Redirect("~/BillDetail.aspx?Id=" + BillId + "#BillDocuments");
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (DriversLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList DocumentTypeDDL = e.Item.FindControl("DocumentTypeDDL") as DropDownList;
                HiddenField HidDocumentTypeId = (e.Item.FindControl("HidDocumentTypeId") as HiddenField);
                DocumentTypeDDL.SelectedValue = HidDocumentTypeId.Value.ToString();

            }
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList DocumentTypeDDL = new DropDownList();
            DocumentTypeDDL = (e.Item.FindControl("DocumentTypeDDL") as DropDownList);
            if (DocumentTypeDDL != null)
            {
                List<DocumentTypes> ps = new LegislationBiz().GetDocumentTypes();

                foreach (DocumentTypes row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.DocumentTypeId.ToString();
                    li.Text = row.DocumentType.ToString();
                    DocumentTypeDDL.Items.Add(li);
                }

            }

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
            if (date < Convert.ToDateTime("01/01/1900"))
                return string.Empty;
            else
                return date.ToShortDateString();

        }

        protected void UpdateCommitteeDetailsBtn_Click(object sender, EventArgs e)
        {

            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
      
            Bills bill = new Bills();
            bill.UpdatedBy = userid;
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            bill.BillsId = BillId;
            if (!string.IsNullOrEmpty(IntroducedInHouseOnTxt.Text))
                bill.IntroducedInHouseOn = ParseDate(IntroducedInHouseOnTxt.Text);
            if (!string.IsNullOrEmpty(CommitteeRefDateTxt.Text))
                bill.CommitteeRefDate = ParseDate(CommitteeRefDateTxt.Text);
            bill.CommitteeId = Convert.ToInt32(CommitteeDDL.SelectedValue);
            bill.CommitteeTimeLimit = Convert.ToInt32(CommitteeTimeLimitTxt.Text);
            //if (!string.IsNullOrEmpty(IntroducedInHouseOnTxt.Text))
            //    bill.CommitteeRefDate = Convert.ToDateTime(CommitteeRefDateTxt.Text);
            bill.CommitteeRecommendationId = Convert.ToInt32(CommitteeRecomendationDDL.SelectedValue);
            bill.AssemblySessionsId = Convert.ToInt32(IntroduceSessionDDL.SelectedValue);
            if (!string.IsNullOrEmpty(CommitteeReportDateTxt.Text))
                bill.CommitteeReportDate = ParseDate(CommitteeReportDateTxt.Text);

            bill.IsSentToCommittee = 1;
           // bill.CommitteeRemarks = CommitteeRemarksTxt.InnerText;
            new LegislationBiz().UpdateCommitteeDetails(bill);

        }

        protected void UpdateMemberPassageDetailsBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
          
            Bills bill = new Bills();
            bill.UpdatedBy = userid;
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            bill.BillsId = BillId;
            bill.MemberWithdrawStatusId= Convert.ToInt32(MemberPassWithdrawStatusDDL.SelectedValue);
            if (!string.IsNullOrEmpty(PassWithdrawDateTxt.Text))
                bill.MemberWithdrawStatusDate= ParseDate(PassWithdrawDateTxt.Text);
            if (!string.IsNullOrEmpty(HouseForConsiderationDate.Text))
                bill.HouseForConsiderationDate= ParseDate(HouseForConsiderationDate.Text);
            bill.ConsiderationSessionId = Convert.ToInt32(ConsiderationSessionDDL.SelectedValue);
           // bill.MemberRemarks = Convert.ToString(MemberRemarksTxt.Value);
            new LegislationBiz().UpdateBillMemberDetails(bill);
        }

        protected void UpdateNADetailsBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }

            Bills bill = new Bills();
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            bill.BillsId = BillId;
            if (!string.IsNullOrEmpty(SenatePassageDate.Text))
                bill.BillPassageDate = ParseDate(SenatePassageDate.Text);
            if (!string.IsNullOrEmpty(ToNAMessageDate.Text))
                bill.SentToNaDate = ParseDate(ToNAMessageDate.Text);// DateTime.ParseExact(ToNAMessageDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(FromNAMessageDate.Text))
                bill.ReceivedFromNADate = ParseDate(FromNAMessageDate.Text);// DateTime.ParseExact(FromNAMessageDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if(!string.IsNullOrEmpty(PassedByNADate.Text))
                bill.PassedByNADate = ParseDate(PassedByNADate.Text);
           // bill.NARemarks = NARemarksTxt.InnerText;
            new LegislationBiz().UpdateNADetails(bill);
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

        public void BindUserDetails(Bills bill)
        {
            string UpdatedLabelText = "";
            if (bill.UpdatedBy != 0)
            {
                UpdatedLabelText = GetUserName(bill.UpdatedBy);
                if (bill.UpdatedOn != null && bill.UpdatedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string updatedon = bill.UpdatedOn.ToString();
                    UpdatedLabelText += " on " + updatedon;
                }
                UpdatedByLbl.Text = UpdatedLabelText;

            }
            string InsertLabelText = "";
            if (bill.InsertedBy != 0)
            {
                InsertLabelText = GetUserName(bill.InsertedBy);
                if (bill.InsertedOn != null && bill.InsertedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string insertedon = bill.InsertedOn.ToString();
                    InsertLabelText += " on " + insertedon;
                }
                InsertedByLbl.Text = InsertLabelText;

            }



            //string TranslationLabelText = "";
            //if (bill.SentForTranslationBy != 0)
            //{
            //    TranslationLabelText = GetUserName(bill.SentForTranslationBy);
            //    if (bill.SentForTranslationOn != null && bill.SentForTranslationOn > Convert.ToDateTime("1/1/1900"))
            //    {
            //        string translatedon = bill.SentForTranslationOn.ToString();
            //        TranslationLabelText += " on " + translatedon;
            //    }
            //    SentForTransByLbl.Text = TranslationLabelText;

            //}

            //string ApprovedByLbl = "";
            //if (bill.TranslationApprovedBy != 0)
            //{
            //    ApprovedByLbl = GetUserName(bill.TranslationApprovedBy);
            //    if (bill.TranslationApprovedOn != null && bill.TranslationApprovedOn > Convert.ToDateTime("1/1/1900"))
            //    {
            //        string approvedon = bill.TranslationApprovedOn.ToString();
            //        ApprovedByLbl += " on " + approvedon;
            //    }
            //    TransApprovedByLbl.Text = ApprovedByLbl;

            //}

            string DeleteLabelTxt = "";
            if (bill.DeletedBy != 0)
            {
                DeleteLabelTxt = GetUserName(bill.DeletedBy);
                if (bill.DeletedOn != null && bill.DeletedOn > Convert.ToDateTime("1/1/1900"))
                {
                    string deletedon = bill.DeletedOn.ToString();
                    DeleteLabelTxt += " on " + deletedon;
                }
                DeletedByLbl.Text = DeleteLabelTxt;

            }

            string RecoveredLabelTxt = "";
            if (bill.RecoveredBy != 0)
            {
                RecoveredLabelTxt = GetUserName(bill.RecoveredBy);
                if (bill.RecoveredOn != null && bill.RecoveredOn > Convert.ToDateTime("1/1/1900"))
                {
                    string recoverdon = bill.RecoveredOn.ToString();
                    RecoveredLabelTxt += " on " + recoverdon;
                }
                RecoveredByLbl.Text = RecoveredLabelTxt;
            }
        }

      
    }
}