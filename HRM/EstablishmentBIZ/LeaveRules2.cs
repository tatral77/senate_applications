using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EstablishmentENT;

namespace EstablishmentBIZ
{
    public static class LeaveTypeIds2
    {
        public const int LFP = 2;
        public const int LHP = 3;
        public const int EOL = 4;
        public const int Study = 5;
        public const int Maternity = 6;
        public const int Recreation = 7;
        public const int Special = 8;
        public const int Disability = 9;
        public const int LPR = 10;
        public const int NotDue = 11;
        public const int Casual = 12;
        public const int WithoutPay = 13;
        public const int Paternity = 14;
    }

    public static class LeaveSubTypeIds2
    {
        public const int Lfp = 1;
        public const int Lhp = 2;
        public const int Eol = 3;
        public const int Outside = 4;
    }

    public class LeaveSuspension2
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class LeaveContext2
    {
        public LeaveContext2()
        {
            Leaves = new List<EmployeeLeave>();
            Suspensions = new List<LeaveSuspension2>();
        }
        public int EmpId { get; set; }
        public DateTime? ServiceStart { get; set; }
        public DateTime? SenateServiceStart { get; set; }
        public DateTime ServiceEnd { get; set; }
        public DateTime? Superannuation { get; set; }
        public bool? IsFemale { get; set; }
        public int OpeningCredit { get; set; }
        public List<EmployeeLeave> Leaves { get; set; }
        public List<LeaveSuspension2> Suspensions { get; set; }
    }

    public class LeaveValidation2
    {
        public LeaveValidation2()
        {
            Errors = new List<string>();
            Warnings = new List<string>();
        }
        public List<string> Errors { get; private set; }
        public List<string> Warnings { get; private set; }
        public bool IsValid { get { return Errors.Count == 0; } }
    }

    public class LeaveYear2
    {
        public int Year { get; set; }
        public int GrossEarned { get; set; }
        public int NotEarned { get; set; }
        public int NetEarned { get { return GrossEarned - NotEarned; } }
        public int Availed { get; set; }
        public int LeavePeriod { get; set; }
        public int EolDays { get; set; }
        public int CasualDays { get; set; }
        public int YearCredit { get; set; }
        public int Encashed { get; set; }
        public int Balance { get; set; }
        public string Remarks { get; set; }
    }

    public class LeaveTypeSummary2
    {
        public int LeaveTypeId { get; set; }
        public string Description { get; set; }
        public int Spells { get; set; }
        public int Days { get; set; }
        public int Debited { get; set; }
    }

    public class LeaveAccount2
    {
        internal Dictionary<int, int> NetByMonth = new Dictionary<int, int>();
        internal Dictionary<DateTime, int> DebitByDay = new Dictionary<DateTime, int>();

        public LeaveAccount2()
        {
            Years = new List<LeaveYear2>();
        }
        public List<LeaveYear2> Years { get; private set; }
        public int OpeningCredit { get; set; }
        public int ClosingBalance { get; set; }

        public int BalanceBefore(DateTime date)
        {
            int balance = OpeningCredit;
            foreach (KeyValuePair<int, int> kv in NetByMonth)
            {
                int y = kv.Key / 100;
                int m = kv.Key % 100;
                DateTime monthEnd = new DateTime(y, m, DateTime.DaysInMonth(y, m));
                if (monthEnd < date.Date)
                    balance += kv.Value;
            }
            foreach (KeyValuePair<DateTime, int> kv in DebitByDay)
            {
                if (kv.Key < date.Date)
                    balance -= kv.Value;
            }
            return balance;
        }
    }

    public static class LeaveRules2
    {
        public const int CasualLeavePerYear = 20;
        public const int CasualLeaveAtATime = 15;
        public const int LfpWithoutMedical = 120;
        public const int LfpWithMedical = 180;
        public const int MaternityMaxDays = 90;
        public const int MaternityMaxTimes = 3;
        public const int DisabilityMaxDays = 720;
        public const int LprMaxDays = 365;
        public const int LeaveNotDueMax = 365;
        public const int LeaveNotDueFirstFiveYears = 90;
        public const int StudyLeaveMaxDays = 1461;
        public const int WidowSpecialLeaveDays = 130;
        public const int ExPakistanPayDays = 120;
        public const string MedicalTag = "[MC]";

        #region Lookups

        public static string TypeName(int typeId)
        {
            switch (typeId)
            {
                case LeaveTypeIds2.LFP: return "LFP";
                case LeaveTypeIds2.LHP: return "LHP";
                case LeaveTypeIds2.EOL: return "EOL";
                case LeaveTypeIds2.Study: return "Study Leave";
                case LeaveTypeIds2.Maternity: return "Maternity Leave";
                case LeaveTypeIds2.Recreation: return "R&R Leave";
                case LeaveTypeIds2.Special: return "Special Leave";
                case LeaveTypeIds2.Disability: return "Disability Leave";
                case LeaveTypeIds2.LPR: return "LPR";
                case LeaveTypeIds2.NotDue: return "Leave not due";
                case LeaveTypeIds2.Casual: return "Casual Leave";
                case LeaveTypeIds2.WithoutPay: return "Without Pay and Allowances";
                case LeaveTypeIds2.Paternity: return "Paternity Leave";
                default: return "Leave";
            }
        }

