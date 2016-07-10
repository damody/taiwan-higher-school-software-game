using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3_RGB與HSI色彩空間互換
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R, G, B;
            if (double.TryParse(textBox1.Text, out R) && double.TryParse(textBox2.Text, out G) && double.TryParse(textBox3.Text, out B))
            {
                double k = R + G + B;
                double r = R / k, g = G / k, b = B / k;
                double h, s, i, H, S, I;
                h = Math.Acos((r * 2 - g - b) / 2 / Math.Pow(Math.Pow(r - g, 2) + (r - b) * (g - b), 0.5));
                if (b > g)
                    h = Math.PI * 2 - h;
                s = 1 - 3 * Math.Min(Math.Min(r, g), b);
                i = (R + G + B) / 3 / 255;
                H = h * 180 / Math.PI;
                if (double.IsNaN(H))
                    H = 0;
                S = s * 255;
                I = i * 255;
                textBox4.Text = ((int)Math.Round(H)).ToString();
                textBox5.Text = ((int)S).ToString();
                textBox6.Text = ((int)I).ToString();
            }
            else
            {
                MessageBox.Show("輸入有誤");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double H, S, I;
            if (double.TryParse(textBox4.Text, out H) && double.TryParse(textBox5.Text, out S) && double.TryParse(textBox6.Text, out I))
            {
                double r, g, b;
                double h = H * Math.PI / 180, s = S / 255, i = I / 255;
                double hp = h;

                if (Math.PI * 2 / 3 <= hp && hp < Math.PI * 4 / 3)
                    hp = hp - Math.PI * 2 / 3;
                else if (Math.PI * 4 / 3 <= hp && hp < Math.PI * 2)
                    hp = hp - Math.PI * 4 / 3;

                double x = i * (1 - s);
                double y = i * (1 + s * Math.Cos(hp) / Math.Cos(Math.PI / 3 - hp));
                double z = i * 3 - (x + y);

                if (h < Math.PI * 2 / 3)
                {
                    r = y;
                    g = z;
                    b = x;
                }
                else if (Math.PI * 2 / 3 <= h && h < Math.PI * 4 / 3)
                {
                    r = x;
                    g = y;
                    b = z;
                }
                else if (Math.PI * 4 / 3 <= h && h < Math.PI * 2)
                {
                    r = z;
                    g = x;
                    b = y;
                }
                else
                {
                    throw new Exception();
                }

                textBox1.Text = ((int)Math.Round(r * 255)).ToString();
                textBox2.Text = ((int)Math.Round(g * 255)).ToString();
                textBox3.Text = ((int)Math.Round(b * 255)).ToString();
            }
            else
            {
                MessageBox.Show("輸入有誤");
            }
        }
    }
}
