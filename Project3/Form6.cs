using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form6 : Form
    {
        DataBase dataBase = new DataBase();
        public Form6()
        {
            InitializeComponent();
            this.button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkUser() == false)
            {
                var login = textBox1.Text;
                var name = textBox2.Text;
                var password = textBox3.Text;
                string querystring = $"insert into users(login, name, password) values('{login}', '{name}' ,'{password}')";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                dataBase.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт создан");
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан");
                }
                dataBase.closeConnection();
            }
            else
            {
                MessageBox.Show("Аккаунт с таким логином уже есть");
            }
        }

        private Boolean checkUser()
        {
            var login = textBox1.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"select * from users where login = '{login}'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Close();
            f2.Show();
        }
    }
}
