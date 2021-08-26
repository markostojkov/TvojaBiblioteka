using Microsoft.EntityFrameworkCore;
using System;
using TvojaBiblioteka.Persistence.Entities;

namespace TvojaBiblioteka.Persistence.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var db = $"Data Source={path}{System.IO.Path.DirectorySeparatorChar}TvojaBiblioteka.db";
            optionsBuilder.UseSqlite(db);
        }
    }
}
