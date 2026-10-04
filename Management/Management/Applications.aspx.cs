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
    public partial class Applications : System.Web.UI.Page
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
                BindApplicationLV();
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
            ApplicationLV.EditIndex = -1;
            ApplicationLV.InsertItemPosition = InsertItemPosition.None;
            ApplicationLV.SelectedIndex = -1;

            e.Cancel = true;

            BindApplicationLV();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            ApplicationLV.SelectedIndex = -1;
            ApplicationLV.EditIndex = -1;
            ApplicationLV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindApplicationLV();

        }
        protected void BindApplicationLV()
        {
            List<ApplicationEnt> ApplicationEntesList = new ManagementBiz().GetApplications();
            ApplicationLV.DataSource = ApplicationEntesList;
            ApplicationLV.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ApplicationLV.InsertItemPosition = InsertItemPosition.None;
            ApplicationLV.SelectedIndex = -1;
            ApplicationLV.EditIndex = e.NewEditIndex;
            BindApplicationLV();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField ApplicationEntId = (HiddenField)ApplicationLV.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int ApplicationEntid = Convert.ToInt32(ApplicationEntId.Value);
        //    new ManagementBiz().DeleteApplicationEnt(ApplicationEntid);
        //    BindApplicationLV();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    ApplicationLV.EditIndex = -1;
        //    ApplicationLV.InsertItemPosition = InsertItemPosition.None;
        //    ApplicationLV.SelectedIndex = -1;

        //    BindApplicationLV();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            //int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox ApplicationTxt = (TextBox)ApplicationLV.InsertItem.FindControl("ApplicationTxt");
            ApplicationEnt b = new ApplicationEnt();
            // if (fuControl != null && PhoneNum != null)
            // {
            b.ApplicationName = Convert.ToString(ApplicationTxt.Text);
            new ManagementBiz().InsertApplication(b);
            ApplicationLV.EditIndex = -1;
            ApplicationLV.InsertItemPosition = InsertItemPosition.None;
            BindApplicationLV();
            //  }
            e.Cancel = true;
            Response.Redirect("Applications.aspx");


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField ApplicationEntId = (HiddenField)ApplicationLV.Items[e.ItemIndex].FindControl("HidDepartmentId");
            TextBox Description = ApplicationLV.EditItem.FindControl("DescriptionTxt") as TextBox;
            DropDownList IsActive = ApplicationLV.EditItem.FindControl("IsActiveDDL") as DropDownList;
            ApplicationEnt b = new ApplicationEnt();
            //b.ApplicationEntid = Convert.ToInt32(ApplicationEntId.Value);
            //b.Description = Convert.ToString(Description.Text);
            //b.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            //new ManagementBiz().UpdateApplicationEnt(b);
            ApplicationLV.EditIndex = -1;
            BindApplicationLV();
            ApplicationLV.InsertItemPosition = InsertItemPosition.None;
            ApplicationLV.SelectedIndex = -1;
            e.Cancel = true;



        }
    }
}