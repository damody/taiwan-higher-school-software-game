using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_使用層級分析法選才
{
    public partial class Form1 : Form
    {
        TextBox[] tbs;
        Label[] lbls;
        bool inEvent = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbs = new TextBox[9];
            for (int i = 0; i < 9; i++)
            {
                TextBox box = tbs[i] = new TextBox();
                box.Size = new Size(60, 22);
                box.Location = new Point(50 + i % 3 * 65, 40 + i / 3 * 28);
                box.TextAlign = HorizontalAlignment.Center;
                box.Tag = i;
                if (i / 3 == i % 3)
                {
                    box.Enabled = false;
                    box.Text = "1";
                }
            }
            foreach (int i in new int[] { 3, 6, 7 })
                tbs[i].Enabled = false;
            for (int i = 0; i < 9; i++)
                tbs[i].TextChanged += new EventHandler(boxes_TextChanged);
            this.Controls.AddRange(tbs);
            int j = 0;
            lbls = new Label[6];
            foreach (string l in new string[] { "能力1", "能力2", "能力3" })
            {
                Label lbl1 = new Label(), lbl2 = new Label();
                lbl1.Location = new Point(60 + j * 65, 10);
                lbl2.Location = new Point(5, 45 + j * 28);
                lbl1.Text = lbl2.Text = l;
                lbl1.AutoSize = lbl2.AutoSize = true;
                this.Controls.Add(lbl1);
                this.Controls.Add(lbl2);
                lbls[j] = lbl1;
                lbls[j + 3] = lbl2;
                j++;
            }
        }

        int p2i(int x, int y)
        {
            return x + y * 3;
        }

        int p2i(Point pt)
        {
            return p2i(pt.X, pt.Y);
        }

        Point i2p(int i)
        {
            return new Point(i % 3, i / 3);
        }

        void boxes_TextChanged(object sender, EventArgs e)
        {
            if (inEvent) return;
            inEvent = true;
            int index = (int)(((TextBox)sender).Tag), t;
            switch (index)
            {
                case 1: t = 3; break;
                case 2: t = 6; break;
                case 5: t = 7; break;
                default: t = -1; break;
            }
            try { double v = double.Parse(tbs[index].Text); tbs[t].Text = (1 / v).ToString(); tbs[index].ForeColor = Color.Black; }
            catch (FormatException) { tbs[index].ForeColor = Color.Red; }
            inEvent = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double lambda_max = 0, CR = 0;
                double[] arr = new double[9], w = new double[3];
                double[,] a = new double[3, 3], b = new double[3, 3];

                for (int i = 0; i < 9; i++)
                    if (!double.TryParse(tbs[i].Text, out arr[i]))
                        throw new Exception("輸入的數值有誤");
                Buffer.BlockCopy(arr, 0, a, 0, 9 * sizeof(double));
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        b[i, j] = a[i, j] / (a[0, j] + a[1, j] + a[2, j]);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        w[i] += b[i, j] / 3;
                for (int j = 0; j < 3; j++)
                    for (int i = 0; i < 3; i++)
                        lambda_max += w[j] * a[i, j];
                CR = (lambda_max - 3) / 2 / 0.58;

                string output = "";

                for (int i = 0; i < 3; i++)
                    output += string.Format("w[{0}] = {1}\r\n", i, w[i]);
                output += "\r\n\r\n";
                output += string.Format("Lambda max = {0}\r\nCR = {1}\r\n", lambda_max, CR);
                output += CR < 0.1 ? "CR 小於 0.1，符合一致性" : "CR 超過 0.1，不符合一致性";

                textBox1.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
