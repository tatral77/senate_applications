using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class NewEmployee
    {
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private int empName;

        public int EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private string FileNumber { get; set; }
        private int MainHead { get; set; }
        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
