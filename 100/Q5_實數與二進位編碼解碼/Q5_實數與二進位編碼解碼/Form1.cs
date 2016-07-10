using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_實數與二進位編碼解碼
{
    public partial class Form1 : Form
    {

        public Form1() { InitializeComponent(); }

        void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double l, h, range, value;
            int accuracy, rangeBits = 0;

            if (!double.TryParse(txtX1.Text, out l) || !double.TryParse(txtX2.Text, out h) || !int.TryParse(txtAcc.Text, out accuracy) || !double.TryParse(txtVal.Text, out value))
            {
                MessageBox.Show("錯誤的輸入");
                return;
            }
            if (l > h) { Swap<double>(ref l, ref h); string T = txtX1.Text; txtX1.Text = txtX2.Text; txtX2.Text = T; }

            range = (h - l) * (int)Math.Pow(10, accuracy);
            while (Math.Pow(2, rangeBits) - 1 < range)
                rangeBits++;

            rangeBits++;

            long result = (long)((value - l) * (Math.Pow(2, rangeBits) - 1) / (h - l));
            txtVal.Text = Convert.ToString(result + 1, 2).PadLeft(rangeBits, '0').Substring(0, rangeBits - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double l, h, range;
            int accuracy, rangeBits = 0;
            long value = -1;

            try
            {
                value = Convert.ToInt64(txtVal.Text, 2);
            }
            catch (Exception)
            {
                MessageBox.Show("錯誤的輸入");
                return;
            }

            if (!double.TryParse(txtX1.Text, out l) || !double.TryParse(txtX2.Text, out h) || !int.TryParse(txtAcc.Text, out accuracy))
            {
                MessageBox.Show("錯誤的輸入");
                return;
            }
            if (l > h) { Swap<double>(ref l, ref h); string T = txtX1.Text; txtX1.Text = txtX2.Text; txtX2.Text = T; }

            range = (h - l) * (int)Math.Pow(10, accuracy);
            while (Math.Pow(2, rangeBits) - 1 < range)
                rangeBits++;
            txtVal.Text = (value * (h - l) / (Math.Pow(2, rangeBits) - 1) + l).ToString();
            if (txtVal.Text.IndexOf('.') > -1)
                txtVal.Text = txtVal.Text.Substring(0, txtVal.Text.IndexOf('.') + accuracy + 1);
        }
    }
}
