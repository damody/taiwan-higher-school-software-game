using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q7_點餐系統
{
    public partial class Form1 : Form
    {
        List<Item> Items = new List<Item>();

        public Form1()
        {
            InitializeComponent();
        }

        GroupBox Register(MenuGroup mg, Point pt)
        {
            GroupBox gbox;
            this.Controls.Add(gbox = mg.Group());
            Items.AddRange(mg.Items);
            gbox.Location = pt;
            return gbox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GroupBox gbox0, gbox1;
            gbox0 = gbox1 = Register(new MenuGroup("主餐").Add(
                new Item("香酥脆皮雞排", 250),
                new Item("特選沙朗牛排", 380),
                new Item("特選菲力牛排", 430),
                new Item("什錦海鮮", 450),
                new Item("法式藍帶豬排", 300),
                new Item("海陸大餐", 570)
                ), new Point(5, 5));
            gbox1 = Register(new MenuGroup("沙拉").Add(
                new Item("生菜沙拉", 60),
                new Item("凱薩醬", 60),
                new Item("和風醬", 60),
                new Item("優格水果沙拉", 60),
                new Item("千島醬", 60),
                new Item("義大利醬", 60)
                ), new Point(gbox1.Left + gbox1.Width + 5, 5));
            gbox1 = Register(new MenuGroup("前菜").Add(
                new Item("洋蔥鱈魚肝", 80),
                new Item("泰式嫩菲力", 80),
                new Item("煙燻鮭魚", 80),
                new Item("香蒜烤田螺", 80),
                new Item("黑菌鵝肝醬", 80)
                ), new Point(gbox1.Left + gbox1.Width + 5, 5));
            gbox0 = Register(new MenuGroup("湯品").Add(
                new Item("雞蓉巧達湯", 100),
                new Item("海鮮嫩魚湯", 100),
                new Item("考洋蔥湯", 100),
                new Item("南瓜湯", 100),
                new Item("脆皮濃湯", 100)
                ), new Point(5, 5 + gbox0.Top + gbox0.Height));
            gbox1 = Register(new MenuGroup("甜點").Add(
                new Item("雞蛋布丁", 30),
                new Item("焦糖蛋糕", 50),
                new Item("義式布丁", 40),
                new Item("提拉米蘇", 50),
                new Item("柳橙水果凍", 50)
                ), new Point(gbox0.Left + gbox0.Width + 5, gbox0.Top));
            gbox0 = Register(new MenuGroup("熱飲").Add(
                new Item("奶泡熱奶茶", 70),
                new Item("熱咖啡", 70),
                new Item("蜂蜜柚子茶", 90),
                new Item("熱拿鐵咖啡", 70),
                new Item("熱金桔檸檬梅子汁", 100)
                ), new Point(5, 5 + gbox0.Top + gbox0.Height));
            gbox1 = Register(new MenuGroup("冷飲").Add(
                new Item("可口可樂", 50),
                new Item("冰咖啡", 70),
                new Item("冰金桔檸檬", 100),
                new Item("芒果汁", 90),
                new Item("冰拿鐵", 70)
                ), new Point(gbox0.Left + gbox0.Width + 5, gbox0.Top));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Items)
                item.Number.Value = 0;
            label1.Text = "等待點餐中...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach (var item in Items)
                sum += item.Price * (int)item.Number.Value;
            sum *= 1.05;
            if (sum % 1 > 0.5)
                sum++;
            sum = Math.Floor(sum);
            label1.Text = "總金額：" + sum.ToString();
        }
    }

    public class Item {
        public string Name;
        public int Price;
        public Label Label;
        public TextBox PriceBox;
        public NumericUpDown Number;

        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void Link(Label lbl, TextBox tbx, NumericUpDown num)
        {
            this.Label = lbl;
            this.PriceBox = tbx;
            this.Number = num;
        }
    }

    public class MenuGroup
    {
        public List<Item> Items = new List<Item>();
        string Name;

        public MenuGroup(string name)
        {
            this.Name = name;
        }

        public MenuGroup Add(params Item[] item)
        {
            Items.AddRange(item);
            return this;
        }

        public GroupBox Group()
        {
            GroupBox box = new GroupBox();
            int i = 0;
            foreach (Item item in Items) {
                Label lbl = new Label();
                TextBox tbx = new TextBox();
                NumericUpDown num = new NumericUpDown();
                item.Link(lbl, tbx, num);
                lbl.Text = item.Name;
                lbl.AutoSize = true;
                tbx.Text = item.Price.ToString();
                tbx.Size = new Size(40, 25);
                tbx.ReadOnly = true;
                num.Maximum = 20;
                num.Minimum = 0;
                lbl.Location = new Point(5, 25 + i * 25);
                tbx.Location = new Point(105, 25 + i * 25);
                num.Location = new Point(150, 25 + i * 25);
                num.Width = 40;
                box.Controls.AddRange(new Control[] { lbl, tbx, num });
                i++;
            }
            box.Width = 200;
            box.Height = i * 25 + 30;
            box.Text = this.Name;
            return box;
        }
    }
}
