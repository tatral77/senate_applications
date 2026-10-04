using IPRBIZ;
using IPRENITITIES;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class ManageComposition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCompositionLV();
            }
        }

        protected void bindCompositionLV()
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            List<Composition> composition = new IPRBiz().GetComposition(VisitId);
            CompositionLV.DataSource = composition;
            CompositionLV.DataBind();
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            CompositionLV.SelectedIndex = -1;
            CompositionLV.EditIndex = -1;
            CompositionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindCompositionLV();
        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CompositionLV.InsertItemPosition = InsertItemPosition.None;
            CompositionLV.SelectedIndex = -1;
            CompositionLV.EditIndex = e.NewEditIndex;
            bindCompositionLV();
            e.Cancel = true;
        }

        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (CompositionLV.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindCompositionLV();
        //}

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (CompositionLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList VisitorStatusDDL = e.Item.FindControl("VisitorStatusDDL") as DropDownList;
                HiddenField HidVisitorStatusId = (e.Item.FindControl("HidVisitorStatusId") as HiddenField);
                VisitorStatusDDL.SelectedValue = HidVisitorStatusId.Value.ToString();

                //DropDownList VisitorTypeDDL = e.Item.FindControl("VisitorTypeDDL") as DropDownList;
                //HiddenField HidVisitorTypeId = (e.Item.FindControl("HidVisitorTypeId") as HiddenField);
                //VisitorTypeDDL.SelectedValue = HidVisitorTypeId.Value.ToString();
            }
        }

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList visitorststusddl = new DropDownList();
            visitorststusddl = (e.Item.FindControl("VisitorStatusDDL") as DropDownList);
            if (visitorststusddl != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<VisitorStatus> pt = new IPRBiz().GetVisitorStatuses();
                if (pt != null)
                {
                    foreach (VisitorStatus row in pt)
                    {
                        ListItem cy = new ListItem();
                        cy.Value = row.VisitorStatusId.ToString();
                        cy.Text = row.VisitorStatudDesc.ToString();
                        visitorststusddl.Items.Add(cy);
                    }
                }
            }

            //DropDownList visitortypeddl = new DropDownList();
            //visitortypeddl = (e.Item.FindControl("VisitorTypeDDL") as DropDownList);
            //if (visitortypeddl != null)
            //{
            //    //designation.Items.Add(new ListItem("Select", "0"));

            //    List<VisitorType> vt = new IPRBiz().GetVisitorTypes();
            //    if (vt != null)
            //    {
            //        foreach (VisitorType row in vt)
            //        {
            //            ListItem vtt = new ListItem();
            //            vtt.Value = row.VisitorTypeId.ToString();
            //            vtt.Text = row.VisitorTypeDesc.ToString();
            //            visitortypeddl.Items.Add(vtt);
            //        }
            //    }
            //}
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField CompositionId = (HiddenField)CompositionLV.Items[e.ItemIndex].FindControl("HidCompositionId");
            new IPRBiz().DeleteComposition(Convert.ToInt32(CompositionId.Value));
            bindCompositionLV();
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            CompositionLV.EditIndex = -1;
            CompositionLV.InsertItemPosition = InsertItemPosition.None;
            CompositionLV.SelectedIndex = -1;
            bindCompositionLV();
            e.Cancel = true;
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int Visit = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidSystemUserId = (HiddenField)CompositionLV.InsertItem.FindControl("HidSystemUserId");
            HiddenField CategoryId = (HiddenField)CompositionLV.InsertItem.FindControl("HidCategoryId");
            HiddenField IsEmployee = (HiddenField)CompositionLV.InsertItem.FindControl("HidIsEmployee");
            HiddenField Designation = (HiddenField)CompositionLV.InsertItem.FindControl("HidDesignation");
            // DropDownList VisitorTypeDDL = CompositionLV.InsertItem.FindControl("VisitorTypeDDL") as DropDownList;
            DropDownList VisitorStatusDDL = CompositionLV.InsertItem.FindControl("VisitorStatusDDL") as DropDownList;
            TextBox VisitorStatusDateTxt = (TextBox)CompositionLV.InsertItem.FindControl("VisitorStatusDateTxt");
            TextBox RemarksTxt = (TextBox)CompositionLV.InsertItem.FindControl("RemarksTxt");
            CheckBox IsChairmanCB = (CheckBox)CompositionLV.InsertItem.FindControl("IsChairmanCB");
            Composition ep = new Composition();
            ep.VisitId = Visit;
            ep.SystemUserId = Convert.ToInt32(HidSystemUserId.Value);
            ep.CategoryId = Convert.ToInt32(CategoryId.Value);
            ep.Post = Convert.ToString(Designation.Value);
            ep.IsChairman = (IsChairmanCB.Checked) ? 1 : 0;
            ep.IsEmployee = Convert.ToInt32(IsEmployee.Value);
            if (ep.IsChairman == 1)
                ep.Post = "Chairman";
            // ep.VisitorTypeId = Convert.ToInt32(VisitorTypeDDL.SelectedValue);
            ep.VisitorStatusId = Convert.ToInt32(VisitorStatusDDL.SelectedValue);
            ep.VisitorStatusDate = Convert.ToDateTime(VisitorStatusDateTxt.Text);
            ep.Remarks = Convert.ToString(RemarksTxt.Text);
            new IPRBiz().InsertComposition(ep);
            CompositionLV.EditIndex = -1;
            CompositionLV.InsertItemPosition = InsertItemPosition.None;
            bindCompositionLV();
            e.Cancel = true;
            Response.Redirect("ManageComposition.aspx?Id=" + Visit);

        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidCompositionId = (HiddenField)CompositionLV.EditItem.FindControl("HidCompositionId");
            HiddenField HidSystemUserId = (HiddenField)CompositionLV.EditItem.FindControl("HidSystemUserId");
            HiddenField CategoryId = (HiddenField)CompositionLV.EditItem.FindControl("HidCategoryId");
            HiddenField IsEmployee = (HiddenField)CompositionLV.EditItem.FindControl("HidIsEmployee");
            HiddenField Designation = (HiddenField)CompositionLV.EditItem.FindControl("HidDesignation");
            //  DropDownList VisitorTypeDDL = CompositionLV.EditItem.FindControl("VisitorTypeDDL") as DropDownList;
            DropDownList VisitorStatusDDL = CompositionLV.EditItem.FindControl("VisitorStatusDDL") as DropDownList;
            TextBox VisitorStatusDateTxt = (TextBox)CompositionLV.EditItem.FindControl("VisitorStatusDateTxt");
            TextBox RemarksTxt = (TextBox)CompositionLV.EditItem.FindControl("RemarksTxt");
            CheckBox IsChairmanCB = (CheckBox)CompositionLV.EditItem.FindControl("IsChairmanCB");
            Composition ep = new Composition();
            ep.CompositionId = Convert.ToInt32(HidCompositionId.Value);
            ep.SystemUserId = Convert.ToInt32(HidSystemUserId.Value);
            ep.Post = Convert.ToString(Designation.Value);
            ep.CategoryId = Convert.ToInt32(CategoryId.Value);
            ep.IsChairman = (IsChairmanCB.Checked) ? 1 : 0;
            if (ep.IsChairman == 1)
                ep.Post = "Chairman";
            //ep.VisitorTypeId = Convert.ToInt32(VisitorTypeDDL.SelectedValue);
            ep.VisitorStatusId = Convert.ToInt32(VisitorStatusDDL.SelectedValue);
            ep.VisitorStatusDate = Convert.ToDateTime(VisitorStatusDateTxt.Text);
            ep.Remarks = Convert.ToString(RemarksTxt.Text);
            new IPRBiz().UpdateComposition(ep);
            CompositionLV.EditIndex = -1;
            CompositionLV.InsertItemPosition = InsertItemPosition.None;
            bindCompositionLV();
            e.Cancel = true;
        }
    }
}