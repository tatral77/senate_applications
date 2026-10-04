using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillAmendAttachments
    {
        public int BillAmendAttachmentsId { get; set; }
        public int BillAmendmentsId { get; set; }
        public int DocumentsId { get; set; }
        public int SystemUsersId { get; set; }
    }
}
