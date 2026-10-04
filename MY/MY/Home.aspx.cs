using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MY
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string systemusersid = string.Empty;
            string FullName = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                systemusersid = reqCookies["SystemUsersId"].ToString();
                FullName = reqCookies["FullName"].ToString();
                int empval = Convert.ToInt32(systemusersid);
                // new EmploymentBIZ().UpdateEmploymentStatus(Convert.ToInt32(empval));
                EmpHeaderInfo EmpInfo = new EmpHeaderInfo();
                EmpInfo = new EmployeeHandler().GetEmpName(Convert.ToInt32(empval));
                EmpHeaderInfo EmpDesig = new EmployeeHandler().GetEmpDesignation(Convert.ToInt32(empval));
                FullName = EmpInfo.EmpName.ToString() + " -- ";
                if (!String.IsNullOrEmpty(EmpDesig.POST))
                    FullName += EmpDesig.POST.ToString() + "  (" + EmpDesig.BPS.ToString() + ") ";
                else
                    FullName += " Post and BPS not mentioned--";
                header.InnerText = FullName;

            }
            else
                Response.Write("Cookies not found");
        }
    }
}