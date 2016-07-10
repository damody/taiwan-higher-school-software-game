using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_計算徑向多項式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        long level(int k)
        {            
            long v = 1;
            for (int i = 2; i <= k; i++)
                v *= i;
            return v;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R;
            int N;
            try
            {
                if (!double.TryParse(textBox1.Text, out R) || !int.TryParse(textBox2.Text, out N))
                    throw new Exception("輸入的不是合法的數字");
                if (N <= 0)
                    throw new Exception("N必須是正整數");

                for (int M = 0; M <= N; M++)
                {
                    if (((N - Math.Abs(M)) & 1) == 1) continue;
                    if (Math.Abs(M) > N) continue;

                    int n_minus_m_2 = (N - Math.Abs(M)) / 2;
                    int n_add_m_2 = (N + Math.Abs(M)) / 2;
                    double sum = 0;

                    for (int s = 0; s <= n_minus_m_2; s++)
                    {
                        sum +=
                            ((s & 1) == 0 ? 1 : -1) *
                            level(N - s) * Math.Pow(R, N - s * 2) /
                            (level(s) * level(n_add_m_2 - s) * level(n_minus_m_2 - s));
                    }

                    txtResult.Text += String.Format("R = {0}, N = {1}, M = {2}" + Environment.NewLine + "    Result = {3}" + Environment.NewLine, R, N, M, sum);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
