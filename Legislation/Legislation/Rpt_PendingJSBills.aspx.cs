using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LegisEntities;
using LegisBIZ;

namespace Legislation
{
    public partial class Rpt_PendingJSBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //List<BillStatuses> billStatuses = new LegislationBiz().GetActiveBillStatuses();
                //if (billStatuses != null)
                //{
                //    foreach (BillStatuses row in billStatuses)
                //    {
                //        ListItem li = new ListItem();
                //        li.Text = row.Description;
                //        li.Value = row.BillStatusesId.ToString();
                //        BillStatusDDL.Items.Add(li);
                //    }
                //}
                //  int parliamentaryYearsId = new AdministrationBiz().GetCurrentParliamentaryYear().ParliamentaryYearsId;
                List<Bills> Bills = new LegisBIZ.LegislationBiz().GetBillsByStatus(21);
                JSBillsLV.DataSource = Bills;
                JSBillsLV.DataBind();
            }
        }
    }
}