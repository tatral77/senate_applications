using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PassportTypes
    {
        private int passportTypeId;

        public int PassportTypeId
        {
            get { return passportTypeId; }
            set { passportTypeId = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int is_Active;

        public int Is_Active
        {
            get { return is_Active; }
            set { is_Active = value; }
        }
    }
}
