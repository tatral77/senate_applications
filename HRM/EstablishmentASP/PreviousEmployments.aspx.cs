using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class PreviousEmployments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;

            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                bindPreviousEmpl(empval);
               
            }

        }
        protected void bindPreviousEmpl(int EmpId)
        {
            List<PrevEmployments> re = new List<PrevEmployments>();
            re = new EmploymentBIZ().GetPrevEmployments(EmpId);
            PreviousEmplLV.DataSource = re;
            PreviousEmplLV.DataBind();
        }

        protected void newPreviousEmpl_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PreviousEmplLV.SelectedIndex = -1;
            PreviousEmplLV.EditIndex = -1;
            PreviousEmplLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindPreviousEmpl(empval);

        }


        protected void PrevEmployments_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidPrevEmplId = (HiddenField)PreviousEmplLV.Items[e.ItemIndex].FindControl("HidPreviousEmplId");
            int PrevId= Convert.ToInt32(HidPrevEmplId.Value);
            new EmploymentBIZ().DeletePrevEmployments(PrevId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPreviousEmpl(empval);
            Response.Redirect("PreviousEmployments.aspx?empid=" + empval);
        }
        protected void PrevEmployments_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(PreviousEmplLV.EditItem)) { e.Cancel = true; return; }
            
            HiddenField PrevEmplId = (HiddenField)PreviousEmplLV.EditItem.FindControl("HidPreviousEmplId");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox Organization = (TextBox)PreviousEmplLV.EditItem.FindControl("OrganizationTxt");
            TextBox Department = (TextBox)PreviousEmplLV.EditItem.FindControl("DepartmentTxt");
            TextBox Post = (TextBox)PreviousEmplLV.EditItem.FindControl("PostTxt");
            DropDownList BPSDDL = (DropDownList)PreviousEmplLV.EditItem.FindControl("BPSDDL");
            TextBox FromDate = (TextBox)PreviousEmplLV.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)PreviousEmplLV.EditItem.FindControl("ToDateTxt");
            TextBox Remarks = (TextBox)PreviousEmplLV.EditItem.FindControl("RemarksTxt");
            PrevEmployments eh = new PrevEmployments();
            eh.SystemUsersId = empval;
            eh.EmpPrevEmplId= Convert.ToInt32(PrevEmplId.Value);
            eh.Organization = Convert.ToString(Organization.Text);
            eh.Department = Convert.ToString(Department.Text);
            eh.Post = Convert.ToString(Post.Text);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdatePrevEmployments(eh);
            PreviousEmplLV.EditIndex = -1;
            PreviousEmplLV.InsertItemPosition = InsertItemPosition.None;
            bindPreviousEmpl(empval);
            e.Cancel = true;
            Response.Redirect("PreviousEmployments.aspx?empid=" + empval);

        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void PrevEmployments_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(PreviousEmplLV.InsertItem)) { e.Cancel = true; return; }
           
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox Organization = (TextBox)PreviousEmplLV.InsertItem.FindControl("OrganizationTxt");
            TextBox Department = (TextBox)PreviousEmplLV.InsertItem.FindControl("DepartmentTxt");
            TextBox Post = (TextBox)PreviousEmplLV.InsertItem.FindControl("PostTxt");
            DropDownList BPSDDL = (DropDownList)PreviousEmplLV.InsertItem.FindControl("BPSDDL");
            TextBox FromDate = (TextBox)PreviousEmplLV.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)PreviousEmplLV.InsertItem.FindControl("ToDateTxt");
            TextBox Remarks = (TextBox)PreviousEmplLV.InsertItem.FindControl("RemarksTxt");
            PrevEmployments eh = new PrevEmployments();
            eh.SystemUsersId = empval;
            eh.Organization = Convert.ToString(Organization.Text);
            eh.Department = Convert.ToString(Department.Text);
            eh.Post = Convert.ToString(Post.Text);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(FromDate.Text);
            eh.ToDate = Convert.ToDateTime(ToDate.Text);
           eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertPrevEmployments(eh);
            PreviousEmplLV.EditIndex = -1;
            PreviousEmplLV.InsertItemPosition = InsertItemPosition.None;
            bindPreviousEmpl(empval);
            e.Cancel = true;
            Response.Redirect("PreviousEmployments.aspx?empid=" + empval);

        }
        protected void PrevEmployments_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            PreviousEmplLV.EditIndex = -1;
            PreviousEmplLV.InsertItemPosition = InsertItemPosition.None;
            PreviousEmplLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPreviousEmpl(empval);
            e.Cancel = true;
        }

        protected void PrevEmployments_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PreviousEmplLV.InsertItemPosition = InsertItemPosition.None;
            PreviousEmplLV.SelectedIndex = -1;
            PreviousEmplLV.EditIndex = e.NewEditIndex;
            bindPreviousEmpl(empval);
            e.Cancel = true;

        }
        protected void PrevEmployments_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (PreviousEmplLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList BPSDDL = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSId = (e.Item.FindControl("HidBPSID") as HiddenField);
                BPSDDL.SelectedValue = BPSId.Value.ToString();

            }
        }
        protected void PrevEmployments_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {

                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> br = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }

        }
    }
}