using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
   public class EmpSearchList
    {
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private string empDesignation;

        public string EmpDesignation
        {
            get { return empDesignation; }
            set { empDesignation = value; }
        }
        private string bps;

        public string Bps
        {
            get { return bps; }
            set { bps = value; }
        }
        private string empAddress;

        public string EmpAddress
        {
            get { return empAddress; }
            set { empAddress = value; }
        }
        private string empstatus;

        public string Empstatus
        {
            get { return empstatus; }
            set { empstatus = value; }
        }
        private string filenumber;

        public string Filenumber
        {
            get { return filenumber; }
            set { filenumber = value; }
        }
        private string age;

        public string Age
        {
            get { return age; }
            set { age = value; }
        }
       public string LocalAddress { get; set; }
       public string EmailAddress { get; set; }
       public int PreviousLeaveCredit { get; set; }
        public int CurrentYearCredit { get; set; }
        public int AvailedLeave { get; set; }
       public DateTime HouseServiceStartDate { get; set; }
        public DateTime GovtServiceStartDate { get; set; }
        public int TotalLeaveCredit { get; set; }
        public double PersonalNumber { get; set;}
        public string Branch { get; set; }
        public int CreditAvailableForEncashment { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredOn { get; set; }
        public string RecheckedBy { get; set; }
        public string ImageUrl { get; set; }
        public int AppointmentPostId { get; set; }
        public string AppointmentPost { get; set; }
        public int AppointmentBpsId { get; set; }
        public string AppointmentBps { get; set; }
        public string AppointmentEmplStatus { get; set; }
        public DateTime AppointmentDate { get; set; }
        public PromotionHistory promotion { get; set; }
        public string  EmployeeQuota { get; set; }
        public string OtherEmploymentQuota { get; set; }
        public int IsOpted { get; set; }
    }

}
