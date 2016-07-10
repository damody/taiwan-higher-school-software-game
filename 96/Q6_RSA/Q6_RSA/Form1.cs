using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Q6_RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //enum CryptionAction { Encrypt, Decrypt }

        /// <summary>
        /// Calcuate A^B mod C
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="c">C</param>
        /// <returns>A^B mod C</returns>
        long BigMod(long a, long b, long c)
        {
            long k = a;
            while (--b > 0)
                k = k * a % c;
            return k;
        }

        private void button_Click(object sender, EventArgs e)
        {
            long k1, k2;
            if (long.TryParse(textBox1.Text, out k1) && long.TryParse(textBox2.Text, out k2))
            {
                if (textBox3.Text.Length > 0)
                {
                    Encoding big5 = Encoding.GetEncoding("big5");
                    if (sender == button1) {
                        // Encrypt
                        byte[] data = big5.GetBytes(textBox3.Text);
                        int c;
                        string output = "";
                        for (int i = 0; i < data.Length; i++)
                        {
                            c = data[i];
                            if (c >> 7 == 1)
                                c = (c << 8) | data[++i];
                            c = (int)BigMod(c, k1, k2);
                            output += c.ToString().PadLeft(5, '0');
                        }
                        textBox4.Text = output;
                        //byte[] data = Encoding.GetEncoding("big5").GetBytes(textBox3.Text);
                        //textBox4.Text = RSA(new BigInteger(data), k1, k2, CryptionAction.Encrypt);
                    }
                    else if (sender == button2)
                    {
                        // Decrypt
                        string input = textBox3.Text;
                        int c;
                        string output = "";
                        if (input.Length % 5 > 0)
                        {
                            MessageBox.Show("輸入資料有誤");
                            return;
                        }
                        for (int i = 0; i < input.Length; i += 5)
                        {
                            if (!int.TryParse(input.Substring(i, 5), out c))
                            {
                                MessageBox.Show("輸入資料有誤");
                                return;
                            }
                            c = (ushort)BigMod(c, k1, k2);
                            if (c < 0x80)
                                output += (char)c;
                            else
                                output += big5.GetString(new byte[] { (byte)((c >> 8) & 0xFF), (byte)(c & 0xFF) });
                        }
                        textBox4.Text = output;
                        //BigInteger data;
                        //if (!BigInteger.TryParse(textBox3.Text, out data))
                        //{
                        //    MessageBox.Show("輸入資料有誤");
                        //    return;
                        //}
                        //textBox4.Text = RSA(data, k1, k2, CryptionAction.Decrypt);
                    }
                }
                else
                {
                    MessageBox.Show("請輸入資料");
                }
            }
            else
            {
                MessageBox.Show("輸入有誤");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "8315";
            textBox2.Text = "68269";
            textBox3.Text = "RSA";
            textBox4.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "8315";
            textBox2.Text = "68269";
            textBox3.Text = "電腦軟體設計";
            textBox4.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "9907";
            textBox2.Text = "68269";
            textBox3.Text = "2854212172437551217228542";
            textBox4.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "9907";
            textBox2.Text = "68269";
            textBox3.Text = "632991699050120151120113617711";
            textBox4.Text = "";
        }

        //string RSA(BigInteger data, long k1, long k2, CryptionAction act)
        //{
        //    if (act == CryptionAction.Encrypt)
        //    {
        //        return BigMod(data, k1, k2).ToString();
        //    }
        //    else if (act == CryptionAction.Decrypt)
        //    {
        //        return Encoding.GetEncoding("big5").GetString(BigMod(data, k1, k2).ToByteArray());
        //        // return BigMod(data, k1, k2).ToString();
        //    }
        //    return null;
        //}
    }
}
