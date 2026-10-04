using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int ApplicationId { get; set; }
        public string Application { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public int IsActive { get; set; }
    }
}
