using System;
using System.Collections.Generic;

namespace Entities
{
    public class QuestionsRota
    {
        public int RotaListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public int SessionNumber { get; set; }
        public string ListType { get; set; }
        public int StartListNo { get; set; }
        public int RotaWeekDayId { get; set; }
        public string RotaWeekDay { get; set; }
        public string Days { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SkipRotaGroups> SkipRotaGroups { get; set; }
        public int StartGroup { get; set; }
        public string SkipDays { get; set; }
        public string AllowedDates { get; set; }
    }
}
