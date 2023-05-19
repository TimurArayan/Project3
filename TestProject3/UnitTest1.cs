using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataBase dataBase = new DataBase();

            dataBase.openConnection();
            string querystring = $"insert into accounts_db (names, surnames, emails, passwords) values ('Анжуманя', 'Бегит', '@.2154765312', '123357521312')";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());


            Assert.IsTrue(sqlCommand.ExecuteNonQuery() == 1);
        }
    }
}
