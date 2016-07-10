using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_動態統計
{
    public partial class Form1 : Form
    {
        List<double> numbers = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        string fmt(double v, int n)
        {
            string[] s = (v.ToString() + ".").Split('.');
            return s[0] + "." + (s[1] + new string('0', n)).Substring(0, n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double input, sum = 0, sum_2 = 0;

            if (!double.TryParse(textBox1.Text, out input))
                return;

            int index = listView1.Items.Count + 1;
            ListViewItem item = listView1.Items.Add(index.ToString());
            item.SubItems.Add(input.ToString());
            numbers.Add(input);

            double s = 0, gm = 1, rmsa, hm = 0;

            for (int i = 0; i < index; i++)
            {
                sum += numbers[i];
                sum_2 += Math.Pow(numbers[i], 2);
                gm *= numbers[i];
                hm += 1 / numbers[i];
            }

            if (index > 1)
                s = Math.Sqrt((index * sum_2 - Math.Pow(sum, 2)) / index / (index - 1));

            gm = Math.Pow(gm, (double)1 / index);
            rmsa = Math.Sqrt(sum_2 / index);
            hm = index / hm;

            item.SubItems.Add(fmt(sum / index, 2));
            item.SubItems.Add(fmt(s, 3));
            item.SubItems.Add(fmt(gm, 3));
            item.SubItems.Add(fmt(rmsa, 3));
            item.SubItems.Add(fmt(hm, 3));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            listView1.Items.Clear();
        }
    }
}
