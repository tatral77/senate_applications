using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class TravelSchedule
    {
        public int TravelScheduleId { get; set; }
        public int VisitId { get; set; }
        public int DepCityId { get; set; }
        public string DepCity { get; set; }
        public DateTime DepDate { get; set; }
        public DateTime DepTime { get; set; }
        public int ArrCityId { get; set; }
        public string ArrCity { get; set; }
        public DateTime ArrDate { get; set; }
        public DateTime ArrTime { get; set; }
        public string FlighNumber { get; set; }
        public int TravellingCalculated { get; set; }
    }
}