        public static string SubTypeName(int subTypeId)
        {
            switch (subTypeId)
            {
                case LeaveSubTypeIds2.Lfp: return "LFP";
                case LeaveSubTypeIds2.Lhp: return "LHP";
                case LeaveSubTypeIds2.Eol: return "EOL";
                case LeaveSubTypeIds2.Outside: return "Outside the Leave Account";
                default: return "";
            }
        }

        public static int[] AllowedSubTypes(int typeId)
        {
            switch (typeId)
            {
                case LeaveTypeIds2.LFP: return new[] { LeaveSubTypeIds2.Lfp };
                case LeaveTypeIds2.LHP: return new[] { LeaveSubTypeIds2.Lhp };
                case LeaveTypeIds2.EOL:
                case LeaveTypeIds2.WithoutPay: return new[] { LeaveSubTypeIds2.Eol };
                case LeaveTypeIds2.Recreation: return new[] { LeaveSubTypeIds2.Lfp };
                case LeaveTypeIds2.LPR:
                case LeaveTypeIds2.NotDue: return new[] { LeaveSubTypeIds2.Lfp, LeaveSubTypeIds2.Lhp };
                case LeaveTypeIds2.Study:
                case LeaveTypeIds2.Maternity:
                case LeaveTypeIds2.Special:
                case LeaveTypeIds2.Disability:
                case LeaveTypeIds2.Casual:
                case LeaveTypeIds2.Paternity: return new[] { LeaveSubTypeIds2.Outside };
                default: return new[] { LeaveSubTypeIds2.Lfp, LeaveSubTypeIds2.Lhp, LeaveSubTypeIds2.Eol, LeaveSubTypeIds2.Outside };
            }
        }

        public static string RuleHint(int typeId)
        {
            switch (typeId)
            {
                case LeaveTypeIds2.LFP:
                    return "Rule 5: debited day for day from the leave account. Maximum 120 days at a time, or 180 days at a time on medical certificate.";
                case LeaveTypeIds2.LHP:
                    return "Rule 6: LFP converted to half pay, debited at one day of LFP for every two days of LHP (a fraction of one-half counts as one full day). Subject to the same 120/180 day limit (in LFP days).";
                case LeaveTypeIds2.EOL:
                case LeaveTypeIds2.WithoutPay:
                    return "Rule 9: leave without pay. Up to 5 years at a time after 10 years of continuous service, otherwise up to 2 years. No pay, no increment, no leave earned and not counted for pension.";
                case LeaveTypeIds2.Study:
                    return "FR 84 / Sl.No.11: outside the leave account, half pay. Not ordinarily for less than 5 years of service or within 3 years of retirement option. Maximum 48 months in entire service.";
                case LeaveTypeIds2.Maternity:
                    return "Rule 13: female civil servant only. Full pay outside the leave account, up to 90 days, maximum 3 times in entire service. Later confinements are taken as LFP/LHP.";
                case LeaveTypeIds2.Recreation:
                    return "Rule 10: 15 days of leave once in a calendar year, debited as 10 days of LFP. Enter 10 as the number of days; the end date is calculated for 15 days.";
                case LeaveTypeIds2.Special:
                    return "Rule 12: female civil servant on death of husband, full pay, up to 130 days from date of death, not debited (Sl.No.9: Khuddam-ul-Hajjaj special leave is also outside the leave account).";
                case LeaveTypeIds2.Disability:
                    return "Rule 14: outside the leave account, up to 720 days on each occasion (full pay for 180 days, half pay thereafter).";
                case LeaveTypeIds2.LPR:
                    return "Rules 16-18: maximum 365 days in total, on full pay and/or half pay. Cannot be combined with any other kind of leave (Rule 25).";
                case LeaveTypeIds2.NotDue:
                    return "Rule 11: full pay, offset against leave to be earned. Maximum 365 days in entire service and 90 days in the first five years of service.";
                case LeaveTypeIds2.Casual:
                    return "Sl.No.12: outside the leave account, 20 days per calendar year, 15 days at a time. A holiday between two days of casual leave is counted as casual leave.";
                case LeaveTypeIds2.Paternity:
                    return "Outside the leave account (not covered by the Revised Leave Rules, 1980).";
                default:
                    return "";
            }
        }

        public static bool HasMedicalCertificate(string remarks)
        {
            return !string.IsNullOrEmpty(remarks) && remarks.TrimStart().StartsWith(MedicalTag, StringComparison.OrdinalIgnoreCase);
        }

