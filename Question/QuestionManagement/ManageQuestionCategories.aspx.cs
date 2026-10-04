using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace QuestionManagement
{
    public partial class ManageQuestionCategories : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
            }

        }
        protected void bindListView1()
        {
            List<QuestionCategories> QuestionCategories = new AdministrationBiz().GetQuestionCategories();
            ListView1.DataSource = QuestionCategories;
            ListView1.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.FirstItem;
            bindListView1();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = e.NewEditIndex;
            bindListView1();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList QuestionCategoriesDDL = e.Item.FindControl("QuestionCategoriesDDL") as DropDownList;
                HiddenField HidQuestionCategoriesId = (e.Item.FindControl("HidQuestionCategoriesId") as HiddenField);
                //QuestionCategoriesDDL.SelectedValue = HidQuestionCategoriesId.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();


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
            DropDownList QuestionCategoriesDDL = new DropDownList();
            QuestionCategoriesDDL = (e.Item.FindControl("QuestionCategoriesDDL") as DropDownList);
            if (QuestionCategoriesDDL != null)
            {
                List<QuestionCategories> ps = new AdministrationBiz().GetQuestionCategories();

                foreach (QuestionCategories row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.QuestionCategoriesId.ToString();
                    li.Text = row.Description.ToString();
                    QuestionCategoriesDDL.Items.Add(li);
                }

            }

        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            bindListView1();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            //HiddenField QuestionCategoriesId = ListView1.InsertItem.FindControl("HidQuestionCategoriesId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("QuestionCategoriesTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            QuestionCategories ep = new QuestionCategories();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);

            new AdministrationBiz().InsertQuestionCategory(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageQuestionCategories.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField QuestionCategoriesId = ListView1.InsertItem.FindControl("HidQuestionCategoriesId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("QuestionCategoriesTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            QuestionCategories ep = new QuestionCategories();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);

            new AdministrationBiz().UpdateQuestionCategory(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

        }
    }
}