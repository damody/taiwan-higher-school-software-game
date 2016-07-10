using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Q1_畫線乘法
{
    public partial class Form1 : Form
    {
        readonly Color COLOR_1 = Color.Red;
        readonly Color COLOR_2 = Color.Blue;
        bool paint = false;
        int a, b;

        public Form1()
        {
            InitializeComponent();
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            const int cx = 400, cy = 300, dist = 12, delta = 150;
            int sx, sy;

            Graphics g = e.Graphics;
            g.Clear(pb.BackColor);

            if (paint)
            {

                int a1 = a / 10, a2 = a % 10, b1 = b / 10, b2 = b % 10;
                if (a1 > 0)
                {
                    sx = cx - 40; sy = cy - 40;
                    Pen p = new Pen(COLOR_1, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    for (int i = 0; i < a1; i++)
                    {
                        g.DrawLine(p, sx + delta, sy - delta, sx - delta, sy + delta);
                        sx -= dist; sy -= dist;
                    }
                }
                else
                {
                    Pen p = new Pen(COLOR_1, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round, DashStyle = DashStyle.Dash, DashCap = DashCap.Round };
                    sx = cx - 40; sy = cy - 40;
                    g.DrawLine(p, sx + delta, sy - delta, sx - delta, sy + delta);
                }
                if (a2 > 0)
                {
                    sx = cx + 40; sy = cy + 40;
                    Pen p = new Pen(COLOR_1, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    for (int i = 0; i < a2; i++)
                    {
                        g.DrawLine(p, sx - delta, sy + delta, sx + delta, sy - delta);
                        sx += dist; sy += dist;
                    }
                }
                else
                {
                    Pen p = new Pen(COLOR_1, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round, DashStyle = DashStyle.Dash, DashCap = DashCap.Round };
                    sx = cx + 40; sy = cy + 40;
                    g.DrawLine(p, sx - delta, sy + delta, sx + delta, sy - delta);
                }
                if (b1 > 0)
                {
                    sx = cx - 40; sy = cy + 40;
                    Pen p = new Pen(COLOR_2, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    for (int i = 0; i < b1; i++)
                    {
                        g.DrawLine(p, sx + delta, sy + delta, sx - delta, sy - delta);
                        sx -= dist; sy += dist;
                    }
                }
                else
                {
                    Pen p = new Pen(COLOR_2, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round, DashStyle = DashStyle.Dash, DashCap = DashCap.Round };
                    sx = cx - 40; sy = cy + 40;
                    g.DrawLine(p, sx + delta, sy + delta, sx - delta, sy - delta);
                }
                if (b2 > 0)
                {
                    sx = cx + 40; sy = cy - 40;
                    Pen p = new Pen(COLOR_2, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    for (int i = 0; i < b2; i++)
                    {
                        g.DrawLine(p, sx - delta, sy - delta, sx + delta, sy + delta);
                        sx += dist; sy -= dist;
                    }
                }
                else
                {
                    Pen p = new Pen(COLOR_2, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round, DashStyle = DashStyle.Dash, DashCap = DashCap.Round };
                    sx = cx + 40; sy = cy - 40;
                    g.DrawLine(p, sx - delta, sy - delta, sx + delta, sy + delta);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = int.Parse(textBox1.Text);
                b = int.Parse(textBox2.Text);
                if (a < 0 || a > 50 || b < 0 || b > 50) throw new Exception();
                paint = true;
            }
            catch (Exception)
            {
                paint = false;
                MessageBox.Show("輸入錯誤");
            }
            pb.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint = false;
            pb.Invalidate();
        }
    }
}
