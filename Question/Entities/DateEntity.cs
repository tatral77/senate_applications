using System;

namespace Entities
{
    public class DateEntity
    {
        public DateTime date { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int weekdayid { get; set; }
        public string weekday { get; set; }
        public int GroupId { get; set; }
        public string GroupDescription { get; set; }
    }
}
