using LegisDAL;
using System;
using System.Data.SqlClient;

namespace ManDAL
{
    public class DalHelper
    {
        public SqlConnection GetConnection()
        {
            string connString = GetConnectionString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }
        public string GetConnectionString()
        {
            return "Server=172.16.15.9;Database=STUSER3; User id=sa;password=X#Bv7_4qT!Ma;Max Pool Size=200;Encrypt=True;TrustServerCertificate =True";
        }
        public int GetPk(string Table, string Field)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 0;
                string query = "SELECT MAX(" + Field + ") AS ID FROM " + Table;
                SqlCommand cmd = new SqlCommand(query, con);
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr["ID"] != DBNull.Value)
                    {

                        pk = Convert.ToInt32(dr["ID"]);
                    }

                }
                return ++pk;
            }
            finally
            {
                con.Close();

            }
        }
    }
}
