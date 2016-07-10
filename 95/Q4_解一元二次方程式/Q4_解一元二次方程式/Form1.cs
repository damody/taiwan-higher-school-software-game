using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_解一元二次方程式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c, check, pre;
            try
            {
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);
                c = double.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("輸入有誤");
                return;
            }
            lblFunction.Text = string.Format("{0}x^2 + {1}x + {2}c = 0", a, b, c);
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        textBox4.Text = "無限多解";
                        textBox5.Text = "";
                        return;
                    }
                    else
                    {
                        textBox4.Text = "無解";
                        textBox5.Text = "";
                        return;
                    }
                }
                else
                {
                    check = -c / b;
                    textBox4.Text = "只有一解";
                    textBox5.Text = check.ToString();
                    return;
                }
            }

            pre = -b / 2 / a;
            check = b * b - 4 * a * c;

            if (check > 0)
            {
                check = Math.Sqrt(check) / 2 / a;
                textBox4.Text = Math.Round(pre + check, 2).ToString();
                textBox5.Text = Math.Round(pre - check, 2).ToString();
            }
            else if (check == 0)
            {
                textBox4.Text = "重根";
                textBox5.Text = pre.ToString();
            }
            else
            {
                check = Math.Abs(Math.Sqrt(-check) / 2 / a);
                string chk = Math.Round(check, 2).ToString() + "i";
                textBox4.Text = Math.Round(pre, 2).ToString() + " + " + chk;
                textBox5.Text = Math.Round(pre, 2).ToString() + " - " + chk;
            }
        }
    }
}