        public static string StripMedicalTag(string remarks)
        {
            if (!HasMedicalCertificate(remarks))
                return remarks;
            return remarks.TrimStart().Substring(MedicalTag.Length).TrimStart();
        }

        public static string ComposeRemarks(string remarks, bool medical)
        {
            string text = (remarks ?? "").Trim();
            return medical ? (MedicalTag + " " + text).Trim() : text;
        }

        #endregion

        #region Day counting

        public static DateTime EndDateFor(DateTime start, int numberOfDays, int typeId)
        {
            int extra = typeId == LeaveTypeIds2.Recreation ? 5 : 0;
            return start.Date.AddDays(numberOfDays - 1 + extra);
        }

        public static int CalendarDays(DateTime start, DateTime end)
        {
            return (end.Date - start.Date).Days + 1;
        }

        public static int CalendarDays(EmployeeLeave l)
        {
            return CalendarDays(l.StartDate, l.EndDate);
        }

        public static int DebitDays(int typeId, int subTypeId, int calendarDays)
        {
            if (calendarDays <= 0)
                return 0;
            if (typeId == LeaveTypeIds2.Recreation)
                return Math.Max(0, calendarDays - 5);
            switch (subTypeId)
            {
                case LeaveSubTypeIds2.Lfp: return calendarDays;
                case LeaveSubTypeIds2.Lhp: return (calendarDays + 1) / 2;
                default: return 0;
            }
        }

        public static int DebitDays(EmployeeLeave l)
        {
            return DebitDays(l.LeaveTypeId, l.LeaveSubTypeId, CalendarDays(l));
        }

        private static int OverlapDays(DateTime a1, DateTime a2, DateTime b1, DateTime b2)
        {
            DateTime s = a1 > b1 ? a1 : b1;
            DateTime e = a2 < b2 ? a2 : b2;
            return e < s ? 0 : (e - s).Days + 1;
        }

        private static int WholeYears(DateTime from, DateTime to)
        {
            int years = to.Year - from.Year;
            if (to < from.AddYears(years))
                years--;
            return years;
        }

        private static bool Bridges(DateTime earlier, DateTime later)
        {
            int gap = (later.Date - earlier.Date).Days - 1;
            if (gap < 0)
                return false;
            if (gap == 0)
                return true;
            if (gap > 2)
                return false;
            for (int i = 1; i <= gap; i++)
            {
                DayOfWeek d = earlier.Date.AddDays(i).DayOfWeek;
                if (d != DayOfWeek.Saturday && d != DayOfWeek.Sunday)
                    return false;
            }
            return true;
        }

        private static bool Touches(EmployeeLeave o, DateTime s, DateTime e)
        {
            DateTime os = o.StartDate.Date;
            DateTime oe = o.EndDate.Date;
            return (oe < s && Bridges(oe, s)) || (e < os && Bridges(e, os));
        }

        private static List<DateTime[]> BuildSpells(IEnumerable<DateTime> sortedDays)
        {
            List<DateTime[]> spells = new List<DateTime[]>();
            bool open = false;
            DateTime spellStart = DateTime.MinValue;
            DateTime prev = DateTime.MinValue;
            foreach (DateTime d in sortedDays)
            {
                if (!open)
                {
                    spellStart = d;
                    open = true;
                }
                else if (!Bridges(prev, d))
                {
                    spells.Add(new[] { spellStart, prev });
                    spellStart = d;
                }
                prev = d;
            }
            if (open)
                spells.Add(new[] { spellStart, prev });
            return spells;
        }

        private static void AllocateDebit(EmployeeLeave l, Dictionary<DateTime, int> debitByDay)
        {
            int days = CalendarDays(l);
            int debit = DebitDays(l);
            if (debit <= 0 || days <= 0)
                return;
            int previous = 0;
            for (int i = 1; i <= days; i++)
            {
                int cumulative = (int)Math.Round((double)debit * i / days, MidpointRounding.AwayFromZero);
                int share = cumulative - previous;
                previous = cumulative;
                if (share <= 0)
                    continue;
                DateTime d = l.StartDate.Date.AddDays(i - 1);
                int existing;
                debitByDay.TryGetValue(d, out existing);
                debitByDay[d] = existing + share;
            }
        }

        #endregion

        #region Account calculation

        private class MonthRow
        {
            public int Year;
            public int Month;
            public int Gross;
            public int Net;
        }

