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
    }
}
