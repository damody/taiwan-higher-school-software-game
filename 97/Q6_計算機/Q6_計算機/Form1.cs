using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q6_計算機
{
    public partial class Form1 : Form
    {
        string last = "", op = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lbl = new string[] { "7", "8", "9", "Log", "AC", "4", "5", "6", "+", "-", "1", "2", "3", "*", "/", "+/-", "0", ".", "=" };
            for (int i = 0; i < lbl.Length; i++)
            {
                Button btn = new Button();
                this.Controls.Add(btn);
                btn.Text = lbl[i];
                btn.Size = new Size(40 + (lbl[i] == "=" ? 50 : 0), 40);
                btn.Location = new Point(12 + (i % 5) * 50, 40 + i / 5 * 50);
                btn.Click += new EventHandler(Button_Click);
            }
        }

        void Button_Click(object s, EventArgs e)
        {
            Button Sender = s as Button;
            if ('0' <= Sender.Text[0] && Sender.Text[0] <= '9')
            {
                textBox1.Text += Sender.Text;
            }
            else if (Sender.Text == ".")
            {
                textBox1.Text += textBox1.Text.IndexOf('.') == -1 ? "." : "";
            }
            else if (Sender.Text == "+/-")
            {
                if (textBox1.Text[0] == '-')
                    textBox1.Text = textBox1.Text.Substring(1);
                else
                    textBox1.Text = "-" + textBox1.Text;
            }
            else if (Sender.Text == "Log")
            {
                try
                {
                    double k = double.Parse(textBox1.Text);
                    k = Math.Log10(k);
                    textBox1.Text = k.ToString();
                }
                catch (Exception)
                {
                    textBox1.Text = "Error";
                }
            }
            else if (Sender.Text == "AC")
            {
                textBox1.Text = op = last = "";
            }
            else if (Sender.Text == "=" && last.Length > 0 && op.Length > 0)
            {
                try
                {
                    double a = double.Parse(last), b = double.Parse(textBox1.Text);
                    switch (op)
                    {
                        case "+":
                            textBox1.Text = (a + b).ToString();
                            return;
                        case "-":
                            textBox1.Text = (a - b).ToString();
                            return;
                        case "*":
                            textBox1.Text = (a * b).ToString();
                            return;
                        case "/":
                            textBox1.Text = (a / b).ToString();
                            return;
                    }
                }
                catch (Exception)
                {
                    textBox1.Text = op = last = "";
                    textBox1.Text = "Error";
                }
            }
            else
            {
                if (textBox1.Text.Length > 0)
                {
                    last = textBox1.Text;
                    textBox1.Text = "";
                }
                op = Sender.Text;
            }
        }
    }
}
