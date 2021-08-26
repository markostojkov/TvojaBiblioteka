using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvojaBiblioteka.Persistence.DbContext;
using TvojaBiblioteka.Persistence.Entities;
using TvojaBiblioteka.Services;

namespace TvojaBiblioteka
{
    public partial class Form1 : Form
    {
        public Form1(AppDbContext dbContext, CurrentUser currentUser)
        {
            InitializeComponent();
            DbContext = dbContext;
            CurrentUser = currentUser;
            Load += new EventHandler(MainFormLoaded);
        }

        private AppDbContext DbContext { get; }
        private CurrentUser CurrentUser { get; }
        public List<Book> BooksForUser { get; private set; }

        private void MainFormLoaded(object sender, EventArgs e)
        {
            BooksForUser = DbContext.Books.Where(x => x.ApplicationUserFk == CurrentUser.User.Id).ToList();
            var booksForUserArray = BooksForUser.Select(x => new ListViewItem(x.ToString())).ToArray();
            listView1.Items.Clear();
            listView1.Items.AddRange(booksForUserArray);
        }

        // add new book
        private void button2_Click(object sender, EventArgs e)
        {
            var bookForm = new AddBookForm(DbContext, CurrentUser);

            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                BooksForUser = DbContext.Books.Where(x => x.ApplicationUserFk == CurrentUser.User.Id).ToList();
                var booksForUserArray = BooksForUser.Select(x => new ListViewItem(x.ToString())).ToArray();
                listView1.Items.Clear();
                listView1.Items.AddRange(booksForUserArray);
            }
        }

        // remove book
        private void button1_Click(object sender, EventArgs e)
        {
            var indexOfBook = listView1.SelectedItems[0].Index;
            var book = BooksForUser[indexOfBook];
            BooksForUser.RemoveAt(indexOfBook);
            DbContext.Books.Remove(book);
            DbContext.SaveChanges();
            listView1.Items.Clear();
            var booksForUserArray = BooksForUser.Select(x => new ListViewItem(x.ToString())).ToArray();
            listView1.Items.AddRange(booksForUserArray);
        }

        // logout
        private void button3_Click(object sender, EventArgs e)
        {
            CurrentUser.Logout();
            Close();
        }
    }
}
