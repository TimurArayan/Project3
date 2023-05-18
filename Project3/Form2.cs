using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var login = textBox1.Text;
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select name from users where login = '{login}' and password = '{password}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;

            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                dataBase.openConnection();
                About.user_name = command.ExecuteScalar().ToString();
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует");
            }
            dataBase.closeConnection();
        }

        private void label3_Click(object sender, EventArgs e)
        {
              Form6 f6 = new Form6();
              this.Hide();
              f6.ShowDialog();      
        }
    }
}
