using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project3
{
    internal class DataBase
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-N4O5T8O\SQLEXPRESS01;Initial Catalog=project3;Integrated Security=True");


        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}
