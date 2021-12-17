using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WizLib_DataAccess.FluentConfig;
using WizLib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<BookDetailsFromView> BookDetailsFromViews { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Genre> Genres { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<BookDetail> BookDetails { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<Publisher> Publishers { set; get; }
        public DbSet<BookAuthor> BookAuthors { set; get; }

        public DbSet<Fluent_BookDetail> Fluent_BookDetails { set; get; }
        public DbSet<Fluent_Book> Fluent_Books { set; get; }
        public DbSet<Fluent_Author> Fluent_Authors { set; get; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure Fluent API

            // Category table name and column name
            modelBuilder.Entity<Category>().ToTable("tbl_category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");

            // composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailsConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<BookDetailsFromView>().HasNoKey().ToView("GetOnlyBookDetails");
        }
    }
}
