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
    public partial class ManageMojaorObjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
                FundCenters fs = new BudgetBiz().GetFundCenter(FundCenterId);
                header.InnerText = fs.FundCenter.ToUpper();
                BindVistLV();
            }
        }
        protected string GetLink(int MajorObjectId)
        {
            int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            return "~/ManageMinorObjects.aspx?MAJ=" + MajorObjectId + "&FC=" + FundCenterId + "&FY=" + FinancialYearId;

        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected void BindVistLV()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
            List<MajorObjects> Eq = new BudgetBiz().GetActiveMajorObjectsByPool(FundCenterId,FinancialYearId);
            LV.DataSource = Eq;
            LV.DataBind();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindVistLV();

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            BindVistLV();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList FundCenterDDL = new DropDownList();
            FundCenterDDL = (e.Item.FindControl("FundCenterDDL") as DropDownList);
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            if (FundCenterDDL != null)
            {
                List<FundCenters> pt = new BudgetBiz().GetFundCenters(FinancialYearId);
                foreach (FundCenters row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.FundCenterId.ToString();
                    cy.Text = row.FundCenter.ToString();
                    FundCenterDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            MajorObjects eh = new MajorObjects();
            int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
            TextBox MajorObjectTxt = LV.InsertItem.FindControl("MajorObjectTxt") as TextBox;
            eh.MajorObject = Convert.ToString(MajorObjectTxt.Text);
            eh.FundCenterId = FundCenterId;
            eh.IsActive = 1;
            new BudgetBiz().InsertMajorObject(eh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            Response.Redirect("~/ManageMajorObjects.aspx?FC=" + FundCenterId + "&FY=" + FinancialYearId);
        }

        protected string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            e.Cancel = true;
            BindVistLV();

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                HiddenField HidFundCenterId = e.Item.FindControl("HidFundCenterId") as HiddenField;
                DropDownList FundCenterDDL = e.Item.FindControl("FundCenterDDL") as DropDownList;
                FundCenterDDL.SelectedValue = HidFundCenterId.Value;
            }


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            MajorObjects eh = new MajorObjects();
            HiddenField HidMajorObjectId = LV.EditItem.FindControl("HidMajorObjectId") as HiddenField;
            DropDownList HidFundCenterDDL = LV.EditItem.FindControl("FundCenterDDL") as DropDownList;
            TextBox MajorObjectTxt = LV.EditItem.FindControl("MajorObjectTxt") as TextBox;
            eh.MajorObjectId = Convert.ToInt32(HidMajorObjectId.Value);
            eh.MajorObject = Convert.ToString(MajorObjectTxt.Text);
            eh.FundCenterId = Convert.ToInt32(HidFundCenterDDL.SelectedValue);
            new BudgetBiz().UpdateMajorObject(eh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
       }

        protected void VisitsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindVistLV();

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidMajorObject = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidMajorObject");
            int MajorObjectId = Convert.ToInt32(HidMajorObject.Value);
            int check = new BudgetBiz().GetMajorMinors(MajorObjectId);
            if (check == 0)
            {
                err.Text = "";
                new BudgetBiz().DeleteMajorObject(MajorObjectId);
            }
            else
            {
                err.Text = "Major object contains minor objects so it can not be deleted";
            }

            BindVistLV();
        }
    }

}