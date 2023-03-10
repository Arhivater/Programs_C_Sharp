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
    public partial class Form2 : Form
    {
        private string placeholderText0 = "Имя";
        private string placeholderText1 = "Логин";
        private string placeholderText2 = "Пароль";
        private string placeholderText3 = "Повторите пароль";
        private string commandConnection = "Data Source=DBSrv\\MSSQL;Initial Catalog=fitlife;Integrated Security=True";
        private char passSymbol;
        public int width = 1200;
        public int height = 788;

        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            passSymbol = textBox2.PasswordChar;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if ((textBox2.Text == placeholderText1) || (textBox3.Text == placeholderText2) || (textBox4.Text == placeholderText3))
            {
                label1.Text = "Заполните все поля";
                label1.Left = width / 2 - label1.Width / 2;
                return;
            }
            using (SqlConnection connection = new SqlConnection(commandConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT [Логин]  FROM [Пользователь] WHERE Логин = '"
                    + textBox2.Text + "' ", connection);
                try
                {
                    SqlDataReader sqlread = command.ExecuteReader();
                    if (sqlread.HasRows)
                    {
                        label1.Text = "Данный логин существует";
                    }
                    else
                    {
                        if (textBox3.Text != textBox4.Text)
                            label1.Text = "Пароли не совпадают";
                        else
                        {
                            sqlread.Close();
                            command = new SqlCommand("Insert Into Пользователь (Логин, Пароль) values ('" 
                                + textBox2.Text + "','" + textBox3.Text + "')", connection  );
                            sqlread = command.ExecuteReader();
                            Form4 f4 = new Form4();
                            this.Hide();
                            f4.ShowDialog();
                        }
                    }
                    
                    label1.Left = width / 2 - label1.Width / 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
                     

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == placeholderText1)
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

                textBox2.Text = placeholderText1;
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == placeholderText2)
            {
                textBox3.Text = "";
                textBox3.PasswordChar = '*';

                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.PasswordChar = passSymbol;
                textBox3.Text = placeholderText2;
            }
        }

        private void TextBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == placeholderText3)
            {
                textBox4.Text = "";
                textBox4.PasswordChar = '*';
                textBox4.ForeColor = Color.Black;
            }
        }

        /*  string connectionString = @"Data Source=DBSRV\MSSQL;Initial Catalog=703b2_Prilepko_d; Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("select dbo.Paintings.Paintings_Name, dbo.Painters.Painters_Name FROM dbo.Paintings, dbo.Painters, dbo.Paintings_By_Painters where(dbo.Paintings_By_Painters.N_Paintings = dbo.Paintings.ID_Paintings and dbo.Paintings_By_Painters.N_Painters = dbo.Painters.ID_Painters)", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                string txt = "";
                for (int i = 0; i < sqlReader.FieldCount; ++i)
                {
                    txt += sqlReader.GetName(i) + "\t\t";
                }
                listBox1.Items.Add(txt);
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Paintings_Name"]) + "\t\t" + Convert.ToString(sqlReader["Painters_Name"]) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            } */

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = Color.Gray;
                textBox4.PasswordChar = passSymbol;
                textBox4.Text = placeholderText3;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
