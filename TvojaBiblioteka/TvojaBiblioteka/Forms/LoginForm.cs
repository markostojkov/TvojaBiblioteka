using System;
using System.Windows.Forms;
using TvojaBiblioteka.Persistence.DbContext;
using TvojaBiblioteka.Services;

namespace TvojaBiblioteka
{
    public partial class LoginForm : Form
    {
        public LoginForm(CurrentUser currentUser, AppDbContext appDbContext)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            AppDbContext = appDbContext;
            textBox2.PasswordChar = '*';
        }

        public CurrentUser CurrentUser { get; }
        public AppDbContext AppDbContext { get; }

        // login
        private void button1_Click(object sender, EventArgs e)
        {
            var loggedIn = CurrentUser.Login(textBox1.Text, textBox2.Text);

            if (loggedIn)
            {
                textBox1.Clear();
                textBox2.Clear();
                var booksForm = new Form1(AppDbContext, CurrentUser)
                {
                    Location = Location,
                    StartPosition = FormStartPosition.Manual
                };
                booksForm.FormClosing += delegate { Show(); };
                booksForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        // go to register form
        private void button2_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(CurrentUser)
            {
                Location = Location,
                StartPosition = FormStartPosition.Manual
            };
            registerForm.FormClosing += delegate { Show(); };
            registerForm.Show();
            Hide();
        }
    }
}
