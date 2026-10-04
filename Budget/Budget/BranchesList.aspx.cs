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
    public partial class BranchesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindBranchLv();
            }

        }
        public string GetStatus(int StatusId)
        {
            if (StatusId == 1)
                return "Yes";
            else
                return "No";
        }
     
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            BranchLv.SelectedIndex = -1;
            BranchLv.EditIndex = -1;
            BranchLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindBranchLv();

        }
        protected void BindBranchLv()
        {
          //  List<Branch> BranchesList = new BudgetBiz().GetBranches();
          //  BranchLv.DataSource = BranchesList;
           // BranchLv.DataBind();

        }

     
                  
    }
}