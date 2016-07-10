using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Q5_股票投資
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] parseLine(string line)
        {
            var items = line.Split(' ');
            var data = new double[items.Length];
            for (int i = 0; i < data.Length; i++)
                data[i] = double.Parse(items[i]);
            return data;
        }

        delegate double Func(double x, double y);

        double funcIn(Func func, double[] arr, int index, int count)
        {
            double m = arr[0];
            for (int i = 1; i < count; i++)
                m = func(m, arr[index + i]);
            return m;
        }

        double maxIn(double[] arr, int index, int count)
        {
            return funcIn(Math.Max, arr, index, count);
        }

        double minIn(double[] arr, int index, int count)
        {
            return funcIn(Math.Min, arr, index, count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(textBox1.Text);
            double[] hi = parseLine(lines[0]), lo = parseLine(lines[1]), final = parseLine(lines[2]);
            double[,] kd = new double[2, hi.Length - 7];
            kd[0, 0] = double.Parse(textBox3.Text);
            kd[1, 0] = double.Parse(textBox4.Text);
            string outk = "", outd = "", k, d;
            for (int i = 1; i < hi.Length - 7; i++)
            {
                double h = maxIn(hi, i - 1, 9);
                double l = minIn(lo, i - 1, 9);
                double RSV = (final[i + 7] - l) * 100 / (h - l);
                kd[0, i] = kd[0, i - 1] * 2 / 3 + RSV / 3;
                kd[1, i] = kd[1, i - 1] * 2 / 3 + kd[0, i] / 3;
                k = kd[0, i].ToString() + ".00";
                k = k.Substring(0, k.IndexOf('.') + 3);
                d = kd[1, i].ToString() + ".00";
                d = d.Substring(0, k.IndexOf('.') + 3);
                outk += " " + k;
                outd += " " + d;
            }
            k = kd[0, 0].ToString() + ".00";
            k = k.Substring(0, k.IndexOf('.') + 3);
            d = kd[1, 0].ToString() + ".00";
            d = d.Substring(0, k.IndexOf('.') + 3);
            outk = k + outk;
            outd = d + outd;
            File.WriteAllText(textBox2.Text, outk + Environment.NewLine + outd);
        }
    }
}
