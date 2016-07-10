using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Q3_數值轉換程式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^(\-?)(\d+)(\.?\d*)$");
            if (!regex.IsMatch(textBox1.Text))
            {
                textBox2.Text = "不正確的輸入格式";
                return;
            }
            Match match = regex.Match(textBox1.Text);
            int sign = match.Groups[1].Value == "-" ? 1 : 0;
            int integer;
            double floating;
            try
            {
                integer = int.Parse(match.Groups[2].Value);
                if (integer > ((1 << 15) - 1))
                    throw new Exception();
            }
            catch (Exception)
            {
                textBox2.Text = "overflow";
                return;
            }
            try
            {
                string k = match.Groups[3].Value;
                if (k.Length > 0)
                {
                    floating = double.Parse(k);
                }
                else
                {
                    floating = 0;
                }
            }
            catch (Exception)
            {
                textBox2.Text = "overflow";
                return;
            }
            string output = sign.ToString() + Convert.ToString(integer, 2).PadLeft(15, '0') + ".";
            for (int i = 1; i <= 8; i++)
            {
                double m = (double)1 / (1 << i);
                if (floating >= m)
                {
                    output += '1';
                    floating -= m;
                    continue;
                }
                output += '0';
            }
            textBox2.Text = output;
        }
    }
}
