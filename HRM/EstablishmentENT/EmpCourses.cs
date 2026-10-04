using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
  
        public class EmpCourses
        {
            int empCourseId;

            public int EmpCourseId
            {
                get { return empCourseId; }
                set { empCourseId = value; }
            }
            int systemUsersId;

            public int SystemUsersId
            {
                get { return systemUsersId; }
                set { systemUsersId = value; }
            }
        public int Mandatory { get; set; }
        int courseTypeId;

            public int CourseTypeId
            {
                get { return courseTypeId; }
                set { courseTypeId = value; }
            }

            string courseName;

            public string CourseName
            {
                get { return courseName; }
                set { courseName = value; }
            }
            DateTime  fromDate;

            public DateTime FromDate
            {
                get { return fromDate; }
                set { fromDate = value; }
            }
            DateTime toDate;

            public DateTime  ToDate
            {
                get { return toDate; }
                set { toDate = value; }
            }
            string institutionName;

            public string InstitutionName
            {
                get { return institutionName; }
                set { institutionName = value; }
            }

            int? countryId;

            public int? CountryId
            {
                get { return countryId; }
                set { countryId = value; }
            }
            int? cityId;

            public int? CityId
            {
                get { return cityId; }
                set { cityId = value; }
            }

            int isForegn;
            public int IsForegn
            {
                get { return isForegn; }
                set { isForegn = value; }
            }

            string degDipCert;
            public string DegDipCert
            {
                get { return degDipCert; }
                set { degDipCert = value; }
            }

            string sponsoredBy;

            public string SponsoredBy
            {
                get { return sponsoredBy; }
                set { sponsoredBy = value; }
            }
        public string Remarks { get; set; }

    }
    }
