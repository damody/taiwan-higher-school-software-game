using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Q6_迷宮遊戲
{
    public partial class Form1 : Form
    {
        int k = 0;

        public Form1()
        {
            InitializeComponent();
        }

        bool go(int x, int y, int[,] map)
        {
            try
            {
                if (map[y, x] != 0) return false;
            }
            catch (Exception) { return false; }
            map[y, x] = 2;
            textBox2.Text += String.Format("({0}, {1}) ", y, x);


            // For Debug
            //Bitmap bmp = new Bitmap(161, 161);
            //Graphics g = Graphics.FromImage(bmp);
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Brush b = Brushes.White;
            //        switch (map[i, j])
            //        {
            //            case 0: b = Brushes.White; break;
            //            case 1: b = Brushes.Gray; break;
            //            case 2:  b = Brushes.Silver; break;
            //        }
            //        if (i == y && j == x) b = Brushes.Red;
            //        g.FillRectangle(b, new Rectangle(new Point(j * 20, i * 20), new Size(20, 20)));
            //    }
            //}

            //for (int i = 0; i < 9; i++)
            //{
            //    g.DrawLine(Pens.Black, i * 20, 0, i * 20, 160);
            //    g.DrawLine(Pens.Black, 0, i * 20, 160, i * 20);
            //}
            //bmp.Save(Path.Combine(Application.StartupPath, (++k).ToString().PadLeft(2, '0') + ".png"), ImageFormat.Png);




            if (x == 7 && y == 7) return true;

            if (go(x,     y - 1, map)) return true;
            if (go(x + 1, y - 1, map)) return true;
            if (go(x + 1, y,     map)) return true;
            if (go(x + 1, y + 1, map)) return true;
            if (go(x,     y + 1, map)) return true;
            if (go(x - 1, y + 1, map)) return true;
            if (go(x - 1, y    , map)) return true;
            if (go(x - 1, y - 1, map)) return true;

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = 0;

            string[] lines;
            int[,] map = new int[8, 8];

            try {
                lines = File.ReadAllLines(textBox1.Text);
                if (lines.Length != 8) throw new Exception();
                for (int i = 0; i < 8; i++ )
                {
                    if (lines[i].Length != 8) throw new Exception();
                    for (int j = 0; j < 8; j++)
                        map[i, j] = (lines[i][j] == '1') ? 1 : 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("檔案讀取時發生錯誤");
                return;
            }

            go(0, 0, map);
        }
    }
}
