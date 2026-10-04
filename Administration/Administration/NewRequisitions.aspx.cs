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
    public partial class NewRequisitions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLV();
            }
        }

        protected void BindLV()
        {
            List<Requisitions> requisition = new AdminBIZ().GetRequisitionsByStatus(1);
            RequisitionItemsLV.DataSource = requisition;
            RequisitionItemsLV.DataBind();
        }

        public string GetDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToShortDateString();
        }
        public string GetLongDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToLongDateString();
        }
    }
}