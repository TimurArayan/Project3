using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            Form2 f2 = new Form2();
            f2.Show();
            this.Visible = false;
        }
    }
}
