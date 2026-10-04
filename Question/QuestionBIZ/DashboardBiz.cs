using QuestionDAL;
using RsolutionDAL;
using System;
using System.Collections.Generic;

namespace QuestionBIZ
{
    // One stat card on the Question home page.
    public class DashboardCard
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int Count { get; set; }
        public string CssClass { get; set; }
        public string Icon { get; set; }
        public string LinkUrl { get; set; }
    }

    public class DashboardBiz
    {
        public string SessionNumber { get; private set; }

        // Builds every card for the current session. To add a card, add one more block here.
        public List<DashboardCard> GetCards()
        {
            int sessionId = new AdministrationBiz().GetCurrentAssemblySessions();
            DashboardDAL dal = new DashboardDAL();
            SessionNumber = dal.GetSessionNumber(sessionId);
            Dictionary<string, int> byStatus = dal.GetQuestionCountsByStatus(sessionId);

            List<Entities.Questions> noticeQuestions = new QuestionBiz().GetNoticeQuestions(sessionId);
            List<ResolutionEntities.ResolutionEnt> noticeResolutions = new ResolutionDal().GetSentResolutions(sessionId);

            List<DashboardCard> cards = new List<DashboardCard>();
            cards.Add(new DashboardCard { Title = "Admitted Questions", Subtitle = "This session", Count = Count(byStatus, "Admitted"), CssClass = "accent-green", Icon = "glyphicon-ok-circle" });
            cards.Add(new DashboardCard { Title = "Under Process Questions", Subtitle = "This session", Count = Count(byStatus, "Under Process"), CssClass = "accent-amber", Icon = "glyphicon-time" });
            cards.Add(new DashboardCard { Title = "Disallowed Questions", Subtitle = "This session", Count = Count(byStatus, "Disallowed"), CssClass = "accent-red", Icon = "glyphicon-ban-circle" });
            cards.Add(new DashboardCard { Title = "Questions from Notice Office", Subtitle = "Received this session", Count = noticeQuestions == null ? 0 : noticeQuestions.Count, CssClass = "accent-blue", Icon = "glyphicon-inbox", LinkUrl = "NoticeQuestions.aspx" });
            cards.Add(new DashboardCard { Title = "Resolutions from Notice Office", Subtitle = "Received this session", Count = noticeResolutions == null ? 0 : noticeResolutions.Count, CssClass = "accent-purple", Icon = "glyphicon-file", LinkUrl = "NoticeResolutions.aspx" });

            // Questions whose 8 clear working days are over but are still Under Process / Under Correspondence.
            // A problem with this one number must not stop the rest of the home page from showing.
            int due;
            string dueSubtitle = DueQuestionsBiz.ClearDays + "+ clear working days passed, not yet admitted";
            try { due = new DueQuestionsBiz().Count(sessionId, DateTime.Today); }
            catch { due = -1; dueSubtitle = "Could not be counted right now"; }
            cards.Add(new DashboardCard { Title = "Due for Question List", Subtitle = dueSubtitle, Count = due, CssClass = "accent-teal", Icon = "glyphicon-list-alt", LinkUrl = "DueQuestions.aspx" });
            return cards;
        }

        public string GetSessionNumber(int sessionId)
        {
            return new DashboardDAL().GetSessionNumber(sessionId);
        }

        private static int Count(Dictionary<string, int> byStatus, string status)
        {
            int n;
            return byStatus.TryGetValue(status, out n) ? n : 0;
        }
    }
}
