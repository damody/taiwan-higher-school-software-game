using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_正N邊形
{
    public partial class Form1 : Form
    {
        int n;
        Color[] Colors = new Color[] { Color.Black, Color.Red, Color.Green, Color.Blue };
        Color cl = Color.Black;
        Point[] pts = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            numericUpDown1_ValueChanged(null, null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (pts == null) return;

            Graphics g = e.Graphics;
            g.Clear(panel1.BackColor);
            Pen p = new Pen(cl);

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    g.DrawLine(p, pts[i], pts[j]);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // R = 380
            // r = 190

            n = (int)numericUpDown1.Value;
            pts = new Point[n];
            double ang = Math.PI * 2 / n;
            for (int i = 0; i < n; i++)
            {
                pts[i] = new Point(
                    200 + (int)(Math.Cos(Math.PI * 3 / 2 + ang * i) * 190),
                    200 + (int)(Math.Sin(Math.PI * 3 / 2 + ang * i) * 190)
                );
            }
            panel1.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cl = Colors[comboBox1.SelectedIndex];
            panel1.Invalidate();
        }
    }
}
