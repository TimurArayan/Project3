﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form5 : Form
    {
        public Form5(string a1, string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9, string a10)
        {
            InitializeComponent();
            label8.Text = a10;
            label9.Text = a9;
            label10.Text = a8;
            label11.Text = a6 + "; " + a7;
            label12.Text = a3 + "; " + a4 + ";\n" + a5;
            label13.Text = a2;
            label14.Text = a1;
        }

        void F(string a)
        {
            string b = "";
            string c = "";
            int l = a.Length;
            if (l > 30)
            {
                for (int i = 30; i < a.Length; i++)
                {
                    if (a[i].Equals(','))
                    {
                        c += a[i];
                    }
                }
                c.Remove(0, 1);
            }
        }
    }
}
