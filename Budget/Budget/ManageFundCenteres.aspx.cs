using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Budget
{
    public partial class ManageFundCenteres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVistLV();
            }
        }
        protected void BindVistLV()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            List<FundCenters> Eq = new BudgetBiz().GetFundCenters(FinancialYearId);
            LV.DataSource = Eq;
            LV.DataBind();


        }
        protected string GetLink(int FundCenterId)
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            return "~/ManageMajorObjects.aspx?FC=" + FundCenterId + "&FY=" + FinancialYearId;

        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
    }
}