using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class ThresholdItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Items> items = new AdminBIZ().GetThresholdItems();
            ListView1.DataSource = items;
            ListView1.DataBind();
        }
    }
}