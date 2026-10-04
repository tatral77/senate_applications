using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;
using Utilities;

namespace EstablishmentASP
{
    public partial class EmployeeProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpHistory eh = new EmploymentBIZ().GetCurrentEmployment(empval);
            EmpProfile ep = new EmpProfile();
            ep = new EmployeeHandler().GetOnePage(empval);
            string EmployeeName = ep.FName + " --- " + ep.CurrentDesignation + " (" + ep.CurrentBPS + ")";
            FName.Text = EmployeeName;
            if(ep.Dob > Convert.ToDateTime("01/01/1900"))
            DOB.Text = Convert.ToString(ep.Dob.ToShortDateString());
            CurrentDesignation.Text = ep.CurrentDesignation;
            bps.Text = ep.CurrentBPS;
            CurrentBranch.Text = ep.CurrentBranch;
            EmployeeStatus.Text = ep.EmployeeStatus;
            DateTime ServiceEndDate = new EmploymentBIZ().GetServiceEndDate(empval);
            if (ep.GovtServiceStartDate > Convert.ToDateTime("01/01/1900"))
            {
                GovtServiceStartDate.Text = Convert.ToString(ep.GovtServiceStartDate.ToShortDateString());                
                Duration GovtServiceDuration = new DateTimeUtils().GetDuration(ep.GovtServiceStartDate, ServiceEndDate);
               // if (duration.Years != 0 && duration.Months != 0)
                    GovtService.Text = Convert.ToString(GovtServiceDuration.Years + " Years " + GovtServiceDuration.Months + " Months");
              //  else if (ep.GovtService != 0 && ep.GovtServiceMonths == 0 && ep.GovtServiceStartDate > Convert.ToDateTime("01/01/1900"))
             //       GovtService.Text = Convert.ToString(ep.GovtService + " Years ");
            //    else if (ep.GovtServiceMonths != 0)
              //      GovtService.Text = Convert.ToString(ep.GovtServiceMonths + " Months");
            }
            if (ep.SenateServiceStartDate > Convert.ToDateTime("01/01/1900"))
            {
                SenateServiceStartDate.Text = Convert.ToString(ep.SenateServiceStartDate.ToShortDateString());
                Duration SenateServiceDuration = new DateTimeUtils().GetDuration(ep.SenateServiceStartDate, ServiceEndDate);
               // if (ep.HouseService != 0 && ep.HouseServiceMonths != 0)
                    HouseService.Text = Convert.ToString(SenateServiceDuration.Years + " Years " + SenateServiceDuration.Months + " Months");
              //  else if (ep.HouseService != 0 && ep.HouseServiceMonths == 0)
                 //   HouseService.Text = Convert.ToString(ep.HouseService + " Years ");
               // else if (ep.HouseServiceMonths != 0)
                //    HouseService.Text = Convert.ToString(ep.HouseServiceMonths + " Months");
            }
            if (ep.Dob > Convert.ToDateTime("01/01/1900"))
                SuperantuationDate.Text = Convert.ToString(ep.SuperanuationDate.ToShortDateString());
            if(ep.Age<=60)
            Age.Text = Convert.ToString(ep.Age);
            CurrentStatusLbl.Text = eh.CurrentStatus + " (" + eh.CurrentStatusDate.ToShortDateString() + ")";
            bindQualificationLv(empval);
            //bindCoursesLv(empval);
            bindPostingLv(empval);
            bindPostingSumLv(empval);
            BindNOCLV(empval);
            BindMedicalLv(empval);
        }
        protected void bindPostingLv(int EmpId)
        {
            List<EmployeePosting> Eq = new EmployeeHandler().GetEmployeePostings(EmpId);
            if (Eq != null)
            {
                Postings.Visible = true;
                PostingSum.Visible = true;
                EmpPostingLv.DataSource = Eq;
                EmpPostingLv.DataBind();
            }


        }
        protected void BindMedicalLv(int empval)
        {
            List<EmpMedical> MedicalesList = new EmployeeHandler().GetEmpMedical(empval);
            if (MedicalesList != null)
            {
                //Medical.Visible = true;
                MedicalLv.DataSource = MedicalesList;
                MedicalLv.DataBind();
            }
        }
        public void BindNOCLV(int empval)
        {
            List<NOC> EmpNocs = new List<NOC>();
            EmpNocs = new EmployeeHandler().GetEmployeeNOCs(empval);
            if (EmpNocs != null)
            {
               // NOC.Visible = true;
               
                EmpNocsLv.DataSource = EmpNocs;
                EmpNocsLv.DataBind();
            }
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindQualificationLv(int EmpId)
        {
            List<EmpQualification> Eq = new EmployeeHandler().GetEmployeeQualifications(EmpId);
            if (Eq != null)
            {
                Education.Visible = true;
                EmpQualificationLv.DataSource = Eq;
                EmpQualificationLv.DataBind();
            }
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

        //protected void bindCoursesLv(int EmpId)
        //{

        //    List<EmpCourses> EmpCoursesList = new EmployeeHandler().GetEmployeeCourses(EmpId);
        //    EmpCoursesLv.DataSource = EmpCoursesList;
        //   EmpCoursesLv.DataBind();
        //}
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
        protected void bindPostingSumLv(int EmpId)
        {
            List<PostingSummary> Eq = new EmployeeHandler().GetPostingSummary(EmpId);
            EmpPostingSumLv.DataSource = Eq;
            EmpPostingSumLv.DataBind();


        }
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