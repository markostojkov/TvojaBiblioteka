using System;
using System.Windows.Forms;
using TvojaBiblioteka.Services;

namespace TvojaBiblioteka
{
    public partial class RegisterForm : Form
    {
        public RegisterForm(CurrentUser currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        public CurrentUser CurrentUser { get; }

        // register user
        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;
            var confirmPassword = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Fields can't be empty");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password must match");
                return;
            }

            var registeredSuccess = CurrentUser.Register(username, password);

            if (!registeredSuccess)
            {
                MessageBox.Show("User already exists");
                return;
            }

            MessageBox.Show($"Successfully registered user with username {username}!");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
