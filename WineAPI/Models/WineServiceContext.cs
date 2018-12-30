using Microsoft.EntityFrameworkCore;
using System;
using WineLib.Models;

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
                        Id = 1,
                        Name = "Tour de Bonnet",
                        Year = 2013,
                        Amount = 1,
                        PurchasedOn = new DateTime(2016, 5, 10),
                        DrinkBefore = 2018
                    },
                    new Wine
                    {
                        Id = 2,
                        Name = "Saint-Emilion Grand Cru",
                        Price = 13.99m,
                        Year = 2010,
                        Amount = 5,
                        PurchasedOn = new DateTime(2012, 6, 8),
                        DrinkBefore = 2016
                    }, 
                    new Wine
                    {
                        Id = 3,
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
                        Id = 1,
                        Name = "Union de producteurs de Saint-Emilion",
                        Country = "France",
                        Region = "Saint-Emilion"
                    },
                    new Producer
                    {
                        Id = 2,
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
                        Id = 1,
                        Type = "Red",
                        Description = "Red wines"
                    },
                    new WineType
                    {
                        Id = 2,
                        Type = "White",
                        Description = "White wines"
                    },
                    new WineType
                    {
                        Id = 3,
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
