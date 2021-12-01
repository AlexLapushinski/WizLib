using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WizLib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        //public DbSet<Category> Categories { set; get; }
        public DbSet<Genre> Genres { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<Publisher> Publishers { set; get; }
        public DbSet<BookAuthor> BookAuthors { set; get; }

        public DbSet<Fluent_BookDetail> Fluent_BookDetails { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure Fluent API

            // composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            // BookDetail
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(bd => bd.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(bd => bd.NumberOfChapters).IsRequired();
        }
    }
}
