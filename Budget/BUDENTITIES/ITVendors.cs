using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class Vendors
    {
        public int VendorId { get; set; }
        public string Vendor { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string Emails { get; set; }
        public string Details { get; set; }
        public string NTN { get; set; }
        public string VendorNumber { get; set; }
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
    }
}
