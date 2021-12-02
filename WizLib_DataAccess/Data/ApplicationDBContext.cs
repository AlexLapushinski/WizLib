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

            // BookDetail
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(bd => bd.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(bd => bd.NumberOfChapters).IsRequired();

            // Book
            modelBuilder.Entity<Fluent_Book>().HasKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Price).IsRequired();
            // one to one relation between book and book detail
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_id");
            // one to many relation between book and publisher
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_Publisher)
                .WithMany(b => b.Fluent_Books).HasForeignKey(b => b.Publisher_Id);
            // many to many relation
            modelBuilder.Entity<Fluent_BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(b => b.Fluent_Book)
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(b => b.Fluent_Author)
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(b => b.Author_Id);

            // Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);

            // Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();

            
        }
    }
}
