using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Country
    {
        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
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
