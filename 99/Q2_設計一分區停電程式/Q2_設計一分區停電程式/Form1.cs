using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_設計一分區停電程式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, m, j, c, k, l;
            if (!int.TryParse(textBox1.Text, out n) || (n < 13 || n > 99))
            {
                MessageBox.Show("錯誤的輸入");
                return;
            }
            for (m = 1; m <= n; m++)
            {
                c = n;
                List<int> list = new List<int>();
                for (j = 0; j <= 1000; j++)
                    list.Add(1);
                j = 1;
                while (true)
                {
                    list[j] = 0; c--;
                    if (c <= 0) break;
                    k = m;
                    while (k > 0)
                    {
                        j++;
                        if (list[j] == 1)
                            k--;
                        if (j > n)
                            for (l = 2; l <= n; l++)
                                if (list[l] == 1)
                                {
                                    j = l;
                                    break;
                                }
                    }
                }                
                if (j == 13)
                {
                    lblResult.Text = m.ToString();
                    break;
                }
            }
        }
    }
}
