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
    public partial class ManageRoleMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
                Role menu = new ManagementBiz().GetRole(RoleId);
                heading1.InnerText = "ROLE" + " ("+ menu.RoleName + ")";
                BindAllPages();
                BindMenuPages();
            }


        }
        public void ClearListBoxes()
        {

            AllMenusLB.Items.Clear();
            RolMenuesLB.Items.Clear();


        }
        protected void Out_Click(object sender, EventArgs e)
        {
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            new ManagementBiz().DeleteRoleMenu(RoleId,Convert.ToInt32(RolMenuesLB.SelectedItem.Value));
            ClearListBoxes();
            BindAllPages();
            BindMenuPages();
        }
        protected void In_Click(object sender, EventArgs e)
        {
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            RoleMenus rm = new RoleMenus();
            rm.RoleId = RoleId;
            rm.MenuId = Convert.ToInt32(AllMenusLB.SelectedItem.Value);
            new ManagementBiz().InsertRoleMenu(rm);
            ClearListBoxes();
            BindAllPages();
            BindMenuPages();
        }

        public void BindAllPages()
        {
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            int AppId = Convert.ToInt32(Request.QueryString["Id"]);
            List<MenuesEnt> menupages = new ManagementBiz().GetUnAssignedRoleMenus(RoleId, AppId);
            if (menupages != null)
            {
                foreach (MenuesEnt mp in menupages)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(mp.MenuId);
                    Temp.Text = Convert.ToString(mp.Menu  + " (" + mp.Description + ")");
                    AllMenusLB.Items.Add(Temp);
                }
            }
        }
        public void BindMenuPages()
        {
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);

            List<RoleMenus> menupages = new ManagementBiz().GetRoleMenus(RoleId);
            if (menupages != null)
            {
                foreach (RoleMenus mp in menupages)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(mp.MenuId);
                    Temp.Text = Convert.ToString(mp.Menu + " (" + mp.Description + ")");
                    RolMenuesLB.Items.Add(Temp);
                }
            }
        }
    }
}