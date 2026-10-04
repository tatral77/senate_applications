using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPRENTITIES;
using IPRBIZ;

namespace IPR
{
    public partial class ManageLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindLocationLV();
            }

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
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LocationLV.InsertItemPosition = InsertItemPosition.None;
            LocationLV.SelectedIndex = -1;
            LocationLV.EditIndex = e.NewEditIndex;
            bindLocationLV();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (LocationLV.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindLocationLV();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LocationLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList CityDDL = e.Item.FindControl("CityDDL") as DropDownList;
                HiddenField HidCityId = (e.Item.FindControl("HidCityId") as HiddenField);
                CityDDL.SelectedValue = HidCityId.Value.ToString();

            }
            if (LocationLV.InsertItemPosition != InsertItemPosition.None)
            {
                TextBox TempControl = (TextBox)LocationLV.InsertItem.FindControl("LocationNameTxt");
                TempControl.Focus();
            }
        }

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            DropDownList cities = new DropDownList();
            cities = (e.Item.FindControl("CityDDL") as DropDownList);
            if (cities != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<City> pt = new DataManagementBIZ().GetActiveCitiesByCountry(CountryId);
                if (pt != null)
                {
                    foreach (City row in pt)
                    {
                        ListItem cy = new ListItem();
                        cy.Value = row.CityId.ToString();
                        cy.Text = row.CityName.ToString();
                        cities.Items.Add(cy);
                    }
                }
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField LocationId = (HiddenField)LocationLV.Items[e.ItemIndex].FindControl("HidLocationId");
            new IPRBiz().DeleteLocation(Convert.ToInt32(LocationId.Value));
            bindLocationLV();
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LocationLV.EditIndex = -1;
            LocationLV.InsertItemPosition = InsertItemPosition.None;
            LocationLV.SelectedIndex = -1;
            bindLocationLV();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox LocationNameTxt = (TextBox)LocationLV.InsertItem.FindControl("LocationNameTxt");
            DropDownList CityDDL = LocationLV.InsertItem.FindControl("CityDDL") as DropDownList;
            Location ep = new Location();
            ep.CountryId = CountryId;
            ep.LocationName = Convert.ToString(LocationNameTxt.Text);
            ep.CityId= Convert.ToInt32(CityDDL.SelectedValue);
            new IPRBiz().InsertLocation(ep);
            LocationLV.EditIndex = -1;
            LocationLV.InsertItemPosition = InsertItemPosition.None;
            bindLocationLV();
            e.Cancel = true;
            //Response.Redirect("ManageLocations.aspx?Id=" + CountryId);
             LocationLV.SelectedIndex = -1;
            LocationLV.EditIndex = -1;
            LocationLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindLocationLV();
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidLocationId = (HiddenField)LocationLV.EditItem.FindControl("HidLocationId");
            TextBox Description = (TextBox)LocationLV.EditItem.FindControl("LocationNameTxt");
            DropDownList CityDDL = LocationLV.EditItem.FindControl("CityDDL") as DropDownList;
            Location ep = new Location();
            ep.LocationId = Convert.ToInt32(HidLocationId.Value);
            ep.LocationName = Convert.ToString(Description.Text);
            ep.CityId = Convert.ToInt32(CityDDL.SelectedValue);
            new IPRBiz().UpdateLocation(ep);
            LocationLV.EditIndex = -1;
            LocationLV.InsertItemPosition = InsertItemPosition.None;
            bindLocationLV();
            e.Cancel = true;
        }
    }
}