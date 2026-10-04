using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveDetailsLib
{
    public class LeaveUtil
    {
        public EmpLeaveDetails GetCreditInSameYearDifferentMonths(DateTime StartDate, DateTime EndDate, int LeaveType, int LeaveSubType)
        {

            EmpLeaveDetails lc = new EmpLeaveDetails();
            int StartMonth = StartDate.Month;
            int StartYear = StartDate.Year;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            int DaysInMonth = 0;
            int HalfOfMonth = 0;
            lc.ServiceYear = StartYear;
            for (int j = StartMonth; j <= EndMonth; j++)
            {
                DaysInMonth = 0;
                HalfOfMonth = 0;

                if (j == StartMonth && j == EndMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = ((EndDay - StartDay) + 1);
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else if (j == StartMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = ((DaysInMonth - StartDay) + 1);
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else if (j == EndMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = EndDay;
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else
                {
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += DateTime.DaysInMonth(StartYear, j);
                    else if (LeaveSubType == 3)
                        lc.EOL += DateTime.DaysInMonth(StartYear, j);
                    lc.LeaveDeducted += 4;
                }


            }
            if (LeaveSubType == 2)
                lc.AvailedLeave = lc.AvailedLeave / 2;
            if (LeaveType == 7)
                lc.AvailedLeave = lc.AvailedLeave - 5;
            return lc;
        }

        public List<EmpLeaveDetails> GetCreditInDifferentYears(DateTime StartDate, DateTime EndDate, int LeaveType, int LeaveSubType)
        {
            List<EmpLeaveDetails> lcs = new List<EmpLeaveDetails>();
            int StartMonth = StartDate.Month;
            int StartYear = StartDate.Year;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            int DaysInMonth = 0;
            int HalfOfMonth = 0;
            int startmonth = 0;
            int endmonth = 0;

            for (int i = StartYear; i <= EndYear; i++)
            {
                startmonth = 1;
                endmonth = 12;
                EmpLeaveDetails lc = new EmpLeaveDetails();
                lc.ServiceYear = i;
                if (i == StartYear)
                {
                    startmonth = StartMonth;
                    endmonth = 12;
                }
                if (i == EndYear)
                {
                    startmonth = 1;
                    endmonth = EndMonth;
                }

                for (int j = startmonth; j <= endmonth; j++)
                {
                    DaysInMonth = DateTime.DaysInMonth(i, j);
                    HalfOfMonth = (DaysInMonth / 2);
                    if (j == StartMonth && i == StartYear)
                    {
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                            lc.AvailedLeave += ((DaysInMonth - StartDay) + 1);
                        else if (LeaveSubType == 3)
                            lc.EOL += ((DaysInMonth - StartDay) + 1);
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else if (j == EndMonth && i == EndYear)
                    {
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                            lc.AvailedLeave += EndDay;
                        else if (LeaveSubType == 3)
                            lc.EOL += EndDay;
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else
                    {
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                            lc.AvailedLeave += DateTime.DaysInMonth(i, j);
                        else if (LeaveSubType == 3)
                            lc.EOL += DateTime.DaysInMonth(i, j);

                        lc.LeaveDeducted += 4;
                    }
                    if (LeaveSubType == 2)
                        lc.AvailedLeave = lc.AvailedLeave / 2;
                    if (LeaveType == 7)
                        lc.AvailedLeave = lc.AvailedLeave - 5;
                }
                lcs.Add(lc);
            }
            lcs.TrimExcess();
            return lcs;

        }


        public List<EmpLeaveDetails> CalculateSuspensionPeriod(int EmpId)
        {
            List<DisciplinaryAction> da = new EmploymentBIZ().GetEmpSuspensions(EmpId);
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
            if (da != null)
            {
                foreach (DisciplinaryAction row in da)
                {
                    if (row.IsLfpCalculated == 0)
                    {
                        DateTime StartDate = row.FromDate;
                        DateTime EndDate = row.ToDate;
                        int LeaveType = 3;
                        int StartMonth = StartDate.Month;
                        int StartYear = StartDate.Year;
                        int StartDay = StartDate.Day;
                        int EndYear = EndDate.Year;
                        int EndMonth = EndDate.Month;
                        int EndDay = EndDate.Day;
                        string Remarks = "Suspended from " + StartDate.ToShortDateString() + " to " + EndDate.ToShortDateString();
                        if (StartMonth == EndMonth)
                        {
                            EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType, 3);
                            lc.Remarks = Remarks;
                            details.Add(lc);

                        }
                        else if (StartMonth != EndMonth && StartYear == EndYear)
                        {
                            EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType, 3);
                            lc.Remarks = Remarks;
                            details.Add(lc);
                        }
                        else if (StartYear != EndYear)
                        {
                            List<EmpLeaveDetails> LeaveDetail = GetCreditInDifferentYears(StartDate, EndDate, LeaveType, 3);
                            foreach (EmpLeaveDetails lc in LeaveDetail)
                            {
                                lc.Remarks = Remarks;
                                details.Add(lc);
                            }
                        }
                    }
                }
            }
            return details;

        }
    }
}
