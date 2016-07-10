using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_整數分割
{
    public partial class Form1 : Form
    {
        int error_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "***")
            {
                error_count = 0;
                label2.Text = "";
                return;
            }
            if (error_count >= 3)
            {
                label2.Text = "輸入超過3次";
                return;
            }
            try
            {
                int N = int.Parse(textBox1.Text);
                label2.Text = "";
                textBox2.Text = "";
                for (int i = N; i >= 1; i--)
                {
                    textBox2.Text += i.ToString() + " ";
                    for (int j = 0; j < N - i; j++)
                        textBox2.Text += "1 ";
                    textBox2.Text += Environment.NewLine;
                }
            }
            catch (Exception)
            {
                error_count++;
                label2.Text = "輸入錯誤";
            }
        }
    }
}
