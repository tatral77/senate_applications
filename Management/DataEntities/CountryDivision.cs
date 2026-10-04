using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class CountryDivision
    {
        public int CountryDivisionId { get; set; }
        public string CountryDivisionName { get; set; }
        public int CountryDivisionTypeId { get; set; }
        public string CountryDivisionType { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int IsActive { get; set; }
    }
}
