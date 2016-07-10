using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_ISBN計算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ISBN10(string input)
        {
            string r;
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (input[i] - '0') * (10 - i);
            int k = (11 - (sum % 11)) % 11;
            r = (k == 10) ? input + "X" : input + k.ToString();
            return string.Format("{0}-{1}-{2}-{3}", r.Substring(0, 3), r.Substring(3, 4), r.Substring(7, 2), r.Substring(9, 1));
        }

        string ISBN13(string input)
        {
            input = "978" + input;
            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (input[i] - '0') * (1 + i % 2 * 2);
            int k = (10 - (sum % 10)) % 10;
            input += k.ToString();
            string[] special_case = { "7198", "7323", "8573" };
            if (Array.IndexOf(special_case, input.Substring(6, 4)) > -1)
            {
                return string.Format("{0}-{1}-{2}-{3}-{4}", input.Substring(0, 3), input.Substring(3, 3), input.Substring(6, 4), input.Substring(10, 2), input.Substring(12, 1));
            }
            return string.Format("{0}-{1}-{2}-{3}-{4}", input.Substring(0, 3), input.Substring(3, 3), input.Substring(6, 3), input.Substring(9, 3), input.Substring(12, 1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Replace("-", "");
            try
            {
                if (int.Parse(input).ToString().PadLeft(9, '0') != input)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("不正確的格式");
                return;
            }
            textBox2.Text = ISBN10(input);
            textBox3.Text = ISBN13(input);
        }
    }
}
