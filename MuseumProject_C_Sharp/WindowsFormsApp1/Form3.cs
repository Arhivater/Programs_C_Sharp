using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private const int width = 1200;
        private const int height = 750;
        private string placeholderText1 = "Логин";
        private string placeholderText2 = "Пароль";
        private string commandConnection = @"Data Source=DBSrv\MSSQL;Initial Catalog=fitlife;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.Height = 46;
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(146, 195, 124);
            button1.BackColor = myRgbColor;
            textBox1.Text = placeholderText1;
            FormBorderStyle = FormBorderStyle.Fixed3D;
           }


        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == placeholderText1)
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black; 
            }
        }

        private void TextBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;

                textBox1.Text = placeholderText1; 
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == placeholderText2)
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;

                textBox2.Text = placeholderText2;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;

                textBox1.Text = placeholderText1;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
               

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(commandConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT [Логин], \"Пароль\" FROM [Пользователь] WHERE Логин = '"
                    + textBox1.Text + "' and Пароль = '" + textBox2.Text + "'", connection);
                try
                {
                    SqlDataReader sqlread = command.ExecuteReader();
                    if (sqlread.HasRows)
                    {
                        label1.Text = "Welcome to the Jungle";                        
                    }
                    else
                    {
                        label1.Text = "Неверные логин или пароль";                        
                    }
                    label1.Left = Form3.width / 2 - label1.Width / 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
                connection.Close();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
           /* if (textBox2.Text != "")
            {
                textBox2.PasswordChar = '#';
            }
            else {
                textBox2.Text = placeholderText2;
                textBox2.PasswordChar = '#';
            }*/
        }
    }
}
