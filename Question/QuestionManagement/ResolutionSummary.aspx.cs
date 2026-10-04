using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ResolutionSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindListView1();
                bindFields();
            }

        }
        private void bindFields()
        {
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                FromAssemblySessionDDL.Items.Add(li);
                ToAssemblySessionDDL.Items.Add(li);
            }
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            int fromsession = Convert.ToInt32(FromAssemblySessionDDL.SelectedItem.Value);
            int tosession = Convert.ToInt32(ToAssemblySessionDDL.SelectedItem.Value);
            List<ResolutionSummaryEnt> QSummary = new ResolutionBiz().GetStatusNoOfResolutions(fromsession, tosession);
            if (QSummary != null)
            {
                TotalLabelLbl.Visible = true;
                TotalQuestionsLbl.Text = Convert.ToString(QSummary.Count());

                var categoryCounts =
              from p in QSummary
              group p by p.Status into g
              select new { Category = g.Key, ProductCount = g.Count() };
                // var ordered = categoryCounts.OrderBy(x => x.Category);
                ListView1.DataSource = categoryCounts;
                ListView1.DataBind();
            }
            else
                TotalLabelLbl.Visible = false;


        }
    }
}