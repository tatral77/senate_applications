using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP.Manage
{
    public partial class ManageCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
            }

        }
        protected void bindListView1()
        {
            List<City> City = new AdministrationBIZ().GetAllCities();
            ListView1.DataSource = City;
            ListView1.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.FirstItem;
            bindListView1();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = e.NewEditIndex;
            bindListView1();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList CountryDDL = e.Item.FindControl("CountryDDL") as DropDownList;
                HiddenField HidCountryId = (e.Item.FindControl("HidCountryId") as HiddenField);
                CountryDDL.SelectedValue = HidCountryId.Value.ToString();

                DropDownList ProvinceDDL = e.Item.FindControl("ProvinceDDL") as DropDownList;
                HiddenField HidProvinceId = (e.Item.FindControl("HidProvinceId") as HiddenField);
                ProvinceDDL.SelectedValue = HidProvinceId.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

                DropDownList IsDistrict = e.Item.FindControl("IsDistrictDDL") as DropDownList;
                HiddenField HidIsDistrict = (e.Item.FindControl("HidIsDistrict") as HiddenField);
                IsDistrict.SelectedValue = HidIsDistrict.Value.ToString();

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
            DropDownList CountryDDL = new DropDownList();
            CountryDDL = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (CountryDDL != null)
            {
                List<Country> ps = new AdministrationBIZ().GetCountries();

                foreach (Country row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CountryId.ToString();
                    li.Text = row.Description.ToString();
                    CountryDDL.Items.Add(li);
                }

            }
            DropDownList ProvinceDDL = new DropDownList();
            ProvinceDDL = (e.Item.FindControl("ProvinceDDL") as DropDownList);
            if (ProvinceDDL != null)
            {
                List<Province> ps = new AdministrationBIZ().GetProvinces();

                foreach (Province row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ProvincesID.ToString();
                    li.Text = row.Description.ToString();
                    ProvinceDDL.Items.Add(li);
                }

            }

        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            bindListView1();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("CityTxt");
            DropDownList ProvinceId = (DropDownList)ListView1.InsertItem.FindControl("ProvinceDDL");
            DropDownList CountryId = (DropDownList)ListView1.InsertItem.FindControl("CountryDDL");
            DropDownList IsDistrict = (DropDownList)ListView1.InsertItem.FindControl("IsDistrictDDL");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.Description = Convert.ToString(Description.Text);
            ep.ProvinceId = Convert.ToInt32(ProvinceId.SelectedItem.Value);
            ep.CountryId = Convert.ToInt32(CountryId.SelectedItem.Value);
            ep.IsDistrict= Convert.ToInt32(IsDistrict.SelectedItem.Value);
            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBIZ().InsertCity(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageCity.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidCityId = (HiddenField)ListView1.EditItem.FindControl("HidCityId");
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("CityTxt");
            DropDownList ProvinceId = (DropDownList)ListView1.EditItem.FindControl("ProvinceDDL");
            DropDownList CountryId = (DropDownList)ListView1.EditItem.FindControl("CountryDDL");
            DropDownList IsDistrict = (DropDownList)ListView1.EditItem.FindControl("IsDistrictDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.CityId = Convert.ToInt32(HidCityId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.ProvinceId = Convert.ToInt32(ProvinceId.SelectedItem.Value);
            ep.CountryId = Convert.ToInt32(CountryId.SelectedItem.Value);
            ep.IsDistrict = Convert.ToInt32(IsDistrict.SelectedItem.Value);
            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBIZ().UpdateCity(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}