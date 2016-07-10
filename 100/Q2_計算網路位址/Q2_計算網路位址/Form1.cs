using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Q2_計算網路位址
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fmtIP(uint ip)
        {
            string[] v = new string[4];

            for (int i = 0; i < 4; i++)
                v[i] = ((ip >> ((3 - i) << 3)) & 0xFF).ToString();
            return string.Join(".", v);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inp = txtInput.Text.Trim();
            Regex r = new Regex(@"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\/(\d+)$");
            if (!r.IsMatch(inp))
            {
                MessageBox.Show("不正確的輸入");
                return;
            }
            Match m = r.Match(inp);
            string[] ip = m.Groups[1].Value.Split('.');
            int n = 32 - int.Parse(m.Groups[2].Value);
            if (n < 1 || n > 32)
            {
                MessageBox.Show("不正確的輸入");
                return;
            }
            uint adr = 0;
            for (int i = 0; i < 4; i++)
            {
                uint k = uint.Parse(ip[i]);
                if (k > 255)
                {
                    MessageBox.Show("不正確的輸入");
                    return;
                }
                adr |= k << ((3 - i) << 3);
            }

            uint net = adr >> n;
            net <<= n;
            uint broadcast = 0;
            for (int i = 0; i < n; i++)
                broadcast = (broadcast << 1) | 1;
            broadcast |= net;
            textBox1.Text = fmtIP(net);
            textBox2.Text = fmtIP(broadcast);
            textBox3.Text = (((long)1 << n) - 2).ToString();
        }
    }
}
