using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project3
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            RefreshPrice();
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            RefreshPrice();
            radioButton1.Checked = false;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.BorderSize = 0;
        }

        public void RefreshPrice()
        {
            label16.Text = About.price.ToString() + " руб.";
        }

        /// <summary>
        /// Кнопки
        /// </summary>
        private void button1_Click(object sender, EventArgs e) ///Кнопка "Далее" ан панели 1
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false)
            {
                MessageBox.Show("Выберите");

            }
            else
            {
                About.date = dateTimePicker1.Value.ToShortDateString();
                string querystring = $"insert into history(user_name, trash_type1, trash_type2, trash_type3, car_type, car_color, area, price, date) values('{About.user_name}', '{About.trash_type1}', '{About.trash_type2}', '{About.trash_type3}', '{About.car_type}', '{About.car_color}', '{About.area}', '{About.price}', '{About.date}')";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                dataBase.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Заказ сделан. Вы моежете посмотреть его в списке.");
                }
                else
                {
                    MessageBox.Show("Заказ не сделан");
                }
                dataBase.closeConnection();
            }
            
        }
        private void button2_Click(object sender, EventArgs e) ///Кнопка "Далее" ан панели 3
        {
            if (industrial.Checked)
            {
                About.trash_type1 = "Промышленный";
            }
            else if (household.Checked)
            {
                About.trash_type1 = "Бытовой";
            }
            Boolean z = true;
            foreach (CheckBox a in p2.Controls)
            {
                if (a.Checked)
                {
                    if (z)
                    {
                        About.trash_type2 += a.Text;
                        z = false;
                    }
                    else
                    {
                        About.trash_type2 += ", " + a.Text;
                    }
                }
            }
            Boolean x = true;
            foreach (CheckBox a in panel4.Controls)
            {
                if (x)
                {
                    About.trash_type3 += a.Text;
                    x = false;
                }
                else
                {
                    About.trash_type3 += ", " + a.Text;
                }
            }
            if ((solid.Checked | liquid.Checked | gas.Checked) && (paper.Checked | plastic.Checked | glass.Checked | wood.Checked | metal.Checked | rubber.Checked | food.Checked) && (industrial.Checked | household.Checked))
            {
                panel3.Hide();
                panel2.Show();
                pp1.Hide();
                pp2.Show();

            }
            else if (gas.Checked)
            {
                panel3.Hide();
                panel2.Show();
                pp1.Hide();
                pp2.Show();
            }
            else
            {
                MessageBox.Show("Выберите");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((ForIndustrial.Checked == false && Usual.Checked == false) || (green.Checked == false && blue.Checked == false && red.Checked == false))
            {
                MessageBox.Show("Выберите");
            }
            else
            {
                panel2.Hide();
                panel1.Show();
                pp2.Hide();
                pp3.Show();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            About.trash_type1 = null;
            About.trash_type2 = null;
            About.trash_type3 = null;
            panel2.Hide();
            panel3.Show();
            pp1.Show();
            pp2.Hide();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            About.car_color = null;
            About.car_type = null;
            panel1.Hide();
            panel2.Show();
            pp3.Hide();
            pp2.Show();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// районы
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.московсский;
                About.area = "Московский";
                About.price += 90;
                RefreshPrice();
            }
            else
            {
                About.price -= 90;

            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.курский;
                About.area = "Курский";
                About.price += 90;
                RefreshPrice();
            }
            else
            {
                About.price -= 90;

            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.вахитовский;
                About.area = "Вахитовский";
                About.price += 100;
                RefreshPrice();
            }
            else
            {
                About.price -= 100;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.авиастроительный;
                About.area = "Авиастроительный";
                About.price += 80;
                RefreshPrice();
            }
            else
            {
                About.price -= 80;

            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.приволжский;
                About.area = "Приволжский";
                About.price += 100;
                RefreshPrice();
            }
            else
            {
                About.price -= 100;

            }

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.советский;
                About.area = "Советский";
                About.price += 100;
                RefreshPrice();
            }
            else
            {
                About.price += 100;

            }
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                pictureBox1.Image = global::Project3.Properties.Resources.ново_савиновский;
                About.area = "Ново-Савиновский";
                About.price += 90;
                RefreshPrice();
            }
            else
            {
                About.price -= 90;

            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Выбираемые кнопки
        /// </summary>
        private void industrial_CheckedChanged(object sender, EventArgs e)
        {
            if (industrial.Checked)
            {
                solid.Enabled = true;
                liquid.Enabled = true;
                if (solid.Checked)
                {
                    metal.Enabled = true;
                }
                if (liquid.Checked)
                {
                    rubber.Enabled = true;
                }
                food.Enabled = false;
                food.Checked = false;
                gas.Enabled = true;
                TypeOfGarbage.IsIndustrial = true;
                Usual.Enabled = false;
                pictureBox2.Image = global::Project3.Properties.Resources.Завод;
                About.price += 200;
            }
            else
            {
                About.price -= 200;
            }
            RefreshPrice();
        }

        private void household_CheckedChanged(object sender, EventArgs e)
        {
            if (household.Checked)
            {
                if (solid.Checked | liquid.Checked)
                {
                    food.Enabled = true;
                }
                if (solid.Checked == false)
                {
                    rubber.Checked = false;
                    rubber.Enabled = false;
                }
                solid.Enabled = true;
                liquid.Enabled = true;
                metal.Enabled = false;
                metal.Checked = false;
                gas.Enabled = false;
                gas.Checked = false;
                TypeOfGarbage.IsIndustrial = false;
                Usual.Enabled = true;
                pictureBox2.Image = global::Project3.Properties.Resources.домик;
                About.price += 150;
            }
            else
            {
                About.price -= 150;
            }
            RefreshPrice();
        }

        private void solid_CheckedChanged(object sender, EventArgs e)
        {
            if (solid.Checked)
            {
                paper.Enabled = true;
                plastic.Enabled = true;
                glass.Enabled = true;
                wood.Enabled = true;
                if (industrial.Checked)
                {
                    metal.Enabled = true;
                }
                rubber.Enabled = true;
                if (household.Checked)
                {
                    food.Enabled = true;
                }
                pictureBox4.Show();
                About.price += 50;
            }
            else
            {
                paper.Enabled = false;
                paper.Checked = false;
                plastic.Enabled = false;
                plastic.Checked = false;
                glass.Enabled = false;
                glass.Checked = false;
                wood.Enabled = false;
                wood.Checked = false;
                metal.Enabled = false;
                metal.Checked = false;
                rubber.Enabled = false;
                rubber.Enabled = false;
                if (liquid.Checked == false)
                {
                    food.Enabled = false;
                    food.Checked = false;
                }
                pictureBox4.Hide();
                About.price -= 50;
            }
            RefreshPrice();
        }

        private void liquid_CheckedChanged_1(object sender, EventArgs e)
        {
            if (liquid.Checked)
            { 
                if (industrial.Checked)
                {
                    rubber.Enabled = true;
                }
                if (household.Checked)
                {
                    food.Enabled= true;
                }
                pictureBox3.Show();
                About.price += 50;

            }
            else
            {
                if (solid.Checked == false)
                {
                    food.Enabled = false;
                    food.Checked = false;
                }
                if (industrial.Checked == false || solid.Checked == false) 
                {
                    rubber.Enabled = false;
                    rubber.Checked = false;
                }
                pictureBox3.Hide();
                About.price -= 50;
            }
            RefreshPrice();
        }

        private void gas_CheckedChanged(object sender, EventArgs e)
        {
            if (gas.Checked)
            {
                pictureBox13.Show();
                About.price += 20;
            }
            else
            {
                pictureBox13.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }
        private void paper_CheckedChanged(object sender, EventArgs e)
        {
            if (paper.Checked)
            {
                pictureBox7.Show();
                About.price += 20;
            }
            else
            {
                pictureBox7.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void plastic_CheckedChanged(object sender, EventArgs e)
        {
            if (plastic.Checked)
            {
                pictureBox6.Show();
                About.price += 20;

            }
            else
            {
                pictureBox6.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void glass_CheckedChanged(object sender, EventArgs e)
        {
            if (glass.Checked)
            {
                pictureBox5.Show();
                About.price += 20;
            }
            else
            {
                pictureBox5.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void wood_CheckedChanged(object sender, EventArgs e)
        {
            if (wood.Checked)
            {
                pictureBox8.Show();
                About.price += 20;
            }
            else
            {
                pictureBox8.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void metal_CheckedChanged(object sender, EventArgs e)
        {
            if (metal.Checked)
            {
                pictureBox9.Show();
                About.price += 20;
            }
            else
            {
                pictureBox9.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void rubber_CheckedChanged(object sender, EventArgs e)
        {
            if (rubber.Checked)
            {
                pictureBox10.Show();
                About.price += 20;
            }
            else
            {
                pictureBox10.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        private void food_CheckedChanged(object sender, EventArgs e)
        {
            if (food.Checked)
            {
                pictureBox11.Show();
                About.price += 20;
            }
            else
            {
                pictureBox11.Hide();
                About.price -= 20;
            }
            RefreshPrice();
        }

        /// <summary>
        /// Мусоровоз
        /// </summary>
        private void ForIndustrial_CheckedChanged(object sender, EventArgs e)
        {
            if (ForIndustrial.Checked)
            {
                About.price += 300;
                About.car_type = "Промышленный";
                red.Enabled = true;
                green.Enabled = true;
                blue.Enabled = true;
                if (red.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_к;

                }
                else if (green.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_з;

                }
                else if (blue.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_с;

                }
                else
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_б;
                }
            }
            else
            {
                About.price -= 300;
            }
            RefreshPrice();
        }

        private void Usual_CheckedChanged(object sender, EventArgs e)
        {
            if (Usual.Checked)
            {
                About.price += 200;
                About.car_type = "Обычный";
                red.Enabled = true;
                green.Enabled = true;
                blue.Enabled = true;
                if (red.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_к;

                }
                else if (green.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_з;

                }
                else if (blue.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_с;

                }
                else
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_б;
                }
            }
            else
            {
                About.price -= 200;
            }
            RefreshPrice();
        }

        private void blue_CheckedChanged(object sender, EventArgs e)
        {
            if (blue.Checked)
            {
                About.car_color = "Синий";
                if (ForIndustrial.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_с;
                }
                else
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_с;
                }
            }
        }
        private void red_CheckedChanged(object sender, EventArgs e)
        {
            if (red.Checked)
            {
                About.car_color = "Красный";
                if (ForIndustrial.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_к;
                }
                else
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_к;
                }
            }
            
        }

        private void green_CheckedChanged(object sender, EventArgs e)
        {
            if (green.Checked)
            {
                About.car_color = "Зеленый";
                if (ForIndustrial.Checked)
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.и_з;
                }
                else
                {
                    pictureBox12.Image = global::Project3.Properties.Resources.б_з;
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        //////
        ///Картинки кликать
        //////


    }

}
