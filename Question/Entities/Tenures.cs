using System;

namespace Entities
{
    public class Tenures
    {
        public int MemTenuresId { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IsActive { get; set; }
        public int IsCurrent { get; set; }

    }
}
