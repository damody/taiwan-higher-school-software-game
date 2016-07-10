using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q6_點菜系統
{
    public partial class Form1 : Form
    {
        int[][] price = new int[][] {
            new int[] { 75, 70, 65, 80 },
            new int[] { 45, 40, 50, 40 },
            new int[] { 45, 40, 40, 50 },
            new int[] { 40, 45, 40, 35 }
        };

        MealSelection[,] selections = new MealSelection[2, 4];
        Label[] lbl;
        Label[,] lblPrice = new Label[2, 4];
        int Index = 0;
        GroupBox[] group;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl = new Label[] { label1, label2 };
            group = new GroupBox[] { groupBox1, groupBox2 };
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                {
                    selections[i, j] = null;
                    group[i].Controls.Add(lblPrice[i, j] = new Label());
                    lblPrice[i, j].Location = new Point(10 + (j % 2) * 160, 20 + (j / 2) * 160);
                    lblPrice[i, j].AutoSize = true;
                }
        }

        void Clicked(int type, int index, string name)
        {
            if (Index >= 2)
                return;

            // MessageBox.Show(name + ", " + price[type][index].ToString());
            lblPrice[Index, type].Text = string.Format("{0}\r\n（{1}元）", name, price[type][index]);
            selections[Index, type] = new MealSelection(type, index, name);
            int sum = 0, c = 0;
            for (int i = 0; i < 4; i++)
            {
                if (selections[Index, i] != null)
                {
                    sum += price[selections[Index, i].Type][selections[Index, i].Item];
                    c++;
                }
            }
            lbl[Index].Text = string.Format("價錢：{0}", sum);
            if (c == 4)
                Index++;
        }

        private void ToolStripMenuItem_0_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Sender = (ToolStripMenuItem)sender;
            int index = int.Parse((string)Sender.Tag);
            Clicked(0, index, Sender.Text);
        }

        private void ToolStripMenuItem_1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Sender = (ToolStripMenuItem)sender;
            int index = int.Parse((string)Sender.Tag);
            Clicked(1, index, Sender.Text);
        }

        private void ToolStripMenuItem_2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Sender = (ToolStripMenuItem)sender;
            int index = int.Parse((string)Sender.Tag);
            Clicked(2, index, Sender.Text);
        }

        private void ToolStripMenuItem_3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Sender = (ToolStripMenuItem)sender;
            int index = int.Parse((string)Sender.Tag);
            Clicked(3, index, Sender.Text);
        }
    }

    class MealSelection
    {
        public int Type, Item;
        public string Name;

        public MealSelection(int type, int item, string name)
        {
            this.Type = type;
            this.Item = item;
            this.Name = name;
        }
    }
}
