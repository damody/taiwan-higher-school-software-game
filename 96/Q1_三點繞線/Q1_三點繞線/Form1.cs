using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_三點繞線
{
    public partial class Form1 : Form
    {
        Point[] pts = null;
        Point middleP;
        int n45l;
        int middleY;
        const int R = 3;

        public Form1()
        {
            InitializeComponent();
        }

        void display(string n45, string o45, string sa)
        {
            textBox1.Text = string.Format("Non-45 Length: {0}" + Environment.NewLine +
                                          " On-45 Length: {1}" + Environment.NewLine +
                                          "       Saving: {2}", n45, o45, sa);
        }

        Graphics newImage()
        {
            pictureBox1.Image = new Bitmap(400, 300);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            return g;
        }

        int _sortPointByX(Point x, Point y)
        {
            return Math.Sign(x.X - y.X);
        }

        int _sortPointByY(Point x, Point y)
        {
            return Math.Sign(x.Y - y.Y);
        }

        Point[] SortPointsByX(Point[] data)
        {
            Array.Sort(data, _sortPointByX);
            return data;
        }

        Point[] SortPointsByY(Point[] data)
        {
            Array.Sort(data, _sortPointByY);
            return data;
        }

        bool CheckPts(Point[] pts, int dx, int dy)
        {
            for (int i = 0; i < pts.Length; i++)
                for (int j = i + 1; j < pts.Length; j++)
                    if (Math.Abs(pts[i].X - pts[j].X) < dx || Math.Abs(pts[i].Y - pts[j].Y) < dy)
                        return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pts = new Point[3];
            Graphics g = newImage();
            Random rnd = new Random();
            do
            {
                for (int i = 0; i < 3; i++)
                    pts[i] = new Point(rnd.Next(40, 360), rnd.Next(40, 260));
            } while (!CheckPts(pts, 40, 40));

            SortPointsByY(pts);
            middleP = pts[1];
            g.DrawLine(Pens.Black, pts[0].X, pts[0].Y, pts[0].X, pts[1].Y);
            g.DrawLine(Pens.Black, pts[2].X, pts[2].Y, pts[2].X, pts[1].Y);
            n45l = Math.Abs(pts[0].Y - middleP.Y) + Math.Abs(pts[2].Y - middleP.Y);
            SortPointsByX(pts);
            g.DrawLine(Pens.Black, pts[0].X, middleP.Y, pts[2].X, middleP.Y);
            n45l += Math.Abs(pts[2].X - pts[0].X);

            for (int i = 0; i < 3; i++)
                g.FillEllipse(Brushes.Blue, pts[i].X - R, pts[i].Y - R, R * 2 + 1, R * 2 + 1);

            display(n45l.ToString(), "", "");
        }

        int min3(int x, int y, int z)
        {
            return Math.Min(Math.Min(x, y), z);
        }

        int max3(int x, int y, int z)
        {
            return Math.Max(Math.Max(x, y), z);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pts == null)
                return;
            SortPointsByY(pts);
            Point p0, p2;
            int o45l = 0, dx, dy, d;

            d = pts[1].Y - pts[0].Y;
            dx = Math.Sign(pts[1].X - pts[0].X);
            dy = Math.Sign(d);
            d = Math.Abs(d);
            p0 = new Point(pts[0].X + d * dx, pts[0].Y + d * dy);

            d = pts[1].Y - pts[2].Y;
            dx = Math.Sign(pts[1].X - pts[2].X);
            dy = Math.Sign(d);
            d = Math.Abs(d);
            p2 = new Point(pts[2].X + d * dx, pts[2].Y + d * dy);
            o45l = (int)(
                Math.Sqrt(Math.Pow(p0.X - pts[1].X, 2) + Math.Pow(p0.Y - pts[1].Y, 2)) +
                Math.Sqrt(Math.Pow(p2.X - pts[1].X, 2) + Math.Pow(p2.Y - pts[1].Y, 2))
                );

            int x1 = min3(p0.X, pts[1].X, p2.X);
            int x2 = max3(p0.X, pts[1].X, p2.X);
            o45l += x2 - x1;
            double percentage = (double)(n45l - o45l) / n45l * 100;
            display(n45l.ToString(), o45l.ToString(), Math.Round(percentage, 1).ToString() + "%");

            Graphics g = newImage();

            g.DrawLine(Pens.Black, x1, pts[1].Y, x2, pts[1].Y);
            g.DrawLine(Pens.Black, pts[0], p0);
            g.DrawLine(Pens.Black, pts[2], p2);

            for (int i = 0; i < 3; i++)
                g.FillEllipse(Brushes.Blue, pts[i].X - R, pts[i].Y - R, R * 2 + 1, R * 2 + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display("", "", "");
        }
    }
}
