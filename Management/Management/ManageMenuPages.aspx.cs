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
    public partial class ManageMenuPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
                MenuesEnt menu = new ManagementBiz().GetMenu(MenuId);
                heading1.InnerText = menu.Menu + " (" + menu.Description+")";
                BindAllPages();
                BindMenuPages();
            }
           

        }
        public void ClearListBoxes()
        {

            AllPagesLB.Items.Clear();
            MenuPagesLB.Items.Clear();
         

        }
        protected void Out_Click(object sender, EventArgs e)
        {
            int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            new ManagementBiz().DeleteMenuPage(Convert.ToInt32(MenuPagesLB.SelectedItem.Value),MenuId);
            ClearListBoxes();
            BindAllPages();
            BindMenuPages();
        }
        protected void In_Click(object sender, EventArgs e)
        {
            int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            new ManagementBiz().InsertMenuPage(Convert.ToInt32(AllPagesLB.SelectedItem.Value),MenuId);
            ClearListBoxes();
            BindAllPages();
            BindMenuPages();

        }

        public void BindAllPages()
        {
            int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            int AppId = Convert.ToInt32(Request.QueryString["Id"]);
            List<MenuPages> menupages = new ManagementBiz().GetUnAssignedPages(MenuId, AppId);
            if (menupages != null)
            {
                foreach (MenuPages mp in menupages)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(mp.PageId);
                    Temp.Text = Convert.ToString(mp.PageTitle);
                    AllPagesLB.Items.Add(Temp);
                }
            }
        }
        public void BindMenuPages()
        {
            int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
        
            List<MenuPages> menupages = new ManagementBiz().GetMenuPages(MenuId);
            if (menupages != null)
            {
                foreach (MenuPages mp in menupages)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(mp.PageId);
                    Temp.Text = Convert.ToString(mp.PageTitle);
                    MenuPagesLB.Items.Add(Temp);
                }
            }
        }

    }
}