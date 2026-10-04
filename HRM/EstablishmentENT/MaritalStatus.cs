using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class MaritalStatus
    {
        private int maritalStatusId;

        public int MaritalStatusId
        {
            get { return maritalStatusId; }
            set { maritalStatusId = value; }
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
