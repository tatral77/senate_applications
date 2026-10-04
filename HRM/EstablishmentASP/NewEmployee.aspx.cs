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
    public partial class NewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["userinfo"];
            //if (userinfo != null)
            //{
            //    string role = userinfo.Value;
            //    if (role.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            bindFields();
        }
        private void bindFields()
        {
            List<EmployeePools> EmpPools = new AdministrationBIZ().GetEmpPools();
            foreach (EmployeePools row in EmpPools)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpPoolsId.ToString();
                MainHead.Items.Add(li);
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            BasicInfo binfo = new BasicInfo();
            binfo.EmpName = EmpName.Text;
            binfo.Gender = Convert.ToInt32(Gender.SelectedValue);
            binfo.FileNumber = Convert.ToString(FileNumber.Text);
            binfo.MainHead = Convert.ToInt32(MainHead.SelectedValue);
            int Empid = new EmployeeHandler().InsertNewEmployee(binfo);
            Response.Redirect("~/PersonalInformation.aspx?empid=" + Empid);

        }
    }
}