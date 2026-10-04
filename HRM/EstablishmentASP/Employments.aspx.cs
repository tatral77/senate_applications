using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class Employments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                //bindEmployment(empval);
                bindEmpPromotion(empval);
                bindEmpHistory(empval);
                bindCombos();
            }
            bindEmployment(empval);

        }
        protected void bindEmpHistory(int empval)
        {
            List<EmploymentHistory> EmpHist = new EmployeeHandler().GetEmploymentHist(empval);

            EmpHistory.DataSource = EmpHist;
            EmpHistory.DataBind();
        }
        protected void bindEmpPromotion(int empval)
        {
            List<PromotionHistory> PromHist = new EmployeeHandler().GetPromotionHistory(empval);
            EmpPromotion.DataSource = PromHist;
            EmpPromotion.DataBind();
        }
        protected void bindEmployment(int EmpId)
        {
            EmpEmployment Ep = new EmpEmployment();
            Ep = new EmployeeHandler().GetEmpEmployment(EmpId);
            FileNo.Text = Convert.ToString(Ep.File_no);
            Branch.SelectedIndex = Branch.Items.IndexOf(Branch.Items.FindByValue(Ep.Branch.ToString()));
            PostHeld.SelectedIndex = PostHeld.Items.IndexOf(PostHeld.Items.FindByValue(Ep.Postheld.ToString()));
            BPS.SelectedIndex = BPS.Items.IndexOf(BPS.Items.FindByValue(Ep.BpsId.ToString()));
            PostStatus.SelectedIndex = PostStatus.Items.IndexOf(PostStatus.Items.FindByValue(Ep.PostStatus.ToString()));
            if (Ep.Is_gazetted == 1)
                NonGazette.Checked = false;
            else
                NonGazette.Checked = true;
            EmpStatus.SelectedIndex = EmpStatus.Items.IndexOf(EmpStatus.Items.FindByValue(Ep.EmpStatusId.ToString()));
            GovtSrvEntry.Text = Ep.GovtServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.GovtServStDate) : string.Empty;
            SenEntry.Text = Ep.SenServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.SenServStDate) : string.Empty;
            PrevBranch.SelectedIndex = PrevBranch.Items.IndexOf(PrevBranch.Items.FindByValue(Ep.PrevDept.ToString()));
            PrevPostHeld.SelectedIndex = PrevPostHeld.Items.IndexOf(PrevPostHeld.Items.FindByValue(Ep.PrevPost.ToString()));
            EmpPoolDDL.SelectedIndex = EmpPoolDDL.Items.IndexOf(EmpPoolDDL.Items.FindByValue(Ep.EmpPoolId.ToString()));
            //if (Ep.NonGazFrom!=null)
            NonGazFrom.Text = Ep.NonGazFrom.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.NonGazFrom) : string.Empty;
            NonGazTo.Text = Ep.NonGazTo.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}",Ep.NonGazTo) : string.Empty;
            GazFrom.Text = Ep.GazFrom.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.GazFrom) : string.Empty;
            GazTo.Text = Ep.GazTo.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.GazTo) : string.Empty;
            SuperDate.Text = Ep.SuperDate.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.SuperDate) : string.Empty;
            ProbFrom.Text = Ep.ProbFrom.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.ProbFrom) : string.Empty;
            ProbTo.Text = Ep.ProbTo.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.ProbTo) : string.Empty;
            ProbExtended.SelectedIndex = ProbExtended.Items.IndexOf(ProbExtended.Items.FindByValue(Ep.IsProbExt.ToString()));
            ProbExtReason.Text = Ep.ProbExtReason;
            ReEmpFrom.Text = Ep.ReEmpFrom.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.ReEmpFrom) : string.Empty;
            ReEmpTo.Text = Ep.ReEmpTo.ToShortDateString();//.HasValue ? String.Format("{0:dd/MM/yyyy}", Ep.ReEmpTo) : string.Empty;
            //ReEmpPeriod.Text=Ep.

        }
        protected void bindCombos()
        {
            List<BPS> bps = new BPSHandler().GetAllBPS();
            foreach (BPS row in bps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.BpsId.ToString();
                BPS.Items.Add(li);
            }
            List<Post> posts = new PostsHandler().GetAllPosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                PostHeld.Items.Add(li);
            }
            List<EmployeePools> EmpPools = new EmployeePoolsHandler().GetEmpPools();
            foreach (EmployeePools row in EmpPools)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpPoolsId.ToString();
                EmpPoolDDL.Items.Add(li);
            }
            List<Branch> branch = new BranchHandler().GetBranches();
            foreach (Branch row in branch)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Branchid.ToString();
                Branch.Items.Add(li);
            }
            List<Branch> Prevbranch = new BranchHandler().GetBranches();
            foreach (Branch row in Prevbranch)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Branchid.ToString();
                PrevBranch.Items.Add(li);
            }
            List<PostStatus> ps = new postStatusHandler().GetPostStatus();
            foreach (PostStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostStatusID.ToString();
                PostStatus.Items.Add(li);
            }
            List<Post> prevposts = new PostsHandler().GetAllPosts();
            foreach (Post row in prevposts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                PrevPostHeld.Items.Add(li);
            }
            List<EmpStatus> empStatus = new EmpStatusHandler().GetEmpStatusList();
            foreach (EmpStatus row in empStatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatus.Items.Add(li);
            }

        }
        public string GetBranch(int BranchId)
        {
            Branch br = new BranchHandler().GetBranch(BranchId);
            return br.Description;
        }
        public string GetPost(int PostId)
        {
            Post pt = new PostsHandler().GetPost(PostId);
            return pt.Description;

        }
        ////////////////List View\\\\\\\\\\\\\\\\\\\\\\
        protected void EmpHistory_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpHistory.InsertItemPosition = InsertItemPosition.None;
            EmpHistory.SelectedIndex = -1;
            EmpHistory.EditIndex = e.NewEditIndex;
            bindEmpHistory(empval);
            e.Cancel = true;


        }
        protected void EmpPromotion_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPromotion.InsertItemPosition = InsertItemPosition.None;
            EmpPromotion.SelectedIndex = -1;
            EmpPromotion.EditIndex = e.NewEditIndex;
            bindEmpPromotion(empval);
            e.Cancel = true;


        }
        protected void EmpHistory_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpHistory.EditIndex = -1;
            EmpHistory.InsertItemPosition = InsertItemPosition.None;
            EmpHistory.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpHistory(empval);
            e.Cancel = true;
        }
        protected void EmpHistory_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpHistory.EditIndex == (e.Item as ListViewDataItem).DataItemIndex || EmpPromotion.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList designation = e.Item.FindControl("DesignationDDL") as DropDownList;
                designation.Items.Add(new ListItem("Select", "0"));
                //if (!IsPostBack)
                //{
                List<Post> pt = new PostsHandler().GetAllPosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
                }
                //}
                HiddenField DesigId = (e.Item.FindControl("HidDesignationId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList branch = e.Item.FindControl("BranchDDL") as DropDownList;
                branch.Items.Add(new ListItem("Select", "0"));
                //if (!IsPostBack)
                //{
                List<Branch> br = new BranchHandler().GetBranches();
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Branchid.ToString();
                    branch.Items.Add(li);
                }
                //}
                HiddenField BrId = (e.Item.FindControl("HidBranchId") as HiddenField);
                branch.SelectedValue = BrId.Value.ToString();
            }
        }
        protected void EmpHistory_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpHistory.EditItem)) { e.Cancel = true; return; }

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField HistoryId = EmpHistory.EditItem.FindControl("HidEmpHistoryId") as HiddenField;
            DropDownList DesignationId = EmpHistory.EditItem.FindControl("DesignationDDL") as DropDownList;
            DropDownList BranchId = EmpHistory.EditItem.FindControl("BranchDDL") as DropDownList;
            TextBox PostedFrom = EmpHistory.EditItem.FindControl("PostedFromTxt") as TextBox;
            TextBox PostedTo = EmpHistory.EditItem.FindControl("PostedToTxt") as TextBox;
            TextBox Remarks = EmpHistory.EditItem.FindControl("RemarksTxt") as TextBox;
            EmploymentHistory eh = new EmploymentHistory();
            eh.EmpId = empval;
            eh.HistoryId = Convert.ToInt32(HistoryId.Value);
            eh.BranchId = Convert.ToInt32(BranchId.SelectedItem.Value);
            eh.DesigId = Convert.ToInt32(DesignationId.SelectedItem.Value);
            eh.StayFrom = Convert.ToDateTime(PostedFrom.Text);
            eh.StayTo = Convert.ToDateTime(PostedTo.Text);
            eh.Rems = Convert.ToString(Remarks.Text);
            new EmployeeHandler().SaveEmployeeHistory(eh);
            EmpHistory.EditIndex = -1;
            bindEmpHistory(empval);
            EmpHistory.InsertItemPosition = InsertItemPosition.None;
            EmpHistory.SelectedIndex = -1;
            e.Cancel = true;

        }
        protected void EmpHistory_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpHistoryId = (HiddenField)EmpHistory.Items[e.ItemIndex].FindControl("HidEmpHistoryId");
            int EmpHistId = Convert.ToInt32(EmpHistoryId.Value);
            new EmployeeHandler().DeleteEmployementHistory(EmpHistId);
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpHistory(empval);
        }
        protected void EmpDetailButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpHistory.SelectedIndex = -1;
            EmpHistory.EditIndex = -1;
            EmpHistory.InsertItemPosition = InsertItemPosition.LastItem;
            bindEmpHistory(empval);

        }
        protected void NewPromButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPromotion.SelectedIndex = -1;
            EmpPromotion.EditIndex = -1;
            EmpPromotion.InsertItemPosition = InsertItemPosition.LastItem;
            bindEmpPromotion(empval);

        }
        protected void EmpHistory_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("DesignationDDL") as DropDownList);
            if (designation != null)
            {
                designation.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new PostsHandler().GetAllPosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
                }
            }

            DropDownList branch = new DropDownList();
            branch = (e.Item.FindControl("BranchDDL") as DropDownList);
            if (branch != null)
            {

                branch.Items.Add(new ListItem("Select", "0"));

                List<Branch> br = new BranchHandler().GetBranches();
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Branchid.ToString();
                    branch.Items.Add(li);
                }
            }
        }
        protected void EmpPromotion_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("DesignationDDL") as DropDownList);
            if (designation != null)
            {
                designation.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new PostsHandler().GetAllPosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
                }
            }

            DropDownList branch = new DropDownList();
            branch = (e.Item.FindControl("BranchDDL") as DropDownList);
            if (branch != null)
            {

                branch.Items.Add(new ListItem("Select", "0"));

                List<Branch> br = new BranchHandler().GetBranches();
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Branchid.ToString();
                    branch.Items.Add(li);
                }
            }


        }

        protected void EmpHistory_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpHistory.InsertItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList designation = (DropDownList)EmpHistory.InsertItem.FindControl("DesignationDDL");
            DropDownList branch = (DropDownList)EmpHistory.InsertItem.FindControl("BranchDDL");
            TextBox postedfrom = (TextBox)EmpHistory.InsertItem.FindControl("PostedFromTxt");
            TextBox postedto = (TextBox)EmpHistory.InsertItem.FindControl("PostedToTxt");
            TextBox remarks = (TextBox)EmpHistory.InsertItem.FindControl("RemarksTxt");
            EmploymentHistory eh = new EmploymentHistory();
            eh.EmpId = empval;
            eh.DesigId = Convert.ToInt32(designation.SelectedItem.Value);
            eh.BranchId = Convert.ToInt32(branch.SelectedItem.Value);
            eh.StayFrom = Convert.ToDateTime(postedfrom.Text);
            eh.StayTo = Convert.ToDateTime(postedto.Text);
            eh.Rems = Convert.ToString(remarks.Text);
            new EmployeeHandler().InsertEmployeeHistory(eh);
            EmpHistory.EditIndex = -1;
            EmpHistory.InsertItemPosition = InsertItemPosition.None;
            bindEmpHistory(empval);
            e.Cancel = true;
        }
        protected void EmpPromotion_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList designation = (DropDownList)EmpPromotion.InsertItem.FindControl("DesignationDDL");
            DropDownList branch = (DropDownList)EmpPromotion.InsertItem.FindControl("BranchDDL");
            TextBox promotiondate = (TextBox)EmpPromotion.InsertItem.FindControl("PromotionDateTxt");
            TextBox remarks = (TextBox)EmpPromotion.InsertItem.FindControl("RemarksTxt");
            PromotionHistory eh = new PromotionHistory();
            eh.EmpId = empval;
            eh.PostId = Convert.ToInt32(designation.SelectedItem.Value);
            eh.BranchId = Convert.ToInt32(branch.SelectedItem.Value);
            eh.PromotionDate = Convert.ToDateTime(promotiondate.Text);
            eh.Remarks = Convert.ToString(remarks.Text);
            new EmployeeHandler().InsertEmployeePromotion(eh);
            EmpPromotion.EditIndex = -1;
            EmpPromotion.InsertItemPosition = InsertItemPosition.None;
            bindEmpPromotion(empval);
            e.Cancel = true;
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            EmpEmployment employment = new EmpEmployment();
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            employment.EmpId = empval;
            employment.File_no = FileNo.Text;

            employment.EmpPoolId = Convert.ToInt32(EmpPoolDDL.SelectedValue);
            employment.Branch = Convert.ToInt32(Branch.SelectedValue);
            employment.Postheld = Convert.ToInt32(PostHeld.SelectedValue);
            employment.BpsId = Convert.ToInt32(BPS.SelectedValue);
            employment.PostStatus = Convert.ToInt32(PostStatus.SelectedValue);
            employment.Gazzetted = (NonGazette.Enabled) ? 1 : 0;
            employment.EmpStatusId = Convert.ToInt32(EmpStatus.SelectedValue);
            if (GovtSrvEntry.Text != "")
                employment.GovtServStDate = Convert.ToDateTime(GovtSrvEntry.Text);
            if (SenEntry.Text != "")
                employment.SenServStDate = Convert.ToDateTime(SenEntry.Text);
            employment.PrevDept = Convert.ToInt32(PrevBranch.SelectedValue);
            employment.PrevPost = Convert.ToInt32(PrevPostHeld.SelectedValue);
            if (NonGazFrom.Text != "")
                employment.NonGazFrom = Convert.ToDateTime(NonGazFrom.Text);
            if (NonGazTo.Text != "")
                employment.NonGazTo = Convert.ToDateTime(NonGazTo.Text);
            if (GazFrom.Text != "")
                employment.GazFrom = Convert.ToDateTime(GazFrom.Text);
            if (GazTo.Text != "")
                employment.GazTo = Convert.ToDateTime(GazTo.Text);
            if (SuperDate.Text != "")
                employment.SuperDate = Convert.ToDateTime(SuperDate.Text);
            if (ProbFrom.Text != "")
                employment.ProbFrom = Convert.ToDateTime(ProbFrom.Text);
            if (ProbTo.Text != "")
                employment.ProbTo = Convert.ToDateTime(ProbTo.Text);
            employment.IsProbExt = Convert.ToInt32(ProbExtended.SelectedValue);
            if (ProbExtTo.Text != "")
                employment.ProbExtTo = Convert.ToDateTime(ProbExtTo.Text);
            if (ProbExtReason.Text != "")
                employment.ProbExtReason = Convert.ToString(ProbExtReason.Text);
            if (ReEmpFrom.Text != "")
                employment.ReEmpFrom = Convert.ToDateTime(ReEmpFrom.Text);
            if (ReEmpTo.Text != "")
                employment.ReEmpTo = Convert.ToDateTime(ReEmpTo.Text);
            employment.ReEmpPeriod = Convert.ToString(ReEmpPeriod.Text);
            new EmployeeHandler().UpdateEmpEmployment(employment);
            //bindEmployment(empval);





        }
        protected void EmpPromotion_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpHistoryId = (HiddenField)EmpHistory.Items[e.ItemIndex].FindControl("HidEmpHistoryId");
            int EmpHistId = Convert.ToInt32(EmpHistoryId.Value);
            new EmployeeHandler().DeleteEmployementHistory(EmpHistId);
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpHistory(empval);
        }
    }
}