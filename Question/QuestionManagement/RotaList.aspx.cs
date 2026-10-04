using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class RotaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<AssemblySessions> ASessions = new QuestionBiz().GetAssemblySessions();
                //foreach (AssemblySessions row in ASessions)
                //{
                //    ListItem li = new ListItem();
                //    li.Text = row.SessionNumber.ToString();
                //    li.Value = row.AssemblySessionsId.ToString();
                //    SessionDDL.Items.Add(li);
                //}
                Generate();
            }
        }
        public string DisplayWithSuffix(int num)
        {
            if (num.ToString().EndsWith("11")) return num.ToString() + "<sup>th</sup>";
            if (num.ToString().EndsWith("12")) return num.ToString() + "<sup>th</sup>";
            if (num.ToString().EndsWith("13")) return num.ToString() + "<sup>th</sup>";
            if (num.ToString().EndsWith("1")) return num.ToString() + "<sup>st</sup>";
            if (num.ToString().EndsWith("2")) return num.ToString() + "<sup>nd</sup>";
            if (num.ToString().EndsWith("3")) return num.ToString() + "<sup>rd</sup>";
            return num.ToString() + "<sup>th</sup>";
        }
        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int RotaId = Convert.ToInt32(Request.QueryString["rotalistid"]);
            QuestionsRota rota = new QuestionsRota();
            rota = new AdministrationBiz().GetQuestionRota(RotaId);

            rota.AssemblySessionsId = rota.AssemblySessionsId;
            rota.StartDate = rota.StartDate;
            rota.EndDate = rota.EndDate;
            rota.StartGroup = rota.StartGroup;
            rota.SkipDays = rota.SkipDays;
            new QuestionBiz().UpdateRota(rota);

            List<DateTime> skipdays = rota.SkipDays.Split(',').Select(DateTime.Parse).ToList();
            DateTime StartDate = rota.StartDate;
            DateTime EndDate = rota.EndDate;
            List<DateEntity> dates = new List<DateEntity>();
            int startday = StartDate.Day;
            int startmonth = StartDate.Month;
            int startyear = StartDate.Year;
            int endday = EndDate.Day;
            int endmonth = EndDate.Month;
            int endyear = EndDate.Year;
            string weekday = null;
            string month = GetMonthName(StartDate, EndDate);

            monthlbl.Text = "PROVISIONAL ALLOTMENT OF DAYS TO MINISTRIES /DIVISIONS OF THE FEDERAL GOVERNMENT FOR ANSWERING QUESTIONS DURING ";
            monthlbl.Text += month + " SESSION (" + DisplayWithSuffix(rota.AssemblySessionsId) + " SESSION) ";
            monthlbl.Text += " OF THE SENATE UNDER RULE 46 OF THE RULES OF PROCEDURE AND CONDUCT OF BUSINESS IN THE SENATE 2012.";
            for (DateTime date = StartDate; date <= EndDate; date = date.AddDays(1.0))
            {
                DateEntity de = new DateEntity();
                int dy = date.Day;
                int mn = date.Month;
                int yr = date.Year;
                weekday = Convert.ToString(date.DayOfWeek);
                if ((!skipdays.Contains(date)) && weekday != "Saturday" && weekday != "Sunday" && weekday != "Monday")
                {
                    de.day = dy; de.month = mn; de.year = yr; de.weekday = weekday;
                    dates.Add(de);
                }


            }

            int startfrom = Convert.ToInt32(rota.StartGroup);
            string table = null;
            int tables = 1;

            int group = 0;
            foreach (DateEntity obj in dates)
            {
                int ListNo = 1;
                if (startfrom > 5)
                    startfrom = 1;

                if (startfrom == 1)
                {


                    group = 1;


                }

                if (startfrom == 2)
                {

                    group = 2;

                }

                if (startfrom == 3)
                {

                    group = 3;

                }

                if (startfrom == 4)
                {


                    group = 4;

                }

                if (startfrom == 5)
                {

                    group = 5;

                }


                List<GroupDivisions> gds = new QuestionBiz().GetSingleGroupDivisions(rota.AssemblySessionsId, startfrom);
                DateTime answdate = Convert.ToDateTime(obj.day + "/" + obj.month + "/" + obj.year);
                string qdate = (answdate.AddDays(-14)).ToShortDateString();
                int a = 1;
                table += "<table style='margin-top:5px;padding:5px;'>" +
                    "<tr>" +
                    "<td width='350px' valign='top' style='margin:0px;padding:0px;'><b>List No: " + ListNo + "</b></td>" +
                   
                    "<td width='500px' style='margin:0px;padding:0px;'>" +
                    "<table class='print-tab'>"+
                        "<tr>" +
                            "<th class='print-tab' colspan='2'> Group - " + group + "</th>" +
                         "</tr>";
                            foreach (GroupDivisions gd in gds)
                            {
                                table += "<tr><td class='print-tab'>" + a + "- </td><td>" + gd.Division + "</td></tr>";
                                a++;
                            }
                table += "</td>" +
                     "<td width='350px' valign='top' style='margin:0px;padding:0px;'><b>" + qdate + "</b></td>" +
                    "</tr></table>";
                //if (tables % 3 == 0)
                //    table += "<div class='page-break'></div><br /><br />";
                ListNo++;
                tables++;

                //Response.Write(obj.day + "/" + obj.month + "/" + obj.day+ "= " + startfrom +"<br>");
                startfrom++;
            }
            divisions.InnerHtml = table;


        }
        protected string GetMonthName(DateTime StartDate,DateTime EndDate)
        {
            int StartMonth = StartDate.Month;
            int EndMonth = EndDate.Month;
            int StartYear = StartDate.Year;
            int EndYear = EndDate.Year;
            if (StartYear != EndYear)
            {
                if (StartMonth != EndMonth)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(StartMonth).ToUpper() + ", " + StartYear + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(EndMonth).ToUpper() + ", " + EndYear;
                }
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(StartMonth).ToUpper() + ", " + StartYear;
            }
            else
            {
                if (StartMonth != EndMonth)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(StartMonth).ToUpper()  + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(EndMonth).ToUpper() + ", " + EndYear;
                }
               
            }
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(StartMonth).ToUpper() + ", " +  StartYear;
        }
        public void Generate()
        {
            int RotaId = Convert.ToInt32(Request.QueryString["rotalistid"]);
            QuestionsRota rota = new QuestionsRota();
            rota = new AdministrationBiz().GetQuestionRota(RotaId);
            // List<int> skipdays = rota.SkipDays.Split(',').Select(int.Parse).ToList();
            DateTime StartDate = rota.StartDate;
            DateTime EndDate = rota.EndDate;
            List<DateEntity> dates = new List<DateEntity>();
            int startday = StartDate.Day;
            int startmonth = StartDate.Month;
            int startyear = StartDate.Year;
            int endday = EndDate.Day;
            int endmonth = EndDate.Month;
            int endyear = EndDate.Year;
            string weekday = null;
            int StartListNo = rota.StartListNo;
            string ListType = rota.ListType;
            string month = GetMonthName(StartDate, EndDate);
            monthlbl.Text = ListType.ToUpper() + " ALLOTMENT OF DAYS TO MINISTRIES /DIVISIONS OF THE FEDERAL GOVERNMENT FOR ANSWERING QUESTIONS DURING ";
            monthlbl.Text += month  + " SESSION (" + DisplayWithSuffix(rota.SessionNumber) + " SESSION) ";
            monthlbl.Text += " OF THE SENATE UNDER RULE 46 OF THE RULES OF PROCEDURE AND CONDUCT OF BUSINESS IN THE SENATE 2012.";
            List<string> RotaDays = new List<string>();
            // day.Text = Convert.ToString((int)DateTime.Now.DayOfWeek);
            //if(rota.RotaWeekDay)
            List<DateTime> AllowedDates= GetAllowedDates(StartDate, EndDate, rota.Days,rota.SkipRotaGroups,rota.AllowedDates);
            AllowedDates.Sort((x, y) => x.CompareTo(y));
            foreach (DateTime alloweddates in AllowedDates )
            {
                DateEntity de = new DateEntity();
                de.date = alloweddates;
                de.day = alloweddates.Day;
                de.month = alloweddates.Month;
                de.year = alloweddates.Year;
                de.weekday = Convert.ToString(alloweddates.DayOfWeek); 
                dates.Add(de);
            }
            List<DateEntity> FinalDates = new List<DateEntity>();
          
                    int startgroup = rota.StartGroup;

            foreach (DateEntity dateEntity in dates)
            {
                if (startgroup > 5)
                    startgroup = 1;
                DateEntity de = new DateEntity();
                de = dateEntity;
                if (rota.SkipRotaGroups != null)
                {
                    foreach (SkipRotaGroups sgs in rota.SkipRotaGroups)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(sgs.SkipDate), Convert.ToDateTime(dateEntity.date)) == 0 && sgs.SkipGroup == startgroup)
                        {
                            startgroup++;
                            if (startgroup > 5)
                                startgroup = 1;
                        }

                    }
                }
                de.GroupId = startgroup;
                de.GroupDescription = "Group-" + startgroup;
                FinalDates.Add(de);
                startgroup++;
            }


            // One table: List No | Ministries/Divisions of the group | Date of answering
            System.Text.StringBuilder rows = new System.Text.StringBuilder();
            foreach (DateEntity obj in FinalDates)
            {
                List<GroupDivisions> gds = new QuestionBiz().GetSingleGroupDivisions(rota.AssemblySessionsId, obj.GroupId);
                rows.Append("<tr>");
                rows.Append("<td class='c-list'>List No: " + StartListNo + "</td>");
                rows.Append("<td class='c-divs'><span class='rota-group'>" + HttpUtility.HtmlEncode(obj.GroupDescription) + "</span><ol class='rota-divs'>");
                if (gds != null)
                {
                    foreach (GroupDivisions gd in gds)
                        rows.Append("<li>" + HttpUtility.HtmlEncode(gd.Division) + "</li>");
                }
                rows.Append("</ol></td>");
                rows.Append("<td class='c-date'>" + obj.date.ToLongDateString() + "</td>");
                rows.Append("</tr>");
                StartListNo++;
            }

            string table;
            if (FinalDates.Count == 0)
                table = "<div class='rota-empty'>No answering dates were found for this rota list.</div>";
            else
                table = "<table class='rota'><thead><tr>" +
                        "<th class='c-list'>Admitted Questions List No</th>" +
                        "<th class='c-divs'>Ministries/Divisions</th>" +
                        "<th class='c-date'>Date of Answering</th>" +
                        "</tr></thead><tbody>" + rows + "</tbody></table>";
            divisions.InnerHtml = table;
        }

        protected List<DateTime> GetAllowedDates(DateTime StartDate, DateTime EndDate, string WeekDays,List<SkipRotaGroups> skipRotaGroups,string OtherAllowedDays)
        {
            List<DateTime> AllowedDates = new List<DateTime>();
            List<int> AllowedDays= WeekDays.Split(',').Select(int.Parse).ToList();
            for (DateTime date = StartDate; date <= EndDate; date = date.AddDays(1.0))
            {
                int WeekDayId = (int)date.DayOfWeek;
                if (AllowedDays.Any(x => x.Equals(WeekDayId)))
                {
                    AllowedDates.Add(date);
                }
            }
            List<DateTime> Temp = new List<DateTime>();
            bool matched = false;
            if (skipRotaGroups != null)
            {
                foreach (DateTime alloweddates in AllowedDates)
                {
                    matched = false;

                    foreach (SkipRotaGroups sg in skipRotaGroups)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(alloweddates), Convert.ToDateTime(sg.SkipDate)) == 0 && sg.SkipGroup == 0)
                        {
                            matched = true;
                        }
                    }
                    if (matched != true)
                        Temp.Add(alloweddates);
                }
               // return Temp;
            }
            else
            {
                foreach (DateTime alloweddates in AllowedDates)
                {
                    Temp.Add(alloweddates);
                }
            }
            List<DateTime> otherdates = null;
            if (!String.IsNullOrEmpty(OtherAllowedDays))
            {
                otherdates = OtherAllowedDays.Split(',').Select(s => Convert.ToDateTime(s)).ToList();
            }
            if(otherdates!=null)
            {
                foreach(DateTime od in otherdates)
                {
                    Temp.Add(od);
                }
            }

            return Temp;


        }
    }
}