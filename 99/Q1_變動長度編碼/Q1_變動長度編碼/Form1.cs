using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_變動長度編碼
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            char[] output = new string('0', 40).ToCharArray();
            int c1 = 4;
            while (c1 > 0)
            {
                int i = rnd.Next(0, 40);
                if (output[i] == '0')
                {
                    output[i] = '1';
                    c1--;
                }
            }
            textBox1.Text = new string(output);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            List<string> output = new List<string>();
            if (input.Length > 0)
            {
                int i = 0, last = 0;
                while (i <= input.Length)
                {
                    if (i == input.Length)
                    {
                        if (input[i - 1] == '0')
                            output.Add(Convert.ToString(i - last, 2));
                        break;
                    }
                    if (input[i] == '1')
                    {
                        output.Add(Convert.ToString(i - last, 2));
                        last = i + 1;
                    }
                    i++;
                }

                if (input[input.Length - 1] == '1') output.Add("0");

                textBox2.Text = string.Join(" ", output);
                label4.Text = ((double)textBox2.Text.Length * 100 / textBox1.Text.Length).ToString() + "%";
            }
        }
    }
}
