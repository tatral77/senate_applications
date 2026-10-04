using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<BasicInfo> Employees = new EmployeeHandler().GetEmployeeByName();
            BasicInfo FoundEmps = null;
            if(Employees!=null)
            {
                foreach(BasicInfo bi in Employees)
                {
                    FoundEmps = new EmployeeHandler().GetEmployeeByName(Before(bi.EmpName,"."));
                    if(FoundEmps!=null)
                    new EmploymentBIZ().InsertPersonalNumber(bi.EmpId, FoundEmps.PersonalNumber);
  
                        
                    }
                    
                }
            }
        public  string Before(string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }
    }
    }
