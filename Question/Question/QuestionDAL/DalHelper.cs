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
            //string connString = "Server=localhost;Database=STUSER3; User id=sa;password=123";
            string connString = "Server=BACKUP-SERVER\\SENATEDB;Database=STUSER3; User id=sa;password=123;Max Pool Size=200;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
