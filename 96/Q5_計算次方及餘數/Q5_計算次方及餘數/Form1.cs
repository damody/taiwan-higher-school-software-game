using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_計算次方及餘數
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calcuate A^B mod C
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="c">C</param>
        /// <returns>A^B mod C</returns>
        long BigMod(long a, long b, long c)
        {
            long k = a;
            while (--b > 0)
                k = k * a % c;
            return k;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long A, B, C;
            if (long.TryParse(textBox1.Text, out A) && (long.TryParse(textBox2.Text, out B) && long.TryParse(textBox3.Text, out C)))
            {
                textBox4.Text = BigMod(A, B, C).ToString();
            }
            else
            {
                MessageBox.Show("輸入有誤");
            }
        }
    }
}
