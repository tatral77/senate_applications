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
    public partial class ManageMainItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
                Categories cat = new AdminBIZ().GetCategory(CategoryId);
                heading.Text = cat.CategoryName.ToUpper();
                HyperLink1.NavigateUrl = ("~/ManageCategories.aspx");
                bindMainItemLV();
            }

        }
        protected void bindMainItemLV()
        {
            int CategoryId= Convert.ToInt32(Request.QueryString["CategoryId"]);
            List<MainItems> Status = new AdminBIZ().GetMainItemsByCat(CategoryId);
            MainItemLV.DataSource = Status;
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

                int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
                DropDownList CategoryDDL = e.Item.FindControl("CategoryDDL") as DropDownList;
                CategoryDDL.SelectedValue = CategoryId.ToString();
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
            DropDownList CategoryDDL = new DropDownList();
            CategoryDDL = (e.Item.FindControl("CategoryDDL") as DropDownList);
            if (CategoryDDL != null)
            {
                List<Categories> ps = new AdminBIZ().GetCategories();
                foreach (Categories row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CategoryId.ToString();
                    li.Text = row.CategoryName.ToString();
                    CategoryDDL.Items.Add(li);
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


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // HiddenField HidMainItemId = MainItemLV.InsertItem.FindControl("HidMainItemId") as HiddenField;
            //HiddenField HidCategoryId = MainItemLV.InsertItem.FindControl("HidCategoryId") as HiddenField;
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            TextBox MainItemTxt = (TextBox)MainItemLV.InsertItem.FindControl("MainItemTxt");
            DropDownList IsActive = (DropDownList)MainItemLV.InsertItem.FindControl("IsActiveDDL");
            MainItems itb = new MainItems();
            itb.MainItem = MainItemTxt.Text;
            itb.CategoryId = CategoryId;
            itb.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().InsertMainItem(itb);
            MainItemLV.EditIndex = -1;
            MainItemLV.InsertItemPosition = InsertItemPosition.None;
            bindMainItemLV();
            e.Cancel = true;
            Response.Redirect("ManageMainItems.aspx?CategoryId=" + CategoryId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidMainItemId = MainItemLV.EditItem.FindControl("HidMainItemId") as HiddenField;
            TextBox MainItemTxt = (TextBox)MainItemLV.EditItem.FindControl("MainItemTxt");
            DropDownList CategoryDDL = (DropDownList)MainItemLV.EditItem.FindControl("CategoryDDL");
            DropDownList IsActive = (DropDownList)MainItemLV.EditItem.FindControl("IsActiveDDL");
            MainItems itb = new MainItems();
            itb.MainItemId = Convert.ToInt32(HidMainItemId.Value);
            itb.MainItem = MainItemTxt.Text;
            itb.CategoryId = Convert.ToInt32(CategoryDDL.SelectedValue);
            itb.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().UpdateMainItem(itb);
            MainItemLV.EditIndex = -1;
            MainItemLV.InsertItemPosition = InsertItemPosition.None;
            bindMainItemLV();
            e.Cancel = true;
        }
    }
}