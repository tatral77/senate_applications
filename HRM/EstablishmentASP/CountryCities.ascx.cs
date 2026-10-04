using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class CountryCities : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["loginstatus"];
            //if (userinfo != null)
            //{
            //    string role = userinfo.Value;
            //    if (role.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            if (!IsPostBack)
            bindCoutriesDDL();

        }
        protected void  bindCoutriesDDL()
        {
            List<Country> countries = new AdministrationBIZ().GetCountries();
            foreach (Country row in countries)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.CountryId.ToString();
                CountriesDDL.Items.Add(li);
            }
        
        }

        protected void CountriesDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CitiesDDL.Items.Clear();
            List < City > cities= new AdministrationBIZ().GetCountryCities(Convert.ToInt32(CountriesDDL.SelectedValue));
            if (cities != null)
            {
                foreach (City row in cities)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.CityId.ToString();
                    CitiesDDL.Items.Add(li);
                }
            }
        }
    }
}