using EstablishmentDAL;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;

namespace EstablishmentBIZ
{
    public class DashboardBIZ
    {
        // Builds every card shown on the HRM home page. To add a new card, add one more block here.
        public List<DashboardCard> GetCards()
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);
            DateTime nextMonth = monthStart.AddMonths(1);

            // Rest of the current week (Monday-Sunday), end exclusive.
            int daysToSunday = (7 - (int)today.DayOfWeek) % 7;
            DateTime weekEnd = today.AddDays(daysToSunday + 1);

            DashboardDAL dal = new DashboardDAL();
            List<DashboardCard> cards = new List<DashboardCard>();

            cards.Add(new DashboardCard
            {
                Title = "Retiring This Month",
                Subtitle = monthStart.ToString("MMMM yyyy"),
                CssClass = "accent-red",
                DateLabel = "Retires on",
                Employees = dal.GetRetiringBetween(monthStart, nextMonth)
            });
            cards.Add(new DashboardCard
            {
                Title = "Leave Ending This Week",
                Subtitle = today.ToString("dd MMM") + " - " + weekEnd.AddDays(-1).ToString("dd MMM"),
                CssClass = "accent-amber",
                DateLabel = "Leave ends",
                Employees = dal.GetLeaveEndingBetween(today, weekEnd)
            });
            cards.Add(new DashboardCard
            {
                Title = "Probation Ending This Week",
                Subtitle = today.ToString("dd MMM") + " - " + weekEnd.AddDays(-1).ToString("dd MMM"),
                CssClass = "accent-blue",
                DateLabel = "Probation ends",
                Employees = dal.GetProbationEndingBetween(today, weekEnd)
            });
            foreach (DashboardCard c in cards) c.ApplyDateLabel();
            return cards;
        }
    }
}
