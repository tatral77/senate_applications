using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillReviews
    {
        public int BillReviewsId { get; set; }
        public int BillsId { get; set; }
        public String Remarks { get; set; }
        public string ReviewedBy { get; set; }
    }
}
