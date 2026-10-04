using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PhoneTypes
    {
        private int phoneTypeID;

        public int PhoneTypeID
        {
            get { return phoneTypeID; }
            set { phoneTypeID = value; }
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
