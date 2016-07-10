using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q4_InfixToPostfix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text, output = "";
            List<ExpressionToken> items = new List<ExpressionToken>();
            ExpressionToken last = new ExpressionToken(input.Substring(0, 1));
            Stack<ExpressionToken> stack = new Stack<ExpressionToken>();
            items.Add(last);

            for (int i = 1; i < input.Length; i++)
            {
                ExpressionToken tmp = new ExpressionToken(input.Substring(i, 1));
                if (tmp.Type == ExpressionToken.ExpressionType.Numeric && tmp.Type == last.Type)
                {
                    last.Value += tmp.Value;
                }
                else
                {
                    items.Add(tmp);
                    last = tmp;
                }
            }

            foreach (ExpressionToken token in items)
            {
                if (token.Type == ExpressionToken.ExpressionType.Numeric)
                {
                    output += token.Value + " ";
                }
                else if (token.Type == ExpressionToken.ExpressionType.Operator)
                {
                    while (stack.Count > 0 && stack.Peek().Priority > token.Priority)
                        output += stack.Pop().Value + " ";
                    stack.Push(token);
                }
                else if (token.Type == ExpressionToken.ExpressionType.LeftParentheses)
                {
                    stack.Push(token);
                }
                else if (token.Type == ExpressionToken.ExpressionType.RightParentheses)
                {
                    while (stack.Count > 0 && stack.Peek().Type != ExpressionToken.ExpressionType.LeftParentheses)
                        output += stack.Pop().Value + " ";
                    stack.Pop();
                }
            }

            while (stack.Count > 0)
                output += stack.Pop().Value + " ";

            textBox2.Text = output.TrimEnd();
        }
    }

    public class ExpressionToken
    {
        public enum ExpressionType { LeftParentheses, RightParentheses, Operator, Numeric }
        public string Value;
        public ExpressionType Type
        {
            get
            {
                if (this.Value == "(")
                    return ExpressionType.LeftParentheses;
                else if (this.Value == ")")
                    return ExpressionType.RightParentheses;
                else if ("+-*/".IndexOf(this.Value) > -1)
                    return ExpressionType.Operator;
                return ExpressionType.Numeric;
            }
            private set { }
        }

        public int Priority
        {
            get {
                return (this.Value == "+" || this.Value == "-") ? 1 :
                           (this.Value == "*" || this.Value == "/") ? 2 :
                               (this.Type == ExpressionType.LeftParentheses || this.Type == ExpressionType.RightParentheses) ? 0 : -1;
            }
            private set { }
        }

        public ExpressionToken(string Value)
        {
            this.Value = Value;
        }
    }
}
