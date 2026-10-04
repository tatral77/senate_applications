using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUDBIZ;
using BUDENTITIES;

namespace Finance
{
    public partial class ManageBillDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDetailLv();
                BindDeductionLv();
            }
        }
        protected void BindDetailLv()
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillId"]);
            List<BillDetails> det = new BudgetBiz().GetBillDetailsByBillId(BillId);
            CategoryLV.DataSource = det;
            CategoryLV.DataBind();
        }
        protected void BindDeductionLv()
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillId"]);
            List<BillDeductions> sal = new BudgetBiz().GetBillDeductionsByBillId(BillId);
            DeductionLV.DataSource = sal;
            DeductionLV.DataBind();
        }
        protected void DeductionLV_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            DeductionLV.EditIndex = -1;
            DeductionLV.InsertItemPosition = InsertItemPosition.None;
            DeductionLV.SelectedIndex = -1;
            BindDeductionLv();
            e.Cancel = true;
        }

        protected void DeductionLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidBillDeductionId = (HiddenField)DeductionLV.Items[e.ItemIndex].FindControl("HidBillDeductionId");
            int Id = Convert.ToInt32(HidBillDeductionId.Value);
            new BudgetBiz().DeleteBillDeduction(Id);
            BindDeductionLv();
        }

        protected void DeductionLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            DeductionLV.InsertItemPosition = InsertItemPosition.None;
            DeductionLV.SelectedIndex = -1;
            DeductionLV.EditIndex = e.NewEditIndex;
            BindDeductionLv();
            e.Cancel = true;
        }

        protected void DeductionLV_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillId"]);
            TextBox Amount = (TextBox)DeductionLV.InsertItem.FindControl("AmountTxt");
            TextBox DeductionDetailTxt = (TextBox)DeductionLV.InsertItem.FindControl("DeductionDetailTxt");
            BillDeductions bh = new BillDeductions();
            bh.BillId = BillId;
            bh.Amount = Convert.ToDouble(Amount.Text);
            bh.DeductionDetail = Convert.ToString(DeductionDetailTxt.Text);
            new BudgetBiz().InsertBillDeduction(bh);
            DeductionLV.EditIndex = -1;
            DeductionLV.InsertItemPosition = InsertItemPosition.None;
            BindDeductionLv();
            e.Cancel = true;
        }

        protected void DeductionLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }

        protected void CategoryLV_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            CategoryLV.SelectedIndex = -1;
            BindDetailLv();
            e.Cancel = true;
        }

        protected void CategoryLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidBillDetailId = (HiddenField)CategoryLV.Items[e.ItemIndex].FindControl("HidBillDetailId");
            int Id = Convert.ToInt32(HidBillDetailId.Value);
            new BudgetBiz().DeleteBillDetail(Id);
            BindDetailLv();
        }

        protected void CategoryLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            CategoryLV.SelectedIndex = -1;
            CategoryLV.EditIndex = e.NewEditIndex;
            BindDetailLv();
            e.Cancel = true;
        }

        protected void CategoryLV_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillId"]);
            TextBox Amount = (TextBox)CategoryLV.InsertItem.FindControl("AmountTxt");
            DropDownList CategoryDDL = (DropDownList)CategoryLV.InsertItem.FindControl("CategoryDDL");
            BillDetails bh = new BillDetails();
            bh.BillId = BillId;
            bh.Amount = Convert.ToDouble(Amount.Text);
            bh.CategoryId = Convert.ToInt32(CategoryDDL.SelectedValue);
            new BudgetBiz().InsertBillDetail(bh);
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            BindDetailLv();
            e.Cancel = true;
        }

        protected void CategoryLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }

        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            //int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
            List<BillCategories> cy = new BudgetBiz().GetBillCategories();
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("CategoryDDL") as DropDownList);
            if (ddl != null)
            {
                foreach (BillCategories row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.BillCategoryId.ToString();
                    ty.Text = row.BillCategory.ToString();
                    ddl.Items.Add(ty);
                }

            }
        }

        protected void CategoryLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (CategoryLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList CategoryDDL = e.Item.FindControl("CategoryDDL") as DropDownList;
                HiddenField HidCategoryId = (e.Item.FindControl("HidCategoryId") as HiddenField);
                CategoryDDL.SelectedValue = HidCategoryId.Value.ToString();
            }
        }

        protected void NewDetailBtn_Click(object sender, EventArgs e)
        {
            CategoryLV.SelectedIndex = -1;
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDetailLv();
        }

        protected void NewDeductionBtn_Click(object sender, EventArgs e)
        {
            DeductionLV.SelectedIndex = -1;
            DeductionLV.EditIndex = -1;
            DeductionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDeductionLv();
        }
    }
}