using BIZ;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Management
{
    public partial class ManageCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                BindCityLv();
                BindDivisionLv();
                int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
                Country country = new DataManagementBIZ().GetCountry(CountryId);
                CountryNameLbl.Text = country.CountryName.ToUpper();
            }

        }
        #region City
        protected void BindCityLv()
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            List<City> City = new DataManagementBIZ().GetCities(CountryId);
            CityLv.DataSource = City;
            CityLv.DataBind();

        }
        protected void NewCity_Click(object sender, EventArgs e)
        {
            CityLv.SelectedIndex = -1;
            CityLv.EditIndex = -1;
            CityLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindCityLv();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CityLv.InsertItemPosition = InsertItemPosition.None;
            CityLv.SelectedIndex = -1;
            CityLv.EditIndex = e.NewEditIndex;
            BindCityLv();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (CityLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex || DivisionLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList DivisionDDL = e.Item.FindControl("DivisionDDL") as DropDownList;
                HiddenField HidDivisionId = (e.Item.FindControl("HidDivisionId") as HiddenField);
                if(DivisionDDL!=null && HidDivisionId!=null)
                    DivisionDDL.SelectedValue = HidDivisionId.Value.ToString();

                DropDownList DivisionTypeDDL = e.Item.FindControl("DivisionTypeDDL") as DropDownList;
                HiddenField HidDivisionTypeId = (e.Item.FindControl("HidDivisionTypeId") as HiddenField);
                if (DivisionTypeDDL != null && HidDivisionTypeId != null)
                    DivisionTypeDDL.SelectedValue = HidDivisionTypeId.Value.ToString();

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
            DropDownList DivisionDDL = new DropDownList();
            DivisionDDL = (e.Item.FindControl("DivisionDDL") as DropDownList);

            if (DivisionDDL != null)
            {
                int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
                List<CountryDivision> ps = new DataManagementBIZ().GetCountryDivisions(CountryId);
                if (ps != null)
                {
                    foreach (CountryDivision row in ps)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.CountryDivisionId.ToString();
                        li.Text = row.CountryDivisionName.ToString();
                        DivisionDDL.Items.Add(li);
                    }
                }

            }
            DropDownList DivisionTypeDDL = new DropDownList();
            DivisionTypeDDL = (e.Item.FindControl("DivisionTypeDDL") as DropDownList);
            if (DivisionTypeDDL != null)
            {
                List<CountryDivisionType> dt = new DataManagementBIZ().GetCountryDivisionTypes();
                if (dt != null)
                {
                    foreach (CountryDivisionType row in dt)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.CountryDivisionTypeId.ToString();
                        li.Text = row.CountryDivisionTypeDesc.ToString();
                        DivisionTypeDDL.Items.Add(li);
                    }
                }

            }

        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            CityLv.EditIndex = -1;
            CityLv.InsertItemPosition = InsertItemPosition.None;
            CityLv.SelectedIndex = -1;
            BindCityLv();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox CityName = (TextBox)CityLv.InsertItem.FindControl("CityNameTxt");
            DropDownList DivisionDDL = (DropDownList)CityLv.InsertItem.FindControl("DivisionDDL");
            DropDownList IsActiveDDL = (DropDownList)CityLv.InsertItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.CityName = Convert.ToString(CityName.Text);
            ep.CountryDivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);
            ep.CountryId = CountryId;
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new DataManagementBIZ().InsertCity(ep);
            CityLv.EditIndex = -1;
            CityLv.InsertItemPosition = InsertItemPosition.None;
            BindCityLv();
            e.Cancel = true;
            Response.Redirect("ManageCountry.aspx?Id="+ CountryId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidCityId = (HiddenField)CityLv.EditItem.FindControl("HidCityId");
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox CityName = (TextBox)CityLv.EditItem.FindControl("CityNameTxt");
            DropDownList DivisionDDL = (DropDownList)CityLv.EditItem.FindControl("DivisionDDL");
            DropDownList IsActiveDDL = (DropDownList)CityLv.EditItem.FindControl("IsActiveDDL");
            City ep = new City();
            ep.CityId = Convert.ToInt32(HidCityId.Value);
            ep.CityName = Convert.ToString(CityName.Text);
            ep.CountryDivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);
            ep.CountryId = CountryId;
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new DataManagementBIZ().UpdateCity(ep);
            CityLv.EditIndex = -1;
            CityLv.InsertItemPosition = InsertItemPosition.None;
            BindCityLv();
            e.Cancel = true;
            Response.Redirect("ManageCountry.aspx?Id=" + CountryId);
        }
        #endregion City



        #region Country Division
        protected void NewDivision_Click(object sender, EventArgs e)
        {
            DivisionLv.SelectedIndex = -1;
            DivisionLv.EditIndex = -1;
            DivisionLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDivisionLv();

        }
        protected void BindDivisionLv()
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            List<CountryDivision> countrydivision = new DataManagementBIZ().GetCountryDivisions(CountryId);
            DivisionLv.DataSource = countrydivision;
            DivisionLv.DataBind();

        }
        protected void NewCountryDivision_Click(object sender, EventArgs e)
        {
            DivisionLv.SelectedIndex = -1;
            DivisionLv.EditIndex = -1;
            DivisionLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindCityLv();

        }
        protected void DivisionItemEditing(object sender, ListViewEditEventArgs e)
        {
            DivisionLv.InsertItemPosition = InsertItemPosition.None;
            DivisionLv.SelectedIndex = -1;
            DivisionLv.EditIndex = e.NewEditIndex;
            BindDivisionLv();
            e.Cancel = true;


        }
        protected void DivisionItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            DivisionLv.EditIndex = -1;
            DivisionLv.InsertItemPosition = InsertItemPosition.None;
            DivisionLv.SelectedIndex = -1;
            BindDivisionLv();
            e.Cancel = true;
        }


        protected void DivisionItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox DivisionName = (TextBox)DivisionLv.InsertItem.FindControl("DivisionNameTxt");
            DropDownList DivisionTypeDDL = (DropDownList)DivisionLv.InsertItem.FindControl("DivisionTypeDDL");
            DropDownList IsActiveDDL = (DropDownList)DivisionLv.InsertItem.FindControl("IsActiveDDL");
            CountryDivision ep = new CountryDivision();
            ep.CountryDivisionName = Convert.ToString(DivisionName.Text);
            ep.CountryDivisionTypeId = Convert.ToInt32(DivisionTypeDDL.SelectedItem.Value);
            ep.CountryId = CountryId;
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new DataManagementBIZ().InsertCountryDivision(ep);
            DivisionLv.EditIndex = -1;
            DivisionLv.InsertItemPosition = InsertItemPosition.None;
            BindDivisionLv();
            e.Cancel = true;
            Response.Redirect("ManageCountry.aspx?Id=" + CountryId);
        }
        protected void DivisionItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int CountryId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidDivisionId = (HiddenField)DivisionLv.EditItem.FindControl("HidDivisionId");
            TextBox DivisionNameTxt = (TextBox)DivisionLv.EditItem.FindControl("DivisionNameTxt");
            DropDownList DivisionTypeDDL = (DropDownList)DivisionLv.EditItem.FindControl("DivisionTypeDDL");
            DropDownList IsActiveDDL = (DropDownList)DivisionLv.EditItem.FindControl("IsActiveDDL");
            CountryDivision ep = new CountryDivision();
            ep.CountryDivisionName = Convert.ToString(DivisionNameTxt.Text);
            ep.CountryDivisionId = Convert.ToInt32(HidDivisionId.Value);
            ep.CountryDivisionTypeId= Convert.ToInt32(DivisionTypeDDL.SelectedItem.Value);
            ep.CountryId = CountryId;
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new DataManagementBIZ().UpdateCountryDivision(ep);
            DivisionLv.EditIndex = -1;
            DivisionLv.InsertItemPosition = InsertItemPosition.None;
            BindDivisionLv();
            e.Cancel = true;
            Response.Redirect("ManageCountry.aspx?Id=" + CountryId);
        }

        #endregion

    }
}