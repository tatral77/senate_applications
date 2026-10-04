using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmployeePools
    {
        private int empPoolsId;

        public int EmpPoolsId
        {
            get { return empPoolsId; }
            set { empPoolsId = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int isActive;

        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        private int sortOrder;

        public int SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }
    }
}
