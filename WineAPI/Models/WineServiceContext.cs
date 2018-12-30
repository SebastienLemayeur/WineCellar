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
                .ToTable("Publisher")
                .HasData();

            modelBuilder.Entity<Chateau>()
                .ToTable("Author")
                .HasData();
        }

        public DbSet<Wine> Publishers { get; set; }
        public DbSet<Chateau> Authors { get; set; }
    }
}
