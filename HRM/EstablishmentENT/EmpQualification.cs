using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpQualification
    {
        int emp_Qualification_Id;

        public int Emp_Qualification_Id
        {
            get { return emp_Qualification_Id; }
            set { emp_Qualification_Id = value; }
        }
        int system_Users_Id;

        public int System_Users_Id
        {
            get { return system_Users_Id; }
            set { system_Users_Id = value; }
        }
        int degree_Level_Id;

        public int Degree_Level_Id
        {
            get { return degree_Level_Id; }
            set { degree_Level_Id = value; }
        }
        string institution_Name;

        public string Institution_Name
        {
            get { return institution_Name; }
            set { institution_Name = value; }
        }
        int country_Id;

        public int Country_Id
        {
            get { return country_Id; }
            set { country_Id = value; }
        }
        int? city_Id=null;

        public int? City_Id
        {
            get { return city_Id; }
            set { city_Id = value; }
        }
        string degree_Obtained;

        public string Degree_Obtained
        {
            get { return degree_Obtained; }
            set { degree_Obtained = value; }
        }
        string completion_Year;

        public string Completion_Year
        {
            get { return completion_Year; }
            set { completion_Year = value; }
        }
        string grade;

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        double cgpa;

        public double Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }
        double percentage;

        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
        public string Division { get; set; }
        public string Subjects { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }



    }
}
