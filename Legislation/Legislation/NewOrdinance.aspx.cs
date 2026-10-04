using LegisEntities;
using LegisBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class NewOrdinance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
            }

        }
        public void BindCombos()
        {
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();

            if (assemblySessions != null)
            {
                List<AssemblySessions> sorted = assemblySessions;
                foreach (AssemblySessions row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    AssemblySessionDDL.Items.Add(li);
                }
            }

            List<ParliamentaryYears> parliamentaryYears = new LegislationBiz().GetParliamentaryYears();

            if (parliamentaryYears != null)
            {
                List<ParliamentaryYears> sorted = parliamentaryYears.OrderByDescending(o => o.FromDate).ToList();
                foreach (ParliamentaryYears row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.ParliamentaryYear;
                    li.Value = row.ParliamentaryYearsId.ToString();
                    ParliamentaryYearDDL.Items.Add(li);
                }
            }
        }
        public void Insertordinance()
        {
            int id = 0;
            id = new LegislationBiz().GetPk("ORDINANCES", "ORDINANCES_ID");
            Ordinances ordinance = new Ordinances();
            ordinance.OrdinanceId = id;
            ordinance.ParliamentaryYearsId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            ordinance.AssemblySessionsId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            ordinance.Title = Convert.ToString(TitleTxt.Text);
            //ordinance.Remarks = Convert.ToString(Remarks.Text);
            ordinance.DateOfPromulgation = Convert.ToDateTime(DateOfPromulgationTxt.Text);
            new LegislationBiz().InsertOrdinance(ordinance);
            if (id != 0)
                Response.Redirect("~/OrdinanceDetails.aspx?Id=" + id);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Insertordinance();
        }

    }
}