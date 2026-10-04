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
    public partial class EmployeeAcr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                BindEmpAcrLv(empval);
            }

        }
        protected void BindEmpAcrLv(int EmpId)
        {
            List<AnnualConfRep> Eq = new EmployeeHandler().GetACRS(EmpId);
            EmpAcrLv.DataSource = Eq;
            EmpAcrLv.DataBind();


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpAcrLv.SelectedIndex = -1;
            EmpAcrLv.EditIndex = -1;
            EmpAcrLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindEmpAcrLv(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpAcrLv.EditIndex = -1;
            EmpAcrLv.InsertItemPosition = InsertItemPosition.None;
            EmpAcrLv.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindEmpAcrLv(empval);
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
            DropDownList CSOfficerDDL = new DropDownList();
            CSOfficerDDL = (e.Item.FindControl("CSOfficerDDL") as DropDownList);
          
            List<ReportingOfficers> co = new EmployeeHandler().GetReportingOfficers();
            if (CSOfficerDDL != null)
            {
                CSOfficerDDL.Items.Add(new ListItem("Select", "0"));
                foreach (ReportingOfficers row in co)
                {
                    ListItem li = new ListItem();
                    li.Text = row.OfficerName + "(" + row.OfficerPost + ")";
                    li.Value = row.OfficerId.ToString();
                    CSOfficerDDL.Items.Add(li);
                   
                }
            }

            DropDownList RepOfficerDDL = new DropDownList();
            RepOfficerDDL = (e.Item.FindControl("RepOfficerDDL") as DropDownList);
            List<ReportingOfficers> ab = new EmployeeHandler().GetReportingOfficers();
            if (RepOfficerDDL != null)
            {
                RepOfficerDDL.Items.Add(new ListItem("Select", "0"));
                foreach (ReportingOfficers row in ab)
                {
                    ListItem li = new ListItem();
                    li.Text = row.OfficerName + "(" + row.OfficerPost + ")";
                    li.Value = row.OfficerId.ToString();
                    RepOfficerDDL.Items.Add(li);
                }
            }
            DropDownList AcrGradeDDL = new DropDownList();
            AcrGradeDDL = (e.Item.FindControl("GradeDDL") as DropDownList);
            if (AcrGradeDDL != null)
            {
                List<TempEntity> AcrGrades = new AdministrationBIZ().GetAcrGrades();
                foreach (TempEntity row in AcrGrades)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    AcrGradeDDL.Items.Add(li);
                }
            }
            DropDownList AcrStatusDDL = new DropDownList();
            AcrStatusDDL = (e.Item.FindControl("StatusDDL") as DropDownList);
            if (AcrStatusDDL != null)
            {
                List<TempEntity> AcrStatuses = new AdministrationBIZ().GetAcrStatuses();
                foreach (TempEntity row in AcrStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    AcrStatusDDL.Items.Add(li);
                }
            }

        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
          
                int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                AnnualConfRep eh = new AnnualConfRep();
                eh.SystemUserId = empval;
                DropDownList PostDDL = EmpAcrLv.InsertItem.FindControl("PostDDL") as DropDownList;
                DropDownList BPSDDL = EmpAcrLv.InsertItem.FindControl("BPSDDL") as DropDownList;
                DropDownList CSOfficerDDL = EmpAcrLv.InsertItem.FindControl("CsOfficerDDL") as DropDownList;
                DropDownList REPOfficerDDL = EmpAcrLv.InsertItem.FindControl("RepOfficerDDL") as DropDownList;
                DropDownList AcrStatusDDL = EmpAcrLv.InsertItem.FindControl("StatusDDL") as DropDownList;
                DropDownList AcrGradeDDL = EmpAcrLv.InsertItem.FindControl("GradeDDL") as DropDownList;
                TextBox CSInDate = EmpAcrLv.InsertItem.FindControl("CSInDateTxt") as TextBox;
                TextBox CSOutDate = EmpAcrLv.InsertItem.FindControl("CSOutDateTxt") as TextBox;
                TextBox ROInDate = EmpAcrLv.InsertItem.FindControl("ROInDateTxt") as TextBox;
                TextBox ROOutDate = EmpAcrLv.InsertItem.FindControl("ROOutDateTxt") as TextBox;
                TextBox RepYear= EmpAcrLv.InsertItem.FindControl("RepYearTxt") as TextBox;
                TextBox Remarks = EmpAcrLv.InsertItem.FindControl("RemarksTxt") as TextBox;
                eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
                eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                eh.RepYear= Convert.ToInt32(RepYear.Text);
                eh.ReportingOfficerId = Convert.ToInt32(REPOfficerDDL.SelectedItem.Value);
                eh.ReportingOfficer = Convert.ToString(REPOfficerDDL.SelectedItem.Text);
                if (!String.IsNullOrEmpty(CSInDate.Text))
                    eh.CSInDate = Convert.ToDateTime(CSInDate.Text);
                if (!String.IsNullOrEmpty(CSOutDate.Text))
                    eh.CSOutDate = Convert.ToDateTime(CSOutDate.Text);
                eh.CounterSignOffId = Convert.ToInt32(CSOfficerDDL.SelectedItem.Value);
                eh.CounterSignOff = Convert.ToString(REPOfficerDDL.SelectedItem.Text);
                if (!String.IsNullOrEmpty(ROInDate.Text))
                    eh.ROInDate = Convert.ToDateTime(ROInDate.Text);
                if (!String.IsNullOrEmpty(ROOutDate.Text))
                    eh.ROOutDate = Convert.ToDateTime(ROOutDate.Text);
                eh.GradeId = Convert.ToInt32(AcrGradeDDL.SelectedItem.Value);
                eh.StatusId = Convert.ToInt32(AcrStatusDDL.SelectedItem.Value);
                eh.Remarks = Convert.ToString(Remarks.Text);
                new EmployeeHandler().InsertEmployeeAcrs(eh);
                EmpAcrLv.EditIndex = -1;
                EmpAcrLv.InsertItemPosition = InsertItemPosition.None;
                EmpAcrLv.SelectedIndex = -1;
                BindEmpAcrLv(empval);
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
            EmpAcrLv.InsertItemPosition = InsertItemPosition.None;
            EmpAcrLv.SelectedIndex = -1;
            EmpAcrLv.EditIndex = e.NewEditIndex;
            BindEmpAcrLv(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpAcrLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();

                DropDownList CSOfficerDDL = e.Item.FindControl("CSOfficerDDL") as DropDownList;
                HiddenField CsOfficerId = (e.Item.FindControl("HidCSOfficerId") as HiddenField);
                CSOfficerDDL.SelectedValue = CsOfficerId.Value.ToString();

                DropDownList RepOfficerDDL = e.Item.FindControl("RepOfficerDDL") as DropDownList;
                HiddenField RepOfficerId = (e.Item.FindControl("HidRepOfficerId") as HiddenField);
                RepOfficerDDL.SelectedValue = RepOfficerId.Value.ToString();

                DropDownList GradeDDL = e.Item.FindControl("GradeDDL") as DropDownList;
                HiddenField GradeId = (e.Item.FindControl("HidGradeId") as HiddenField);
                GradeDDL.SelectedValue = GradeId.Value.ToString();

                DropDownList StatusDDL = e.Item.FindControl("StatusDDL") as DropDownList;
                HiddenField StatusId = (e.Item.FindControl("HidStatusId") as HiddenField);
                StatusDDL.SelectedValue = StatusId.Value.ToString();

            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            AnnualConfRep eh = new AnnualConfRep();
            eh.SystemUserId = empval;
            HiddenField EmpAcrId = EmpAcrLv.EditItem.FindControl("HidEmpAcrId") as HiddenField;
            DropDownList PostDDL = EmpAcrLv.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = EmpAcrLv.EditItem.FindControl("BPSDDL") as DropDownList;
            DropDownList CSOfficerDDL = EmpAcrLv.EditItem.FindControl("CsOfficerDDL") as DropDownList;
            DropDownList REPOfficerDDL = EmpAcrLv.EditItem.FindControl("RepOfficerDDL") as DropDownList;
            DropDownList AcrStatusDDL = EmpAcrLv.EditItem.FindControl("StatusDDL") as DropDownList;
            DropDownList AcrGradeDDL = EmpAcrLv.EditItem.FindControl("GradeDDL") as DropDownList;
            TextBox CSInDate = EmpAcrLv.EditItem.FindControl("CSInDateTxt") as TextBox;
            TextBox CSOutDate = EmpAcrLv.EditItem.FindControl("CSOutDateTxt") as TextBox;
            TextBox ROInDate = EmpAcrLv.EditItem.FindControl("ROInDateTxt") as TextBox;
            TextBox ROOutDate = EmpAcrLv.EditItem.FindControl("ROOutDateTxt") as TextBox;
            TextBox RepYear = EmpAcrLv.EditItem.FindControl("RepYearTxt") as TextBox;
            TextBox Remarks = EmpAcrLv.EditItem.FindControl("RemarksTxt") as TextBox;
            eh.AnConfRepId = Convert.ToInt32(EmpAcrId.Value);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.RepYear = Convert.ToInt32(RepYear.Text);
            eh.ReportingOfficerId = Convert.ToInt32(REPOfficerDDL.SelectedItem.Value);
            eh.ReportingOfficer = Convert.ToString(REPOfficerDDL.SelectedItem.Text);
            if (!String.IsNullOrEmpty(ROInDate.Text))
                eh.ROInDate = Convert.ToDateTime(ROInDate.Text);
            if (!String.IsNullOrEmpty(ROOutDate.Text))
                eh.ROOutDate = Convert.ToDateTime(ROOutDate.Text);
            eh.CounterSignOffId = Convert.ToInt32(CSOfficerDDL.SelectedItem.Value);
            eh.CounterSignOff = Convert.ToString(CSOfficerDDL.SelectedItem.Text);
            if (!String.IsNullOrEmpty(CSInDate.Text))
                eh.CSInDate = Convert.ToDateTime(CSInDate.Text);
            if (!String.IsNullOrEmpty(CSOutDate.Text))
                eh.CSOutDate = Convert.ToDateTime(CSOutDate.Text);
            eh.GradeId = Convert.ToInt32(AcrGradeDDL.SelectedItem.Value);
            eh.StatusId = Convert.ToInt32(AcrStatusDDL.SelectedItem.Value);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmployeeHandler().UpdateEmployeeAcrs(eh);
            EmpAcrLv.EditIndex = -1;
            EmpAcrLv.InsertItemPosition = InsertItemPosition.None;
            EmpAcrLv.SelectedIndex = -1;
            BindEmpAcrLv(empval);
            e.Cancel = true;

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            
            HiddenField HidEmpAcrId = (HiddenField)EmpAcrLv.Items[e.ItemIndex].FindControl("HidEmpAcrId") as HiddenField;
            int EmpAcrId = Convert.ToInt32(HidEmpAcrId.Value);
            new EmployeeHandler().DeleteEmployeeACR(EmpAcrId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            BindEmpAcrLv(empval);
        }
    }
}