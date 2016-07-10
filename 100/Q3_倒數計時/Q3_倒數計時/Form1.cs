using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_倒數計時
{
    public partial class Form1 : Form
    {
        int t;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                t = int.Parse(textBox1.Text) * 60 + int.Parse(textBox2.Text);
                if (t <= 0) throw new Exception();
                textBox1.Enabled = textBox2.Enabled = true;
                timer1.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("錯誤的輸入");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t--;
            textBox1.Text = (t / 60).ToString();
            textBox2.Text = (t % 60).ToString();
            if (t <= 0)
            {
                textBox1.Enabled = textBox2.Enabled = false;
                timer1.Stop();
                MessageBox.Show("時間到");
            }
        }
    }
}
