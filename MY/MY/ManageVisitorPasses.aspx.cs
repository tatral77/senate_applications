using Entities;
using MyBIZ;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MY
{
    public partial class ManageVisitorPasses : System.Web.UI.Page
    {
        int empval=0;
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
               
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    empval = Convert.ToInt32(reqCookies["SystemUsersId"]);
                }
                BindLV();
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            string BranchId = "0";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                BranchId = reqCookies["BranchId"].ToString();
            }
            DropDownList PassTypesDDL = new DropDownList();
            PassTypesDDL = (e.Item.FindControl("PassTypeDDL") as DropDownList);
            if (PassTypesDDL != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));
               

                List<PassTypes> pt = new vmsBiz().GetPassTypes();

                foreach (PassTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PassTypeId.ToString();
                    cy.Text = row.Description.ToString();
                    PassTypesDDL.Items.Add(cy);
                }
            }


            DropDownList BrancheDDL = new DropDownList();
            BrancheDDL = (e.Item.FindControl("BranchDDL") as DropDownList);
            if (BrancheDDL != null)
            {
                ListItem temp = new ListItem();
                temp.Value = "0";
                temp.Text = "Select Branch";
                BrancheDDL.Items.Add(temp);
                List<Branch> branches = new vmsBiz().GetBranches();
                foreach (Branch branch in branches)
                {
                    ListItem li = new ListItem();
                    li.Value = branch.BranchId.ToString();
                    li.Text = branch.BranchName.ToString();
                    BrancheDDL.Items.Add(li);
                }
                BrancheDDL.SelectedValue = BranchId;
            }


        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PassTypesDDL = e.Item.FindControl("PassTypeDDL") as DropDownList;
                HiddenField HidPassTypeId = (e.Item.FindControl("HidPassTypeId") as HiddenField);
                PassTypesDDL.SelectedValue = HidPassTypeId.Value.ToString();

                DropDownList BranchDDL = e.Item.FindControl("BranchDDL") as DropDownList;
                HiddenField HidBranchId = (e.Item.FindControl("HidBranchId") as HiddenField);
                BranchDDL.SelectedValue = HidBranchId.Value.ToString();

                DropDownList IsActiveDDL = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HiIsActive = (e.Item.FindControl("HiIsActive") as HiddenField);
                IsActiveDDL.SelectedValue = HiIsActive.Value.ToString();
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
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindLV();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewVisitorpPass.aspx");
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLV();

        }
        protected void BindLV()
        {
             HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                empval = Convert.ToInt32(reqCookies["SystemUsersId"]);

            }
            List<VisitorPasses> visitorPasses = new vmsBiz().GetVisitorPasses(empval);
            LV.DataSource = visitorPasses;
            LV.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            BindLV();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField UserId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Userid = Convert.ToInt32(UserId.Value);
        //    new AdministrationBIZ().DeleteUser(Userid);
        //    BindLV();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    LV.EditIndex = -1;
        //    LV.InsertItemPosition = InsertItemPosition.None;
        //    LV.SelectedIndex = -1;

        //    BindLV();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                empval = Convert.ToInt32(reqCookies["SystemUsersId"]);
            }
            HiddenField RequestedById = LV.InsertItem.FindControl("HidRequestedById") as HiddenField;
            TextBox PassDateTxt = LV.InsertItem.FindControl("PassDateTxt") as TextBox;
            HiddenField CompanyId = LV.InsertItem.FindControl("HidCompanyId") as HiddenField;
            DropDownList PassTypeDDL = LV.InsertItem.FindControl("PassTypeDDL") as DropDownList;
            DropDownList BranchDDL = LV.InsertItem.FindControl("BranchDDL") as DropDownList;
            TextBox VisitPurposeTxt = LV.InsertItem.FindControl("VisitPurposeTxt") as TextBox;
            TextBox CompanyName = LV.InsertItem.FindControl("CompanyNameTxt") as TextBox;
            TextBox FromDateTxt = LV.InsertItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDateTxt = LV.InsertItem.FindControl("ToDateTxt") as TextBox;
            TextBox Remarks = LV.InsertItem.FindControl("RemarksTxt") as TextBox;
            CheckBox SaturdayCB = LV.InsertItem.FindControl("SaturdayCB") as CheckBox;
            CheckBox SundayCB = LV.InsertItem.FindControl("SundayCB") as CheckBox;
            DropDownList IsActiveDDL = LV.InsertItem.FindControl("IsActiveDDL") as DropDownList;
            VisitorPasses b = new VisitorPasses();
            b.RequestedById = empval;// Convert.ToInt32(RequestedById.Value);
            b.CompanyId = Convert.ToInt32(CompanyId.Value);
            b.PassDate = Convert.ToDateTime(PassDateTxt.Text);
            b.PassTypeId = Convert.ToInt32(PassTypeDDL.SelectedValue);
            b.BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            b.Company = new Companies();
            b.Company.CompanyName = Convert.ToString(CompanyName.Text);
            b.FromDate = Convert.ToDateTime(FromDateTxt.Text);
            b.ToDate = Convert.ToDateTime(ToDateTxt.Text);
            b.VisitPurpose = Convert.ToString(VisitPurposeTxt.Text);
            b.Remarks = Convert.ToString(Remarks.Text);
            b.Saturday = (SaturdayCB.Checked == true) ? 1 : 0;
            b.Sunday = (SundayCB.Checked == true) ? 1 : 0;
            b.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new vmsBiz().InsertVisitorPass(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            Response.Redirect("ManageVisitorPasses.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                empval = Convert.ToInt32(reqCookies["SystemUsersId"]);
            }
            HiddenField HidPassId = LV.EditItem.FindControl("HidPassId") as HiddenField;
            HiddenField RequestedById = LV.EditItem.FindControl("HidRequestedById") as HiddenField;
            TextBox PassDateTxt = LV.EditItem.FindControl("PassDateTxt") as TextBox;
            HiddenField CompanyId = LV.EditItem.FindControl("HidCompanyId") as HiddenField;
            DropDownList PassTypeDDL = LV.EditItem.FindControl("PassTypeDDL") as DropDownList;
            DropDownList BranchDDL = LV.EditItem.FindControl("BranchDDL") as DropDownList;
            TextBox VisitPurposeTxt = LV.EditItem.FindControl("VisitPurposeTxt") as TextBox;
            TextBox CompanyName = LV.EditItem.FindControl("CompanyNameTxt") as TextBox;
            TextBox FromDateTxt = LV.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox ToDateTxt = LV.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox Remarks = LV.EditItem.FindControl("RemarksTxt") as TextBox;
            CheckBox SaturdayCB = LV.EditItem.FindControl("SaturdayCB") as CheckBox;
            CheckBox SundayCB = LV.EditItem.FindControl("SundayCB") as CheckBox;
            DropDownList IsActiveDDL = LV.EditItem.FindControl("IsActiveDDL") as DropDownList;
            DateTime passDate, fromDate, toDate;
            MsgLbl.Text = "";
            if (!DateTime.TryParse(PassDateTxt.Text, out passDate) || !DateTime.TryParse(FromDateTxt.Text, out fromDate) || !DateTime.TryParse(ToDateTxt.Text, out toDate))
            {
                MsgLbl.Text = "Please enter valid dates (dd/mm/yyyy).";
                e.Cancel = true;
                return;
            }
            if (toDate < fromDate)
            {
                MsgLbl.Text = "The To Date cannot be earlier than the From Date.";
                e.Cancel = true;
                return;
            }
            VisitorPasses b = new VisitorPasses();
            b.PassId = HidPassId.Value;
            b.RequestedById = empval;// Convert.ToInt32(RequestedById.Value);
            b.PassDate = passDate;
            b.CompanyId = Convert.ToInt32(CompanyId.Value);
            b.PassTypeId = Convert.ToInt32(PassTypeDDL.SelectedValue);
            b.BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            b.Company = new Companies();
            b.Company.CompanyName = Convert.ToString(CompanyName.Text);
            b.FromDate = fromDate;
            b.ToDate = toDate;
            b.VisitPurpose = Convert.ToString(VisitPurposeTxt.Text);
            b.Remarks = Convert.ToString(Remarks.Text);
            b.Saturday = (SaturdayCB.Checked == true) ? 1 : 0;
            b.Sunday = (SundayCB.Checked == true) ? 1 : 0;
            b.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new vmsBiz().UpdateVisitorPass(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            Response.Redirect("ManageVisitorPasses.aspx");
        }
        protected void DetailsBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string PassId = linkButton.CommandArgument;
            Response.Redirect("~/VisitorsDetail.aspx?Id=" + PassId);

        }

        protected void Print_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string PassId = linkButton.CommandArgument;
            Response.Redirect("~/PrintPass.aspx?Id=" + PassId);
        }
        protected void PassIdTxt_TextChanged(object sender, EventArgs e)
        {
            SearchPasses();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchPasses();
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            PassIdTxt.Text = "";
            MsgLbl.Text = "";
            LV.EditIndex = -1;
            BindLV();
        }

        // only the passes of the signed-in employee can be searched
        protected void SearchPasses()
        {
            MsgLbl.Text = "";
            if (PassIdTxt.Text.Trim() == "")
            {
                BindLV();
                return;
            }
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
                empval = Convert.ToInt32(reqCookies["SystemUsersId"]);

            string query = "SELECT VIS_VISITOR_PASSES.PASS_ID, VIS_VISITOR_PASSES.REQUESTED_BY,VIS_VISITOR_PASSES.PASS_DATE, VIS_VISITOR_PASSES.VISIT_PURPOSE, VIS_VISITOR_PASSES.FROM_DATE, VIS_VISITOR_PASSES.TO_DATE, VIS_VISITOR_PASSES.REMARKS, ";
            query += " VIS_VISITOR_PASSES.IS_ACTIVE, VIS_VISITOR_PASSES.PASS_TYPE_ID, SYSTEM_USERS.F_NAME, VIS_PASS_TYPES.PASS_TYPE, SYSTEM_USERS.SYSTEM_USERS_ID, POSTS.POSTS_ID, POSTS.DESCRIPTION AS POST,  ";
            query += " BASIC_PAY_SCALES.DESCRIPTION AS BPS, VIS_VISITOR_PASSES.PASS_CODE, BRANCHES.DESCRIPTION AS BRANCH, VIS_VISITOR_PASSES.BRANCH_ID, VIS_VISITOR_PASSES.SUNDAY, VIS_VISITOR_PASSES.SATURDAY,  ";
            query += " VIS_VISITOR_PASSES.COMPANY_ID,(SELECT COMPANY_NAME FROM VIS_COMPANIES WHERE COMPANY_ID = VIS_VISITOR_PASSES.COMPANY_ID) AS COMPANY_NAME ";

            query += " FROM VIS_VISITOR_PASSES INNER JOIN ";
            query += " VIS_PASS_TYPES ON VIS_VISITOR_PASSES.PASS_TYPE_ID = VIS_PASS_TYPES.PASS_TYPE_ID INNER JOIN ";
            query += " SYSTEM_USERS ON VIS_VISITOR_PASSES.REQUESTED_BY = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " BRANCHES ON VIS_VISITOR_PASSES.BRANCH_ID = BRANCHES.BRANCHES_ID ";
            query = query + "  WHERE PASS_CODE= '" + PassIdTxt.Text.Trim().Replace("'", "''") + "' AND VIS_VISITOR_PASSES.REQUESTED_BY=" + empval;

            //if (GetCriteria() != String.Empty)
            //{
            //    query += " WHERE ";
            //    query += GetCriteria();
            //    //query += " ORDER BY EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID DESC ";
            //}
            //query += " ORDER BY QUESTIONS.NOTICE_DIARY_DATE DESC,QUESTIONS.NOTICE_DIARY_TIME  ";
            List<VisitorPasses> visitorPasses = new vmsBiz().SearchVisitorPasses(query);
            LV.DataSource = visitorPasses;
            LV.DataBind();
        }
    }
}