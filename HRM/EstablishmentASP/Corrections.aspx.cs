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
    public partial class Corrections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindCorrectionLV();
            }
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindCorrectionLV()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int systemusersid = Convert.ToInt32(reqCookies["SystemUsersId"]);
                List<Correction> Corrections = new EmployeeHandler().GetUnSolvedCorrections();
                CorrectionLV.DataSource = Corrections;
                CorrectionLV.DataBind();
            }
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CorrectionLV.InsertItemPosition = InsertItemPosition.None;
            CorrectionLV.SelectedIndex = -1;
            CorrectionLV.EditIndex = e.NewEditIndex;
            bindCorrectionLV();
            e.Cancel = true;

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            CorrectionLV.EditIndex = -1;
            CorrectionLV.InsertItemPosition = InsertItemPosition.None;
            CorrectionLV.SelectedIndex = -1;
            bindCorrectionLV();
            e.Cancel = true;
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int systemusersid = Convert.ToInt32(reqCookies["SystemUsersId"]);
                HiddenField HidCorrectionId = CorrectionLV.EditItem.FindControl("HidCorrectionId") as HiddenField;
                TextBox CorrectionTxt = CorrectionLV.EditItem.FindControl("CorrectionTxt") as TextBox;
                Correction eh = new Correction();
                eh.CorrectionId = Convert.ToInt32(HidCorrectionId.Value);
                eh.CorrectionTxt = Convert.ToString(CorrectionTxt.Text);
                new EmployeeHandler().UpdateCorrection(eh);
                CorrectionLV.EditIndex = -1;
                bindCorrectionLV();
                CorrectionLV.InsertItemPosition = InsertItemPosition.None;
                CorrectionLV.SelectedIndex = -1;
                e.Cancel = true;
            }

        }
        protected void EmpDepButton_Click(object sender, EventArgs e)
        {
            CorrectionLV.SelectedIndex = -1;
            CorrectionLV.EditIndex = -1;
            CorrectionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindCorrectionLV();

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int systemusersid = Convert.ToInt32(reqCookies["SystemUsersId"]);
                TextBox CorrectionTxt = CorrectionLV.InsertItem.FindControl("CorrectionTxt") as TextBox;
                Correction comp = new Correction();
                comp.SystemUsersId = systemusersid;
                comp.CorrectionTxt = Convert.ToString(CorrectionTxt.Text);
                comp.CorrectionDate = DateTime.Now;
                new EmployeeHandler().InsertCorrection(comp);
                CorrectionLV.EditIndex = -1;
                bindCorrectionLV();
                CorrectionLV.InsertItemPosition = InsertItemPosition.None;
                CorrectionLV.SelectedIndex = -1;
                e.Cancel = true;
                Response.Redirect("Corrections.aspx");
            }
        }


        protected void NewCorrectionBtn_Click(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int systemusersid = Convert.ToInt32(reqCookies["SystemUsersId"]);
                CorrectionLV.SelectedIndex = -1;
                CorrectionLV.EditIndex = -1;
                CorrectionLV.InsertItemPosition = InsertItemPosition.FirstItem;
                bindCorrectionLV();
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidCorrectionId = (HiddenField)CorrectionLV.Items[e.ItemIndex].FindControl("HidCorrectionId");
            int Correctionid = Convert.ToInt32(HidCorrectionId.Value);
            new EmployeeHandler().DeleteCorrection(Correctionid);
            bindCorrectionLV();

        }

        protected void SolvedBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int CorrectionId = Convert.ToInt32(btn.CommandArgument);
            new EmployeeHandler().SolveCorrection(CorrectionId);
            bindCorrectionLV();
        }

        protected void StatusDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StatusId=Convert.ToInt32(StatusDDL.SelectedValue);
            List<Correction> Corrections = null;
            if (StatusId==1)
                 Corrections = new EmployeeHandler().GetSolvedCorrections();
            else if(StatusId == 0)
                Corrections = new EmployeeHandler().GetUnSolvedCorrections();
            CorrectionLV.DataSource = Corrections;
            CorrectionLV.DataBind();
        }
    }
}