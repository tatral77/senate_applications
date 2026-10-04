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
    public partial class EmployeeMedical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                BindMedicalLv();
            }

        }
        public string GetStatus(int StatusId)
        {
            if (StatusId == 1)
                return "Yes";
            else
                return "No";
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            MedicalLv.EditIndex = -1;
            MedicalLv.InsertItemPosition = InsertItemPosition.None;
            MedicalLv.SelectedIndex = -1;

            e.Cancel = true;

            BindMedicalLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            MedicalLv.SelectedIndex = -1;
            MedicalLv.EditIndex = -1;
            MedicalLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindMedicalLv();

        }
        protected void BindMedicalLv()
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            List<EmpMedical> MedicalesList = new EmployeeHandler().GetEmpMedical(empval);
            MedicalLv.DataSource = MedicalesList;
            MedicalLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            MedicalLv.InsertItemPosition = InsertItemPosition.None;
            MedicalLv.SelectedIndex = -1;
            MedicalLv.EditIndex = e.NewEditIndex;
            BindMedicalLv();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (MedicalLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PostDDL = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField PostId = (e.Item.FindControl("HidPostId") as HiddenField);
                PostDDL.SelectedValue = PostId.Value.ToString();

                DropDownList MedicalTypeDDL = e.Item.FindControl("MedicalTypeDDL") as DropDownList;
                HiddenField MedicalTypeId = (e.Item.FindControl("HidMedicalTypeId") as HiddenField);
                MedicalTypeDDL.SelectedValue = MedicalTypeId.Value.ToString();

                DropDownList BPSDDL = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSID = (e.Item.FindControl("HidBPSID") as HiddenField);
                BPSDDL.SelectedValue = BPSID.Value.ToString();



                CheckBox SubmittedCB = e.Item.FindControl("SubmittedCB") as CheckBox;
                if (SubmittedCB != null)
                {
                    HiddenField IsSubmitted = (e.Item.FindControl("HidSubmitted") as HiddenField);
                    if (Convert.ToInt32(IsSubmitted.Value) == 1)
                        SubmittedCB.Checked = true;
                    else
                        SubmittedCB.Checked = false;
                }
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField MedicalId = (HiddenField)MedicalLv.Items[e.ItemIndex].FindControl("HidMedicalId");
            int Medicalid = Convert.ToInt32(MedicalId.Value);
            new EmployeeHandler().DeleteEmpMedical(Medicalid);
            BindMedicalLv();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList PostId = MedicalLv.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = MedicalLv.InsertItem.FindControl("BPSDDL") as DropDownList;
            DropDownList MedicalTypeId = MedicalLv.InsertItem.FindControl("MedicalTypeDDL") as DropDownList;
            TextBox CheckupDate = MedicalLv.InsertItem.FindControl("CheckupDateTxt") as TextBox;
            TextBox YearTxt = MedicalLv.InsertItem.FindControl("MedYearTxt") as TextBox;
            CheckBox Submitted = (CheckBox)MedicalLv.InsertItem.FindControl("SubmittedCB");
            TextBox Remarks = MedicalLv.InsertItem.FindControl("RemarksTxt") as TextBox;
            EmpMedical eh = new EmpMedical();
            eh.SystemUserId = empval; ;
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.MedicalTypeId = Convert.ToInt32(MedicalTypeId.SelectedItem.Value);
            eh.OnDate = Convert.ToDateTime(CheckupDate.Text);
            eh.MedYear= Convert.ToInt32(YearTxt.Text);
            eh.IsSubmitted = (Submitted.Checked == true) ? 1 : 0;
            eh.Remarks = Remarks.Text;
            new EmployeeHandler().InsertEmpMedical(eh);
            MedicalLv.EditIndex = -1;
            MedicalLv.InsertItemPosition = InsertItemPosition.None;
            MedicalLv.SelectedIndex = -1;
            e.Cancel = true;
            BindMedicalLv();
            //Response.Redirect("EmployeeMedical.aspx?EmpId" + empval);


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField MedicalId = (HiddenField)MedicalLv.EditItem.FindControl("HidMedicalId");
            DropDownList PostId = MedicalLv.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = MedicalLv.EditItem.FindControl("BPSDDL") as DropDownList;
            DropDownList MedicalTypeId = MedicalLv.EditItem.FindControl("MedicalTypeDDL") as DropDownList;
            TextBox CheckupDate = MedicalLv.EditItem.FindControl("CheckupDateTxt") as TextBox;
            TextBox YearTxt = MedicalLv.EditItem.FindControl("MedYearTxt") as TextBox;
            CheckBox Submitted = (CheckBox)MedicalLv.EditItem.FindControl("SubmittedCB");
            TextBox Remarks = MedicalLv.EditItem.FindControl("RemarksTxt") as TextBox;
            EmpMedical eh = new EmpMedical();
            eh.EmpMedicalId = Convert.ToInt32(MedicalId.Value);
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.MedicalTypeId = Convert.ToInt32(MedicalTypeId.SelectedItem.Value);
            eh.OnDate = Convert.ToDateTime(CheckupDate.Text);
            eh.MedYear = Convert.ToInt32(YearTxt.Text);
            eh.IsSubmitted = (Submitted.Checked == true) ? 1 : 0;
            eh.Remarks = Remarks.Text;
            new EmployeeHandler().UpdateEmpMedical(eh);
            MedicalLv.EditIndex = -1;
            BindMedicalLv();
            MedicalLv.InsertItemPosition = InsertItemPosition.None;
            MedicalLv.SelectedIndex = -1;
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
    }
}