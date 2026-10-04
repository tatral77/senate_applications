using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserTypes
    {
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public int CanAdd { get; set; }
        public int CanEdit { get; set; }
        public int CanDelete { get; set; }
    }
}
