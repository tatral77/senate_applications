using LegisEntities;
using System;
using LegisBIZ;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;

namespace Legislation
{
    public partial class NewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
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
                int id = 0;
                Bills bill = new Bills();
                bill.AssemblySessionsId = Convert.ToInt32(HidSessionNumber.Value);
                bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
                bill.NoticeDiaryDate= Convert.ToDateTime(NoticedateTxt.Text);
                bill.BillYear=bill.NoticeDiaryDate.Year;
                bill.BillCategoryId= Convert.ToInt32(BillCategoryDDL.SelectedValue);
                bill.HouseTypesId = 1;// Convert.ToInt32(OriginatedByDDL.SelectedValue);
                //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
                bill.BillTitle= Convert.ToString(BillTitleTxt.Value);
                bill.Subject= Convert.ToString(SubjectTxt.Value);
                bill.BillTypeId= Convert.ToInt32(BillTypeDDL.SelectedValue);
                bill.BillStatusId = 2;
                bill.BillStagesId = 1;
                bill.IsActive = 1;
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
            id = new LegislationBiz().InsertBill(bill);
            if (BillUpload.HasFile)
            {
                string strname = BillUpload.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
                string filename = id + "-" + DocumentId + ext;
                BillUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
                string url = "./contents/bills/" + filename;
                bill.BillFile = url;
                //question.QuestionFile = url;
                BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                billDocumentsEnt.DocumentDescription = "Bill";
                billDocumentsEnt.Url = url;
                billDocumentsEnt.BillId = id;
                new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            }
            if (NoticeUpload.HasFile)
            {
                string strname = NoticeUpload.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                int DocumentId = new LegislationBiz().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
                string filename = id + "-" + DocumentId + ext;
                NoticeUpload.PostedFile.SaveAs(Server.MapPath("~//contents//bills//") + filename);
                string url = "./contents/bills/" + filename;
                bill.NoticeFile = url;
                BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                billDocumentsEnt.DocumentDescription = "Notice";
                billDocumentsEnt.Url = url;
                billDocumentsEnt.BillId = id;
                new LegislationBiz().InsertBillDocument(billDocumentsEnt);
            }
            if (id != 0)
                Response.Redirect("~/BillDetail.aspx?Id=" + id);
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewLegislation.aspx");
        }

        protected void AddMover_Click(object sender, EventArgs e)
        {
            int found = 0;
            int moverid = 0;
            string movername="";
            
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
                err2.Text = "Ministry already exists";
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
            InsertBill();
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
    }
}