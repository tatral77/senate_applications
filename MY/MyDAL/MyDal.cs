using EstablishmentDAL;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDAL
{
    public class MyDal
    {
        public User GetEmployeeUser(double PersonalNumber,string Password)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MY]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER";
                cmd.Parameters.Add("@PersonalNumber", SqlDbType.Float).Value = PersonalNumber;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {

                    User pd = new User();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        pd.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        pd.FullName = Convert.ToString(dr["F_NAME"]);
                        pd.PostId= Convert.ToInt32(dr["POST_HELD"]);
                        pd.PersonalNumber= Convert.ToString(dr["PERSONAL_NO"]);
                        pd.BranchId= Convert.ToInt32(dr["BRANCH"]);
                    }
                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }

    }
}
