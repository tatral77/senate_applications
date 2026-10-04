using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageQuestionStatuses : System.Web.UI.Page
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
            List<QuestionStatuses> QuestionStatuses = new AdministrationBiz().GetQuestionStatuses();
            ListView1.DataSource = QuestionStatuses;
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
                // QuestionStatusesId = e.Item.FindControl("QuestionStatusTxt") as TextBox;
                //HiddenField HidQuestionStatusesId = (e.Item.FindControl("HidQuestionStatusesId") as HiddenField);
                //IsActive.SelectedValue = HidIsActive.Value.ToString();

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
            //TextBox QuestionStatusTxt = new TextBox();
            //QuestionStatusTxt = (e.Item.FindControl("QuestionStatusTxt") as TextBox);
            //if (QuestionStatusTxt != null)
            //{
            //    List<QuestionStatuses> ps = new QuestionBiz().GetQuestionStatuses();

            //    foreach (QuestionStatuses row in ps)
            //    {
            //        ListItem li = new ListItem();
            //        li.Value = row.QuestionStatusesId.ToString();
            //        li.Text = row.Description.ToString();
            //        QuestionStatusTxt.Items.Add(li);
            //    }

            //}

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
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("QuestionStatusTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            QuestionStatuses ep = new QuestionStatuses();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().InsertQuestionStatuses(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageQuestionStatuses.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField QuestionStatusesId = ListView1.EditItem.FindControl("HidQuestionStatusesId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("QuestionStatusTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            QuestionStatuses ep = new QuestionStatuses();
            ep.QuestionStatusesId = Convert.ToInt32(QuestionStatusesId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().UpdateQuestionStatuses(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}