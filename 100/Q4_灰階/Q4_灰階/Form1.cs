using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_灰階
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Image img = Image.FromFile(ofd.FileName);
                pb1.Image = img;
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pb1.Image == null)
                return;
            Bitmap bmp = pb1.Image.Clone() as Bitmap;
            if (bmp == null)
                return;
            int w = bmp.Width, h = bmp.Height, sz = w * h, max = 0, min = 0, most = 0;
            double[] map = new double[256];

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int gray = (c.R * 307 + c.G * 604 + c.B * 112) >> 10;
                    // if (gray > 255) gray = 255;
                    c = Color.FromArgb(gray, gray, gray);
                    map[gray]++;
                    bmp.SetPixel(i, j, c);
                }

            for (int i = 0; i < 256; i++)
                if (map[i] != 0) max = i;
            for (int i = 255; i >= 0; i--)
                if (map[i] != 0) min = i;
            for (int i = 0; i < 256; i++)
                if (map[i] > map[most])
                    most = i;
            pb2.Image = bmp;

            textBox1.Text = string.Format("最小亮度：{0}，最大亮度：{1}，最多次數：{2}，最多次數比率：{3} %", min, max, most, Math.Round(map[most] / sz * 100, 2));

            bmp = new Bitmap(400, 400);
            Graphics g = Graphics.FromImage(bmp);

            Point[] pts;
            g.DrawLines(Pens.Black, new Point[] { new Point(30, 30), new Point(30, 370), new Point(370, 370) });

            pts = new Point[256];
            for (int i = 0; i < 256; i++)
                pts[i] = new Point(50 + i, 370 - (int)(map[i] * 320 / sz));
            g.DrawLines(Pens.Red, pts);

            pictureBox1.Image = bmp;
        }
    }
}
