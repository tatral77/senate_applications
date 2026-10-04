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
    public partial class OutgoingVisitDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVistLV();
            }
            //else
            //{
            //    int parliamentaryyearid = Convert.ToInt32(Request.QueryString["Py"]);
            //    int visit= Convert.ToInt32(Request.QueryString["visit"]);
            //    ParliamentaryYearDDL.SelectedValue = parliamentaryyearid.ToString();
            //    VisitsDDL.SelectedValue = visit.ToString();
            //    BindLVByVisit(parliamentaryyearid, visit);

            //}

        }
        protected void BindVistLV()
        {
            int visitid = Convert.ToInt32(Request.QueryString["Id"]);
            //BindLVByVisit();
            List<OutgoingVisitDetailEnt> Eq = new IPRBiz().GetVisitDetails(visitid);
            VisitsLV.DataSource = Eq;
            VisitsLV.DataBind();


        }
      
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            VisitsLV.SelectedIndex = -1;
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindVistLV();

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            BindVistLV();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            OutgoingVisit visit = new IPRBiz().GetOutgoingVisit(VisitId);
            DropDownList locations = new DropDownList();
            locations = (e.Item.FindControl("LocationsDDL") as DropDownList);
            if (locations != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<Location> pt = new IPRBiz().GetCountryLocations(visit.CountryId);
                foreach (Location row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.LocationId.ToString();
                    cy.Text = row.LocationName.ToString();
                    locations.Items.Add(cy);
                }
            }
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            OutgoingVisitDetailEnt eh = new OutgoingVisitDetailEnt();
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            DropDownList HidLocationId = VisitsLV.InsertItem.FindControl("LocationsDDL") as DropDownList;
            TextBox FromDate = VisitsLV.InsertItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = VisitsLV.InsertItem.FindControl("ToDateTxt") as TextBox;
            TextBox Details = VisitsLV.InsertItem.FindControl("NoOfNights") as TextBox;
            eh.LocationId = Convert.ToInt32(HidLocationId.SelectedValue);
            eh.VisitId = VisitId;
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            new IPRBiz().InsertVisitDetail(eh);
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            //Response.Redirect("~/ManageVisits.aspx?Py=" + ParliamentaryYearDDL.SelectedValue + "$visit=" + VisitsDDL.SelectedValue);
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
            BindVistLV();

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (VisitsLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList LocationDDL = e.Item.FindControl("LocationsDDL") as DropDownList;
                HiddenField LocationId = (e.Item.FindControl("HidLocationId") as HiddenField);
                LocationDDL.SelectedValue = LocationId.Value.ToString();
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            OutgoingVisitDetailEnt eh = new OutgoingVisitDetailEnt();
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidVisitDetailId = VisitsLV.EditItem.FindControl("HidVisitDetailId") as HiddenField;
            DropDownList HidLocationId = VisitsLV.EditItem.FindControl("LocationsDDL") as DropDownList;
            TextBox FromDate = VisitsLV.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDate = VisitsLV.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox Details = VisitsLV.EditItem.FindControl("NoOfNights") as TextBox;
            eh.OutgoingVisitDetailId= Convert.ToInt32(HidVisitDetailId.Value);
            eh.LocationId = Convert.ToInt32(HidLocationId.SelectedValue);
            eh.VisitId = VisitId;
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            new IPRBiz().UpdateVisitDetail(eh);
            VisitsLV.EditIndex = -1;
            VisitsLV.InsertItemPosition = InsertItemPosition.None;
            VisitsLV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            //Response.Redirect("~/ManageVisits.aspx?Py=" + ParliamentaryYearDDL.SelectedValue + "$visit=" + VisitsDDL.SelectedValue);
        }


        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidVisitDetailId = (HiddenField)VisitsLV.Items[e.ItemIndex].FindControl("HidVisitDetailId");
            int visitdetailid = Convert.ToInt32(HidVisitDetailId.Value);
            new IPRBiz().DeleteVisitDetail(visitdetailid);
            BindVistLV();
        }
    }
}