        // Earning follows Rules 2-3: 4 days per calendar month, a month counts only if more than 15 days are spent on duty,
        // and a spell of leave running from one month into another credits at most one month (Rule 3(2)).
        public static LeaveAccount2 Compute(DateTime serviceStart, DateTime serviceEnd, int openingCredit,
            IList<EmployeeLeave> leaves, IList<LeaveSuspension2> suspensions)
        {
            LeaveAccount2 acc = new LeaveAccount2();
            acc.OpeningCredit = openingCredit;
            acc.ClosingBalance = openingCredit;
            if (leaves == null)
                leaves = new List<EmployeeLeave>();
            if (suspensions == null)
                suspensions = new List<LeaveSuspension2>();

            DateTime ws = serviceStart.Date;
            DateTime we = serviceEnd.Date;
            if (we < ws)
                return acc;

            DateTime tableStart = new DateTime(ws.Year, 1, 1);
            DateTime tableEnd = new DateTime(we.Year, 12, 31);

            Dictionary<int, LeaveYear2> years = new Dictionary<int, LeaveYear2>();
            for (int y = ws.Year; y <= we.Year; y++)
            {
                LeaveYear2 row = new LeaveYear2();
                row.Year = y;
                years[y] = row;
                acc.Years.Add(row);
            }

            SortedSet<DateTime> nonDuty = new SortedSet<DateTime>();
            HashSet<DateTime> leaveDays = new HashSet<DateTime>();

            foreach (EmployeeLeave l in leaves)
            {
                DateTime ls = l.StartDate.Date;
                DateTime le = l.EndDate.Date;
                if (le < ls)
                    continue;
                AllocateDebit(l, acc.DebitByDay);
                DateTime from = ls < tableStart ? tableStart : ls;
                DateTime to = le > tableEnd ? tableEnd : le;
                for (DateTime d = from; d <= to; d = d.AddDays(1))
                {
                    leaveDays.Add(d);
                    LeaveYear2 yr = years[d.Year];
                    if (l.LeaveSubTypeId == LeaveSubTypeIds2.Eol)
                        yr.EolDays++;
                    else
                        yr.LeavePeriod++;
                    if (l.LeaveTypeId == LeaveTypeIds2.Casual)
                        yr.CasualDays++;
                    else if (d >= ws && d <= we)
                        nonDuty.Add(d);
                }
            }

            HashSet<DateTime> suspensionDays = new HashSet<DateTime>();
            foreach (LeaveSuspension2 s in suspensions)
            {
                DateTime ss = s.From.Date;
                DateTime se = s.To.Date;
                if (se < ss)
                    continue;
                DateTime from = ss < tableStart ? tableStart : ss;
                DateTime to = se > tableEnd ? tableEnd : se;
                for (DateTime d = from; d <= to; d = d.AddDays(1))
                {
                    if (!suspensionDays.Add(d))
                        continue;
                    if (!leaveDays.Contains(d))
                        years[d.Year].EolDays++;
                    if (d >= ws && d <= we)
                        nonDuty.Add(d);
                }
                for (int y = from.Year; y <= to.Year; y++)
                {
                    LeaveYear2 yr = years[y];
                    string note = "Suspended from " + ss.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " to " + se.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    yr.Remarks = string.IsNullOrEmpty(yr.Remarks) ? note : yr.Remarks + "; " + note;
                }
            }

            Dictionary<int, MonthRow> months = new Dictionary<int, MonthRow>();
            List<MonthRow> monthList = new List<MonthRow>();
            for (int y = ws.Year; y <= we.Year; y++)
            {
                int firstMonth = y == ws.Year ? ws.Month : 1;
                int lastMonth = y == we.Year ? we.Month : 12;
                for (int m = firstMonth; m <= lastMonth; m++)
                {
                    DateTime monthStart = new DateTime(y, m, 1);
                    DateTime monthEnd = new DateTime(y, m, DateTime.DaysInMonth(y, m));
                    DateTime a = monthStart < ws ? ws : monthStart;
                    DateTime b = monthEnd > we ? we : monthEnd;
                    int potential = (b - a).Days + 1;
                    int onLeave = nonDuty.GetViewBetween(a, b).Count;
                    MonthRow row = new MonthRow();
                    row.Year = y;
                    row.Month = m;
                    row.Gross = potential > 15 ? 4 : 0;
                    row.Net = (potential - onLeave) > 15 ? 4 : 0;
                    months[y * 100 + m] = row;
                    monthList.Add(row);
                }
            }

            foreach (DateTime[] spell in BuildSpells(nonDuty))
            {
                int startKey = spell[0].Year * 100 + spell[0].Month;
                int endKey = spell[1].Year * 100 + spell[1].Month;
                if (startKey == endKey)
                    continue;
                MonthRow first;
                MonthRow last;
                if (months.TryGetValue(startKey, out first) && months.TryGetValue(endKey, out last))
                {
                    if (first.Net == 4 && last.Net == 4)
                        last.Net = 0;
                }
            }

            foreach (MonthRow row in monthList)
            {
                LeaveYear2 yr = years[row.Year];
                yr.GrossEarned += row.Gross;
                yr.NotEarned += row.Gross - row.Net;
                acc.NetByMonth[row.Year * 100 + row.Month] = row.Net;
            }

            foreach (KeyValuePair<DateTime, int> kv in acc.DebitByDay)
            {
                LeaveYear2 yr;
                if (years.TryGetValue(kv.Key.Year, out yr))
                    yr.Availed += kv.Value;
            }

            int running = openingCredit;
            foreach (LeaveYear2 yr in acc.Years)
            {
                yr.YearCredit = yr.NetEarned - yr.Availed;
                running += yr.YearCredit;
                yr.Balance = running;
            }
            acc.ClosingBalance = running;
            return acc;
        }

