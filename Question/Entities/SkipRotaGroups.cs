using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SkipRotaGroups
    {
        public int SkipRotaGroupId { get; set; }
        public int RotaId { get; set; }
        public DateTime SkipDate { get; set; }
        public int SkipGroup { get; set; }
        public string SkipGroupDesc { get; set; }
    }
}
