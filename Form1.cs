using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discrete_Math
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int numberPass(string pass)
        {
            int num = 0;

            foreach (char ch in pass)
            {
                if (char.IsDigit(ch))
                {
                    num++;
                }
            }
            return num;
        }

        private int upperCase(string pass)
        {
            int num = 0;

            foreach (char ch in pass)
            {
                if (char.IsUpper(ch))
                {
                    num++;
                }
            }
            return num;
        }

        private bool specChar(string pass)
        {
            return pass.Any(ch => ! char.IsLetterOrDigit(ch));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int min_length = 12;
            const int umin_length = 8;
            string password = textBox2.Text;
            string password2 = textBox3.Text;
            string username = textBox1.Text;

            if (password.Length >= min_length
                && numberPass(password) >= 1 && upperCase(password) >= 1 && specChar(password)
                && textBox2.Text == textBox3.Text && username.Length >= umin_length)
            {
                MessageBox.Show("Registration Successful!");
                listBox1.Items.Add(textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Some fields are empty!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }

            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match. Try again");
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
            }

            else if (textBox1.Text.Length < 8)
            {
                MessageBox.Show("Username must be at least 8 characters long");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Your password needs to: \n • include at least one number or symbol. \n • be at least 12 characters long.");
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '•';
                textBox3.PasswordChar = '•';
            }
        }
    }
}