        public static LeaveContext2 LoadContext(int empId)
        {
            LeaveContext2 ctx = new LeaveContext2();
            ctx.EmpId = empId;
            DateTime floor = new DateTime(1900, 1, 1);

            EmpProfile ep = new EmployeeHandler().GetOnePage(empId);
            if (ep != null)
            {
                if (ep.GovtServiceStartDate > floor)
                    ctx.ServiceStart = ep.GovtServiceStartDate.Date;
                if (ep.SenateServiceStartDate > floor)
                    ctx.SenateServiceStart = ep.SenateServiceStartDate.Date;
                if (ep.Dob > floor && ep.SuperanuationDate > floor)
                    ctx.Superannuation = ep.SuperanuationDate.Date;
                ctx.OpeningCredit = ep.LeaveOnCredit;
                ctx.IsFemale = IsFemaleGender(ep.Gender);
            }
            ctx.ServiceEnd = new EmploymentBIZ().GetServiceEndDate(empId);

            List<EmployeeLeave> leaves = new EmployeeHandler().GetAllLeaves(empId);
            if (leaves != null)
                ctx.Leaves = leaves;

            List<DisciplinaryAction> suspensions = new EmploymentBIZ().GetEmpSuspensions(empId);
            if (suspensions != null)
            {
                foreach (DisciplinaryAction da in suspensions)
                {
                    if (da.IsLfpCalculated == 0 && da.FromDate > floor && da.ToDate >= da.FromDate)
                    {
                        LeaveSuspension2 s = new LeaveSuspension2();
                        s.From = da.FromDate;
                        s.To = da.ToDate;
                        ctx.Suspensions.Add(s);
                    }
                }
            }
            return ctx;
        }

        private static bool? IsFemaleGender(int genderId)
        {
            try
            {
                List<Gender> genders = new AdministrationBIZ().GetGenders();
                if (genders == null)
                    return null;
                Gender g = genders.FirstOrDefault(x => x.GenderId == genderId);
                if (g == null || string.IsNullOrEmpty(g.Description))
                    return null;
                string d = g.Description.ToLowerInvariant();
                if (d.Contains("female") || d.Contains("woman") || d.Contains("women"))
                    return true;
                return false;
            }
            catch
            {
                return null;
            }
        }

        public static LeaveAccount2 BuildAccount(LeaveContext2 ctx, bool fromSenateService)
        {
            DateTime? start = fromSenateService ? ctx.SenateServiceStart : ctx.ServiceStart;
            if (!start.HasValue)
                return new LeaveAccount2();

            LeaveAccount2 acc = Compute(start.Value, ctx.ServiceEnd, ctx.OpeningCredit, ctx.Leaves, ctx.Suspensions);
            if (acc.Years.Count == 0)
                return acc;

            // Yearly encashment options are not part of the Revised Leave Rules; they are applied with the existing encashment routine.
            List<EmpLeaveDetails> forEncashment = new List<EmpLeaveDetails>();
            int cumulative = ctx.OpeningCredit;
            foreach (LeaveYear2 y in acc.Years)
            {
                cumulative += y.YearCredit;
                EmpLeaveDetails d = new EmpLeaveDetails();
                d.ServiceYear = y.Year;
                d.CreditOfYear = y.YearCredit;
                d.BalanceTillNow = cumulative;
                forEncashment.Add(d);
            }
            List<EmpLeaveDetails> adjusted = new LeaveUtilites().GetLeaveEncashmentBalance(forEncashment, ctx.EmpId);
            for (int i = 0; i < acc.Years.Count && i < adjusted.Count; i++)
            {
                acc.Years[i].Encashed = adjusted[i].AvailedEncashment;
                acc.Years[i].YearCredit = adjusted[i].CreditOfYear;
                acc.Years[i].Balance = adjusted[i].BalanceTillNow;
                if (acc.Years[i].Balance < 0)
                {
                    string note = "Negative balance: leave taken without credit is Leave not due (Rule 11)";
                    acc.Years[i].Remarks = string.IsNullOrEmpty(acc.Years[i].Remarks) ? note : acc.Years[i].Remarks + "; " + note;
                }
            }
            acc.ClosingBalance = acc.Years[acc.Years.Count - 1].Balance;
            return acc;
        }

        public static List<LeaveTypeSummary2> SummariseByType(IList<EmployeeLeave> leaves)
        {
            List<LeaveTypeSummary2> list = new List<LeaveTypeSummary2>();
            if (leaves == null)
                return list;
            foreach (IGrouping<int, EmployeeLeave> g in leaves.GroupBy(x => x.LeaveTypeId).OrderBy(x => x.Key))
            {
                LeaveTypeSummary2 s = new LeaveTypeSummary2();
                s.LeaveTypeId = g.Key;
                s.Description = TypeName(g.Key);
                s.Spells = g.Count();
                s.Days = g.Sum(x => CalendarDays(x));
                s.Debited = g.Sum(x => DebitDays(x));
                list.Add(s);
            }
            return list;
        }

