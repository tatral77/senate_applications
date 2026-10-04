using CommitteesEntities;
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
    public partial class ManageCommittees : System.Web.UI.Page
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
            ParliamentaryTerms parliamentaryTerms = new CommitteesBiz().GetActiveParliamentaryTerm();
            List<Committees> committees = new CommitteesBiz().GetCommitteesByParliamentaryTerm(parliamentaryTerms.ParliamentaryTermsId);
            ListView1.DataSource = committees;
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
                DropDownList CommitteeTypeDDL = e.Item.FindControl("CommitteeTypeDDL") as DropDownList;
                HiddenField HidCommitteeTypeId = (e.Item.FindControl("HidCommitteeTypeId") as HiddenField);
                CommitteeTypeDDL.SelectedValue = HidCommitteeTypeId.Value.ToString();

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
            DropDownList CommitteeTypeDDL = new DropDownList();
            CommitteeTypeDDL = (e.Item.FindControl("CommitteeTypeDDL") as DropDownList);
            if (CommitteeTypeDDL != null)
            {
                List<CommitteeTypes> ps = new CommitteesBiz().GetCommitteesTypes();

                foreach (CommitteeTypes row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CommitteeTypeId.ToString();
                    li.Text = row.CommitteeType.ToString();
                    CommitteeTypeDDL.Items.Add(li);
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
            ParliamentaryTerms parliamentaryTerms = new CommitteesBiz().GetActiveParliamentaryTerm();
            TextBox CommitteeNameTxt = (TextBox)ListView1.InsertItem.FindControl("CommitteeNameTxt");
            DropDownList CommitteeTypeDDL = (DropDownList)ListView1.InsertItem.FindControl("CommitteeTypeDDL");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromationDate = (TextBox)ListView1.InsertItem.FindControl("FromationDateTxt");
            Committees ep = new Committees();
            ep.CommitteeName = Convert.ToString(CommitteeNameTxt.Text);
            ep.CommitteeTypeId = Convert.ToInt32(CommitteeTypeDDL.SelectedItem.Value);
            ep.ParliamentaryTermId = parliamentaryTerms.ParliamentaryTermsId;
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            if (String.IsNullOrEmpty(FromationDate.Text))
                ep.FormationDate = DateTime.Now;
            else
                ep.FormationDate = Convert.ToDateTime(FromationDate.Text);
            new CommitteesBiz().InsrtCommittee(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageCommittees.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidCommitteeId = ListView1.EditItem.FindControl("HidCommitteeId") as HiddenField;
            TextBox CommitteeNameTxt = (TextBox)ListView1.EditItem.FindControl("CommitteeNameTxt");
            DropDownList CommitteeTypeDDL = (DropDownList)ListView1.EditItem.FindControl("CommitteeTypeDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromationDate = (TextBox)ListView1.EditItem.FindControl("FromationDateTxt");
            Committees ep = new Committees();
            ep.CommitteesId= Convert.ToInt32(HidCommitteeId.Value);
            ep.CommitteeName = Convert.ToString(CommitteeNameTxt.Text);
            ep.CommitteeTypeId = Convert.ToInt32(CommitteeTypeDDL.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            if(String.IsNullOrEmpty(FromationDate.Text))
                ep.FormationDate = DateTime.Now;
            else
            ep.FormationDate = Convert.ToDateTime(FromationDate.Text);
            new CommitteesBiz().UpdateCommittee(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
    }
}