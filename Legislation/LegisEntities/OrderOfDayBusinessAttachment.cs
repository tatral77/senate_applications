using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrderOfDayBusinessAttachment
    {
        public int OrderOfDayAttachmentsId { get; set; }
        public int OrderOfDayBusinessId { get; set; }
        public string Attachment { get; set; }
    }
}
