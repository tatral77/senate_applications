using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }

        }
        protected string Initials(object name)
        {
            string[] parts = Convert.ToString(name).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "?";
            string s = parts[0].Substring(0, 1);
            if (parts.Length > 1) s += parts[parts.Length - 1].Substring(0, 1);
            return HttpUtility.HtmlEncode(s.ToUpper());
        }
        protected void LoadData()
        {
            CardsRepeater.DataSource = new EstablishmentBIZ.DashboardBIZ().GetCards();
            CardsRepeater.DataBind();
        }
    }
}