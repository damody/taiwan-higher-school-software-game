using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_點和集合間之鄰近函數
{
    public partial class Form1 : Form
    {
        private const int c = 8;
        Tuple<Label, Tuple<TextBox, TextBox>>[] l = new Tuple<Label, Tuple<TextBox, TextBox>>[c];
        string[,] data = new string[,] { { "1.5", "1.5" }, { "2.0", "1.0" }, { "2.5", "1.75" }, { "1.5", "2.0" }, { "3.0", "2.0" }, { "1.0", "3.5" }, { "2.0", "3.0" }, { "3.5", "3.0" } };
        int Count;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < c; i++)
            {
                l[i] = new Tuple<Label, Tuple<TextBox, TextBox>>(new Label(), new Tuple<TextBox, TextBox>(new TextBox(), new TextBox()));
                l[i].Item1.Text = string.Format("第x{0}點座標", i + 1);
                l[i].Item1.AutoSize = true;
                l[i].Item1.Location = new Point(5, 25 + i * 36);
                l[i].Item2.Item1.Text = data[i, 0];
                l[i].Item2.Item2.Text = data[i, 1];
                l[i].Item2.Item1.Location = new Point(50 +  60, 24 + i * 36);
                l[i].Item2.Item2.Location = new Point(50 + 120, 24 + i * 36);
                l[i].Item2.Item1.Size = new Size(50, 28);
                l[i].Item2.Item2.Size = new Size(50, 28);
                groupBox1.Controls.Add(l[i].Item1);
                groupBox1.Controls.Add(l[i].Item2.Item1);
                groupBox1.Controls.Add(l[i].Item2.Item2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out Count))
            {
                if (Count > 8)
                {
                    Count = 8;
                    textBox1.Text = "8";
                }
                else if (Count < 1)
                {
                    Count = 1;
                    textBox1.Text = "1";
                }
                groupBox1.Text = string.Format("請輸入{0}個點座標：X和Y值", Count);
                groupBox1.Height = 20 + Count * 36;
                groupBox1.Visible = true;
            }
        }

        PointF[] parseData()
        {
            PointF[] pts = new PointF[Count];
            float x, y;
            for (int i = 0; i < Count; i++)
            {
                if (!float.TryParse(l[i].Item2.Item1.Text, out x) || !float.TryParse(l[i].Item2.Item2.Text, out y))
                {
                    MessageBox.Show("輸入資料有誤");
                    return null;
                }
                else if (x < 0 || x > 6 || y < 0 || y > 6)
                {
                    MessageBox.Show(string.Format("第{0}個資料點的資料有誤", i + 1));
                    return null;
                }
                pts[i] = new PointF(x, y);
            }
            return pts;
        }

        bool currPoint(out PointF pt)
        {
            float x, y;
            if (!float.TryParse(textBox5.Text, out x) || !float.TryParse(textBox6.Text, out y))
            {
                MessageBox.Show("輸入資料有誤");
                pt = new PointF();
                return false;
            }
            else if (x < 0 || x > 6 || y < 0 || y > 6)
            {
                MessageBox.Show("輸入資料有誤");
                pt = new PointF();
                return false;
            }
            pt = new PointF(x, y);
            return true;
        }

        double distance(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] pts = parseData();
            PointF pt;
            if (pts == null || !currPoint(out pt))
                return;
            double max = distance(pts[0], pt);
            for (int i = 1; i < Count; i++)
                max = Math.Max(max, distance(pts[i], pt));
            textBox2.Text = max.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointF[] pts = parseData();
            PointF pt;
            if (pts == null || !currPoint(out pt))
                return;
            double min = distance(pts[0], pt);
            for (int i = 1; i < Count; i++)
                min = Math.Min(min, distance(pts[i], pt));
            textBox3.Text = min.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PointF[] pts = parseData();
            PointF pt;
            if (pts == null || !currPoint(out pt))
                return;
            double sum = 0;
            for (int i = 0; i < Count; i++)
                sum += distance(pts[i], pt);
            double avg = sum / Count;
            textBox4.Text = avg.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PointF[] pts = parseData();
            PointF pt;
            if (pts == null || !currPoint(out pt))
                return;

            Bitmap bmp1 = new Bitmap(380, 380), bmp2 = new Bitmap(400, 400);
            Graphics g1 = Graphics.FromImage(bmp1), g2 = Graphics.FromImage(bmp2);
            for (int i = 0; i <= 6; i++)
            {
                g1.DrawLine(Pens.Black, 0, i * 60, 360, i * 60);
                g1.DrawLine(Pens.Black, i * 60, 0, i * 60, 360);
            }
            for (int i = 0; i < Count; i++)
                g1.FillEllipse(Brushes.Blue, pts[i].X * 60 - 4, (6 - pts[i].Y) * 60 - 4, 8, 8);
            g1.FillEllipse(Brushes.Red, pt.X * 60 - 4, (6 - pt.Y) * 60 - 4, 8, 8);

            g2.DrawImage(bmp1, 30, 10);

            for (int i = 0; i <= 6; i++)
            {
                g2.DrawString(i.ToString() + ".0", new Font("Courier New", 8), Brushes.Black, 2, 360 - i * 60);
                g2.DrawString(i.ToString() + ".0", new Font("Courier New", 8), Brushes.Black, 12 + i * 60, 375);
            }

            pictureBox1.Image = bmp2;
        }
    }
}
