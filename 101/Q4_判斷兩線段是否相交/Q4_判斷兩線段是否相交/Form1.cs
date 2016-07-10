using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_判斷兩線段是否相交
{
    public partial class Form1 : Form
    {
        PointF[] pts;
        TextBox[] input;

        public Form1()
        {
            InitializeComponent();
            pts = new PointF[4];
            for (int i = 0; i < 4; i++)
                pts[i] = new Point();
            input = new TextBox[] { textBox1, textBox2, textBox3, textBox4 };

            string[] txt = new string[] { "10, 20", "30, 40", "30, 20", "10, 10" };
            for (int i = 0; i < 4; i++) input[i].Text = txt[i];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] pts_tmp = new PointF[4];
            for (int i = 0; i < 4; i++)
            {
                float x = 0, y = 0;
                string[] txt = input[i].Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (!float.TryParse(txt[0], out x) || !float.TryParse(txt[1], out y))
                {
                    MessageBox.Show("錯誤的輸入", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pts_tmp[i] = new PointF(x, y);
            }
            Array.Copy(pts_tmp, pts, 4);
            panel1.Invalidate();

            {
                bool L1v = false, L2v = false;
                double m1 = 0, m2 = 0, k1, k2, x, y;
                if (pts[0].X - pts[1].X == 0) L1v = true;
                else m1 = (double)(pts[0].Y - pts[1].Y) / (pts[0].X - pts[1].X);
                if (pts[2].X - pts[3].X == 0) L2v = true;
                else m2 = (double)(pts[2].Y - pts[3].Y) / (pts[2].X - pts[3].X);
                if (m1 == m2 || (L1v && L2v))
                {
                    textBox5.Text = "沒有交集，沒有交點";
                }
                else if (L1v)
                {
                    k2 = pts[2].Y - m2 * pts[2].X;

                    x = pts[0].X;
                    y = m2 * x + k2;

                    textBox5.Text = String.Format("交點在：({0}, {1})", x, y);

                    float minX = Math.Min(pts[2].X, pts[3].X), maxX = Math.Max(pts[2].X, pts[3].X);
                    if (minX <= x && x <= maxX)
                    {
                        textBox5.Text = "有交集，" + textBox5.Text;
                    }
                    else
                    {
                        textBox5.Text = "沒有交集"; //，" + textBox5.Text;
                    }
                }
                else if (L2v)
                {
                    k1 = pts[0].Y - m1 * pts[0].X;

                    x = pts[2].X;
                    y = m1 * x + k1;

                    textBox5.Text = String.Format("交點在：({0}, {1})", x, y);

                    float minX = Math.Min(pts[0].X, pts[1].X), maxX = Math.Max(pts[0].X, pts[1].X);
                    if (minX <= x && x <= maxX)
                    {
                        textBox5.Text = "有交集，" + textBox5.Text;
                    }
                    else
                    {
                        textBox5.Text = "沒有交集"; //，" + textBox5.Text;
                    }
                }
                else
                {
                    k1 = pts[0].Y - m1 * pts[0].X;
                    k2 = pts[2].Y - m2 * pts[2].X;
                    x = -(k1 - k2) / (m1 - m2);
                    y = x * m1 + k1;
                    textBox5.Text = String.Format("交點在：({0}, {1})", x, y);
                    float minX1 = Math.Min(pts[0].X, pts[1].X),
                          minX2 = Math.Min(pts[2].X, pts[3].X),
                          minY1 = Math.Min(pts[0].Y, pts[1].Y),
                          minY2 = Math.Min(pts[2].Y, pts[3].Y),
                          maxX1 = Math.Max(pts[0].X, pts[1].X),
                          maxX2 = Math.Max(pts[2].X, pts[3].X),
                          maxY1 = Math.Max(pts[0].Y, pts[1].Y),
                          maxY2 = Math.Max(pts[2].Y, pts[3].Y);
                    float minX = Math.Max(minX1, minX2),
                          minY = Math.Max(minY1, minY2),
                          maxX = Math.Min(maxX1, maxX2),
                          maxY = Math.Min(maxY1, maxY2);
                    if (minX <= x && x <= maxX && minY <= y && y <= maxY)
                    {
                        textBox5.Text = "有交集，" + textBox5.Text;
                    }
                    else
                    {
                        textBox5.Text = "沒有交集"; //，" + textBox5.Text;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                pts[i] = new PointF();
            panel1.Invalidate();
        }

        Point fixPoint(Point source, int offsetX = 0, int offsetY = 0, int minX = -40, int minY = -40, int maxX = 40, int maxY = 40, int x = 70, int y = 70, int width = 660, int height = 460)
        {
            return new Point(
                x + (source.X - minX) * width / (maxX - minX) + offsetX,
                y + height - ((source.Y - minY) * height / (maxY - minY)) + offsetY
            );
        }

        Point fixPoint(PointF source, int offsetX = 0, int offsetY = 0, int minX = -40, int minY = -40, int maxX = 40, int maxY = 40, int x = 70, int y = 70, int width = 660, int height = 460)
        {
            return new Point(
                (int)(x + (source.X - minX) * width / (maxX - minX) + offsetX),
                (int)(y + height - ((source.Y - minY) * height / (maxY - minY)) + offsetY)
            );
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penLine = new Pen(new SolidBrush(Color.FromArgb(0x33, 0x33, 0x33)), 1);
            g.Clear(Color.White);

            g.DrawLine(penLine, 70, 300, 730, 300);
            g.DrawLine(penLine, 400, 70, 400, 530);

            for (int x = -40; x <= 40; x += 5)
            {
                g.DrawLine(penLine, fixPoint(new Point(x, 0), 0, -5)
                    , fixPoint(new Point(x, 0), 0, 5));
                if (x % 10 == 0)
                {
                    g.FillEllipse(Brushes.Black, new Rectangle(fixPoint(new Point(x, 0), -3, -3), new Size(6, 6)));
                    g.DrawString(String.Format("({0}, {1})", x, 0), new Font("微軟正黑體", 8), Brushes.Gray, fixPoint(new Point(x, 0), 3, 5));
                }
            }

            for (int y = -40; y <= 40; y += 5)
            {
                g.DrawLine(penLine, fixPoint(new Point(0, y), 0, -5)
                    , fixPoint(new Point(0, y), 0, 5));
                if (y % 10 == 0)
                {
                    g.FillEllipse(Brushes.Black, new Rectangle(fixPoint(new Point(0, y), -3, -3), new Size(6, 6)));
                    g.DrawString(String.Format("({0}, {1})", 0, y), new Font("微軟正黑體", 8), Brushes.Gray, fixPoint(new Point(0, y), 3, 5));
                }
            }

            g.DrawLine(Pens.Black, fixPoint(pts[0]), fixPoint(pts[1]));
            g.DrawLine(Pens.Black, fixPoint(pts[2]), fixPoint(pts[3]));
        }
    }
}
