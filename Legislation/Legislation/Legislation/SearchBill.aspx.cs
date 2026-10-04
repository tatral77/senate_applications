using LegisBIZ;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class SearchBill : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindControl();
        //    }
        //}
        //protected void BindControl()
        //{
        //    List<BillStatuses> billStatuses = new LegislationBiz().GetBillStatuses();
        //    if (billStatuses != null)
        //    {
        //        foreach (BillStatuses item in billStatuses)
        //        {
        //            ListItem li = new ListItem();
        //            li.Value = item.BillStatusesId.ToString();
        //            li.Text = item.Description;
        //            BillStatusesDDL.Items.Add(li);
        //        }
        //    }
        //}


        protected void FromAssemblySessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ToAssemblySessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategoryDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void Search_Click(object sender, EventArgs e)
        {
            //Search();
        }   

    }
}

