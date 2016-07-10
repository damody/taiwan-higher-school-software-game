using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_Sinc訊號繪圖
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double sinc(double x)
        {
            if (x == 0) return 1;
            return Math.Sin(x) / x;
        }

        float Fix5(float x) {
            float k = x % 5;
            if (k == 0)
            {
                return x;
            }
            else if (x > 0)
            {
                return x + (5 - k);
            }
            else
            {
                return x - (5 + k);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const float minY = -0.2f, maxY = 1;
            float minX, maxX;
            Point p1, p2, p3;

            if (!float.TryParse(textBox1.Text, out minX) || !float.TryParse(textBox2.Text, out maxX))
            {
                MessageBox.Show("輸入有誤");
                return;
            }

            float aminX = Fix5(minX * 10) / 10, amaxX = Fix5(maxX * 10) / 10;
            if (aminX > 0) aminX = 0;
            if (amaxX < 0) amaxX = 0;

            AxisPointConverter apc = new AxisPointConverter(new Point(30, 20), new Point(800 - 60, 600 - 40), new PointF(aminX, minY), new PointF(amaxX, maxY));

            Bitmap bmp = new Bitmap(800, 600);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, 799, 599);

            g.DrawLine(Pens.Black, apc.Convert(aminX, 0), apc.Convert(amaxX, 0));
            g.DrawLine(Pens.Black, apc.Convert(0, minY), apc.Convert(0, maxY));
            
            for (float y = -1; y <= 5; y ++)
            {
                p1 = apc.Convert(0, y / 5);
                p2 = new Point(p1.X + 5, p1.Y);
                p3 = new Point(p1.X + 8, p1.Y);
                g.DrawLine(Pens.Black, p1, p2);
                g.DrawString((y / 5).ToString(), this.Font, Brushes.Black, p3);
            }

            float dx = (amaxX - aminX) / 6;
            for (float x = aminX; x < amaxX + dx; x += dx)
            {
                p1 = apc.Convert(x, 0);
                p2 = new Point(p1.X, p1.Y - 5);
                p3 = new Point(p1.X + 8, p1.Y);
                g.DrawLine(Pens.Black, p1, p2);
                g.DrawString(Math.Round(x, 2).ToString(), this.Font, Brushes.Black, p3);
            }

            dx = (maxX - minX) / 500;
            p1 = apc.Convert((float)minX, (float)sinc(minX));
            for (double x = minX + dx; x <= maxX; x += dx)
            {
                p2 = apc.Convert((float)x, (float)sinc(x));
                g.DrawLine(Pens.Red, p1, p2);
                p1 = p2;
            }

            pictureBox1.Image = bmp;
        }
    }

    class AxisPointConverter
    {
        Point LT, RB;
        PointF Min, Max;

        int Scale(int Start, int Length, float Min, float Max, float Value)
        {
            return Start + (int)((Value - Min) * Length / (Max - Min));
        }

        public AxisPointConverter(Point LT, Point RB, PointF Min, PointF Max)
        {
            this.LT = LT;
            this.RB = RB;
            this.Min = Min;
            this.Max = Max;
        }

        public Point Convert(float x, float y)
        {
            return new Point(
                Scale(LT.X, RB.X - LT.X, Min.X, Max.X, x),
                Scale(RB.Y, -(RB.Y - LT.Y), Min.Y, Max.Y, y)
            );
        }
    }
}
