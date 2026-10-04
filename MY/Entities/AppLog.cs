using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AppLog
    {
        public int LogId { get; set; }
        public string Details { get; set; }
        public string LogTable { get; set; }
        public DateTime LogDate { get; set; }
    }
}
