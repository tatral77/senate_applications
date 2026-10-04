using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmployeePhones
    {
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private int empPhoneId;

        public int EmpPhoneId
        {
            get { return empPhoneId; }
            set { empPhoneId = value; }
        }
        private string phoneType;

        public string PhoneType
        {
            get { return phoneType; }
            set { phoneType = value; }
        }
        private int phoneTypeId;

        public int PhoneTypeId
        {
            get { return phoneTypeId; }
            set { phoneTypeId = value; }
        }
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
