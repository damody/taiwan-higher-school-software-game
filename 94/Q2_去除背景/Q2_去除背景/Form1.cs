using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_去除背景
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(300, 200);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawString("Click", new Font("Courier New", 24), Brushes.Black, 5, 5);
            pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = pictureBox4.Image = pictureBox5.Image = bmp;
        }

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Application.StartupPath;
                ofd.ShowDialog();
                ((PictureBox)sender).Image = Image.FromFile(ofd.FileName);
            }
            catch (Exception) { }
        }

        private void pictureBox_Gray_Click(object sender, EventArgs e)
        {
            PictureBox source = sender == pictureBox2 ? pictureBox1 : pictureBox3;
            if (source.Image == null)
                return;
            Bitmap bmp = new Bitmap(source.Image);
            for(int i = 0; i < bmp.Height; i++)
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    int g = (c.R + c.G + c.B) / 3;
                    bmp.SetPixel(j, i, Color.FromArgb(g, g, g));
                }
            ((PictureBox)sender).Image = bmp;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp1 = new Bitmap(pictureBox2.Image), bmp2 = new Bitmap(pictureBox4.Image);
                for (int i = 0; i < bmp1.Height; i++)
                    for (int j = 0; j < bmp1.Width; j++)
                    {
                        if (Math.Abs(bmp1.GetPixel(j, i).R - bmp2.GetPixel(j, i).R) < 5)
                        {
                            bmp2.SetPixel(j, i, Color.White);
                        }
                    }
                pictureBox5.Image = bmp2;
            }
            catch (Exception) { }
        }
    }
}
