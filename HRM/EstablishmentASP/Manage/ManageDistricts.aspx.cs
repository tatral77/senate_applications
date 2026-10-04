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
    public partial class ManageDistricts : System.Web.UI.Page
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
            List<District> District = new AdministrationBIZ().GetAllDistricts();
            ListView1.DataSource = District;
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
                DropDownList ProvinceDDL = e.Item.FindControl("ProvinceDDL") as DropDownList;
                HiddenField HidProvinceId = (e.Item.FindControl("HidProvinceId") as HiddenField);
                ProvinceDDL.SelectedValue = HidProvinceId.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

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
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("DistrictTxt");
            DropDownList ProvinceId = (DropDownList)ListView1.InsertItem.FindControl("ProvinceDDL");
            DropDownList CountryId = (DropDownList)ListView1.InsertItem.FindControl("CountryDDL");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            District ep = new District();
            ep.Description = Convert.ToString(Description.Text);
            ep.ProvinceId = Convert.ToInt32(ProvinceId.SelectedItem.Value);
            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBIZ().InsertDistrict(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            //Response.Redirect("ManageDistrict.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidDistrictId = (HiddenField)ListView1.EditItem.FindControl("HidDistrictId");
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("DistrictTxt");
            DropDownList ProvinceId = (DropDownList)ListView1.EditItem.FindControl("ProvinceDDL");
            DropDownList CountryId = (DropDownList)ListView1.EditItem.FindControl("CountryDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            District ep = new District();
            ep.DistrictId = Convert.ToInt32(HidDistrictId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.ProvinceId = Convert.ToInt32(ProvinceId.SelectedItem.Value);
           

            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
           new AdministrationBIZ().UpdateDistrict(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}