using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Details { get; set; }
        public int MainItemId  { get; set; }
        public string MainItem { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int IsActive { get; set; }
        public int OpeningBalance { get; set; }
        public int CurrentBalance { get; set; }
        public int PriceUnit { get; set; }
        public string  PriceUnitDesc { get; set; }
        public int UnitQuantity { get; set; }
        public int Price { get; set; }
        public int ThresholdLevel { get; set; }
        public int ItemsInPacking { get; set; }
        public int TotalCurrentItems { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
    }
}
