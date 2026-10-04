using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUDENTITIES
{
    public class Branch
    {
        private int branchid;

        public int Branchid
        {
            get { return branchid; }
            set { branchid = value; }
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
