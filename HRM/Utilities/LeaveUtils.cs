using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class LeaveUtils
    {
    //    public List<EmployeeLeave> EmployeeAllLeaves(int EmpId)
    //    {
    //        List<EmployeeLeave> EmpLeave = new EmployeeHandler().GetAllLeaves(EmpId);
    //        List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
    //        foreach (EmployeeLeave row in EmpLeave)
    //        {
    //            DateTime StartDate = Convert.ToDateTime(row.StartDate);
    //            DateTime EndDate = Convert.ToDateTime(row.EndDate);
    //            int LeaveType = row.LeaveSubTypeId;
    //            int StartMonth = StartDate.Month;
    //            int StartYear = StartDate.Year;
    //            int StartDay = StartDate.Day;
    //            int EndYear = EndDate.Year;
    //            int EndMonth = EndDate.Month;
    //            int EndDay = EndDate.Day;

    //            if (StartMonth == EndMonth)
    //            {
    //                EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
    //                details.Add(lc);

    //            }
    //            else if (StartMonth != EndMonth && StartYear == EndYear)
    //            {
    //                EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
    //                details.Add(lc);
    //            }
    //            else if (StartYear != EndYear)
    //            {
    //                List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType);
    //                foreach (EmpLeaveDetails lc in ld)
    //                {
    //                    details.Add(lc);
    //                }
    //            }
    //        }
    //        int startyear = 0;
    //        List<EmpLeaveDetails> Calculated = new List<EmpLeaveDetails>();
    //        foreach (EmpLeaveDetails row in details)
    //        {

    //            if (startyear != row.ServiceYear)
    //            {
    //                EmpLeaveDetails ed = new EmpLeaveDetails();
    //                startyear = row.ServiceYear;
    //                ed.ServiceYear = row.ServiceYear;
    //                ed.AvailedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.AvailedLeave);
    //                ed.LeaveDeducted = details.Where(item => item.ServiceYear == startyear).Sum(item => item.LeaveDeducted);
    //                ed.Remarks = row.Remarks;
    //                //ed.EarnedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EarnedLeave);
    //                ed.EOL = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EOL);

    //                Calculated.Add(ed);
    //            }
    //        }
    //    }
    //}
     
    }
}
