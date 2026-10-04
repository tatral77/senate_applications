using IPRBIZ;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class Rates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindLocationLV();

            }

        }
        protected string GetRate(int LocationId,int CategoryId)
        {
            int RateListId = Convert.ToInt32(RateListDDL.SelectedValue);
            LocationRate rate=new IPRBiz().GetLocationsCategoryRate(RateListId, LocationId, CategoryId);
            return Convert.ToString(rate.Rate);
        }
        protected void bindLocationLV()
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            Country cn = new DataManagementBIZ().GetCountry(CountryId);
            heading.InnerText = cn.CountryName.ToUpper();
            List<Location> Location = new IPRBiz().GetCountryLocations(CountryId);
            LocationLV.DataSource = Location;
            LocationLV.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            LocationLV.SelectedIndex = -1;
            LocationLV.EditIndex = -1;
            LocationLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindLocationLV();

        }
        //protected void ItemEditing(object sender, ListViewEditEventArgs e)
        //{
        //    LocationLV.InsertItemPosition = InsertItemPosition.None;
        //    LocationLV.SelectedIndex = -1;
        //    LocationLV.EditIndex = e.NewEditIndex;
        //    bindLocationLV();
        //    e.Cancel = true;


        //}
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (LocationLV.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindLocationLV();
        //}
        //protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    if (LocationLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
        //    {

        //        //DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
        //        //HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
        //        //IsActive.SelectedValue = HidIsActive.Value.ToString();

        //    }
        //}

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {


        }

        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    LocationLV.EditIndex = -1;
        //    LocationLV.InsertItemPosition = InsertItemPosition.None;
        //    LocationLV.SelectedIndex = -1;
        //    bindLocationLV();
        //    e.Cancel = true;
        //}


        //protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        //{
        //    int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
        //    TextBox LocationNameTxt = (TextBox)LocationLV.InsertItem.FindControl("LocationNameTxt");
        //    Location ep = new Location();
        //    ep.CountryId = CountryId;
        //    ep.LocationName = Convert.ToString(LocationNameTxt.Text);
        //    new IPRBiz().InsertLocation(ep);
        //    LocationLV.EditIndex = -1;
        //    LocationLV.InsertItemPosition = InsertItemPosition.None;
        //    bindLocationLV();
        //    e.Cancel = true;
        //    Response.Redirect("ManageLocations.aspx?Id=" + CountryId);
        //}
        //protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        //{
        //    HiddenField HidLocationId = (HiddenField)LocationLV.EditItem.FindControl("HidLocationId");
        //    TextBox Description = (TextBox)LocationLV.EditItem.FindControl("LocationNameTxt");
        //    Location ep = new Location();
        //    ep.LocationId = Convert.ToInt32(HidLocationId.Value);
        //    ep.LocationName = Convert.ToString(Description.Text);
        //    new IPRBiz().UpdateLocation(ep);
        //    LocationLV.EditIndex = -1;
        //    LocationLV.InsertItemPosition = InsertItemPosition.None;
        //    bindLocationLV();
        //    e.Cancel = true;
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {

            int RateListId = Convert.ToInt32(RateListDDL.SelectedValue);
            LocationRate locationrate = new LocationRate();
            List<int> questions = new List<int>();
            foreach (ListViewItem li in LocationLV.Items)
            {
                locationrate.RateListId = RateListId;
                HiddenField LocationId = (HiddenField)li.FindControl("HidLocationId");
                TextBox Cat1 = (TextBox)li.FindControl("Cat1");
                TextBox Cat2 = (TextBox)li.FindControl("Cat2");
                TextBox Cat3 = (TextBox)li.FindControl("Cat3");
                TextBox Cat4 = (TextBox)li.FindControl("Cat4");
                locationrate.LocationId = Convert.ToInt32(LocationId.Value);
                locationrate.CategoryId = 1;
                locationrate.Rate = Convert.ToInt32(Cat1.Text);
                new IPRBiz().InsertLocationRate(locationrate);
                locationrate.CategoryId = 2;
                locationrate.Rate = Convert.ToInt32(Cat2.Text);
                new IPRBiz().InsertLocationRate(locationrate);
                locationrate.CategoryId = 3;
                locationrate.Rate = Convert.ToInt32(Cat3.Text);
                new IPRBiz().InsertLocationRate(locationrate);
                locationrate.CategoryId = 4;
                locationrate.Rate = Convert.ToInt32(Cat4.Text);
                new IPRBiz().InsertLocationRate(locationrate);
                sucess.InnerText = "Saved Successfully.";
            }
        }
    }
}