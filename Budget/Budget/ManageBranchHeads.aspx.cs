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
    public partial class ManageBranchHeads : System.Web.UI.Page
    {
        string lastrec = "";
        string major = "";
        int i = 0;
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
                int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
                heading.InnerText = new BudgetBiz().GetBranch(BranchId).Description;
                bindBranchHeadsLV();
            }
        }
        protected void bindBranchHeadsLV()
        {
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            int FinancialYearsId = Convert.ToInt32(FinancialYearsDDL.SelectedValue);
            List<BranchHead> composition = new BudgetBiz().GetBranchHeads(BranchId,FinancialYearsId);
            BranchHeadsLV.DataSource = composition;
            BranchHeadsLV.DataBind();

        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("FundCenter"));

            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                return String.Format("<tr style='background-color:#d3d3d3;'><td colspan=4><h4>" + Eval("FundCenter") + "</h4></td><tr>");

            }
            else return String.Empty;
        }
        protected string AddMajorGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("MinorObjectId"));

            if (currentSemesterValue != major)
            {
                major = currentSemesterValue;
                i++;
                return String.Format("<tr><td colspan=4><h5><b>" + Eval("MinorObject") + "</b></h5></td><tr>");

            }
            else return String.Empty;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            BranchHeadsLV.SelectedIndex = -1;
            BranchHeadsLV.EditIndex = -1;
            BranchHeadsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindBranchHeadsLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            BranchHeadsLV.InsertItemPosition = InsertItemPosition.None;
            BranchHeadsLV.SelectedIndex = -1;
            BranchHeadsLV.EditIndex = e.NewEditIndex;
            bindBranchHeadsLV();
            e.Cancel = true;


        }
     
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (BranchHeadsLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
                int FinancialYearId = Convert.ToInt32(FinancialYearsDDL.SelectedValue);
                HiddenField HidHeadOfAccountId = (e.Item.FindControl("HidHeadOfAccountId") as HiddenField);
                HiddenField HidCurrentBudget = (e.Item.FindControl("HidCurrentBudget") as HiddenField);
                int HeadOfAccountId = Convert.ToInt32(HidHeadOfAccountId.Value);
                HeadOfAccountBudget hoabudget = new BudgetBiz().GetHeadOfAccountBudget(HeadOfAccountId, FinancialYearId);
                HidCurrentBudget.Value = Convert.ToString(hoabudget.Savings);
            }

        }

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
           
           
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField HidBranchHeadId = (HiddenField)BranchHeadsLV.Items[e.ItemIndex].FindControl("HidBranchHeadId");
            int FinancialYearId = Convert.ToInt32(FinancialYearsDDL.SelectedValue);
            int HeadOfAccountId = Convert.ToInt32(HidBranchHeadId.Value);
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            BranchHead branchhead = new BudgetBiz().GetBranchHead(BranchId, HeadOfAccountId, FinancialYearId);
            if (branchhead.CurrentAmount != branchhead.BudgetLimit)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert(Can not delete Head of Account. Delete Bills entered in this Head of Account)", true);
            }
            else
            {
                new BudgetBiz().DeleteBranchHead(Convert.ToInt32(HidBranchHeadId.Value));
                bindBranchHeadsLV();
            }
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            BranchHeadsLV.EditIndex = -1;
            BranchHeadsLV.InsertItemPosition = InsertItemPosition.None;
            BranchHeadsLV.SelectedIndex = -1;
            bindBranchHeadsLV();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int fy = new BudgetBiz().GetCurrentFinancialYear().FinancialYearId;
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            HiddenField HidHeadOfAccountId = (HiddenField)BranchHeadsLV.InsertItem.FindControl("HidHeadOfAccountId");
            HiddenField HidCurrentBudget = (HiddenField)BranchHeadsLV.InsertItem.FindControl("HidCurrentBudget");
            TextBox BudgetLimitTxt = (TextBox)BranchHeadsLV.InsertItem.FindControl("BudgetLimitTxt");
            Label err= (Label)BranchHeadsLV.InsertItem.FindControl("err");
            double currentbudget = Convert.ToDouble(HidCurrentBudget.Value);
            BranchHead bh= new BranchHead();
            bh.BranchId = BranchId;
            bh.FinancialYearId = fy;
            bh.HeadOfAccountId = Convert.ToInt32(HidHeadOfAccountId.Value);
            bh.BudgetLimit = Convert.ToDouble(BudgetLimitTxt.Text);
            if (bh.BudgetLimit > currentbudget)
                err.Text = "Amount exceeded from " + currentbudget;
            else
            {
                err.Text = "";
                new BudgetBiz().InsertBranchHead(bh);
                BranchHeadsLV.EditIndex = -1;
                BranchHeadsLV.InsertItemPosition = InsertItemPosition.None;
                bindBranchHeadsLV();
                e.Cancel = true;
                Response.Redirect("ManageBranchHeads.aspx?BID=" + BranchId);
            }

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            HiddenField HidHeadOfAccountId = (HiddenField)BranchHeadsLV.EditItem.FindControl("HidHeadOfAccountId");
            HiddenField HidBranchHeadId = (HiddenField)BranchHeadsLV.EditItem.FindControl("HidBranchHeadId");
            TextBox BudgetLimitTxt = (TextBox)BranchHeadsLV.EditItem.FindControl("BudgetLimitTxt");
            HiddenField HidCurrentBudget = (HiddenField)BranchHeadsLV.EditItem.FindControl("HidCurrentBudget");
            Label err = (Label)BranchHeadsLV.EditItem.FindControl("err");
            BranchHead bh = new BranchHead();
            double currentbudget = Convert.ToDouble(HidCurrentBudget.Value);
            bh.BranchId = BranchId;
            bh.BranchHeadId = Convert.ToInt32(HidBranchHeadId.Value);
            bh.HeadOfAccountId = Convert.ToInt32(HidHeadOfAccountId.Value);
            bh.BudgetLimit = Convert.ToDouble(BudgetLimitTxt.Text);
            if (bh.BudgetLimit > currentbudget)
                err.Text = "Amount exceeded from " + currentbudget;
            else
            {
                err.Text = "";
                new BudgetBiz().UpdateBranchHead(bh);
                BranchHeadsLV.EditIndex = -1;
                BranchHeadsLV.InsertItemPosition = InsertItemPosition.None;
                bindBranchHeadsLV();
                e.Cancel = true;
            }

        }
        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindBranchHeadsLV();
        }
    }
}