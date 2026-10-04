using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchases
    {
        public int PurchaseId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string OfficeFileNo { get; set; }
        public DateTime OfficeFileDate { get; set; }
    }
}
