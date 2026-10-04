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
    public partial class ManageRoles : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["loginstatus"];
            //if (userinfo != null)
            //{
            //    string role = userinfo.Value;
            //    if (role.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            if (!IsPostBack)
            {
                BindRoleLv();
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
            RoleLv.EditIndex = -1;
            RoleLv.InsertItemPosition = InsertItemPosition.None;
            RoleLv.SelectedIndex = -1;

            e.Cancel = true;

            BindRoleLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            RoleLv.SelectedIndex = -1;
            RoleLv.EditIndex = -1;
            RoleLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindRoleLv();

        }
        protected void BindRoleLv()
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            List<Role> RolesList = new ManagementBiz().GetApplicationRoles(ApplicationId);
            RoleLv.DataSource = RolesList;
            RoleLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            RoleLv.InsertItemPosition = InsertItemPosition.None;
            RoleLv.SelectedIndex = -1;
            RoleLv.EditIndex = e.NewEditIndex;
            BindRoleLv();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField RoleId = (HiddenField)RoleLv.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Roleid = Convert.ToInt32(RoleId.Value);
        //    new AdministrationBIZ().DeleteRole(Roleid);
        //    BindRoleLv();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    RoleLv.EditIndex = -1;
        //    RoleLv.InsertItemPosition = InsertItemPosition.None;
        //    RoleLv.SelectedIndex = -1;

        //    BindRoleLv();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox RoleNameTxt = (TextBox)RoleLv.InsertItem.FindControl("RoleNameTxt");
            DropDownList IsActive = (DropDownList)RoleLv.InsertItem.FindControl("IsActiveDDL");
            Role b = new Role();
            b.ApplicationId = ApplicationId;
            b.RoleName = Convert.ToString(RoleNameTxt.Text);
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().InsertRole(b);
            RoleLv.EditIndex = -1;
            RoleLv.InsertItemPosition = InsertItemPosition.None;
            BindRoleLv();
            e.Cancel = true;
            Response.Redirect("ManageRoles.aspx?Id=" + ApplicationId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField RoleId = RoleLv.EditItem.FindControl("HidRoleId") as HiddenField;
            TextBox RoleNameTxt = RoleLv.EditItem.FindControl("RoleNameTxt") as TextBox; 
            DropDownList IsActive = RoleLv.EditItem.FindControl("IsActiveDDL") as DropDownList;
            Role b = new Role();
            b.RoleId = Convert.ToInt32(RoleId.Value);
            b.RoleName = Convert.ToString(RoleNameTxt.Text);
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().UpdateRole(b);
            RoleLv.EditIndex = -1;
            BindRoleLv();
            RoleLv.InsertItemPosition = InsertItemPosition.None;
            RoleLv.SelectedIndex = -1;
            e.Cancel = true;
        }
    }
}