using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WizLib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            // Name of Table

            // Book
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.Price).IsRequired();

            // one to one relation between book and book detail
            modelBuilder
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_id");
            // one to many relation between book and publisher
            modelBuilder
                .HasOne(b => b.Fluent_Publisher)
                .WithMany(b => b.Fluent_Books).HasForeignKey(b => b.Publisher_Id);            
        }
    }
}
