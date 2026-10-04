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
    public partial class HOAReappropriationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                List<FinancialYears> fys = new BudgetBiz().GetFinancialYears();
                if (fys != null)
                {
                    foreach (FinancialYears row in fys)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.FinancialYear;
                        li.Value = row.FinancialYearId.ToString();
                        FinancialYearDDL.Items.Add(li);
                    }
                }
               
            }
        }

        protected string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(HOATxt.Text))
                {
                int FY = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                int HOA = Convert.ToInt32(HidHeadOfAccountId.Value);
                List<ReApproprationEnt> reapp = new BudgetBiz().GetHOAReAppropriation(FY, HOA);
                ReappLV.DataSource = reapp;
                ReappLV.DataBind();
            }
            else
            {
                ReappLV.DataSource = null;
                ReappLV.DataBind();
            }
        }
    }
}