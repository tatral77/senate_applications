using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Documents
    {
        public int DocumentId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentType { get; set; }
        public int BranbchId { get; set; }
        public string Branch { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentTime { get; set; }
        public string Subject { get; set; }
    }
}
