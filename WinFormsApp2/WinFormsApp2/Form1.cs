using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double txt1 = Convert.ToDouble(textBox1.Text);
            double txt2 = Convert.ToDouble(textBox2.Text);
            double sum = txt1 + txt2;
            textBox3.Text=sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double txt1 = Convert.ToDouble(textBox1.Text);
            double txt2 = Convert.ToDouble(textBox2.Text);
            double sum = txt1 - txt2;
            textBox3.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double txt1 = Convert.ToDouble(textBox1.Text);
            double txt2 = Convert.ToDouble(textBox2.Text);
            double sum = txt1 / txt2;
            textBox3.Text = sum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double txt1 = Convert.ToDouble(textBox1.Text);
            double txt2 = Convert.ToDouble(textBox2.Text);
            double sum = txt1 * txt2;
            textBox3.Text = sum.ToString();
        }
    }
}
