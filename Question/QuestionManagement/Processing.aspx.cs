using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;

namespace QuestionManagement
{
    public partial class Processing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangeGroupsBtn_Click(object sender, EventArgs e)
        {
            int first;
            int second;
            int third;
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions asessions in ASessions)
            {
                for (int i = 1; i <= 5; i++)
                {
                    first = 0; second = 0; third = 0;
                    List<Groups> groups = new QuestionBiz().GetSessionCorrespondingGroup(asessions.AssemblySessionsId, i);
                    foreach (Groups gps in groups)
                    {
                        if (first == 0)
                            first = gps.GroupsId;
                        else if (second == 0)
                            second = gps.GroupsId;
                        else if (third == 0)
                            third = gps.GroupsId;

                    }
                    new QuestionBiz().ChangeGroups(first, second, third);

                }

            }
        }

        protected void CalculateDaysBtn_Click(object sender, EventArgs e)
        {
            DateTime StartDate = Convert.ToDateTime(StartDateTxt.Text);
            DateTime EndDate = Convert.ToDateTime(EndDateTxt.Text);
            NumberOfDaysTxt.Text = (((EndDate - StartDate).TotalDays) - 1).ToString();
        }
    }
}