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
    public partial class EmployeeSecClearance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                BindSecurityClearanceLV(empval);
            }

        }
        protected void BindSecurityClearanceLV(int EmpId)
        {
            List<SecurityClearance> Eq = new EmploymentBIZ().GetSecurityClearance(EmpId);
            SecurityClearanceLV.DataSource = Eq;
            SecurityClearanceLV.DataBind();


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            SecurityClearanceLV.SelectedIndex = -1;
            SecurityClearanceLV.EditIndex = -1;
            SecurityClearanceLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindSecurityClearanceLV(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            SecurityClearanceLV.EditIndex = -1;
            SecurityClearanceLV.InsertItemPosition = InsertItemPosition.None;
            SecurityClearanceLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindSecurityClearanceLV(empval);
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
            DropDownList ClearanceTypeDDL = new DropDownList();
            ClearanceTypeDDL = (e.Item.FindControl("ClearanceTypeDDL") as DropDownList);
            if (ClearanceTypeDDL != null)
            {
                ClearanceTypeDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> ct = new AdministrationBIZ().GetSecClearanceTypes(); ;

                foreach (TempEntity row in ct)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Id.ToString();
                    li.Text = row.Description.ToString();
                    ClearanceTypeDDL.Items.Add(li);
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
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            SecurityClearance eh = new SecurityClearance();
            eh.SystemUserId = empval;
            DropDownList ClearanceTypeDDL = SecurityClearanceLV.InsertItem.FindControl("ClearanceTypeDDL") as DropDownList;
            DropDownList PostDDL = SecurityClearanceLV.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = SecurityClearanceLV.InsertItem.FindControl("BPSDDL") as DropDownList;
            TextBox OnDateTxt = SecurityClearanceLV.InsertItem.FindControl("DateOnTxt") as TextBox;
            TextBox Remarks = SecurityClearanceLV.InsertItem.FindControl("RemarksTxt") as TextBox;
            eh.SecClearanceTypeId = Convert.ToInt32(ClearanceTypeDDL.SelectedItem.Value);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.OnDate = Convert.ToDateTime(OnDateTxt.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertSecurityClearance(eh);
            SecurityClearanceLV.EditIndex = -1;
            SecurityClearanceLV.InsertItemPosition = InsertItemPosition.None;
            SecurityClearanceLV.SelectedIndex = -1;
            BindSecurityClearanceLV(empval);
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
            SecurityClearanceLV.InsertItemPosition = InsertItemPosition.None;
            SecurityClearanceLV.SelectedIndex = -1;
            SecurityClearanceLV.EditIndex = e.NewEditIndex;
            BindSecurityClearanceLV(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (SecurityClearanceLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                DropDownList ClearanceTypeDDL = e.Item.FindControl("ClearanceTypeDDL") as DropDownList;
                HiddenField HidChargeTypeId = (e.Item.FindControl("HidClearanceTypeId") as HiddenField);
                ClearanceTypeDDL.SelectedValue = HidChargeTypeId.Value.ToString();
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            SecurityClearance eh = new SecurityClearance();
            eh.SystemUserId = empval;
            HiddenField SecClearanceId = SecurityClearanceLV.EditItem.FindControl("HidEmpSecClearanceId") as HiddenField;
            DropDownList ClearanceTypeDDL = SecurityClearanceLV.EditItem.FindControl("ClearanceTypeDDL") as DropDownList;
            DropDownList PostDDL = SecurityClearanceLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = SecurityClearanceLV.EditItem.FindControl("BPSDDL") as DropDownList;
            TextBox OnDateTxt = SecurityClearanceLV.EditItem.FindControl("DateOnTxt") as TextBox;
            TextBox Remarks = SecurityClearanceLV.EditItem.FindControl("RemarksTxt") as TextBox;
            eh.SecurityClearanceId = Convert.ToInt32(SecClearanceId.Value);
            eh.SecClearanceTypeId = Convert.ToInt32(ClearanceTypeDDL.SelectedItem.Value);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.OnDate  = Convert.ToDateTime(OnDateTxt.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateSecurityClearance(eh);
            SecurityClearanceLV.EditIndex = -1;
            SecurityClearanceLV.InsertItemPosition = InsertItemPosition.None;
            SecurityClearanceLV.SelectedIndex = -1;
            BindSecurityClearanceLV(empval);
            e.Cancel = true;


        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField OtherChargeId = (HiddenField)SecurityClearanceLV.Items[e.ItemIndex].FindControl("HidEmpSecClearanceId");
            int CId = Convert.ToInt32(OtherChargeId.Value);
            new EmploymentBIZ().DeleteSecurityClearance(CId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindSecurityClearanceLV(empval);
        }
    }
}