using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP.Reports
{
    public partial class TrainingsProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpProfile ep = new EmpProfile();
            ep = new EmployeeHandler().GetOnePage(empval);
            FName.Text = ep.FName;
            if (ep.Dob > Convert.ToDateTime("01/01/1900"))
                DOB.Text = Convert.ToString(ep.Dob.ToShortDateString());
            CurrentDesignation.Text = ep.CurrentDesignation;
            bps.Text = ep.CurrentBPS;
            CurrentBranch.Text = ep.CurrentBranch;
            EmployeeStatus.Text = ep.EmployeeStatus;


            if (ep.GovtServiceStartDate > Convert.ToDateTime("01/01/1900"))
            {
                GovtServiceStartDate.Text = Convert.ToString(ep.GovtServiceStartDate.ToShortDateString());
                if (ep.GovtService != 0 && ep.GovtServiceMonths != 0)
                    GovtService.Text = Convert.ToString(ep.GovtService + " Years " + ep.GovtServiceMonths % 12 + " Months");
                else if (ep.GovtService != 0 && ep.GovtServiceMonths == 0 && ep.GovtServiceStartDate > Convert.ToDateTime("01/01/1900"))
                    GovtService.Text = Convert.ToString(ep.GovtService + " Years ");
                else if (ep.GovtServiceMonths != 0)
                    GovtService.Text = Convert.ToString(ep.GovtServiceMonths + " Months");
            }
            if (ep.SenateServiceStartDate > Convert.ToDateTime("01/01/1900"))
            {
                SenateServiceStartDate.Text = Convert.ToString(ep.SenateServiceStartDate.ToShortDateString());
                if (ep.HouseService != 0 && ep.HouseServiceMonths != 0)
                    HouseService.Text = Convert.ToString(ep.HouseService + " Years " + ep.HouseServiceMonths % 12 + " Months");
                else if (ep.HouseService != 0 && ep.HouseServiceMonths == 0)
                    HouseService.Text = Convert.ToString(ep.HouseService + " Years ");
                else if (ep.HouseServiceMonths != 0)
                    HouseService.Text = Convert.ToString(ep.HouseServiceMonths + " Months");
            }
            if (ep.Dob > Convert.ToDateTime("01/01/1900"))
                SuperantuationDate.Text = Convert.ToString(ep.SuperanuationDate.ToShortDateString());
            if (ep.Age < 100)
                Age.Text = Convert.ToString(ep.Age);
            bindCoursesLv(empval);
           // bindPostingLv(empval);
          //  bindPostingSumLv(empval);
        }
        //protected void bindPostingLv(int EmpId)
        //{
        //    List<EmployeePosting> Eq = new EmployeeHandler().GetEmployeePostings(EmpId);
        //    EmpPostingLv.DataSource = Eq;
        //    EmpPostingLv.DataBind();


        //}
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        //protected void bindQualificationLv(int EmpId)
        //{
        //    List<EmpQualification> Eq = new EmployeeHandler().GetEmployeeQualifications(EmpId);
        //    EmpQualificationLv.DataSource = Eq;
        //    EmpQualificationLv.DataBind();
        //}
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

        protected void bindCoursesLv(int EmpId)
        {

            List<EmpCourses> EmpCoursesList = new EmployeeHandler().GetEmployeeCourses(EmpId);
            EmpCoursesLv.DataSource = EmpCoursesList;
            EmpCoursesLv.DataBind();
        }
        protected string GetCountry1(int CountryId)
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
        //protected void bindPostingSumLv(int EmpId)
        //{
        //    List<PostingSummary> Eq = new EmployeeHandler().GetPostingSummary(EmpId);
        //    EmpPostingSumLv.DataSource = Eq;
        //    EmpPostingSumLv.DataBind();


        //}
        protected string GetCity1(int CityId)
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
    }
}
