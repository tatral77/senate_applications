using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        public string Application { get; set; }
        public int IsActive { get; set; }
    }
}
