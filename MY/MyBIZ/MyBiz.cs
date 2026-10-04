using ManEntities;
using MyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBIZ
{
    public class MyBiz
    {
        public User GetEmployeeUser(double PersonalNumber, string Password)
        {
            return new MyDal().GetEmployeeUser(PersonalNumber, Password);
        }
        }
}
