using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class EmployeePostings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindPostingLv(empval);
            }

        }
        protected void bindPostingLv(int EmpId)
        {
            List<EmployeePosting> Eq = new EmployeeHandler().GetEmployeePostings(EmpId);
            EmpPostingLv.DataSource = Eq;
            EmpPostingLv.DataBind();


        }
        protected string GetAdditionalBranches(ListBox lb)
        {
            string values = String.Empty;
            foreach (ListItem listItem in lb.Items)
            {
                if (listItem.Selected == true)
                {
                    values += listItem.Value.ToString();
                    values += ",";
                }
            }
            values = values.TrimEnd(',');
            return values;
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPostingLv.SelectedIndex = -1;
            EmpPostingLv.EditIndex = -1;
            EmpPostingLv.InsertItemPosition = InsertItemPosition.FirstItem;
            bindPostingLv(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpPostingLv.EditIndex = -1;
            EmpPostingLv.InsertItemPosition = InsertItemPosition.None;
            EmpPostingLv.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPostingLv(empval);
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("PostDDL") as DropDownList);
            if (designation != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new AdministrationBIZ().GetActivePosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
                }
            }
            ListBox additionalBranchesLB = new ListBox();
            additionalBranchesLB = (e.Item.FindControl("additionalBranchesLB") as ListBox);
            if (additionalBranchesLB != null)
            {
                List<Branch> pt = new AdministrationBIZ().GetBranches();

                foreach (Branch row in pt)
                {
                    ListItem by = new ListItem();
                    by.Value = row.Branchid.ToString();
                    by.Text = row.Description.ToString();
                    additionalBranchesLB.Items.Add(by);
                }
            }

            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {

                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> bpslist = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in bpslist)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }
            
            DropDownList branch = new DropDownList();
            branch = (e.Item.FindControl("BranchDDL") as DropDownList);
            List<Branch> br = new AdministrationBIZ().GetBranches();
            if (branch != null)
            {
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Branchid.ToString();
                    branch.Items.Add(li);
                    
                }
            }


        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpPostingLv.InsertItem)) { e.Cancel = true; return; }
            Label err = (Label)EmpPostingLv.InsertItem.FindControl("ErrorLabel");
            CheckBox CurrentStatusDDL = (CheckBox)EmpPostingLv.InsertItem.FindControl("WorkingCB");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (new EmployeeHandler().GetWorkingStatus(empval) !=0 && CurrentStatusDDL.Checked == true)
                err.Text = "Employee already posted in another branch";
            else
            {
                //int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                EmployeePosting eh = new EmployeePosting();
                eh.System_Users_Id = empval;
                DropDownList PostDDL = EmpPostingLv.InsertItem.FindControl("PostDDL") as DropDownList;
                DropDownList BPSDDL = EmpPostingLv.InsertItem.FindControl("BPSDDL") as DropDownList;
                DropDownList BranchDDL = EmpPostingLv.InsertItem.FindControl("BranchDDL") as DropDownList;
                //TextBox FromBranch = EmpPostingLv.InsertItem.FindControl("FromBranchTxt") as TextBox;
                //TextBox ToBranch = EmpPostingLv.InsertItem.FindControl("ToBranchTxt") as TextBox;
                TextBox DateFrom = EmpPostingLv.InsertItem.FindControl("DateFromTxt") as TextBox;
                TextBox DateTo = EmpPostingLv.InsertItem.FindControl("DateToTxt") as TextBox;
                CheckBox working = (CheckBox)EmpPostingLv.InsertItem.FindControl("WorkingCB");
                TextBox Remarks = EmpPostingLv.InsertItem.FindControl("RemarksTxt") as TextBox;
                ListBox AdditionalBranchesLB= EmpPostingLv.InsertItem.FindControl("AdditionalBranchesLB") as ListBox;
                string AdditionalBranches = GetAdditionalBranches(AdditionalBranchesLB);
                eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
                eh.BPS = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                // eh.From_Branch = Convert.ToString(FromBranch.Text);
                //  eh.To_Branch = Convert.ToString(ToBranch.Text);
                eh.BranchId = Convert.ToInt32(BranchDDL.SelectedItem.Value);
                eh.Date_From = Convert.ToDateTime(DateFrom.Text);
                if (!String.IsNullOrEmpty(DateTo.Text))
                    eh.Date_To = Convert.ToDateTime(DateTo.Text);
                eh.Working = (working.Checked) ? 1 : 0;
                eh.Remarks = Convert.ToString(Remarks.Text);
                int id=new EmployeeHandler().InsertEmployeePosting(eh);
                InsertAdditionalBranches(id, AdditionalBranches,eh.System_Users_Id,eh.Working);
                EmpPostingLv.EditIndex = -1;
                EmpPostingLv.InsertItemPosition = InsertItemPosition.None;
                EmpPostingLv.SelectedIndex = -1;
                bindPostingLv(empval);
                e.Cancel = true;
            }
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void InsertAdditionalBranches(int PostingId,string AdditionalBranches,int SystemUsersId,int working)
        {
            if(working==1)
            new EmployeeHandler().UpdateBranchesInMainEmployment(AdditionalBranches,SystemUsersId);
            new EmployeeHandler().DeleteAdditionalBranches(PostingId);
            if (!String.IsNullOrEmpty(AdditionalBranches))
            {
                List<int> AdditionalBranchesId = AdditionalBranches.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (AdditionalBranchesId != null)
                {
                    foreach (int dq in AdditionalBranchesId)
                    {
                        AdditionalBranchesEnt temp = new AdditionalBranchesEnt();
                        temp.PostingId = PostingId;
                        temp.AdditionalBranchesId = dq;
                        new EmployeeHandler().InsertAdditionalBranch(temp);
                    }
                }
            }
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPostingLv.InsertItemPosition = InsertItemPosition.None;
            EmpPostingLv.SelectedIndex = -1;
            EmpPostingLv.EditIndex = e.NewEditIndex;
            bindPostingLv(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpPostingLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList branch = e.Item.FindControl("BranchDDL") as DropDownList;
                HiddenField branchId = (e.Item.FindControl("HidBranchId") as HiddenField);
                branch.SelectedValue = branchId.Value.ToString();

                CheckBox working = e.Item.FindControl("WorkingCB") as CheckBox;
                HiddenField workingid = (e.Item.FindControl("HidWorking") as HiddenField);
                working.Checked = (Convert.ToInt32(workingid.Value) == 1) ? true : false;

                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                ListBox additionalBranchesLB = e.Item.FindControl("additionalBranchesLB") as ListBox;
                HiddenField postingId = e.Item.FindControl("HidEmpPostingId") as HiddenField;
                int i = Convert.ToInt32(postingId.Value);
                List<AdditionalBranchesEnt> additionalBranches = new EmployeeHandler().GetAdditionalBranches(i);
                if (additionalBranches != null)
                {
                    foreach (AdditionalBranchesEnt AddBr in additionalBranches)
                    {
                        foreach (ListItem b in additionalBranchesLB.Items)
                        {

                            if (Convert.ToInt32(AddBr.AdditionalBranchesId) == Convert.ToInt32(b.Value)) 
                                b.Selected = true;
                        }

                    }
                }
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpPostingLv.EditItem)) { e.Cancel = true; return; }
            Label err = (Label)EmpPostingLv.EditItem.FindControl("ErrorLabel");
            CheckBox CurrentStatusDDL = (CheckBox)EmpPostingLv.EditItem.FindControl("WorkingCB");
            HiddenField EmpPostingId = EmpPostingLv.EditItem.FindControl("HidEmpPostingId") as HiddenField;
            int postingid = Convert.ToInt32(EmpPostingId.Value);
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
           
            if (new EmployeeHandler().GetWorkingStatus(empval)!=0 && new EmployeeHandler().GetWorkingStatus(empval) !=postingid && CurrentStatusDDL.Checked == true)
                err.Text = "Employee already posted in another branch";
            else
            {
                err.Text = "";
               // int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                EmployeePosting eh = new EmployeePosting();
                eh.System_Users_Id = empval;
                DropDownList PostDDL = EmpPostingLv.EditItem.FindControl("PostDDL") as DropDownList;
                DropDownList BranchDDL = EmpPostingLv.EditItem.FindControl("BranchDDL") as DropDownList;
                DropDownList BPSDDL = EmpPostingLv.EditItem.FindControl("BPSDDL") as DropDownList;
                // TextBox FromBranch = EmpPostingLv.EditItem.FindControl("FromBranchTxt") as TextBox;
                // TextBox ToBranch = EmpPostingLv.EditItem.FindControl("ToBranchTxt") as TextBox;
                TextBox DateFrom = EmpPostingLv.EditItem.FindControl("DateFromTxt") as TextBox;
                TextBox DateTo = EmpPostingLv.EditItem.FindControl("DateToTxt") as TextBox;
                CheckBox working = (CheckBox)EmpPostingLv.EditItem.FindControl("WorkingCB");
                TextBox Remarks = EmpPostingLv.EditItem.FindControl("RemarksTxt") as TextBox;
                ListBox AdditionalBranchesLB = EmpPostingLv.EditItem.FindControl("AdditionalBranchesLB") as ListBox;
                string AdditionalBranches = GetAdditionalBranches(AdditionalBranchesLB);
                // HiddenField EmpPostingId = EmpPostingLv.EditItem.FindControl("HidEmpPostingId") as HiddenField;
                eh.Emp_Posting_id = postingid;
                eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
                eh.BPS = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                //eh.From_Branch = Convert.ToString(FromBranch.Text);
                //eh.To_Branch = Convert.ToString(ToBranch.Text);
                eh.BranchId = Convert.ToInt32(BranchDDL.SelectedItem.Value);
                eh.Date_From = Convert.ToDateTime(DateFrom.Text);
                if (!String.IsNullOrEmpty(DateTo.Text))
                    eh.Date_To = Convert.ToDateTime(DateTo.Text);
                eh.Working = (working.Checked) ? 1 : 0;
                eh.Remarks = Convert.ToString(Remarks.Text);
                new EmployeeHandler().UpdateEmployeePosting(eh);
                //new EmployeeHandler().DeleteAdditionalBranches(eh.Emp_Posting_id);
                InsertAdditionalBranches(eh.Emp_Posting_id, AdditionalBranches,eh.System_Users_Id,eh.Working);
                EmpPostingLv.EditIndex = -1;
                EmpPostingLv.InsertItemPosition = InsertItemPosition.None;
                EmpPostingLv.SelectedIndex = -1;
                bindPostingLv(empval);
                e.Cancel = true;
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidEmpPostingId = (HiddenField)EmpPostingLv.Items[e.ItemIndex].FindControl("HidEmpPostingId");
            int EmpPostingId = Convert.ToInt32(HidEmpPostingId.Value);
            new EmployeeHandler().DeleteEmployeePosting(EmpPostingId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPostingLv(empval);
        }

    }
}