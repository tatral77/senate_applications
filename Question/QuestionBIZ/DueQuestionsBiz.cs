using QuestionDAL;
using System;
using System.Collections.Generic;

namespace QuestionBIZ
{
    // Questions that have waited long enough to go into a question list but are still not admitted.
    //
    // Rule: a question is ready for the list once 8 clear days have passed since its notice date, not counting
    // Saturdays and Sundays. "Clear" means the notice day itself and the day of the list are not counted.
    // Public holidays are not known to the system, so they are counted as working days.
    // Only questions still "Under Process" or "Under Correspondence" are shown.
    public class DueQuestionsBiz
    {
        public const int ClearDays = 8;

        // Notice dates strictly before this date are ready.
        // (Counting back from today, the 8th working day is the last day that must lie fully between notice and list.)
        public static DateTime ReadyBefore(DateTime today)
        {
            int counted = 0;
            DateTime d = today.Date;
            while (true)
            {
                d = d.AddDays(-1);
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday) continue;
                if (++counted == ClearDays) return d;
            }
        }

        // The last notice date that is ready today (for showing on screen).
        public static DateTime LatestReadyNoticeDate(DateTime today)
        {
            return ReadyBefore(today).AddDays(-1);
        }

        private const string FromWhereFormat =
            " FROM QUESTIONS INNER JOIN " +
            " QUESTION_CATEGORIES ON QUESTIONS.QUESTION_CATEGORY = QUESTION_CATEGORIES.QUESTION_CATEGORIES_ID INNER JOIN " +
            " QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN " +
            " DIVISIONS ON QUESTIONS.DIVISION = DIVISIONS.DIVISIONS_ID INNER JOIN " +
            " SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN " +
            " ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID INNER JOIN " +
            " MEMBERS ON SYSTEM_USERS.SYSTEM_USERS_ID = MEMBERS.SYSTEM_USERS_ID INNER JOIN " +
            " POLITICAL_PARTIES ON MEMBERS.POLITICAL_PARTY = POLITICAL_PARTIES.POLITICAL_PARTIES_ID INNER JOIN " +
            " COALITIONS ON POLITICAL_PARTIES.COALITIONS_ID = COALITIONS.COALITIONS_ID INNER JOIN " +
            " GROUPS ON QUESTIONS.MINISTRY_GROUP = GROUPS.GROUPS_ID " +
            " WHERE QUESTIONS.SESSION_NUMBER = {0} " +
            " AND ISNULL(QUESTIONS.IS_DELETED, 0) = 0 " +
            " AND (LTRIM(RTRIM(QUESTION_STATUSES.DESCRIPTION)) LIKE 'Under Process%' OR LTRIM(RTRIM(QUESTION_STATUSES.DESCRIPTION)) LIKE 'Under Corr%') " +
            " AND CAST(QUESTIONS.NOTICE_DIARY_DATE AS DATE) < '{1}' ";

        // Only numbers and an ISO date are put into the text, so nothing typed by a user reaches the query.
        private static string FromWhere(int sessionId, DateTime today)
        {
            return string.Format(FromWhereFormat, sessionId, ReadyBefore(today).ToString("yyyyMMdd"));
        }

        // Same columns as the Search Question page, so the list can reuse the same display.
        public string BuildListQuery(int sessionId, DateTime today)
        {
            return "SELECT QUESTIONS.QUESTIONS_ID,QUESTIONS.LIST_NO,QUESTIONS.SUP_NO, QUESTIONS.PARLIAMENTARY_YEAR, QUESTIONS.MOVER, QUESTIONS.QUESTION_CATEGORY,QUESTIONS.STATUS_DATE, QUESTIONS.QUESTION_DATE, QUESTIONS.QUESTION_TIME, QUESTIONS.SUBJECT, " +
                   " QUESTIONS.QUESTION_TEXT, QUESTIONS.MINISTRY, QUESTIONS.MINISTRY_GROUP, QUESTIONS.DIVISION,DIVISIONS.DESCRIPTION AS DIVISION_NAME, QUESTIONS.DEPARTMENTS_ID, QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE, QUESTIONS.REPLY_DATE, " +
                   " QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.ADMITTED_NUMBER,QUESTIONS.IS_CARRY_FWD, QUESTIONS.QUESTION_DIARY_NO, QUESTIONS.QUESTION_DIARY_DATE, QUESTIONS.QUESTION_DIARY_TIME, QUESTIONS.SESSION_NUMBER, " +
                   " QUESTIONS.SESSION_SITTINGS_ID, CONCAT(SYSTEM_USERS.F_NAME,' ' ,SYSTEM_USERS.M_NAME,' ',SYSTEM_USERS.L_NAME) AS F_NAME, QUESTION_STATUSES.DESCRIPTION AS QUESTION_STATUS, QUESTION_CATEGORIES.DESCRIPTION AS CATEGORY,ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME,GROUPS.GROUP_SEQUENCE,QUESTIONS.DELETED_BY,QUESTIONS.DELETION_DATE " +
                   ", COALITIONS.COALITIONS_ID,POLITICAL_PARTIES.DESCRIPTION AS POLITICAL_PARTY_DESC, MEMBERS.POLITICAL_PARTY, COALITIONS.DESCRIPTION AS COALLITION_DESC,DEVICE_ID " +
                   FromWhere(sessionId, today) +
                   " ORDER BY QUESTIONS.NOTICE_DIARY_DATE, QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.NOTICE_DIARY_NO";
        }

        public List<Entities.Questions> GetList(int sessionId, DateTime today)
        {
            return new QuestionBiz().SearchQuestion(BuildListQuery(sessionId, today));
        }

        // Counted with the same joins and filters as the list, so the home-page number always matches the page it opens.
        public int Count(int sessionId, DateTime today)
        {
            return new DashboardDAL().Count("SELECT COUNT(*) " + FromWhere(sessionId, today));
        }
    }
}
