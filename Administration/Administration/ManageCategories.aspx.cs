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
    public partial class ManageCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCategoryLV();
              
            }

        }
        protected void bindCategoryLV()
        {
            List<Categories> Category = new AdminBIZ().GetCategories();
            CategoryLV.DataSource = Category;
            CategoryLV.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            CategoryLV.SelectedIndex = -1;
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindCategoryLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            CategoryLV.SelectedIndex = -1;
            CategoryLV.EditIndex = e.NewEditIndex;
            bindCategoryLV();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (CategoryLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

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
            //DropDownList CategoryDDL = new DropDownList();
            //CategoryDDL = (e.Item.FindControl("CategoryDDL") as DropDownList);
            //if (CategoryDDL != null)
            //{
            //    List<Categories> ps = new AdminBIZ().GetCategory();

            //    foreach (Categories row in ps)
            //    {
            //        ListItem li = new ListItem();
            //        li.Value = row.Description.ToString();
            //        li.Text = row.Description.ToString();
            //        CategoryDDL.Items.Add(li);
            //    }

            //}

        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            CategoryLV.SelectedIndex = -1;
            bindCategoryLV();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox CategoryTxt = (TextBox)CategoryLV.InsertItem.FindControl("CategoryTxt");
            DropDownList IsActive = (DropDownList)CategoryLV.InsertItem.FindControl("IsActiveDDL");
            Categories itb = new Categories();
            itb.CategoryName = CategoryTxt.Text;
            itb.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().InsertCategory(itb);
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            bindCategoryLV();
            e.Cancel = true;
            Response.Redirect("ManageCategories.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidCategoryId = CategoryLV.EditItem.FindControl("HidCategoryId") as HiddenField;
            TextBox Description = (TextBox)CategoryLV.EditItem.FindControl("CategoryTxt");
            DropDownList IsActive = (DropDownList)CategoryLV.EditItem.FindControl("IsActiveDDL");
            Categories ep = new Categories();
            ep.CategoryId = Convert.ToInt32(HidCategoryId.Value);
            ep.CategoryName = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().UpdateCategory(ep);
            CategoryLV.EditIndex = -1;
            CategoryLV.InsertItemPosition = InsertItemPosition.None;
            bindCategoryLV();
            //  }
            e.Cancel = true;
        }
    }
}