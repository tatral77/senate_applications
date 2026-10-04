using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Budget
{
    public partial class ManageFinancialYears : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVistLV();
            }
        }
        protected void BindVistLV()
        {
            List<FinancialYears> Eq = new BudgetBiz().GetFinancialYears();
            FinancialYearsLV.DataSource = Eq;
            FinancialYearsLV.DataBind();


        }
      
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            FinancialYearsLV.SelectedIndex = -1;
            FinancialYearsLV.EditIndex = -1;
            FinancialYearsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindVistLV();

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            FinancialYearsLV.EditIndex = -1;
            FinancialYearsLV.InsertItemPosition = InsertItemPosition.None;
            FinancialYearsLV.SelectedIndex = -1;
            BindVistLV();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            //DropDownList countries = new DropDownList();
            //countries = (e.Item.FindControl("CountryDDL") as DropDownList);
            //if (countries != null)
            //{
            //    //designation.Items.Add(new ListItem("Select", "0"));

            //    List<Country> pt = new DataManagementBIZ().GetAllCountries();

            //    foreach (Country row in pt)
            //    {
            //        ListItem cy = new ListItem();
            //        cy.Value = row.CountryId.ToString();
            //        cy.Text = row.CountryName.ToString();
            //        countries.Items.Add(cy);
            //    }
            //}
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            FinancialYears eh = new FinancialYears();
            TextBox FinancialYearTxt = FinancialYearsLV.InsertItem.FindControl("FinancialYearTxt") as TextBox;
            TextBox FromDate = FinancialYearsLV.InsertItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = FinancialYearsLV.InsertItem.FindControl("ToDateTxt") as TextBox;
            TextBox DemandNumberTxt = FinancialYearsLV.InsertItem.FindControl("DemandNumberTxt") as TextBox;
            eh.FinancialYear = Convert.ToString(FinancialYearTxt.Text);
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.DemandNumber= Convert.ToString(DemandNumberTxt.Text);
            new BudgetBiz().InsertFinancialYear(eh);
            FinancialYearsLV.EditIndex = -1;
            FinancialYearsLV.InsertItemPosition = InsertItemPosition.None;
            FinancialYearsLV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            Response.Redirect("~/ManageFinancialYears.aspx");
        }

        protected string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            FinancialYearsLV.InsertItemPosition = InsertItemPosition.None;
            FinancialYearsLV.SelectedIndex = -1;
            FinancialYearsLV.EditIndex = e.NewEditIndex;
            e.Cancel = true;
            BindVistLV();

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
           
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            FinancialYears eh = new FinancialYears();
            HiddenField HidFinancialYearId = FinancialYearsLV.EditItem.FindControl("HidFinancialYearId") as HiddenField;
            TextBox FinancialYearTxt = FinancialYearsLV.EditItem.FindControl("FinancialYearTxt") as TextBox;
            TextBox FromDate = FinancialYearsLV.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = FinancialYearsLV.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox DemandNumberTxt = FinancialYearsLV.EditItem.FindControl("DemandNumberTxt") as TextBox;
            eh.FinancialYearId = Convert.ToInt32(HidFinancialYearId.Value);
            eh.FinancialYear = Convert.ToString(FinancialYearTxt.Text);
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.DemandNumber = Convert.ToString(DemandNumberTxt.Text);
            new BudgetBiz().UpdateFinancialYear(eh);
            FinancialYearsLV.EditIndex = -1;
            FinancialYearsLV.InsertItemPosition = InsertItemPosition.None;
            FinancialYearsLV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
        }

        protected void VisitsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindVistLV();
           
        }
        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField HidEmpPostingId = (HiddenField)FinancialYearsLV.Items[e.ItemIndex].FindControl("HidEmpPostingId");
        //    int EmpPostingId = Convert.ToInt32(HidEmpPostingId.Value);
        //    new IPRBiz().DeleteOutgoingVisit(EmpPostingId);
        //    int empval;
        //    empval = Convert.ToInt32(Request.QueryString["EmpId"]);
        //    BindVistLV();
        //}
   // }
}
}