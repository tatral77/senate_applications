using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillContents
    {
        public int BillContentsId { get; set; }
        public int VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public int IsLatestVer { get; set; }
        public string Preamble { get; set; }
        public string Introduction { get; set; }
        public string ShortTitle { get; set; }
        public string Extent { get; set; }
        public string Commencement { get; set; }
        public string BillDescription { get; set; }
        public int BillsId { get; set; }
        public int BillVersionTypesId { get; set; }
        public int RolesId { get; set; }
        public int BillContentDetailsId { get; set; }
        public String StmtOfObjects { get; set; }
    }
}
