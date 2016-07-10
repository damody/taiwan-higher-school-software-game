using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1_同音代換加密法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HCSEncrypter hcse = new HCSEncrypter();
                textBox2.Text = hcse.Encrypt(textBox1.Text.ToUpper());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("輸入超出範圍 (A~J)");
            }
        }
    }

    public class HCSEncrypter
    {
        Queue<int>[] Table;

        public HCSEncrypter()
        {
            this.Table = new Queue<int>[10]{
                /* A */ new Queue<int>(new int[] { 09, 12, 33, 47, 53, 67, 78, 92 }),
                /* B */ new Queue<int>(new int[] { 48, 81 }),
                /* C */ new Queue<int>(new int[] { 13, 41, 62 }),
                /* D */ new Queue<int>(new int[] { 01, 03, 45, 79 }),
                /* E */ new Queue<int>(new int[] { 14, 16, 24, 44, 46, 55, 57, 64, 74, 82, 87, 98 }),
                /* F */ new Queue<int>(new int[] { 10, 31 }),
                /* G */ new Queue<int>(new int[] { 06, 25 }),
                /* H */ new Queue<int>(new int[] { 23, 39, 50, 56, 65, 68 }),
                /* I */ new Queue<int>(new int[] { 32, 70, 73, 83, 88, 93 }),
                /* J */ new Queue<int>(new int[] { 15 }),
            };
        }

        public string Encrypt(string str)
        {
            if (str == "")
                return str;
            string output = "";
            foreach (char ch in str)
            {
                if ('A' <= ch && ch <= 'J')
                {
                    int k = Table[ch - 'A'].Dequeue();
                    Table[ch - 'A'].Enqueue(k);
                    output += " " + k.ToString().PadLeft(2, '0');
                }
                else
                {
                    throw new ArgumentOutOfRangeException("超出範圍的輸入");
                }
            }
            return output.Substring(1);
        }
    }
}
