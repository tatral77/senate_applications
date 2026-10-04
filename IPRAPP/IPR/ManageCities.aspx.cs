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
    public partial class ManageCities : System.Web.UI.Page
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
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            Country cy = new DataManagementBIZ().GetCountry(CountryId);
            header.InnerText = "CITIES OF (" + cy.CountryName.ToUpper() + ")";
            List<City> City = new DataManagementBIZ().GetAllCitiesByCountry(CountryId);
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
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField CityId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidCityId");
            new DataManagementBIZ().DeleteCity(Convert.ToInt32(CityId.Value));
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

             

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

               

            }
            if (ListView1.InsertItemPosition != InsertItemPosition.None)
            {
                TextBox TempControl = (TextBox)ListView1.InsertItem.FindControl("CityTxt");
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
            //TextBox citytxt = (e.Item.FindControl("CityTxt") as TextBox);
            //citytxt.Focus();
            DropDownList CountryDDL = new DropDownList();
            CountryDDL = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (CountryDDL != null)
            {
                List<Country> ps = new DataManagementBIZ().GetActiveCountries();

                foreach (Country row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CountryId.ToString();
                    li.Text = row.CountryName.ToString();
                    CountryDDL.Items.Add(li);
                }

            }
            //DropDownList ProvinceDDL = new DropDownList();
            //ProvinceDDL = (e.Item.FindControl("ProvinceDDL") as DropDownList);
            //if (ProvinceDDL != null)
            //{
            //    List<Province> ps = new DataManagementBIZ().GetProvinces();

            //    foreach (Province row in ps)
            //    {
            //        ListItem li = new ListItem();
            //        //li.Value = row.ProvincesID.ToString();
            //        //li.Text = row.Description.ToString();
            //        ProvinceDDL.Items.Add(li);
            //    }

            //}

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
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("CityTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.CityName = Convert.ToString(Description.Text);
            ep.CountryId = CountryId;
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new DataManagementBIZ().InsertCity(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
         
            //  }
            e.Cancel = true;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.FirstItem;
            bindListView1();

          //  Response.Redirect("ManageCities.aspx?Id="  + CountryId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidCityId = (HiddenField)ListView1.EditItem.FindControl("HidCityId");
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("CityTxt");
            DropDownList CountryId = (DropDownList)ListView1.EditItem.FindControl("CountryDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.CityId = Convert.ToInt32(HidCityId.Value);
            ep.CityName = Convert.ToString(Description.Text);
            ep.CountryId = Convert.ToInt32(CountryId.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new DataManagementBIZ().UpdateCity(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}