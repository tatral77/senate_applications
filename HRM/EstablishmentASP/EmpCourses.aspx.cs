using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class EmpCources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindCoursesLv(empval);
            }

        }
        protected void bindCoursesLv(int EmpId)
        {
            List<EmpCourses> EmpCoursesList = new EmployeeHandler().GetEmployeeCourses(EmpId);
            EmpHeaderInfo EmpInfo = new EmpHeaderInfo();
            EmpInfo = new EmployeeHandler().GetEmpName(Convert.ToInt32(EmpId));
            EmpHeaderInfo EmpDesig = new EmployeeHandler().GetEmpDesignation(Convert.ToInt32(EmpId));
            LeaveHeader.Text = EmpInfo.EmpName.ToString() + " -- ";
            if (!String.IsNullOrEmpty(EmpDesig.POST))
                LeaveHeader.Text += EmpDesig.POST.ToString() + "(" + EmpDesig.BPS.ToString() + ") -- ";
            else
                LeaveHeader.Text += " Post and BPS not mentioned--";

            EmpInfo = new EmployeeHandler().GetEmpBranch(Convert.ToInt32(EmpId));
            if (!String.IsNullOrEmpty(EmpInfo.BRANCH))
                LeaveHeader.Text += EmpInfo.BRANCH.ToString() + " -- ";
            else
                LeaveHeader.Text += " Branch not mentioned -- ";

            EmpInfo = new EmployeeHandler().GetEmpEmplStatus(Convert.ToInt32(EmpId));
            if (!String.IsNullOrEmpty(EmpInfo.EmploymentStatus))
                LeaveHeader.Text += EmpInfo.EmploymentStatus.ToString() + " -- ";
            else
                LeaveHeader.Text += "Employment Status not mentioned";
            if (!String.IsNullOrEmpty(EmpInfo.EmploymentStatus))
                LeaveHeader.Text += EmpInfo.CurrentStatus.ToString();
            else
                LeaveHeader.Text += "Employment Status not mentioned";
            EmpCoursesLv.DataSource = EmpCoursesList;
            EmpCoursesLv.DataBind();

        }
        protected string GetCountry(int CountryId)
        {
            if (CountryId == 0)
                return "Not Mentioned";
            else
            {
                Country cy = new Country();
                cy = new AdministrationBIZ().GetCountry(CountryId);
                return cy.Description;
            }


        }
        protected string GetCourseType(int CourseTypeId)
        {
            if (CourseTypeId == 0)
                return "Not Mentioned";
            else
            {
                CourseType cy = new CourseType();
                cy = new AdministrationBIZ().GetCourseType(CourseTypeId);
                return cy.Description;
            }


        }
        protected string GetCity(int CityId)
        {
            if (CityId == 0)
                return "Not Mentioned";
            else
            {
                City cy = new City();
                cy = new AdministrationBIZ().GetCity(CityId);
                return cy.Description;
            }


        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpCoursesLv.InsertItemPosition = InsertItemPosition.None;
            EmpCoursesLv.SelectedIndex = -1;
            EmpCoursesLv.EditIndex = e.NewEditIndex;
            bindCoursesLv(empval);
            e.Cancel = true;


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpCoursesLv.SelectedIndex = -1;
            EmpCoursesLv.EditIndex = -1;
            EmpCoursesLv.InsertItemPosition = InsertItemPosition.FirstItem;
            bindCoursesLv(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpCoursesLv.EditIndex = -1;
            EmpCoursesLv.InsertItemPosition = InsertItemPosition.None;
            EmpCoursesLv.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindCoursesLv(empval);
            e.Cancel = true;
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpCoursesLv.EditItem)) { e.Cancel = true; return; }

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField empcourseid = EmpCoursesLv.EditItem.FindControl("HidEmpCourseId") as HiddenField;
            TextBox coursename = EmpCoursesLv.EditItem.FindControl("CourseNameTxt") as TextBox;
            DropDownList courseTypeid = EmpCoursesLv.EditItem.FindControl("CourseTypeDDL") as DropDownList;
            CheckBox Mandatory = (CheckBox)EmpCoursesLv.EditItem.FindControl("MandatoryCB");
            TextBox degdipcert = EmpCoursesLv.EditItem.FindControl("DegDipCertTxt") as TextBox;
            TextBox institutionname = EmpCoursesLv.EditItem.FindControl("InstitutionNameTxt") as TextBox;
            DropDownList countryid = EmpCoursesLv.EditItem.FindControl("CourseCountryDDL") as DropDownList;
            //DropDownList cityid = EmpCoursesLv.EditItem.FindControl("CourseCityDDL") as DropDownList;
            TextBox fromdate = EmpCoursesLv.EditItem.FindControl("FromDateTxt") as TextBox;
            TextBox todate = EmpCoursesLv.EditItem.FindControl("ToDateTxt") as TextBox;
            TextBox sponsoredby = EmpCoursesLv.EditItem.FindControl("SponsoredByTxt") as TextBox;
            TextBox remarks = EmpCoursesLv.EditItem.FindControl("RemarksTxt") as TextBox;

            EmpCourses ec = new EmpCourses();
            ec.SystemUsersId = empval;
            ec.EmpCourseId = Convert.ToInt32(empcourseid.Value);
            ec.Mandatory = (Mandatory.Checked == true) ? 1 : 0;
            ec.CourseName = Convert.ToString(coursename.Text);
            ec.CourseTypeId = Convert.ToInt32(courseTypeid.SelectedItem.Value);
            ec.DegDipCert = Convert.ToString(degdipcert.Text);
            ec.InstitutionName = Convert.ToString(institutionname.Text);
            ec.CountryId = Convert.ToInt32(countryid.SelectedItem.Value);
            //ec.CityId = Convert.ToInt32(cityid.SelectedItem.Value);
            ec.FromDate = Convert.ToDateTime(fromdate.Text);
            ec.ToDate = Convert.ToDateTime(todate.Text);
            ec.SponsoredBy = Convert.ToString(sponsoredby.Text);
            ec.Remarks = Convert.ToString(remarks.Text);

            new EmployeeHandler().SaveEmpCourses(ec);
            EmpCoursesLv.EditIndex = -1;
            bindCoursesLv(empval);
            EmpCoursesLv.InsertItemPosition = InsertItemPosition.None;
            EmpCoursesLv.SelectedIndex = -1;
            e.Cancel = true;
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (EmpCoursesLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList fuControl = e.Item.FindControl("CourseCountryDDL") as DropDownList;
                HiddenField CourseCountryid = (e.Item.FindControl("HidCourseCountryId") as HiddenField);
                fuControl.SelectedValue = CourseCountryid.Value.ToString();

                DropDownList courseType = e.Item.FindControl("CourseTypeDDL") as DropDownList;
                HiddenField CourseTypeid = (e.Item.FindControl("HidCourseTypeId") as HiddenField);
                courseType.SelectedValue = CourseTypeid.Value.ToString();
                CheckBox MandatoryCB = e.Item.FindControl("MandatoryCB") as CheckBox;
                if (MandatoryCB != null)
                {
                    HiddenField Mandatory = (e.Item.FindControl("HidMandatory") as HiddenField);
                    if (Convert.ToInt32(Mandatory.Value) == 1)
                        MandatoryCB.Checked = true;
                    else
                        MandatoryCB.Checked = false;
                }
            }
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmpCoursesLv.InsertItem)) { e.Cancel = true; return; }
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox coursename = EmpCoursesLv.InsertItem.FindControl("CourseNameTxt") as TextBox;
            DropDownList courseTypeid = EmpCoursesLv.InsertItem.FindControl("CourseTypeDDL") as DropDownList;
            TextBox degdipcert = EmpCoursesLv.InsertItem.FindControl("DegDipCertTxt") as TextBox;
            TextBox institutionname = EmpCoursesLv.InsertItem.FindControl("InstitutionNameTxt") as TextBox;
            DropDownList countryid = EmpCoursesLv.InsertItem.FindControl("CourseCountryDDL") as DropDownList;
            //DropDownList cityid = EmpCoursesLv.InsertItem.FindControl("CourseCityDDL") as DropDownList;
            CheckBox Mandatory = (CheckBox)EmpCoursesLv.InsertItem.FindControl("MandatoryCB");
            TextBox fromdate = EmpCoursesLv.InsertItem.FindControl("FromDateTxt") as TextBox;
            TextBox todate = EmpCoursesLv.InsertItem.FindControl("ToDateTxt") as TextBox;
            TextBox sponsoredby = EmpCoursesLv.InsertItem.FindControl("SponsoredByTxt") as TextBox;
            TextBox remarks = EmpCoursesLv.InsertItem.FindControl("RemarksTxt") as TextBox;

            EmpCourses ec = new EmpCourses();
            ec.SystemUsersId = empval;
            ec.CourseName = Convert.ToString(coursename.Text);
            ec.CourseTypeId = Convert.ToInt32(courseTypeid.SelectedItem.Value);
            ec.Mandatory = (Mandatory.Checked == true) ? 1 : 0;
            ec.DegDipCert = Convert.ToString(degdipcert.Text);
            ec.InstitutionName = Convert.ToString(institutionname.Text);
            ec.CountryId = Convert.ToInt32(countryid.SelectedItem.Value);
            //ec.CityId = Convert.ToInt32(cityid.SelectedItem.Value);
            if (!String.IsNullOrEmpty(fromdate.Text))
                ec.FromDate = Convert.ToDateTime(fromdate.Text);
            if (!String.IsNullOrEmpty(todate.Text))
                ec.ToDate = Convert.ToDateTime(todate.Text);
            ec.SponsoredBy = Convert.ToString(sponsoredby.Text);
            ec.Remarks = Convert.ToString(remarks.Text);


            new EmployeeHandler().InsertEmployeeCourse(ec);
            EmpCoursesLv.EditIndex = -1;
            EmpCoursesLv.InsertItemPosition = InsertItemPosition.None;
            bindCoursesLv(empval);
            e.Cancel = true;
            Response.Redirect("EmpCourses.aspx?empid=" + empval);

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            List<Country> cy = new AdministrationBIZ().GetCountries();
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("CourseCountryDDL") as DropDownList);
            if (ddl != null)
            {
                ddl.Items.Add(new ListItem("Select", "0"));
                foreach (Country row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.CountryId.ToString();
                    ty.Text = row.Description.ToString();
                    ddl.Items.Add(ty);
                }

            }
            List<CourseType> ct = new AdministrationBIZ().GetCourseTypes();
            DropDownList ptddl = new DropDownList();
            ptddl = (e.Item.FindControl("CourseTypeDDL") as DropDownList);
            if (ptddl != null)
            {
                foreach (CourseType row in ct)
                {
                    ListItem lpt = new ListItem();
                    lpt.Value = row.CourseTypeId.ToString();
                    lpt.Text = row.Description.ToString();
                    ptddl.Items.Add(lpt);
                }



            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpCourseId = (HiddenField)EmpCoursesLv.Items[e.ItemIndex].FindControl("HidEmpCourseId");
            int EmpCourId = Convert.ToInt32(EmpCourseId.Value);
            new EmployeeHandler().DeleteEmployeeCourse(EmpCourId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindCoursesLv(empval);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////










    }
}