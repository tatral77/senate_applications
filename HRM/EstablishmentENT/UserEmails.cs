using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class UserEmails
    {
        public int UserEmailId { get; set; }
        public int SystemUsersId { get; set; }
        public string Email { get; set; }
        public int IsOfficial { get; set; }
        public int IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
