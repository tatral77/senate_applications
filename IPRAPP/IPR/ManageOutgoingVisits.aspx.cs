using BUDENTITIES;
using BUDBIZ;
using IPRBIZ;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class ManageVisits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                BindVistLV();
            }
            //else
            //{
            //    int parliamentaryyearid = Convert.ToInt32(Request.QueryString["Py"]);
            //    int visit= Convert.ToInt32(Request.QueryString["visit"]);
            //    FinancialYearDDL.SelectedValue = parliamentaryyearid.ToString();
            //    VisitsDDL.SelectedValue = visit.ToString();
            //    BindLVByVisit(parliamentaryyearid, visit);
               
            //}

        }
        protected void BindDDL()
        {
            FinancialYearDDL.Items.Add(new ListItem("Select Financial Year", "0"));
            List<FinancialYears> financialYears = new BudgetBiz().GetFinancialYears();
            if (financialYears != null)
            {
                foreach (FinancialYears row in financialYears)
                {
                    ListItem li = new ListItem();
                    li.Value = row.FinancialYearId.ToString();
                    li.Text = row.FinancialYear.ToString();
                    FinancialYearDDL.Items.Add(li);
                }
                FinancialYears currentFinancialYear = new BudgetBiz().GetCurrentFinancialYear();
                FinancialYearDDL.SelectedValue = currentFinancialYear.FinancialYearId.ToString();
            }

        }

        protected void BindVistLV()
        {
            int parliamentaryyearid = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            //BindLVByVisit();
            List<OutgoingVisit> Eq = new IPRBiz().GetUpcomingVisits(parliamentaryyearid);
            VisitsLV.DataSource = Eq;
            VisitsLV.DataBind();


        }
        protected void BindLVByVisit()
        {
            int financialyearid = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int visit = Convert.ToInt32(VisitsDDL.SelectedValue);
            if (visit == 1)
            {
                List<OutgoingVisit> Eq = new IPRBiz().GetAllVisits(financialyearid);
                VisitsLV.DataSource = Eq;
                VisitsLV.DataBind();
            }
            else if (visit == 2)
            {
                List<OutgoingVisit> Eq = new IPRBiz().GetUpcomingVisits(financialyearid);
                VisitsLV.DataSource = Eq;
                VisitsLV.DataBind();
            }
            else if (visit == 3)
            {
                List<OutgoingVisit> Eq = new IPRBiz().GetPreviousVisits(financialyearid);
                VisitsLV.DataSource = Eq;
                VisitsLV.DataBind();
            }

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            VisitsLV.SelectedIndex = -1;
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLVByVisit();

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            BindLVByVisit();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList countries = new DropDownList();
            countries = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (countries != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<Country> pt = new DataManagementBIZ().GetAllCountries();

                foreach (Country row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.CountryId.ToString();
                    cy.Text = row.CountryName.ToString();
                    countries.Items.Add(cy);
                }
            }
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
                OutgoingVisit eh = new OutgoingVisit();
                DropDownList CountryDDL = VisitsLV.InsertItem.FindControl("CountryDDL") as DropDownList;
                TextBox VisitTitle = VisitsLV.InsertItem.FindControl("VisitTitleTxt") as TextBox;
                TextBox FromDate = VisitsLV.InsertItem.FindControl("FromDateTxt") as TextBox;
                TextBox ToDate = VisitsLV.InsertItem.FindControl("ToDateTxt") as TextBox;
                TextBox DollarRate = VisitsLV.InsertItem.FindControl("DollarRateTxt") as TextBox;
                TextBox TransportCharges = VisitsLV.InsertItem.FindControl("TransportChargesTxt") as TextBox;
                TextBox TransportChargesDescription = VisitsLV.InsertItem.FindControl("TransportChargesDescriptionTxt") as TextBox;
                TextBox Details = VisitsLV.InsertItem.FindControl("DetailsTxt") as TextBox;
                eh.CountryId = Convert.ToInt32(CountryDDL.SelectedItem.Value);
                eh.VisitTitle= Convert.ToString(VisitTitle.Text);
                eh.FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                eh.FromDate = Convert.ToDateTime(FromDate.Text);
                eh.ToDate = Convert.ToDateTime(ToDate.Text);
                eh.DollarRate=Convert.ToDouble(DollarRate.Text);
                eh.TransportCharges = Convert.ToInt32(TransportCharges.Text);
                eh.TransportChargesDescription = Convert.ToString(TransportChargesDescription.Text);
                eh.Details = Convert.ToString(Details.Text);
                new IPRBiz().InsertVisit(eh);
                VisitsLV.EditIndex = -1;
                VisitsLV.InsertItemPosition = InsertItemPosition.None;
                VisitsLV.SelectedIndex = -1;
                e.Cancel = true;
                BindLVByVisit();
                //Response.Redirect("~/ManageVisits.aspx?Py=" + FinancialYearDDL.SelectedValue + "$visit=" + VisitsDDL.SelectedValue);
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
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            VisitsLV.EditIndex = e.NewEditIndex;
            e.Cancel = true;
            BindLVByVisit();

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (VisitsLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList countryddl = e.Item.FindControl("CountryDDL") as DropDownList;
                HiddenField countryid = (e.Item.FindControl("HidCountryId") as HiddenField);
                countryddl.SelectedValue = countryid.Value.ToString();

               
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            OutgoingVisit eh = new OutgoingVisit();
            HiddenField visitid = VisitsLV.EditItem.FindControl("HidVisitId") as HiddenField;
            DropDownList CountryDDL = VisitsLV.EditItem.FindControl("CountryDDL") as DropDownList;
            TextBox VisitTitle = VisitsLV.EditItem.FindControl("VisitTitleTxt") as TextBox;
            TextBox FromDate = VisitsLV.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = VisitsLV.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox DollarRate = VisitsLV.EditItem.FindControl("DollarRateTxt") as TextBox;
            TextBox TransportCharges = VisitsLV.EditItem.FindControl("TransportChargesTxt") as TextBox;
            TextBox TransportChargesDescription = VisitsLV.EditItem.FindControl("TransportChargesDescriptionTxt") as TextBox;
            TextBox Details = VisitsLV.EditItem.FindControl("DetailsTxt") as TextBox;
            eh.VisitId=Convert.ToInt32(visitid.Value);
            eh.CountryId = Convert.ToInt32(CountryDDL.SelectedItem.Value);
            eh.VisitTitle = Convert.ToString(VisitTitle.Text);
            eh.FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.DollarRate = Convert.ToDouble(DollarRate.Text);
            eh.TransportCharges = Convert.ToInt32(TransportCharges.Text);
            eh.TransportChargesDescription = Convert.ToString(TransportChargesDescription.Text);
            eh.Details = Convert.ToString(Details.Text);
            new IPRBiz().UpdateVisit(eh);
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            BindLVByVisit();
            //Response.Redirect("~/ManageVisits.aspx?Py=" + FinancialYearDDL.SelectedValue + "$visit=" + VisitsDDL.SelectedValue);
        }

        protected void VisitsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLVByVisit();
           // Response.Redirect("~/ManageVisits.aspx?Py=" + FinancialYearDDL.SelectedValue + "$visit=" + VisitsDDL.SelectedValue);
        }

        protected void FinancialYearDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLVByVisit();
        }
        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField HidEmpPostingId = (HiddenField)VisitsLV.Items[e.ItemIndex].FindControl("HidEmpPostingId");
        //    int EmpPostingId = Convert.ToInt32(HidEmpPostingId.Value);
        //    new IPRBiz().DeleteOutgoingVisit(EmpPostingId);
        //    int empval;
        //    empval = Convert.ToInt32(Request.QueryString["EmpId"]);
        //    BindVistLV();
        //}
    }
}