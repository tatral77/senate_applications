using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class BPS
    {
        private int bpsId;

        public int BpsId
        {
            get { return bpsId; }
            set { bpsId = value; }
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

    }
}
