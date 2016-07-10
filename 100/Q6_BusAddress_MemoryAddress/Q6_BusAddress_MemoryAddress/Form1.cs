using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Q6_BusAddress_MemoryAddress
{
    public partial class Form1 : Form
    {
        private const long KB = 1024;
        private const long MB = KB * 1024;
        private const long GB = MB * 1024;
        private const long TB = GB * 1024;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        string formatSize(long sz)
        {
            if (sz > TB) return ((double)sz / TB).ToString() + "TB";
            if (sz > GB) return ((double)sz / GB).ToString() + "GB";
            if (sz > MB) return ((double)sz / MB).ToString() + "MB";
            if (sz > KB) return ((double)sz / KB).ToString() + "KB";
            return sz.ToString() + "B";
        }

        long parseSize(string str)
        {
            str = str.ToLower();
            Regex regSZ = new Regex(@"^(\d+\.?\d*)([kmgt]?)b$");
            if (!regSZ.IsMatch(str))
                return -1;
            Match match = regSZ.Match(str);
            double number = double.Parse(match.Groups[1].Value);
            string szStr = match.Groups[2].Value;
            long mul = 1;
            switch (szStr)
            {
                case "k": mul = KB; break;
                case "m": mul = MB; break;
                case "g": mul = GB; break;
                case "t": mul = TB; break;
            }
            return (long)(number * mul);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = rnd.Next(16, 53).ToString();
            textBox2.Text = rnd.Next(1, 9).ToString();
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bus, bpa;
            if (int.TryParse(textBox1.Text, out bus) && int.TryParse(textBox2.Text, out bpa))
            {
                long n = ((long)1 << bus) * bpa;
                textBox3.Text = formatSize(n);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int bpa;
            if (int.TryParse(textBox5.Text, out bpa))
            {
                long sz = parseSize(textBox6.Text);
                int bus = 0;
                while (((long)1 << bus) * bpa < sz)
                    bus++;
                textBox4.Text = bus.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = rnd.Next(1, 9).ToString();
            textBox6.Text = formatSize((long)rnd.Next() << 21 | rnd.Next());
        }
    }
}
