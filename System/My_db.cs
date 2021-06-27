using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class My_db
    {
       
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
        public SqlConnection getConnection
        {
            get
            {
                return conn;
            }
        }
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public static string type;
      
    }
}
