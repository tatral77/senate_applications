using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinBiz;
using BUDBIZ;

namespace Finance
{
    public partial class MonthlyChangesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                int FinancialYearId = Convert.ToInt32(Request.QueryString["fy"]);
                int MonthId = Convert.ToInt32(Request.QueryString["Mon"]);
                string month = new BudgetBiz().GetMonth(MonthId).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(MonthId, FinancialYearId);
                monthdiv.InnerText = "MONTHLY CHANGES FOR THE MONTH OF " + month;
                BindListViews();
            }


        }
        protected void BindListViews()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["fy"]);
            int MonthId = Convert.ToInt32(Request.QueryString["Mon"]);
            List<MonthlyChange> AllowanceChanges = new FinBIZ().GetMonthlyChanges(FinancialYearId, MonthId);
            List<MonthlyChange> DeductionChanges = new FinBIZ().GetMonthlyDeductionChanges(FinancialYearId, MonthId);
            LV.DataSource = AllowanceChanges;
            LV.DataBind();
            DLV.DataSource = DeductionChanges;
            DLV.DataBind();
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ChangeId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidMonthlyChangeId");
            int Id = Convert.ToInt32(ChangeId.Value);
            new FinBIZ().DeleteMonthlyChange(Id);
            BindListViews();
        }
        protected void ItemDeductionDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ChangeId = (HiddenField)DLV.Items[e.ItemIndex].FindControl("HidMonthlyChangeId");
            int Id = Convert.ToInt32(ChangeId.Value);
            new FinBIZ().DeleteMonthlyDeductionChange(Id);
            BindListViews();
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
    }
}