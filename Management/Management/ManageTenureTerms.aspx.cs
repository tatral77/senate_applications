using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataEntities;
using BIZ;

namespace Management
{
    public partial class ManageTenureTerms : System.Web.UI.Page
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
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            ParliamentaryTenures tenure = new DataManagementBIZ().GetParliamentaryTenure(Id);
            headinglbl.InnerText = "TENURE TERMS (" + tenure.Description + ")";
            List<ParliamentaryTenureTerm> ParliamentaryPeriods = new DataManagementBIZ().GetParliamentaryTenureTerms(Id);
            ListView1.DataSource = ParliamentaryPeriods;
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
                DropDownList ParliamentaryTermDDL = (e.Item.FindControl("ParliamentaryTermDDL") as DropDownList);
                HiddenField HidParliamentaryTermId = (e.Item.FindControl("HidParliamentaryTermId") as HiddenField);
                ParliamentaryTermDDL.SelectedValue = HidParliamentaryTermId.Value.ToString();
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
            DropDownList ParliamentaryTermDDL = new DropDownList();
            ParliamentaryTermDDL = (e.Item.FindControl("ParliamentaryTermDDL") as DropDownList);
            if (ParliamentaryTermDDL != null)
            {
                List<ParliamentaryTerms> ps = new DataManagementBIZ().GetParliamentaryTerms();

                foreach (ParliamentaryTerms row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ParliamentaryTermsId.ToString();
                    li.Text = row.Description.ToString();
                    ParliamentaryTermDDL.Items.Add(li);
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
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            DropDownList ParliamentaryTermDDL = (DropDownList)ListView1.InsertItem.FindControl("ParliamentaryTermDDL");
            ParliamentaryTenureTerm ep = new ParliamentaryTenureTerm();
            ep.ParliamentaryTenureId= Id;
            ep.ParliamentaryTermId = Convert.ToInt32(ParliamentaryTermDDL.SelectedItem.Value);
            new DataManagementBIZ().InsertParliamentaryTenureTerm(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
            Response.Redirect("ManageTenureTerms.aspx?Id=" + Id);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField ParliamentaryTenureTermId = ListView1.EditItem.FindControl("HidParliamentaryTenureTermsId") as HiddenField;
            DropDownList ParliamentaryTermDDL = (DropDownList)ListView1.EditItem.FindControl("ParliamentaryTermDDL");
            ParliamentaryTenureTerm ep = new ParliamentaryTenureTerm();
            ep.ParliamentaryTenureId = Id;
            ep.ParliamentaryTenureTermId= Convert.ToInt32(ParliamentaryTenureTermId.Value);
            ep.ParliamentaryTermId = Convert.ToInt32(ParliamentaryTermDDL.SelectedItem.Value);
            new DataManagementBIZ().UpdateParliamentaryTenureTerm(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
    }
}