using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class EmpQualifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindQualificationLv(empval);
            }


        }
        protected void bindQualificationLv(int EmpId)
        {
            List<EmpQualification> Eq = new EmployeeHandler().GetEmployeeQualifications(EmpId);
            EmpQualificationLv .DataSource = Eq;
            EmpQualificationLv.DataBind();

        
        }
        protected string GetDegreeLevel(int Degree_Level_Id)
        {
            if (Degree_Level_Id == 0)
                return "Not Mentioned";
            else
            {
                DegreeLevel dl = new DegreeLevel();
                dl = new AdministrationBIZ().GetDegreeLevel(Degree_Level_Id);
                return dl.Degree_Level;
            }


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
        //protected string GetCity(int CityId)
        //{
        //    if (CityId == 0)
        //        return "Not Mentioned";
        //    else
        //    {
        //        City cy = new City();
        //        cy = new AdministrationBIZ().GetCity(CityId);
        //        return cy.Description;
        //    }


        //}
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpQualificationLv.InsertItemPosition = InsertItemPosition.None;
            EmpQualificationLv.SelectedIndex = -1;
            EmpQualificationLv.EditIndex = e.NewEditIndex;
            bindQualificationLv(empval);
            e.Cancel = true;


        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmpQualificationLv.EditIndex = -1;
            EmpQualificationLv.InsertItemPosition = InsertItemPosition.None;
            EmpQualificationLv.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindQualificationLv(empval);
            e.Cancel = true;
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (EmpQualificationLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList countryid = e.Item.FindControl("CountryDDL") as DropDownList;
                ////countryid.Items.Add(new ListItem("Select", "0"));
                //// if (!IsPostBack)
                //// {
                //List<Country> pt = new AdministrationBIZ().GetCountries();

                //foreach (Country row in pt)
                //{
                //    ListItem ty = new ListItem();
                //    ty.Value = row.CountryId.ToString();
                //    ty.Text = row.Description.ToString();
                //    countryid.Items.Add(ty);
                //}

                ////  }
                HiddenField CourseCountryid = (e.Item.FindControl("HidCountryId") as HiddenField);
                countryid.SelectedValue = CourseCountryid.Value.ToString();


                //DropDownList cityid = e.Item.FindControl("CityDDL") as DropDownList;
                //cityid.Items.Add(new ListItem("Select", "0"));
                //// if (!IsPostBack)
                //// {
                //List<City> cy = new AdministrationBIZ().GetCities();

                //foreach (City row in cy)
                //{
                //    ListItem ty = new ListItem();
                //    ty.Value = row.CityId.ToString();
                //    ty.Text = row.Description.ToString();
                //    cityid.Items.Add(ty);
                //}

                ////  }
                //HiddenField hidcityid = (e.Item.FindControl("HidCityId") as HiddenField);
                //cityid.SelectedValue = hidcityid.Value.ToString();


                //degreelevelid.Items.Add(new ListItem("Select", "0"));
                //// if (!IsPostBack)
                //// {
                //List<DegreeLevel> dl = new AdministrationBIZ().GetDegreeLevels();

                //foreach (DegreeLevel row in dl)
                //{
                //    ListItem ty = new ListItem();
                //    ty.Value = row.Degree_Level_Id.ToString();
                //    ty.Text = row.Degree_Level.ToString();
                //    degreelevelid.Items.Add(ty);
                //}

                //  }
                DropDownList degreelevelid = e.Item.FindControl("DegreeLevelDDL") as DropDownList;
                HiddenField hiddegreelevelid = (e.Item.FindControl("HidDegreeLevelId") as HiddenField);
                degreelevelid.SelectedValue = hiddegreelevelid.Value.ToString();

                DropDownList divisionddl = e.Item.FindControl("DivisionDDL") as DropDownList;
                HiddenField division = (e.Item.FindControl("HidDivision") as HiddenField);
                divisionddl.SelectedValue = division.Value.ToString();

            }
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("DegreeLevelDDL") as DropDownList);
            if (ddl != null)
            {
                List<DegreeLevel> pt = new AdministrationBIZ().GetDegreeLevels();

                foreach (DegreeLevel row in pt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.Degree_Level_Id.ToString();
                    ty.Text = row.Degree_Level.ToString();
                    ddl.Items.Add(ty);
                }

            }
            List<Country> cy = new AdministrationBIZ().GetCountries();
            // ListViewItem lvi = PassportsLv.EditItem;
            DropDownList Cddl = new DropDownList();
            Cddl = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (Cddl != null)
            {
                foreach (Country row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.CountryId.ToString();
                    ty.Text = row.Description.ToString();
                    Cddl.Items.Add(ty);
                }

            }



        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpQualificationLv.SelectedIndex = -1;
            EmpQualificationLv.EditIndex = -1;
            EmpQualificationLv.InsertItemPosition = InsertItemPosition.FirstItem;
            bindQualificationLv(empval);

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList degreelevel = EmpQualificationLv.InsertItem.FindControl("DegreeLevelDDL") as DropDownList;
            TextBox degreeobtained = EmpQualificationLv.InsertItem.FindControl("DegreeObtainedTxt") as TextBox;
            TextBox institutionname = EmpQualificationLv.InsertItem.FindControl("InstitutionNameTxt") as TextBox;
            TextBox SubjectsTxt = EmpQualificationLv.InsertItem.FindControl("SubjectsTxt") as TextBox;
            DropDownList country = EmpQualificationLv.InsertItem.FindControl("CountryDDL") as DropDownList;
            //DropDownList city = EmpQualificationLv.InsertItem.FindControl("CityDDL") as DropDownList;
            TextBox completionyear = EmpQualificationLv.InsertItem.FindControl("CompletionYearTxt") as TextBox;
            TextBox cgpa = EmpQualificationLv.InsertItem.FindControl("CGPATxt") as TextBox;
            TextBox grade = EmpQualificationLv.InsertItem.FindControl("GradeTxt") as TextBox;
            TextBox percentage = EmpQualificationLv.InsertItem.FindControl("PercentageTxt") as TextBox;
            DropDownList divisionddl = EmpQualificationLv.InsertItem.FindControl("DivisionDDL") as DropDownList;

            EmpQualification eq = new EmpQualification();
            eq.System_Users_Id = empval;
            eq.Degree_Level_Id = Convert.ToInt32(degreelevel.SelectedItem.Value);
            eq.Degree_Obtained = Convert.ToString(degreeobtained.Text);
            eq.Institution_Name = Convert.ToString(institutionname.Text);
            eq.Subjects = Convert.ToString(SubjectsTxt.Text);
            eq.Country_Id = Convert.ToInt32(country.SelectedItem.Value);
            //eq.City_Id = Convert.ToInt32(city.SelectedItem.Value);
            eq.Completion_Year = Convert.ToString(completionyear.Text);
            if (cgpa.Text!="")
            eq.Cgpa = Convert.ToDouble(cgpa.Text);
            if (grade.Text !="")
            eq.Grade = Convert.ToString(grade.Text);
            if (percentage.Text != "")
            eq.Percentage = Convert.ToDouble(percentage.Text);
            eq.Division = Convert.ToString(divisionddl.SelectedItem.Value);
            new EmployeeHandler().InsertEmployeeQualification(eq);
            EmpQualificationLv.EditIndex = -1;
            EmpQualificationLv.InsertItemPosition = InsertItemPosition.None;
            bindQualificationLv(empval);
            e.Cancel = true;


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField empqualificationid = EmpQualificationLv.EditItem.FindControl("HidEmpQualificationId") as HiddenField;
            DropDownList degreelevel = EmpQualificationLv.EditItem.FindControl("DegreeLevelDDL") as DropDownList;
            TextBox degreeobtained = EmpQualificationLv.EditItem.FindControl("DegreeObtainedTxt") as TextBox;
            TextBox institutionname = EmpQualificationLv.EditItem.FindControl("InstitutionNameTxt") as TextBox;
            TextBox SubjectsTxt = EmpQualificationLv.EditItem.FindControl("SubjectsTxt") as TextBox;
            DropDownList country = EmpQualificationLv.EditItem.FindControl("CountryDDL") as DropDownList;
            //DropDownList city = EmpQualificationLv.EditItem.FindControl("CityDDL") as DropDownList;
            TextBox completionyear = EmpQualificationLv.EditItem.FindControl("CompletionYearTxt") as TextBox;
            TextBox cgpa = EmpQualificationLv.EditItem.FindControl("CGPATxt") as TextBox;
            TextBox grade = EmpQualificationLv.EditItem.FindControl("GradeTxt") as TextBox;
            TextBox percentage = EmpQualificationLv.EditItem.FindControl("PercentageTxt") as TextBox;
            DropDownList divisionddl = EmpQualificationLv.EditItem.FindControl("DivisionDDL") as DropDownList;
            EmpQualification eq = new EmpQualification();
            eq.System_Users_Id = empval;
            eq.Emp_Qualification_Id = Convert.ToInt32(empqualificationid.Value);
            eq.Degree_Level_Id = Convert.ToInt32(degreelevel.SelectedItem.Value);
            eq.Degree_Obtained = Convert.ToString(degreeobtained.Text);
            eq.Institution_Name = Convert.ToString(institutionname.Text);
            eq.Subjects = Convert.ToString(SubjectsTxt.Text);
            eq.Country_Id = Convert.ToInt32(country.SelectedItem.Value);
            //if(city.SelectedItem.Value!="0")
            //eq.City_Id = Convert.ToInt32(city.SelectedItem.Value);
            eq.Completion_Year = Convert.ToString(completionyear.Text);
            if (cgpa.Text != "")
                eq.Cgpa = Convert.ToDouble(cgpa.Text);
            if (grade.Text != "")
                eq.Grade = Convert.ToString(grade.Text);
            if (percentage.Text != "")
                eq.Percentage = Convert.ToDouble(percentage.Text);
            eq.Division = Convert.ToString(divisionddl.SelectedItem.Value);
            new EmployeeHandler().UpdateEmployeeQualification(eq);
            EmpQualificationLv.EditIndex = -1;
            EmpQualificationLv.InsertItemPosition = InsertItemPosition.None;
            bindQualificationLv(empval);
            e.Cancel = true;


        }

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpCourseId = (HiddenField)EmpQualificationLv.Items[e.ItemIndex].FindControl("HidEmpQualificationId");
            int empqualificationid = Convert.ToInt32(EmpCourseId.Value);
            new EmployeeHandler().DeleteEmployeeQualification(empqualificationid);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindQualificationLv(empval);
        }
        //protected void Populate_Insert_Cities(object sender, EventArgs e)
        //{
        //    DropDownList country = EmpQualificationLv.InsertItem.FindControl("CountryDDL") as DropDownList;
        //    int countryid=Convert.ToInt32(country.SelectedItem.Value);
        //    DropDownList city = EmpQualificationLv.InsertItem.FindControl("CityDDL") as DropDownList;
        //    city.Items.Clear();
        //    city.Items.Add(new ListItem("Select", "0"));
        //    List<City> cities = new AdministrationBIZ().GetCities(countryid);
        //    if (cities != null)
        //    {
        //        foreach (City row in cities)
        //        {
        //            ListItem ty = new ListItem();
        //            ty.Value = row.CityId .ToString();
        //            ty.Text = row.Description.ToString();
        //            city.Items.Add(ty);
        //        }

        //    }

        
        //}
        //protected void Populate_Edit_Cities(object sender, EventArgs e)
        //{
        //    DropDownList country = EmpQualificationLv.EditItem.FindControl("CountryDDL") as DropDownList;
        //    int countryid = Convert.ToInt32(country.SelectedItem.Value);
        //    DropDownList city = EmpQualificationLv.EditItem.FindControl("CityDDL") as DropDownList;
        //    city.Items.Clear();
        //    List<City> cities = new AdministrationBIZ().GetCities(countryid);
        //    if (cities != null)
        //    {
        //        foreach (City row in cities)
        //        {
        //            ListItem ty = new ListItem();
        //            ty.Value = row.CityId.ToString();
        //            ty.Text = row.Description.ToString();
        //            city.Items.Add(ty);
        //        }

        //    }


        //}
    
    }
} 