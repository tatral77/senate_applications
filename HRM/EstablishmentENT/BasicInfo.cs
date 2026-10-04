using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class BasicInfo
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
        public string FileNumber { get; set; }
        public int MainHead { get; set; }
        public int Gender { get; set; }
        public double PersonalNumber { get; set; }
    }
}
