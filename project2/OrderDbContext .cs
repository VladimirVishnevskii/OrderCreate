using Microsoft.EntityFrameworkCore;
using project2.Models;
using System.Collections.Generic;

namespace project2
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=orderdb;Username=postgres;Password=2107");
        }
        public DbSet<Order> Orders { get; set; }
    }
}
