using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MyDatabase
{
    public class MyDb : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost; " +
                "Database=MyDb; " +
                "Integrated Security=True; " +
                "TrustServerCertificate=True;"
                );
        }
    }
}
