using System;
using System.Data.SqlClient;

namespace ManDAL
{
    public class DalHelper
    {
        public SqlConnection GetConnection()
        {
            //string connString = "Server=localhost;Database=STUSER3; User id=sa;password=123";
            //string connString = "Server=172.18.1.12\\SENATEDB;Database=STUSER3; User id=sa;password=123;Max Pool Size=200;";
            string connString = "Server=172.16.15.8;Database=STUSER3; User id=sa;password=X#Bv7_4qT!Ma;Max Pool Size=200;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
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
