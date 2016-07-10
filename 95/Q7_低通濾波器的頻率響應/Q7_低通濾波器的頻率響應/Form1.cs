using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q7_低通濾波器的頻率響應
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
                double R = double.Parse(textBox1.Text),
                       C = double.Parse(textBox2.Text),
                       f = double.Parse(textBox3.Text);
                double av = 20 * Math.Log10(1 / Math.Sqrt(1 + Math.Pow(2 * Math.PI * R * C * f, 2)));
                double Xc = (double)1 / (2 * Math.PI * f * C);
                double Z = Math.Sqrt(R * R + Xc * Xc);
                double theta = -90 - Math.Asin(-Xc / Z) * 180 / Math.PI;
                textBox4.Text = Math.Round(av, 3).ToString() + " dB";
                textBox5.Text = Math.Round(theta, 3).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("輸入有誤");
                return;
            }
        }
    }
}
