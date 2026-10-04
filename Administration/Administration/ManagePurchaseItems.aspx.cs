using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BIZ;

namespace Administration
{
    public partial class ManagePurchaseItems : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                bindListView1();
                List<CalcUnit> units = new AdminBIZ().GetUnits();
                if (units != null)
                {
                    foreach (CalcUnit t in units)
                    {
                        ListItem a = new ListItem();
                        a.Value = t.UnitId.ToString();
                        a.Text = t.Description;
                        UnitDDL.Items.Add(a);
                    }
                }
            }
            


        }
        protected string GetGrandTotal()
        {
            decimal GrandTotal = 0;
            foreach (ListViewItem li in ListView1.Items)
            {
                Label cb = (Label)li.FindControl("TotalPrice");
                GrandTotal += decimal.Parse(cb.Text);
            }
           return String.Format("{0:#,##0}", GrandTotal); 

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList UnitDDL2 = new DropDownList();
            UnitDDL2 = (e.Item.FindControl("UnitDDL") as DropDownList);
            if (UnitDDL2 != null)
            {

                List<CalcUnit> ps = new AdminBIZ().GetUnits();
                if (ps != null)
                {
                    foreach (CalcUnit row in ps)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.UnitId.ToString();
                        li.Text = row.Description.ToString();
                        UnitDDL2.Items.Add(li);
                    }
                }

            }

        }
        protected void bindListView1()
        {
            int PurchaseId = Convert.ToInt32(Request.QueryString["Id"]);
            List<PurchaseItem> PurchaseItems = new AdminBIZ().GetPurchaseItems(PurchaseId);
            ListView1.DataSource = PurchaseItems;
            ListView1.DataBind();
            GrandTotalLbl.Text = GetGrandTotal();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            int PurchaseId = Convert.ToInt32(Request.QueryString["Id"]);
            PurchaseItem ep = new PurchaseItem();
            ep.PurchaseId = PurchaseId;
            ep.ItemId = Convert.ToInt32(HidItemId.Value);
            ep.SingleItemPrice = Convert.ToInt32(PriceTxt.Text);
            ep.Quantity= Convert.ToInt32(QuantityTxt.Text);
            ep.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            ep.Remarks = Convert.ToString(RemarksTxt.Text); ;
            new AdminBIZ().InsertPurchaseItem(ep);
            bindListView1();
            Response.Redirect("ManagePurchaseItems.aspx?Id=" + PurchaseId);

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = e.NewEditIndex;
            bindListView1();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                
                DropDownList UnitDDL = e.Item.FindControl("UnitDDL") as DropDownList;
                HiddenField HidUnitIt = (e.Item.FindControl("HidUnitId") as HiddenField);
                UnitDDL.SelectedValue = HidUnitIt.Value.ToString();
            }
         
        }
        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            bindListView1();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            //int PurchaseId = Convert.ToInt32(Request.QueryString["Id"]);
            //PurchaseItem ep = new PurchaseItem();
            //ep.PurchaseId = PurchaseId;
            //ep.ItemId = Convert.ToInt32(HidItemId.Value);
            //ep.SingleItemPrice = Convert.ToInt32(PriceTxt.Text);
            //ep.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            //ep.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            //ep.Quantity = Convert.ToInt32(QuantityTxt.Text);
            //ep.Remarks = Convert.ToString(RemarksTxt.Text);
            //new AdminBIZ().InsertPurchaseItem(ep);
            //ListView1.EditIndex = -1;
            //ListView1.InsertItemPosition = InsertItemPosition.None;
            //bindListView1();
            //e.Cancel = true;
            //Response.Redirect("ManagePurchaseItem.aspx?Id=" + PurchaseId);
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidPurchaseItemId = ListView1.EditItem.FindControl("HidPurchaseItemId") as HiddenField;
            int PurchaseId = Convert.ToInt32(Request.QueryString["PurchaseId"]);
            TextBox Price = (TextBox)ListView1.EditItem.FindControl("PriceTxt");
            TextBox Quantity = (TextBox)ListView1.EditItem.FindControl("QuantityTxt");
            DropDownList UnitId = (DropDownList)ListView1.EditItem.FindControl("UnitDDL");
            TextBox Remarks = (TextBox)ListView1.EditItem.FindControl("RemarksTxt");
            PurchaseItem ep = new PurchaseItem();
            ep.PurchaseItemId = Convert.ToInt32(HidPurchaseItemId.Value);
            ep.TotalPrice = Convert.ToInt32(Price.Text);
            ep.UnitId = Convert.ToInt32(UnitId.SelectedValue);
            ep.Quantity = Convert.ToInt32(Quantity.Text);
            ep.Remarks = Convert.ToString(Remarks.Text);
            new AdminBIZ().UpdatePurchaseItem(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidPurchaseItemId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidPurchaseItemId");
            int itemid = Convert.ToInt32(HidPurchaseItemId.Value);
            new AdminBIZ().DeletePurchaseItem(itemid);
            bindListView1();
        }

    }
}