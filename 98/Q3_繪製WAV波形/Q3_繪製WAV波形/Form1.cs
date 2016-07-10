using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_繪製WAV波形
{
    public partial class Form1 : Form
    {
        int max, curr;
        double time;
        Image img = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wav files|*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs;
            try
            { fs = File.OpenRead(txtFile.Text); }
            catch (Exception)
            { MessageBox.Show("無法開啟檔案"); return; }
            byte[] buffer;
            
            buffer = new byte[4];
            fs.Read(buffer, 0, 4);
            if (Encoding.ASCII.GetString(buffer) != "RIFF")
            { MessageBox.Show("非RIFF檔案"); return; }
            buffer = new byte[7];
            fs.Seek(0x08, SeekOrigin.Begin);
            fs.Read(buffer, 0, 7);
            if (Encoding.ASCII.GetString(buffer) != "WAVEfmt")
            { MessageBox.Show("非WAVE格式"); return; }
            fs.Seek(0x14, SeekOrigin.Begin);
            fs.Read(buffer, 0, 2);
            if (buffer[0] != 1 || buffer[1] != 0)
            { MessageBox.Show("非PCM格式"); return; }
            fs.Read(buffer, 0, 2);
            if (buffer[0] != 1 || buffer[1] != 0)
            { MessageBox.Show("非單聲道"); return; }
            fs.Read(buffer, 0, 4);
            // samples per second
            int sps = BitConverter.ToInt32(buffer, 0);
            fs.Seek(0x22, SeekOrigin.Begin);
            fs.Read(buffer, 0, 2);
            // bits per sample
            int bps = BitConverter.ToInt16(buffer, 0);
            if (bps != 8)
            { MessageBox.Show("非8位元"); return; }
            buffer = new byte[4];
            fs.Seek(0x24, SeekOrigin.Begin);
            fs.Read(buffer, 0, 4);
            if (Encoding.ASCII.GetString(buffer) != "data")
            { MessageBox.Show("檔案格式有誤"); return; }
            fs.Read(buffer, 0, 4);
            // number of samples
            int nos = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[nos];
            fs.Read(buffer, 0, nos);

            img = new Bitmap(nos, 300);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.DarkBlue);

            for(int i = 0; i < nos; i++)
            {
                int v = buffer[i];
                if (v >= 0x80)
                    v -= 0x80;
                else
                    v = 0x7F - v;
                g.DrawLine(Pens.Green, i, 150 - v, i, 150 + v);
            }

            hScrollBar1.Maximum = max = nos - 600;
            hScrollBar1.Value = curr = 0;
            time = (double)nos / sps;
            hScrollBar1_Scroll(null, null);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (img != null)
            {
                curr = hScrollBar1.Value;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.DrawImage(img, -curr, 0);
                lblStatus.Text = string.Format("時間長度：{0}秒，目前位置：{1}秒", Math.Round(time, 5), Math.Round(time * curr / max, 5));
            }
        }
    }
}
