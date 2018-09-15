using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorTitle> AuthorTitles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTitle> CategoryTitles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryTitle>().HasKey(c => new { c.CategoryID , c.TitleID});
            builder.Entity<AuthorTitle>().HasKey(a => new { a.AuthorID, a.TitleID });

            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Publisher>().HasIndex(p => p.Name).IsUnique();
            builder.Entity<Language>().HasIndex(l => l.Name).IsUnique();


        }
    }
}
