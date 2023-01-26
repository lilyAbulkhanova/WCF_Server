using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFServer;

namespace WCFClient
{
    public partial class login : Form
    {
        Client client = new Client();

        public login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usrlogin = textBox1.Text;
            var password = textBox2.Text;
            int key = client.RegistrationClient(usrlogin, password);
            if (key == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                Login_test_ login_form = new Login_test_();
                this.Hide();
                login_form.ShowDialog();
            }
            else
            if (key == 0)
            {
                MessageBox.Show("Аккаунт с таким именем уже существует");
            }
            else
            {
                MessageBox.Show("Не получилось создать");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login_test_ login_form = new Login_test_();
            login_form.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login_test_ registration = new Login_test_();
            registration.Show();
            this.Hide();

        }

        private void login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            pictureBox1.Visible = false;
            textBox1.MaxLength = 40;
            textBox2.MaxLength = 40;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
    }
}
