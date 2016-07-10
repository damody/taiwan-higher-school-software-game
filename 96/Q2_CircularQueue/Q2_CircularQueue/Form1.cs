using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_CircularQueue
{
    public partial class Form1 : Form
    {
        int[] data = new int[6];
        int index, count = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        void PaintData()
        {
            // 15, 35, 23
            Bitmap bmp = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < data.Length; i++)
                g.DrawRectangle(Pens.Black, 15 + i * 30, 35, 30, 23);
            for (int i = 0; i < count; i++)
            {
                int k = (i + index) % data.Length;
                g.DrawString(data[k].ToString(), this.Font, Brushes.Black, 17 + k * 30, 38);
            }

            this.BackgroundImage = bmp;
        }

        void AddData()
        {
            if (count == data.Length)
            {
                this.Width += data.Length * 30;
                int[] newdata = new int[data.Length * 2];
                for (int i = 0; i < count; i++)
                    newdata[i + index] = data[(i + index) % data.Length];
                data = newdata;
            }
            int t = index + count++;
            t %= data.Length;
            int k = data[t] = rnd.Next(1, 1000);
            txtMsg.Text = "Added " + k.ToString();
            PaintData();
        }

        void RemoveData()
        {
            if (count == 0)
            {
                txtMsg.Text = "Queue is empty";
                return;
            }
            count--;
            int k = data[index];
            index = (index + 1) % data.Length;
            PaintData();
            txtMsg.Text = "Removed " + k.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            index = rnd.Next(0, 6);
            AddData();
            AddData();
            txtMsg.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PaintData();
        }
    }
}
