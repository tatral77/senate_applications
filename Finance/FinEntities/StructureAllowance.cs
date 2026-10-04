using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class StructureAllowance
    {
        public int StructureId { get; set; }
        public string StructureDesc { get; set; }
        public int AllowanceId { get; set; }
        public string AllowanceDesc { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public string Id { get; set; }
        public double Amount { get; set; }
    }
}
