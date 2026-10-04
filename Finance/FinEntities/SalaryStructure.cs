using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class SalaryStructure
    {
        public int SalaryStructureId { get; set; }
        public string Description { get; set; }
        public int MemberSalCategoryId { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public string MemberSalCategory { get; set; }
        public int FundCenterId { get; set; }
        public int IsCurrent { get; set; }
    }
}