        public static List<KeyValuePair<string, string>> Position(LeaveContext2 ctx, DateTime today)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            IList<EmployeeLeave> leaves = ctx.Leaves;
            DateTime yStart = new DateTime(today.Year, 1, 1);
            DateTime yEnd = new DateTime(today.Year, 12, 31);
            int casual = leaves.Where(x => x.LeaveTypeId == LeaveTypeIds2.Casual).Sum(x => OverlapDays(x.StartDate.Date, x.EndDate.Date, yStart, yEnd));
            items.Add(new KeyValuePair<string, string>("Casual leave in " + today.Year, casual + " of " + CasualLeavePerYear + " days"));
            int maternity = leaves.Count(x => x.LeaveTypeId == LeaveTypeIds2.Maternity);
            items.Add(new KeyValuePair<string, string>("Maternity leave availed", maternity + " of " + MaternityMaxTimes + " times"));
            int notDue = leaves.Where(x => x.LeaveTypeId == LeaveTypeIds2.NotDue).Sum(x => DebitDays(x));
            items.Add(new KeyValuePair<string, string>("Leave not due availed", notDue + " of " + LeaveNotDueMax + " days"));
            int study = leaves.Where(x => x.LeaveTypeId == LeaveTypeIds2.Study).Sum(x => CalendarDays(x));
            items.Add(new KeyValuePair<string, string>("Study leave availed", study + " of " + StudyLeaveMaxDays + " days (48 months)"));
            int lpr = leaves.Where(x => x.LeaveTypeId == LeaveTypeIds2.LPR).Sum(x => CalendarDays(x));
            items.Add(new KeyValuePair<string, string>("LPR availed", lpr + " of " + LprMaxDays + " days"));
            int eol = leaves.Where(x => x.LeaveSubTypeId == LeaveSubTypeIds2.Eol).Sum(x => CalendarDays(x));
            items.Add(new KeyValuePair<string, string>("EOL availed (entire service)", eol + " days"));
            return items;
        }

        #endregion

        #region Validation

