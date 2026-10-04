using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillAttachments
    {
        public int BillAttachmentsId { get; set; }
        public int BillsId { get; set; }
        public int DocumentsId { get; set; }
        public int SystemUsersId { get; set; }
    }
}
