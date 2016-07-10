using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_TrashProcessFee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int getLevel(double x, int r)
        {
            if (x < 50 * r) return 1;
            if (x <= 100 * r) return 2;
            return 3;
        }

        double calculateTrashProcessFee(double m, double n)
        {
            int p = getLevel(m, 1), q = getLevel(n, 2);

            if (p == 1 && q == 1)
            {
                return (m + n) * 5 / 2 * 0.6;
            }
            else if ((p == 1 && q == 2) || (p == 2 && q == 1))
            {
                return (m + n) * 5 / 2 * 0.8;
            }
            else if (p == 3 && q == 3)
            {
                return (m + n) * 5 / 2 * 1.4;
            }
            else if ((p == 3 && q == 2) || (p == 2 && q == 3))
            {
                return (m + n) * 5 / 2 * 1.2;
            }
            else
            {
                return (m + n) * 5 / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] data = textBox1.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                double m = double.Parse(data[0]), n = double.Parse(data[1]);
                textBox2.Text = calculateTrashProcessFee(m, n).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("輸入有誤");
                return;
            }
        }
    }
}
