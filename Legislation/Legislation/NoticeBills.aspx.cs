using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LegisBIZ;
using LegisEntities;

namespace Legislation
{
    public partial class NoticeBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindControls();
                bindListView();
            }
        }
        private void bindListView()
        {
            // int parliamentaryYearsId = new AdministrationBiz().GetCurrentParliamentaryYear().ParliamentaryYearsId;
            List<Bills> Bills = new NoticeBiz().GetNoticeBills();
            ListView1.DataSource = Bills;
            ListView1.DataBind();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }
        public string GetLink(string BillId, string HouseTypeId)
        {
            string link = "~/NoticeBillDetails.aspx?BillsId=" + BillId;
            if (!string.IsNullOrEmpty(BillId) && !string.IsNullOrEmpty(HouseTypeId))
            {
                int typeid = Convert.ToInt32(HouseTypeId);
                if (typeid == 2)
                {
                    link = "~/NoticeNABillDetails.aspx?BillsId=" + BillId;
                }
            }
            return link;

        }

    }
}