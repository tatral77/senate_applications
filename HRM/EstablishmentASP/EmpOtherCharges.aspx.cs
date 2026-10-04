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
    public partial class EmpOtherCharges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                BindOtherChargesLV(empval);
            }

        }
        protected void BindOtherChargesLV(int EmpId)
        {
            List<OtherCharges> Eq = new EmploymentBIZ().GetOtherCharges(EmpId);
            OtherChargesLV.DataSource = Eq;
            OtherChargesLV.DataBind();


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            OtherChargesLV.SelectedIndex = -1;
            OtherChargesLV.EditIndex = -1;
            OtherChargesLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindOtherChargesLV(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            OtherChargesLV.EditIndex = -1;
            OtherChargesLV.InsertItemPosition = InsertItemPosition.None;
            OtherChargesLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindOtherChargesLV(empval);
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
            DropDownList ChargeTypeDDL = new DropDownList();
            ChargeTypeDDL = (e.Item.FindControl("ChargeTypeDDL") as DropDownList);
            if (ChargeTypeDDL != null)
            {
                ChargeTypeDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> ct = new AdministrationBIZ().GetOtherChargeTypes();

                foreach (TempEntity row in ct)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Id.ToString();
                    li.Text = row.Description.ToString();
                    ChargeTypeDDL.Items.Add(li);
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
            if (!HrmDates.RangeOk(OtherChargesLV.InsertItem)) { e.Cancel = true; return; }
                int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                OtherCharges eh = new OtherCharges();
                eh.SystemUserId = empval;
                DropDownList ChargeTypeDDL = OtherChargesLV.InsertItem.FindControl("ChargeTypeDDL") as DropDownList;
                DropDownList PostDDL = OtherChargesLV.InsertItem.FindControl("PostDDL") as DropDownList;
                DropDownList BPSDDL = OtherChargesLV.InsertItem.FindControl("BPSDDL") as DropDownList;
                DropDownList BranchDDL = OtherChargesLV.InsertItem.FindControl("BranchDDL") as DropDownList;
                TextBox DateFrom = OtherChargesLV.InsertItem.FindControl("DateFromTxt") as TextBox;
                
                TextBox DateTo = OtherChargesLV.InsertItem.FindControl("DateToTxt") as TextBox;
                TextBox Remarks = OtherChargesLV.InsertItem.FindControl("RemarksTxt") as TextBox;
                eh.OtherChargeTypeId = Convert.ToInt32(ChargeTypeDDL.SelectedItem.Value);
                eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
                eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                eh.BranchId = Convert.ToInt32(BranchDDL.SelectedItem.Value);
                eh.FromDate = Convert.ToDateTime(DateFrom.Text);
                if (!String.IsNullOrEmpty(DateTo.Text))
                eh.ToDate = Convert.ToDateTime(DateTo.Text);
                eh.Remarks = Convert.ToString(Remarks.Text);
                new EmploymentBIZ().InsertOtherCharges(eh);
                OtherChargesLV.EditIndex = -1;
                OtherChargesLV.InsertItemPosition = InsertItemPosition.None;
                OtherChargesLV.SelectedIndex = -1;
                BindOtherChargesLV(empval);
                e.Cancel = true;
            
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            OtherChargesLV.InsertItemPosition = InsertItemPosition.None;
            OtherChargesLV.SelectedIndex = -1;
            OtherChargesLV.EditIndex = e.NewEditIndex;
            BindOtherChargesLV(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (OtherChargesLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList branch = e.Item.FindControl("BranchDDL") as DropDownList;
                HiddenField branchId = (e.Item.FindControl("HidBranchId") as HiddenField);
                branch.SelectedValue = branchId.Value.ToString();

             

                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                DropDownList ChargeTypeDDL = e.Item.FindControl("ChargeTypeDDL") as DropDownList;
                HiddenField HidChargeTypeId = (e.Item.FindControl("HidChargeTypeId") as HiddenField);
                ChargeTypeDDL.SelectedValue = HidChargeTypeId.Value.ToString();
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(OtherChargesLV.EditItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            OtherCharges eh = new OtherCharges();
            eh.SystemUserId = empval;
            HiddenField OtherChargeId = OtherChargesLV.EditItem.FindControl("HidOtherChargeId") as HiddenField;
            DropDownList ChargeTypeDDL = OtherChargesLV.EditItem.FindControl("ChargeTypeDDL") as DropDownList;
            DropDownList PostDDL = OtherChargesLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = OtherChargesLV.EditItem.FindControl("BPSDDL") as DropDownList;
            DropDownList BranchDDL = OtherChargesLV.EditItem.FindControl("BranchDDL") as DropDownList;
            TextBox DateFrom = OtherChargesLV.EditItem.FindControl("DateFromTxt") as TextBox;
            TextBox DateTo = OtherChargesLV.EditItem.FindControl("DateToTxt") as TextBox;
            TextBox Remarks = OtherChargesLV.EditItem.FindControl("RemarksTxt") as TextBox;
            eh.OtherChargeId= Convert.ToInt32(OtherChargeId.Value);
            eh.OtherChargeTypeId = Convert.ToInt32(ChargeTypeDDL.SelectedItem.Value);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.BranchId = Convert.ToInt32(BranchDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(DateFrom.Text);
            if (!String.IsNullOrEmpty(DateTo.Text))
                eh.ToDate = Convert.ToDateTime(DateTo.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateOtherCharges(eh);
            OtherChargesLV.EditIndex = -1;
            OtherChargesLV.InsertItemPosition = InsertItemPosition.None;
            OtherChargesLV.SelectedIndex = -1;
            BindOtherChargesLV(empval);
            e.Cancel = true;
                
            
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField OtherChargeId = (HiddenField)OtherChargesLV.Items[e.ItemIndex].FindControl("HidOtherChargeId");
            int CId = Convert.ToInt32(OtherChargeId.Value);
            new EmploymentBIZ().DeleteOtherCharges(CId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindOtherChargesLV(empval);
        }
    }
}