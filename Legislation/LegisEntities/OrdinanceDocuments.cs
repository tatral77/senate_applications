using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrdinanceDocuments
    {
        public int OrdinanceDocumentsId { get; set; }
        public int DocumentTypeId { get; set; }
        public int OrdinancesId { get; set; }
        public String Description { get; set; }
        public String DocumentUrl { get; set; }
        public DateTime AttachmentDate { get; set; }
    }
}
