using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuestionDAL
{
    public class DashboardDAL
    {
        // Number of (non-deleted) questions in the session, keyed by status description.
        public Dictionary<string, int> GetQuestionCountsByStatus(int assemblySessionId)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string query = @"SELECT QUESTION_STATUSES.DESCRIPTION AS STATUS, COUNT(*) AS CNT
                             FROM QUESTIONS INNER JOIN
                                  QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID
                             WHERE QUESTIONS.SESSION_NUMBER = @SessionId AND ISNULL(QUESTIONS.IS_DELETED, 0) = 0
                             GROUP BY QUESTION_STATUSES.DESCRIPTION";
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@SessionId", SqlDbType.Int).Value = assemblySessionId;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        counts[Convert.ToString(dr["STATUS"]).Trim()] = Convert.ToInt32(dr["CNT"]);
                }
            }
            return counts;
        }

        // Runs a query that returns a single number (SELECT COUNT(*) ...). The text must be built by the server only.
        public int Count(string countQuery)
        {
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand(countQuery, con))
            {
                cmd.CommandTimeout = 60;
                object o = cmd.ExecuteScalar();
                return o == null || o == DBNull.Value ? 0 : Convert.ToInt32(o);
            }
        }

        public string GetSessionNumber(int assemblySessionId)
        {
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT SESSION_NUMBER FROM ASSEMBLY_SESSIONS WHERE ASSEMBLY_SESSIONS_ID = @SessionId", con))
            {
                cmd.Parameters.Add("@SessionId", SqlDbType.Int).Value = assemblySessionId;
                object o = cmd.ExecuteScalar();
                return o == null || o == DBNull.Value ? "" : Convert.ToString(o);
            }
        }
    }
}