        public static LeaveValidation2 Validate(EmployeeLeave p, LeaveContext2 ctx)
        {
            LeaveValidation2 v = new LeaveValidation2();
            List<EmployeeLeave> others = (ctx.Leaves ?? new List<EmployeeLeave>()).Where(x => x.EmpLeaveId != p.EmpLeaveId).ToList();
            CultureInfo inv = CultureInfo.InvariantCulture;
            int type = p.LeaveTypeId;
            int sub = p.LeaveSubTypeId;

            if (type == 0)
            {
                v.Errors.Add("Select the leave type.");
                return v;
            }
            if (sub == 0)
            {
                v.Errors.Add("Select the leave sub type.");
                return v;
            }
            if (p.NumberOfDays < 1)
            {
                v.Errors.Add("Number of days must be at least 1 (Rule 7: leave is applied for, expressed and sanctioned in days).");
                return v;
            }
            if (p.StartDate.Year < 1950 || p.StartDate.Year > 2100)
            {
                v.Errors.Add("Start date is not valid.");
                return v;
            }

            DateTime s = p.StartDate.Date;
            DateTime e = EndDateFor(s, p.NumberOfDays, type);
            p.EndDate = e;
            int days = CalendarDays(s, e);
            int debit = DebitDays(type, sub, days);
            string name = TypeName(type);

            if (ctx.ServiceStart.HasValue)
            {
                if (s < ctx.ServiceStart.Value)
                    v.Errors.Add("Leave cannot start before the government service start date (" + ctx.ServiceStart.Value.ToString("dd/MM/yyyy", inv) + ").");
            }
            else
            {
                v.Warnings.Add("Government service start date is not recorded for this employee; service-based checks were skipped.");
            }

            int[] allowed = AllowedSubTypes(type);
            if (!allowed.Contains(sub))
                v.Errors.Add(name + " must be recorded as: " + string.Join(" / ", allowed.Select(a => SubTypeName(a))) + ".");

            foreach (EmployeeLeave o in others.OrderBy(x => x.StartDate))
            {
                if (s <= o.EndDate.Date && e >= o.StartDate.Date)
                {
                    v.Errors.Add("Employee is already on " + TypeName(o.LeaveTypeId) + " from " + o.StartDate.ToString("dd/MM/yyyy", inv) + " to " + o.EndDate.ToString("dd/MM/yyyy", inv) + ".");
                    break;
                }
            }

            foreach (EmployeeLeave o in others)
            {
                if ((o.LeaveTypeId == LeaveTypeIds2.LPR) != (type == LeaveTypeIds2.LPR) && Touches(o, s, e))
                {
                    v.Errors.Add("LPR cannot be combined with any other kind of leave (Rule 25); " + TypeName(o.LeaveTypeId) + " from " + o.StartDate.ToString("dd/MM/yyyy", inv) + " to " + o.EndDate.ToString("dd/MM/yyyy", inv) + " is adjacent.");
                    break;
                }
            }

            if (type == LeaveTypeIds2.LFP || type == LeaveTypeIds2.LHP || type == LeaveTypeIds2.NotDue)
            {
                bool medical = HasMedicalCertificate(p.Remarks);
                if (debit > LfpWithMedical)
                    v.Errors.Add("Leave on full pay cannot exceed " + LfpWithMedical + " days at a time even on medical certificate (Rule 5). This leave is " + debit + " days of LFP.");
                else if (debit > LfpWithoutMedical && !medical)
                    v.Errors.Add("Leave on full pay above " + LfpWithoutMedical + " days at a time needs a medical certificate (Rule 5). This leave is " + debit + " days of LFP; tick Medical Certificate if one is attached.");
                if (p.ExPakistan == 1 && debit > ExPakistanPayDays)
                    v.Warnings.Add("Leave pay abroad is payable for a maximum of " + ExPakistanPayDays + " days at a time (Rule 15(4)).");
            }

            switch (type)
            {
                case LeaveTypeIds2.EOL:
                case LeaveTypeIds2.WithoutPay:
                    ValidateEol(v, s, e, others, ctx, inv);
                    break;
                case LeaveTypeIds2.Study:
                    ValidateStudy(v, s, days, others, ctx);
                    break;
                case LeaveTypeIds2.Maternity:
                    if (ctx.IsFemale == false)
                        v.Errors.Add("Maternity leave is admissible to a female civil servant only (Rule 13).");
                    if (days > MaternityMaxDays)
                        v.Errors.Add("Maternity leave cannot exceed " + MaternityMaxDays + " days (Rule 13(1)).");
                    if (others.Count(x => x.LeaveTypeId == LeaveTypeIds2.Maternity) >= MaternityMaxTimes)
                        v.Errors.Add("Maternity leave has already been granted " + MaternityMaxTimes + " times; for later confinements leave is taken from the normal leave account (Rule 13(3)).");
                    break;
                case LeaveTypeIds2.Recreation:
                    if (p.NumberOfDays != 10)
                        v.Errors.Add("Enter 10 days for recreation leave: 15 days of leave are granted and debited as 10 days of LFP (Rule 10).");
                    if (others.Any(x => x.LeaveTypeId == LeaveTypeIds2.Recreation && x.StartDate.Year == s.Year))
                        v.Errors.Add("Recreation leave has already been granted in " + s.Year + "; it is admissible once in a calendar year (Rule 10).");
                    break;
                case LeaveTypeIds2.Special:
                    if (days > WidowSpecialLeaveDays)
                        v.Warnings.Add("Special leave on death of husband is limited to " + WidowSpecialLeaveDays + " days (Rule 12); ignore this if it is Khuddam-ul-Hajjaj special leave.");
                    break;
                case LeaveTypeIds2.Disability:
                    if (days > DisabilityMaxDays)
                        v.Errors.Add("Disability leave cannot exceed " + DisabilityMaxDays + " days on each occasion (Rule 14).");
                    break;
                case LeaveTypeIds2.LPR:
                    int lprTotal = others.Where(x => x.LeaveTypeId == LeaveTypeIds2.LPR).Sum(x => CalendarDays(x)) + days;
                    if (lprTotal > LprMaxDays)
                        v.Errors.Add("Leave preparatory to retirement cannot exceed " + LprMaxDays + " days in all (Rule 16(1)); with this leave it would be " + lprTotal + " days.");
                    if (ctx.Superannuation.HasValue && e > ctx.Superannuation.Value)
                        v.Warnings.Add("LPR extends beyond the superannuation date (" + ctx.Superannuation.Value.ToString("dd/MM/yyyy", inv) + ").");
                    break;
                case LeaveTypeIds2.NotDue:
                    ValidateNotDue(v, s, debit, others, ctx);
                    break;
                case LeaveTypeIds2.Casual:
                    if (days > CasualLeaveAtATime)
                        v.Warnings.Add("Casual leave at a time is limited to " + CasualLeaveAtATime + " days; it can be relaxed only by the Head of Department.");
                    for (int y = s.Year; y <= e.Year; y++)
                    {
                        DateTime ys = new DateTime(y, 1, 1);
                        DateTime ye = new DateTime(y, 12, 31);
                        int used = others.Where(x => x.LeaveTypeId == LeaveTypeIds2.Casual).Sum(x => OverlapDays(x.StartDate.Date, x.EndDate.Date, ys, ye));
                        int adding = OverlapDays(s, e, ys, ye);
                        if (used + adding > CasualLeavePerYear)
                            v.Errors.Add("Casual leave in " + y + " would be " + (used + adding) + " days; the limit is " + CasualLeavePerYear + " days in a calendar year (" + used + " already taken).");
                    }
                    break;
            }

            if (p.IsExtension == 1 && !others.Any(x => x.EndDate.Date < s && Bridges(x.EndDate.Date, s)))
                v.Warnings.Add("Marked as an extension, but no leave ends immediately before this leave.");

            if (v.IsValid && debit > 0 && type != LeaveTypeIds2.NotDue && ctx.ServiceStart.HasValue)
            {
                LeaveAccount2 before = Compute(ctx.ServiceStart.Value, s.AddDays(-1), ctx.OpeningCredit, others, ctx.Suspensions);
                int available = before.BalanceBefore(s);
                if (debit > available)
                    v.Warnings.Add("Leave due at the start of this leave is " + available + " days but " + debit + " days of LFP are being debited. The excess should be granted as Leave not due (Rule 11).");
            }

            return v;
        }

