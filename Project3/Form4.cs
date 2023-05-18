using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
   
    public partial class Form4 : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;

        public Form4()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 14);
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 14);
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "№");
            dataGridView1.Columns.Add("user_name", "Имя пользователя");
            dataGridView1.Columns.Add("area", "Район");
            dataGridView1.Columns.Add("price", "цена");
            dataGridView1.Columns.Add("date", "дата");
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record) 
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDecimal(3), record.GetString(4));

        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string querystring = $"select id, user_name, area, price, date from history";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        public void Info()
        {
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                int id = int.Parse(row.Cells[0].Value.ToString());
                string q2 = $"select user_name from history where id={id}";
                string q3 = $"select trash_type1 from history where id={id}";
                string q4 = $"select trash_type2 from history where id={id}";
                string q5 = $"select trash_type3 from history where id={id}";
                string q6 = $"select car_type from history where id={id}";
                string q7 = $"select car_color from history where id={id}";
                string q8 = $"select area from history where id={id}";
                string q9 = $"select price from history where id={id}";
                string q10 = $"select date from history where id={id}";

                SqlCommand c2 = new SqlCommand(q2, dataBase.getConnection());
                SqlCommand c3 = new SqlCommand(q3, dataBase.getConnection());
                SqlCommand c4 = new SqlCommand(q4, dataBase.getConnection());
                SqlCommand c5 = new SqlCommand(q5, dataBase.getConnection());
                SqlCommand c6 = new SqlCommand(q6, dataBase.getConnection());
                SqlCommand c7 = new SqlCommand(q7, dataBase.getConnection());
                SqlCommand c8 = new SqlCommand(q8, dataBase.getConnection());
                SqlCommand c9 = new SqlCommand(q9, dataBase.getConnection());
                SqlCommand c10 = new SqlCommand(q10, dataBase.getConnection());

                string z1 = id.ToString();
                string z2 = c2.ExecuteScalar().ToString();
                string z3 = c3.ExecuteScalar().ToString();
                string z4 = c4.ExecuteScalar().ToString();
                string z5 = c5.ExecuteScalar().ToString();
                string z6 = c6.ExecuteScalar().ToString();
                string z7 = c7.ExecuteScalar().ToString();
                string z8 = c8.ExecuteScalar().ToString();
                string z9 = c9.ExecuteScalar().ToString();
                string z10 = c10.ExecuteScalar().ToString();

                Form5 f5 = new Form5(z1, z2, z3, z4, z5, z6, z7, z8, z9, z10);
                f5.ShowDialog();

            }
        }
    }
}
