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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(129, 240, 102);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.AutoSize = false;
            textBox1.Size = new System.Drawing.Size(240, 50);
            textBox2.AutoSize = false;
            textBox2.Size = new System.Drawing.Size(240, 50);
            button1.BackColor = Color.FromArgb(150, 240, 154);
        }
    }
}
