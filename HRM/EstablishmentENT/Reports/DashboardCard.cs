using System;
using System.Collections.Generic;

namespace EstablishmentENT.Reports
{
    public class DashboardEmployee
    {
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public string Post { get; set; }
        public string Bps { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public string DateLabel { get; set; }
    }

    // One card on the HRM home page. Add a new card by building one of these in DashboardBIZ.GetCards().
    public class DashboardCard
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string CssClass { get; set; }
        public string DateLabel { get; set; }
        public List<DashboardEmployee> Employees { get; set; }
        public void ApplyDateLabel() { foreach (DashboardEmployee e in Employees) e.DateLabel = DateLabel; }
        public int Count { get { return Employees == null ? 0 : Employees.Count; } }
    }
}
