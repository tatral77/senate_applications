using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class BranchesInfo : System.Web.UI.Page
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
                BindBranchLv();
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
            BranchLv.EditIndex = -1;
            BranchLv.InsertItemPosition = InsertItemPosition.None;
            BranchLv.SelectedIndex = -1;

            e.Cancel = true;

            BindBranchLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            BranchLv.SelectedIndex = -1;
            BranchLv.EditIndex = -1;
            BranchLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindBranchLv();

        }
        protected void BindBranchLv()
        {
            List<Branch> BranchesList = new AdministrationBIZ().GetAllBranches();
            BranchLv.DataSource = BranchesList;
            BranchLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            BranchLv.InsertItemPosition = InsertItemPosition.None;
            BranchLv.SelectedIndex = -1;
            BranchLv.EditIndex = e.NewEditIndex;
            BindBranchLv();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField BranchId = (HiddenField)BranchLv.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Branchid = Convert.ToInt32(BranchId.Value);
        //    new AdministrationBIZ().DeleteBranch(Branchid);
        //    BindBranchLv();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    BranchLv.EditIndex = -1;
        //    BranchLv.InsertItemPosition = InsertItemPosition.None;
        //    BranchLv.SelectedIndex = -1;

        //    BindBranchLv();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            //int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox Description = (TextBox)BranchLv.InsertItem.FindControl("DescriptionTxt");
            DropDownList IsActive = (DropDownList)BranchLv.InsertItem.FindControl("IsActiveDDL");
            Branch b = new Branch();
            // if (fuControl != null && PhoneNum != null)
            // {
            b.Description = Convert.ToString(Description.Text);
            b.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBIZ().InsertBranch(b);
            BranchLv.EditIndex = -1;

            BranchLv.InsertItemPosition = InsertItemPosition.None;
            BindBranchLv();
            //  }
            e.Cancel = true;
            Response.Redirect("BranchesInfo.aspx");


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField BranchId = (HiddenField)BranchLv.Items[e.ItemIndex].FindControl("HidDepartmentId");
            TextBox Description = BranchLv.EditItem.FindControl("DescriptionTxt") as TextBox;
            DropDownList IsActive = BranchLv.EditItem.FindControl("IsActiveDDL") as DropDownList;
            Branch b = new Branch();
            b.Branchid = Convert.ToInt32(BranchId.Value);
            b.Description = Convert.ToString(Description.Text);
            b.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBIZ().UpdateBranch(b);
            BranchLv.EditIndex = -1;
            BindBranchLv();
            BranchLv.InsertItemPosition = InsertItemPosition.None;
            BranchLv.SelectedIndex = -1;
            e.Cancel = true;



        }
    }
}