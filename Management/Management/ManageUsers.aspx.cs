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
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["loginstatus"];
            //if (userinfo != null)
            //{
            //    string User = userinfo.Value;
            //    if (User.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            if (!IsPostBack)
            {

                BindUserLv();
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList UserTypeDDL = new DropDownList();
            UserTypeDDL = (e.Item.FindControl("UserTypeDDL") as DropDownList);
            if (UserTypeDDL != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<UserTypes> pt = new ManagementBiz().GetUserTypes();

                foreach (UserTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.UserTypeId.ToString();
                    cy.Text = row.UserType.ToString();
                    UserTypeDDL.Items.Add(cy);
                }
            }

            DropDownList RoleDDL = new DropDownList();
            RoleDDL = (e.Item.FindControl("RoleDDL") as DropDownList);
            if (UserTypeDDL != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));
                int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
                List<Role> roles = new ManagementBiz().GetApplicationRoles(ApplicationId);
                foreach (Role row in roles)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.RoleId.ToString();
                    cy.Text = row.RoleName.ToString();
                    RoleDDL.Items.Add(cy);
                }
            }


        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (UserLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList UserTypeDDL = e.Item.FindControl("UserTypeDDL") as DropDownList;
                HiddenField HidUserTypeId = (e.Item.FindControl("HidUserTypeId") as HiddenField);
                UserTypeDDL.SelectedValue = HidUserTypeId.Value.ToString();

                DropDownList RoleDDL = e.Item.FindControl("RoleDDL") as DropDownList;
                HiddenField HidRoleId = (e.Item.FindControl("HidRoleId") as HiddenField);
                RoleDDL.SelectedValue = HidRoleId.Value.ToString();
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
            UserLv.EditIndex = -1;
            UserLv.InsertItemPosition = InsertItemPosition.None;
            UserLv.SelectedIndex = -1;
            e.Cancel = true;
            BindUserLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            UserLv.SelectedIndex = -1;
            UserLv.EditIndex = -1;
            UserLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindUserLv();

        }
        protected void BindUserLv()
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            List<Users> UseresList = new ManagementBiz().GetUsers(ApplicationId);
            UserLv.DataSource = UseresList;
            UserLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            UserLv.InsertItemPosition = InsertItemPosition.None;
            UserLv.SelectedIndex = -1;
            UserLv.EditIndex = e.NewEditIndex;
            BindUserLv();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField UserId = (HiddenField)UserLv.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Userid = Convert.ToInt32(UserId.Value);
        //    new AdministrationBIZ().DeleteUser(Userid);
        //    BindUserLv();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    UserLv.EditIndex = -1;
        //    UserLv.InsertItemPosition = InsertItemPosition.None;
        //    UserLv.SelectedIndex = -1;

        //    BindUserLv();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox FullNameTxt = UserLv.InsertItem.FindControl("FullNameTxt") as TextBox;
            TextBox UserNameTxt = UserLv.InsertItem.FindControl("UserNameTxt") as TextBox;
            TextBox PasswordTxt = UserLv.InsertItem.FindControl("PasswordTxt") as TextBox;
            DropDownList UserTypeDDL = UserLv.InsertItem.FindControl("UserTypeDDL") as DropDownList;
            DropDownList RoleDDL = UserLv.InsertItem.FindControl("RoleDDL") as DropDownList;
            DropDownList IsActive = UserLv.InsertItem.FindControl("IsActiveDDL") as DropDownList;
            Users b = new Users();
            b.FullName = Convert.ToString(FullNameTxt.Text);
            b.UserName = Convert.ToString(UserNameTxt.Text);
            b.Password = Convert.ToString(PasswordTxt.Text);
            b.ApplicationId = ApplicationId;
            b.UserTypeId = Convert.ToInt32(UserTypeDDL.SelectedItem.Value);
            b.RoleId = Convert.ToInt32(RoleDDL.SelectedItem.Value);
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().InsertUser(b);
            UserLv.EditIndex = -1;
            UserLv.InsertItemPosition = InsertItemPosition.None;
            BindUserLv();
            e.Cancel = true;
            Response.Redirect("ManageUsers.aspx?Id=" + ApplicationId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField UserId = UserLv.EditItem.FindControl("HidUserId") as HiddenField;
            TextBox FullNameTxt = UserLv.EditItem.FindControl("FullNameTxt") as TextBox;
            TextBox UserNameTxt = UserLv.EditItem.FindControl("UserNameTxt") as TextBox;
            TextBox PasswordTxt = UserLv.EditItem.FindControl("PasswordTxt") as TextBox;
            DropDownList UserTypeDDL = UserLv.EditItem.FindControl("UserTypeDDL") as DropDownList;
            DropDownList RoleDDL = UserLv.EditItem.FindControl("RoleDDL") as DropDownList;
            DropDownList IsActive = UserLv.EditItem.FindControl("IsActiveDDL") as DropDownList;
            Users b = new Users();
            b.UserId = Convert.ToInt32(UserId.Value);
            b.FullName= Convert.ToString(FullNameTxt.Text);
            b.UserName = Convert.ToString(UserNameTxt.Text);
            b.Password=Convert.ToString(PasswordTxt.Text);
            b.UserTypeId = Convert.ToInt32(UserTypeDDL.SelectedItem.Value);
            b.RoleId = Convert.ToInt32(RoleDDL.SelectedItem.Value);
            b.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new ManagementBiz().UpdateUser(b);
            UserLv.EditIndex = -1;
            BindUserLv();
            UserLv.InsertItemPosition = InsertItemPosition.None;
            UserLv.SelectedIndex = -1;
            e.Cancel = true;
        }
    }
}