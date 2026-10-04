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
    public partial class EmployeeNOC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLV();
            }
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpNocsLv.SelectedIndex = -1;
            EmpNocsLv.EditIndex = -1;
            EmpNocsLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLV();
        }
        public void BindLV()
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            List<NOC> EmpNocs = new List<NOC>();
            EmpNocs = new EmployeeHandler().GetEmployeeNOCs(empval);
            EmpNocsLv.DataSource = EmpNocs;
            EmpNocsLv.DataBind();
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
           
            List<NOCTypes> vt = new AdministrationBIZ().GetNOCTypes();
            DropDownList ddl2 = new DropDownList();
            ddl2 = (e.Item.FindControl("NOCTypeDDL") as DropDownList);
            if (ddl2 != null)
            {
                ddl2.Items.Add(new ListItem("Select", "0"));
                foreach (NOCTypes row in vt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.NocTypeId.ToString();
                    ty.Text = row.Description.ToString();
                    ddl2.Items.Add(ty);
                }
            }
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmpNocsLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList NocType = e.Item.FindControl("NOCTypeDDL") as DropDownList;
                HiddenField HidNocTypeId = (e.Item.FindControl("HidNocTypeId") as HiddenField);
                NocType.SelectedValue = HidNocTypeId.Value.ToString();

            }
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            EmpNocsLv.InsertItemPosition = InsertItemPosition.None;
            EmpNocsLv.SelectedIndex = -1;
            EmpNocsLv.EditIndex = e.NewEditIndex;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpNocsLv.EditIndex = -1;
            EmpNocsLv.InsertItemPosition = InsertItemPosition.None;
            EmpNocsLv.SelectedIndex = -1;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList NocTypeId = (DropDownList)EmpNocsLv.InsertItem.FindControl("NOCTypeDDL");
           //TextBox NOCNumber = (TextBox)EmpNocsLv.InsertItem.FindControl("NOCNumberTxt");
            TextBox NOCDate = (TextBox)EmpNocsLv.InsertItem.FindControl("NOCDateTxt");
            TextBox Remarks = (TextBox)EmpNocsLv.InsertItem.FindControl("RemarksTxt");
            NOC ep = new NOC();
            ep.SystemUserId = empval;
            ep.NocTypeId = Convert.ToInt32(NocTypeId.SelectedItem.Value);
           // ep.NocNumber = Convert.ToString(NOCNumber.Text);
            ep.IssueDate = Convert.ToDateTime(NOCDate.Text);
            ep.Remarks = Convert.ToString(Remarks.Text);
            new EmployeeHandler().InsertEmployeeNOC(ep);
            EmpNocsLv.EditIndex = -1;
            EmpNocsLv.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            Response.Redirect("EmployeeNOC.aspx?empid=" + empval);
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField NocId = EmpNocsLv.EditItem.FindControl("HidNocId") as HiddenField;
            DropDownList NocTypeId = (DropDownList)EmpNocsLv.EditItem.FindControl("NOCTypeDDL");
         //   TextBox NOCNumber = (TextBox)EmpNocsLv.EditItem.FindControl("NOCNumberTxt");
            TextBox NOCDate = (TextBox)EmpNocsLv.EditItem.FindControl("NOCDateTxt");
            TextBox Remarks = (TextBox)EmpNocsLv.EditItem.FindControl("RemarksTxt");
            NOC ep = new NOC();
            ep.NocId = Convert.ToInt32(NocId.Value);
            ep.NocTypeId = Convert.ToInt32(NocTypeId.SelectedItem.Value);
          //  ep.NocNumber = Convert.ToString(NOCNumber.Text);
            ep.IssueDate = Convert.ToDateTime(NOCDate.Text);
            ep.Remarks = Convert.ToString(Remarks.Text);
            new EmployeeHandler().UpdateEmployeeNOC(ep);
            EmpNocsLv.EditIndex = -1;
            EmpNocsLv.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField NOCId = (HiddenField)EmpNocsLv.Items[e.ItemIndex].FindControl("HidNOCId");
            new EmployeeHandler().DeleteEmployeeNOC(Convert.ToInt32(NOCId.Value));
            BindLV();
        }
    }
}