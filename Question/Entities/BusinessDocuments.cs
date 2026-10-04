using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BusinessDocuments
    {
        public int DocumentId { get; set; }
        public string Description { get; set; }
        public int BusinessId { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentUrl { get; set; }
        public int InsertedById { get; set; }
        public DateTime InsertedOn { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int IsListed { get; set; }
    }
}
