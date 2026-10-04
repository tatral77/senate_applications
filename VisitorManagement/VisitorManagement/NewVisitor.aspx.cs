using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VisitorManagement
{
    public partial class NewVisitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<PassTypes> pt = new Biz().GetPassTypes();

                foreach (PassTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PassTypeId.ToString();
                    cy.Text = row.Description.ToString();
                    VisitTypeDDL.Items.Add(cy);
                }
                VisitDateTxt.Text = DateTime.Now.ToString("dd/MM/yyy hh:mm tt");
            }
        }

        protected void InsertVisitor_Click(object sender, EventArgs e)
        {
            WalkInVisitor walkInVisitor = new WalkInVisitor();
            walkInVisitor.VisitorName = VisitorNameTxt.Text;
            if (CNIC.Text.Length < 13)
                cnicerror.Visible = true;
            else
            {
                walkInVisitor.Cnic = CNIC.Text;
                cnicerror.Visible = false;
                if (!string.IsNullOrEmpty(HidRequestedById.Value))
                    walkInVisitor.PersonToVisitId = Convert.ToInt32(HidRequestedById.Value);
                walkInVisitor.PersonToVisitName = RequestedByTxt.Text;
                walkInVisitor.VisitTypeId = Convert.ToInt32(VisitTypeDDL.SelectedValue);
                walkInVisitor.VisitDate = DateTime.Now;
                walkInVisitor.Details = PurposeTxt.Text;
                new Biz().AddWalkInVisitor(walkInVisitor);
                SuccessLbl.Visible = true;
                VisitorNameTxt.Text = "";
                CNIC.Text = "";
                HidRequestedById.Value = "";
                RequestedByTxt.Text = "";
                PurposeTxt.Text = "";
            }
           

        }
    }
}