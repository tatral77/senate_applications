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
    public partial class Application : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ApplicationId =  Convert.ToInt32(Request.QueryString["Id"]);
            ApplicationEnt application = new ManagementBiz().GetApplication(ApplicationId);
            NameLabel.Text = application.ApplicationName;
            if (!IsPostBack)
            {
                RolesHL.NavigateUrl = "~/ManageRoles.aspx?id=" + ApplicationId;
                UsersHL.NavigateUrl = "~/ManageUsers.aspx?id=" + ApplicationId;
                PagesHL.NavigateUrl = "~/ManagePages.aspx?id=" + ApplicationId;
                //RoleMenusHL.NavigateUrl = "~/ManageRoleMenus.aspx?id=" + ApplicationId;
                ManageMenusHL.NavigateUrl = "~/ManageMenus.aspx?id=" + ApplicationId;
            }
        }
    }
}