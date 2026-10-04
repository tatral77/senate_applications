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
    public partial class SuspensionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                BindDisciplinaryActionLV(empval);
            }

        }
        protected void BindDisciplinaryActionLV(int EmpId)
        {
            List<DisciplinaryAction> Eq = new EmploymentBIZ().GetEmpSuspension(EmpId);
            DisciplinaryActionLV.DataSource = Eq;
            DisciplinaryActionLV.DataBind();


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DisciplinaryActionLV.SelectedIndex = -1;
            DisciplinaryActionLV.EditIndex = -1;
            DisciplinaryActionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDisciplinaryActionLV(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            DisciplinaryActionLV.EditIndex = -1;
            DisciplinaryActionLV.InsertItemPosition = InsertItemPosition.None;
            DisciplinaryActionLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindDisciplinaryActionLV(empval);
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList DiscipActionDDL = new DropDownList();
            DiscipActionDDL = (e.Item.FindControl("DiscipActionDDL") as DropDownList);
            if (DiscipActionDDL != null)
            {
                DiscipActionDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> ct = new AdministrationBIZ().GetDiscipActionTypes();

                foreach (TempEntity row in ct)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Id.ToString();
                    li.Text = row.Description.ToString();
                    DiscipActionDDL.Items.Add(li);
                }
            }

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
            DropDownList FinalActionTypeDDL = new DropDownList();
            FinalActionTypeDDL = (e.Item.FindControl("ActionTypeDDL") as DropDownList);
            if (FinalActionTypeDDL != null)
            {
                FinalActionTypeDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> ct = new AdministrationBIZ().GetFinalDiscipActionTypes();

                foreach (TempEntity row in ct)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Id.ToString();
                    li.Text = row.Description.ToString();
                    FinalActionTypeDDL.Items.Add(li);
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
            if (!HrmDates.RangeOk(DisciplinaryActionLV.InsertItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DisciplinaryAction eh = new DisciplinaryAction();
           // DropDownList DiscipActionDDL = DisciplinaryActionLV.InsertItem.FindControl("DiscipActionDDL") as DropDownList;
           // TextBox OnDateTxt = DisciplinaryActionLV.InsertItem.FindControl("OnDateTxt") as TextBox;
            DropDownList PostDDL = DisciplinaryActionLV.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = DisciplinaryActionLV.InsertItem.FindControl("BPSDDL") as DropDownList;
            TextBox FromDateTxt = DisciplinaryActionLV.InsertItem.FindControl("DateFromTxt") as TextBox;
            TextBox ToDateTxt = DisciplinaryActionLV.InsertItem.FindControl("DateToTxt") as TextBox;
            DropDownList ActionTypeDDL = DisciplinaryActionLV.InsertItem.FindControl("ActionTypeDDL") as DropDownList;
            TextBox FinalActionDateTxt = DisciplinaryActionLV.InsertItem.FindControl("FinalActionDateTxt") as TextBox;
            CheckBox IsLfpCalculatedCB = (CheckBox)DisciplinaryActionLV.InsertItem.FindControl("IsLfpCalculatedCB");
            CheckBox IsServiceCalculatedCB = (CheckBox)DisciplinaryActionLV.InsertItem.FindControl("IsServiceCalculatedCB");
            TextBox Remarks = DisciplinaryActionLV.InsertItem.FindControl("RemarksTxt") as TextBox;
            eh.SystemUserId = empval;
           // eh.DisciplinaryActionTypeId = Convert.ToInt32(DiscipActionDDL.SelectedItem.Value);
           // eh.ActionDate = Convert.ToDateTime(OnDateTxt.Text);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(FromDateTxt.Text);
            if(!String.IsNullOrEmpty(ToDateTxt.Text))
            eh.ToDate = Convert.ToDateTime(ToDateTxt.Text);
            eh.FinalActionTypeId = Convert.ToInt32(ActionTypeDDL.SelectedItem.Value);
            eh.FinalActionDate = Convert.ToDateTime(FinalActionDateTxt.Text);
            eh.IsLfpCalculated = (IsLfpCalculatedCB.Checked == true) ? 1 : 0;
            eh.IsServiceCalculated = (IsServiceCalculatedCB.Checked == true) ? 1 : 0;
            eh.Details = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertEmpSuspension(eh);
            DisciplinaryActionLV.EditIndex = -1;
            DisciplinaryActionLV.InsertItemPosition = InsertItemPosition.None;
            DisciplinaryActionLV.SelectedIndex = -1;
            BindDisciplinaryActionLV(empval);
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
            DisciplinaryActionLV.InsertItemPosition = InsertItemPosition.None;
            DisciplinaryActionLV.SelectedIndex = -1;
            DisciplinaryActionLV.EditIndex = e.NewEditIndex;
            BindDisciplinaryActionLV(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (DisciplinaryActionLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                //DropDownList DiscipActionDDL = e.Item.FindControl("DiscipActionDDL") as DropDownList;
                //HiddenField HidDiscipActionId = (e.Item.FindControl("HidDisciplinaryActionTypeId") as HiddenField);
                //DiscipActionDDL.SelectedValue = HidDiscipActionId.Value.ToString();

                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                DropDownList ActionTypeDDL = e.Item.FindControl("ActionTypeDDL") as DropDownList;
                HiddenField HidActionTypeId = (e.Item.FindControl("HidFinalActionTypeId") as HiddenField);
                ActionTypeDDL.SelectedValue = HidActionTypeId.Value.ToString();

                CheckBox IsLfpCalculatedCB = e.Item.FindControl("IsLfpCalculatedCB") as CheckBox;
                if (IsLfpCalculatedCB != null)
                {
                    HiddenField IsExtended = (e.Item.FindControl("HidIsLfpCalculated") as HiddenField);
                    if (Convert.ToInt32(IsExtended.Value) == 1)
                        IsLfpCalculatedCB.Checked = true;
                    else
                        IsLfpCalculatedCB.Checked = false;
                }
                CheckBox IsServiceCalculatedCB = e.Item.FindControl("IsServiceCalculatedCB") as CheckBox;
                if (IsServiceCalculatedCB != null)
                {
                    HiddenField IsGaz = (e.Item.FindControl("HidIsSeriviceCalculated") as HiddenField);
                    if (Convert.ToInt32(IsGaz.Value) == 1)
                        IsServiceCalculatedCB.Checked = true;
                    else
                        IsServiceCalculatedCB.Checked = false;
                }
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(DisciplinaryActionLV.EditItem)) { e.Cancel = true; return; }
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DisciplinaryAction eh = new DisciplinaryAction();
            HiddenField HidDisciplinaryActionId = DisciplinaryActionLV.EditItem.FindControl("HidDisciplinaryActionId") as HiddenField;
           // DropDownList DiscipActionDDL = DisciplinaryActionLV.EditItem.FindControl("DiscipActionDDL") as DropDownList;
           // TextBox OnDateTxt = DisciplinaryActionLV.EditItem.FindControl("OnDateTxt") as TextBox;
            DropDownList PostDDL = DisciplinaryActionLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = DisciplinaryActionLV.EditItem.FindControl("BPSDDL") as DropDownList;
            TextBox FromDateTxt = DisciplinaryActionLV.EditItem.FindControl("DateFromTxt") as TextBox;
            TextBox ToDateTxt = DisciplinaryActionLV.EditItem.FindControl("DateToTxt") as TextBox;
            DropDownList ActionTypeDDL = DisciplinaryActionLV.EditItem.FindControl("ActionTypeDDL") as DropDownList;
            TextBox FinalActionDateTxt = DisciplinaryActionLV.EditItem.FindControl("FinalActionDateTxt") as TextBox;
            CheckBox IsLfpCalculatedCB = (CheckBox)DisciplinaryActionLV.EditItem.FindControl("IsLfpCalculatedCB");
            CheckBox IsServiceCalculatedCB = (CheckBox)DisciplinaryActionLV.EditItem.FindControl("IsServiceCalculatedCB");
            TextBox Remarks = DisciplinaryActionLV.EditItem.FindControl("RemarksTxt") as TextBox;
            eh.DisciplinaryActionId = Convert.ToInt32(HidDisciplinaryActionId.Value);
          //  eh.DisciplinaryActionTypeId = Convert.ToInt32(DiscipActionDDL.SelectedItem.Value);
           // eh.ActionDate = Convert.ToDateTime(OnDateTxt.Text);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(FromDateTxt.Text);
            if (!String.IsNullOrEmpty(ToDateTxt.Text))
                eh.ToDate = Convert.ToDateTime(ToDateTxt.Text);
            eh.FinalActionTypeId = Convert.ToInt32(ActionTypeDDL.SelectedItem.Value);
            eh.FinalActionDate = Convert.ToDateTime(FinalActionDateTxt.Text);
            eh.IsLfpCalculated = (IsLfpCalculatedCB.Checked == true) ? 1 : 0;
            eh.IsServiceCalculated = (IsServiceCalculatedCB.Checked == true) ? 1 : 0;
            eh.Details = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateEmpSuspension(eh);
            DisciplinaryActionLV.EditIndex = -1;
            DisciplinaryActionLV.InsertItemPosition = InsertItemPosition.None;
            DisciplinaryActionLV.SelectedIndex = -1;
            BindDisciplinaryActionLV(empval);
            e.Cancel = true;


        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidDisciplinaryActionId = (HiddenField)DisciplinaryActionLV.Items[e.ItemIndex].FindControl("HidDisciplinaryActionId");
            int CId = Convert.ToInt32(HidDisciplinaryActionId.Value);
            new EmploymentBIZ().DeleteEmpSuspension(CId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindDisciplinaryActionLV(empval);
        }
    }
}