using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDAL
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
            //return "Server=db-server.senate.gov.pk;Database=STUSER3; User id=sa;password=X#Bv7_4qT!Ma;Max Pool Size=200;Encrypt=True";
            return "Server=172.16.15.9;Database=STUSER3; User id=sa;password=X#Bv7_4qT!Ma;Max Pool Size=200;Encrypt=True;TrustServerCertificate =True";
        }
    }
}
