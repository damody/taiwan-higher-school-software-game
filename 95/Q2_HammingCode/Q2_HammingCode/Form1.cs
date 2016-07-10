using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2_HammingCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool is2N(int x)
        {
            return (x & (x - 1)) == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            int hammingCode = 0, hashLength = 0;
            char[] buffer;
            int p = 0;

            if (input.Length > 11)
            {
                textBox2.Text = "輸入的訊息長度應小於12";
                return;
            }

            while ((1 << hashLength) < input.Length + hashLength + 1)
                hashLength++;

            buffer = new char[hashLength + input.Length];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (!is2N(buffer.Length - i)) ? input[p++] : '\0';

            p = buffer.Length;
            foreach (char ch in buffer)
                if (ch == '1')
                {
                    hammingCode ^= p;
                    p--;
                }
                else if (ch == '0' || ch == '\0')
                {
                    p--;
                }
                else
                {
                    textBox2.Text = "輸入的訊息應為0或1";
                    return;
                }
            string hash = Convert.ToString(hammingCode, 2).PadLeft(hashLength, '0');

            p = 0;
            for (int i = 0; i < buffer.Length; i++)
                if (buffer[i] == '\0')
                    buffer[i] = hash[p++];

            textBox2.Text = new string(buffer);
        }
    }
}
