using System;
namespace Entities

{
    public class Visitors
    {
        
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string Details { get; set; }
        public string Cnic { get; set; }
        public string PassId { get; set; }
        public int Verified { get; set; }
        public virtual VisitorPasses VisitorPasses { get; set; }

    }
}
