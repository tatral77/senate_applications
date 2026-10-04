using System;
using EstablishmentBIZ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class Visits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               BindLV();
            }
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpVisitsLv.SelectedIndex = -1;
            EmpVisitsLv.EditIndex = -1;
            EmpVisitsLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLV();
        }
        public void BindLV()
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            List<EmployeeVisits> EmpVisits = new List<EmployeeVisits>();
            EmpVisits = new EmployeeHandler().GetEmployeeVisits(empval);
            EmpVisitsLv.DataSource = EmpVisits;
            EmpVisitsLv.DataBind();
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            List<Country> cy = new AdministrationBIZ().GetCountries();
            // ListViewItem lvi = PassportsLv.EditItem;
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (ddl != null)
            {
                ddl.Items.Add(new ListItem("Select", "0"));
                foreach (Country row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.CountryId.ToString();
                    ty.Text = row.Description.ToString();
                    ddl.Items.Add(ty);
                }
            }
            List<VistTypes> vt = new AdministrationBIZ().GetVisitTypes();
            DropDownList ddl2 = new DropDownList();
            ddl2 = (e.Item.FindControl("VisitTypeDDL") as DropDownList);
            if (ddl2 != null)
            {
                ddl2.Items.Add(new ListItem("Select", "0"));
                foreach (VistTypes row in vt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.VisitTypeId.ToString();
                    ty.Text = row.VistType.ToString();
                    ddl2.Items.Add(ty);
                }
            }
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpVisitsLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList VisitType = e.Item.FindControl("VisitTypeDDL") as DropDownList;
                HiddenField HidVisitTypeId = (e.Item.FindControl("HidVisitTypeId") as HiddenField);
                VisitType.SelectedValue = HidVisitTypeId.Value.ToString();

                DropDownList CountryDDL = e.Item.FindControl("CountryDDL") as DropDownList;
                HiddenField HidCountryId = (e.Item.FindControl("HidCountryId") as HiddenField);
                CountryDDL.SelectedValue = HidCountryId.Value.ToString();
            }
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            EmpVisitsLv.InsertItemPosition = InsertItemPosition.None;
            EmpVisitsLv.SelectedIndex = -1;
            EmpVisitsLv.EditIndex = e.NewEditIndex;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpVisitsLv.EditIndex = -1;
            EmpVisitsLv.InsertItemPosition = InsertItemPosition.None;
            EmpVisitsLv.SelectedIndex = -1;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpVisitsLv.InsertItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList VisitTypeId = (DropDownList)EmpVisitsLv.InsertItem.FindControl("VisitTypeDDL");
            DropDownList CountryId = (DropDownList)EmpVisitsLv.InsertItem.FindControl("CountryDDL");
            TextBox FromDate = (TextBox)EmpVisitsLv.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)EmpVisitsLv.InsertItem.FindControl("ToDateTxt");
            TextBox NOCDate = (TextBox)EmpVisitsLv.InsertItem.FindControl("NOCDateTxt");
            TextBox Purpose = (TextBox)EmpVisitsLv.InsertItem.FindControl("PurposeTxt");
            EmployeeVisits ep = new EmployeeVisits();
            ep.System_User_Id = empval;
            ep.VisitTypeId = Convert.ToInt32(VisitTypeId.SelectedItem.Value);
            ep.CountryId = Convert.ToInt32(CountryId.Text);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            ep.NocDate= Convert.ToDateTime(NOCDate.Text);
            ep.Purpose = Convert.ToString(Purpose.Text);
            new EmployeeHandler().InsertEmployeeVisits(ep);
            EmpVisitsLv.EditIndex = -1;
            EmpVisitsLv.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpVisitsLv.EditItem)) { e.Cancel = true; return; }
            HiddenField VisitId = EmpVisitsLv.EditItem.FindControl("HidVisitId") as HiddenField;
            DropDownList VisitTypeId = (DropDownList)EmpVisitsLv.EditItem.FindControl("VisitTypeDDL");
            DropDownList CountryId = (DropDownList)EmpVisitsLv.EditItem.FindControl("CountryDDL");
            TextBox FromDate = (TextBox)EmpVisitsLv.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)EmpVisitsLv.EditItem.FindControl("ToDateTxt");
            TextBox NOCDate = (TextBox)EmpVisitsLv.EditItem.FindControl("NOCDateTxt");
            TextBox Purpose = (TextBox)EmpVisitsLv.EditItem.FindControl("PurposeTxt");
            EmployeeVisits ep = new EmployeeVisits();
            ep.ForeignVisitId = Convert.ToInt32(VisitId.Value);
            ep.VisitTypeId = Convert.ToInt32(VisitTypeId.SelectedItem.Value);
            ep.CountryId = Convert.ToInt32(CountryId.Text);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            ep.NocDate = Convert.ToDateTime(NOCDate.Text);
            ep.Purpose = Convert.ToString(Purpose.Text);
            new EmployeeHandler().UpdateEmployeeVisits(ep);
            EmpVisitsLv.EditIndex = -1;
            EmpVisitsLv.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField VisitId = (HiddenField)EmpVisitsLv.Items[e.ItemIndex].FindControl("HidVisitId");
            new EmployeeHandler().DeleteEmployeeVisit(Convert.ToInt32(VisitId.Value));
            BindLV();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}