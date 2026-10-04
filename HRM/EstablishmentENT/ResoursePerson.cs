using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class ResoursePerson
    {
        public int ResoursePersonId { get; set; }
        public int SystemUsersId { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public string Details { get; set; }
        public string Station { get; set; }
        public DateTime PresDate { get; set; }
        public string PresAs { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
