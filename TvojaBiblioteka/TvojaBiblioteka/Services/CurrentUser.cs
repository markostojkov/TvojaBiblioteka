using System.Linq;
using TvojaBiblioteka.Persistence.DbContext;
using TvojaBiblioteka.Persistence.Entities;

namespace TvojaBiblioteka.Services
{
    public class CurrentUser
    {
        public CurrentUser(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationUser User { get; set; }

        public bool IsLoggedIn => User != null;

        public AppDbContext DbContext { get; }

        public bool Login(string username, string password)
        {
            var user = DbContext.ApplicationUsers.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                User = user;
                return true;
            }

            return false;
        }

        public bool Register(string username, string password)
        {
            var userExists = DbContext.ApplicationUsers.FirstOrDefault(x => x.Username == username);

            if (userExists != null)
            {
                return false;
            }

            DbContext.ApplicationUsers.Add(new ApplicationUser()
            {
                Username = username,
                Password = password
            });
            DbContext.SaveChanges();
            return true;
        }

        public void Logout()
        {
            User = null;
        }
    }
}
