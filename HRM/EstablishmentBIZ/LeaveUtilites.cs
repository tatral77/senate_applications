using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace EstablishmentBIZ
{
    public class LeaveUtilites
    {
        public List<EmpLeaveDetails> GetLeaveDetails(List<EmployeeLeave> EmpLeave)
        {
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
            foreach (EmployeeLeave row in EmpLeave)
            {
                DateTime StartDate = Convert.ToDateTime(row.StartDate);
                DateTime EndDate = Convert.ToDateTime(row.EndDate);
                int LeaveType = row.LeaveTypeId;
                int LeaveSubType = row.LeaveSubTypeId;
                int StartMonth = StartDate.Month;
                int StartYear = StartDate.Year;
                int StartDay = StartDate.Day;
                int EndYear = EndDate.Year;
                int EndMonth = EndDate.Month;
                int EndDay = EndDate.Day;
             
                
                    if (StartYear == EndYear)
                    {

                        EmpLeaveDetails lc = new LeaveUtilites().GetCreditInSameYear(StartDate, EndDate, LeaveType, LeaveSubType);
                        details.Add(lc);
                    }
                    //else if (StartMonth != EndMonth && StartYear == EndYear)
                    //{
                    //    EmpLeaveDetails lc = new LeaveUtilites().GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType, LeaveSubType);
                    //    details.Add(lc);
                    //}
                    else if (StartYear != EndYear)
                    {
                        List<EmpLeaveDetails> LeaveDetail = new LeaveUtilites().GetCreditInDifferentYears(StartDate, EndDate, LeaveType, LeaveSubType);
                        foreach (EmpLeaveDetails lc in LeaveDetail)
                        {
                            details.Add(lc);
                        }
                    }
                }
           
            return details;
        }
        public List<EmpLeaveDetails> Get2017LeaveDetails(List<EmployeeLeave> EmpLeave)
        {
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
            foreach (EmployeeLeave row in EmpLeave)
            {
                DateTime StartDate = Convert.ToDateTime(row.StartDate);
                DateTime EndDate = Convert.ToDateTime(row.EndDate);
                int LeaveType = row.LeaveTypeId;
                int LeaveSubType = row.LeaveSubTypeId;
                int StartMonth = StartDate.Month;
                int StartYear = StartDate.Year;
                int StartDay = StartDate.Day;
                int EndYear = EndDate.Year;
                int EndMonth = EndDate.Month;
                int EndDay = EndDate.Day;

                if (StartYear == EndYear)
                {
                    EmpLeaveDetails lc = new LeaveUtilites().GetCreditInSameYear(StartDate, EndDate, LeaveType, LeaveSubType);
                    details.Add(lc);

                }
                //else if (StartMonth != EndMonth && StartYear == EndYear)
                //{
                //    EmpLeaveDetails lc = new LeaveUtilites().GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType, LeaveSubType);
                //    details.Add(lc);
                //}
                else if (StartYear != EndYear)
                {
                    List<EmpLeaveDetails> LeaveDetail = new LeaveUtilites().GetCreditInDifferentYears(StartDate, EndDate, LeaveType, LeaveSubType);
                    foreach (EmpLeaveDetails lc in LeaveDetail)
                    {
                        details.Add(lc);
                    }
                }
            }
            return details;
        }
        public List<EmpLeaveDetails> GetCalculatedLeave(List<EmpLeaveDetails> details)
        {
            List<EmpLeaveDetails> Calculated = new List<EmpLeaveDetails>();
            int startyear = 0;
            foreach (EmpLeaveDetails row in details)
            {
                
                if (startyear != row.ServiceYear)
                {
                    EmpLeaveDetails ed = new EmpLeaveDetails();
                    startyear = row.ServiceYear;
                    ed.ServiceYear = row.ServiceYear;
                    ed.AvailedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.AvailedLeave);
                    ed.LeavePeriod = details.Where(item => item.ServiceYear == startyear).Sum(item => item.LeavePeriod);
                    ed.LeaveDeducted = details.Where(item => item.ServiceYear == startyear).Sum(item => item.LeaveDeducted);
                    ed.Remarks = row.Remarks;
                    //ed.EarnedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EarnedLeave);
                    ed.EOL = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EOL);

                    Calculated.Add(ed);
                }
            }
            return Calculated;
        }
        public EmpLeaveDetails GetCreditInSameYear(DateTime StartDate, DateTime EndDate, int LeaveType, int LeaveSubType)
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

                    if (j == StartMonth && j == EndMonth)   // if same month
                    {
                        DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                        HalfOfMonth = (DaysInMonth / 2);
                        int Leaves = ((EndDay - StartDay) + 1);
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                        {
                            lc.AvailedLeave += Leaves;
                            lc.LeavePeriod += Leaves;
                        }
                        else if (LeaveSubType == 4)
                            lc.LeavePeriod += Leaves;
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
                        HalfOfMonth = (DaysInMonth / 2) ;
                        int Leaves = ((DaysInMonth - StartDay) + 1);
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                        {
                            lc.AvailedLeave += Leaves;
                            lc.LeavePeriod += Leaves;
                        }
                        else if (LeaveSubType == 4)
                            lc.LeavePeriod += Leaves;

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
                        HalfOfMonth = (DaysInMonth / 2);
                        int Leaves = EndDay;
                        if (LeaveSubType == 1 || LeaveSubType == 2)
                        {
                            lc.AvailedLeave += Leaves;
                            lc.LeavePeriod += Leaves;
                        }
                        else if (LeaveSubType == 4)
                            lc.LeavePeriod += Leaves;
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
                        {
                            lc.AvailedLeave += DateTime.DaysInMonth(StartYear, j);
                            lc.LeavePeriod += DateTime.DaysInMonth(StartYear, j);
                        }
                        else if(LeaveSubType==4)
                            lc.LeavePeriod += DateTime.DaysInMonth(StartYear, j);
                        else if (LeaveSubType == 3)
                            lc.EOL += DateTime.DaysInMonth(StartYear, j);
                        lc.LeaveDeducted += 4;
                    }


                }
                if (LeaveSubType == 2)  //If LHP
                    lc.AvailedLeave = lc.AvailedLeave / 2;
                if (LeaveType == 7) // IF Recration Leave
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
                        EmpLeaveDetails lc = new EmpLeaveDetails();
                        DaysInMonth = DateTime.DaysInMonth(i, j);
                        lc.ServiceYear = i;
                        HalfOfMonth = (DaysInMonth / 2);
                        if (j == StartMonth && i == StartYear)
                        {

                            if (LeaveSubType == 1 || LeaveSubType == 2)
                            {
                                lc.AvailedLeave = ((DaysInMonth - StartDay) + 1);
                                lc.LeavePeriod= ((DaysInMonth - StartDay) + 1);
                                lc.LeaveMonth = j;
                            }
                            else if(LeaveSubType==4)
                            {
                                lc.LeavePeriod = ((DaysInMonth - StartDay) + 1);
                                lc.LeaveMonth = j;
                            }

                            else if (LeaveSubType == 3)
                                lc.EOL += ((DaysInMonth - StartDay) + 1);
                            if (lc.LeavePeriod > HalfOfMonth || lc.EOL > HalfOfMonth)
                            {
                                lc.LeaveDeducted = 4;
                            }
                        }
                        else if (j == EndMonth && i == EndYear)
                        {
                            if (LeaveSubType == 1 || LeaveSubType == 2)
                            {
                                lc.AvailedLeave = EndDay;
                                lc.LeavePeriod = EndDay;
                                lc.LeaveMonth = j;
                            }
                            else if(LeaveSubType==4)
                            {
                                lc.LeavePeriod = EndDay;
                                lc.LeaveMonth = j;
                            }
                            else if (LeaveSubType == 3)
                                lc.EOL += EndDay;
                            if (lc.LeavePeriod > HalfOfMonth || lc.EOL > HalfOfMonth )
                            {
                                lc.LeaveDeducted = 4;
                            }
                        }
                        else
                        {
                            if (LeaveSubType == 1 || LeaveSubType == 2)
                            {
                                lc.AvailedLeave = DateTime.DaysInMonth(i, j);
                                lc.LeaveMonth = j;
                            }
                            else if (LeaveSubType == 4)
                            {
                                lc.LeavePeriod = DateTime.DaysInMonth(i, j);
                                lc.LeaveMonth = j;
                            }
                            else if (LeaveSubType == 3)
                                lc.EOL += DateTime.DaysInMonth(i, j);
                            lc.LeaveDeducted = 4;
                        }
                        if (LeaveSubType == 2)
                        {
                            lc.AvailedLeave = lc.AvailedLeave / 2;
                            lc.LeaveMonth = j;
                        }
                        if (LeaveType == 7)
                            lc.AvailedLeave = lc.AvailedLeave - 5;

                        lcs.Add(lc);
                    }
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
                        if (StartYear == EndYear)
                        {
                            EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, 3);
                            lc.Remarks = Remarks;
                            details.Add(lc);

                        }
                        //else if (StartMonth != EndMonth && StartYear == EndYear)
                        //{
                        //    EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, 3);
                        //    lc.Remarks = Remarks;
                        //    details.Add(lc);
                        //}
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

        public List<EmpLeaveDetails> DisplayProfileSummery(List<EmpLeaveDetails> empLeaves, DateTime ServiceStartDate, int EmpId, int LeaveOnCredit)
        {

            int SenServiceYear = ServiceStartDate.Year;
            DateTime ServiceEndDate = new EmploymentBIZ().GetServiceEndDate(EmpId);
            int CurrentYear = ServiceEndDate.Year;
            List<EmpLeaveDetails> LeaveDetailList = new List<EmpLeaveDetails>();
            for (int i = SenServiceYear; i <= CurrentYear; i++)
            {
               EmpLeaveDetails LeaveDetail = new EmpLeaveDetails();
                LeaveDetail.ServiceYear = i;
                //if (i == SenServiceYear)
                //     LeaveDetail.BalanceTillNow = LeaveOnCredit;
                ///////////////////////////////////   EARNED LEAVE IN THE YEAR ////////////////////////////////
                if (SenServiceYear != CurrentYear)
                {
                    
                        if (i == SenServiceYear)
                            LeaveDetail.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, Convert.ToDateTime("31/12/" + i));
                        else if (i == CurrentYear)
                            LeaveDetail.EarnedLeave = new DateTimeUtils().CalculateCurrentMonthsEarnedLFP(Convert.ToDateTime("1/1/" + i), ServiceEndDate);
                        else
                            LeaveDetail.EarnedLeave = 48;
                    
                }
                else
                LeaveDetail.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, ServiceEndDate);
               
                    LeaveDetailList.Add(LeaveDetail);
            }
            int yearbalane = LeaveOnCredit;
            List<EmpLeaveDetails> FinalBalance = new List<EmpLeaveDetails>();

            foreach (EmpLeaveDetails row in LeaveDetailList)
            {
                if (empLeaves != null)
                {
                    foreach (EmpLeaveDetails row2 in empLeaves)
                    {
                        if (row.ServiceYear == row2.ServiceYear)
                        {
                            row.EOL = row2.EOL;
                            row.LeaveDeducted = row2.LeaveDeducted;
                            row.AvailedLeave = row2.AvailedLeave;
                            row.LeavePeriod = row2.LeavePeriod;
                            row.CreditOfYear = (row.EarnedLeave - (row.LeavePeriod + row.LeaveDeducted));
                        }

                    }
                }
                row.CreditOfYear = (row.EarnedLeave - (row.LeavePeriod + row.LeaveDeducted));
                yearbalane += row.CreditOfYear;
                row.BalanceTillNow = yearbalane;
                FinalBalance.Add(row);

              
            }
            List<EmpLeaveDetails> SuspensionList = new LeaveUtilites().CalculateSuspensionPeriod(EmpId);
            int FinalYearBalance = 0;
            foreach (EmpLeaveDetails obj in FinalBalance)
            {

                foreach (EmpLeaveDetails susp in SuspensionList)
                {
                    if (susp.ServiceYear == obj.ServiceYear)
                    {
                        obj.LeaveDeducted = obj.LeaveDeducted + susp.LeaveDeducted;
                        obj.Remarks = susp.Remarks;
                    }
                }
                obj.LeaveBalance = obj.EarnedLeave - (obj.AvailedLeave + obj.LeaveDeducted);
                FinalYearBalance += obj.LeaveBalance;
                obj.BalanceTillNow = FinalYearBalance;
            }

            return GetLeaveEncashmentBalance(FinalBalance, EmpId);



               // return FinalBalance;


        }

        public List<EmpLeaveDetails> GetLeaveEncashmentBalance(List<EmpLeaveDetails> FinalBalance,int EmpId)
        {
            int EncashmentDeducted = 0;
            int Enc2017 = 0;
            foreach (EmpLeaveDetails fld in FinalBalance)
            {
                LeaveEnchashmentOptEnt leopt = new EmployeeHandler().GetLeaveEncashmentOpted(fld.ServiceYear, EmpId);
               
                if (leopt.StystemUsersId != 0)
                {
                    if (fld.ServiceYear == 2017)
                    {
                        List<EmpLeaveDetails> details2017 = new List<EmpLeaveDetails>();
                        List<EmpLeaveDetails> Calculated2017 = null;
                        List<EmployeeLeave> LeaveIn2017 = new EmployeeHandler().GetLeavesStatusBetweenDates(EmpId, Convert.ToDateTime("01/07/2017"), Convert.ToDateTime("31/12/2017"));
                        if (LeaveIn2017 != null)
                        {
                            DateTime startdate = Convert.ToDateTime("01/07/2017");
                            DateTime endate = Convert.ToDateTime("31/12/2017");
                            foreach (EmployeeLeave leavein2017 in LeaveIn2017)
                            {
                                if (leavein2017.StartDate <= startdate)
                                    leavein2017.StartDate = startdate;
                                if (leavein2017.EndDate >= endate)
                                    leavein2017.EndDate = endate;
                            }
                            details2017 = new LeaveUtilites().GetLeaveDetails(LeaveIn2017);
                            Calculated2017 = new LeaveUtilites().GetCalculatedLeave(details2017);
                            int leaves = 0;
                            foreach (EmpLeaveDetails clc2017 in Calculated2017)
                            {
                                leaves = leaves + (clc2017.AvailedLeave + clc2017.LeaveDeducted);
                            }
                            int availableforencashment = 20 - leaves;
                            if (fld.BalanceTillNow < 365 || fld.CreditOfYear < 0)
                                fld.AvailedEncashment = 0;
                            else if (fld.BalanceTillNow - availableforencashment < 365)
                                fld.AvailedEncashment = fld.BalanceTillNow - 365;
                            else if (fld.CreditOfYear < 20)
                                fld.AvailedEncashment = fld.CreditOfYear;
                            else
                                fld.AvailedEncashment = 20;


                        }
                        else
                        {
                            if (fld.BalanceTillNow < 365 || fld.CreditOfYear < 0)
                                fld.AvailedEncashment = 0;
                            else if (fld.BalanceTillNow - 20 < 365)
                                fld.AvailedEncashment = fld.BalanceTillNow - 365;
                            else if (fld.CreditOfYear < 20)
                                fld.AvailedEncashment = fld.CreditOfYear;
                            else
                                fld.AvailedEncashment = 20;
                        }
                        fld.BalanceTillNow = fld.BalanceTillNow - fld.AvailedEncashment;
                        EncashmentDeducted += fld.AvailedEncashment;
                    }
                    else
                    {
                        if ((fld.BalanceTillNow - fld.CreditOfYear) < 365)
                        {
                            fld.AvailedEncashment = fld.BalanceTillNow - 365;
                            fld.CreditOfYear = fld.CreditOfYear - fld.AvailedEncashment;
                            EncashmentDeducted += fld.AvailedEncashment;
                            fld.BalanceTillNow = fld.BalanceTillNow - EncashmentDeducted;
                        }

                        else
                        {
                            fld.AvailedEncashment = fld.CreditOfYear;
                            fld.CreditOfYear = 0;
                            EncashmentDeducted += fld.AvailedEncashment;
                            fld.BalanceTillNow = fld.BalanceTillNow - EncashmentDeducted;
                        }
                    }
                }
                else
                fld.BalanceTillNow = fld.BalanceTillNow - EncashmentDeducted; 
            }
            return FinalBalance;
        }
    }
}
