using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_線性回歸
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PointF> list = new List<PointF>();
            string[] lines = textBox1.Text.Split('\n');
            float sum_x = 0, sum_x_2 = 0, sum_y = 0, sum_xy = 0;
            float minx = float.MaxValue, miny = float.MaxValue, maxx = float.MinValue, maxy = float.MinValue;
            foreach (string l in lines)
            {
                try
                {
                    string[] items = l.Split(' ');
                    float x = float.Parse(items[0]);
                    float y = float.Parse(items[1]);
                    sum_x += x;
                    sum_x_2 += x * x;
                    sum_y += y;
                    sum_xy += x * y;
                    minx = Math.Min(minx, x);
                    miny = Math.Min(miny, y);
                    maxx = Math.Max(maxx, x);
                    maxy = Math.Max(maxy, y);
                    list.Add(new PointF(x, y));
                }
                catch (Exception)
                {
                    MessageBox.Show("輸入資料有誤");
                    return;
                }
            }
            float avg_x = sum_x / list.Count;
            float avg_y = sum_y / list.Count;
            float m = (sum_xy - sum_x * avg_y) / (sum_x_2 - sum_x * avg_x);
            float c = avg_y - m * avg_x;
            float w = maxx - minx;
            float h = maxy - miny;
            miny -= h / 12;
            maxy += h / 12;
            minx -= w / 12;
            maxx += w / 12;
            w = maxx - minx;
            h = maxy - miny;

            const int W = 750;
            const int H = 550;
            Bitmap inner = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(inner);
            g.Clear(Color.White);
            CalcPoint cp = new CalcPoint(minx, miny, maxx, maxy, W, H);
            g.DrawLine(Pens.Red, cp.Calculate(minx, m * minx + c), cp.Calculate(maxx, m * maxx + c));
            foreach (PointF p in list)
                g.DrawEllipse(Pens.Blue, new Rectangle(cp.Calculate(p.X, p.Y, -2, -2), new Size(4, 4)));

            Bitmap outer = new Bitmap(W + 50, H + 50);
            g = Graphics.FromImage(outer);
            g.DrawImage(inner, 50, 0);
            g.DrawLine(Pens.Black, 50, 0, 50, H);
            g.DrawLine(Pens.Black, 50, H, W + 50, H);

            float dx = w / 12;
            float dy = h / 10;

            for (float x = minx; x < maxx; x += dx)
            {
                g.DrawLine(Pens.Black, cp.Calculate(x, 0).X + 50, H - 4, cp.Calculate(x, 0).X + 50, H + 4);
                g.DrawString(Math.Round(x, 2).ToString(), new Font("Courier New", 12, GraphicsUnit.Point), Brushes.Black, cp.Calculate(x, 0).X + 50, H);
            }
            for (float y = miny; y < maxy; y += dy)
            {
                g.DrawLine(Pens.Black, 46, cp.Calculate(0, y).Y, 54, cp.Calculate(0, y).Y);
                g.DrawString(Math.Round(y, 2).ToString(), new Font("Courier New", 12, GraphicsUnit.Point), Brushes.Black, 0, cp.Calculate(0, y).Y);
            }

            inner = outer;
            outer = new Bitmap(820, 620);
            g = Graphics.FromImage(outer);
            g.DrawImage(inner, 20, 0);
            g.DrawString("y", this.Font, Brushes.Black, 0, 300);
            g.DrawString("x", this.Font, Brushes.Black, 410, 600);
            g.DrawImage(Properties.Resources.label, 820 - 120, 5);

            pictureBox1.Image = outer;

            label2.Text = string.Format("斜率 m = {0}, 截距 b = {1}", Math.Round(m, 3), Math.Round(c, 3));
        }

        public class CalcPoint
        {
            float minX, minY, maxX, maxY;
            int w, h;

            public CalcPoint(float minX, float minY, float maxX, float maxY, int w, int h)
            {
                this.minX = minX;
                this.minY = minY;
                this.maxX = maxX;
                this.maxY = maxY;
                this.w = w;
                this.h = h;
            }

            public Point Calculate(float x, float y, int ox, int oy)
            {
                return new Point(
                    ox + (int)((x - minX) * w / (maxX - minX)),
                    oy + (int)(h - (y - minY) * h / (maxY - minY))
                );
            }

            public Point Calculate(float x, float y)
            {
                return this.Calculate(x, y, 0, 0);
            }
        }
    }
}
