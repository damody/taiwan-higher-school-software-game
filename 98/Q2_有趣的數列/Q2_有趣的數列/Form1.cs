using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_有趣的數列
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string R(string str, int m)
        {
            if (m == 0) return str;

            List<Pair<char, int>> l = new List<Pair<char, int>>();
            Pair<char, int> last = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (last != null && last.Item1 == str[i])
                {
                    last.Item2++;
                }
                else
                {
                    last = new Pair<char, int>(str[i], 1);
                    l.Add(last);
                }
            }
            str = "";
            for (int i = 0; i < l.Count; i++)
                str += l[i].Item2.ToString() + l[i].Item1;

            return R(str, m-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k;
            if (int.TryParse(textBox1.Text, out k))
            {
                string output = "";
                for (int i = 0; i <= k; i++)
                    output += R("1", i) + "\r\n";
                textBox2.Text = output;
            }
            else
            {
                textBox2.Text = "錯誤的輸入";
            }
        }
    }

    class Pair<T1, T2>
    {
        public T1 Item1;
        public T2 Item2;

        public Pair(T1 t1, T2 t2)
        {
            Item1 = t1;
            Item2 = t2;
        }
    }
}
