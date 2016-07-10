using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_急速穿梭
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string output = "";
                foreach (string line in textBox1.Lines)
                {
                    string[] data = line.Split(' ');
                    string[] d2 = data[1].Split('/');
                    double a = double.Parse(data[0]),
                           b = double.Parse(d2[0]) / double.Parse(d2[1]),
                           c = double.Parse(data[2]);
                    output += Math.Round(a * b / c, 0, MidpointRounding.AwayFromZero).ToString() + Environment.NewLine;
                }
                textBox2.Text = output;
            }
            catch (Exception)
            {
                MessageBox.Show("輸入有誤");
                return;
            }
        }
    }
}
