using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TvojaBiblioteka.Persistence.DbContext;
using TvojaBiblioteka.Persistence.Entities;
using TvojaBiblioteka.Services;

namespace TvojaBiblioteka
{
    public partial class AddBookForm : Form
    {
        public AddBookForm(AppDbContext dbContext, CurrentUser currentUser)
        {
            InitializeComponent();
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public AppDbContext DbContext { get; }
        public CurrentUser CurrentUser { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var description = textBox3.Text;
            var author = textBox2.Text;
            var date = dateTimePicker1.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Fields cant be empty");
                return;
            }

            var book = new Book()
            {
                Name = name,
                Description = description,
                Author = author,
                DatePublished = date,
                ApplicationUserFk = CurrentUser.User.Id
            };
            DbContext.Books.Add(book);
            DbContext.SaveChanges();

            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
