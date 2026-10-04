using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class Leave_EncashmentOpted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int currentyear = DateTime.Now.Year;
                for (int i = 2017; i <= currentyear; i++)
                {
                    ListItem li = new ListItem(i.ToString(), i.ToString());
                    YearsDDL.Items.Add(li);

                }
            }

        }

        protected void ClearSearch_Click(object sender, EventArgs e)
        {

        }
    }
}