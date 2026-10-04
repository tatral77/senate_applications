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
    public partial class ManageMinisters : System.Web.UI.Page
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
            List<Ministers> ParliamentaryTerms = new LegislationBiz().GetAllMinisters();
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
                DropDownList PoliticalPartyDDL = e.Item.FindControl("PoliticalPartyDDL") as DropDownList;
                HiddenField HidPoliticalParty = (e.Item.FindControl("HidPoliticalPartyId") as HiddenField);
                PoliticalPartyDDL.SelectedValue = HidPoliticalParty.Value.ToString();

                DropDownList GenderDDL = e.Item.FindControl("GenderDDL") as DropDownList;
                HiddenField HidGenderId = (e.Item.FindControl("HidGenderId") as HiddenField);
                GenderDDL.SelectedValue = HidGenderId.Value.ToString();

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
            DropDownList PoliticalPartyDDL = new DropDownList();
            PoliticalPartyDDL = (e.Item.FindControl("PoliticalPartyDDL") as DropDownList);
            if (PoliticalPartyDDL != null)
            {
                List<PoliticalParty> ps = new LegislationBiz().GetPoliticalParties();
                foreach (PoliticalParty row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.PartyId.ToString();
                    li.Text = row.PartyName.ToString();
                    PoliticalPartyDDL.Items.Add(li);
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
            TextBox MinisterNameTxt = (TextBox)ListView1.InsertItem.FindControl("MinisterNameTxt");
            DropDownList PoliticalPartyDDL = (DropDownList)ListView1.InsertItem.FindControl("PoliticalPartyDDL");
            DropDownList GenderDDL = (DropDownList)ListView1.InsertItem.FindControl("GenderDDL");
            DropDownList IsActiveDDL = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            Ministers ep = new Ministers();
            ep.MinisterName = Convert.ToString(MinisterNameTxt.Text);
            ep.PoliticalPartyId = Convert.ToInt32(PoliticalPartyDDL.SelectedItem.Value);
            ep.GenderId = Convert.ToInt32(GenderDDL.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new LegislationBiz().InsertMinister(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("~/ManageMinisters.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField MinisterId = ListView1.EditItem.FindControl("HidMinisterId") as HiddenField;
            TextBox MinisterNameTxt = (TextBox)ListView1.EditItem.FindControl("MinisterNameTxt");
            DropDownList PoliticalPartyDDL = (DropDownList)ListView1.EditItem.FindControl("PoliticalPartyDDL");
            DropDownList GenderDDL = (DropDownList)ListView1.EditItem.FindControl("GenderDDL");
            DropDownList IsActiveDDL = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            Ministers ep = new Ministers();
            ep.MinisterId = Convert.ToInt32(MinisterId.Value);
            ep.MinisterName = Convert.ToString(MinisterNameTxt.Text);
            ep.PoliticalPartyId = Convert.ToInt32(PoliticalPartyDDL.SelectedItem.Value);
            ep.GenderId = Convert.ToInt32(GenderDDL.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
            new LegislationBiz().UpdateMinister(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
    }
}