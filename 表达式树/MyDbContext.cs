using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 表达式树
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Demo1;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder.LogTo(Console.WriteLine));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Book>().HasKey(it => it.BookID);
         //   modelBuilder.Entity<Book>().Property(it => it.Name).IsRequired().HasMaxLength(50);
         //   modelBuilder.ApplyConfigurationsFromAssembly(modelBuilder.GetType().Assembly);
            //  base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
