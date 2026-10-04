using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Management
{
    public partial class ManageMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {

                BindMenuLv();
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList MenuPositionDDL = new DropDownList();
            MenuPositionDDL = (e.Item.FindControl("MenuPositionDDL") as DropDownList);
            if (MenuPositionDDL != null)
            {
                List<MenuPositionEnt> pt = new ManagementBiz().GetMenuPositions();
                foreach (MenuPositionEnt row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.MenuPositionId.ToString();
                    cy.Text = row.MenuPosition.ToString();
                    MenuPositionDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (MenuLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList MenuPositionDDL = e.Item.FindControl("MenuPositionDDL") as DropDownList;
                HiddenField HidMenuPositionId = (e.Item.FindControl("HidMenuPositionId") as HiddenField);
                MenuPositionDDL.SelectedValue = HidMenuPositionId.Value.ToString();

                DropDownList IsActiveDDL = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActiveDDL.SelectedValue = HidIsActive.Value.ToString();
            }
        }
        public string GetStatus(int StatusId)
        {
            if (StatusId == 1)
                return "Yes";
            else
                return "No";
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            MenuLv.EditIndex = -1;
            MenuLv.InsertItemPosition = InsertItemPosition.None;
            MenuLv.SelectedIndex = -1;
            e.Cancel = true;
            BindMenuLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            MenuLv.SelectedIndex = -1;
            MenuLv.EditIndex = -1;
            MenuLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindMenuLv();

        }
        protected void BindMenuLv()
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            List<MenuesEnt> MenuesList = new ManagementBiz().GetMenus(ApplicationId);
            MenuLv.DataSource = MenuesList;
            MenuLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            MenuLv.InsertItemPosition = InsertItemPosition.None;
            MenuLv.SelectedIndex = -1;
            MenuLv.EditIndex = e.NewEditIndex;
            BindMenuLv();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField MenuId = (HiddenField)MenuLv.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Menuid = Convert.ToInt32(MenuId.Value);
        //    new AdministrationBIZ().DeleteMenu(Menuid);
        //    BindMenuLv();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    MenuLv.EditIndex = -1;
        //    MenuLv.InsertItemPosition = InsertItemPosition.None;
        //    MenuLv.SelectedIndex = -1;

        //    BindMenuLv();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox MenuTxt = MenuLv.InsertItem.FindControl("MenuTxt") as TextBox;
            TextBox Description = MenuLv.InsertItem.FindControl("DescriptionTxt") as TextBox;
            TextBox UrlTxt = MenuLv.InsertItem.FindControl("UrlTxt") as TextBox;
            TextBox SortOrderTxt = MenuLv.InsertItem.FindControl("SortOrderTxt") as TextBox;
            DropDownList MenuPositionDDL = MenuLv.InsertItem.FindControl("MenuPositionDDL") as DropDownList;
            TextBox InnerFunctionTxt = MenuLv.InsertItem.FindControl("InnerFunctionTxt") as TextBox;
            TextBox InnerCssTxt = MenuLv.InsertItem.FindControl("InnerCssTxt") as TextBox;
            DropDownList IsActive = MenuLv.InsertItem.FindControl("IsActiveDDL") as DropDownList;

            MenuesEnt b = new MenuesEnt();
            b.Menu = Convert.ToString(MenuTxt.Text);
            b.Description = Convert.ToString(Description.Text);
            b.Url = Convert.ToString(UrlTxt.Text);
            b.SortOrder = Convert.ToInt32(SortOrderTxt.Text);
            b.ApplicationId = ApplicationId;
            b.MenuPositionId = Convert.ToInt32(MenuPositionDDL.SelectedItem.Value);
            b.InnerFunction = InnerFunctionTxt.Text;
            b.InnerCss = InnerCssTxt.Text;
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().InsertMenu(b);
            MenuLv.EditIndex = -1;
            MenuLv.InsertItemPosition = InsertItemPosition.None;
            BindMenuLv();
            e.Cancel = true;
            Response.Redirect("ManageMenus.aspx?Id=" + ApplicationId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField MenuId = MenuLv.EditItem.FindControl("HidMenuId") as HiddenField;
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox MenuTxt = MenuLv.EditItem.FindControl("MenuTxt") as TextBox;
            TextBox Description = MenuLv.EditItem.FindControl("DescriptionTxt") as TextBox;
            TextBox UrlTxt = MenuLv.EditItem.FindControl("UrlTxt") as TextBox;
            TextBox SortOrderTxt = MenuLv.EditItem.FindControl("SortOrderTxt") as TextBox;
            DropDownList MenuPositionDDL = MenuLv.EditItem.FindControl("MenuPositionDDL") as DropDownList;
            TextBox InnerFunctionTxt = MenuLv.EditItem.FindControl("InnerFunctionTxt") as TextBox;
            TextBox InnerCssTxt = MenuLv.EditItem.FindControl("InnerCssTxt") as TextBox;
            DropDownList IsActive = MenuLv.EditItem.FindControl("IsActiveDDL") as DropDownList;
            MenuesEnt b = new MenuesEnt();
            b.MenuId= Convert.ToInt32(MenuId.Value);
            b.Menu = Convert.ToString(MenuTxt.Text);
            b.Description= Convert.ToString(Description.Text);
            b.Url = Convert.ToString(UrlTxt.Text);
            b.SortOrder = Convert.ToInt32(SortOrderTxt.Text);
            b.ApplicationId = ApplicationId;
            b.MenuPositionId = Convert.ToInt32(MenuPositionDDL.SelectedItem.Value);
            b.InnerFunction = InnerFunctionTxt.Text;
            b.InnerCss = InnerCssTxt.Text;
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().UpdateMenu(b);
            MenuLv.EditIndex = -1;
            BindMenuLv();
            MenuLv.InsertItemPosition = InsertItemPosition.None;
            MenuLv.SelectedIndex = -1;
            e.Cancel = true;
        }
    }
}