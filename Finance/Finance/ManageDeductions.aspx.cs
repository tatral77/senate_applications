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
    public partial class ManageDeductions : System.Web.UI.Page
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
            List<Deductions> deductions = new FinBIZ().GetDeductions();
            LV.DataSource = deductions;
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
            TextBox Deduction = (TextBox)LV.InsertItem.FindControl("DeductionTxt");
            Deductions bh = new Deductions();
            bh.DeductionDesc = Convert.ToString(Deduction.Text);
            new FinBIZ().InsertDeduction(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;
            Response.Redirect("ManageDeductions.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidDeductionId = (HiddenField)LV.EditItem.FindControl("HidDeductionId");
            TextBox Deduction = (TextBox)LV.EditItem.FindControl("DeductionTxt");
            Deductions bh = new Deductions();
            bh.DeductionId = Convert.ToInt32(HidDeductionId.Value);
            bh.DeductionDesc = Convert.ToString(Deduction.Text);
            new FinBIZ().UpdateDeduction(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;

        }
    }
}