using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpStatus
    {
        private int empStatusId;

        public int EmpStatusId
        {
            get { return empStatusId; }
            set { empStatusId = value; }
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
    }
}
