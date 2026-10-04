using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResolutionSubmittersEnt
    {
        public int ResolutionsSubmittersId { get; set; }
        public int ResolutionsId { get; set; }
        public int SystemUsersId { get; set; }
        public string MoverName { get; set; }
    }
}
