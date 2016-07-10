using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_象棋馬走法
{
    public partial class Form1 : Form
    {
        const string WideNumber = "０１２３４５６７８９";
        const string WideSpace  = "　";
        const string WideState  = "　★馬";
        const string WideGrid   = "─┼│";
        int[,] map = new int[8, 8];
        int X, Y;

        public Form1()
        {
            InitializeComponent();
        }

        void PaintMap()
        {
            textBox1.Text = WideSpace + WideGrid[2] + WideNumber.Substring(1, 8) + "\r\n" + WideGrid.Substring(0, 2) + "────────\r\n";
            for (int i = 0; i < 8; i++)
            {
                textBox1.Text += WideNumber[i + 1] + WideGrid.Substring(2);
                for (int j = 0; j < 8; j++)
                {
                    textBox1.Text += WideState[map[i, j]];
                }
                textBox1.Text += "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = textBox2.Text.Split(' ');
            map = new int[8, 8];
            try
            {
                int y = int.Parse(data[0]) - 1, x = int.Parse(data[1]) - 1;
                map[y, x] = 2;
                X = x; Y = y;
                for (int i = 2; i < data.Length; )
                {
                    y = int.Parse(data[i++]) - 1;
                    x = int.Parse(data[i++]) - 1;
                    map[y, x] = 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("輸入資料有誤");
                return;
            }
            PaintMap();
        }

        int getBlock(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 8 || y >= 8)
                return -1;
            return map[y, x];
        }

        void Move(int dx, int dy)
        {
            // -1 -> x
            // 1 -> y
            int ld = Math.Abs(dy) - Math.Abs(dx);
            int ldl = (ld == -1 ? dx : dy) / 2;
            int b = (ld == -1) ? getBlock(X + ldl, Y) : getBlock(X, Y + ldl);
            string output;
            if (getBlock(X + dx, Y + dy) == -1)
            {
                output = string.Format("馬移動至 ({1}, {0})", X + 1, Y + 1) + " (超出棋盤)";
            }
            else if (b == 1)
            {
                output = string.Format("馬移動至 ({1}, {0})", X + 1, Y + 1) + " (拐馬腳)";
            }
            else
            {
                map[Y, X] = 0;
                X += dx;
                Y += dy;
                map[Y, X] = 2;
                output = string.Format("馬移動至 ({1}, {0})", X + 1, Y + 1);
            }
            lblState.Text = output;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ('0' <= e.KeyChar && e.KeyChar <= '9')
            {
                int i = e.KeyChar - '0';
                switch (i)
                {
                    case 0:
                        Move(2, 1);
                        break;
                    case 1:
                        Move(2, -1);
                        break;
                    case 2:
                        Move(1, -2);
                        break;
                    case 3:
                        Move(-1, -2);
                        break;
                    case 4:
                        Move(-2, -1);
                        break;
                    case 5:
                        Move(-2, 1);
                        break;
                    case 6:
                        Move(-1, 2);
                        break;
                    case 7:
                        Move(1, 2);
                        break;
                    case 9:
                        lblState.Text = "結束程式";
                        map = new int[8, 8];
                        break;
                }
                PaintMap();
            }
            e.KeyChar = '\0';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PaintMap();
        }
    }
}
