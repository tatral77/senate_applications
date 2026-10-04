using IPRBIZ;
using IPRENITITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class OutgoingVisitDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSanctionLV();
            }
        }

        protected void bindSanctionLV()
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            List<OutgoingVisitSanction> sanction = new IPRBiz().GetOutgoingVisitSanctions(VisitId);
            SanctionLV.DataSource = sanction;
            SanctionLV.DataBind();
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {
           SanctionLV.SelectedIndex = -1;
           SanctionLV.EditIndex = -1;
           SanctionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindSanctionLV();
        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            SanctionLV.InsertItemPosition = InsertItemPosition.None;
            SanctionLV.SelectedIndex = -1;
            SanctionLV.EditIndex = e.NewEditIndex;
            bindSanctionLV();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidSanctionId = (HiddenField)SanctionLV.Items[e.ItemIndex].FindControl("HidSanctionId");
            new IPRBiz().DeleteOutgoingVisitSanction(Convert.ToInt32(HidSanctionId.Value));
            bindSanctionLV();
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            SanctionLV.EditIndex = -1;
            SanctionLV.InsertItemPosition = InsertItemPosition.None;
            SanctionLV.SelectedIndex = -1;
            bindSanctionLV();
            e.Cancel = true;
        }
        public string GetPrintLink(string SanctionId)
        {
            return "~/PrintOutgoingVisitSanction.aspx?SanctionId=" + SanctionId;
        }

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int Visit = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox SanctionDateTxt = (TextBox)SanctionLV.InsertItem.FindControl("SanctionDateTxt");
            TextBox FileNoTxt = (TextBox)SanctionLV.InsertItem.FindControl("FileNoTxt");
            TextBox MovedByTxt = (TextBox)SanctionLV.InsertItem.FindControl("MovedByTxt");
            TextBox SubjectTxt = (TextBox)SanctionLV.InsertItem.FindControl("SubjectTxt");
            TextBox IncurredOnTxt = (TextBox)SanctionLV.InsertItem.FindControl("IncurredOnTxt");
            TextBox RuleNoTxt = (TextBox)SanctionLV.InsertItem.FindControl("RuleNoTxt");
            TextBox HeadOfAccountTxt = (TextBox)SanctionLV.InsertItem.FindControl("HeadOfAccountTxt");
            OutgoingVisitSanction ep = new OutgoingVisitSanction();
            ep.VisitId = Visit;
            ep.SanctionDate = Convert.ToDateTime(SanctionDateTxt.Text);
            ep.FileNo = Convert.ToString(FileNoTxt.Text);
            ep.MovedBy = Convert.ToString(MovedByTxt.Text);
            ep.Subject = Convert.ToString(SubjectTxt.Text);
            ep.IncurredOn = Convert.ToString(IncurredOnTxt.Text);
            ep.RuleNo = Convert.ToString(RuleNoTxt.Text);
            ep.HeadOfAccount = Convert.ToString(HeadOfAccountTxt.Text);
            new IPRBiz().InsertOutgoingVisitSanction(ep);
            SanctionLV.EditIndex = -1;
            SanctionLV.InsertItemPosition = InsertItemPosition.None;
            e.Cancel = true;
            Response.Redirect("OutgoingVisitDocuments.aspx?Id=" + Visit);
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int Visit = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidSanctionId = (HiddenField)SanctionLV.EditItem.FindControl("HidSanctionId");
            TextBox SanctionDateTxt = (TextBox)SanctionLV.EditItem.FindControl("SanctionDateTxt");
            TextBox FileNoTxt = (TextBox)SanctionLV.EditItem.FindControl("FileNoTxt");
            TextBox MovedByTxt = (TextBox)SanctionLV.EditItem.FindControl("MovedByTxt");
            TextBox SubjectTxt = (TextBox)SanctionLV.EditItem.FindControl("SubjectTxt");
            TextBox IncurredOnTxt = (TextBox)SanctionLV.EditItem.FindControl("IncurredOnTxt");
            TextBox RuleNoTxt = (TextBox)SanctionLV.EditItem.FindControl("RuleNoTxt");
            TextBox HeadOfAccountTxt = (TextBox)SanctionLV.EditItem.FindControl("HeadOfAccountTxt");
            OutgoingVisitSanction ep = new OutgoingVisitSanction();
            ep.VisitId = Visit;
            ep.SanctionId= Convert.ToInt32(HidSanctionId.Value);
            ep.SanctionDate = Convert.ToDateTime(SanctionDateTxt.Text);
            ep.FileNo = Convert.ToString(FileNoTxt.Text);
            ep.MovedBy = Convert.ToString(MovedByTxt.Text);
            ep.Subject = Convert.ToString(SubjectTxt.Text);
            ep.IncurredOn = Convert.ToString(IncurredOnTxt.Text);
            ep.RuleNo = Convert.ToString(RuleNoTxt.Text);
            ep.HeadOfAccount = Convert.ToString(HeadOfAccountTxt.Text);
            new IPRBiz().UpdateOutgoingVisitSanction(ep);
            SanctionLV.EditIndex = -1;
            SanctionLV.InsertItemPosition = InsertItemPosition.None;
            bindSanctionLV();
            e.Cancel = true;
        }
    }
}