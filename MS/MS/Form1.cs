using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int A = Convert.ToInt32(textBox1.Text);
            int B = Convert.ToInt32(textBox2.Text);
            int k1 = Convert.ToInt32(textBox3.Text);
            int k2 = Convert.ToInt32(textBox4.Text);
            int F0 = Convert.ToInt32(textBox5.Text);
            int Dt = Convert.ToInt32(textBox6.Text);

            MessageBox.Show("Данные добавлены!");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
