using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP
{
    public partial class DateCalculations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<EmployeeLeave> EmpLeave = new EmployeeHandler().GetAllLeaves(202);
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
            foreach (EmployeeLeave row in EmpLeave)
            {
                DateTime StartDate = Convert.ToDateTime(row.StartDate);
                DateTime EndDate = Convert.ToDateTime(row.EndDate);
                int LeaveType = row.LeaveSubTypeId;
                int StartMonth = StartDate.Month;
                int StartYear = StartDate.Year;
                int StartDay = StartDate.Day;
                int EndYear = EndDate.Year;
                int EndMonth = EndDate.Month;
                int EndDay = EndDate.Day;

                if (StartMonth == EndMonth)
                {
                    EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate,LeaveType);
                    details.Add(lc);
                    Label1.Text += "1Year=" + lc.ServiceYear + " Leave Availed = " + lc.AvailedLeave + " Leave Deducted = " + lc.LeaveDeducted + " EOL = " + lc.EOL + "<br>";

                }
                else if (StartMonth != EndMonth && StartYear == EndYear)
                {
                    EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate,LeaveType);
                    details.Add(lc);
                    Label1.Text += "1Year=" + lc.ServiceYear + " Leave Availed = " + lc.AvailedLeave + " Leave Deducted = " + lc.LeaveDeducted + " EOL = " + lc.EOL + "<br>";
                }
                else if (StartYear != EndYear)
                {
                    List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate,LeaveType);
                    //Label1.Text = "";
                    foreach (EmpLeaveDetails lc in ld)
                    {
                        Label1.Text += "1Year=" + lc.ServiceYear + " Leave Availed = " + lc.AvailedLeave + " Leave Deducted = " + lc.LeaveDeducted + " EOL = " + lc.EOL + "<br>";
                        details.Add(lc);
                    }
                }
            }
            int startyear = 0;
            List<EmpLeaveDetails> Calculated = new List<EmpLeaveDetails>();
            foreach (EmpLeaveDetails row in details)
            {
                if (startyear != row.ServiceYear)
                {
                    EmpLeaveDetails ed = new EmpLeaveDetails();
                    startyear = row.ServiceYear;
                    ed.ServiceYear = row.ServiceYear;
                    ed.AvailedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.AvailedLeave);
                    ed.LeaveDeducted= details.Where(item => item.ServiceYear == startyear).Sum(item => item.LeaveDeducted);
                    //ed.EarnedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EarnedLeave);
                    ed.EOL= details.Where(item => item.ServiceYear == startyear).Sum(item => item.EOL);
                    
                    Calculated.Add(ed);
                }
            }
            foreach (EmpLeaveDetails row in Calculated)
            {

                Label1.Text += "2Year=" + row.ServiceYear  + " Leave Availed = " + row.AvailedLeave + " Leave Deducted = " + row.LeaveDeducted + " EOL = " + row.EOL + "<br>";
            }
            DisplaySummery(Calculated);
            Label2.Text = "<br><br><br>";
            CalculateSuspensionPeriod(202);

            }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="cd"></param>

            public void DisplaySummery(List<EmpLeaveDetails> cd)
            {
            DateTime ServiceStart = Convert.ToDateTime("12/6/1982");
            int SenServiceYear = ServiceStart.Year;
            int CurrentYear = DateTime.Now.Year;
            List<EmpLeaveDetails> Lds = new List<EmpLeaveDetails>();

            for (int i = SenServiceYear; i <= CurrentYear; i++)
            {
                EmpLeaveDetails Ld = new EmpLeaveDetails();
                Ld.ServiceYear = i;
                ///////////////////////////////////   EARNED LEAVE IN THE YEAR ////////////////////////////////
                if (SenServiceYear != CurrentYear)
                {

                    if (i == SenServiceYear)
                        Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStart, Convert.ToDateTime("31/12/" + i));
                    else if (i == CurrentYear)
                        Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(Convert.ToDateTime("1/1/" + i), DateTime.Now);
                    else
                        Ld.EarnedLeave = 48;

                }
                else
                    Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStart, DateTime.Now);
                Lds.Add(Ld);
            }
            
            Label1.Text += "<br><br>////////////////////////////////////////////////////<br>";
            foreach(EmpLeaveDetails row in Lds)
            {
                Label1.Text += "3Year=" + row.ServiceYear + " Leave Availed = " + row.AvailedLeave + " Leave Deducted = " + row.LeaveDeducted + " Earned Leave=" + row.EarnedLeave + " EOL = " + row.EOL + "<br>";
            }
            //int YearLeaveCredit = 0;

            Label1.Text += "<br><br>////////////////////////////////////////////////////<br>";
            int yearbalane = 0;
            List<EmpLeaveDetails> FinalBalance = new List<EmpLeaveDetails>();
            foreach (EmpLeaveDetails row in Lds)
            {
                
                foreach(EmpLeaveDetails row2 in cd)
                {
                    if(row.ServiceYear==row2.ServiceYear)
                    {
                        if(row.EarnedLeave==0)
                        row.EarnedLeave = row2.EarnedLeave;
                        row.EOL = row2.EOL;
                        row.LeaveDeducted = row2.LeaveDeducted;
                        row.AvailedLeave = row2.AvailedLeave;
                        row.CreditOfYear = (row.EarnedLeave - (row.AvailedLeave + row.LeaveDeducted));
                        row.BalanceTillNow += row.CreditOfYear;


                    }
                    row.CreditOfYear = (row.EarnedLeave - (row.AvailedLeave + row.LeaveDeducted));
                    
                }
                yearbalane += row.CreditOfYear;
                row.BalanceTillNow = yearbalane;
                FinalBalance.Add(row);
                Label1.Text += "4Year=" + row.ServiceYear + " Leave Availed = " + row.AvailedLeave + " Leave Deducted = " + row.LeaveDeducted + " Earned Leave=" + row.EarnedLeave + " EOL = " + row.EOL  +" This Year Balance = " + row.CreditOfYear + " Balance till now= " + row.BalanceTillNow + "<br>";
            }
            List<EmpLeaveDetails> SuspensionList = CalculateSuspensionPeriod(202);
            foreach(EmpLeaveDetails obj in FinalBalance)
            {
                foreach(EmpLeaveDetails susp in SuspensionList)
                {
                    if (susp.ServiceYear == obj.ServiceYear)
                        obj.LeaveDeducted += susp.LeaveDeducted;
                }
                Label1.Text += "5Year=" + obj.ServiceYear + " Leave Availed = " + obj.AvailedLeave + " Leave Deducted = " + obj.LeaveDeducted + " Earned Leave=" + obj.EarnedLeave + " EOL = " + obj.EOL + " This Year Balance = " + obj.CreditOfYear + " Balance till now= " + obj.BalanceTillNow + "<br>";
            }
        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
            
        //public EmpLeaveDetails GetCreditInSameMonth(DateTime StartDate,DateTime EndDate)
        //{
        //    EmpLeaveDetails lc = new EmpLeaveDetails();
        //    int Month = StartDate.Month;
        //    int Year = StartDate.Year;
        //    int StartDay = StartDate.Day;
        //    int EndDay = EndDate.Day;
        //    int DaysInMonth = DateTime.DaysInMonth(Year, Month);
        //    int HalfOfMonth = (DaysInMonth / 2) ;
        //    lc.ServiceYear = Year;
        //    lc.AvailedLeave = EndDay - StartDay+1;
        //    if (lc.AvailedLeave > HalfOfMonth)
        //        lc.LeaveDeducted = 4;
        //    return lc;

        //}

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public EmpLeaveDetails GetCreditInSameYearDifferentMonths(DateTime StartDate, DateTime EndDate,int LeaveType)
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
                        if (LeaveType != 3)
                            lc.AvailedLeave += Leaves;
                        else
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
                        if (LeaveType != 3)
                            lc.AvailedLeave += Leaves;
                        else
                            lc.EOL += Leaves;
                        if (Leaves > HalfOfMonth )
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else if (j == EndMonth)
                    {
                        DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                        HalfOfMonth = (DaysInMonth / 2) + 1;
                        int Leaves = EndDay;
                        if (LeaveType != 3)
                            lc.AvailedLeave += Leaves;
                        else
                            lc.EOL += Leaves;
                        if (Leaves > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else
                    {
                        if(LeaveType!=3)
                            lc.AvailedLeave += DateTime.DaysInMonth(StartYear, j);
                        else
                            lc.EOL += DateTime.DaysInMonth(StartYear, j);
                        lc.LeaveDeducted += 4;
                    }


                }
                if (LeaveType == 2)
                    lc.AvailedLeave = lc.AvailedLeave / 2;
                return lc;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public List<EmpLeaveDetails> GetCreditInDifferentYears(DateTime StartDate, DateTime EndDate, int LeaveType)
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
                        if (LeaveType != 3)
                            lc.AvailedLeave += ((DaysInMonth - StartDay) + 1);
                        else
                            lc.EOL += ((DaysInMonth - StartDay) + 1);
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL>HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else if (j == EndMonth && i == EndYear)
                    {
                        if (LeaveType != 3)
                            lc.AvailedLeave += EndDay;
                        else
                            lc.EOL += EndDay;
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else
                    {
                        if (LeaveType != 3)
                            lc.AvailedLeave += DateTime.DaysInMonth(i, j);
                        else
                            lc.EOL += DateTime.DaysInMonth(i, j);

                        lc.LeaveDeducted += 4;
                    }

                }
                if (LeaveType == 2)
                    lc.AvailedLeave = lc.AvailedLeave / 2;
                lcs.Add(lc);
            }
            lcs.TrimExcess();
            return lcs;

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<EmpLeaveDetails> CalculateSuspensionPeriod(int EmpId)
        {
            List<DisciplinaryAction> da = new EmploymentBIZ().GetEmpSuspensions(EmpId);
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
            foreach (DisciplinaryAction row in da)
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

                if (StartMonth == EndMonth)
                {
                    EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                    details.Add(lc);
                    Label2.Text += "Year="+ lc.ServiceYear+ " Leave Deducted = " + lc.LeaveDeducted;

                }
                else if (StartMonth != EndMonth && StartYear == EndYear)
                {
                    EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                    details.Add(lc);
                    Label2.Text += "Year=" + lc.ServiceYear + " Leave Deducted = " + lc.LeaveDeducted;
                }
                else if (StartYear != EndYear)
                {
                    List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType);
                    //Label1.Text = "";
                    foreach (EmpLeaveDetails lc in ld)
                    {
                        Label2.Text += "Year=" + lc.ServiceYear + " Leave Deducted = " + lc.LeaveDeducted;
                        details.Add(lc);
                    }
                }
            }

            return details;

        }
    }
}