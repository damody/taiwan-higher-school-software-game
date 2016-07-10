using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Q5_設計一字串搜尋程式
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
                textBox4.Text = File.ReadAllText(textBox1.Text);
                if (textBox2.Text.Length == 0) throw new Exception();
            }
            catch (Exception)
            {
                return;
            }

            string str = textBox4.Text.Replace("\r", "").Replace("\n", "");
            int index = str.IndexOf(textBox2.Text) + 1;

            if (index > 0)
                textBox3.Text = "位置：" + index.ToString();
            else
                textBox3.Text = string.Format("未找到字串 \"{0}\"", textBox2.Text);
        }
    }
}
