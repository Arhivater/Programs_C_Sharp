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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(150, 240, 154);
            button2.BackColor = Color.FromArgb(150, 240, 154);
            button3.BackColor = Color.FromArgb(150, 240, 154);
            button4.BackColor = Color.FromArgb(150, 240, 154);
        }
    }
}
