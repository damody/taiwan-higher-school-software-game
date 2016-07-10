using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q5_8Puzzle智慧盤系統
{
    public partial class Form1 : Form
    {
        private byte[] Goal = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        TextBox[,] textboxes = new TextBox[2,9];
        Panel[] panels;
        GameState[] solution_steps = null;
        int step_index = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panels = new Panel[] { panel1, panel2 };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txt = new TextBox();
                    panels[i].Controls.Add(txt);
                    txt.Location = new Point((j % 3) * 29, (j / 3) * 29);
                    txt.Size = new Size(22, 22);
                    txt.Visible = true;
                    txt.TextAlign = HorizontalAlignment.Center;
                    textboxes[i, j] = txt;
                }
            }
            for (int i = 0; i < 9; i++)
                textboxes[1, i].Text = i.ToString();
        }

        void Swap<T>(ref T a, ref T b)
        {
            T c = a; a = b; b = c;
        }

        GameState next_permutation(GameState now, int step)
        {
            int index = Array.IndexOf<byte>(now.State, 0);

            byte[] arr = null;

            switch (step)
            {
                case 1: // L
                    if (index % 3 == 0) return null;
                    break;
                case 2: // T
                    if (index / 3 == 0) return null;
                    break;
                case 3: // R
                    if (index % 3 == 2) return null;
                    break;
                case 4: // B
                    if (index / 3 == 2) return null;
                    break;
                default:
                    return null;
            }

            arr = (byte[])now.State.Clone();

            switch (step)
            {
                case 1: // L
                    Swap<byte>(ref arr[index], ref arr[index - 1]);
                    break;
                case 2: // T
                    Swap<byte>(ref arr[index], ref arr[index - 3]);
                    break;
                case 3: // R
                    Swap<byte>(ref arr[index], ref arr[index + 1]);
                    break;
                case 4: // B
                    Swap<byte>(ref arr[index], ref arr[index + 3]);
                    break;
            }
            return new GameState(arr, now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Random rnd = new Random();
            for (int i = 0; i < 9; i++ )
                    Swap<int>(ref arr[i], ref arr[rnd.Next(0, 8)]);
            for (int i = 0; i < 9; i++)
                textboxes[0, i].Text = arr[i].ToString();
        }

        GameState[] Calc()
        {
            Queue<GameState> queue = new Queue<GameState>();
            byte[] st_data = new byte[9];
            byte[,] calc = new byte[2, 9];
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    st_data[i] = byte.Parse(textboxes[0, i].Text);
                    Goal[i] = byte.Parse(textboxes[1, i].Text);
                    if (st_data[i] < 0 || st_data[i] > 8) throw new Exception();
                    if (Goal[i] < 0 || Goal[i] > 8) throw new Exception();
                    if (calc[0, st_data[i]]++ > 0) throw new Exception();
                    if (calc[1, Goal[i]]++ > 0) throw new Exception();
                }
            }
            catch (Exception) { MessageBox.Show("輸入有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            GameState st = new GameState(st_data, null); // Root
            queue.Enqueue(st);
            SortedList<long, bool> dict = new SortedList<long, bool>();

            lblSteps.Text = "計算中...";
            this.Refresh();

            while (queue.Count > 0)
            {
                st = queue.Dequeue();

                if (st.State.SequenceEqual(Goal))
                {
                    List<GameState> arr = new List<GameState>();
                    while (!st.IsRoot())
                    {
                        arr.Add(st);
                        st = st.Father;
                    }
                    arr.Add(st);
                    lblSteps.Text = (arr.Count - 1).ToString();
                    arr.Reverse();
                    return arr.ToArray();
                }

                for (int i = 1; i <= 4; i++)
                {
                    GameState next = next_permutation(st, i);
                    if (next != null)
                    {
                        long n = next.Serialize();
                        if (!dict.Keys.Contains(n))
                        {
                            dict.Add(n, true);
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            lblSteps.Text = "無解";
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameState[] steps = Calc();
            if (steps != null)
            {
                solution_steps = steps;
                step_index = 0;
                tmrMove.Enabled = true;
            }
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            GameState st = solution_steps[step_index++];

            for (int i = 0; i < 9; i++)
                textboxes[0, i].Text = st.State[i].ToString();

            lblSteps.Text = String.Format("({0} / {1})", solution_steps.Length - step_index, solution_steps.Length - 1);

            if (solution_steps.Length == step_index)
                tmrMove.Enabled = false;
        }
    }

    class GameState // about 160 bytes per instance in List<GameState>
    {
        // public byte[,] State_2D { get; private set; }
        public byte[] State { get; private set; }
        public GameState Father { get; private set; }

        //public GameState(byte[,] state, GameState father)
        //{
        //    this.State_1D = new byte[9];
        //    this.State_2D = state;
        //    Buffer.BlockCopy(state, 0, this.State_1D, 0, 9);
        //    this.Father = father;
        //}

        public GameState(byte[] state, GameState father)
        {
            this.State = state;
            //this.State_2D = new byte[3, 3];
            //Buffer.BlockCopy(state, 0, this.State_2D, 0, 9);
            this.Father = father;
        }

        public bool IsRoot()
        {
            return this.Father == null;
        }

        public long Serialize()
        {
            long n = 0;
            for (int i = 8; i >= 0; i--)
                n = n * 10 + this.State[i];
            return n;
        }
    }
}
