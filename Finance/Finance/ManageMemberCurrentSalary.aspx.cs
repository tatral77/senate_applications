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
    public partial class ManageMemberCurrentSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
                Member mem = new FinBIZ().GetMemberById(MemberId);
                header.Text = mem.MemberName.ToUpper();
                BindAllowancesLV();
                BindDeductionsLV();
            }

        }
        protected void BindAllowancesLV()
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            List<CurrentAllowance> structureAllowances = new FinBIZ().GetMemberCurrentAllowances(MemberId);
            AllowancesLV.DataSource = structureAllowances;
            AllowancesLV.DataBind();
        }
        protected void BindDeductionsLV()
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            List<CurrentDeduction> structureDeductions = new FinBIZ().GetMemberCurrentDeductions(MemberId);
            DeductionsLV.DataSource = structureDeductions;
            DeductionsLV.DataBind();
        }
        protected void AllowanceItemEditing(object sender, ListViewEditEventArgs e)
        {
            AllowancesLV.InsertItemPosition = InsertItemPosition.None;
            AllowancesLV.SelectedIndex = -1;
            AllowancesLV.EditIndex = e.NewEditIndex;
            BindAllowancesLV();
            e.Cancel = true;


        }
        protected void DeductionItemEditing(object sender, ListViewEditEventArgs e)
        {
            DeductionsLV.InsertItemPosition = InsertItemPosition.None;
            DeductionsLV.SelectedIndex = -1;
            DeductionsLV.EditIndex = e.NewEditIndex;
            BindDeductionsLV();
            e.Cancel = true;


        }
        protected void AllowanceItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            AllowancesLV.EditIndex = -1;
            AllowancesLV.InsertItemPosition = InsertItemPosition.None;
            AllowancesLV.SelectedIndex = -1;
            BindAllowancesLV();
            e.Cancel = true;
        }
        protected void DeductionItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            DeductionsLV.EditIndex = -1;
            DeductionsLV.InsertItemPosition = InsertItemPosition.None;
            DeductionsLV.SelectedIndex = -1;
            BindDeductionsLV();
            e.Cancel = true;
        }


        protected void AllowanceItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (AllowancesLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList AllowanceDDL = e.Item.FindControl("AllowanceDDL") as DropDownList;
                HiddenField AllowanceId = (e.Item.FindControl("HidAllowanceId") as HiddenField);
                AllowanceDDL.SelectedValue = AllowanceId.Value.ToString();

            }

        }
        protected void DeductionItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (DeductionsLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList DeductionDDL = e.Item.FindControl("DeductionDDL") as DropDownList;
                HiddenField deductionId = (e.Item.FindControl("HidDeductionId") as HiddenField);
                DeductionDDL.SelectedValue = deductionId.Value.ToString();

            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
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
            List<Deductions> dy = new FinBIZ().GetDeductions();
            DropDownList dddl = new DropDownList();
            dddl = (e.Item.FindControl("DeductionDDL") as DropDownList);
            if (dddl != null)
            {
                foreach (Deductions row2 in dy)
                {
                    ListItem dty = new ListItem();
                    dty.Value = row2.DeductionId.ToString();
                    dty.Text = row2.DeductionDesc.ToString();
                    dddl.Items.Add(dty);
                }

            }
        }
        protected void AllowanceItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox Amount = (TextBox)AllowancesLV.InsertItem.FindControl("AmountTxt");
            DropDownList AllowanceId = (DropDownList)AllowancesLV.InsertItem.FindControl("AllowanceDDL");
            CurrentAllowance b = new CurrentAllowance();
            b.MemberId = MemberId;
            b.Amount = Convert.ToDouble(Amount.Text);
            b.AllowanceId = Convert.ToInt32(AllowanceId.SelectedItem.Value);
            b.IsStructured = 0;
            new FinBIZ().InsertCurrentAllowance(b);
            AllowancesLV.EditIndex = -1;
            AllowancesLV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;
            Response.Redirect("ManageMemberCurrentSalary.aspx?Id=" + MemberId);
        }
        protected void AllowanceItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField CurrentAllowanceId = (HiddenField)AllowancesLV.EditItem.FindControl("HidCurrentAllowanceId");
            TextBox Amount = (TextBox)AllowancesLV.EditItem.FindControl("AmountTxt");
            DropDownList AllowanceId = (DropDownList)AllowancesLV.EditItem.FindControl("AllowanceDDL");
            CurrentAllowance b = new CurrentAllowance();
            b.CurrentAllowanceId = Convert.ToInt32(CurrentAllowanceId.Value);
            b.MemberId = MemberId;
            b.Amount = Convert.ToDouble(Amount.Text);
            b.AllowanceId = Convert.ToInt32(AllowanceId.SelectedItem.Value);
            new FinBIZ().UpdateMemberCurrentAllowance(b);
            AllowancesLV.EditIndex = -1;
            AllowancesLV.InsertItemPosition = InsertItemPosition.None;
            BindAllowancesLV();
            e.Cancel = true;
        }
        protected void AllowanceItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField AllowId = (HiddenField)AllowancesLV.Items[e.ItemIndex].FindControl("HidCurrentAllowanceId");
            int AllowanceId = Convert.ToInt32(AllowId.Value);
            new FinBIZ().DeleteCurrentAllowance(AllowanceId);
            BindAllowancesLV();
        }

        protected void DeductionItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox Amount = (TextBox)DeductionsLV.InsertItem.FindControl("AmountTxt");
            DropDownList DeductionId = (DropDownList)DeductionsLV.InsertItem.FindControl("DeductionDDL");
            CurrentDeduction b = new CurrentDeduction();
            b.MemberId = MemberId;
            b.Amount = Convert.ToDouble(Amount.Text);
            b.DeductionId = Convert.ToInt32(DeductionId.SelectedItem.Value);
            b.IsStructured = 0;
            new FinBIZ().InsertCurrentDeduction(b);
            DeductionsLV.EditIndex = -1;
            DeductionsLV.InsertItemPosition = InsertItemPosition.None;
            BindDeductionsLV();
            e.Cancel = true;
           // Response.Redirect("StructureDetails.aspx?Id=" + StructureId);
        }
        protected void DeductionItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField CurrentDeductionId = (HiddenField)DeductionsLV.EditItem.FindControl("HidCurrentDeductionId");
            TextBox Amount = (TextBox)DeductionsLV.EditItem.FindControl("AmountTxt");
            DropDownList DeductionId = (DropDownList)DeductionsLV.EditItem.FindControl("DeductionDDL");
            CurrentDeduction b = new CurrentDeduction();
            b.CurrentDeductionId = Convert.ToInt32(CurrentDeductionId.Value);
            b.MemberId = MemberId;
            b.Amount = Convert.ToDouble(Amount.Text);
            b.DeductionId = Convert.ToInt32(DeductionId.SelectedItem.Value);
            new FinBIZ().UpdateMemberCurrentDeduction(b);
            DeductionsLV.EditIndex = -1;
            DeductionsLV.InsertItemPosition = InsertItemPosition.None;
            BindDeductionsLV();
            e.Cancel = true;
        }
        protected void DeductionItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField AllowId = (HiddenField)DeductionsLV.Items[e.ItemIndex].FindControl("HidCurrentDeductionId");
            int CurrentDeductionId = Convert.ToInt32(AllowId.Value);
            new FinBIZ().DeleteCurrentDeduction(CurrentDeductionId);
            BindDeductionsLV();
        }


        protected void AddAllowanceBtn_Click(object sender, EventArgs e)
        {
            AllowancesLV.SelectedIndex = -1;
            AllowancesLV.EditIndex = -1;
            AllowancesLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindAllowancesLV();

        }

        protected void AddDeductionBtn_Click(object sender, EventArgs e)
        {
            DeductionsLV.SelectedIndex = -1;
            DeductionsLV.EditIndex = -1;
            DeductionsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindDeductionsLV();

        }
    }
}