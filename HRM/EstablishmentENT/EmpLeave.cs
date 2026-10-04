using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpLeave
    {
        private int empLeaveId;

        public int EmpLeaveId
        {
            get { return empLeaveId; }
            set { empLeaveId = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private int leaveTypeId;

        public int LeaveTypeId
        {
            get { return leaveTypeId; }
            set { leaveTypeId = value; }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        private string nocNumb;

        public string NocNumb
        {
            get { return nocNumb; }
            set { nocNumb = value; }
        }
        private DateTime nocDate;

        public DateTime NocDate
        {
            get { return nocDate; }
            set { nocDate = value; }
        }

    }
}