        private static void ValidateEol(LeaveValidation2 v, DateTime s, DateTime e, List<EmployeeLeave> others, LeaveContext2 ctx, CultureInfo inv)
        {
            if (ctx.ServiceStart.HasValue)
            {
                int served = WholeYears(ctx.ServiceStart.Value, s);
                int maxYears = served >= 10 ? 5 : 2;
                if (e > s.AddYears(maxYears).AddDays(-1))
                    v.Errors.Add("EOL cannot exceed " + maxYears + " years at a time for a civil servant with " + (served >= 10 ? "10 or more" : "less than 10") + " years of continuous service (Rule 9(1)).");
            }

            DateTime spellStart = s;
            DateTime spellEnd = e;
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (EmployeeLeave o in others)
                {
                    if (o.LeaveSubTypeId == LeaveSubTypeIds2.Outside)
                        continue;
                    DateTime os = o.StartDate.Date;
                    DateTime oe = o.EndDate.Date;
                    if (oe < spellStart && Bridges(oe, spellStart))
                    {
                        spellStart = os;
                        changed = true;
                    }
                    else if (os > spellEnd && Bridges(spellEnd, os))
                    {
                        spellEnd = oe;
                        changed = true;
                    }
                }
            }
            if (spellEnd > spellStart.AddYears(5).AddDays(-1))
                v.Errors.Add("EOL together with the leave granted in combination with it cannot exceed 5 years (Rule 9(1) proviso); the combined period is " + spellStart.ToString("dd/MM/yyyy", inv) + " to " + spellEnd.ToString("dd/MM/yyyy", inv) + ".");
        }

        private static void ValidateStudy(LeaveValidation2 v, DateTime s, int days, List<EmployeeLeave> others, LeaveContext2 ctx)
        {
            int total = others.Where(x => x.LeaveTypeId == LeaveTypeIds2.Study).Sum(x => CalendarDays(x)) + days;
            if (total > StudyLeaveMaxDays)
                v.Errors.Add("Study leave cannot exceed 48 months in the entire service (FR 84); with this leave it would be " + total + " days.");
            if (ctx.ServiceStart.HasValue)
            {
                int served = WholeYears(ctx.ServiceStart.Value, s);
                if (served < 5)
                    v.Warnings.Add("Study leave should not ordinarily be granted to a civil servant with less than five years of service.");
                if (s >= ctx.ServiceStart.Value.AddYears(22))
                    v.Warnings.Add("Study leave should not ordinarily be granted within three years of the date on which the civil servant can retire on 25 years of service.");
            }
            if (ctx.Superannuation.HasValue && s >= ctx.Superannuation.Value.AddYears(-3))
                v.Warnings.Add("Study leave should not ordinarily be granted within three years of retirement.");
        }

        private static void ValidateNotDue(LeaveValidation2 v, DateTime s, int debit, List<EmployeeLeave> others, LeaveContext2 ctx)
        {
            List<EmployeeLeave> notDue = others.Where(x => x.LeaveTypeId == LeaveTypeIds2.NotDue).ToList();
            int total = notDue.Sum(x => DebitDays(x)) + debit;
            if (total > LeaveNotDueMax)
                v.Errors.Add("Leave not due cannot exceed " + LeaveNotDueMax + " days in the entire service (Rule 11(1)); with this leave it would be " + total + " days.");
            if (ctx.ServiceStart.HasValue)
            {
                DateTime fiveYears = ctx.ServiceStart.Value.AddYears(5);
                if (s < fiveYears)
                {
                    int early = notDue.Where(x => x.StartDate.Date < fiveYears).Sum(x => DebitDays(x)) + debit;
                    if (early > LeaveNotDueFirstFiveYears)
                        v.Errors.Add("Leave not due cannot exceed " + LeaveNotDueFirstFiveYears + " days in the first five years of service (Rule 11(1)); with this leave it would be " + early + " days.");
                }
            }
        }

        #endregion
    }
}
