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
                .HasData(
                    new Wine
                    {
                        Name = "Tour de Bonnet",
                        Year = 2013,
                        Amount = 1,
                        PurchasedOn = new DateTime(2016, 5, 10),
                        DrinkBefore = 2018
                    },
                    new Wine
                    {
                        Name = "Saint-Emilion Grand Cru",
                        Price = 13.99m,
                        Year = 2010,
                        Amount = 5,
                        PurchasedOn = new DateTime(2012, 6, 8),
                        DrinkBefore = 2016
                    }, 
                    new Wine
                    {
                        Name = "Tour de Bonnet",
                        Price = 13.99m,
                        Year = 2013,
                        Amount = 1,
                        PurchasedOn = new DateTime(2016, 5, 10)
                    }

                );

            modelBuilder.Entity<Producer>()
                .ToTable("Producer")
                .HasData(
                    new Producer
                    {
                        Name = "Union de producteurs de Saint-Emilion",
                        Country = "France",
                        Region = "Saint-Emilion"
                    },
                    new Producer
                    {
                        Name = "André Lurton",
                        Country = "France",
                        Region = "Bordeaux"
                    }
                );

            modelBuilder.Entity<WineType>()
                .ToTable("Type")
                .HasData(
                    new WineType
                    {
                        Type = "Red",
                        Description = "Red wines"
                    },
                    new WineType
                    {
                        Type = "White",
                        Description = "White wines"
                    },
                    new WineType
                    {
                        Type = "Dessert",
                        Description = "Wines best suited for dessert"
                    }
                );
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<WineType> Types { get; set; }
    }
}
