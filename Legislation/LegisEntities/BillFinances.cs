using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillFinances
    {
        public int BillFinancesID { get; set; }
        public DateTime DFGDays { get; set; }
        public DateTime BFTime { get; set; }
        public int BillsId { get; set; }
        public int SystemUsersId { get; set; }
        public int BillFinanceTypesId { get; set; }
    }
}
