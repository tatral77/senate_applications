using LegisEntities;
using LegisBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class ManageParliamentaryTerms : System.Web.UI.Page
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
            List<ParliamentaryTerms> ParliamentaryTerms = new LegislationBiz().GetParliamentaryTerms();
            ListView1.DataSource = ParliamentaryTerms;
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
                DropDownList ParliamentaryTenureDDL = e.Item.FindControl("ParliamentaryTenureDDL") as DropDownList;
                HiddenField HidParliamentaryTenureId = (e.Item.FindControl("HidParliamentaryTenureId") as HiddenField);
                ParliamentaryTenureDDL.SelectedValue = HidParliamentaryTenureId.Value.ToString();

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
            DropDownList ParliamentaryTenureDDL = new DropDownList();
            ParliamentaryTenureDDL = (e.Item.FindControl("ParliamentaryTenureDDL") as DropDownList);
            if (ParliamentaryTenureDDL != null)
            {
                List<ParliamentaryTenures> ps = new LegislationBiz().GetParliamentaryTenuress();

                foreach (ParliamentaryTenures row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ParliamentaryTenuresId.ToString();
                    li.Text = row.Description.ToString();
                    ParliamentaryTenureDDL.Items.Add(li);
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
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("ParliamentaryTermsTxt");
            DropDownList ParliamentaryTenureDDL = (DropDownList)ListView1.InsertItem.FindControl("ParliamentaryTenureDDL");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            ParliamentaryTerms ep = new ParliamentaryTerms();
            ep.Description = Convert.ToString(Description.Text);
            ep.ParliamentaryTenureId= Convert.ToInt32(ParliamentaryTenureDDL.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new LegislationBiz().InsertParliamentaryTerm(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageParliamentaryTerms.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidParliamentaryTermsId = ListView1.EditItem.FindControl("HidParliamentaryTermsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("ParliamentaryTermsTxt");
            DropDownList ParliamentaryTenureDDL = (DropDownList)ListView1.EditItem.FindControl("ParliamentaryTenureDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            ParliamentaryTerms ep = new ParliamentaryTerms();
            ep.ParliamentaryTermsId = Convert.ToInt32(HidParliamentaryTermsId.Value);
            ep.ParliamentaryTenureId = Convert.ToInt32(ParliamentaryTenureDDL.SelectedItem.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new LegislationBiz().UpdateParliamentaryTerm(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}