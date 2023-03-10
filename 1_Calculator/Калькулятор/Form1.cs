using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        String Operation;
        Double FirstNumber, SecondNumber;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumericValue(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (TextDisplay.Text == "0") {
                TextDisplay.Text = "";
            }

            if (b.Text == ",") {
                if (!TextDisplay.Text.Contains(","))
                    TextDisplay.Text = TextDisplay.Text + b.Text;
            }
            else {
                    TextDisplay.Text = TextDisplay.Text + b.Text;
                }
        }

        private void ButtonC(object sender, EventArgs e)
        {
            TextDisplay.Text = "0";
        }

        private void ButtonCE(object sender, EventArgs e)
        {
            TextDisplay.Text = "0";

            String f, s;

            s = Convert.ToString(SecondNumber);
            f = Convert.ToString(FirstNumber);

            s = "";
            f = "";
        }

        private void Operation_Func(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            FirstNumber = Double.Parse(TextDisplay.Text);
            Operation = b.Text;
            TextDisplay.Text = "";
        }

        private void Backspace(object sender, EventArgs e)
        {
            if (TextDisplay.Text.Length > 0) {
                TextDisplay.Text = TextDisplay.Text.Remove(TextDisplay.Text.Length - 1, 1);
            }

            if (TextDisplay.Text == "") {
                TextDisplay.Text = "0";
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (TextDisplay.Text.Contains("-"))
            {
                TextDisplay.Text = TextDisplay.Text.Remove(0, 1);
            }
            else {
                TextDisplay.Text = "-" + TextDisplay.Text;
            }
                
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            SecondNumber = double.Parse(TextDisplay.Text);
            switch (Operation) {
                case "+":
                    TextDisplay.Text = Convert.ToString(FirstNumber + SecondNumber);
                    break;
                case "-":
                    TextDisplay.Text = Convert.ToString(FirstNumber - SecondNumber);
                    break;
                case "*":
                    TextDisplay.Text = Convert.ToString(FirstNumber * SecondNumber);
                    break;
                case "/":
                    TextDisplay.Text = Convert.ToString(FirstNumber / SecondNumber);
                    break;
                default:
                    break;
            }
        }

    }
}
