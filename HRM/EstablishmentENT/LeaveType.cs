using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class LeaveType
    {
        private int leaveTypeId;

        public int LeaveTypeId
        {
            get { return leaveTypeId; }
            set { leaveTypeId = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int is_active;

        public int Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }
        private int daysallowed;

        public int Daysallowed
        {
            get { return daysallowed; }
            set { daysallowed = value; }
        }

    }
}
