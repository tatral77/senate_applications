using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Province
    {
        private int provincesID;

        public int ProvincesID
        {
            get { return provincesID; }
            set { provincesID = value; }
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
        private int sortorder;

        public int Sortorder
        {
            get { return sortorder; }
            set { sortorder = value; }
        }
    }
}
