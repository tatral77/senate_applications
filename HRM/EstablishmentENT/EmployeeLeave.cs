using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmployeeLeave
    {
       public int EmpLeaveId { get; set; }
       public int EmpId { get; set; }
       public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public int LeaveSubTypeId { get; set; }
        public string LeaveSubType { get; set; }
       public int ExPakistan { get; set; }
        public int IsExtension { get; set; }
       public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
       public DateTime EndDate { get; set; }
       public DateTime ExpectedJoiningDate { get; set; }
       public DateTime? JoiningDate { get; set; }
       public int DaysApplied { get; set; }
       public int DaysAvailed { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
