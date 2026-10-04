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
    public partial class SearchItem : System.Web.UI.Page
    {
        //[WebMethod]
        //public static List<string> GetEmployeeName(string empName)
        //{
        //    List<string> empResult = new List<string>();
        //    List<Member> mems = new AutomationBIZ().GetMembersByName(empName);
        //    foreach (Member a in mems)
        //    {
        //        empResult.Add(a.MemberName);
        //    }
        //    return empResult;
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }
        }
        private void bindListView()
        {
            string query = " SELECT ADM_ITEMS.ITEM_ID, ADM_ITEMS.ITEM, ADM_ITEMS.MAIN_ITEM_ID,ADM_ITEMS.CURRENT_BALANCE, ADM_ITEMS.THRESHOLD_LEVEL,ADM_ITEMS.IS_ACTIVE, ADM_MAIN_ITEMS.MAIN_ITEM, ADM_MAIN_ITEMS.CATEGORY_ID, ";
            query += " ADM_CATEGORIES.CATEGORY, ADM_ITEMS.CURRENT_BALANCE ";
            query += " FROM ADM_MAIN_ITEMS INNER JOIN ";
            query += " ADM_CATEGORIES ON ADM_MAIN_ITEMS.CATEGORY_ID = ADM_CATEGORIES.CATEGORY_ID INNER JOIN ";
            query += " ADM_ITEMS ON ADM_MAIN_ITEMS.MAIN_ITEM_ID = ADM_ITEMS.MAIN_ITEM_ID ORDER BY ADM_ITEMS.ITEM";
            List<Items> items = new AdminBIZ().SearchItems(query);
            ListView1.DataSource = items;
            ListView1.DataBind();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();
        }
        private void bindFields()
        {
            List<Categories> categories = new AdminBIZ().GetCategories();
            if (categories != null)
            {
                foreach (Categories row in categories)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CategoryId.ToString();
                    li.Text = row.CategoryName.ToString();
                    CategoryDDL.Items.Add(li);
                }
            }         
        }
        protected string GetCriteria()
        {
            string query = "";
            if (CategoryDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ADM_MAIN_ITEMS.CATEGORY_ID=" + CategoryDDL.SelectedItem.Value;
            }
            if (MainItemDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ADM_ITEMS.MAIN_ITEM_ID=" + MainItemDDL.SelectedItem.Value;
            }
            if (ItemDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ADM_ITEMS.ITEM_ID=" + ItemDDL.Text;
            }
            if (!(String.IsNullOrEmpty(ItemNameTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " ADM_ITEMS.ITEM LIKE '%" + ItemNameTxt.Text + "%' ";
            }
            return query;
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            searchitem();
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ItemId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidItemId");
            int Id = Convert.ToInt32(ItemId.Value);
            new AdminBIZ().DeleteItem(Id);
            searchitem();
        }
        public void searchitem()
        {
            string criteria = GetCriteria();
            if (GetCriteria() == String.Empty)
                bindListView();
            else
            {
                string query = " SELECT ADM_ITEMS.ITEM_ID, ADM_ITEMS.ITEM, ADM_ITEMS.MAIN_ITEM_ID, ADM_ITEMS.IS_ACTIVE,ADM_ITEMS.THRESHOLD_LEVEL, ADM_MAIN_ITEMS.MAIN_ITEM, ADM_MAIN_ITEMS.CATEGORY_ID, ";
                query += " ADM_CATEGORIES.CATEGORY, ADM_ITEMS.CURRENT_BALANCE ";
                query += " FROM ADM_MAIN_ITEMS INNER JOIN ";
                query += " ADM_CATEGORIES ON ADM_MAIN_ITEMS.CATEGORY_ID = ADM_CATEGORIES.CATEGORY_ID INNER JOIN ";
                query += " ADM_ITEMS ON ADM_MAIN_ITEMS.MAIN_ITEM_ID = ADM_ITEMS.MAIN_ITEM_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                query += " ORDER BY ADM_ITEMS.ITEM";
                List<Items> items = new AdminBIZ().SearchItems(query);
                ListView1.DataSource = items;
                ListView1.DataBind();
            }

        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
            ItemNameTxt.Text = "";
            CategoryDDL.SelectedValue = "0";
            MainItemDDL.Items.Clear();
            ItemDDL.Items.Clear();
            ItemDDL.Items.Add(new ListItem("Select", "0"));
            MainItemDDL.Items.Add(new ListItem("Select", "0"));
        }

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainItemDDL.Items.Clear();
            ItemDDL.Items.Clear();
            List<MainItems> mainitems = new AdminBIZ().GetMainItemsByCat(Convert.ToInt32(CategoryDDL.SelectedValue));
            ItemDDL.Items.Add(new ListItem("Select", "0"));
            MainItemDDL.Items.Add(new ListItem("Select", "0"));
            if (mainitems != null)
            {
               
                foreach (MainItems row in mainitems)
                {
                    ListItem li = new ListItem();
                    li.Value = row.MainItemId.ToString();
                    li.Text = row.MainItem.ToString();
                    MainItemDDL.Items.Add(li);
                }

            }
            searchitem();

        }

        protected void MainItemDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemDDL.Items.Clear();
            List<Items> items = new AdminBIZ().GetItemsByMainItem(Convert.ToInt32(MainItemDDL.SelectedValue));
            ItemDDL.Items.Add(new ListItem("Select", "0"));
            if (items != null)
            {

                foreach (Items row in items)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ItemId.ToString();
                    li.Text = row.ItemName.ToString();
                    ItemDDL.Items.Add(li);
                }

            }
            searchitem();

        }

        protected void ItemDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchitem();
        }

    }
}