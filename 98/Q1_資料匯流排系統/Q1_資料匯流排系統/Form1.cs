using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_資料匯流排系統
{
    public partial class Form1 : Form
    {
        TextBox[] tbs = new TextBox[4];
        Button[] btns = new Button[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                tbs[i] = new TextBox();
                tbs[i].Size = new Size(80, 24);
                tbs[i].Location = new Point(0, i * 30);

                btns[i] = new Button();
                btns[i].Text = "Ih";
                btns[i].Size = new Size(36, 24);
                btns[i].Location = new Point(90, i * 30);
                btns[i].Click += new EventHandler(Buttons_Click);
                btns[i].Tag = i;

                panel1.Controls.Add(tbs[i]);
                panel1.Controls.Add(btns[i]);
            }
            btnRandom.Location = new Point(51, 120);
            btnTransmit.Location = new Point(51, 150);
        }

        void Buttons_Click(object sd, EventArgs e)
        {
            Button sender = sd as Button;
            int val = (int)sender.Tag;
            int index = val & 0xF;

            switch (sender.Text)
            {
                case "Ld":
                    sender.Text = "En";
                    break;
                case "En":
                    sender.Text = "Ih";
                    break;
                default:
                    sender.Text = "Ld";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
                tbs[i].Text = Convert.ToString(rnd.Next() & 0xFF, 2).PadLeft(8, '0');
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            string data = "";
            int ldc = 0;

            for (int i = 0; i < 4; i++)
            {
                if (btns[i].Text == "Ld")
                    ldc++;
                if (btns[i].Text != "En")
                    continue;
                if (data.Length == 0)
                {
                    data = tbs[i].Text;
                    continue;
                }
                MessageBox.Show("只能有一個Enable");
                return;
            }
            if (ldc == 0)
                return;
            if (data.Length == 0)
            {
                MessageBox.Show("沒有Enable");
                return;
            }
            for (int i = 0; i < 4; i++)
                if (btns[i].Text == "Ld")
                    tbs[i].Text = data;
        }
    }
}
