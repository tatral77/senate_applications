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
    public partial class ManageStructureMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int StructureId = Convert.ToInt32(Request.QueryString["Id"]);
                SalaryStructure sal = new FinBIZ().GetSalaryStructure(StructureId);
                header.Text = sal.Description.ToUpper();
                BindVistLV();
                 //List<FinancialYears> fys = new BudgetBiz().GetFinancialYears();
                 //   if (fys != null)
                 //   {
                 //       foreach (FinancialYears row in fys)
                 //       {
                 //           ListItem li = new ListItem();
                 //           li.Text = row.FinancialYear;
                 //           li.Value = row.FinancialYearId.ToString();
                 //           FinancialYearsDDL.Items.Add(li);
                 //       }

                 //   }
                 //   List<Months> months = new BudgetBiz().GetMonths();
                 //   if (months != null)
                 //   {
                 //       foreach (Months month in months)
                 //       {
                 //           ListItem li = new ListItem();
                 //           li.Text = month.MonthName;
                 //           li.Value = month.MonthId.ToString();
                 //           MonthsDDL.Items.Add(li);
                 //       }

                 //   }
                }
            
        }
        protected void BindVistLV()
        {
            int StructureId = Convert.ToInt32(Request.QueryString["Id"]);
            SalaryStructure salstruct = new FinBIZ().GetSalaryStructure(StructureId);
            List<Member> Eq = new FinBIZ().GetMembersByCategory(salstruct.MemberSalCategoryId);
            LV.DataSource = Eq;
            LV.DataBind();

        }
        protected string GetLink(int MemberId)
        {
            return "~/ManageMemberCurrentSalary.aspx?Id=" + MemberId;
        }
       
        //protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        //{
        //    TextBox SalaryStructure = (TextBox)LV.InsertItem.FindControl("SalaryStructureTxt");
        //    DropDownList MemSalCategoryDDL = (DropDownList)LV.InsertItem.FindControl("MemSalCategoryDDL");
        //    CheckBox IsCurrent = (CheckBox)LV.InsertItem.FindControl("IsCurrentCB");
        //    SalaryStructure bh = new SalaryStructure();
        //    bh.Description = Convert.ToString(SalaryStructure.Text);
        //    bh.MemberSalCategoryId = Convert.ToInt32(MemSalCategoryDDL.SelectedValue);
        //    bh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
        //    new FinBIZ().InsertSalaryStructure(bh);
        //    LV.EditIndex = -1;
        //    LV.InsertItemPosition = InsertItemPosition.None;
        //    BindVistLV();
        //    e.Cancel = true;
        //    Response.Redirect("ManageSalaryStructure.aspx");

        //}
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField SalaryStructureId = (HiddenField)LV.EditItem.FindControl("HidSalaryStructureId");
            HiddenField MemberId = (HiddenField)LV.EditItem.FindControl("HidMemberId");
            DropDownList MemSalCategoryDDL = (DropDownList)LV.EditItem.FindControl("MemSalCategoryDDL");
            CheckBox SalaryStatus = (CheckBox)LV.EditItem.FindControl("SalaryStatusCB");
            Member bh = new Member();
            bh.MemberId = Convert.ToInt32(MemberId.Value);
            bh.MemberSalCategoryId = Convert.ToInt32(MemSalCategoryDDL.SelectedItem.Value);
            bh.SalaryStatus = (SalaryStatus.Checked == true) ? 1 : 0;
            new FinBIZ().UpdateMemberSalaryStatus(bh.MemberId, bh.MemberSalCategoryId, bh.SalaryStatus);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindVistLV();
            e.Cancel = true;
            Response.Redirect("ManageMembers.aspx");

        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    LV.SelectedIndex = -1;
        //    LV.EditIndex = -1;
        //    LV.InsertItemPosition = InsertItemPosition.FirstItem;
        //    BindVistLV();

        //}
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


        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList DDL = e.Item.FindControl("MemSalCategoryDDL") as DropDownList;
                HiddenField Id = (e.Item.FindControl("HidMemberSalCategoryId") as HiddenField);
                DDL.SelectedValue = Id.Value.ToString();
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
            List<MemberSalCategories> cy = new FinBIZ().GetMemberSalCategories();
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("MemSalCategoryDDL") as DropDownList);
            if (ddl != null)
            {
                foreach (MemberSalCategories row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.MemberSalCategoryId.ToString();
                    ty.Text = row.MemberSalCategory.ToString();
                    ddl.Items.Add(ty);
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int StructureId = Convert.ToInt32(Request.QueryString["Id"]);
            // HiddenField ddl = (LV.Items.FindControl("SalCategoryDDL") as HiddenField);
            new FinBIZ().AssignStructureToMembers(StructureId);
        }

        //protected void PrintSlipBtn_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int MemberId = Convert.ToInt32(btn.CommandArgument);
        //    int fy = 2;// Convert.ToInt32(FinancialYearsDDL.SelectedValue);
        //    int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
        //    Response.Redirect("~/SalarySlip.aspx?MemId=" + MemberId + "&FY=" + fy + "&Mon=" + mon);
        //}
     
    }
}