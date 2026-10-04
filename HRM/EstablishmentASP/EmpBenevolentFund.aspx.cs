using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP
{
    public partial class EmpBenevolentFund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                bindEmpBenFundsLV(empval);
            }
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindEmpBenFundsLV(int empval)
        {
            List<EmpBenevolentFunds> EmpDep = new EmployeeHandler().GetEmpBenevolentFunds(empval);
            EmpBenFundsLV.DataSource = EmpDep;
            EmpBenFundsLV.DataBind();
        }

        //public string GetDate(DateTime date)
        //{
        //    return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        //}
        //////////////////List View\\\\\\\\\\\\\\\\\\\\\\
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpBenFundsLV.InsertItemPosition = InsertItemPosition.None;
            EmpBenFundsLV.SelectedIndex = -1;
            EmpBenFundsLV.EditIndex = e.NewEditIndex;
            bindEmpBenFundsLV(empval);
            e.Cancel = true;

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpBenFundsLV.EditIndex = -1;
            EmpBenFundsLV.InsertItemPosition = InsertItemPosition.None;
            EmpBenFundsLV.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpBenFundsLV(empval);
            e.Cancel = true;
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField EmpBenevolentFundId = EmpBenFundsLV.EditItem.FindControl("EmpBenevolentFundId") as HiddenField;
            TextBox AmountTxt = EmpBenFundsLV.EditItem.FindControl("AmountTxt") as TextBox;
            DropDownList FundTypeDDL = EmpBenFundsLV.EditItem.FindControl("FundTypeDDL") as DropDownList;
            TextBox FundDateTxt = EmpBenFundsLV.EditItem.FindControl("FundDateTxt") as TextBox;
            TextBox DetailsTxt = EmpBenFundsLV.EditItem.FindControl("DetailsTxt") as TextBox;
            EmpBenevolentFunds eh = new EmpBenevolentFunds();
            eh.EmpBenevolentFundId= Convert.ToInt32(EmpBenevolentFundId.Value);
            eh.SystemUsersId = empval;
            eh.BenevolentFundTypeId = Convert.ToInt32(FundTypeDDL.SelectedValue);
            eh.Details = Convert.ToString(DetailsTxt.Text);
            eh.FundDate= Convert.ToDateTime(FundDateTxt.Text);
            if (!string.IsNullOrEmpty(AmountTxt.Text))
                eh.Amount = Convert.ToInt32(AmountTxt.Text);
            new EmployeeHandler().UpdateEmpBenevolentFund(eh);
            EmpBenFundsLV.EditIndex = -1;
            bindEmpBenFundsLV(empval);
            EmpBenFundsLV.InsertItemPosition = InsertItemPosition.None;
            EmpBenFundsLV.SelectedIndex = -1;
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (EmpBenFundsLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList FundTypeDDL = e.Item.FindControl("FundTypeDDL") as DropDownList;
                HiddenField BenevolentFundTypeId = (e.Item.FindControl("BenevolentFundTypeId") as HiddenField);
                FundTypeDDL.SelectedValue = BenevolentFundTypeId.Value.ToString();
            }

        }

        protected void EmpDepButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpBenFundsLV.SelectedIndex = -1;
            EmpBenFundsLV.EditIndex = -1;
            EmpBenFundsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmpBenFundsLV(empval);

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox AmountTxt = EmpBenFundsLV.InsertItem.FindControl("AmountTxt") as TextBox;
            DropDownList FundTypeDDL = EmpBenFundsLV.InsertItem.FindControl("FundTypeDDL") as DropDownList;
            TextBox FundDateTxt = EmpBenFundsLV.InsertItem.FindControl("FundDateTxt") as TextBox;
            TextBox DetailsTxt = EmpBenFundsLV.InsertItem.FindControl("DetailsTxt") as TextBox;
            EmpBenevolentFunds eh = new EmpBenevolentFunds();
            eh.SystemUsersId = empval;
            eh.BenevolentFundTypeId = Convert.ToInt32(FundTypeDDL.SelectedValue);
            eh.Details = Convert.ToString(DetailsTxt.Text);
            eh.FundDate = Convert.ToDateTime(FundDateTxt.Text);
            if(!string.IsNullOrEmpty(AmountTxt.Text))
            eh.Amount = Convert.ToInt32(AmountTxt.Text);
            new EmployeeHandler().InsertEmpBenevolentFund(eh);
            EmpBenFundsLV.EditIndex = -1;
            bindEmpBenFundsLV(empval);
            EmpBenFundsLV.InsertItemPosition = InsertItemPosition.None;
            EmpBenFundsLV.SelectedIndex = -1;
            e.Cancel = true;
            Response.Redirect("EmpBenevolentFund.aspx?empid=" + empval);
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList FundTypeDDL = new DropDownList();
            FundTypeDDL = (e.Item.FindControl("FundTypeDDL") as DropDownList);
            if (FundTypeDDL != null)
            {
                FundTypeDDL.Items.Add(new ListItem("Select", "0"));
                List<BenFundTypes> pt = new AdministrationBIZ().GetBenFundTypes();
                foreach (BenFundTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Text = row.FundType.ToString();
                    cy.Value = row.BenFundTypeId.ToString();
                    FundTypeDDL.Items.Add(cy);
                }
            }
        }

        protected void EmpBenFundsLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpBenevolentFundId = (HiddenField)EmpBenFundsLV.Items[e.ItemIndex].FindControl("EmpBenevolentFundId");
            int Id= Convert.ToInt32(EmpBenevolentFundId.Value);
            new EmployeeHandler().DeleteEmpBenevolentFund(Id);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpBenFundsLV(empval);
        }
    }
}