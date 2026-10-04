using FinBiz;
using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finance
{
    public partial class ManageAllowances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllowancesLV();

            }
        }
        protected void BindAllowancesLV()
        {
            List<Allowances> allowances = new FinBIZ().GetAllowances();
            LV.DataSource = allowances;
            LV.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindAllowancesLV();

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            BindAllowancesLV();
            e.Cancel = true;
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            BindAllowancesLV();
            e.Cancel = true;


        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox Allowance = (TextBox)LV.InsertItem.FindControl("AllowanceTxt");
            HiddenField HeadOfAccountId = (HiddenField)LV.InsertItem.FindControl("HidHeadOfAccountId");
            Allowances bh = new Allowances();
            bh.AllowanceDesc = Convert.ToString(Allowance.Text);
            bh.HeadOfAccountId = Convert.ToInt32(HeadOfAccountId.Value);
            new FinBIZ().InsertAllowance(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;
            Response.Redirect("ManageAllowances.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidAllowanceId = (HiddenField)LV.EditItem.FindControl("HidAllowanceId");
            TextBox Allowance = (TextBox)LV.EditItem.FindControl("AllowanceTxt");
            HiddenField HeadOfAccountId = (HiddenField)LV.EditItem.FindControl("HidHeadOfAccountId");
            Allowances bh = new Allowances();
            bh.AllowanceId= Convert.ToInt32(HidAllowanceId.Value);
            bh.AllowanceDesc = Convert.ToString(Allowance.Text);
            bh.HeadOfAccountId = Convert.ToInt32(HeadOfAccountId.Value);
            new FinBIZ().UpdateAllowance(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;

        }


    }
}