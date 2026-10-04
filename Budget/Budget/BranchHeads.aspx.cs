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
    public partial class BranchHeads : System.Web.UI.Page
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
                        FinancialYearsDDL.Items.Add(li);
                    }
                }
            }
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            heading.InnerText = new BudgetBiz().GetBranch(BranchId).Description;
            BindBillLV();
        }

        protected void BindBillLV()
        {
            int FinancialYearsId = Convert.ToInt32(FinancialYearsDDL.SelectedValue);
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            List<BranchHead> BranchHead = new BudgetBiz().GetBranchHeads(BranchId, FinancialYearsId);
            BillLV.DataSource = BranchHead;
            BillLV.DataBind();
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            BillLV.EditIndex = -1;
            BillLV.InsertItemPosition = InsertItemPosition.None;
            BillLV.SelectedIndex = -1;
            BindBillLV();
            e.Cancel = true;
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            BranchHead eh = new BranchHead();
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            HiddenField HeadOfAccountId = BillLV.InsertItem.FindControl("HidHeadOfAccountId") as HiddenField;
            TextBox BudgetLimit = BillLV.InsertItem.FindControl("BudgetLimitTxt") as TextBox;
            eh.BranchId = BranchId;
            string test = HeadOfAccountId.Value;
            eh.HeadOfAccountId = Convert.ToInt32(test);
            eh.HeadOfAccountId = Convert.ToInt32(FinancialYearsDDL.SelectedValue);
            eh.BudgetLimit = Convert.ToDouble(BudgetLimit.Text);
            new BudgetBiz().InsertBranchHead(eh);
            BillLV.EditIndex = -1;
            BillLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BillLV.SelectedIndex = -1;
           // e.Cancel = true;
            Response.Redirect("~/BranchHeads.aspx?BID=" + BranchId);
        }
        protected string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            BillLV.InsertItemPosition = InsertItemPosition.None;
            BillLV.SelectedIndex = -1;
            BillLV.EditIndex = e.NewEditIndex;
            e.Cancel = true;
            BindBillLV();
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            BranchHead eh = new BranchHead();
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            HiddenField HidHeadOfAccountId = BillLV.EditItem.FindControl("HidHeadOfAccountId") as HiddenField;
            TextBox HeadOfAccountTxt = BillLV.EditItem.FindControl("HeadOfAccountTxt") as TextBox;
            HiddenField HidBranchHeadId = BillLV.EditItem.FindControl("HidBranchHeadId") as HiddenField;
            eh.BranchId = BranchId;
            eh.HeadOfAccountId = Convert.ToInt32(HidHeadOfAccountId.Value);
            eh.BranchHeadId = Convert.ToInt32(HidBranchHeadId.Value);
            new BudgetBiz().UpdateBranchHead(eh);
            BillLV.EditIndex = -1;
            BillLV.InsertItemPosition = InsertItemPosition.None;
            BillLV.SelectedIndex = -1;
            e.Cancel = true;
            BindBillLV();
            Response.Redirect("~/BranchHeads.aspx?BID=" + BranchId);
        }

        protected void VisitsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindBillLV();

        }
        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField HidEmpPostingId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidEmpPostingId");
        //    int EmpPostingId = Convert.ToInt32(HidEmpPostingId.Value);
        //    new IPRBiz().DeleteOutgoingVisit(EmpPostingId);
        //    int empval;
        //    empval = Convert.ToInt32(Request.QueryString["EmpId"]);
        //    BindBillLV();
        //}
        // }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BillLV.SelectedIndex = -1;
            BillLV.EditIndex = -1;
            BillLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindBillLV();
        }

        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBillLV();
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
    }
}