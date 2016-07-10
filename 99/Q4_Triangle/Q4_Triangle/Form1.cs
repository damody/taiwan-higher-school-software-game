using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_Triangle
{
    public partial class Form1 : Form
    {
        bool UpSideDown = false, Empty = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpSideDown = false;
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpSideDown = true;
            Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Empty = !Empty;
            Draw();
        }

        void Draw()
        {
            int n;

            if (!int.TryParse(textBox2.Text, out n)) return;
            if (n < 5 || n > 9 || ((n & 1) == 0)) return;

            List<string> rows = new List<string>();

            for (int i = 1; i <= n; i += 2)
            {
                rows.Add(new string('　', (n - i) / 2) + (Empty && i < n && i > 1 ?
                    '＊' + new string('　', i - 2) + '＊' :
                    new string('＊', i)
                ));
            }

            if (UpSideDown) rows.Reverse();

            textBox1.Text = string.Join("\r\n", rows);
        }
    }
}
