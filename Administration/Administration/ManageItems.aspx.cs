using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class ManageItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MainItemId = Convert.ToInt32(Request.QueryString["MainItemId"]);
                MainItems mitem = new AdminBIZ().GetMainItem(MainItemId);
                heading.Text = mitem.MainItem.ToUpper() + " ( " + mitem.Category.ToUpper() + " )" ;
                HyperLink1.NavigateUrl = ("~/ManageMainItems.aspx?CategoryId=" + mitem.CategoryId);
                bindMainItemLV();
            }

        }
        protected void bindMainItemLV()
        {
            int MainItemId = Convert.ToInt32(Request.QueryString["MainItemId"]);
            List<Items> items = new AdminBIZ().GetItemsByMainItem(MainItemId);
            MainItemLV.DataSource = items;
            MainItemLV.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            MainItemLV.SelectedIndex = -1;
            MainItemLV.EditIndex = -1;
            MainItemLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindMainItemLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            MainItemLV.InsertItemPosition = InsertItemPosition.None;
            MainItemLV.SelectedIndex = -1;
            MainItemLV.EditIndex = e.NewEditIndex;
            bindMainItemLV();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (MainItemLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

                int MainItemId = Convert.ToInt32(Request.QueryString["MainItemId"]);
                DropDownList MainItemDDL = e.Item.FindControl("MainItemDDL") as DropDownList;
                MainItemDDL.SelectedValue = MainItemId.ToString();

                DropDownList UnitDDL = e.Item.FindControl("UnitDDL") as DropDownList;
                HiddenField HidUnitId = (e.Item.FindControl("HidUnitId") as HiddenField);
                UnitDDL.SelectedValue = HidUnitId.Value.ToString();


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
            DropDownList MainItemDDL = new DropDownList();
            MainItemDDL = (e.Item.FindControl("MainItemDDL") as DropDownList);
            if (MainItemDDL != null)
            {
                List<MainItems> ps = new AdminBIZ().GetMainItems();
                foreach (MainItems row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.MainItemId.ToString();
                    li.Text = row.MainItem.ToString();
                    MainItemDDL.Items.Add(li);
                }

            }
            DropDownList UnitDDL = new DropDownList();
            UnitDDL = (e.Item.FindControl("UnitDDL") as DropDownList);
            if (UnitDDL != null)
            {
                List<CalcUnit> ps = new AdminBIZ().GetUnits();
                foreach (CalcUnit row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.UnitId.ToString();
                    li.Text = row.Description.ToString();
                    UnitDDL.Items.Add(li);
                }

            }


        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            MainItemLV.EditIndex = -1;
            MainItemLV.InsertItemPosition = InsertItemPosition.None;
            MainItemLV.SelectedIndex = -1;
            bindMainItemLV();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ItemId = (HiddenField)MainItemLV.Items[e.ItemIndex].FindControl("HidItemId");
            int Id = Convert.ToInt32(ItemId.Value);
            new AdminBIZ().DeleteItem(Id);
            bindMainItemLV();
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
           
            // HiddenField HidMainItemId = MainItemLV.InsertItem.FindControl("HidMainItemId") as HiddenField;
            //HiddenField HidCategoryId = MainItemLV.InsertItem.FindControl("HidCategoryId") as HiddenField;
            int MainItemId = Convert.ToInt32(Request.QueryString["MainItemId"]);
            TextBox ItemTxt = (TextBox)MainItemLV.InsertItem.FindControl("ItemTxt");
            TextBox DetailsTxt = (TextBox)MainItemLV.InsertItem.FindControl("DetailsTxt");
            TextBox CurrentBalanceTxt = (TextBox)MainItemLV.InsertItem.FindControl("CurrentBalanceTxt");
            TextBox ThresholdLevel = (TextBox)MainItemLV.InsertItem.FindControl("ThresholdLevelTxt");
            TextBox ItemsInPacking = (TextBox)MainItemLV.InsertItem.FindControl("ItemsInPackingTxt");
            DropDownList IsActive = (DropDownList)MainItemLV.InsertItem.FindControl("IsActiveDDL");
            DropDownList UnitDDL = (DropDownList)MainItemLV.InsertItem.FindControl("UnitDDL");
            List<Items> ITEM = new AdminBIZ().GetItemByName(ItemTxt.Text);
            Label err = (Label)MainItemLV.InsertItem.FindControl("err");
            if (ITEM!=null)
                err.Text = "Item already exists";
            else
            {
                Items itb = new Items();
                itb.ItemName = ItemTxt.Text;
                itb.Details = DetailsTxt.Text;
                itb.MainItemId = MainItemId;
                itb.ThresholdLevel = Convert.ToInt32(ThresholdLevel.Text);
                itb.CurrentBalance = Convert.ToInt32(CurrentBalanceTxt.Text);
                itb.ItemsInPacking = Convert.ToInt32(ItemsInPacking.Text);
                itb.IsActive = Convert.ToInt32(IsActive.SelectedValue);
                itb.UnitId= Convert.ToInt32(UnitDDL.SelectedValue);
                new AdminBIZ().InsertItem(itb);
                MainItemLV.EditIndex = -1;
                MainItemLV.InsertItemPosition = InsertItemPosition.None;
                bindMainItemLV();
                e.Cancel = true;
                Response.Redirect("ManageItems.aspx?MainItemId=" + MainItemId);
                err.Text = "";
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidItemId = MainItemLV.EditItem.FindControl("HidItemId") as HiddenField;
            int itemid = Convert.ToInt32(HidItemId.Value);
            TextBox ItemTxt = (TextBox)MainItemLV.EditItem.FindControl("ItemTxt");
            TextBox DetailsTxt = (TextBox)MainItemLV.EditItem.FindControl("DetailsTxt");
            DropDownList MainItemDDL = (DropDownList)MainItemLV.EditItem.FindControl("MainItemDDL");
            TextBox CurrentBalanceTxt = (TextBox)MainItemLV.EditItem.FindControl("CurrentBalanceLbl");
            TextBox ThresholdLevel = (TextBox)MainItemLV.EditItem.FindControl("ThresholdLevelTxt");
            TextBox ItemsInPacking = (TextBox)MainItemLV.EditItem.FindControl("ItemsInPackingTxt");
            DropDownList UnitDDL = (DropDownList)MainItemLV.EditItem.FindControl("UnitDDL");
            DropDownList IsActive = (DropDownList)MainItemLV.EditItem.FindControl("IsActiveDDL");
            List<Items> ITEM = new AdminBIZ().GetItemByName(ItemTxt.Text);
            Label err = (Label)MainItemLV.EditItem.FindControl("err");
            Items itb = new Items();
            itb.ItemId = Convert.ToInt32(HidItemId.Value);
            itb.ItemName = ItemTxt.Text;
            itb.Details = DetailsTxt.Text;
            itb.MainItemId = Convert.ToInt32(MainItemDDL.SelectedValue);
            itb.ThresholdLevel = Convert.ToInt32(ThresholdLevel.Text);
            itb.CurrentBalance = Convert.ToInt32(CurrentBalanceTxt.Text);
            itb.ItemsInPacking = Convert.ToInt32(ItemsInPacking.Text);
            itb.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            itb.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            if (ITEM != null)
            {
                if (ITEM.Exists(x => x.ItemId != itemid))
                    err.Text = "Item already exists";

                else
                {
                   
                    new AdminBIZ().UpdateItem(itb);
                }
            }
            else
            {
                new AdminBIZ().UpdateItem(itb);

            }
                MainItemLV.EditIndex = -1;
                MainItemLV.InsertItemPosition = InsertItemPosition.None;
                bindMainItemLV();
                e.Cancel = true;
            
            }
    }
}