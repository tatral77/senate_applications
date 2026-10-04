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
    public partial class ManageHeadOfAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
                int MinorObjectId = Convert.ToInt32(Request.QueryString["MIN"]);
                int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
                int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
                string fs = new BudgetBiz().GetFundCenter(FundCenterId).FundCenter.ToUpper();
                string maj= new BudgetBiz().GetMajorObject(MajorObjectId).MajorObject.ToUpper();
                string min = new BudgetBiz().GetMinorObject(MinorObjectId).MinorObject.ToUpper();
                string fy = new BudgetBiz().GetFinancialYear(FinancialYearId).FinancialYear.ToUpper();
                // header.InnerText = min + " ( " + maj + " - " + fs + ")->"  + fy;
                HeaderLink.NavigateUrl = "~/ManageMinorObjects.aspx?MAJ=" + MajorObjectId + "&FC=" + FundCenterId + "&FY=" + FinancialYearId + "&MIN=" + MinorObjectId;
                HeaderLink.Text= fy + " ( " + fs + " - " + maj + ")->" + min;
                BindVistLV();
            }
        }
        protected string GetLink(int MinorObjectId)
        {
            int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
            int MajorObjectId= Convert.ToInt32(Request.QueryString["MAJ"]);
            return "#";
           // return "~/ManageHeadOfAccounts.aspx?MAJ=" + MajorObjectId + "&FC=" + FundCenterId + "&MIN=" + MinorObjectId;

        }
      
        protected void BindVistLV()
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            int MinorObject = Convert.ToInt32(Request.QueryString["MIN"]);
            List<HeadOfAccounts> Eq = new BudgetBiz().GetHeadOfAccounts(MinorObject,FinancialYearId);
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
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            int MajorObjectId= Convert.ToInt32(Request.QueryString["MAJ"]);
            DropDownList MinorObjectDDL = new DropDownList();
            MinorObjectDDL = (e.Item.FindControl("MinorObjectDDL") as DropDownList);
            if (MinorObjectDDL != null)
            {
                List<MinorObjects> pt = new BudgetBiz().GetActiveMinorObjectsByMajorObject(MajorObjectId,FinancialYearId);
                foreach (MinorObjects row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.MinorObjectId.ToString();
                    cy.Text = row.MinorObject.ToString();
                    MinorObjectDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int MajorObjectId = Convert.ToInt32(Request.QueryString["MAJ"]);
            int FundCenterId = Convert.ToInt32(Request.QueryString["FC"]);
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            HeadOfAccounts eh = new HeadOfAccounts();
            int MinorObjectId = Convert.ToInt32(Request.QueryString["MIN"]);
            TextBox HeadOfAccountTxt = LV.InsertItem.FindControl("HeadOfAccountTxt") as TextBox;
            TextBox BudgetTxt = LV.InsertItem.FindControl("BudgetTxt") as TextBox;
            HeadOfAccountBudget sh = new HeadOfAccountBudget();
            eh.HeadOfAccount = Convert.ToString(HeadOfAccountTxt.Text);
            eh.MinorObjectId = MinorObjectId;
            eh.IsActive = 1;
            int Id=new BudgetBiz().InsertHeadOfAccount(eh);
            sh.HeadOfAccountId = Id;
            sh.Amount = Convert.ToDouble(BudgetTxt.Text);
            sh.RemainingBalance = sh.Amount;
            sh.FinancialYearId = FinancialYearId;
            new BudgetBiz().InsertHeadOfAccountBudget(sh);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindVistLV();
          
            Response.Redirect("~/ManageHeadOfAccounts.aspx?FC=" + FundCenterId + "&MAJ=" + MajorObjectId + "&MIN=" + MinorObjectId + "&FY=" + FinancialYearId);
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

                HiddenField HidMinorObjectId = e.Item.FindControl("HidMinorObjectId") as HiddenField;
                DropDownList MinorObjectDDL = e.Item.FindControl("MinorObjectDDL") as DropDownList;
                MinorObjectDDL.SelectedValue = HidMinorObjectId.Value;
            }


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HeadOfAccounts eh = new HeadOfAccounts();
            HiddenField HeadOfAccountId = LV.EditItem.FindControl("HidHeadOfAccountId") as HiddenField;
            TextBox HeadOfAccountTxt = LV.EditItem.FindControl("HeadOfAccountTxt") as TextBox;
            DropDownList MinorObjectDDL= LV.EditItem.FindControl("MinorObjectDDL") as DropDownList;
            eh.HeadOfAccountId = Convert.ToInt32(HeadOfAccountId.Value);
            eh.HeadOfAccount = Convert.ToString(HeadOfAccountTxt.Text);
            eh.MinorObjectId = Convert.ToInt32(MinorObjectDDL.SelectedValue);
            eh.IsActive = 1;
            new BudgetBiz().UpdateHeadOfAccount(eh);
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
        protected string  GetBudget(int HeadOfAccountId)
        {
            int FinancialYearId=Convert.ToInt32(Request.QueryString["FY"]);
            //return new BudgetBiz().GetHeadOfAccountBudget(HeadOfAccountId, FinancialYearId).Amount.ToString();
            return  new BudgetBiz().GetHeadOfAccountBudget(HeadOfAccountId, FinancialYearId).Amount.ToString();
        }

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidHeadOfAccountId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidHeadOfAccountId");
            int HeadOfAccountId = Convert.ToInt32(HidHeadOfAccountId.Value);
            new BudgetBiz().DeleteHeadOfAccount(HeadOfAccountId);
            int check = new BudgetBiz().GetHOABills(HeadOfAccountId);
            if (check == 0)
            {
                err.Text = "";
                new BudgetBiz().DeleteHeadOfAccount(HeadOfAccountId);
            }
            else
            {
                err.Text = "Head of Account contains Bills so it can not be deleted";
            }
            BindVistLV();
        
    }
    protected void SaveBudgetBtn_Click(object sender, EventArgs e)
        {
            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            foreach (ListViewItem li in LV.Items)
            {
                TextBox cb = (TextBox)li.FindControl("BudgetTxt");
                if (cb!=null)
                {
                    HiddenField HeadOfAccountId = (HiddenField)li.FindControl("HidHeadOfAccountId");
                    int headOfAccountId = (Convert.ToInt32(HeadOfAccountId.Value));
                    HeadOfAccountBudget sh = new HeadOfAccountBudget();
                    sh.HeadOfAccountId = headOfAccountId;
                    sh.FinancialYearId = FinancialYearId;
                    sh.Amount = Convert.ToDouble(cb.Text);
                    new BudgetBiz().InsertHeadOfAccountBudget(sh);
                }
            }
        }
        protected string GetFormattedAmount(double Amount)
        {
            //decimal GrandTotal = 0;
            //foreach (ListViewItem li in ListView1.Items)
            //{
            //    Label cb = (Label)li.FindControl("TotalPrice");
            //    GrandTotal += decimal.Parse(cb.Text);
            //}
            return String.Format("{0:#,##0}", Amount);

        }
    }
}