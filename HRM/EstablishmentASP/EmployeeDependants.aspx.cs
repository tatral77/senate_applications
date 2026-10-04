using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP
{
    public partial class EmployeeDependants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {

                bindEmpDependantLV(empval);

            }


        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindEmpDependantLV(int empval)
        {
            List<EmployeeDependant> EmpDep = new EmployeeHandler().GetEmployeeDependants(empval);

            EmpDependantLV.DataSource = EmpDep;
            EmpDependantLV.DataBind();
        }
       
        //public string GetDate(DateTime date)
        //{
        //    return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        //}
        //////////////////List View\\\\\\\\\\\\\\\\\\\\\\
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpDependantLV.InsertItemPosition = InsertItemPosition.None;
            EmpDependantLV.SelectedIndex = -1;
            EmpDependantLV.EditIndex = e.NewEditIndex;
            bindEmpDependantLV(empval);
            e.Cancel = true;

         }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpDependantLV.EditIndex = -1;
            EmpDependantLV.InsertItemPosition = InsertItemPosition.None;
            EmpDependantLV.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpDependantLV(empval);
            e.Cancel = true;
        }
        
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField EmpId = EmpDependantLV.EditItem.FindControl("HidEmpDependantId") as HiddenField;
            TextBox Name = EmpDependantLV.EditItem.FindControl("NameTxt") as TextBox;
            DropDownList Relationd = EmpDependantLV.EditItem.FindControl("RelationDDL") as DropDownList;
            TextBox DOB = EmpDependantLV.EditItem.FindControl("DOBTxt") as TextBox;
            TextBox Years = EmpDependantLV.EditItem.FindControl("YearsTxt") as TextBox;
            TextBox Months = EmpDependantLV.EditItem.FindControl("MonthsTxt") as TextBox;
            CheckBox IsDependant= EmpDependantLV.EditItem.FindControl("IsDependant") as CheckBox;
            EmployeeDependant eh = new EmployeeDependant();
            eh.SystemUersId = empval;
            eh.EmpDependantId = Convert.ToInt32(EmpId.Value);
            eh.DependantName = Convert.ToString(Name.Text);
            eh.RelationshipId = Convert.ToInt32(Relationd.SelectedItem.Value);
            if (!String.IsNullOrEmpty(DOB.Text))
            {
                eh.DOB = Convert.ToDateTime(DOB.Text);
                Duration duration = new DateTimeUtils().GetDuration(eh.DOB, DateTime.Now);
                eh.AgeYears = duration.Years;
                eh.AgeMonths = duration.Months;
            }
            //if (!String.IsNullOrEmpty(Years.Text))
            //    eh.AgeYears = Convert.ToInt32(Years.Text);
            //if (!String.IsNullOrEmpty(Months.Text))
            //    eh.AgeMonths = Convert.ToInt32(Months.Text);
            if (IsDependant.Checked == true)
                eh.IsDependant = 1;
            else
                eh.IsDependant = 0;

            new EmployeeHandler().UpdateEmployeeDependants(eh);
            EmpDependantLV.EditIndex = -1;
            bindEmpDependantLV(empval);
            EmpDependantLV.InsertItemPosition = InsertItemPosition.None;
            EmpDependantLV.SelectedIndex = -1;
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (EmpDependantLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList RelationDDL = e.Item.FindControl("RelationDDL") as DropDownList;
                CheckBox IsDependant = e.Item.FindControl("IsDependant") as CheckBox;
                HiddenField RelationId = (e.Item.FindControl("HidRelationId") as HiddenField);
                HiddenField HidIsDependant = (e.Item.FindControl("HidIsDependant") as HiddenField);
                RelationDDL.SelectedValue = RelationId.Value.ToString();
                if (Convert.ToInt32(HidIsDependant.Value) == 1)
                    IsDependant.Checked = true;
                else
                    IsDependant.Checked = false;


            }

        }

        protected void EmpDepButton_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpDependantLV.SelectedIndex = -1;
            EmpDependantLV.EditIndex = -1;
            EmpDependantLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmpDependantLV(empval);

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            //HiddenField EmpId = EmpDependantLV.InsertItem.FindControl("HidEmpDependantId") as HiddenField;
            TextBox Name = EmpDependantLV.InsertItem.FindControl("NameTxt") as TextBox;
            DropDownList Relationd = EmpDependantLV.InsertItem.FindControl("RelationDDL") as DropDownList;
            TextBox DOB = EmpDependantLV.InsertItem.FindControl("DOBTxt") as TextBox;
            TextBox Years = EmpDependantLV.InsertItem.FindControl("YearsTxt") as TextBox;
            TextBox Months = EmpDependantLV.InsertItem.FindControl("MonthsTxt") as TextBox;
            CheckBox IsDependant = EmpDependantLV.InsertItem.FindControl("IsDependant") as CheckBox;
            EmployeeDependant eh = new EmployeeDependant();
            eh.SystemUersId = empval;
            //eh.EmpDependantId = Convert.ToInt32(EmpId.Value);
            eh.DependantName = Convert.ToString(Name.Text);
            eh.RelationshipId = Convert.ToInt32(Relationd.SelectedItem.Value);
            if (!String.IsNullOrEmpty(DOB.Text))
            {
                eh.DOB = Convert.ToDateTime(DOB.Text);
                Duration duration = new DateTimeUtils().GetDuration(eh.DOB, DateTime.Now);
                eh.AgeYears = duration.Years;
                eh.AgeMonths = duration.Months;
            }
            if (IsDependant.Checked == true)
                eh.IsDependant = 1;
            else
                eh.IsDependant = 0;
            new EmployeeHandler().InsertEmployeeDependants(eh);
            EmpDependantLV.EditIndex = -1;
            bindEmpDependantLV(empval);
            EmpDependantLV.InsertItemPosition = InsertItemPosition.None;
            EmpDependantLV.SelectedIndex = -1;
            e.Cancel = true;
            Response.Redirect("EmployeeDependants.aspx?empid=" + empval);
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList Relation = new DropDownList();
            Relation = (e.Item.FindControl("RelationDDL") as DropDownList);
            if (Relation != null)
            {
                Relation.Items.Add(new ListItem("Select", "0"));
                List<Relations> pt = new AdministrationBIZ().GetRelations();
                foreach (Relations row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Text = row.RelationName.ToString();
                    cy.Value = row.RelationsId.ToString();
                    Relation.Items.Add(cy);
                }
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpLeaveId = (HiddenField)EmpDependantLV.Items[e.ItemIndex].FindControl("HidEmpDependantId");
            int EL = Convert.ToInt32(EmpLeaveId.Value);
            new EmployeeHandler().DeleteEmployeeDepenedent(EL);
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmpDependantLV(empval);
        }

    }
}