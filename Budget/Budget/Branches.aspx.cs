using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Budget
{
    public partial class Branches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBranchLV();
            }
        }

        protected void BindBranchLV()
        {

           
            List<Branch> BranchHead = new BudgetBiz().GetBranches();
            BillLV.DataSource = BranchHead;
            BillLV.DataBind();

        }
    }
}