using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VisitorManagement
{
    public partial class VisitorsDetail : System.Web.UI.Page
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

                BindLV();
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList PassTypesDDL = new DropDownList();
            PassTypesDDL = (e.Item.FindControl("PassTypeDDL") as DropDownList);
            if (PassTypesDDL != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<PassTypes> pt = new Biz().GetPassTypes();

                foreach (PassTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PassTypeId.ToString();
                    cy.Text = row.Description.ToString();
                    PassTypesDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PassTypesDDL = e.Item.FindControl("PassTypesDDL") as DropDownList;
                HiddenField HidPassTypeId = (e.Item.FindControl("HidPassTypeId") as HiddenField);
                PassTypesDDL.SelectedValue = HidPassTypeId.Value.ToString();
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
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLV();

        }
        protected void BindLV()
        {
            string id = Convert.ToString(Request.QueryString["Id"]);
            List<Visitors> visitors = new Biz().GetVisitors(id);
            LV.DataSource = visitors;
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

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidVisitorId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidVisitorId");
            int VisitorId = Convert.ToInt32(HidVisitorId.Value);
            new Biz().DeleteVisitor(VisitorId);
            BindLV();
        }
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
            string id = Convert.ToString(Request.QueryString["Id"]);
            TextBox VisitorNameTxt = LV.InsertItem.FindControl("VisitorNameTxt") as TextBox;
            TextBox CnicTxt = LV.InsertItem.FindControl("CnicTxt") as TextBox;
            TextBox DetailsTxt = LV.InsertItem.FindControl("DetailsTxt") as TextBox;
            Visitors b = new Visitors();
            b.VisitorName = Convert.ToString(VisitorNameTxt.Text);
            b.Cnic = Convert.ToString(CnicTxt.Text);
            b.Details = Convert.ToString(DetailsTxt.Text);
            b.PassId = id;
            new Biz().InsertVisitor(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            Response.Redirect("VisitorsDetail.aspx?Id=" + id);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string id = Convert.ToString(Request.QueryString["Id"]);
            HiddenField HidVisitorId = LV.EditItem.FindControl("HidVisitorId") as HiddenField;
            TextBox VisitorNameTxt = LV.EditItem.FindControl("VisitorNameTxt") as TextBox;
            TextBox CnicTxt = LV.EditItem.FindControl("CnicTxt") as TextBox;
            TextBox DetailsTxt = LV.EditItem.FindControl("DetailsTxt") as TextBox;
            Visitors b = new Visitors();
            b.VisitorId = Convert.ToInt32(HidVisitorId.Value);
            b.VisitorName = Convert.ToString(VisitorNameTxt.Text);
            b.Cnic = Convert.ToString(CnicTxt.Text);
            b.Details = Convert.ToString(DetailsTxt.Text);
            b.PassId = id;
            new Biz().UpdateVisitor(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            Response.Redirect("VisitorsDetail.aspx?Id=" + id);
        }
       
    }
}