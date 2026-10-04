using BUDBIZ;
using BUDENTITIES;
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
    public partial class ManageMonthlyChange : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
                int fy = Convert.ToInt32(Request.QueryString["fy"]);
                int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
                Member mem = new FinBIZ().GetMemberById(MemberId);
                FinancialYears fyear = new BudgetBiz().GetFinancialYear(fy);
                Months mon = new BudgetBiz().GetMonth(Mon);
                header.Text = mem.MemberName + "(" + mon.MonthName +" - " + fyear.FinancialYear +")";
                BindAllowanceLV();
                BindDeductionLV();

            }

        }
        protected void BindAllowanceLV()
        {
            int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            List<MonthlyChange> sal = new FinBIZ().GetMonthlyChanges(MemberId,fy,Mon);
            LV.DataSource = sal;
            LV.DataBind();

        }
        protected void BindDeductionLV()
        {
            int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            List<MonthlyChange> sal = new FinBIZ().GetMonthlyDeductionChanges(MemberId, fy, Mon);
            DLV.DataSource = sal;
            DLV.DataBind();

        }
        protected string GetLink(int MemberId)
        {
            return "~/ManageMonthlyChange.aspx?Id=" + MemberId;
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            TextBox Amount = (TextBox)LV.InsertItem.FindControl("AmountTxt");
            TextBox Remarks = (TextBox)LV.InsertItem.FindControl("RemarksTxt");
            DropDownList AllowanceId = (DropDownList)LV.InsertItem.FindControl("AllowanceDDL");
            MonthlyChange bh = new MonthlyChange();
            bh.MemberId = MemberId;
            bh.FinancialYearId = fy;
            bh.MonthId = Mon;
            bh.Id = Convert.ToInt32(AllowanceId.SelectedValue);
            bh.Amount = Convert.ToDouble(Amount.Text);
            bh.Remarks = Convert.ToString(Remarks.Text);
            new FinBIZ().InsertMonthlyChange(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindAllowanceLV();
            e.Cancel = true;

        }
        protected void ItemDeductionInserting(object sender, ListViewInsertEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            TextBox Amount = (TextBox)DLV.InsertItem.FindControl("AmountTxt");
            TextBox Limit = (TextBox)DLV.InsertItem.FindControl("LimitTxt");
            TextBox Remarks = (TextBox)DLV.InsertItem.FindControl("RemarksTxt");
            DropDownList DeductionId = (DropDownList)DLV.InsertItem.FindControl("DeductionDDL");
            MonthlyChange bh = new MonthlyChange();
            bh.MemberId = MemberId;
            bh.FinancialYearId = fy;
            bh.MonthId = Mon;
            bh.Id = Convert.ToInt32(DeductionId.SelectedValue);
            bh.Amount = Convert.ToDouble(Amount.Text);
            bh.Limit = Convert.ToDouble(Limit.Text);
            bh.Remarks = Convert.ToString(Remarks.Text);
            new FinBIZ().InsertMonthlyDeductionChange(bh);
            DLV.EditIndex = -1;
            DLV.InsertItemPosition = InsertItemPosition.None;
            BindDeductionLV();
            e.Cancel = true;

        }
        //protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        //{
        //    int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
        //    HiddenField BankAccountId = (HiddenField)LV.EditItem.FindControl("HidMemberBankAccountId");
        //    TextBox BankName = (TextBox)LV.EditItem.FindControl("BankNameTxt");
        //    TextBox AccountNumber = (TextBox)LV.EditItem.FindControl("AccountNumberTxt");
        //    CheckBox IsSalaried = (CheckBox)LV.EditItem.FindControl("IsSalariedCB");
        //    MonthlyChange bh = new MonthlyChange();
        //    bh.MemberId = MemberId;
        //    bh.MemberBankAccountId = Convert.ToInt32(BankAccountId.Value);
        //    bh.BankName = Convert.ToString(BankName.Text);
        //    bh.AccountNumber = Convert.ToString(AccountNumber.Text);
        //    bh.IsSalaried = (IsSalaried.Checked == true) ? 1 : 0;
        //    new FinBIZ().UpdateMemberBankAccount(bh);
        //    LV.EditIndex = -1;
        //    LV.InsertItemPosition = InsertItemPosition.None;
        //    BindVistLV();
        //    e.Cancel = true;
        //    Response.Redirect("~/ManageMonthlyChange.aspx?Id=" + MemberId);

        //}


        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            //int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            List<Allowances> cy = new FinBIZ().GetAllowances();
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("AllowanceDDL") as DropDownList);
            if (ddl != null)
            {
                foreach (Allowances row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.AllowanceId.ToString();
                    ty.Text = row.AllowanceDesc.ToString() + " (" + row.Id + ")"; 
                    ddl.Items.Add(ty);
                }

            }
            List<Deductions> cy2 = new FinBIZ().GetDeductions();
            DropDownList ddl2 = new DropDownList();
            ddl2 = (e.Item.FindControl("DeductionDDL") as DropDownList);
            if (ddl2 != null)
            {
                foreach (Deductions row in cy2)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.DeductionId.ToString();
                    ty.Text = row.DeductionDesc.ToString();
                    ddl2.Items.Add(ty);
                }

            }

        }

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ChangeId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidMonthlyChangeId");
            int Id = Convert.ToInt32(ChangeId.Value);
            new FinBIZ().DeleteMonthlyChange(Id);
            BindAllowanceLV();
        }
        protected void ItemDeductionDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ChangeId = (HiddenField)DLV.Items[e.ItemIndex].FindControl("HidMonthlyChangeId");
            int Id = Convert.ToInt32(ChangeId.Value);
            new FinBIZ().DeleteMonthlyDeductionChange(Id);
            BindDeductionLV();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindAllowanceLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            BindAllowanceLV();
            e.Cancel = true;


        }
        protected void ItemDeductionEditing(object sender, ListViewEditEventArgs e)
        {
            DLV.InsertItemPosition = InsertItemPosition.None;
            DLV.SelectedIndex = -1;
            DLV.EditIndex = e.NewEditIndex;
            BindDeductionLV();
            e.Cancel = true;


        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            BindAllowanceLV();
            e.Cancel = true;
        }
        protected void ItemDeductionCanceling(object sender, ListViewCancelEventArgs e)
        {
            DLV.EditIndex = -1;
            DLV.InsertItemPosition = InsertItemPosition.None;
            DLV.SelectedIndex = -1;
            BindDeductionLV();
            e.Cancel = true;
        }

        protected void DeductionBtn_Click(object sender, EventArgs e)
        {
            DLV.SelectedIndex = -1;
            DLV.EditIndex = -1;
            DLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDeductionLV();

        }
        //protected string GetStatus(int id)
        //{
        //    if (id == 0)
        //        return "No";
        //    else
        //        return "Yes";

        //}
    }
}