using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillDocumentsEnt
    {
        public int DocumentId { get; set; }
        public string DocumentDescription { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentType { get; set; }
        public int BillId { get; set; }
        public string Url { get; set; }
        public DateTime AttachmentDate { get; set; }
    }
}
