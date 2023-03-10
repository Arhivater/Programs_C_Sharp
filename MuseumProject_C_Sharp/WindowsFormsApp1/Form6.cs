using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(150, 240, 154);
            button2.BackColor = Color.FromArgb(150, 240, 154);
            button3.BackColor = Color.FromArgb(150, 240, 154);
            button4.BackColor = Color.FromArgb(150, 240, 154);
            button5.BackColor = Color.FromArgb(150, 240, 154);
            button6.BackColor = Color.FromArgb(150, 240, 154);
            textBox1.AutoSize = false;
            textBox1.Size = new System.Drawing.Size(240, 50);
            label2.AutoSize = false;
            label2.Size = new System.Drawing.Size(340, 330);
        }
    }
}
