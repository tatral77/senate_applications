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
    public partial class EmpDisciplinaryActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                BindDisciplinaryActionLV(empval);
                bindPenaltyLV(empval);
            }

        }
        protected void BindDisciplinaryActionLV(int EmpId)
        {
            List<DisciplinaryAction> Eq = new EmploymentBIZ().GetDisciplinaryAction(EmpId);
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
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DisciplinaryAction eh = new DisciplinaryAction();
            DropDownList DiscipActionDDL = DisciplinaryActionLV.InsertItem.FindControl("DiscipActionDDL") as DropDownList;
            TextBox OnDateTxt = DisciplinaryActionLV.InsertItem.FindControl("OnDateTxt") as TextBox;
            DropDownList PostDDL = DisciplinaryActionLV.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = DisciplinaryActionLV.InsertItem.FindControl("BPSDDL") as DropDownList;
            //TextBox FromDateTxt = DisciplinaryActionLV.InsertItem.FindControl("DateFromTxt") as TextBox;
            //TextBox ToDateTxt = DisciplinaryActionLV.InsertItem.FindControl("DateToTxt") as TextBox;
            DropDownList ActionTypeDDL = DisciplinaryActionLV.InsertItem.FindControl("ActionTypeDDL") as DropDownList;
            TextBox FinalActionDateTxt = DisciplinaryActionLV.InsertItem.FindControl("FinalActionDateTxt") as TextBox;
            TextBox Remarks = DisciplinaryActionLV.InsertItem.FindControl("RemarksTxt") as TextBox;
            eh.SystemUserId = empval;
            eh.DisciplinaryActionTypeId = Convert.ToInt32(DiscipActionDDL.SelectedItem.Value);
            eh.ActionDate = Convert.ToDateTime(OnDateTxt.Text);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            //eh.FromDate = Convert.ToDateTime(FromDateTxt.Text);
            //eh.ToDate = Convert.ToDateTime(ToDateTxt.Text);
            eh.FinalActionTypeId = Convert.ToInt32(ActionTypeDDL.SelectedItem.Value);
            if (!String.IsNullOrEmpty(FinalActionDateTxt.Text))
                eh.FinalActionDate = Convert.ToDateTime(FinalActionDateTxt.Text);
            eh.Details = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertDisciplinaryAction(eh);
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
                DropDownList DiscipActionDDL = e.Item.FindControl("DiscipActionDDL") as DropDownList;
                HiddenField HidDiscipActionId = (e.Item.FindControl("HidDisciplinaryActionTypeId") as HiddenField);
                DiscipActionDDL.SelectedValue = HidDiscipActionId.Value.ToString();

                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                DropDownList ActionTypeDDL = e.Item.FindControl("ActionTypeDDL") as DropDownList;
                HiddenField HidActionTypeId = (e.Item.FindControl("HidFinalActionTypeId") as HiddenField);
                ActionTypeDDL.SelectedValue = HidActionTypeId.Value.ToString();
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DisciplinaryAction eh = new DisciplinaryAction();
            HiddenField HidDisciplinaryActionId = DisciplinaryActionLV.EditItem.FindControl("HidDisciplinaryActionId") as HiddenField;
            DropDownList DiscipActionDDL = DisciplinaryActionLV.EditItem.FindControl("DiscipActionDDL") as DropDownList;
            TextBox OnDateTxt = DisciplinaryActionLV.EditItem.FindControl("OnDateTxt") as TextBox;
            DropDownList PostDDL = DisciplinaryActionLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = DisciplinaryActionLV.EditItem.FindControl("BPSDDL") as DropDownList;
            //TextBox FromDateTxt = DisciplinaryActionLV.EditItem.FindControl("DateFromTxt") as TextBox;
            //TextBox ToDateTxt = DisciplinaryActionLV.EditItem.FindControl("DateToTxt") as TextBox;
            DropDownList ActionTypeDDL = DisciplinaryActionLV.EditItem.FindControl("ActionTypeDDL") as DropDownList;
            TextBox FinalActionDateTxt = DisciplinaryActionLV.EditItem.FindControl("FinalActionDateTxt") as TextBox;
            TextBox Remarks = DisciplinaryActionLV.EditItem.FindControl("RemarksTxt") as TextBox;
            eh.DisciplinaryActionId= Convert.ToInt32(HidDisciplinaryActionId.Value);
            eh.DisciplinaryActionTypeId = Convert.ToInt32(DiscipActionDDL.SelectedItem.Value);
            eh.ActionDate = Convert.ToDateTime(OnDateTxt.Text);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            //eh.FromDate = Convert.ToDateTime(FromDateTxt.Text);
            //eh.ToDate = Convert.ToDateTime(ToDateTxt.Text);
            eh.FinalActionTypeId = Convert.ToInt32(ActionTypeDDL.SelectedItem.Value);
            if (!String.IsNullOrEmpty(FinalActionDateTxt.Text))
                eh.FinalActionDate = Convert.ToDateTime(FinalActionDateTxt.Text);
            eh.Details = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateDisciplinaryAction(eh);
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
            new EmploymentBIZ().DeleteDisciplinaryAction(CId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindDisciplinaryActionLV(empval);
        }


        protected void newPenalty_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PenaltyLV.SelectedIndex = -1;
            PenaltyLV.EditIndex = -1;
            PenaltyLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindPenaltyLV(empval);

        }
        protected void bindPenaltyLV(int EmpId)
        {
            List<EmpPenalty> re = new List<EmpPenalty>();
            re = new EmploymentBIZ().GetEmpPenalties(EmpId);
            PenaltyLV.DataSource = re;
            PenaltyLV.DataBind();
        }
        protected void Penalty_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField PenaltyId = (HiddenField)PenaltyLV.Items[e.ItemIndex].FindControl("HidPenaltyId");
            int EmpHistoryId = Convert.ToInt32(PenaltyId.Value);
            new EmploymentBIZ().DeleteEmpPenalties(EmpHistoryId);
            bindPenaltyLV(empval);
        }
        protected void Penalty_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField PenaltyId = PenaltyLV.EditItem.FindControl("HidPenaltyId") as HiddenField;
            DropDownList PenaltyTypeDDL = (DropDownList)PenaltyLV.EditItem.FindControl("PenaltyTypeDDL");            
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox PenaltyDate = (TextBox)PenaltyLV.EditItem.FindControl("PenaltyDateTxt");
            TextBox Remarks = (TextBox)PenaltyLV.EditItem.FindControl("RemarksTxt");
            Label ReferenceId = (Label)PenaltyLV.EditItem.FindControl("ReferenceIdTxt");
            EmpPenalty eh = new EmpPenalty();
            eh.PenaltyId = Convert.ToInt32(PenaltyId.Value);
            eh.DisciplinaryActionId = Convert.ToInt32(ReferenceId.Text);
            eh.SystemUsersId = empval;
            eh.PenaltyTypeId = Convert.ToInt32(PenaltyTypeDDL.SelectedItem.Value);
            eh.PenaltyDate = Convert.ToDateTime(PenaltyDate.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateEmpPenalties(eh);
            PenaltyLV.EditIndex = -1;
            PenaltyLV.InsertItemPosition = InsertItemPosition.None;
            bindPenaltyLV(empval);
            e.Cancel = true;


        }

        protected void Penalty_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox ReferenceId = (TextBox)PenaltyLV.InsertItem.FindControl("ReferenceIdTxt");
            DropDownList PenaltyTypeDDL = (DropDownList)PenaltyLV.InsertItem.FindControl("PenaltyTypeDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox PenaltyDate = (TextBox)PenaltyLV.InsertItem.FindControl("PenaltyDateTxt");
            TextBox Remarks = (TextBox)PenaltyLV.InsertItem.FindControl("RemarksTxt");
            EmpPenalty eh = new EmpPenalty();
            eh.SystemUsersId = empval;
            eh.DisciplinaryActionId = Convert.ToInt32(ReferenceId.Text);
            eh.PenaltyTypeId = Convert.ToInt32(PenaltyTypeDDL.SelectedItem.Value);
            eh.PenaltyDate = Convert.ToDateTime(PenaltyDate.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);        
            new EmploymentBIZ().InsertEmpPenalties(eh);
            PenaltyLV.EditIndex = -1;
            PenaltyLV.InsertItemPosition = InsertItemPosition.None;
            bindPenaltyLV(empval);
            e.Cancel = true;
            Response.Redirect("EmploymentDetails.aspx?empid=" + empval);

        }
        protected void Penalty_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            PenaltyLV.EditIndex = -1;
            PenaltyLV.InsertItemPosition = InsertItemPosition.None;
            PenaltyLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPenaltyLV(empval);
            e.Cancel = true;
        }

        protected void Penalty_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PenaltyLV.InsertItemPosition = InsertItemPosition.None;
            PenaltyLV.SelectedIndex = -1;
            PenaltyLV.EditIndex = e.NewEditIndex;
            bindPenaltyLV(empval);
            e.Cancel = true;

        }
        protected void Penalty_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (PenaltyLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList PenaltyType = e.Item.FindControl("PenaltyTypeDDL") as DropDownList;
                HiddenField PenaltyTypeId = (e.Item.FindControl("HidPenaltyTypeId") as HiddenField);
                PenaltyType.SelectedValue = PenaltyTypeId.Value.ToString();

            }
        }
        protected void Penalty_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList PenaltyType = new DropDownList();
            PenaltyType = (e.Item.FindControl("PenaltyTypeDDL") as DropDownList);
            if (PenaltyType != null)
            {
                PenaltyType.Items.Add(new ListItem("Select", "0"));

                List<PenaltyTypes> pt = new AdministrationBIZ().GetPenaltyTypes();

                foreach (PenaltyTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PenaltyTypeId.ToString();
                    cy.Text = row.PenaltyType.ToString();
                    PenaltyType.Items.Add(cy);
                }
            }
        }
    }
}