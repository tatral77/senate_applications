using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class TempEntity
    {
        public int Id { get; set; }
        public int SystemUserId { get; set; }
        public string Description { get; set; }
        public int year { get; set; }
        public int IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
