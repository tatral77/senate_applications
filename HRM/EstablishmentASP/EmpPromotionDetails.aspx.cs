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
    public partial class EmpPromotionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;

            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                bindEmpPromotion(empval);
                bindProbationLV(empval);
            }

        }
        protected void NewPromButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPromotion.SelectedIndex = -1;
            EmpPromotion.EditIndex = -1;
            EmpPromotion.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmpPromotion(empval);

        }
        protected void bindEmpPromotion(int empval)
        {
            List<PromotionHistory> PromHist = new EmployeeHandler().GetPromotionHistory(empval);
            EmpPromotion.DataSource = PromHist;
            EmpPromotion.DataBind();
           
        }
        protected void EmpPromotion_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpPromotionId = (HiddenField)EmpPromotion.Items[e.ItemIndex].FindControl("HidEmpPromotionId");
            int EmpPromId = Convert.ToInt32(EmpPromotionId.Value);
            new EmployeeHandler().DeletePromotionHistory(EmpPromId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpPromotion(empval);
            bindProbationLV(empval);
        }
        protected void EmpPromotion_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpPromotion.EditIndex = -1;
            EmpPromotion.InsertItemPosition = InsertItemPosition.None;
            EmpPromotion.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpPromotion(empval);
            bindProbationLV(empval);
            e.Cancel = true;
        }
        protected void EmpPromotion_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpPromotion.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || EmpPromotion.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList PromotionTypeDDL = e.Item.FindControl("PromotionTypeDDL") as DropDownList;
                HiddenField PromotionTypeId = (e.Item.FindControl("HidPromotionTypeId") as HiddenField);
                PromotionTypeDDL.SelectedValue = PromotionTypeId.Value.ToString();

                DropDownList PromotionModeDDL = e.Item.FindControl("PromotionModeDDL") as DropDownList;
                HiddenField PromotionModeId = (e.Item.FindControl("HidPromotionModeId") as HiddenField);
                PromotionModeDDL.SelectedValue = PromotionModeId.Value.ToString();

                DropDownList designation = e.Item.FindControl("DesignationDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidDesignationId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();


                DropDownList bps = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BpsId = (e.Item.FindControl("HidBPSId") as HiddenField);
                bps.SelectedValue = BpsId.Value.ToString();

                CheckBox IsExtendedCB = e.Item.FindControl("ExtendedCB") as CheckBox;
                if (IsExtendedCB != null)
                {
                    HiddenField IsExtended = (e.Item.FindControl("HidIsExtended") as HiddenField);
                    if(Convert.ToInt32(IsExtended.Value)==1)
                      IsExtendedCB.Checked = true;
                    else
                        IsExtendedCB.Checked = false;
                }
                CheckBox IsGazettedCB = e.Item.FindControl("IsGazettedCB") as CheckBox;
                if (IsGazettedCB != null)
                {
                    HiddenField IsGaz = (e.Item.FindControl("HidIsGazetted") as HiddenField);
                    if (Convert.ToInt32(IsGaz.Value) == 1)
                        IsGazettedCB.Checked = true;
                    else
                        IsGazettedCB.Checked = false;
                }
                CheckBox IsCurrentCB = e.Item.FindControl("IsCurrentCB") as CheckBox;
                if (IsCurrentCB != null)
                {
                    HiddenField IsCurrent = (e.Item.FindControl("HidIsCurrent") as HiddenField);
                    if (Convert.ToInt32(IsCurrent.Value) == 1)
                        IsCurrentCB.Checked = true;
                    else
                        IsCurrentCB.Checked = false;
                }
            }
        }
        protected void EmpPromotion_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField PromotionId = EmpPromotion.EditItem.FindControl("HidEmpPromotionId") as HiddenField;
            int pid = Convert.ToInt32(PromotionId.Value);
            Label err = (Label)EmpPromotion.EditItem.FindControl("ErrorLabel");
            CheckBox IsCurrent = (CheckBox)EmpPromotion.EditItem.FindControl("IsCurrentCB");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            double temp = new EmployeeHandler().GetCurrentStatus(empval);
            if (pid!=temp && temp!=0 && IsCurrent.Checked==true)
                err.Text = "Employee already has a current promotion";
            else
            {
                err.Text = "";
                DropDownList PromotionTypeDDL = (DropDownList)EmpPromotion.EditItem.FindControl("PromotionTypeDDL");
                DropDownList PromotionModeDDL = (DropDownList)EmpPromotion.EditItem.FindControl("PromotionModeDDL");
                HiddenField ProbationId = EmpPromotion.EditItem.FindControl("HidEmpProbationId") as HiddenField;
                DropDownList designation = (DropDownList)EmpPromotion.EditItem.FindControl("DesignationDDL");
                DropDownList bps = (DropDownList)EmpPromotion.EditItem.FindControl("BPSDDL");
                TextBox promotiondate = (TextBox)EmpPromotion.EditItem.FindControl("PromotionDateTxt");
                //TextBox ProbationFrom = (TextBox)EmpPromotion.EditItem.FindControl("ProbationFromTxt");
                //TextBox ProbationTo = (TextBox)EmpPromotion.EditItem.FindControl("ProbationToTxt");
                TextBox remarks = (TextBox)EmpPromotion.EditItem.FindControl("RemarksTxt");
                CheckBox IsGazetted = (CheckBox)EmpPromotion.EditItem.FindControl("IsGazettedCB");
                TextBox Reason = (TextBox)EmpPromotion.EditItem.FindControl("ReasonTxt");
                PromotionHistory eh = new PromotionHistory();
                eh.EmpId = empval;
                eh.EmpPromotionId = pid;
                eh.PromotionTypeId = Convert.ToInt32(PromotionTypeDDL.SelectedItem.Value);
                eh.PromotionModeId = Convert.ToInt32(PromotionModeDDL.SelectedItem.Value);
                eh.PostId = Convert.ToInt32(designation.SelectedItem.Value);
                eh.Bps = Convert.ToInt32(bps.SelectedItem.Value);
                eh.PromotionDate = Convert.ToDateTime(promotiondate.Text);
               // eh.ProbationFrom= Convert.ToDateTime(ProbationFrom.Text);
               // eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
                eh.Remarks = Convert.ToString(remarks.Text);
                eh.ProbationId = Convert.ToInt32(ProbationId.Value);
                eh.IsGazetted= (IsGazetted.Checked == true) ? 1 : 0;
                eh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
                new EmployeeHandler().UpdateEmployeePromotion(eh);
                EmpPromotion.EditIndex = -1;
                EmpPromotion.InsertItemPosition = InsertItemPosition.None;
                bindEmpPromotion(empval);
                bindProbationLV(empval);
                e.Cancel = true;
            }
        }
        protected void EmpPromotion_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpPromotion.InsertItemPosition = InsertItemPosition.None;
            EmpPromotion.SelectedIndex = -1;
            EmpPromotion.EditIndex = e.NewEditIndex;
            bindEmpPromotion(empval);
            bindProbationLV(empval);
            e.Cancel = true;
        }
        protected void EmpPromotion_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpPromotion.InsertItem)) { e.Cancel = true; return; }
            Label err = (Label)EmpPromotion.InsertItem.FindControl("ErrorLabel");
            CheckBox IsCurrent = (CheckBox)EmpPromotion.InsertItem.FindControl("IsCurrentCB");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (new EmployeeHandler().GetCurrentStatus(empval)!=0 && IsCurrent.Checked == true)
                err.Text = "Employee already has a current promotion";
            else
            {
                err.Text = "";
                DropDownList PromotionTypeDDL = (DropDownList)EmpPromotion.InsertItem.FindControl("PromotionTypeDDL");
                DropDownList PromotionModeDDL = (DropDownList)EmpPromotion.InsertItem.FindControl("PromotionModeDDL");
                DropDownList designation = (DropDownList)EmpPromotion.InsertItem.FindControl("DesignationDDL");
                DropDownList bps = (DropDownList)EmpPromotion.InsertItem.FindControl("BPSDDL");
                TextBox promotiondate = (TextBox)EmpPromotion.InsertItem.FindControl("PromotionDateTxt");
                TextBox remarks = (TextBox)EmpPromotion.InsertItem.FindControl("RemarksTxt");
                TextBox ProbationFrom = (TextBox)EmpPromotion.InsertItem.FindControl("ProbationFromTxt");
                TextBox ProbationTo = (TextBox)EmpPromotion.InsertItem.FindControl("ProbationToTxt");
                CheckBox IsGazetted = (CheckBox)EmpPromotion.InsertItem.FindControl("IsGazettedCB");
                PromotionHistory eh = new PromotionHistory();
                eh.EmpId = empval;
                eh.PromotionTypeId = Convert.ToInt32(PromotionTypeDDL.SelectedItem.Value);
                eh.PromotionModeId= Convert.ToInt32(PromotionModeDDL.SelectedItem.Value);
                eh.PostId = Convert.ToInt32(designation.SelectedItem.Value);
                eh.Bps = Convert.ToInt32(bps.SelectedItem.Value);
                eh.PromotionDate = Convert.ToDateTime(promotiondate.Text);
                eh.Remarks = Convert.ToString(remarks.Text);
                if (!String.IsNullOrEmpty(ProbationFrom.Text))
                    eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
                else
                    eh.ProbationTo = null;
                if (!String.IsNullOrEmpty(ProbationFrom.Text))
                    eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
                else
                    eh.ProbationTo = null;
                eh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
                eh.IsGazetted = (IsGazetted.Checked) ? 1 : 0;
                new EmployeeHandler().InsertEmployeePromotion(eh);
                EmpPromotion.EditIndex = -1;
                EmpPromotion.InsertItemPosition = InsertItemPosition.None;
                bindEmpPromotion(empval);
                bindProbationLV(empval);
                e.Cancel = true;
                Response.Redirect("EmpPromotionDetails.aspx?empid=" + empval);
            }
        }
        protected void EmpPromotion_ItemCreated(object sender, ListViewItemEventArgs e)
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
            DropDownList PromMode = new DropDownList();
            PromMode = (e.Item.FindControl("PromotionModeDDL") as DropDownList);
            if (PromMode != null)
            {
                List<TempEntity> pt = new AdministrationBIZ().GetPromotionModes();
                foreach (TempEntity row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.Id.ToString();
                    cy.Text = row.Description.ToString();
                    PromMode.Items.Add(cy);
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
            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {
                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> br = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }
            DropDownList PromotionTypeDDL = new DropDownList();
            PromotionTypeDDL = (e.Item.FindControl("PromotionTypeDDL") as DropDownList);
            if (PromotionTypeDDL != null)
            {
                PromotionTypeDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> br = new AdministrationBIZ().GetPromotionTypes();
                foreach (TempEntity row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    PromotionTypeDDL.Items.Add(li);
                }
            }


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
           return  (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        //===============================================================================================================================
        #region PROBATION
        protected void newProbation_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ProbationLV.SelectedIndex = -1;
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindProbationLV(empval);
        }
        protected void bindProbationLV(int EmpId)
        {
            List<Probation> re = new List<Probation>();
            re = new EmploymentBIZ().GetPromotionProbations(EmpId);
            ProbationLV.DataSource = re;
            ProbationLV.DataBind();
        }
        protected void Probation_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField ProbationId = (HiddenField)ProbationLV.Items[e.ItemIndex].FindControl("HidProbationId");
            int EmpHistoryId = Convert.ToInt32(ProbationId.Value);
            new EmploymentBIZ().DeleteProbation(EmpHistoryId,empval);
         
            bindProbationLV(empval);
        }
        protected void Probation_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(ProbationLV.EditItem)) { e.Cancel = true; return; }
            DropDownList ProbationTypeDDL = (DropDownList)ProbationLV.EditItem.FindControl("ProbationTypeDDL");
            HiddenField ProbationId = ProbationLV.EditItem.FindControl("HidProbationId") as HiddenField;
            HiddenField PromotionId = ProbationLV.EditItem.FindControl("HidPromotionId") as HiddenField;
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            int promid = Convert.ToInt32(PromotionId.Value);
            TextBox ProbationFrom = (TextBox)ProbationLV.EditItem.FindControl("ProbationFromTxt");
            TextBox ProbationTo = (TextBox)ProbationLV.EditItem.FindControl("ProbationToTxt");
            TextBox Remarks = (TextBox)ProbationLV.EditItem.FindControl("RemarksTxt");
            Probation eh = new Probation();
            eh.PromotionId = promid;
            eh.SystemUserId = empval;
            eh.ProbationId = Convert.ToInt32(ProbationId.Value);
            eh.ProbationTypeId = Convert.ToInt32(ProbationTypeDDL.SelectedItem.Value);
            eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
            eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdatePromProbation(eh);
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            bindProbationLV(empval);
            e.Cancel = true;
        }

        protected void Probation_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(ProbationLV.InsertItem)) { e.Cancel = true; return; }
            DropDownList ProbationTypeDDL = (DropDownList)ProbationLV.InsertItem.FindControl("ProbationTypeDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox PromotionId = (TextBox)ProbationLV.InsertItem.FindControl("ReferenceIdTxt");
            TextBox ProbationFrom = (TextBox)ProbationLV.InsertItem.FindControl("ProbationFromTxt");
            TextBox ProbationTo = (TextBox)ProbationLV.InsertItem.FindControl("ProbationToTxt");
            TextBox Remarks = (TextBox)ProbationLV.InsertItem.FindControl("RemarksTxt");
            Probation eh = new Probation();
            eh.PromotionId = Convert.ToInt32(PromotionId.Text);
            eh.SystemUserId = empval;
            eh.ProbationTypeId = Convert.ToInt32(ProbationTypeDDL.SelectedItem.Value);
            eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
            eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertPromProbation(eh);
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            bindProbationLV(empval);
            e.Cancel = true;
            Response.Redirect("EmpPromotionDetails.aspx?empid=" + empval);

        }
        protected void Probation_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            ProbationLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindProbationLV(empval);
            e.Cancel = true;
        }

        protected void Probation_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            ProbationLV.SelectedIndex = -1;
            ProbationLV.EditIndex = e.NewEditIndex;
            bindProbationLV(empval);
            e.Cancel = true;

        }
        protected void Probation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ProbationLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList ProbationType = e.Item.FindControl("ProbationTypeDDL") as DropDownList;
                HiddenField ProbationTypeId = (e.Item.FindControl("HidProbationTypeId") as HiddenField);
                ProbationType.SelectedValue = ProbationTypeId.Value.ToString();

            }
        }
        protected void Probation_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList ProbationType = new DropDownList();
            ProbationType = (e.Item.FindControl("ProbationTypeDDL") as DropDownList);
            if (ProbationType != null)
            {
                ProbationType.Items.Add(new ListItem("Select", "0"));

                List<ProbationTypes> pt = new AdministrationBIZ().GetProbationTypes();
                foreach (ProbationTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.ProbationTypeId.ToString();
                    cy.Text = row.ProbationType.ToString();
                    ProbationType.Items.Add(cy);
                }
            }
        }

        #endregion PROBATION
    }
}