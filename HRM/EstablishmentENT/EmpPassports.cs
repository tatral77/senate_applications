using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpPassports
    {
        private int empPassportId;

        public int EmpPassportId
        {
            get { return empPassportId; }
            set { empPassportId = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private string passportNumber;

        public string PassportNumber
        {
            get { return passportNumber; }
            set { passportNumber = value; }
        }
        private DateTime issueDate;

        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }
        private DateTime validUpto;

        public DateTime ValidUpto
        {
            get { return validUpto; }
            set { validUpto = value; }
        }
        private int passportTypeId;

        public int PassportTypeId
        {
            get { return passportTypeId; }
            set { passportTypeId = value; }
        }
        public string PassportType { get; set; }
        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }
        private int cityId;

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
