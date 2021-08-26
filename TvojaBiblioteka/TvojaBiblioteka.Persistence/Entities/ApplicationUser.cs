using System.Collections.Generic;

namespace TvojaBiblioteka.Persistence.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
