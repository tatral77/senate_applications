using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PurchaseItem
    {
        public int PurchaseItemId { get; set; }
        public int PurchaseId { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public int UnitQuantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalItems { get; set; }
        public int TotalPrice { get; set; }
        public int SingleItemPrice { get; set; }
        public string Remarks  { get; set; }
    }
}
