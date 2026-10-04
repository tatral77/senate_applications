using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuestionDAL
{
    // One existing question that is a candidate for the similarity check.
    public class SimilarityCandidate
    {
        public int QuestionsId { get; set; }
        public string SessionNumber { get; set; }
        public string QuestionText { get; set; }
        public string MoverName { get; set; }
        public string Status { get; set; }
        public string Division { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
    }

    public class SimilarityDAL
    {
        // Non-deleted questions from the current session and the previous 'sessionsBack' sessions.
        // Sessions are ordered by their id, the same way the other question pages compare session ranges.
        public List<SimilarityCandidate> GetCandidates(int currentSessionId, int sessionsBack)
        {
            List<SimilarityCandidate> list = new List<SimilarityCandidate>();
            string query = @"SELECT QUESTIONS.QUESTIONS_ID, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME, QUESTIONS.QUESTION_TEXT,
                                    LTRIM(RTRIM(CONCAT(SYSTEM_USERS.F_NAME, ' ', SYSTEM_USERS.M_NAME, ' ', SYSTEM_USERS.L_NAME))) AS MOVER_NAME,
                                    QUESTION_STATUSES.DESCRIPTION AS STATUS, DIVISIONS.DESCRIPTION AS DIVISION_NAME,
                                    QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE
                             FROM QUESTIONS INNER JOIN
                                  ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID INNER JOIN
                                  QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN
                                  SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID LEFT JOIN
                                  DIVISIONS ON QUESTIONS.DIVISION = DIVISIONS.DIVISIONS_ID
                             WHERE ISNULL(QUESTIONS.IS_DELETED, 0) = 0
                               AND QUESTIONS.SESSION_NUMBER IN (SELECT TOP (@Count) ASSEMBLY_SESSIONS_ID
                                                                FROM ASSEMBLY_SESSIONS
                                                                WHERE ASSEMBLY_SESSIONS_ID <= @Current
                                                                ORDER BY ASSEMBLY_SESSIONS_ID DESC)";
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandTimeout = 120;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Value = sessionsBack + 1;   // current + previous N
                cmd.Parameters.Add("@Current", SqlDbType.Int).Value = currentSessionId;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SimilarityCandidate c = new SimilarityCandidate();
                        c.QuestionsId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        c.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                        c.QuestionText = dr["QUESTION_TEXT"] == DBNull.Value ? "" : Convert.ToString(dr["QUESTION_TEXT"]);
                        c.MoverName = Convert.ToString(dr["MOVER_NAME"]);
                        c.Status = Convert.ToString(dr["STATUS"]);
                        c.Division = dr["DIVISION_NAME"] == DBNull.Value ? "" : Convert.ToString(dr["DIVISION_NAME"]);
                        if (dr["NOTICE_DIARY_NO"] != DBNull.Value) c.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value) c.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        list.Add(c);
                    }
                }
            }
            return list;
        }
    }
}
