using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_PaintSinAndCos
{
    public partial class Form1 : Form
    {
        delegate double DrawFunction(double x);
        DrawFunction drawFunction = Math.Sin;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                bmp.SetPixel(i, 150, Color.Blue);
                bmp.SetPixel(i, 150 - (int)(drawFunction((double)i / 100) * 100), Color.Blue);
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            drawFunction = Math.Sin;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            drawFunction = Math.Cos;
        }
    }
}
