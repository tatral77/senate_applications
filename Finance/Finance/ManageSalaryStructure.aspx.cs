using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinEntities;
using FinBiz;
using BUDENTITIES;
using BUDBIZ;

namespace Finance
{
    public partial class ManageSalaryStructure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVistLV();
            }
        }
        protected void BindVistLV()
        {
            List<SalaryStructure> Eq = new FinBIZ().GetSalaryStructures();
            LV.DataSource = Eq;
            LV.DataBind();

        }
        protected string GetLink(int StructureId)
        {
            return "~/StructureDetails.aspx?Id=" + StructureId;

        }
        protected string GetLink2(int StructureId)
        {
            return "~/ManageStructureMembers.aspx?Id=" + StructureId;

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox SalaryStructure = (TextBox)LV.InsertItem.FindControl("SalaryStructureTxt");
            DropDownList MemSalCategoryDDL = (DropDownList)LV.InsertItem.FindControl("MemSalCategoryDDL");
            CheckBox IsCurrent = (CheckBox)LV.InsertItem.FindControl("IsCurrentCB");
            DropDownList FundCenterDDL = (DropDownList)LV.InsertItem.FindControl("FundCenterDDL");
            FinancialYears financialYears = new BudgetBiz().GetCurrentFinancialYear();
            SalaryStructure bh = new SalaryStructure();
            bh.Description = Convert.ToString(SalaryStructure.Text);
            bh.MemberSalCategoryId= Convert.ToInt32(MemSalCategoryDDL.SelectedValue);
            bh.FinancialYearId = financialYears.FinancialYearId;
            bh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
            bh.FundCenterId = Convert.ToInt32(FundCenterDDL.SelectedItem.Value);
            new FinBIZ().InsertSalaryStructure(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindVistLV();
            e.Cancel = true;
            Response.Redirect("ManageSalaryStructure.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField SalaryStructureId = (HiddenField)LV.EditItem.FindControl("HidSalaryStructureId");
            TextBox SalaryStructure = (TextBox)LV.EditItem.FindControl("SalaryStructureTxt");
            DropDownList MemSalCategoryDDL = (DropDownList)LV.EditItem.FindControl("MemSalCategoryDDL");
            DropDownList FundCenterDDL = (DropDownList)LV.EditItem.FindControl("FundCenterDDL");
            CheckBox IsCurrent = (CheckBox)LV.EditItem.FindControl("IsCurrentCB");
            SalaryStructure bh = new SalaryStructure();
            bh.SalaryStructureId= Convert.ToInt32(SalaryStructureId.Value);
            bh.MemberSalCategoryId = Convert.ToInt32(MemSalCategoryDDL.SelectedItem.Value);
            bh.Description = Convert.ToString(SalaryStructure.Text);
            bh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
            bh.FundCenterId= Convert.ToInt32(FundCenterDDL.SelectedItem.Value);
            new FinBIZ().UpdateSalaryStructure(bh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindVistLV();
            e.Cancel = true;
            Response.Redirect("ManageSalaryStructure.aspx");

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


        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList DDL = e.Item.FindControl("MemSalCategoryDDL") as DropDownList;
                HiddenField Id = (e.Item.FindControl("HidMemberSalCategoryId") as HiddenField);
                DDL.SelectedValue = Id.Value.ToString();
                DropDownList FundCenterDDL = e.Item.FindControl("FundCenterDDL") as DropDownList;
                HiddenField FundCenterId = (e.Item.FindControl("HidFundCenterId") as HiddenField);
                FundCenterDDL.SelectedValue = FundCenterId.Value.ToString();
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
            FinancialYears financialYears = new BudgetBiz().GetCurrentFinancialYear();
            List<FundCenters> fs = new BudgetBiz().GetFundCenters(financialYears.FinancialYearId);
            DropDownList FundCenterDDL = new DropDownList();
            FundCenterDDL = (e.Item.FindControl("FundCenterDDL") as DropDownList);
            if (FundCenterDDL != null)
            {
                foreach (FundCenters row in fs)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.FundCenterId.ToString();
                    ty.Text = row.FundCenter.ToString();
                    FundCenterDDL.Items.Add(ty);
                }

            }

        }

        protected void AssignBtn_Click(object sender, EventArgs e)
        {
           
        }
    }
}