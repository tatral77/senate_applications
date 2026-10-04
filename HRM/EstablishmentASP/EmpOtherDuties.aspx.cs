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
    public partial class EmpOtherDuties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOtherDutyLV();
            }

        }
    
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            OtherDutyLV.EditIndex = -1;
            OtherDutyLV.InsertItemPosition = InsertItemPosition.None;
            OtherDutyLV.SelectedIndex = -1;

            e.Cancel = true;

            BindOtherDutyLV();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            OtherDutyLV.SelectedIndex = -1;
            OtherDutyLV.EditIndex = -1;
            OtherDutyLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindOtherDutyLV();

        }
        protected void BindOtherDutyLV()
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            List<EmpOtherDuty> OtherDutyesList = new EmployeeHandler().GetEmpOtherDuties(empval);
            OtherDutyLV.DataSource = OtherDutyesList;
            OtherDutyLV.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            OtherDutyLV.InsertItemPosition = InsertItemPosition.None;
            OtherDutyLV.SelectedIndex = -1;
            OtherDutyLV.EditIndex = e.NewEditIndex;
            BindOtherDutyLV();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (OtherDutyLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PostDDL = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField PostId = (e.Item.FindControl("HidPostId") as HiddenField);
                PostDDL.SelectedValue = PostId.Value.ToString();

                DropDownList OtherDutyTypeDDL = e.Item.FindControl("DutyTypeDDL") as DropDownList;
                HiddenField OtherDutyTypeId = (e.Item.FindControl("HidDutyTypeId") as HiddenField);
                OtherDutyTypeDDL.SelectedValue = OtherDutyTypeId.Value.ToString();

                DropDownList BPSDDL = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSID = (e.Item.FindControl("HidBPSID") as HiddenField);
                BPSDDL.SelectedValue = BPSID.Value.ToString();

                            
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField OtherDutyId = (HiddenField)OtherDutyLV.Items[e.ItemIndex].FindControl("HidEmpOtherDutyId");
            int OtherDutyid = Convert.ToInt32(OtherDutyId.Value);
            new EmployeeHandler().DeleteEmpOtherDuty(OtherDutyid);
            BindOtherDutyLV();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(OtherDutyLV.InsertItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList PostId = OtherDutyLV.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = OtherDutyLV.InsertItem.FindControl("BPSDDL") as DropDownList;
            DropDownList OtherDutyTypeId = OtherDutyLV.InsertItem.FindControl("DutyTypeDDL") as DropDownList;
            TextBox YearTxt = OtherDutyLV.InsertItem.FindControl("DutyYearTxt") as TextBox;
            TextBox FromDate = OtherDutyLV.InsertItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = OtherDutyLV.InsertItem.FindControl("ToDateTxt") as TextBox;
            TextBox DetailsTxt = OtherDutyLV.InsertItem.FindControl("DetailsTxt") as TextBox;
            EmpOtherDuty eh = new EmpOtherDuty();
            eh.SystemUserId = empval; ;
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.DutyTypeId = Convert.ToInt32(OtherDutyTypeId.SelectedItem.Value);
            if (!String.IsNullOrEmpty(YearTxt.Text))
                eh.DutyYear = Convert.ToInt32(YearTxt.Text);
            if(!String.IsNullOrEmpty(FromDate.Text))
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            if (!String.IsNullOrEmpty(ToDate.Text))
                eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.Details = Convert.ToString(DetailsTxt.Text);
            new EmployeeHandler().InsertEmpOtherDuty(eh);
            OtherDutyLV.EditIndex = -1;
            OtherDutyLV.InsertItemPosition = InsertItemPosition.None;
            OtherDutyLV.SelectedIndex = -1;
            e.Cancel = true;
            BindOtherDutyLV();
            //Response.Redirect("EmployeeOtherDuty.aspx?EmpId" + empval);


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(OtherDutyLV.EditItem)) { e.Cancel = true; return; }
            HiddenField OtherDutyId = (HiddenField)OtherDutyLV.EditItem.FindControl("HidEmpOtherDutyId");
            DropDownList PostId = OtherDutyLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = OtherDutyLV.EditItem.FindControl("BPSDDL") as DropDownList;
            DropDownList OtherDutyTypeId = OtherDutyLV.EditItem.FindControl("DutyTypeDDL") as DropDownList;
            TextBox YearTxt = OtherDutyLV.EditItem.FindControl("DutyYearTxt") as TextBox;
            TextBox FromDate = OtherDutyLV.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = OtherDutyLV.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox DetailsTxt = OtherDutyLV.EditItem.FindControl("DetailsTxt") as TextBox;
            EmpOtherDuty eh = new EmpOtherDuty();
            eh.EmpOtherDutyId= Convert.ToInt32(OtherDutyId.Value);
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.DutyTypeId = Convert.ToInt32(OtherDutyTypeId.SelectedItem.Value);
            eh.DutyYear = Convert.ToInt32(YearTxt.Text);
            if (!String.IsNullOrEmpty(FromDate.Text))
                eh.FromDate = Convert.ToDateTime(FromDate.Text);
            if (!String.IsNullOrEmpty(ToDate.Text))
                eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.Details = Convert.ToString(DetailsTxt.Text);
            new EmployeeHandler().UpdateEmpOtherDuty(eh);
            OtherDutyLV.EditIndex = -1;
            BindOtherDutyLV();
            OtherDutyLV.InsertItemPosition = InsertItemPosition.None;
            OtherDutyLV.SelectedIndex = -1;
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
            DropDownList OtherDutyTypeDDL = new DropDownList();
            OtherDutyTypeDDL = (e.Item.FindControl("DutyTypeDDL") as DropDownList);

            List<TempEntity> co = new AdministrationBIZ().GetDutyTypes();
            if (OtherDutyTypeDDL != null)
            {
                OtherDutyTypeDDL.Items.Add(new ListItem("Select", "0"));
                foreach (TempEntity row in co)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    OtherDutyTypeDDL.Items.Add(li);

                }
            }

        }
    }
}