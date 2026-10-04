using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EstablishmentDAL
{
    public class DashboardDAL
    {
        // Retirement (superannuation) at 60, same rule as SuperanuationReport.
        public List<DashboardEmployee> GetRetiringBetween(DateTime from, DateTime to)
        {
            string query = @"SELECT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS,
                                    DATEADD(year, 60, SYSTEM_USERS.DOB) AS D, '' AS DETAIL
                             FROM SYSTEM_USERS INNER JOIN
                                  EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN
                                  POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN
                                  BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID
                             WHERE SYSTEM_USERS.IS_ACTIVE = 1 AND SYSTEM_USERS.DOB IS NOT NULL
                               AND DATEADD(year, 60, SYSTEM_USERS.DOB) >= @From AND DATEADD(year, 60, SYSTEM_USERS.DOB) < @To
                             ORDER BY D";
            return Run(query, from, to);
        }

        // Leave whose end date falls in the window.
        public List<DashboardEmployee> GetLeaveEndingBetween(DateTime from, DateTime to)
        {
            string query = @"SELECT DISTINCT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS,
                                    EMP_LEAVES.END_DATE AS D, EMP_LEAVE_TYPES.DESCRIPTION AS DETAIL
                             FROM SYSTEM_USERS INNER JOIN
                                  EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN
                                  EMP_LEAVES ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_LEAVES.SYSTEM_USERS_ID INNER JOIN
                                  EMP_LEAVE_TYPES ON EMP_LEAVES.EMP_LEAVE_TYPES_ID = EMP_LEAVE_TYPES.EMP_LEAVES_TYPE_ID INNER JOIN
                                  POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN
                                  BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID
                             WHERE SYSTEM_USERS.IS_ACTIVE = 1
                               AND EMP_LEAVES.END_DATE >= @From AND EMP_LEAVES.END_DATE < @To
                             ORDER BY D";
            return Run(query, from, to);
        }

        // Probation whose end date falls in the window.
        public List<DashboardEmployee> GetProbationEndingBetween(DateTime from, DateTime to)
        {
            string query = @"SELECT DISTINCT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS,
                                    EMP_PROBATION.PROBATION_TO AS D, '' AS DETAIL
                             FROM SYSTEM_USERS INNER JOIN
                                  EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN
                                  EMP_PROBATION ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_PROBATION.SYSTEM_USERS_ID INNER JOIN
                                  POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN
                                  BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID
                             WHERE SYSTEM_USERS.IS_ACTIVE = 1
                               AND EMP_PROBATION.PROBATION_TO >= @From AND EMP_PROBATION.PROBATION_TO < @To
                             ORDER BY D";
            return Run(query, from, to);
        }

        // 'to' is exclusive.
        private List<DashboardEmployee> Run(string query, DateTime from, DateTime to)
        {
            List<DashboardEmployee> list = new List<DashboardEmployee>();
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@From", System.Data.SqlDbType.DateTime).Value = from;
                cmd.Parameters.Add("@To", System.Data.SqlDbType.DateTime).Value = to;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DashboardEmployee e = new DashboardEmployee();
                        e.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        e.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        e.Post = Convert.ToString(dr["POST"]);
                        e.Bps = Convert.ToString(dr["BPS"]);
                        e.Date = Convert.ToDateTime(dr["D"]);
                        e.Detail = Convert.ToString(dr["DETAIL"]);
                        list.Add(e);
                    }
                }
            }
            return list;
        }
    }
}
