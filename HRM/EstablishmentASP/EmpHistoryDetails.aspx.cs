using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class EmpHistoryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int empval;
            
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            
            if (!IsPostBack)
            {
               
                bindEmpHistory(empval);
                
            }


        }
        protected void bindEmpHistory(int empval)
        {
            List<EmpHistory> EmpHist = new EmploymentBIZ().GetRegEmployment(empval);

            EmpHistory.DataSource = EmpHist;
            EmpHistory.DataBind();
        }
        public string GetBranch(int BranchId)
        {
            if (BranchId <= 0)
                return "Not Mentioned";
            else
            {
                Branch br = new AdministrationBIZ().GetBranch(BranchId);
                return br.Description;
            }
        }
        public string GetBps(int Bpsid)
        {
            if (Bpsid <= 0)
                return "Not Mentioned";
            else
            {
                BPS br = new AdministrationBIZ().GetBPS(Bpsid);
                return br.Description;
            }
        }
        public string GetPost(int PostId)
        {
            if (PostId <= 0)
                return "Not Mentioned";
            else
            {
                Post pt = new AdministrationBIZ().GetPost(PostId);
                return pt.Description;
            }

        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
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
            if (EmpHistory.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || EmpPromotion.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList designation = e.Item.FindControl("DesignationDDL") as DropDownList;
                designation.Items.Add(new ListItem("Select", "0"));
                //if (!IsPostBack)
                //{
                List<Post> pt = new AdministrationBIZ().GetActivePosts();

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
                List<Branch> br = new AdministrationBIZ().GetBranches();
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
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("PostDDL") as DropDownList);
            if (designation != null)
            {
                designation.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new AdministrationBIZ().GetActivePosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
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
            DropDownList MedicalTypeDDL = new DropDownList();
            MedicalTypeDDL = (e.Item.FindControl("MedicalTypeDDL") as DropDownList);

            List<TempEntity> co = new AdministrationBIZ().GetMedicalTypes();
            if (MedicalTypeDDL != null)
            {
                MedicalTypeDDL.Items.Add(new ListItem("Select", "0"));
                foreach (TempEntity row in co)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    MedicalTypeDDL.Items.Add(li);

                }
            }
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
            EmpHistory.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmpHistory(empval);

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
            Response.Redirect("EmpHistoryDetails.aspx?empid="+ empval );
        }
        protected void EmpHistory_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("DesignationDDL") as DropDownList);
            if (designation != null)
            {
                designation.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new AdministrationBIZ().GetActivePosts();

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

                List<Branch> br = new AdministrationBIZ().GetBranches();
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Branchid.ToString();
                    branch.Items.Add(li);
                }
            }
        }
    }
}