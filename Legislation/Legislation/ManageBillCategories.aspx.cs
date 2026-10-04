using LegisBIZ;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class ManageBillCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListview();
            }
        }
        protected void BindListview()
        {
            List<BillCategories> billStatuses = new LegislationBiz().GetAllBillCategories();
            lv.DataSource = billStatuses;
            lv.DataBind();
        }

        protected void lv_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField BillStatusId = lv.EditItem.FindControl("HidDivisionsId") as HiddenField;

        }

        protected void lv_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lv.InsertItemPosition = InsertItemPosition.None;
            lv.SelectedIndex = -1;
            lv.EditIndex = e.NewEditIndex;
            BindListview();
            e.Cancel = true;
        }

        protected void lv_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lv.EditIndex = -1;
            lv.InsertItemPosition = InsertItemPosition.None;
            lv.SelectedIndex = -1;
            BindListview();
            e.Cancel = true;
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            lv.SelectedIndex = -1;
            lv.EditIndex = -1;
            lv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindListview();
        }

        protected void lv_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox Description = (TextBox)lv.InsertItem.FindControl("DescriptionTxt");
            DropDownList IsActive = (DropDownList)lv.InsertItem.FindControl("IsActiveDDL");
            BillCategories ep = new BillCategories();

            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new LegislationBiz().InsertBillCategory(ep);
            //  }
            e.Cancel = true;

            Response.Redirect("ManageBillCategories.aspx");
        }

        protected void lv_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField BillCategoriesId = lv.EditItem.FindControl("HidCategoryId") as HiddenField;
            TextBox Description = (TextBox)lv.EditItem.FindControl("DescriptionTxt");
            DropDownList IsActive = (DropDownList)lv.EditItem.FindControl("IsActiveDDL");
            BillCategories ep = new BillCategories();
            ep.BillCategoriesId = Convert.ToInt32(BillCategoriesId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new LegislationBiz().UpdateBillCategory(ep);
            lv.EditIndex = -1;

            lv.InsertItemPosition = InsertItemPosition.None;
            BindListview();
            //  }
            e.Cancel = true;
        }
        protected void lv_DataBound(object sender, ListViewItemEventArgs e)
        {
            if (lv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {


                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();


            }
        }
    }
}