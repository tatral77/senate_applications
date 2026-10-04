using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class LeaveEnchashmentOptEnt
    {
        public int LeaveEncashmentOptId { get; set; }
        public int StystemUsersId { get; set; }
        public int Year { get; set; }
        public int Days { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
