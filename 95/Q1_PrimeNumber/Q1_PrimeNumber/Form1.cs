using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_PrimeNumber
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
                int N = int.Parse(textBox1.Text);
                List<int> list = new List<int>();
                list.Add(2);
                for (int i = 3; i <= N; i += 2)
                {
                    bool isPrime = true;
                    foreach (var n in list)
                    {
                        if (i % n == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        list.Add(i);
                }
                if (N < 2)
                {
                    textBox2.Text = "小於等於 " + N.ToString() + " 的質數有 0 個";
                }
                else if (list.Count < 3)
                {
                    textBox2.Text = "小於等於 " + N.ToString() + " 的質數有 " + list.Count.ToString() + " 個\r\n";
                    textBox2.Text += "最大的 " + list.Count.ToString() + " 個分別是：";
                    foreach (var n in list)
                        textBox2.Text += " " + n.ToString();
                }
                else
                {
                    textBox2.Text = "小於等於 " + N.ToString() + " 的質數有 " + list.Count.ToString() + " 個\r\n";
                    textBox2.Text += "最大的 3 個分別是：";
                    for (int i = list.Count - 3; i < list.Count; i++)
                        textBox2.Text += " " + list[i].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("輸入有誤");
                return;
            }
        }
    }
}
