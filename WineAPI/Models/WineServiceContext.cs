using Microsoft.EntityFrameworkCore;
using System;

namespace WineAPI.Models
{
    public class WineServiceContext : DbContext
    {
        public WineServiceContext(DbContextOptions<WineServiceContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Wine>()
                .ToTable("Wine")
                .HasData();

            modelBuilder.Entity<Producer>()
                .ToTable("Producer")
                .HasData();

            modelBuilder.Entity<WineType>()
                .ToTable("Type")
                .HasData();
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<WineType> Types { get; set; }
    }
}
