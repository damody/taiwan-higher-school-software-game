using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q6_SortByFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int _sort(Tuple<char, int> a, Tuple<char, int> b) { return b.Item2 - a.Item2; }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] map = new int[128];
            foreach (char ch in textBox1.Text)
            {
                int c = (int)ch;
                if (0 <= c && c <= 127)
                {
                    map[c]++;
                }
                else
                {
                    MessageBox.Show("輸入了非ASCII字元");
                    return;
                }
            }
            List<Tuple<char, int>> list = new List<Tuple<char, int>>();
            for (int i = 0x20; i <= 0x7E; i++)
                if (map[i] > 0)
                    list.Add(new Tuple<char, int>((char)i, map[i]));
            Tuple<char, int>[] array = list.ToArray();
            Array.Sort(array, _sort);
            textBox2.Text = "";
            foreach (var i in array)
                textBox2.Text += string.Format("\"{0}\" = {1}; ", i.Item1, i.Item2);
            textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 2);
        }
    }
}
