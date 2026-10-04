using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationPages
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string Url { get; set; }
        public string InnerFunction { get; set; }
        public string InnerCss { get; set; }
        public int ApplicationId { get; set; }
    }
}
