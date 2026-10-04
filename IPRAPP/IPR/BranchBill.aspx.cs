using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUDENTITIES;
using BUDBIZ;

namespace IPR
{
    public partial class BranchBill : System.Web.UI.Page
    {
        int BranchId = 13;
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
                List<BranchHead> branch = new BudgetBiz().GetBranchHeads(BranchId, Convert.ToInt32(FinancialYearDDL.SelectedValue));
                if (branch != null)
                {
                    foreach (BranchHead row in branch)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.HeadOfAccount;
                        li.Value = row.HeadOfAccountId.ToString();
                        HeadOfAccountDDL.Items.Add(li);
                    }
                }
                List<BillStatus> BillStatuses = new BudgetBiz().GetBillStatuses();
                if (BillStatuses != null)
                {
                    foreach (BillStatus row in BillStatuses)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.BillStatusDesc;
                        li.Value = row.BillStatusId.ToString();
                        StatusDDL.Items.Add(li);
                    }
                }
                // GetBills();

                BindBillLV();
            }

        }

        protected void BindBillLV()
        {
            //int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            //int HeadOfAccountId = Convert.ToInt32(Request.QueryString["HOA"]);
            //int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            //List<Bills> bills = new BudgetBiz().GetBranchFinancialYearsBills(FinancialYearId, HeadOfAccountId, BranchId);
            //BillLV.DataSource = bills;
            //BillLV.DataBind();
            GetBills();
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
            Bills eh = new Bills();
            int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            HiddenField HidHOAId = BillLV.InsertItem.FindControl("HidHeadOfAccountId") as HiddenField;
            DropDownList HeadOfAccountDDL2 = BillLV.InsertItem.FindControl("HeadOfAccountDDL") as DropDownList;
            TextBox VendorNameTxt = BillLV.InsertItem.FindControl("VendorNameTxt") as TextBox;
            HiddenField HidVendorId = BillLV.InsertItem.FindControl("HidVendorId") as HiddenField;
            TextBox VendorNumberTxt = BillLV.InsertItem.FindControl("VendorNumberTxt") as TextBox;
            TextBox BillDetailsTxt = BillLV.InsertItem.FindControl("BillDetailsTxt") as TextBox;
            TextBox BillNumberTxt = BillLV.InsertItem.FindControl("BillNumberTxt") as TextBox;
            TextBox BillDateTxt = BillLV.InsertItem.FindControl("BillDateTxt") as TextBox;
            TextBox TotalAmountTxt = BillLV.InsertItem.FindControl("TotalAmountTxt") as TextBox;
            TextBox IncomeTaxTxt = BillLV.InsertItem.FindControl("IncomeTaxTxt") as TextBox;
            TextBox GstTxt = BillLV.InsertItem.FindControl("GstTxt") as TextBox;
            TextBox TokenNumberTxt = BillLV.InsertItem.FindControl("TokenNumberTxt") as TextBox;
            TextBox ChequeNumberTxt = BillLV.InsertItem.FindControl("ChequeNumberTxt") as TextBox;
            TextBox ChequeDateTxt = BillLV.InsertItem.FindControl("ChequeDateTxt") as TextBox;
            TextBox RemarksTxt = BillLV.InsertItem.FindControl("RemarksTxt") as TextBox;
            TextBox SanctionFileNoTxt = BillLV.InsertItem.FindControl("SanctionFileNoTxt") as TextBox;
            TextBox SanctionFileDate = BillLV.InsertItem.FindControl("SanctionFileDate") as TextBox;
            eh.BillStatusId = 1;
            if (!String.IsNullOrEmpty(SanctionFileNoTxt.Text))
            {
                eh.SanctionFileNumber = Convert.ToString(SanctionFileNoTxt.Text);
                eh.SanctionFileDate = Convert.ToDateTime(SanctionFileDate.Text);
                eh.BillStatusId = 2;
            }
            eh.BillTypeId = 1;
            eh.FinancialYearId = FinancialYearId;
            eh.HeadOfAccountId = Convert.ToInt32(HidHOAId.Value);
            eh.BranchId = BranchId;

            eh.VendorId = Convert.ToInt32(HidVendorId.Value);
            eh.VendorName = Convert.ToString(VendorNameTxt.Text);
            eh.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
            eh.BillNumber = Convert.ToString(BillNumberTxt.Text);
            eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
            if (!String.IsNullOrEmpty(BillDateTxt.Text))
            {
                eh.BillDate = Convert.ToDateTime(BillDateTxt.Text);
                eh.GeneratedOn = Convert.ToDateTime(BillDateTxt.Text);
            }
            else
                eh.GeneratedOn = DateTime.Now;
            eh.TotalAmount = Convert.ToDouble(TotalAmountTxt.Text);
            eh.BillCategoryId = 1;
            eh.GeneratedBy = 2;

            // eh.IncomeTax = Convert.ToDouble(IncomeTaxTxt.Text);
            //  eh.Gst = Convert.ToDouble(GstTxt.Text);
            // eh.TokenNumber = Convert.ToString(TokenNumberTxt.Text);
            // eh.ChequeNumber = Convert.ToString(ChequeNumberTxt.Text);
            //  if (!String.IsNullOrEmpty(ChequeDateTxt.Text))
            //      eh.ChequeDate = Convert.ToDateTime(ChequeDateTxt.Text);
            //  eh.Remarks = Convert.ToString(RemarksTxt.Text);
            HeadOfAccountBudget hoa = new BudgetBiz().GetBranchBudget(eh.HeadOfAccountId, FinancialYearId, BranchId);
            if (eh.TotalAmount > hoa.RemainingBalance)
            {
                error.Text = "Amount exceeded from current budget";
            }
            else
            {
                int Id = new BudgetBiz().InsertBill(eh);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('BILL ID " + Id + "')", true);
                BillLV.EditIndex = -1;
                BillLV.InsertItemPosition = InsertItemPosition.None;
                BillLV.SelectedIndex = -1;
                e.Cancel = true;
                BindBillLV();
                Response.Redirect("~/BranchBill.aspx");
            }
        }

        protected string GetDate(DateTime date)
        {
            return (date < Convert.ToDateTime("01/01/1900")) ? string.Empty : date.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            BillLV.InsertItemPosition = InsertItemPosition.None;
            BillLV.SelectedIndex = -1;
            BillLV.EditIndex = e.NewEditIndex;
            e.Cancel = true;
            BindBillLV();


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (BillLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList HeadOfAccountDDL = e.Item.FindControl("HeadOfAccountDDL") as DropDownList;
                HiddenField HidHeadOfAccountId = (e.Item.FindControl("HidHeadOfAccountId") as HiddenField);
                HeadOfAccountDDL.SelectedValue = HidHeadOfAccountId.Value.ToString();


            }
        }


        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList HOADDL = new DropDownList();
            HOADDL = (e.Item.FindControl("HeadOfAccountDDL") as DropDownList);
            if (HOADDL != null)
            {
                List<BranchHead> branch = new BudgetBiz().GetBranchHeads(BranchId, Convert.ToInt32(FinancialYearDDL.SelectedValue));
                if (branch != null)
                {
                    foreach (BranchHead row in branch)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.HeadOfAccount;
                        li.Value = row.HeadOfAccountId.ToString();
                        HOADDL.Items.Add(li);
                    }
                }
            }

            DropDownList TotalAmountTxt = (e.Item.FindControl("TotalAmountTxt") as DropDownList);
            HiddenField HidBillStatusId = (e.Item.FindControl("HidBillStatusId") as HiddenField);
            if (TotalAmountTxt != null)
            {
                int billstatus = Convert.ToInt32(HidBillStatusId.Value);
                if (billstatus == 4)
                    TotalAmountTxt.Attributes.Add("ReadOnly", "true");
            }
        }

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField BillId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidBillId");
            HiddenField HidHeadOfAccountId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidHeadOfAccountId");
            HiddenField HidFinancialYearId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidFinancialYearId");
            int billid = Convert.ToInt32(BillId.Value);
            int hoaId = Convert.ToInt32(HidHeadOfAccountId.Value);
            int fyid = Convert.ToInt32(HidFinancialYearId.Value);
            Bills bill = new BudgetBiz().GetBill(billid);
            if (bill.BillStatusId <= 2)
                new BudgetBiz().DeleteBill(billid, hoaId, fyid, 13);
            BindBillLV();
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField BillStatusId = BillLV.EditItem.FindControl("HidBillStatusId") as HiddenField;
            int BillStatusid = Convert.ToInt32(BillStatusId.Value);
            if (BillStatusid <= 2)
            {
                Bills eh = new Bills();
                int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                int BranchId = 13;
                // DropDownList HOADDL = BillLV.EditItem.FindControl("HeadOfAccountDDL") as DropDownList;
                HiddenField HidHOAId = BillLV.EditItem.FindControl("HidHeadOfAccountId") as HiddenField;
                TextBox VendorNameTxt = BillLV.EditItem.FindControl("VendorNameTxt") as TextBox;
                HiddenField HidVendorId = BillLV.EditItem.FindControl("HidVendorId") as HiddenField;
                HiddenField BillId = BillLV.EditItem.FindControl("HidBillId") as HiddenField;
                TextBox VendorNumberTxt = BillLV.EditItem.FindControl("VendorNumberTxt") as TextBox;
                TextBox BillDetailsTxt = BillLV.EditItem.FindControl("BillDetailsTxt") as TextBox;
                TextBox BillNumberTxt = BillLV.EditItem.FindControl("BillNumberTxt") as TextBox;
                TextBox BillDateTxt = BillLV.EditItem.FindControl("BillDateTxt") as TextBox;
                TextBox SanctionFileNoTxt = BillLV.EditItem.FindControl("SanctionFileNoTxt") as TextBox;
                TextBox SanctionFileDate = BillLV.EditItem.FindControl("SanctionFileDate") as TextBox;
                TextBox TotalAmountTxt = BillLV.EditItem.FindControl("TotalAmountTxt") as TextBox;
                Label IncomeTaxTxt = BillLV.EditItem.FindControl("IncomeTaxTxt") as Label;
                Label GstTxt = BillLV.EditItem.FindControl("GstTxt") as Label;
                //TextBox TokenNumberTxt = BillLV.EditItem.FindControl("TokenNumberTxt") as TextBox;
                //TextBox ChequeNumberTxt = BillLV.EditItem.FindControl("ChequeNumberTxt") as TextBox;
                //TextBox ChequeDateTxt = BillLV.EditItem.FindControl("ChequeDateTxt") as TextBox;
                //TextBox RemarksTxt = BillLV.EditItem.FindControl("RemarksTxt") as TextBox;
                TextBox StockRegisterTxt = BillLV.EditItem.FindControl("StockRegisterTxt") as TextBox;

                eh.BillTypeId = 1;
                eh.FinancialYearId = FinancialYearId;
                eh.BranchId = BranchId;
                eh.BillStatusId = BillStatusid;
                eh.BillId = Convert.ToInt32(BillId.Value);
                eh.HeadOfAccountId = Convert.ToInt32(HidHOAId.Value);
                eh.VendorId = Convert.ToInt32(HidVendorId.Value);
                eh.VendorName = Convert.ToString(VendorNameTxt.Text);
                eh.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
                eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
                eh.BillNumber = Convert.ToString(BillNumberTxt.Text);
                eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);

                if (!String.IsNullOrEmpty(BillDateTxt.Text))
                {
                    eh.BillDate = Convert.ToDateTime(BillDateTxt.Text);
                    eh.GeneratedOn = Convert.ToDateTime(BillDateTxt.Text);
                }
                else
                    eh.GeneratedOn = DateTime.Now;
                eh.SanctionFileNumber = Convert.ToString(SanctionFileNoTxt.Text);
                if (!String.IsNullOrEmpty(SanctionFileDate.Text))
                    eh.SanctionFileDate = Convert.ToDateTime(SanctionFileDate.Text);
                eh.TotalAmount = Convert.ToDouble(TotalAmountTxt.Text);
                eh.IncomeTax = Convert.ToDouble(IncomeTaxTxt.Text);
                eh.Gst = Convert.ToDouble(GstTxt.Text);
                eh.NetAmount = eh.TotalAmount - eh.Gst - eh.IncomeTax;
                eh.StockRegisterDetails = Convert.ToString(StockRegisterTxt.Text);

                if (!string.IsNullOrEmpty(eh.SanctionFileNumber))
                    eh.BillStatusId = 2;
                //  eh.TokenNumber = Convert.ToString(TokenNumberTxt.Text);
                //   eh.ChequeNumber = Convert.ToString(ChequeNumberTxt.Text);
                //   if (!String.IsNullOrEmpty(ChequeDateTxt.Text))
                //      eh.ChequeDate = Convert.ToDateTime(ChequeDateTxt.Text);
                //  eh.Remarks = Convert.ToString(RemarksTxt.Text);
                HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(eh.HeadOfAccountId, FinancialYearId);
                if (eh.TotalAmount > hoa.RemainingBalance)
                {
                    error.Text = "Amount exceeded from current budget";
                }
                else
                {
                    new BudgetBiz().UpdateBill(eh);
                    BillLV.EditIndex = -1;
                    BillLV.InsertItemPosition = InsertItemPosition.None;
                    BillLV.SelectedIndex = -1;
                    e.Cancel = true;
                    BindBillLV();
                }
            }

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


        protected void Button1_Click(object sender, EventArgs e)
        {
            BillLV.SelectedIndex = -1;
            BillLV.EditIndex = -1;
            BillLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindBillLV();
        }

        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void GetBills()
        {
            int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);

            string query = "  SELECT BUD_BILL.BILL_ID, BUD_BILL.BRANCH_ID, BUD_BILL.FINANCIAL_YEAR_ID, BUD_BILL.VENDOR_ID, BUD_BILL.BILL_TYPE_ID, BUD_BILL.BILL_STATUS_ID, BUD_BILL.BILL_SUBJECT, BUD_BILL.BILL_NUMBER, ";
            query += " BUD_BILL.BILL_DATE, BUD_BILL.SANCTION_FILE_NO, BUD_BILL.SANCTION_DATE, BUD_BILL.HEAD_OF_ACCOUNT_ID, BUD_BILL.VENDOR_NUMBER, BUD_BILL.TOTAL_AMOUNT, BUD_BILL.INCOME_TAX, BUD_BILL.GST, ";
            query += " BUD_BILL.NET_AMOUNT, BUD_BILL.STOCK_REGISTER_DETAILS, BUD_BILL.CHEQUE_NUMBER, BUD_BILL.CHEQUE_DATE, BUD_BILL.TOKEN_NUMBER, BUD_BILL.REMARKS, BUD_BILL.GENERATED_BY, ";
            query += " BUD_VENDORS.VENDOR, BRANCHES.DESCRIPTION, BUD_BILL_TYPES.BILL_TYPE, BUD_VENDORS.VENDOR_NUMBER AS VEN_VENDOR_NUMBER, BUD_HEAD_OF_ACCOUNTS.HEAD_OF_ACCOUNT, ";
            query += " BUD_BILL.BILL_STATUS_ID AS Expr1, BUD_BILL.ENTRY_DATE, BUD_BILL_STATUSES.BILL_STATUS, BUD_BILL_STATUSES.BUDGET_EFFECT, EMPLOYEE_POOLS.SHORT ";
            query += " FROM            BUD_BILL INNER JOIN ";
            query += " BUD_VENDORS ON BUD_BILL.VENDOR_ID = BUD_VENDORS.VENDOR_ID INNER JOIN ";
            query += " BRANCHES ON BUD_BILL.BRANCH_ID = BRANCHES.BRANCHES_ID INNER JOIN ";
            query += " BUD_BILL_TYPES ON BUD_BILL.BILL_TYPE_ID = BUD_BILL_TYPES.BILL_TYPE_ID INNER JOIN ";
            query += " BUD_HEAD_OF_ACCOUNTS ON BUD_BILL.HEAD_OF_ACCOUNT_ID = BUD_HEAD_OF_ACCOUNTS.HEAD_OF_ACCOUNT_ID INNER JOIN ";
            query += " BUD_BILL_STATUSES ON BUD_BILL.BILL_STATUS_ID = BUD_BILL_STATUSES.BILL_STATUS_ID INNER JOIN ";
            query += " BUD_MINOR_OBJECTS ON BUD_HEAD_OF_ACCOUNTS.MINOR_OBJECT_ID = BUD_MINOR_OBJECTS.MINOR_OBJECT_ID INNER JOIN ";
            query += " BUD_MAJOR_OBJECTS ON BUD_MINOR_OBJECTS.MAJOR_OBJECT_ID = BUD_MAJOR_OBJECTS.MAJOR_OBJECT_ID INNER JOIN ";
            query += " EMPLOYEE_POOLS ON BUD_MAJOR_OBJECTS.POOL_ID = EMPLOYEE_POOLS.EMPLOYEE_POOLS_ID ";
            query += " WHERE BUD_BILL.BRANCH_ID=" + 13 + "AND  BUD_BILL.FINANCIAL_YEAR_ID =" + FinancialYearDDL.SelectedValue;
            if (HeadOfAccountDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.HEAD_OF_ACCOUNT_ID=" + HeadOfAccountDDL.SelectedItem.Value;

            }
            if (StatusDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.BILL_STATUS_ID=" + StatusDDL.SelectedItem.Value;
            }

            query += " ORDER BY BILL_ID DESC,SANCTION_DATE DESC";
            List<Bills> bills = new BudgetBiz().GetBranchFinancialYearsBills(query);
            BillLV.DataSource = bills;
            BillLV.DataBind();
        }

        protected void HeadOfAccountDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBills();
        }

        protected void UpdateSanctionBtn_Click(object sender, EventArgs e)
        {
            HiddenField BillStatusId = BillLV.EditItem.FindControl("HidBillStatusId") as HiddenField;
            int BillStatusid = Convert.ToInt32(BillStatusId.Value);
            if (BillStatusid <= 2)
            {
                Bills eh = new Bills();
                int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                HiddenField BillId = BillLV.EditItem.FindControl("HidBillId") as HiddenField;
                TextBox SanctionFileNoTxt = BillLV.EditItem.FindControl("SanctionFileNoTxt") as TextBox;
                TextBox SanctionFileDate = BillLV.EditItem.FindControl("SanctionFileDate") as TextBox;
                eh.BillStatusId = 2;
                eh.BillId = Convert.ToInt32(BillId.Value);
                eh.SanctionFileNumber = Convert.ToString(SanctionFileNoTxt.Text);
                eh.SanctionFileDate = Convert.ToDateTime(SanctionFileDate.Text);
                new BudgetBiz().UpdateBillSanction(eh);
                BillLV.EditIndex = -1;
                BillLV.InsertItemPosition = InsertItemPosition.None;
                BillLV.SelectedIndex = -1;
                BindBillLV();
            }
            else
                error.Text = "Can not update bill. Bill is processed by Accounts branch";
        }

        protected void UpdateBillBtn_Click(object sender, EventArgs e)
        {
            HiddenField BillStatusId = BillLV.EditItem.FindControl("HidBillStatusId") as HiddenField;
            int BillStatusid = Convert.ToInt32(BillStatusId.Value);
            if (BillStatusid <= 2)
            {
                Bills eh = new Bills();
                int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                DropDownList HOADDL = BillLV.EditItem.FindControl("HeadOfAccountDDL") as DropDownList;
                TextBox VendorNameTxt = BillLV.EditItem.FindControl("VendorNameTxt") as TextBox;
                HiddenField HidVendorId = BillLV.EditItem.FindControl("HidVendorId") as HiddenField;
                HiddenField BillId = BillLV.EditItem.FindControl("HidBillId") as HiddenField;
                TextBox VendorNumberTxt = BillLV.EditItem.FindControl("VendorNumberTxt") as TextBox;
                TextBox BillDetailsTxt = BillLV.EditItem.FindControl("BillDetailsTxt") as TextBox;
                TextBox BillNumberTxt = BillLV.EditItem.FindControl("BillNumberTxt") as TextBox;
                TextBox BillDateTxt = BillLV.EditItem.FindControl("BillDateTxt") as TextBox;
                TextBox TotalAmountTxt = BillLV.EditItem.FindControl("TotalAmountTxt") as TextBox;
                Label IncomeTaxTxt = BillLV.EditItem.FindControl("IncomeTaxTxt") as Label;
                Label GstTxt = BillLV.EditItem.FindControl("GstTxt") as Label;
                TextBox StockRegisterTxt = BillLV.EditItem.FindControl("StockRegisterTxt") as TextBox;
                eh.BillTypeId = 1;
                eh.FinancialYearId = FinancialYearId;
                eh.BranchId = BranchId;
                eh.BillStatusId = BillStatusid;
                eh.BillId = Convert.ToInt32(BillId.Value);
                eh.HeadOfAccountId = Convert.ToInt32(HOADDL.SelectedValue);
                eh.VendorId = Convert.ToInt32(HidVendorId.Value);
                eh.VendorName = Convert.ToString(VendorNameTxt.Text);
                eh.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
                eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
                eh.BillNumber = Convert.ToString(BillNumberTxt.Text);
                eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
                if (!String.IsNullOrEmpty(BillDateTxt.Text))
                {
                    eh.BillDate = Convert.ToDateTime(BillDateTxt.Text);
                    eh.GeneratedOn = Convert.ToDateTime(BillDateTxt.Text);
                }
                else
                    eh.GeneratedOn = DateTime.Now;
                eh.TotalAmount = Convert.ToDouble(TotalAmountTxt.Text);
                eh.IncomeTax = Convert.ToDouble(IncomeTaxTxt.Text);
                eh.Gst = Convert.ToDouble(GstTxt.Text);
                eh.NetAmount = eh.TotalAmount - eh.Gst - eh.IncomeTax;
                eh.StockRegisterDetails = Convert.ToString(StockRegisterTxt.Text);
                HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(eh.HeadOfAccountId, FinancialYearId);
                if (eh.TotalAmount > hoa.RemainingBalance)
                {
                    error.Text = "Amount exceeded from current budget";
                }
                else
                {
                    new BudgetBiz().UpdateBill(eh);
                    BillLV.EditIndex = -1;
                    BillLV.InsertItemPosition = InsertItemPosition.None;
                    BillLV.SelectedIndex = -1;
                    BindBillLV();
                }
            }

        }
        protected void StatusDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBills();
        }
    }
}