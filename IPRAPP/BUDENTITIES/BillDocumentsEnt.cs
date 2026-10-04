using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class BillDocumentsEnt
    {
        public int DocumentId { get; set; }
        public string DocumentDescription { get; set; }
        public int BillId { get; set; }
        public string Url { get; set; }
    }
}
