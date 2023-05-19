using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Project3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateAccount()
        {
            DataBase dataBase = new DataBase();

            dataBase.openConnection();
            string querystring = $"insert into users(login, name, password) values ('oXXXymiron', 'Мирон' ,'Oxxxy123')";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());


            Assert.IsTrue(sqlCommand.ExecuteNonQuery() == 1);
            dataBase.closeConnection();
        }
        [TestMethod]
        public void TestCreateHistory()
        {
            DataBase dataBase = new DataBase();

            dataBase.openConnection();
            string querystring = $"insert into history(user_name, trash_type1, trash_type2, trash_type3, car_type, car_color, area, price, date) values('John', 'type1', 'type2', 'type3', 'car_type', 'car_color', 'area', '1777', '07.02.2023')";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());


            Assert.IsTrue(sqlCommand.ExecuteNonQuery() == 1);
            dataBase.closeConnection();
        }
        [TestMethod]
        public void TestEntentranceAccount()
        {
            DataBase dataBase = new DataBase();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataBase.openConnection();
            string querystring = $"select name from users where login = 'oXXXymiron' and password = 'Oxxxy123'";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);


            Assert.IsTrue(dataTable.Rows.Count != 0);
        }
        [TestMethod]
        public void TestDeleteAccount()
        {
            DataBase dataBase = new DataBase();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataBase.openConnection();
            string querystring = "delete from users where login = 'oXXXymiron'";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
            sqlCommand.ExecuteNonQuery();

            querystring = "select * from users where login = 'oXXXymiron'";
            sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);


            Assert.IsTrue(dataTable.Rows.Count != 1);
        }
    }
}
