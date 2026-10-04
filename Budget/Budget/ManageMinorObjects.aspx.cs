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
    public partial class ManageMinorObjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
                int FundCenter = Convert.ToInt32(Request.QueryString["FC"]);
                MajorObjects fs = new BudgetBiz().GetMajorObject(MajorObjectId);
                string fc = new BudgetBiz().GetFundCenter(FundCenter).FundCenter.ToUpper();
                string maj= fs.MajorObject.ToUpper();
                header.InnerText = maj + " (" + fc + ")";
                BindVistLV();
            }
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected string GetLink(int MinorObjectId)
        {
            int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
            int FundCenter = Convert.ToInt32(Request.QueryString["FC"]);
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            return "~/ManageHeadOfAccounts.aspx?MIN=" + MinorObjectId + "&MAJ=" + MajorObjectId + "&FC=" + FundCenter + "&FY=" + FinancialYearId;

        }
        protected void BindVistLV()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
            List<MinorObjects> Eq = new BudgetBiz().GetActiveMinorObjectsByMajorObject(MajorObjectId,FinancialYearId);
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
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            DropDownList MajorObjectDDL = new DropDownList();
            MajorObjectDDL = (e.Item.FindControl("MajorObjectDDL") as DropDownList);
            if (MajorObjectDDL != null)
            {
                List<MajorObjects> pt = new BudgetBiz().GetMajorObjects(FinancialYearId);
                foreach (MajorObjects row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.MajorObjectId.ToString();
                    cy.Text = row.MajorObject.ToString();
                    MajorObjectDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            MinorObjects eh = new MinorObjects();
            int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
            int FinancialYearId= Convert.ToInt32(Request.QueryString["FY"]);
            int FundCenter= Convert.ToInt32(Request.QueryString["FC"]);
            TextBox MinorObjectTxt = LV.InsertItem.FindControl("MinorObjectTxt") as TextBox;
            eh.MinorObject = Convert.ToString(MinorObjectTxt.Text);
            eh.MajorObjectId = MajorObjectId;
            eh.IsActive = 1;
            new BudgetBiz().InsertMinorObject(eh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
            Response.Redirect("~/ManageMinorObjects.aspx?MAJ=" +  MajorObjectId + "&FY=" + FinancialYearId + "&FC=" + FundCenter);
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

                HiddenField HidMajorObjectId = e.Item.FindControl("HidMajorObjectId") as HiddenField;
                DropDownList MajorObjectDDL = e.Item.FindControl("MajorObjectDDL") as DropDownList;
                MajorObjectDDL.SelectedValue = HidMajorObjectId.Value;
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            MinorObjects eh = new MinorObjects();
            HiddenField HidMinorObjectId = LV.EditItem.FindControl("HidMinorObjectId") as HiddenField;
            DropDownList MajorObjectDDL = LV.EditItem.FindControl("MajorObjectDDL") as DropDownList;
            TextBox MinorObjectTxt = LV.EditItem.FindControl("MinorObjectTxt") as TextBox;
            eh.MinorObjectId = Convert.ToInt32(HidMinorObjectId.Value);
            eh.MinorObject = Convert.ToString(MinorObjectTxt.Text);
            eh.MajorObjectId = Convert.ToInt32(MajorObjectDDL.SelectedValue);
            new BudgetBiz().UpdateMinorObject(eh);
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
            HiddenField HidMinorObject = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidMinorObject");
            int MinorObjectId = Convert.ToInt32(HidMinorObject.Value);
            int check = new BudgetBiz().GetMinorHOAs(MinorObjectId);
            if (check == 0)
            {
                err.Text = "";
                new BudgetBiz().DeleteMinorObject(MinorObjectId);
            }
            else
            {
                err.Text = "Minor object contains Head of Accounts so it can not be deleted";
            }
            BindVistLV();
        }
    
}
}