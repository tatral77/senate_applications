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
    public partial class ManageMemberBankAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
                Member mem = new FinBIZ().GetMemberById(MemberId);
                header.Text = mem.MemberName.ToUpper();
                BindVistLV();
             
            }

        }
        protected void BindVistLV()
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            List<MemberBankAccounts> sal = new FinBIZ().GetMemberBankAccounts(MemberId);
            LV.DataSource = sal;
            LV.DataBind();

        }
        protected string GetLink(int MemberId)
        {
            return "~/ManageMemberBankAccounts.aspx?Id=" + MemberId;
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox BankName = (TextBox)LV.InsertItem.FindControl("BankNameTxt");
            TextBox AccountNumber = (TextBox)LV.InsertItem.FindControl("AccountNumberTxt");
            CheckBox IsSalaried = (CheckBox)LV.InsertItem.FindControl("IsSalariedCB");
            MemberBankAccounts bh = new MemberBankAccounts();
            bh.MemberId = MemberId;
            bh.BankName = Convert.ToString(BankName.Text);
            bh.AccountNumber = Convert.ToString(AccountNumber.Text);
            bh.IsSalaried = (IsSalaried.Checked == true) ? 1 : 0;
            new FinBIZ().InsertMemberBankAccount(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindVistLV();
            e.Cancel = true;

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int MemberId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField BankAccountId = (HiddenField)LV.EditItem.FindControl("HidMemberBankAccountId");
            TextBox BankName = (TextBox)LV.EditItem.FindControl("BankNameTxt");
            TextBox AccountNumber = (TextBox)LV.EditItem.FindControl("AccountNumberTxt");
            CheckBox IsSalaried = (CheckBox)LV.EditItem.FindControl("IsSalariedCB");
            MemberBankAccounts bh = new MemberBankAccounts();
            bh.MemberId = MemberId;
            bh.MemberBankAccountId = Convert.ToInt32(BankAccountId.Value);
            bh.BankName = Convert.ToString(BankName.Text);
            bh.AccountNumber = Convert.ToString(AccountNumber.Text);
            bh.IsSalaried = (IsSalaried.Checked == true) ? 1 : 0;
            new FinBIZ().UpdateMemberBankAccount(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindVistLV();
            e.Cancel = true;
            Response.Redirect("~/ManageMemberBankAccounts.aspx?Id=" + MemberId);

        }
        protected void AllowanceItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField BankAccountId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidMemberBankAccountId");
            int AccId = Convert.ToInt32(BankAccountId.Value);
            new FinBIZ().DeleteMemberBankAccount(AccId);
            BindVistLV();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindVistLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            BindVistLV();
            e.Cancel = true;


        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            BindVistLV();
            e.Cancel = true;
        }
        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
    }
}