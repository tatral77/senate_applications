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
    public partial class BranchBills : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                List<Branch> branch = new BudgetBiz().GetBudgetBranches();
                if (branch != null)
                {
                    foreach (Branch row in branch)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.Description;
                        li.Value = row.Branchid.ToString();
                        BranchDDL.Items.Add(li);
                    }
                }
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
                List<BillStatus> BillStatuses = new BudgetBiz().GetBillStatuses();
                if (BillStatuses != null)
                {
                    foreach (BillStatus row in BillStatuses)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.Description;
                        li.Value = row.BillStatusId.ToString();
                        StatusDDL.Items.Add(li);
                    }
                }
                GetBranchBills();
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
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            int FinancialYearsId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            DropDownList HOADDL = new DropDownList();
            HOADDL = (e.Item.FindControl("HeadOfAccountDDL") as DropDownList);
            if (HOADDL != null)
            {
                List<BranchHead> branch = new BudgetBiz().GetBranchHeads(Convert.ToInt32(BranchDDL.SelectedValue),FinancialYearsId);
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
            int hoa = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            HeadOfAccountBudget hoabud = new BudgetBiz().GetHeadOfAccountBudget(hoa, FinancialYearsId);
            RangeValidator rv = new RangeValidator();
            rv = (e.Item.FindControl("RangeValidator1") as RangeValidator);
            if(rv!=null)
            rv.MaximumValue = hoabud.RemainingBalance.ToString();

        }
    

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            Bills eh = new Bills();
            int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int HeadOfAccountId = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(HeadOfAccountId, FinancialYearId);
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
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
            eh.BillTypeId = 1;
            eh.FinancialYearId = FinancialYearId;
            eh.HeadOfAccountId = HeadOfAccountId;
            eh.BranchId = BranchId;
            eh.VendorId = Convert.ToInt32(HidVendorId.Value);
            eh.VendorName = Convert.ToString(VendorNameTxt.Text);
            eh.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
            eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
            eh.BillNumber = Convert.ToString(BillNumberTxt.Text);
            eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
            eh.BillDate = Convert.ToDateTime(BillDateTxt.Text);
            eh.TotalAmount = Convert.ToDouble(TotalAmountTxt.Text);
            eh.BillStatusId = 1;
            //eh.IncomeTax = Convert.ToDouble(IncomeTaxTxt.Text);
            //eh.Gst = Convert.ToDouble(GstTxt.Text);
            //eh.TokenNumber = Convert.ToString(TokenNumberTxt.Text);
            //eh.ChequeNumber = Convert.ToString(ChequeNumberTxt.Text);
            eh.GeneratedBy = 1;
            //if (!String.IsNullOrEmpty(ChequeDateTxt.Text))
            //    eh.ChequeDate = Convert.ToDateTime(ChequeDateTxt.Text);
            // eh.Remarks = Convert.ToString(RemarksTxt.Text);
            if (eh.TotalAmount > hoa.RemainingBalance)
            {
                error.Text = "Amount exceeded from current budget";
            }
            else
            {
             
                    error.Text = "";
                    int Id = new BudgetBiz().InsertBill(eh);
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('BILL ID " + Id + "')", true);
                    BillLV.EditIndex = -1;
                    BillLV.InsertItemPosition = InsertItemPosition.None;
                    BillLV.SelectedIndex = -1;
                    e.Cancel = true;
                    BindBillLV();
                    //Response.Redirect("~/BranchBills.aspx?FY=" + FinancialYearId + "&HOA=" + HeadOfAccountId + "&BID=" + BranchId);


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
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField BillStatusId = BillLV.EditItem.FindControl("HidBillStatusId") as HiddenField;
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            //int headofaccount = Convert.ToInt32(HeadOfAccountDDL.SelectedValue);
            int BillStatusid = Convert.ToInt32(BillStatusId.Value);
            if (BillStatusid > 1 )
            {
                Bills eh = new Bills();
                int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
                DropDownList HOADDL = BillLV.EditItem.FindControl("HeadOfAccountDDL") as DropDownList;
               // TextBox VendorNameTxt = BillLV.EditItem.FindControl("VendorNameTxt") as TextBox;
                HiddenField HidVendorId = BillLV.EditItem.FindControl("HidVendorId") as HiddenField;
                HiddenField BillId = BillLV.EditItem.FindControl("HidBillId") as HiddenField;
               // TextBox VendorNumberTxt = BillLV.EditItem.FindControl("VendorNumberTxt") as TextBox;
              //  TextBox BillDetailsTxt = BillLV.EditItem.FindControl("BillDetailsTxt") as TextBox;
              //  TextBox BillNumberTxt = BillLV.EditItem.FindControl("BillNumberTxt") as TextBox;
              //  TextBox BillDateTxt = BillLV.EditItem.FindControl("BillDateTxt") as TextBox;
               // TextBox SanctionFileNoTxt = BillLV.EditItem.FindControl("SanctionFileNoTxt") as TextBox;
              //  TextBox SanctionFileDate = BillLV.EditItem.FindControl("SanctionFileDate") as TextBox;
                Label TotalAmountTxt = BillLV.EditItem.FindControl("TotalAmountTxt") as Label;
                TextBox IncomeTaxTxt = BillLV.EditItem.FindControl("IncomeTaxTxt") as TextBox;
                TextBox GstTxt = BillLV.EditItem.FindControl("GstTxt") as TextBox;
                TextBox TokenNumberTxt = BillLV.EditItem.FindControl("TokenNumberTxt") as TextBox;
                TextBox ChequeNumberTxt = BillLV.EditItem.FindControl("ChequeNumberTxt") as TextBox;
                TextBox ChequeDateTxt = BillLV.EditItem.FindControl("ChequeDateTxt") as TextBox;
                TextBox RemarksTxt = BillLV.EditItem.FindControl("RemarksTxt") as TextBox;
                TextBox StockRegisterTxt = BillLV.EditItem.FindControl("StockRegisterTxt") as TextBox;
                eh.BillTypeId = 1;
                //eh.FinancialYearId = FinancialYearId;
                //  eh.BranchId = BranchId;
                if (!String.IsNullOrEmpty(ChequeNumberTxt.Text))
                    eh.BillStatusId = 4;
                else
                    eh.BillStatusId =Convert.ToInt32(BillStatusId.Value);
                eh.BillId = Convert.ToInt32(BillId.Value);
              //  eh.HeadOfAccountId = Convert.ToInt32(HOADDL.SelectedValue);
                //  eh.VendorId = Convert.ToInt32(HidVendorId.Value);
                //  eh.VendorName = Convert.ToString(VendorNameTxt.Text);
                //  eh.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
               // eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
               // eh.BillNumber = Convert.ToString(BillNumberTxt.Text);
              //  eh.BillDescription = Convert.ToString(BillDetailsTxt.Text);
               // eh.BillDate = Convert.ToDateTime(BillDateTxt.Text);
              //  eh.SanctionFileNumber = Convert.ToString(SanctionFileNoTxt.Text);
              //  if (!String.IsNullOrEmpty(SanctionFileDate.Text))
               //     eh.SanctionFileDate = Convert.ToDateTime(SanctionFileDate.Text);
                eh.TotalAmount = Convert.ToDouble(TotalAmountTxt.Text);
                eh.IncomeTax = Convert.ToDouble(IncomeTaxTxt.Text);
                eh.Gst = Convert.ToDouble(GstTxt.Text);
                eh.NetAmount = eh.TotalAmount - eh.Gst - eh.IncomeTax;
              //  eh.StockRegisterDetails = Convert.ToString(StockRegisterTxt.Text);

               // if (!string.IsNullOrEmpty(eh.SanctionFileNumber))
                 //   eh.BillStatusId = 2;
                eh.TokenNumber = Convert.ToString(TokenNumberTxt.Text);
                eh.ChequeNumber = Convert.ToString(ChequeNumberTxt.Text);
                if (!String.IsNullOrEmpty(ChequeDateTxt.Text))
                    eh.ChequeDate = Convert.ToDateTime(ChequeDateTxt.Text);
                eh.Remarks = Convert.ToString(RemarksTxt.Text);
               // HeadOfAccountBudget hoa = new BudgetBiz().GetHeadOfAccountBudget(eh.HeadOfAccountId, FinancialYearId);
               // if (eh.TotalAmount > hoa.RemainingBalance)
              //  {
               //     error.Text = "Amount exceeded from current budget";
              //  }
               // else
                
                    error.Text = "";
                    new BudgetBiz().UpdateBillDetails(eh);
                    BillLV.EditIndex = -1;
                    BillLV.InsertItemPosition = InsertItemPosition.None;
                    BillLV.SelectedIndex = -1;
                    e.Cancel = true;
                    BindBillLV();
                

            }
        }

        protected void VisitsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindBillLV();

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField BillId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidBillId");
            HiddenField HidHeadOfAccountId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidHeadOfAccountId");
            HiddenField HidFinancialYearId = (HiddenField)BillLV.Items[e.ItemIndex].FindControl("HidFinancialYearId");
            int billid = Convert.ToInt32(BillId.Value);
            int hoaId = Convert.ToInt32(HidHeadOfAccountId.Value);
            int fyid = Convert.ToInt32(HidFinancialYearId.Value);
            new BudgetBiz().DeleteBill(billid, hoaId, fyid);
            BindBillLV();

        }

    protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(BranchDDL.SelectedValue) == 0 || Convert.ToInt32(HeadOfAccountDDL.SelectedValue) == 0)
                error.Text = "Please select Branch and Head of Account";
            else
            {
                error.Text = "";
                BillLV.SelectedIndex = -1;
                BillLV.EditIndex = -1;
                BillLV.InsertItemPosition = InsertItemPosition.FirstItem;
                BindBillLV();

            }
        }

        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            HeadOfAccountDDL.Items.Clear();
            HeadOfAccountDDL.Items.Add(new ListItem("Select", "0"));
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            int FinancialYearsId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            List<BranchHead> branch = new BudgetBiz().GetBranchHeads(BranchId,FinancialYearsId);
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
            GetBills();
        }
        protected void GetBills()
        {
            int FinancialYearId = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            string query = "  SELECT BUD_BILL.BILL_ID, BUD_BILL.BRANCH_ID, BUD_BILL.FINANCIAL_YEAR_ID, BUD_BILL.VENDOR_ID, BUD_BILL.BILL_TYPE_ID, BUD_BILL.BILL_STATUS_ID, BUD_BILL.BILL_SUBJECT, BUD_BILL.BILL_NUMBER, ";
            query += " BUD_BILL.BILL_DATE, BUD_BILL.SANCTION_FILE_NO, BUD_BILL.SANCTION_DATE, BUD_BILL.HEAD_OF_ACCOUNT_ID, BUD_BILL.VENDOR_NUMBER, BUD_BILL.TOTAL_AMOUNT, BUD_BILL.INCOME_TAX, BUD_BILL.GST, ";
            query += " BUD_BILL.NET_AMOUNT, BUD_BILL.STOCK_REGISTER_DETAILS, BUD_BILL.CHEQUE_NUMBER, BUD_BILL.CHEQUE_DATE, BUD_BILL.TOKEN_NUMBER, BUD_BILL.REMARKS, BUD_BILL.GENERATED_BY, ";
            query += " BUD_VENDORS.VENDOR, BRANCHES.DESCRIPTION AS BRANCH, BUD_BILL_TYPES.BILL_TYPE, BUD_VENDORS.VENDOR_NUMBER AS VEN_VENDOR_NUMBER, BUD_HEAD_OF_ACCOUNTS.HEAD_OF_ACCOUNT, ";
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
            query += " WHERE BUD_BILL.BILL_STATUS_ID>1 AND BUD_BILL.FINANCIAL_YEAR_ID =" + FinancialYearDDL.SelectedValue;
            if (HeadOfAccountDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.HEAD_OF_ACCOUNT_ID=" + HeadOfAccountDDL.SelectedItem.Value;

            }
            if (BranchDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.BRANCH_ID=" + BranchDDL.SelectedItem.Value;

            }
            if (StatusDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.BILL_STATUS_ID=" + StatusDDL.SelectedItem.Value;
            }
            List<Bills> bills = new BudgetBiz().GetBranchFinancialYearsBills(query);
            BillLV.DataSource = bills;
            BillLV.DataBind();
        }
        protected void GetBranchBills()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            int HeadOfAccountId = Convert.ToInt32(Request.QueryString["HOA"]);
            int BranchId = Convert.ToInt32(Request.QueryString["BID"]);
            string query = "  SELECT BUD_BILL.BILL_ID, BUD_BILL.BRANCH_ID, BUD_BILL.FINANCIAL_YEAR_ID, BUD_BILL.VENDOR_ID, BUD_BILL.BILL_TYPE_ID, BUD_BILL.BILL_STATUS_ID, BUD_BILL.BILL_SUBJECT, BUD_BILL.BILL_NUMBER, ";
            query += " BUD_BILL.BILL_DATE, BUD_BILL.SANCTION_FILE_NO, BUD_BILL.SANCTION_DATE, BUD_BILL.HEAD_OF_ACCOUNT_ID, BUD_BILL.VENDOR_NUMBER, BUD_BILL.TOTAL_AMOUNT, BUD_BILL.INCOME_TAX, BUD_BILL.GST, ";
            query += " BUD_BILL.NET_AMOUNT, BUD_BILL.STOCK_REGISTER_DETAILS, BUD_BILL.CHEQUE_NUMBER, BUD_BILL.CHEQUE_DATE, BUD_BILL.TOKEN_NUMBER, BUD_BILL.REMARKS, BUD_BILL.GENERATED_BY, ";
            query += " BUD_VENDORS.VENDOR, BRANCHES.DESCRIPTION AS BRANCH, BUD_BILL_TYPES.BILL_TYPE, BUD_VENDORS.VENDOR_NUMBER AS VEN_VENDOR_NUMBER, BUD_HEAD_OF_ACCOUNTS.HEAD_OF_ACCOUNT, ";
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
            query += " WHERE BUD_BILL.BILL_STATUS_ID>1 AND BUD_BILL.FINANCIAL_YEAR_ID =" + FinancialYearId;
            if (HeadOfAccountId != 0)
            {
                HeadOfAccountDDL.SelectedValue = Convert.ToString(HeadOfAccountId);
                query += " AND BUD_BILL.HEAD_OF_ACCOUNT_ID=" + HeadOfAccountDDL.SelectedItem.Value;

            }
            if (BranchId != 0)
            {
                BranchDDL.SelectedValue = Convert.ToString(BranchId);
                query += " AND BUD_BILL.BRANCH_ID=" + BranchDDL.SelectedItem.Value;

            }
            if (StatusDDL.SelectedItem.Value != "0")
            {
                query += " AND BUD_BILL.BILL_STATUS_ID=" + StatusDDL.SelectedItem.Value;
            }
            List<Bills> bills = new BudgetBiz().GetBranchFinancialYearsBills(query);
            BillLV.DataSource = bills;
            BillLV.DataBind();
        }

        protected void HeadOfAccountDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBills();
        }

        protected void SendToAgprBtn_Click(object sender, EventArgs e)
        {
            ListViewDataItem clickedItem = ((Button)sender).NamingContainer as ListViewDataItem;

            string billid = ((HiddenField)clickedItem.FindControl("HidBillId")).Value;
            new BudgetBiz().SendToAgpr(Convert.ToInt32(billid));
            GetBills();

        }
        protected void StatusDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBills();
        }
    }
}