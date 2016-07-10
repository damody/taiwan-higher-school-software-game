using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_交易趨勢分析預測及買賣建議
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string JoinFromDouble(double[] arr)
        {
            string[] data = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                data[i] = Math.Round(arr[i], 2).ToString();
            return string.Join(" ", data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] inp = textBox1.Text.Split(" ".ToCharArray());
            double[] data = new double[inp.Length];
            double[] avg5 = new double[inp.Length - 19];
            double[] avg20 = new double[avg5.Length];
            double[] val = new double[avg5.Length];
            double[] sum = new double[data.Length + 1];
            double[] x = new double[avg5.Length];
            sum[0] = 0;
            for (int i = 0; i < inp.Length; i++)
            {
                sum[i + 1] = data[i] = double.Parse(inp[i]);
                if (i > 0)
                    sum[i + 1] += sum[i];
            }
            for (int i = 19; i < inp.Length; i++)
            {
                avg20[i - 19] = (sum[i + 1] - sum[i + 1 - 20]) / 20;
                avg5[i - 19] = (sum[i + 1] - sum[i + 1 - 5]) / 5;
                x[i - 19] = (data[i - 4] * 4 - data[i - 19]) / 3;
            }
            for (int i = 0; i < val.Length; i++)
                val[i] = avg5[i] - avg20[i];
            textBox2.Text = JoinFromDouble(avg5);
            textBox3.Text = JoinFromDouble(avg20);
            textBox4.Text = JoinFromDouble(val);
            textBox5.Text = JoinFromDouble(x);
        }
    }
}
