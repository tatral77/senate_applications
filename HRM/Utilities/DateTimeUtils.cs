using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class DateTimeUtils
    {
        public int CalculateNumberofDays(DateTime fromdate, DateTime todate)
        {
            int fromyear = fromdate.Year;
            int toyear = todate.Year;
            int frommonth = fromdate.Month;
            int tomonth = todate.Month;
            int fromday = fromdate.Day;
            int today = todate.Day;
            int NumberofDays = 0;
            int StartMonth = 0;
            int EndMonth = 0;

            for (int i = fromyear; i <= toyear; i++)
            {
                StartMonth = 1;
                EndMonth = 12;
                if (i == fromyear)
                    StartMonth = frommonth;
                if (i == toyear)
                    EndMonth = tomonth;
                for (int j = StartMonth; j <= EndMonth; j++)
                {

                    NumberofDays += DateTime.DaysInMonth(i, j);
                }
            }
            NumberofDays = NumberofDays - fromday;
            NumberofDays = NumberofDays - ((DateTime.DaysInMonth(toyear, tomonth) - (today)));

            //if (fromdate == todate)
            //    return
            //        NumberofDays+1;
            //else
            return NumberofDays+1;

        }
        public int DeductLFP(DateTime fromdate, DateTime todate)
        {
            int StartYear = fromdate.Year;
            int EndYear = todate.Year;
            int StartMonth = fromdate.Month;
            int EndMonth = todate.Month;
            int StartDay = fromdate.Day;
            int EndDay = todate.Day;
            int startmonth = 1;
            int endmonth = 12;
            int DeductLFP = 0;
            if (StartMonth == EndMonth && StartYear == EndYear)
            {
               int Leave= CalculateNumberofDays(fromdate, todate);
                int DaysInMonth = DateTime.DaysInMonth(StartYear, StartMonth);
                //int Leave = DaysInMonth - (StartDay - 1);
                if (Leave > ((DaysInMonth / 2) + 1))
                    DeductLFP += 4;

            }
            else
            {
                for (int i = StartYear; i <= EndYear; i++)
                {
                    startmonth = 1;
                    endmonth = 12;
                    if (i == StartYear)
                        startmonth = StartMonth;
                    if (i == EndYear)
                        endmonth = EndMonth;
                    for (int j = startmonth; j <= endmonth; j++)
                    {
                        if (j == StartMonth && i == StartYear)
                        {
                            int DaysInMonth = DateTime.DaysInMonth(StartYear, StartMonth);
                            int Leave = DaysInMonth - (StartDay - 1);
                            if (Leave > ((DaysInMonth / 2) + 1))
                                DeductLFP += 4;
                        }
                        else if (j == EndMonth && i == EndYear)
                        {
                            int DaysInMonth = DateTime.DaysInMonth(EndYear, EndMonth);
                            int Present = DaysInMonth - (EndDay);
                            if (Present < ((DaysInMonth / 2) + 1))
                                DeductLFP += 4;
                        }
                        else
                            DeductLFP += 4;

                    }
                }

            }

            return DeductLFP;
        }
        public DateTime GetEndDate(DateTime StartDate,int NoOfDays,int LeaveTypeId)
        {

            DateTime dt=new DateTime();
            if(LeaveTypeId==7)
                dt = StartDate.AddDays((NoOfDays - 1) + 5);
            else
            dt =StartDate.AddDays(NoOfDays-1);

            return Convert.ToDateTime(dt.ToShortDateString());
          
        }
        public DateTime GetJoiningDate(DateTime EndDate,int NumberOfDays, int LeaveTypeId)
        {
            //if (LeaveTypeId == 7)
            //{
            //    if (Convert.ToString(EndDate.AddDays(6).DayOfWeek) == "Saturday")
            //        return Convert.ToDateTime(EndDate.AddDays(8).ToShortDateString());
            //    else if (Convert.ToString(EndDate.AddDays(6).DayOfWeek) == "Sunday")
            //        return Convert.ToDateTime(EndDate.AddDays(7).ToShortDateString());
            //    else
            //        return Convert.ToDateTime(EndDate.AddDays(6).ToShortDateString());
            //}
            //else
            //{

                if (Convert.ToString(EndDate.AddDays(1).DayOfWeek) == "Saturday")
                    return Convert.ToDateTime(EndDate.AddDays(3).ToShortDateString());
                else if (Convert.ToString(EndDate.AddDays(1).DayOfWeek) == "Sunday")
                    return Convert.ToDateTime(EndDate.AddDays(2).ToShortDateString());
                else
                    return Convert.ToDateTime(EndDate.AddDays(1).ToShortDateString());
           // }
        }
        public string GetDay(DateTime date)
        {
            return Convert.ToString(date.DayOfWeek);
        }
        public int CalculateMonthsEarnedLFP(DateTime StartDate,DateTime EndDate)
        {
            int LFP = 0;
            int StartYear = StartDate.Year;
            int StartMonth = StartDate.Month;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            for (int j = StartMonth; j <= EndMonth; j++)
            {
                if (j == StartMonth)
                {
                    int DaysInMonth = DateTime.DaysInMonth(StartYear, StartMonth);
                    if (StartDay< ((DaysInMonth / 2) + 1))
                        LFP += 4;
                }
                else if (j == EndMonth)
                {
                    int DaysInMonth = DateTime.DaysInMonth(EndYear, EndMonth);
                    if (EndDay >=((DaysInMonth / 2) + 1))
                        LFP += 4;
                }
                else
                    LFP += 4;

            }
            return LFP;
        }
        public int CalculateCurrentMonthsEarnedLFP(DateTime StartDate, DateTime EndDate)
        {
            int LFP = 0;
            int today = DateTime.Now.Day;
            int StartYear = StartDate.Year;
            int StartMonth = StartDate.Month;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            for (int j = StartMonth; j <= EndMonth; j++)
            {
                if (j == EndMonth)
                {
                    int DaysInMonth = DateTime.DaysInMonth(EndYear, EndMonth);
                    if (EndDay >= ((DaysInMonth / 2) + 1))
                        LFP += 4;
                }
                else
                    LFP += 4;

            }
            return LFP;
        }

        public Duration GetDuration(DateTime OldDate, DateTime NewDate)
        {
            Duration duration = new Duration();
            DateTime zeroTime = new DateTime(1, 1, 1);
            //DateTime olddate = new DateTime(1947, 8, 15);
            //olddate.Dump();
            DateTime curdate = DateTime.Now.ToLocalTime();
            //curdate.Dump();

            TimeSpan span = NewDate - OldDate;

            // because we start at year 1 for the Gregorian 
            // calendar, we must subtract a year here.

            duration.Years = (zeroTime + span).Year - 1;
            duration.Months = (zeroTime + span).Month - 1;
            duration.Days = (zeroTime + span).Day;

            return duration;
        }
    }
}
